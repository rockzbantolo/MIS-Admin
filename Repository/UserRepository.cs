using MIS_Admin.Core;
using MIS_Admin.UI.Dto;
using Next.Clients.Providers;

namespace MIS_Admin.Repository
{
    internal class UserRepository
    {
        private readonly MySqlDb Db;

        public UserRepository() => Db = Database.Instance;

        public async Task<PaginationDto<UserInfoDto>> GetAllUsersAsync(
            int? id = null,
            string search = null,
            IEnumerable<string> filter = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            int page = 1,
            int pageSize = 100)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 100;

            // Count total rows
            string countSql = @"
            SELECT COUNT(*) 
            FROM tblparticular
            WHERE (@Id IS NULL OR ParticularID = @Id)
              AND (@Search IS NULL OR NAME LIKE CONCAT('%', @Search, '%'))
              AND (@Filters IS NULL OR ParticularDescription IN @Filters);";

            var totalCount = await Db.ExecuteScalarAsync<int>(countSql, new
            {
                Id = id,
                Filters = filter,
                StartDate = startDate,
                EndDate = endDate,
                Search = search
            });

            // Fetch paged data
            string sql = @"
                SELECT
                    ParticularID AS Id,
                    NAME AS Personel,
                    CONCAT_WS(' / ', NULLIF(TelNo, ''), NULLIF(Mobile, '')) AS ContactNo,
                    NULLIF(Email, '') AS Email,
                    ParticularDescription as Role
                FROM tblparticular
                WHERE (@Id IS NULL OR ParticularID = @Id)
                  AND (@Search IS NULL OR NAME LIKE CONCAT('%', @Search, '%'))
                  AND (@Filters IS NULL OR ParticularDescription IN @Filters)
                ORDER BY NAME
                LIMIT @PageSize OFFSET @Offset;";

            var data = await Db.QueryAsync<UserInfoDto>(sql, new
            {
                Id = id,
                Filters = filter,
                StartDate = startDate,
                EndDate = endDate,
                Search = search,
                PageSize = pageSize,
                Offset = (page - 1) * pageSize
            });

            return new PaginationDto<UserInfoDto>
            {
                Data = data,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }

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
