using MIS_Admin.Core;
using MIS_Admin.UI.Dto;
using MIS_Admin.UI.Dto.Lookup;
using Next.Clients.Providers;

namespace MIS_Admin.Repository
{
    public class MerchantRepository
    {
        private readonly MySqlDb Db;

        public MerchantRepository() {
            Db = Database.Instance;
        }

        public async Task<PaginationDto<dynamic>> GetAllMerchantAsync(
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
            FROM vw_merchant_info m
            LEFT JOIN tblirdetail i ON i.MerchantID = m.Merchant_ID
            LEFT JOIN tblterminaldetail t ON t.TerminalID = i.TerminalID
            LEFT JOIN tblparticular p ON p.ParticularID = i.MerchantID
            LEFT JOIN tblregion r ON r.RegionID = p.RegionType
            WHERE i.IRActive = 1
                AND (@Id IS NULL OR m.Merchant_ID = @Id)
                AND (@Search IS NULL OR @Search = '' 
                    OR i.TID = @Search
                    OR m.Merchant_Name LIKE CONCAT('%', @Search, '%')
                    OR m.Contact_Person LIKE CONCAT('%', @Search, '%')
                    OR m.Province LIKE CONCAT('%', @Search, '%')
                    OR m.Region LIKE CONCAT('%', @Search, '%'))
                AND (@Filters IS NULL
                    OR (UPPER('MANILA') IN @Filters AND r.RegionID = 4)
                    OR (UPPER('PROVINCE') IN @Filters AND r.RegionID = 5)
                    OR (UPPER('DUPLICATE') IN @Filters AND t.TerminalID IN (
                        SELECT TerminalID
                        FROM tblirdetail
                        GROUP BY TerminalID
                        HAVING COUNT(*) >= 2
                    )))
                AND (@StartDate IS NULL OR i.IRDate >= @StartDate)
                AND (@EndDate IS NULL OR i.IRDate <= @EndDate);";

            var totalCount = await Db.ExecuteScalarAsync<int>(countStmt, new
            {
                Id = id,
                Search = string.IsNullOrWhiteSpace(search) ? null : search.Trim(),
                Filters = filters,
                StartDate = startDate,
                EndDate = endDate
            });

            string stmt = @"
            SELECT
                i.IRIDNo AS ID,
                m.Merchant_ID AS Code,
                CASE i.IRStatus
                    WHEN 1 THEN 'AVAILABLE'
                    WHEN 2 THEN 'ASSIGNED'
                    WHEN 7 THEN 'ACTIVE'
                    WHEN 8 THEN 'DISPATCH'
                    WHEN 11 THEN 'INACTIVE'
                    ELSE 'UNKNOWN'
                END AS Status,
                m.Merchant_Name AS Merchant,
                IFNULL(NULLIF(i.TID, '-'), 'N/A') AS TID,
                IFNULL(NULLIF(i.MID, '-'), 'N/A') AS MID,
                IFNULL(NULLIF(i.TerminalSN, 0), 'N/A') AS Terminal,
                IFNULL(NULLIF(i.SIMSN, 0), 'N/A') AS Sim,
                m.Region AS City,
                IF(UPPER(NULLIF(TRIM(m.Contact_Person), '')) = 'X' OR m.Contact_Person IS NULL, 'N/A', m.Contact_Person) AS Contact_Person,
                IF(UPPER(NULLIF(TRIM(m.Contact_No), '')) = 'X' OR m.Contact_No IS NULL, 'N/A', m.Contact_No) AS Contact_No,
                IF(UPPER(NULLIF(TRIM(m.Email), '')) = 'X' OR m.Email IS NULL, 'N/A', m.Email) AS Email
            FROM vw_merchant_info m
            LEFT JOIN tblirdetail i ON i.MerchantID = m.Merchant_ID
            LEFT JOIN tblterminaldetail t ON t.TerminalID = i.TerminalID
            LEFT JOIN tblparticular p ON p.ParticularID = i.MerchantID
            LEFT JOIN tblregion r ON r.RegionID = p.RegionType
            WHERE i.IRActive = 1
                AND (@Id IS NULL OR m.Merchant_ID = @Id)
                AND (@Search IS NULL OR @Search = '' 
                    OR i.TID = @Search
                    OR m.Merchant_Name LIKE CONCAT('%', @Search, '%')
                    OR m.Contact_Person LIKE CONCAT('%', @Search, '%')
                    OR m.Province LIKE CONCAT('%', @Search, '%')
                    OR m.Region LIKE CONCAT('%', @Search, '%'))
                AND (@Filters IS NULL
                    OR (UPPER('MANILA') IN @Filters AND r.RegionID = 4)
                    OR (UPPER('PROVINCE') IN @Filters AND r.RegionID = 5)
                    OR (UPPER('DUPLICATE') IN @Filters AND t.TerminalID IN (
                        SELECT TerminalID
                        FROM tblirdetail
                        GROUP BY TerminalID
                        HAVING COUNT(*) >= 2
                    )))
                AND (@StartDate IS NULL OR i.IRDate >= @StartDate)
                AND (@EndDate IS NULL OR i.IRDate <= @EndDate)
            ORDER BY m.Merchant_Name
            LIMIT @PageSize OFFSET @Offset;";

            var data = await Db.QueryAsync<dynamic>(stmt, new
            {
                Id = id,
                Search = string.IsNullOrWhiteSpace(search) ? null : search.Trim(),
                Filters = filters,
                StartDate = startDate,
                EndDate = endDate,
                PageSize = pageSize,
                Offset = (page - 1) * pageSize
            });

            return new PaginationDto<dynamic>
            {
                Data = data,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<IEnumerable<dynamic>> GetMerchantInstallationInfoAsync(int id)
        {
            string stmt = $@"
                SELECT 
                    Request_No,
                    Merchant,
                    TID,
                    MID,
                    Model_Name,
                    Terminal_SN,
                    Carrier,
                    Sim_SN,
                    Address,
                    IF(UPPER(NULLIF(TRIM(Contact_Person), '')) = 'X' OR Contact_Person IS NULL, 'N/A', Contact_Person) AS `Contact_Person`,
                    IF(UPPER(NULLIF(TRIM(Contact_No), '')) = 'X' OR Contact_No IS NULL, 'N/A', Contact_No) AS `Contact_No`,
                    IF(UPPER(NULLIF(TRIM(Email), '')) = 'X' OR Email IS NULL, 'N/A', Email) AS Email,
                    Region,
                    App_Crc,
                    App_Version,
                    Created_Date
                FROM vw_installation_info
                WHERE (@Id IS NULL OR IR_ID = @Id)
                  AND Status_ID = 7
                  AND isActive = 1;";

            return await Db.QueryAsync<dynamic>(stmt, new { Id = id });
        }

        public async Task<IEnumerable<MultiMerchantLookupDto>> GetMultiMerchant(int id)
        {
            const string sql = @"
            SELECT
                TID,
                TerminalSN,
                SIMSN,
                IRStatusDescription AS STATUS
            FROM tblirdetail
            WHERE MerchantID = @Id";

            return await Db.QueryAsync<MultiMerchantLookupDto>(sql, new { Id = id });
        }

        public async Task<ResultDto> PullOutMerchantAsync(int id)
        {
            string stmt = @"
                UPDATE tblirdetail
                SET 
                    IRStatus = 11,
                    IRStatusDescription = 'PULLED-OUT',
                    TerminalID = 0,
                    TerminalSN = 0,
                    SIMID = 0,
                    SIMSN = 0,
                    IRActive = 0
                WHERE IRIDNo = @Id;";

            int affectedRows = await Db.ExecuteAsync(stmt, new { Id = id });

            return affectedRows > 0 ? ResultDto.Ok() : ResultDto.Fail("No rows affected.");
        }

        public async Task<ResultDto> ReplaceMerchantDeviceAsync(int id, string terminalSN, string simSN)
        {
            var parameters = new
            {
                in_id = id,
                in_NewTerminalSn = terminalSN,
                in_NewSimSn = simSN
            };

            int result = await Db.ExecuteSpAsync("spReplaceDevice", parameters);

            return result > 0
                ? ResultDto.Ok("Success")
                : ResultDto.Fail("No response from procedure.");
        }


        public void Save() { }
        public void Delete() { }
        public void Update() { }
            

    }
}
