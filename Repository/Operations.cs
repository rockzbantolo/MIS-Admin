using MIS_Admin.Core;
using MIS_Admin.Model;
using MIS_Admin.Model.Dto;
using MySql.Data.MySqlClient;
using Next.Clients.Providers;
using System.Data;

namespace MIS_Admin.Repository
{
    internal class Operations : Base
    {
        private readonly MySqlDb Db;

        public Operations() => Db = Database.Instance;
        
        // ---------- Services ----------
        public DataTable FindServices(object search, int limit = 100)
        {
            string stmt = $@"
            SELECT 
                Job_ID AS `Order No`,
                Request_No AS `Request No`,
                Merchant_Name AS `Merchant`,
                REPLACE(Request, 'FOR ', '') AS Service,
                CASE 
                    WHEN Days < 1 OR Days = 1 THEN 'Normal'
                    WHEN Days BETWEEN 2 AND 4 THEN 'Medium'
                    WHEN Days BETWEEN 5 AND 8 THEN 'High'
                    WHEN Days >= 9 THEN 'Critical'
                    ELSE 'Unknown'
                END AS Priority,
                Service_Status AS `Status`,
                Service_Result AS `Result`,
                Terminal_SN AS `Terminal`,
                Sim_SN AS `Sim`,
                CASE 
                    WHEN Prov_ID = 5 THEN 'PROVINCE' 
                    WHEN Prov_ID = 4 THEN 'MANILA' 
                    ELSE Province 
                END AS Region,
                Days AS SLA,
               IF(STR_TO_DATE(Dispatch_Date_Time, '%Y-%m-%d') IS NOT NULL,
                    DATE_FORMAT(Dispatch_Date_Time, '%b %d, %Y'),
                    NULL) AS `Request Date`,
                IF(STR_TO_DATE(Dispatch_Date_Time, '%Y-%m-%d') IS NOT NULL, 
                    DATE_FORMAT(Dispatch_Date_Time, '%h:%i %p, %b %d, %Y'), 
                    Dispatch_Date_Time) AS `Dispatch Date`
            FROM 
                vw_service_info
            WHERE
                (
                    @Search IS NULL OR @Search = ''
                    OR Terminal_SN = @Search
                    OR Sim_SN = @Search
                    OR TID = @Search
                    OR Job_ID = @Search
                    OR Service_Result = @Search
                    OR Merchant_Name LIKE CONCAT('%', @Search, '%')
                    OR Dispatch_By LIKE CONCAT('%', @Search, '%')
                )
            ORDER BY Processed_Date_Time DESC
            LIMIT {limit};";

            return Select(stmt, new MySqlParameter("@Search", search));
        }

        public async Task<IEnumerable<dynamic>> FindServicesAsync(object search, int limit = 100)
        {
            string stmt = $@"
                SELECT 
                    Job_ID AS `Order No`,
                    Request_No AS `Request No`,
                    IFNULL(Merchant_Name, 'N/A') AS `Merchant`,
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
                    END AS `Status`,
                    CASE 
				        WHEN Service_Result = 'COMPLETED' THEN 'SUCCESS'
				        ELSE Service_Result
			        END AS `Result`,
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
                        'N/A') AS `Request Date`,
                    IF(STR_TO_DATE(Dispatch_Date_Time, '%Y-%m-%d') IS NOT NULL, 
                        DATE_FORMAT(Dispatch_Date_Time, '%h:%i %p, %b %d, %Y'), 
                        'N/A') AS `Dispatch Date`
                FROM 
                    vw_service_info
                WHERE
                    (
                        @Search IS NULL OR @Search = ''
                        OR Terminal_SN = @Search
                        OR Sim_SN = @Search
                        OR TID = @Search
                        OR Job_ID = @Search
                        OR Service_Result = @Search
                        OR Merchant_Name LIKE CONCAT('%', @Search, '%')
                        OR Dispatch_By LIKE CONCAT('%', @Search, '%')
                    )
                ORDER BY Processed_Date_Time DESC
                LIMIT {limit};";

            return await Db.QueryAsync<dynamic>(stmt, new { Search = search});
        }

        /*
        public async Task<DataTable> FindServicesAsync(object search, int limit)
        {
            string stmt = $@"
            SELECT 
                Job_ID AS `Order No`,
                Request_No AS `Request No`,
                IFNULL(Merchant_Name, 'N/A') AS `Merchant`,
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
                END AS `Status`,
                CASE 
				    WHEN Service_Result = 'COMPLETED' THEN 'SUCCESS'
				    ELSE Service_Result
			    END AS `Result`,
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
                    'N/A') AS `Request Date`,
                IF(STR_TO_DATE(Dispatch_Date_Time, '%Y-%m-%d') IS NOT NULL, 
                    DATE_FORMAT(Dispatch_Date_Time, '%h:%i %p, %b %d, %Y'), 
                    'N/A') AS `Dispatch Date`
            FROM 
                vw_service_info
            WHERE
                (
                    @Search IS NULL OR @Search = ''
                    OR Terminal_SN = @Search
                    OR Sim_SN = @Search
                    OR TID = @Search
                    OR Job_ID = @Search
                    OR Service_Result = @Search
                    OR Merchant_Name LIKE CONCAT('%', @Search, '%')
                    OR Dispatch_By LIKE CONCAT('%', @Search, '%')
                )
            ORDER BY Processed_Date_Time DESC
            LIMIT {limit};";

            return await SelectAsync(stmt, new MySqlParameter("@Search", search ?? DBNull.Value));
        }
        */

