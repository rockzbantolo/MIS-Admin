using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MIS_Admin.Core
{
    internal class Base : Connection
    {
        private static readonly MemoryCache _cache = MemoryCache.Default;
        private static readonly Dictionary<string, HashSet<string>> _cacheDependencies = new();

        // ---------- SELECT ----------

        protected DataTable Select(string query, params MySqlParameter[] parameters)
        {
            string cacheKey = BuildCacheKey(query, parameters);

            if (_cache.Contains(cacheKey))
                return (DataTable)_cache.Get(cacheKey);

            using (var conn = GetConnection())
            {
                conn.Open(); // <-- open explicitly for sync

                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);

                        CacheResult(cacheKey, dt, query);
                        return dt;
                    }
                }
            }
        }

        protected async Task<DataTable> SelectAsync(string query, params MySqlParameter[] parameters)
        {
            string cacheKey = BuildCacheKey(query, parameters);

            if (_cache.Contains(cacheKey))
                return (DataTable)_cache.Get(cacheKey);

            using (var conn = GetConnection())
            {
                await conn.OpenAsync(); // <-- open explicitly for async

                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);

                        CacheResult(cacheKey, dt, query);
                        return dt;
                    }
                }
            }
        }

        // ---------- EXECUTE (INSERT/UPDATE/DELETE) ----------

        protected int Execute(string query, string tableName, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    int rows = cmd.ExecuteNonQuery();

                    InvalidateCacheForTable(tableName);
                    return rows;
                }
            }
        }

        protected async Task<int> ExecuteAsync(string query, string tableName, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    int rows = await cmd.ExecuteNonQueryAsync();

                    InvalidateCacheForTable(tableName);
                    return rows;
                }
            }
        }

        // ---------- SCALAR ----------

        protected object Scalar(string query, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteScalar();
                }
            }
        }

        protected async Task<object> ScalarAsync(string query, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    return await cmd.ExecuteScalarAsync();
                }
            }
        }

        // ---------- TRANSACTION ----------

        protected void Transact(Action<MySqlConnection, MySqlTransaction> action, params string[] affectedTables)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        action(conn, tx);
                        tx.Commit();

                        foreach (var table in affectedTables)
                            InvalidateCacheForTable(table);
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        protected async Task TransactAsync(Func<MySqlConnection, MySqlTransaction, Task> action, params string[] affectedTables)
        {
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();

                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        await action(conn, tx);
                        tx.Commit();

                        foreach (var table in affectedTables)
                            InvalidateCacheForTable(table);
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        // ---------- Helper Methods ----------

        private string BuildCacheKey(string query, MySqlParameter[] parameters)
        {
            var sb = new StringBuilder(query);
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    sb.Append($"|{p.ParameterName}:{Convert.ToString(p.Value, System.Globalization.CultureInfo.InvariantCulture)}");
                }
            }
            return sb.ToString();
        }

        private void CacheResult(string cacheKey, DataTable dt, string query)
        {
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
            };
            _cache.Add(cacheKey, dt, policy);

            TrackDependency(cacheKey, query);
        }

        private void TrackDependency(string cacheKey, string query)
        {
            // naive: take first word after FROM
            var match = Regex.Match(query, @"FROM\s+(\w+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                string table = match.Groups[1].Value.ToLowerInvariant();

                if (!_cacheDependencies.ContainsKey(table))
                    _cacheDependencies[table] = new HashSet<string>();

                _cacheDependencies[table].Add(cacheKey);
            }
        }

        private void InvalidateCacheForTable(string tableName)
        {
            tableName = tableName.ToLowerInvariant();

            if (_cacheDependencies.TryGetValue(tableName, out var keys))
            {
                foreach (var key in keys)
                    _cache.Remove(key);

                _cacheDependencies.Remove(tableName);
            }
        }
    }
}
