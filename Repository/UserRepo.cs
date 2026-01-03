using MIS_Admin.Core;
using Next.Clients.Providers;

namespace MIS_Admin.Repository
{
    internal class UserRepo
    {
        private readonly MySqlDb Db;

        public UserRepo() => Db = Database.Instance;
        
        public async Task<IEnumerable<dynamic>> FindAccountAsync(object username)
        {
            string stmt = @"
                SELECT   
                    a.UserID AS UserID,
                    a.ParticularID AS ParticularID,
                    a.UserName AS UserName,
                    a.FullName AS FullName,
                    a.`Password` AS `Password`,		
                    a.MD5Password AS MD5Password,
                    a.UserType AS UserType,
                    IFNULL(b.isActive, 0) AS isActive,
                    IFNULL(b.isAppVersion, 0) AS isAppVersion,
                    a.MobileID AS MobileID,
                    c.TerminalID AS MobileTerminalID,
                    c.TerminalName AS MobileTerminalName
                FROM tbluser a
                LEFT JOIN tblparticular AS b ON a.ParticularID = b.ParticularID
                LEFT JOIN tblterminal AS c ON a.MobileID = c.TID
                WHERE a.UserName = @username
            ";

            return await Db.QueryAsync<dynamic>(stmt, new { username = username }).ConfigureAwait(false);
        }

        public async Task<bool> UpdateUserStatusAsync(object id, int status, string statusDesc)
        {
            var paramId = id ?? DBNull.Value;
            var paramStatusDesc = string.IsNullOrWhiteSpace(statusDesc) ? DBNull.Value : (object)statusDesc;

            string stmt = @"
                UPDATE tbluser 
                SET 
                    LogStatus = @status,
                    LogStatusDesc = @statusDesc
                WHERE UserID = @id;
            ";

            int rows = await Db.ExecuteAsync(stmt, new
            {
                id = paramId,
                status,
                statusDesc = paramStatusDesc
            }).ConfigureAwait(false);

            return rows > 0;
        }
    }
}