        public async Task<DataTable> FindHelpdeskRequestAsync(object search, object id, int limit)
        {
            string stmt = $@"
            SELECT 
                j.Description AS `Service`, 
                h.RequestID AS `Request No.`,
                i.MerchantName AS `Merchant`,
                p.Name AS `Helpdesk`, 
                s.JobTypeStatusDescription AS `Service Status`
            FROM tblhddetail h
            JOIN tblparticular p ON p.ParticularID = h.HelpdeskID
            JOIN tblhdmaster m ON m.AssistNo = h.AssistNo
            JOIN tblirdetail i ON i.IRIDNo = m.IRIDNo
            JOIN tblservicetype j ON j.JobType = m.JobType
            LEFT JOIN tblservicingdetail s ON s.ProblemNo = h.ProblemNo
            WHERE (@id IS NULL OR h.HelpdeskID = @id)
                AND h.Status = 'NEGATIVE'
                AND s.JobTypeStatusDescription <> 'COMPLETED'
                AND DATE(h.CreatedAt) = CURRENT_DATE()
                AND (@search IS NULL OR (
                    h.RequestID LIKE CONCAT('%', @search, '%') OR
                    i.MerchantName LIKE CONCAT('%', @search, '%') OR
                    j.Description LIKE CONCAT('%', @search, '%')
                ))
            LIMIT {limit};";

            return await SelectAsync(stmt,
                    new MySqlParameter("@search", search),
                    new MySqlParameter("@id", id));
        }

        public async Task<DataTable> FindServiceRequestAsync(object date)
        {
            string stmt = @"
            SELECT 
                Request_No AS `Request No`,
                Merchant,
                TID,
                MID
            FROM vw_installation_info
            WHERE		
                Status_ID = 1
                AND (@date IS NULL OR DATE(Created_Date) = @date);";

            return await SelectAsync(stmt, new MySqlParameter("@date", date));
        }

        public async Task<DataTable> FindServiceSummary(object id, object date)
        {
            string stmt = @"
            SELECT
                REPLACE(Request, 'FOR ', '') AS Description,
                FORMAT(SUM(CASE WHEN Status_ID IN (7, 11) AND Service_Result = 'COMPLETED' THEN 1 ELSE 0 END), 0) AS Completed,
                FORMAT(SUM(CASE WHEN Status_ID = 8 THEN 1 ELSE 0 END), 0) AS Dispatch,
                FORMAT(SUM(CASE WHEN Status_ID = 2 THEN 1 ELSE 0 END), 0) AS Pending,
                FORMAT(SUM(CASE WHEN Status_ID = 9 THEN 1 ELSE 0 END), 0) AS Negative,
                FORMAT(
                    SUM(
                        (CASE WHEN Status_ID IN (7, 11) AND Service_Result = 'COMPLETED' THEN 1 ELSE 0 END) +
                        (CASE WHEN Status_ID = 8 THEN 1 ELSE 0 END) +
                        (CASE WHEN Status_ID = 2 THEN 1 ELSE 0 END) +
                        (CASE WHEN Status_ID = 9 THEN 1 ELSE 0 END)
                    ), 0
                ) AS Total
            FROM vw_service_info
            WHERE (@id IS NULL OR Dispatcher_ID = @id)
              AND DATE(Created_Date) = DATE(@date)
              AND YEAR(Created_Date) = YEAR(@date)
            GROUP BY Type_ID;";

            return await SelectAsyncNoCache(stmt, 
                new MySqlParameter("@id", id), 
                new MySqlParameter("@date", date));
        }

        public async Task<DataTable> FindServiceAreaSummary(object id, object date)
        {
            string stmt = @"
            SELECT
	            FORMAT(SUM(CASE WHEN Prov_ID = 4 THEN 1 ELSE 0 END), 0) AS Manila,
	            FORMAT(SUM(CASE WHEN Prov_ID = 5 THEN 1 ELSE 0 END), 0) AS Province,
	            FORMAT(COUNT(*), 0) AS Total
            FROM
                vw_service_info
            WHERE (@id IS NULL OR Dispatcher_ID = @id)
	            AND MONTH(Created_Date) = MONTH(@date)
                AND YEAR(Created_Date) = YEAR(@date)";

            return await SelectAsyncNoCache(stmt,
                new MySqlParameter("@id", id),
                new MySqlParameter("@date", date));
        }

        public async Task<DataTable> FindInstalledTerminalCount(object id)
        {
            string stmt = @"     
            SELECT
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
            WHERE (@id IS NULL OR x.RegionID = @id);";

            return await SelectAsyncNoCache(stmt, new MySqlParameter("@id", id));
        }

        public async Task<DataTable> FindMonthlyServiceCountAsync(object id)
        {
            string stmt = @"
            SELECT
                DATE_FORMAT(Created_Date, '%M') AS Month,
                FORMAT(COUNT(*), 0) AS TotalServices
            FROM vw_service_info
            WHERE (@id IS NULL OR Dispatcher_ID = @id) 
              AND Request_Status = 'SUCCESS'
              AND YEAR(Created_Date) = YEAR(CURDATE())
            GROUP BY YEAR(Created_Date), MONTH(Created_Date)
            ORDER BY YEAR(Created_Date), MONTH(Created_Date);";

            return await SelectAsync(stmt, new MySqlParameter("@id", id));
        }

