using MIS_Admin.Core;
using MIS_Admin.UI.Dto;
using MIS_Admin.UI.Dto.Lookup;
using Next.Clients.Providers;

namespace MIS_Admin.Repository
{
    public class TerminalRepository
    {
        private readonly MySqlDb Db;

        public TerminalRepository() {
            Db = Database.Instance;
        }

        public async Task<PaginationDto<TerminalInfoDto>> GetAllTerminalInfosAsync(
         int? id = null,
         string search = null,
         IEnumerable<string> filters = null,
         DateTime? startDate = null,
         DateTime? endDate = null,
         int page = 1,
         int pageSize = 100)
        {
            string countStmt = @"
            SELECT COUNT(*)
            FROM vw_terminal_info
            WHERE
                (@Id IS NULL OR Terminal_ID = @Id)
                AND (@Filters IS NULL OR Status IN @Filters)
                AND (@StartDate IS NULL OR Delivery_Date >= @StartDate)
                AND (@EndDate IS NULL OR Delivery_Date <= @EndDate)
                AND (@Search IS NULL OR @Search = ''
                    OR Terminal_SN = @Search
                    OR Brand = @Search
                    OR Model = @Search);";

            var totalCount = await Db.ExecuteScalarAsync<int>(countStmt, new
            {
                Id = id,
                Filters = filters,
                StartDate = startDate,
                EndDate = endDate,
                Search = search
            });

            string stmt = @"
            SELECT 
                Terminal_ID AS `Id`,
                Terminal_SN AS `Serial`,
                Status,
                Model_ID as ModelId,
                Model as Description,
                Location,
                Type,
                Code,
                Brand,
                Part_No as PartNo,
                App_Version as AppVersion,
                App_Crc as AppCrc,
                Asset,
                Delivery_Date as DeliveryDate
            FROM vw_terminal_info
            WHERE
                (@Id IS NULL OR Terminal_ID = @Id)
                AND (@Filters IS NULL OR Status IN @Filters)
                AND (@StartDate IS NULL OR Delivery_Date >= @StartDate)
                AND (@EndDate IS NULL OR Delivery_Date <= @EndDate)
                AND (@Search IS NULL OR @Search = ''
                    OR Terminal_SN = @Search
                    OR Brand = @Search
                    OR Model = @Search)
            ORDER BY Terminal_ID DESC
            LIMIT @PageSize OFFSET @Offset;";

            var data = await Db.QueryAsync<TerminalInfoDto>(stmt, new
            {
                Id = id,
                Filters = filters,
                StartDate = startDate,
                EndDate = endDate,
                Search = search,
                PageSize = pageSize,
                Offset = (page - 1) * pageSize
            });

            return new PaginationDto<TerminalInfoDto>
            {
                Data = data,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<IEnumerable<DeviceLookupDto>> GetTerminalsForSelectAsync(
            string search = null,
            int limit = 10)
        {
            string stmt = @"
            SELECT Terminal_ID AS Id,
                    Terminal_SN AS Serial
            FROM vw_terminal_info
            WHERE (@Search IS NULL OR Terminal_SN LIKE CONCAT('%', @Search, '%'))
            AND isActive = 1
            ORDER BY Terminal_ID DESC
            LIMIT @Limit;";

            return await Db.QueryAsync<DeviceLookupDto>(stmt, new
            {
                Search = search,
                Limit = limit
            });
        }

        public async Task<IEnumerable<dynamic>> GetAllInstalledTerminalCountAsync(int? id = null)
        {
            string stmt = @"
            SELECT 'Summary' AS Description,
                FORMAT(SUM(CASE WHEN x.RegionID = 4 THEN 1 ELSE 0 END), 0) AS Manila,
                FORMAT(SUM(CASE WHEN x.RegionID = 5 THEN 1 ELSE 0 END), 0) AS Province,
                FORMAT(COUNT(*), 0) AS Total,
                FORMAT(SUM(x.DuplicateCount - 1), 0) AS Duplicates
            FROM (
                SELECT 
                    t.TerminalID,
                    r.RegionID,
                    COUNT(i.TerminalID) AS DuplicateCount
                FROM tblterminaldetail t
                JOIN tblirdetail i ON i.TerminalID = t.TerminalID
                LEFT JOIN tblparticular p ON p.ParticularID = i.MerchantID
                LEFT JOIN tblregion r ON r.RegionID = p.RegionType
                WHERE t.TerminalStatus = 7
                GROUP BY t.TerminalID
            ) AS x

            WHERE (@Id IS NULL OR x.RegionID = @Id);";

            return await Db.QueryAsync<dynamic>(stmt, new { Id = id });
        }

        public void Save() { }
        public void Delete() { }
        public void Update() { }


    }
}
