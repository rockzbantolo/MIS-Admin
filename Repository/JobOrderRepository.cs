using MIS_Admin.Core;
using MIS_Admin.Models;
using MIS_Admin.UI.Dto;
using MIS_Admin.UI.Dto.Lookup;
using Next.Clients.Providers;


namespace MIS_Admin.Repository
{
    public class JobOrderRepository
    {
        private readonly MySqlDb Db;

        public JobOrderRepository() {
            Db = Database.Instance;
        }

        public async Task<PaginationDto<ServicingDto>> GetAllJobOrders(
            int? id = null,
            string search = null,
            IEnumerable<string> filters = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            int page = 1,
            int pageSize = 100)
        {
            // Count total rows for pagination
            string countStmt = @"
            SELECT COUNT(*) 
            FROM vw_service_info
            WHERE
                (@Id IS NULL OR Dispatcher_ID = @Id)
                AND (@Filters IS NULL OR Service_Result IN @Filters)
                AND (@StartDate IS NULL OR Created_Date >= @StartDate)
                AND (@EndDate IS NULL OR Created_Date <= @EndDate)
                AND (@Search IS NULL OR @Search = ''
                     OR Terminal_SN = @Search
                     OR Sim_SN = @Search
                     OR TID = @Search
                     OR Job_ID = @Search
                     OR Merchant_Name LIKE CONCAT('%', @Search, '%')
                     OR Dispatch_By LIKE CONCAT('%', @Search, '%'));";

            var totalCount = await Db.ExecuteScalarAsync<int>(countStmt, new
            {
                Id = id,
                Filters = filters,
                StartDate = startDate,
                EndDate = endDate,
                Search = search
            });

            // Fetch paged data
            string dataStmt = @"
             SELECT 
                Job_ID,
                Request_No,
                IFNULL(Merchant_Name, 'N/A') AS Merchant,
                IFNULL(REPLACE(Request, 'FOR ', ''), 'N/A') AS Service,
                CASE 
                    WHEN Days < 1 OR Days = 1 THEN 'NORMAL'
                    WHEN Days BETWEEN 2 AND 4 THEN 'MEDIUM'
                    WHEN Days BETWEEN 5 AND 8 THEN 'HIGH'
                    WHEN Days >= 9 THEN 'CRITICAL'
                    ELSE 'Unknown'
                END AS Priority,
                CASE 
                    WHEN Service_Result = 'NEGATIVE' THEN
                        CASE 
                            WHEN Type_ID IN (1, 4) THEN 'FAILED'
                            WHEN Type_ID IN (3, 6, 7) THEN 'NO RESPONSE'
                            ELSE 'N/A'
                        END
                    WHEN Service_Result = 'COMPLETED' THEN
                        CASE 
                            WHEN Type_ID = 1 THEN 'INSTALLED'
                            ELSE 'COMPLETED'
                        END
                    WHEN Status_ID = 2 THEN 'ASSIGNED'
                    WHEN Status_ID = 8 THEN 'DISPATCHED'
                    WHEN Service_Result = 'PENDING' THEN 'PROCESSING'
                    ELSE 'N/A'
                END AS Status,
                CASE 
                    WHEN Service_Result = 'COMPLETED' THEN 'SUCCESS'
                    ELSE Service_Result
                END AS Result,
                IFNULL(NULLIF(Terminal_SN, 0), 'N/A') AS Terminal,
                IFNULL(NULLIF(Sim_SN, 0), 'N/A') AS Sim,
                CASE 
                    WHEN Prov_ID = 5 THEN 'PROVINCE' 
                    WHEN Prov_ID = 4 THEN 'MANILA' 
                    ELSE IFNULL(Province, 'N/A')
                END AS Region,
                IFNULL(Days, 0) AS SLA,
                IF(STR_TO_DATE(Dispatch_Date_Time, '%Y-%m-%d') IS NOT NULL,
                    DATE_FORMAT(Dispatch_Date_Time, '%b %d, %Y'),
                    'N/A') AS Request_Date,
                IF(STR_TO_DATE(Dispatch_Date_Time, '%Y-%m-%d') IS NOT NULL, 
                    DATE_FORMAT(Dispatch_Date_Time, '%h:%i %p, %b %d, %Y'), 
                    'N/A') AS Dispatch_Date
             FROM 
                vw_service_info
             WHERE
                (@Id IS NULL OR Dispatcher_ID = @Id)
                AND (@Filters IS NULL OR Service_Result IN @Filters)
                AND (@StartDate IS NULL OR Created_Date >= @StartDate)
                AND (@EndDate IS NULL OR Created_Date <= @EndDate)
                AND (@Search IS NULL OR @Search = ''
                     OR Terminal_SN = @Search
                     OR Sim_SN = @Search
                     OR TID = @Search
                     OR Job_ID = @Search
                     OR Merchant_Name LIKE CONCAT('%', @Search, '%')
                     OR Dispatch_By LIKE CONCAT('%', @Search, '%'))
             ORDER BY Processed_Date_Time DESC
             LIMIT @PageSize OFFSET @Offset;";

            var data = await Db.QueryAsync<ServicingDto>(dataStmt, new
            {
                Id = id,
                Filters = filters,
                StartDate = startDate,
                EndDate = endDate,
                Search = search,
                PageSize = pageSize,
                Offset = (page - 1) * pageSize
            });

            return new PaginationDto<ServicingDto>
            {
                Data = data,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<JobOrderModel> GetJobOrderInfoAsync(int jobId)
        {
            string stmt = @"
            SELECT
                ServiceNo AS Id,
                IRIDNo AS IRId,
                IRNo AS IRNumber,
                JobType AS JobTypeId,
                JobTypeDescription AS JobTypeDesc,
                JobTypeSubDescription AS JobTypeSubDesc,
                JobTypeStatusDescription AS JobTypeStatusDesc,
                MerchantID AS MerchantId,
                MerchantName AS MerchantName,
                TerminalID AS TerminalId,
                TerminalSN AS TerminalSerial,
                SIMID AS SIMId,
                SIMSerialNo AS SIMSerial,
                ReplaceTerminalID AS ReplaceTerminalId,
                ReplaceTerminalSN AS ReplaceTerminalSerial,
                ReplaceSIMID AS ReplaceSIMId,
                ReplaceSIMSN AS ReplaceSIMSerial,
                ReplaceDockID AS ReplaceDockId,
                ReplaceDockSN AS ReplaceDockSerial,
                ReplacePowerSN AS ReplacePowerSerial,
                FEID AS FEId,
                FEName AS FEName,
                ClientID AS ClientId,
                ClientName AS ClientName,
                ActionMade AS ActionMade,
                ServiceDateTime AS ServiceDateTime,
                ServiceDate AS ServiceDate,
                ServiceTime AS ServiceTime,
                ReqInstallationDate AS ReqInstallDate,
                ReqInstallationTime AS ReqInstallTime,
                ServiceReqDate AS ServiceReqDate,
                ServiceReqTime AS ServiceReqTime,
                ReportedDate AS ReportedDate,
                LastServiceRequest AS LastServiceRequest,
                CurTerminalSNStatus AS CurTerminalStatus,
                CurSIMSNStatus AS CurSIMStatus,
                CurDockSNStatus AS CurDockStatus,
                CurTerminalSNStatusDescription AS CurTerminalStatusDesc,
                CurSIMSNStatusDescription AS CurSIMStatusDesc,
                CurDockSNStatusDescription AS CurDockStatusDesc,
                RepTerminalSNStatus AS RepTerminalStatus,
                RepSIMSNStatus AS RepSIMStatus,
                RepDockSNStatus AS RepDockStatus,
                RepTerminalSNStatusDescription AS RepTerminalStatusDesc,
                RepSIMSNStatusDescription AS RepSIMStatusDesc,
                RepDockSNStatusDescription AS RepDockStatusDesc,
                ServiceStatus AS ServiceStatusId,
                ServiceStatusDescription AS ServiceStatusDesc,
                ServiceCode AS ServiceCode,
                RegionID AS RegionId,
                RegionType AS RegionType,
                CounterNo AS CounterNo,
                DockID AS DockId,
                DockSN AS DockSerial,
                RequestNo AS RequestNo,
                CustomerName AS CustomerName,
                CustomerContactNo AS CustomerContactNo,
                CustomerPosition AS CustomerPosition,
                CustomerEmail AS CustomerEmail,
                ProblemReported AS ProblemReported,
                Remarks AS Remarks,
                RMInstruction AS RMInstruction,
                NewServiceRequest AS NewServiceRequest,
                ReasonID AS ReasonId,
                ExpensesID AS ExpensesId,
                TExpenses AS TotalExpenses,
                ReferenceNo AS ReferenceNo,
                ProcessedBy AS ProcessedBy,
                ModifiedBy AS ModifiedBy,
                ProcessedDateTime AS ProcessedDateTime,
                ModifiedDateTime AS ModifiedDateTime,
                DispatchID AS DispatchId,
                DispatchBy AS DispatchBy,
                DispatchDateTime AS DispatchDateTime,
                DispatchDate AS DispatchDate,
                DispatchTime AS DispatchTime,
                isPrimary AS IsPrimary,
                isClose AS IsClose,
                AppVersion AS AppVersion,
                AppCRC AS AppCRC,
                isCancelled AS IsCancelled,
                isBillable AS IsBillable,
                TicketStatus AS TicketStatus,
                TicketID AS TicketId,
                TicketDateTime AS TicketDateTime,
                DateTimeStamp AS DateTimeStamp,
                SourceID AS SourceId,
                CategoryID AS CategoryId,
                SubCategoryID AS SubCategoryId,
                Vendor AS Vendor,
                Requestor AS Requestor,
                AssistNo AS AssistNo,
                ProblemNo AS ProblemNo,
                isReport AS IsReport,
                BillingTypeID AS BillingTypeId,
                isActive AS IsActive
            FROM tblservicingdetail
            WHERE ServiceNo = @ServiceNo
            LIMIT 1;";

            return await Db.QueryFirstOrDefaultAsync<JobOrderModel>(
                stmt,
                new { ServiceNo = jobId }
            );
        }

        public async Task<IEnumerable<JobOrderHistoryLookupDto>> GetAllJobOrderMerchantHistory(int id)
        {
            const string sql = @"
            SELECT
                s.ServiceNo AS Id,
                REPLACE(s.JobTypeSubDescription, 'FOR', '') AS JobType,
                f.ActionMade          AS Status,
                DATE_FORMAT(f.FSRDate, '%b %e, %Y') AS Date
            FROM tblservicingdetail s
            LEFT JOIN tblfsrdetail f ON f.ServiceNo = s.ServiceNo
            WHERE s.MerchantID = @id";

            return await Db.QueryAsync<JobOrderHistoryLookupDto>(sql, new { id });
        }


        // Summary
        public async Task<IEnumerable<dynamic>> GetAllDispatchJobOrdersAsync(DateTime targetDate, int? id = null)
        {
            int monthParam = targetDate.Month;
            int yearParam = targetDate.Year;

            string stmt = @"
            SELECT
                REPLACE(Request, 'FOR ', '') AS Service,
                Dispatch_By AS Dispatcher,
                SUM(CASE WHEN Status_ID = 8 OR Dispatcher_ID IS NULL THEN 1 ELSE 0 END) AS Pending,
                SUM(CASE WHEN Status_ID = 7 AND Service_Result = 'COMPLETED' THEN 1 ELSE 0 END) AS Completed
            FROM vw_service_info
            WHERE (@Id IS NULL OR Dispatcher_ID = @Id)
                AND MONTH(Created_Date) = @Month
                AND YEAR(Created_Date)  = @Year                
            GROUP BY Dispatcher_ID, Type_ID, Request
            HAVING Pending <> 0 AND Completed <> 0
            ORDER BY Pending, Dispatcher;";

            return await Db.QueryAsync<dynamic>(stmt, new { Id = id, Month = monthParam, Year = yearParam });
        }

        public async Task<IEnumerable<dynamic>> GetAllJobOrderSummaryAsync(DateTime date, int? id = null)
        {
            string stmt = @"
               SELECT
                    CASE
                        WHEN GROUPING(Type_ID) = 1 THEN 'ALL SERVICES'
                        ELSE MAX(REPLACE(Request, 'FOR ', ''))
                    END AS Description,

                    CAST(SUM(CASE 
                        WHEN Status_ID IN (7, 11) AND Service_Result = 'COMPLETED' THEN 1 
                        ELSE 0 
                    END) AS SIGNED) AS Completed,

                    CAST(SUM(CASE 
                        WHEN Status_ID = 8 THEN 1 
                        ELSE 0 
                    END) AS SIGNED) AS Dispatch,

                    CAST(SUM(CASE 
                        WHEN Status_ID = 2 THEN 1 
                        ELSE 0 
                    END) AS SIGNED) AS Pending,

                    CAST(SUM(CASE 
                        WHEN Status_ID = 9 THEN 1 
                        ELSE 0 
                    END) AS SIGNED) AS Negative,

                    CAST(SUM(
                        (CASE WHEN Status_ID IN (7, 11) AND Service_Result = 'COMPLETED' THEN 1 ELSE 0 END) +
                        (CASE WHEN Status_ID = 8 THEN 1 ELSE 0 END) +
                        (CASE WHEN Status_ID = 2 THEN 1 ELSE 0 END) +
                        (CASE WHEN Status_ID = 9 THEN 1 ELSE 0 END)
                    ) AS SIGNED) AS Total
                FROM vw_service_info
                WHERE (@Id IS NULL OR Dispatcher_ID = @Id)
                        AND DATE(Created_Date) = DATE(@Date)
                        AND YEAR(Created_Date) = YEAR(@Date)
                GROUP BY Type_ID WITH ROLLUP;
                ";

            return await Db.QueryAsync<dynamic>(stmt, new { Id = id, Date = date });
        }

        public async Task<IEnumerable<dynamic>> GetAllJobOrderAreaSummaryAsync(DateTime date, int? id = null)
        {
            string stmt = @"
            SELECT 'Summary' AS Description,
                FORMAT(SUM(CASE WHEN Prov_ID = 4 THEN 1 ELSE 0 END), 0) AS Manila,
                FORMAT(SUM(CASE WHEN Prov_ID = 5 THEN 1 ELSE 0 END), 0) AS Province,
                COUNT(*) AS TotalServices
            FROM vw_service_info
            WHERE (@Id IS NULL OR Dispatcher_ID = @Id)
            AND MONTH(Created_Date) = MONTH(@Date)
            AND YEAR(Created_Date) = YEAR(@Date);";

            return await Db.QueryAsync<dynamic>(stmt, new { Id = id, Date = date });
        }

        public async Task<IEnumerable<dynamic>> GetAllMonthlyJobOrderCountAsync(int? id = null)
        {
            string stmt = @"
            SELECT
                DATE_FORMAT(Created_Date, '%M') AS Month,
                FORMAT(COUNT(*), 0) AS TotalServices
            FROM vw_service_info
            WHERE (@Id IS NULL OR Dispatcher_ID = @Id) 
                AND Request_Status = 'SUCCESS'
                AND YEAR(Created_Date) = YEAR(CURDATE())
            GROUP BY YEAR(Created_Date), MONTH(Created_Date)
            ORDER BY YEAR(Created_Date), MONTH(Created_Date);";

            return await Db.QueryAsync<dynamic>(stmt, new { Id = id });
        }

        public async Task<IEnumerable<dynamic>> GetAllMonthlySlaAsync(DateTime targetDate, int? id = null)
        {
            int monthParam = targetDate.Month;
            int yearParam = targetDate.Year;

            string stmt = @"
                SELECT
                    COALESCE(SUM(CASE WHEN TAT_Status = 'Beyond' THEN 1 ELSE 0 END), 0) AS Beyond,
                    COALESCE(SUM(CASE WHEN TAT_Status = 'Within' THEN 1 ELSE 0 END), 0) AS Within
                FROM vw_service_info
                WHERE (@Id IS NULL OR Dispatcher_ID = @Id)
                AND MONTH(Created_Date) = @Month
                AND YEAR(Created_Date) = @Year
                AND Request_Status = 'SUCCESS';";

            return await Db.QueryAsync<dynamic>(stmt, new
            {
                Id = id,
                Month = monthParam,
                Year = yearParam
            });
        }

        public async Task<IEnumerable<dynamic>> GetAllJobOrderRequestAsync(DateTime date)
        {
            string stmt = @"
                SELECT 
                    Request_No,
                    Merchant,
                    TID,
                    MID
                FROM vw_installation_info
                WHERE
                    Status_ID = 1
                    AND (@Date IS NULL OR DATE(Created_Date) = @Date);";

            return await Db.QueryAsync<dynamic>(stmt, new { Date = date });
        }

        public async Task<IEnumerable<dynamic>> GetAllUnclosedTicketsAsync(DateTime date, int? id = null)
        {
            string stmt = @"
                SELECT 
                    Request_No AS `Request No`,
                    Merchant_Name AS `Merchant`,
                    CASE 
                        WHEN Request_Status = 'SUCCESS' THEN 'COMPLETED'
                        ELSE Request_Status
                    END AS `Status`,
                    Dispatch_By AS `Dispatcher`,
                    FE_Name AS `Engineer`
                FROM vw_service_info
                WHERE (@Id IS NULL OR Dispatcher_ID = @Id)
                    AND MONTH(Created_Date) = MONTH(@Date)
                    AND YEAR(Created_Date) = YEAR(@Date)
                    AND Request_Status IN ('SUCCESS','NEGATIVE')
                    AND Ticket_ID = 0;";

            return await Db.QueryAsync<dynamic>(stmt, new { Id = id, Date = date });
        }


        // Selectable
        public async Task<IEnumerable<ServiceTypeLookupDto>> GetSelectedServiceTypesAsync(
           int? id = null,
           int? limit = 10)
        {
            string sql = @"
            SELECT 
                JobType AS Id,
                JobTypeDescription AS Description
            FROM tblservicetype
            WHERE isActive = 1
                AND (@Id IS NULL OR JobType = @Id)
            ORDER BY SequenceDisplay ASC
            LIMIT @Limit;";

            return await Db.QueryAsync<ServiceTypeLookupDto>(sql, new { Id = id, Limit = limit });
        }

        public async Task<IEnumerable<ServiceTypeLookupDto>> GetSelectedServiceResultsAsync(
           int? id = null,
           int? limit = 10)
        {
            string sql = @"
            SELECT 
                ServiceStatus AS Id,
                ServiceStatusDescription AS Description
            FROM tblservicetype
            WHERE ServiceTypeActive = 1
              AND (@Id IS NULL OR ServiceStatus = @Id)
            ORDER BY SequenceDisplay ASC
            LIMIT @Limit;";

            return await Db.QueryAsync<ServiceTypeLookupDto>(sql, new { Id = id, Limit = limit });
        }


        public void Save() { }
        public void Delete() { }
        public void Update() { }

    }
}