        public async Task<DataTable> FindMonthlySLA(object id, DateTime targetDate)
        {
            var monthParam = targetDate.Month;
            var yearParam = targetDate.Year;

            string stmt = @"
            SELECT
                SUM(CASE WHEN TAT_Status = 'Beyond' THEN 1 ELSE 0 END) AS `Beyond`,
                SUM(CASE WHEN TAT_Status = 'Within' THEN 1 ELSE 0 END) AS `Within`
            FROM vw_service_info
            WHERE (@id IS NULL OR Dispatcher_ID = @id)
                AND MONTH(Created_Date) = @month
                AND YEAR(Created_Date) = @year
                AND Request_Status = 'SUCCESS';";

            return await SelectAsync(stmt,
                new MySqlParameter("@id", id),
                new MySqlParameter("@month", monthParam),
                new MySqlParameter("@year", yearParam));
        }

        public async Task<DataTable> FindUnclosedTicketsAsync(object id, DateTime date)
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
            WHERE (@id IS NULL OR Dispatcher_ID = @id)
              AND MONTH(Created_Date) = MONTH(@date)
              AND YEAR(Created_Date) = YEAR(@date)
              AND Request_Status IN ('SUCCESS','NEGATIVE')
              AND Ticket_ID = 0;";

            return await SelectAsyncNoCache(stmt,
                new MySqlParameter("@id", id),
                new MySqlParameter("@date", date));
        }

        public async Task<DataTable> FindDispatcherServices(object id, DateTime targetDate)
        {
            var monthParam = targetDate.Month;
            var yearParam = targetDate.Year;

            string stmt = @"
            SELECT
	            REPLACE(Request, 'FOR ', '') AS Service,
	            Dispatch_By AS Dispatcher,
	            SUM(CASE WHEN Status_ID = 8 OR Dispatcher_ID = NULL THEN 1 ELSE 0 END) AS Pending,
	            SUM(CASE WHEN Status_ID = 7 AND Service_Result = 'COMPLETED' THEN 1 ELSE 0 END) AS Completed
            FROM 
                vw_service_info
            WHERE (@id IS NULL OR Dispatcher_ID = @id)
              AND MONTH(Created_Date) = MONTH(@month)
              AND YEAR(Created_Date)  = YEAR(@year)                
            GROUP BY Dispatcher_ID, Type_ID, Request
            HAVING Pending <> 0 AND Completed <> 0
            ORDER BY Status_ID, Dispatch_By;";

            return await SelectAsync(stmt,
                 new MySqlParameter("@id", id),
                 new MySqlParameter("@month", monthParam),
                 new MySqlParameter("@year", yearParam));
        }

        public DataTable FindStores(object search, int limit = 100)
        {
            string stmt = $@"
            SELECT 
                Merchant_ID AS `Store ID`,
                Merchant_Name AS `Store Name`,
                Address,
                Region AS `City`,
                Province,
                Contact_Person AS `Contact`,
                Contact_No AS `Contact No.`,
                Tel_No AS `Tel No.`,
                Mobile_No AS `Mobile No.`,
                Fax_No AS `Fax No.`,
                Email
            FROM vw_merchant_info
            WHERE 
                (@Search IS NULL OR @Search = '')
                OR Merchant_Name LIKE CONCAT('%', @Search, '%')
                OR Contact_Person LIKE CONCAT('%', @Search, '%')
                OR Province LIKE CONCAT('%', @Search, '%')
                OR Region LIKE CONCAT('%', @Search, '%')
            LIMIT {limit};";

            return Select(stmt, new MySqlParameter("@Search", search));
        }

        public async Task<DataTable> FindMerchantAsync(object search, object mode, int limit = 100)
        {
            string stmt = $@"
            SELECT
                i.IRIDNo AS `ID`,
                m.Merchant_ID AS `Code`,
                CASE i.IRStatus
                    WHEN 1 THEN 'AVAILABLE'
                    WHEN 2 THEN 'ASSIGNED'
                    WHEN 7 THEN 'ACTIVE'
                    WHEN 8 THEN 'DISPATCH'
                    WHEN 11 THEN 'INACTIVE'
                    ELSE 'UNKNOWN'
                END AS `Status`,
                m.Merchant_Name AS `Merchant`,
                IFNULL(NULLIF(i.TID, '-'), 'N/A') AS TID,
                IFNULL(NULLIF(i.MID, '-'), 'N/A') AS MID,
                IFNULL(NULLIF(i.TerminalSN, 0), 'N/A') AS Terminal,
                IFNULL(NULLIF(i.SIMSN, 0), 'N/A') AS Sim,
                m.Region AS `City`,
                IF(UPPER(NULLIF(TRIM(m.Contact_Person), '')) = 'X' OR m.Contact_Person IS NULL, 'N/A', m.Contact_Person) AS `Contact Person`,
                IF(UPPER(NULLIF(TRIM(m.Contact_No), '')) = 'X' OR m.Contact_No IS NULL, 'N/A', m.Contact_No) AS `Contact No.`,
                IF(UPPER(NULLIF(TRIM(m.Email), '')) = 'X' OR m.Email IS NULL, 'N/A', m.Email) AS Email
            FROM vw_merchant_info m
            LEFT JOIN tblirdetail i ON i.MerchantID = m.Merchant_ID
            LEFT JOIN tblterminaldetail t ON t.TerminalID = i.TerminalID
            LEFT JOIN tblparticular p ON p.ParticularID = i.MerchantID
            LEFT JOIN tblregion r ON r.RegionID = p.RegionType
            WHERE i.IRActive = 1
                AND (
                    @Search IS NULL OR @Search = '' OR
                    i.TID = @Search OR
                    m.Merchant_Name LIKE CONCAT('%', @Search, '%') OR
                    m.Contact_Person LIKE CONCAT('%', @Search, '%') OR
                    m.Province LIKE CONCAT('%', @Search, '%') OR
                    m.Region LIKE CONCAT('%', @Search, '%')
                    )
                AND (
                    @Mode IS NULL OR
                    (UPPER(@Mode) = 'MANILA' AND r.RegionID = 4) OR
                    (UPPER(@Mode) = 'PROVINCE' AND r.RegionID = 5) OR
                    (UPPER(@Mode) = 'DUPLICATE' AND t.TerminalID IN (
                        SELECT TerminalID
                        FROM tblirdetail
                        GROUP BY TerminalID
                        HAVING COUNT(*) >= 2
                    ))
                    )
            LIMIT {limit};";

            return await SelectAsync(stmt,
                new MySqlParameter("@Search", search),
                new MySqlParameter("@Mode", mode));
        }

        public async Task<DataTable> FindTerminals(object search, int limit = 10)
        {
            string stmt = $@"
            SELECT 
                Terminal_ID   AS `ID`,
                Model_ID      AS `Model ID`,
                Model         AS `Model`,
                Terminal_SN   AS `Serial`,
                Status        AS `Status`,
                Location      AS `Location`,
                Type          AS `Type`,
                Code          AS `Code`,
                Brand         AS `Brand`,
                Part_No       AS `Part No`,
                App_Version   AS `App Version`,
                App_Crc       AS `App Crc`,
                Asset         AS `Asset`,
                Delivery_Date AS `Delivery Date`
            FROM vw_terminal_info
            WHERE 
                (@Search IS NULL OR @Search = '' 
                    OR Terminal_SN = @Search
                    OR Brand = @Search
                    OR Model = @Search )
            LIMIT {limit};";

            return await SelectAsync(stmt, new MySqlParameter("@Search", search));
        }

        public DataTable FindSimCards(object search, int limit = 10)
        {
            string stmt = $@"
            SELECT 
                SIM_ID         AS `ID`,
                Carrier_ID     AS `Carrier ID`,
                Carrier        AS `Carrier`,
                SIM_SN         AS `Serial`,
                Status         AS `Status`,
                Location       AS `Location`,
                Delivery_Date  AS `Delivery Date`,
                Receive_Date   AS `Receive Date`,
                Release_Date   AS `Release Date`
            FROM vw_sim_info
            WHERE 
                (@Search IS NULL OR @Search = '')
                OR SIM_SN LIKE CONCAT('%', @Search, '%')
                OR Carrier LIKE CONCAT('%', @Search, '%')
                OR Status LIKE CONCAT('%', @Search, '%')
                OR Location LIKE CONCAT('%', @Search, '%')
            ORDER BY SIM_SN
            LIMIT {limit};";

            return Select(stmt, new MySqlParameter("@Search", search));
        }

        public async Task<DataTable> FindInstallationRequest(object id)
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
            WHERE (@id IS NULL OR IR_ID = @id) 
            AND   Status_ID = 7
            AND   isActive = 1";

            return await SelectAsyncNoCache(stmt, new MySqlParameter("@id", id));
        }

        // ---------- PROCEDURES ------------
        public ProcedureResult CallReplaceDevice(int id, string terminalSN, string simSN)
        {
            var dt = ExecuteProcedure("spReplaceDevice",
                new MySqlParameter("@in_id", id),
                new MySqlParameter("@in_NewTerminalSn", terminalSN),
                new MySqlParameter("@in_NewSimSn", simSN));

            if (dt.Rows.Count == 0)
                return new ProcedureResult { Result = 0, Message = "No response from procedure." };

            var row = dt.Rows[0];
            return new ProcedureResult
            {
                Result = Convert.ToInt32(row["Result"]),
                Message = row["Message"].ToString()
            };
        }


        // ---------- Update -----------
        public ExeResult PullOutMerchant(object Id)
        {
            try
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
                    WHERE IRIDNo = @Id";

                Execute(stmt, "tblirdetail", new MySqlParameter("@Id", Id));

                return ExeResult.Ok();
            }
            catch (Exception ex)
            {
                return ExeResult.Fail(ex.Message);
            }
        }


        public ExeResult JobOrderUpdate(JobOrderDetails jobOrder)
        {
            var result = new ExeResult();

            try
            {
                Transact((conn, tx) =>
                {
                    // Fetch service, job type, terminal, and SIM info
                    var dt = SelectNoCache(@"
                        SELECT 
                            s.IRIDNo,
                            s.JobType AS CurrentJobType,
                            s.TerminalID,
                            s.TerminalSN,
                            s.SIMID,
                            s.SIMSerialNo,
                            s.ClientID,
                            s.ClientName,
                            f.ActionMade,
                            st.JobType AS NewJobType,
                            st.JobTypeDescription,
                            st.Description AS JobDesc,
                            t.TerminalStatus,
                            t.TerminalSN AS ReplacementTerminalSN,
                            sim.SIMStatus,
                            sim.SIMSN AS ReplacementSIMSN
                        FROM tblservicingdetail s
                        LEFT JOIN tblfsrdetail f ON f.ServiceNo = s.ServiceNo
                        LEFT JOIN tblservicetype st ON st.JobType=@JobType
                        LEFT JOIN tblterminaldetail t ON t.TerminalID=@RepTerminalID
                        LEFT JOIN tblsimdetail sim ON sim.SIMID=@RepSIMID
                        WHERE s.ServiceNo=@ServiceNo
                        LIMIT 1",
                        new MySqlParameter("@ServiceNo", jobOrder.ServiceNo),
                        new MySqlParameter("@JobType", jobOrder.JobType),
                        new MySqlParameter("@RepTerminalID", jobOrder.RepTerminalID ?? 0),
                        new MySqlParameter("@RepSIMID", jobOrder.RepSIMID ?? 0)
                    );

                    if (dt.Rows.Count == 0)
                    {
                        result.Success = false;
                        result.Message = "Service or Job type not found.";
                        return; // exit delegate
                    }

                    var row = dt.Rows[0];
                    int newJobType = Convert.ToInt32(row["NewJobType"]);
                    string jobTypeDesc = row["JobTypeDescription"].ToString();
                    string jobDesc = row["JobDesc"].ToString();

                    // Validate replacements for Replacement / Reprogramming
                    if ((newJobType == 3 || newJobType == 7) &&
                        (jobOrder.RepTerminalID.HasValue && jobOrder.RepSIMID.HasValue))
                    {
                        if (Convert.ToInt32(row["TerminalStatus"]) != 1)
                        {
                            result.Success = false;
                            result.Message = "Terminal is not available";
                            return;
                        }

                        if (Convert.ToInt32(row["SIMStatus"]) != 1)
                        {
                            result.Success = false;
                            result.Message = "SIM is not available";
                            return;
                        }
                    }

                    // Execute updates
                    if (newJobType == 3 || newJobType == 7) // Replacement / Reprogramming
                    {
                        Execute(@"
                            UPDATE tblservicingdetail s
                            LEFT JOIN tblfsrdetail f ON f.ServiceNo = s.ServiceNo
                            SET
                                s.JobType=@JobType,
                                s.JobTypeDescription=@JobTypeDesc,
                                s.JobTypeSubDescription=@JobDesc,
                                f.JobType=@JobType,
                                f.JobTypeDescription=@JobTypeDesc,
                                s.ReplaceTerminalID=@RepTerminalID,
                                s.ReplaceTerminalSN=@ReplacementTerminalSN,
                                s.ReplaceSIMID=@RepSIMID,
                                s.ReplaceSIMSN=@ReplacementSIMSN,
                                f.TerminalID=@RepTerminalID,
                                f.SIMID=@RepSIMID
                            WHERE s.ServiceNo=@ServiceNo",
                            "tblservicingdetail",
                            new MySqlParameter("@JobType", newJobType),
                            new MySqlParameter("@JobTypeDesc", jobTypeDesc),
                            new MySqlParameter("@JobDesc", jobDesc),
                            new MySqlParameter("@RepTerminalID", jobOrder.RepTerminalID.Value),
                            new MySqlParameter("@ReplacementTerminalSN", row["ReplacementTerminalSN"]),
                            new MySqlParameter("@RepSIMID", jobOrder.RepSIMID.Value),
                            new MySqlParameter("@ReplacementSIMSN", row["ReplacementSIMSN"]),
                            new MySqlParameter("@ServiceNo", jobOrder.ServiceNo)
                        );
                    }
                    else if (newJobType == 4 || newJobType == 6) // Pull-Out or Servicing
                    {
                        Execute(@"
                            UPDATE tblservicingdetail s
                            LEFT JOIN tblfsrdetail f ON f.ServiceNo = s.ServiceNo
                            SET
                                s.JobType=@JobType,
                                s.JobTypeDescription=@JobTypeDesc,
                                s.JobTypeSubDescription=@JobDesc,
                                f.JobType=@JobType,
                                f.JobTypeDescription=@JobTypeDesc,
                                s.ReplaceTerminalID=0,
                                s.ReplaceTerminalSN=0,
                                s.ReplaceSIMID=0,
                                s.ReplaceSIMSN=0
                            WHERE s.ServiceNo=@ServiceNo",
                                "tblservicingdetail",
                            new MySqlParameter("@JobType", newJobType),
                            new MySqlParameter("@JobTypeDesc", jobTypeDesc),
                            new MySqlParameter("@JobDesc", jobDesc),
                            new MySqlParameter("@ServiceNo", jobOrder.ServiceNo)
                        );
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Unsupported JobType";
                        return;
                    }

                    // Success
                    result.Success = true;
                    result.Message = "Service update completed.";

                }, "tblservicingdetail", "tblfsrdetail");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public ExeResult JobOrderUpdateDetails(JobOrderDetails jobOrder)
        {
            var result = new ExeResult();

            try
            {
                Transact((conn, tx) =>
                {
                    // Fetch all job/service details
                    var dt = SelectNoCache(@"
                        SELECT 
                            s.IRIDNo,
                            s.JobType AS CurrentJobType,
                            s.TerminalID,
                            s.TerminalSN,
                            s.SIMID,
                            s.SIMSerialNo,
                            s.ClientID,
                            s.ClientName,
                            f.ActionMade,
                            st.JobType AS NewJobType,
                            st.JobTypeDescription,
                            st.Description AS JobDesc,
                            t.TerminalStatus,
                            t.TerminalSN AS ReplacementTerminalSN,
                            sim.SIMStatus,
                            sim.SIMSN AS ReplacementSIMSN,
                            i.TID,
                            i.LocationID AS MerchantLocationID,
                            i.Location AS MerchantLocation
                        FROM tblservicingdetail s
                        LEFT JOIN tblfsrdetail f ON f.ServiceNo = s.ServiceNo
                        LEFT JOIN tblservicetype st ON st.JobType=@JobType
                        LEFT JOIN tblterminaldetail t ON t.TerminalID=@RepTerminalID
                        LEFT JOIN tblsimdetail sim ON sim.SIMID=@RepSIMID
                        LEFT JOIN tblirdetail i ON i.IRIDNo = s.IRIDNo
                        WHERE s.ServiceNo=@ServiceNo
                        LIMIT 1",
                        new MySqlParameter("@ServiceNo", jobOrder.ServiceNo),
                        new MySqlParameter("@JobType", jobOrder.JobType),
                        new MySqlParameter("@RepTerminalID", jobOrder.RepTerminalID ?? 0),
                        new MySqlParameter("@RepSIMID", jobOrder.RepSIMID ?? 0)
                    );

                    if (dt.Rows.Count == 0)
                        throw new Exception("Service or Job type not found.");

                    var row = dt.Rows[0];
                    int newJobType = Convert.ToInt32(row["NewJobType"]);
                    string jobTypeDesc = row["JobTypeDescription"].ToString();
                    string jobDesc = row["JobDesc"].ToString();
                    string actionMade = row["ActionMade"].ToString().ToUpper();

                    var jobHandlers = new Dictionary<int, Action>
                    {
                        { 1, () => HandleInstallation(conn, tx, row, jobOrder, actionMade, jobTypeDesc, jobDesc) },
                        { 3, () => HandleReplacement(conn, tx, row, jobOrder, actionMade, jobTypeDesc, jobDesc) },
                        { 7, () => HandleReplacement(conn, tx, row, jobOrder, actionMade, jobTypeDesc, jobDesc) },
                        { 4, () => HandlePullout(conn, tx, row, jobOrder, actionMade, jobTypeDesc, jobDesc) },
                        { 6, () => HandlePullout(conn, tx, row, jobOrder, actionMade, jobTypeDesc, jobDesc) }
                    };

                    if (!jobHandlers.ContainsKey(newJobType))
                        throw new Exception("Unsupported JobType.");

                    jobHandlers[newJobType]();

                    result.Success = true;
                    result.Message = "Service update completed.";

                }, "tblservicingdetail", "tblfsrdetail");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        private void HandleInstallation(MySqlConnection conn, MySqlTransaction tx, DataRow row, JobOrderDetails jobOrder, string actionMade, string jobTypeDesc, string jobDesc)
        {
            Execute(@"
                UPDATE tblservicingdetail s
                LEFT JOIN tblfsrdetail f ON f.ServiceNo = s.ServiceNo
                SET
                    s.JobType=@JobType,
                    s.JobTypeDescription=@JobTypeDesc,
                    s.JobTypeSubDescription=@JobDesc,
                    f.JobType=@JobType,
                    f.JobTypeDescription=@JobTypeDesc,
                    f.TerminalID=@TerminalID,
                    f.SIMID=@SIMID
                WHERE s.ServiceNo=@ServiceNo",
                    "tblservicingdetail",
                new MySqlParameter("@JobType", 1),
                new MySqlParameter("@JobTypeDesc", jobTypeDesc),
                new MySqlParameter("@JobDesc", jobDesc),
                new MySqlParameter("@TerminalID", jobOrder.TerminalID),
                new MySqlParameter("@SIMID", jobOrder.SimID),
                new MySqlParameter("@ServiceNo", jobOrder.ServiceNo)
            );

            // --- Compare old vs new ActionMade ---
            string oldAction = row["ActionMade"].ToString().ToUpper();
            string newAction = jobOrder.ActionMade?.ToUpper() ?? oldAction;

            if (!oldAction.Equals(newAction)) // only execute device update if ActionMade changed
            {
                if (newAction == "SUCCESS")
                {
                    UpdateDevice(conn, tx, "TERMINAL", jobOrder.TerminalID, "INSTALLED", row);
                    UpdateDevice(conn, tx, "SIM", jobOrder.SimID, "INSTALLED", row);
                }
                else if (newAction == "NEGATIVE")
                {
                    UpdateDevice(conn, tx, "TERMINAL", jobOrder.TerminalID, "AVAILABLE");
                    UpdateDevice(conn, tx, "SIM", jobOrder.SimID, "AVAILABLE");
                }
            }
        }

        private void HandleReplacement(MySqlConnection conn, MySqlTransaction tx, DataRow row, JobOrderDetails jobOrder, string actionMade, string jobTypeDesc, string jobDesc)
        {
            Execute(@"
            UPDATE tblservicingdetail s
            LEFT JOIN tblfsrdetail f ON f.ServiceNo = s.ServiceNo
            SET
                s.JobType=@JobType,
                s.JobTypeDescription=@JobTypeDesc,
                s.JobTypeSubDescription=@JobDesc,
                f.JobType=@JobType,
                f.JobTypeDescription=@JobTypeDesc,
                s.ReplaceTerminalID=@RepTerminalID,
                s.ReplaceTerminalSN=@ReplacementTerminalSN,
                s.ReplaceSIMID=@RepSIMID,
                s.ReplaceSIMSN=@ReplacementSIMSN,
                f.TerminalID=@RepTerminalID,
                f.SIMID=@RepSIMID
            WHERE s.ServiceNo=@ServiceNo",
                    "tblservicingdetail",
                new MySqlParameter("@JobType", Convert.ToInt32(row["NewJobType"])),
                new MySqlParameter("@JobTypeDesc", jobTypeDesc),
                new MySqlParameter("@JobDesc", jobDesc),
                new MySqlParameter("@RepTerminalID", jobOrder.RepTerminalID.Value),
                new MySqlParameter("@ReplacementTerminalSN", row["ReplacementTerminalSN"].ToString()),
                new MySqlParameter("@RepSIMID", jobOrder.RepSIMID.Value),
                new MySqlParameter("@ReplacementSIMSN", row["ReplacementSIMSN"].ToString()),
                new MySqlParameter("@ServiceNo", jobOrder.ServiceNo)
            );

            if (actionMade == "SUCCESS")
            {
                // Old devices back to stock
                UpdateDevice(conn, tx, "TERMINAL", Convert.ToInt32(row["TerminalID"]), "AVAILABLE");
                UpdateDevice(conn, tx, "SIM", Convert.ToInt32(row["SIMID"]), "AVAILABLE");
                // New devices installed
                UpdateDevice(conn, tx, "TERMINAL", jobOrder.RepTerminalID.Value, "INSTALLED", row);
                UpdateDevice(conn, tx, "SIM", jobOrder.RepSIMID.Value, "INSTALLED", row);
            }
            else if (actionMade == "NEGATIVE")
            {
                UpdateDevice(conn, tx, "TERMINAL", jobOrder.RepTerminalID.Value, "AVAILABLE");
                UpdateDevice(conn, tx, "SIM", jobOrder.RepSIMID.Value, "AVAILABLE");
            }
        }

        private void HandlePullout(MySqlConnection conn, MySqlTransaction tx, DataRow row, JobOrderDetails jobOrder, string actionMade, string jobTypeDesc, string jobDesc)
        {
            Execute(@"
            UPDATE tblservicingdetail s
            LEFT JOIN tblfsrdetail f ON f.ServiceNo = s.ServiceNo
            SET
                s.JobType=@JobType,
                s.JobTypeDescription=@JobTypeDesc,
                s.JobTypeSubDescription=@JobDesc,
                f.JobType=@JobType,
                f.JobTypeDescription=@JobTypeDesc
            WHERE s.ServiceNo=@ServiceNo",
                    "tblservicingdetail",
                new MySqlParameter("@JobType", Convert.ToInt32(row["NewJobType"])),
                new MySqlParameter("@JobTypeDesc", jobTypeDesc),
                new MySqlParameter("@JobDesc", jobDesc),
                new MySqlParameter("@ServiceNo", jobOrder.ServiceNo)
            );

            if (actionMade == "SUCCESS")
            {
                UpdateDevice(conn, tx, "TERMINAL", Convert.ToInt32(row["TerminalID"]), "AVAILABLE");
                UpdateDevice(conn, tx, "SIM", Convert.ToInt32(row["SIMID"]), "AVAILABLE");
            }
            else if (actionMade == "NEGATIVE")
            {
                UpdateDevice(conn, tx, "TERMINAL", Convert.ToInt32(row["TerminalID"]), "RESTORE_MERCHANT", row);
                UpdateDevice(conn, tx, "SIM", Convert.ToInt32(row["SIMID"]), "RESTORE_MERCHANT", row);
            }
        }

        private void UpdateDevice(MySqlConnection conn, MySqlTransaction tx, string deviceType, int id, string state, DataRow merchant = null)
        {
            string table = deviceType == "TERMINAL" ? "tblterminaldetail" : "tblsimdetail";
            string statusField = deviceType == "TERMINAL" ? "TerminalStatus" : "SIMStatus";
            string statusDescField = deviceType == "TERMINAL" ? "TerminalStatusDescription" : "SIMStatusDescription";
            string idField = deviceType == "TERMINAL" ? "TerminalID" : "SIMID";

            int status;
            string statusDesc;
            int locId;
            string loc;
            object clientId = null, clientName = null;

            switch (state)
            {
                case "INSTALLED":
                    status = 7; statusDesc = "INSTALLED";
                    locId = 18; loc = "PRODUCTION";
                    clientId = merchant?["ClientID"];
                    clientName = merchant?["ClientName"];
                    break;
                case "AVAILABLE":
                    status = 1; statusDesc = "AVAILABLE";
                    locId = 1; loc = "STOCK ROOM";
                    break;
                case "RESTORE_MERCHANT":
                    status = 7; statusDesc = "INSTALLED";
                    locId = Convert.ToInt32(merchant!["MerchantLocationID"]);
                    loc = merchant["MerchantLocation"].ToString();
                    clientId = merchant["ClientID"];
                    clientName = merchant["ClientName"];
                    break;
                default:
                    throw new ArgumentException("Invalid device state");
            }

            Execute($@"
            UPDATE {table}
            SET 
                {statusField} = @Status,
                {statusDescField} = @StatusDesc,
                LocationID = @LocID,
                Location = @Loc,
                ClientID = @ClientID,
                ClientName = @ClientName
            WHERE {idField} = @ID",
                table,
                new MySqlParameter("@Status", status),
                new MySqlParameter("@StatusDesc", statusDesc),
                new MySqlParameter("@LocID", locId),
                new MySqlParameter("@Loc", loc),
                new MySqlParameter("@ClientID", clientId ?? DBNull.Value),
                new MySqlParameter("@ClientName", clientName ?? DBNull.Value),
                new MySqlParameter("@ID", id)
            );
        }


        // --------- Device Validation ------------------
        private ExeResult ValidateTerminal(int terminalId, MySqlConnection conn = null, MySqlTransaction tx = null)
        {
            bool ownConn = conn == null;
            if (ownConn) {
                conn = GetConnection();
                conn.Open();
            }

            try
            {
                int status = Convert.ToInt32(Scalar(
                    "SELECT TerminalStatus FROM tblterminaldetail WHERE TerminalID=@id",
                    conn, tx,
                    new MySqlParameter("@id", terminalId)
                ));

                return status == 1
                    ? ExeResult.Ok()
                    : ExeResult.Fail("Terminal is not available");
            }
            finally
            {
                if (ownConn)
                    conn.Dispose();
            }
        }

        private ExeResult ValidateSIM(int simId, MySqlConnection conn = null, MySqlTransaction tx = null)
        {
            bool ownConn = conn == null;
            if (ownConn) {
                conn = GetConnection();
                conn.Open();
            }

            try
            {
                int status = Convert.ToInt32(Scalar(
                    "SELECT SIMStatus FROM tblsimdetail WHERE SIMID=@id",
                    conn, tx,
                    new MySqlParameter("@id", simId)
                ));

                return status == 1
                    ? ExeResult.Ok()
                    : ExeResult.Fail("SIM is not available");
            }
            finally
            {
                if (ownConn)
                    conn.Dispose();
            }
        }

        public List<JobTypeInfo> GetJobTypes(int? jobTypeId = null, MySqlConnection conn = null, MySqlTransaction tx = null)
        {
            bool ownConn = conn == null;
            if (ownConn)
            {
                conn = GetConnection();
                conn.Open();
            }

            try
            {
                var sql = jobTypeId.HasValue
                    ? "SELECT JobType, JobTypeDescription FROM tblservicetype WHERE JobType=@JobType LIMIT 1"
                    : "SELECT JobType, JobTypeDescription FROM tblservicetype ORDER BY JobType";

                using var cmd = new MySqlCommand(sql, conn, tx);
                if (jobTypeId.HasValue)
                    cmd.Parameters.AddWithValue("@JobType", jobTypeId.Value);

                using var reader = cmd.ExecuteReader();
                var list = new List<JobTypeInfo>();

                while (reader.Read())
                {
                    list.Add(new JobTypeInfo
                    {
                        Id = Convert.ToInt32(reader["JobType"]),
                        Description = reader["JobTypeDescription"].ToString()!
                    });
                }

                return list;
            }
            finally
            {
                if (ownConn)
                    conn.Dispose();
            }
        }

        // ---------- CRUD Samples ----------
        public int AddUser(string username)
        {
            return Execute("INSERT INTO users (username) VALUES (@u)", "users",
                new MySqlParameter("@u", username));
        }

        public async Task<int> AddUserAsync(string username)
        {
            return await ExecuteAsync("INSERT INTO users (username) VALUES (@u)", "users",
                new MySqlParameter("@u", username));
        }

        public void UpdateService(int id, string username)
        {
            Execute("UPDATE users SET username=@u WHERE id=@id", "users",
                new MySqlParameter("@u", username),
                new MySqlParameter("@id", id));
        }

        public async Task<int> UpdateServiceAsync(int id, string username)
        {
            return await ExecuteAsync("UPDATE users SET username=@u WHERE id=@id", "users",
                new MySqlParameter("@u", username),
                new MySqlParameter("@id", id));
        }

        public void DeleteService(int id)
        {
            Execute("DELETE FROM users WHERE id=@id", "users",
                new MySqlParameter("@id", id));
        }

        public async Task<int> DeleteServiceAsync(int id)
        {
            return await ExecuteAsync("DELETE FROM users WHERE id=@id", "users",
                new MySqlParameter("@id", id));
        }

        public void CreateUserWithLog(string username)
        {
            Transact((conn, tx) =>
            {
                using (var cmd = new MySqlCommand("INSERT INTO users (username) VALUES (@u)", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new MySqlCommand("INSERT INTO logs (message) VALUES (@m)", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@m", $"User {username} created");
                    cmd.ExecuteNonQuery();
                }
            }, "users", "logs");
        }

        public async Task CreateUserWithLogAsync(string username)
        {
            await TransactAsync(async (conn, tx) =>
            {
                using (var cmd = new MySqlCommand("INSERT INTO users (username) VALUES (@u)", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    await cmd.ExecuteNonQueryAsync();
                }

                using (var cmd = new MySqlCommand("INSERT INTO logs (message) VALUES (@m)", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@m", $"User {username} created");
                    await cmd.ExecuteNonQueryAsync();
                }
            }, "users", "logs");
        }
    
    }
}
