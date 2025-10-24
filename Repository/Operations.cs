using MIS_Admin.Core;
using MIS_Admin.Model;
using MySql.Data.MySqlClient;
using System.Data;

namespace MIS_Admin.Repository
{
    internal class Operations : Base
    {
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

        public async Task<DataTable> FindServicesAsync(object search, int limit)
        {
            string stmt = $@"
            SELECT 
                Job_ID AS `Order No`,
                Request_No AS `Request No`,
                IFNULL(Merchant_Name, 'N/A') AS `Merchant`,
                IFNULL(REPLACE(Request, 'FOR ', ''), 'N/A') AS Service,
                CASE 
                    WHEN Days < 1 OR Days = 1 THEN 'Normal'
                    WHEN Days BETWEEN 2 AND 4 THEN 'Medium'
                    WHEN Days BETWEEN 5 AND 8 THEN 'High'
                    WHEN Days >= 9 THEN 'Critical'
                    ELSE 'Unknown'
                END AS Priority,
                IFNULL(Service_Status, 'N/A') AS `Status`,
                IFNULL(Service_Result, 'N/A') AS `Result`,
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

        public async Task<DataTable> FindAreaSummary(object id, object date)
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
                   Request_Status AS `Status`,
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

        public async Task<DataTable> FindSLACount(object id)
        {
            string stmt = @"
            SELECT
                SUM(CASE WHEN TAT_Status = 'Beyond' THEN 1 ELSE 0 END) AS `Beyond Count`,
                SUM(CASE WHEN TAT_Status = 'Within' THEN 1 ELSE 0 END) AS `Within Count`
            FROM vw_service_info
            WHERE (@id IS NULL OR Dispatcher_ID = @id)
              AND MONTH(Created_Date) = MONTH(CURDATE())
              AND YEAR(Created_Date) = YEAR(CURDATE())
              AND Request_Status = 'SUCCESS';";

            return await SelectAsync(stmt, new MySqlParameter("@id", id));
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

        public async Task<DataTable> FindMerchantAsync(object search, int limit = 100)
        {
            string stmt = $@"
            SELECT
                i.IRIDNo as `ID`,
                m.Merchant_ID AS `Code`,
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
            WHERE i.IRActive = 1 
              AND i.IRStatus <> 11
              AND (
                    @Search IS NULL OR @Search = '' OR
                    i.TID = @Search OR
                    m.Merchant_Name LIKE CONCAT('%', @Search, '%') OR
                    m.Contact_Person LIKE CONCAT('%', @Search, '%') OR
                    m.Province LIKE CONCAT('%', @Search, '%') OR
                    m.Region LIKE CONCAT('%', @Search, '%')
                  )
            LIMIT {limit};";

            return await SelectAsync(stmt, new MySqlParameter("@Search", search));
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

        public void UpdateUser(int id, string username)
        {
            Execute("UPDATE users SET username=@u WHERE id=@id", "users",
                new MySqlParameter("@u", username),
                new MySqlParameter("@id", id));
        }

        public async Task<int> UpdateUserAsync(int id, string username)
        {
            return await ExecuteAsync("UPDATE users SET username=@u WHERE id=@id", "users",
                new MySqlParameter("@u", username),
                new MySqlParameter("@id", id));
        }

        public void DeleteUser(int id)
        {
            Execute("DELETE FROM users WHERE id=@id", "users",
                new MySqlParameter("@id", id));
        }

        public async Task<int> DeleteUserAsync(int id)
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
