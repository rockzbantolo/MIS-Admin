using MIS_Admin.Models;
using MIS_Admin.Repository;
using MIS_Admin.UI.Dto;
using Next.Extention;
using System.Data;

namespace MIS_Admin.Services
{
    public sealed class OpsService
    {
        private readonly OpsRepo _Ops;

        public OpsService() => _Ops = new OpsRepo();

        public async Task<DataTable> GetServicesAsync(string search = null, int? userId = null)
        {
            var results = await _Ops.FindServicesAsync(search, userId);

            return results.ToDataTable("Services");
        }

        public async Task<DataTable> GetHelpdeskRequestAsync(string search = null, int? id = null)
        {
            var data = await _Ops.FindHelpdeskRequestAsync(search, id);

            return data.ToDataTable("HelpdeskRequests");
        }

        public async Task<DataTable> GetRecentServicesAsync()
        {
            var data = await _Ops.FindServicesAsync(limit: 10);

            return data
                .ToDataTable("RecentServices")
                .DefaultView
                .ToTable(false, "Order No", "Merchant", "Status");
        }

        public async Task<DataTable> GetServiceSummaryAsync(DateTime? targetDate = null, int? id = null)
        {
            var data = await _Ops.FindServiceSummaryAsync(targetDate ?? DateTime.Now, id);
            return data.ToDataTable("ServiceSummary");
        }

        public async Task<DataTable> GetServiceAreaSummaryAsync(DateTime? targetDate = null, int? id = null)
        {
            var data = await _Ops.FindServiceAreaSummaryAsync(targetDate ?? DateTime.Now, id);
            return data.ToDataTable("ServiceAreaSummary");
        }

        public async Task<DataTable> GetInstalledTerminalCountAsync(int? regionId = null)
        {
            var data = await _Ops.FindInstalledTerminalCountAsync(regionId);
            return data.ToDataTable("InstalledTerminalCount");
        }

        public async Task<DataTable> GetServiceRequestAsync(DateTime? targetDate = null)
        {
            var data = await _Ops.FindServiceRequestAsync(targetDate ?? DateTime.Now);
            return data.ToDataTable("ServiceRequests");
        }

        public async Task<DataTable> GetMonthlyServiceCountAsync(int? id = null)
        {
            var data = await _Ops.FindMonthlyServiceCountAsync(id);
            return data.ToDataTable("MonthlyServiceCount");
        }

        public async Task<DataTable> GetMonthlySLAAsync(DateTime? targetDate = null, int? id = null)
        {
            var data = await _Ops.FindMonthlySLAAsync(targetDate ?? DateTime.Now, id);
            return data.ToDataTable("MonthlySLA");
        }

        public async Task<DataTable> GetUnclosedTicketsAsync(DateTime? targetDate = null, int? id = null)
        {
            var data = await _Ops.FindUnclosedTicketsAsync(targetDate ?? DateTime.Now, id);
            return data.ToDataTable("UnclosedTickets");
        }

        public async Task<DataTable> GetDispatchersServicesAsync(DateTime? targetDate = null, int? id = null)
        {
            var data = await _Ops.FindDispatcherServicesAsync(targetDate ?? DateTime.Now, id);
            return data.ToDataTable("DispatchersServices");
        }

        public async Task<DataTable> GetStoresAsync(string search = null)
        {
            var results = await _Ops.FindStoresAsync(string.IsNullOrWhiteSpace(search) ? null : search.Trim());

            return results.ToDataTable("Stores");
        }

        public async Task<DataTable> GetMerchantAsync(string search = null, string mode = null)
        {
            string effectiveSearch = string.IsNullOrWhiteSpace(search) ? null : search?.Trim();
            string effectiveMode = string.IsNullOrWhiteSpace(mode) ? null : mode?.Trim();

            var results = await _Ops.FindMerchantAsync(effectiveSearch, effectiveMode);
            return results.ToDataTable("Merchants");
        }

        public async Task<DataTable> GetListOfTerminalsAsync(string search = null)
        {
            string filter = string.IsNullOrWhiteSpace(search) ? null : search?.Trim();
            var results = await _Ops.FindTerminalsAsync(filter);
            return results.ToDataTable("Terminals");
        }

        public async Task<DataTable> GetListOfSimCardsAsync(string search = null)
        {
            string filter = string.IsNullOrWhiteSpace(search) ? null : search?.Trim();
            var results = await _Ops.FindSimCardsAsync(filter);
            return results.ToDataTable("SimCards");
        }

        public async Task<DataTable> GetAvailableTerminalsAsync(string search = null)
        {
            string filter = string.IsNullOrWhiteSpace(search) ? null : search?.Trim();

            // 1. Get raw dynamic results from Dapper
            var rawResults = await _Ops.FindTerminalsAsync(filter, limit: 10);

            // 2. Convert to DataTable (using your existing extension)
            var dt = rawResults.ToDataTable("TempTerminals");

            // 3. Now filter using LINQ-to-DataSet
            var filteredRows = dt.AsEnumerable()
                .Where(row => row.Field<string>("Status") == "AVAILABLE");

            if (!filteredRows.Any())
            {
                // Return empty table with same structure
                return dt.Clone();
            }

            // 4. Create the result table
            var resultTable = filteredRows.CopyToDataTable();

            // 5. Select only desired columns
            return resultTable.DefaultView.ToTable(false, "ID", "Serial");
        }

        public async Task<DataTable> GetAvailableSimsAsync(string search = null)
        {
            string filter = string.IsNullOrWhiteSpace(search) ? null : search?.Trim();

            var rawResults = await _Ops.FindSimCardsAsync(filter, limit: 10);
            var dt = rawResults.ToDataTable("TempSims");

            var filteredRows = dt.AsEnumerable()
                .Where(row => row.Field<string>("Status") == "AVAILABLE");

            if (!filteredRows.Any())
            {
                return dt.Clone();
            }

            var resultTable = filteredRows.CopyToDataTable();
            return resultTable.DefaultView.ToTable(false, "ID", "Serial");
        }

        public async Task<ProcedureDto> SetReplaceDeviceAsync(int id, string terminalSn, string simSn)
        {
            return await _Ops.CallReplaceDeviceAsync(id, terminalSn, simSn);
        }

        public async Task<InstallationModel> GetInstallationRecordAsync(int? id = null)
        {
            if (!id.HasValue)
                return null;

            var rawResults = await _Ops.FindInstallationRequestAsync(id.Value);

            var dt = rawResults.ToDataTable("InstallationRequest");

            if (dt.Rows.Count == 0)
                return null;

            var row = dt.Rows[0];

            return new InstallationModel
            {
                RequestNo = row["Request_No"]?.ToString(),
                Merchant = row["Merchant"]?.ToString(),
                TID = row["TID"]?.ToString(),
                MID = row["MID"]?.ToString(),
                ModelName = row["Model_Name"]?.ToString(),
                TerminalSN = row["Terminal_SN"]?.ToString(),
                Carrier = row["Carrier"]?.ToString(),
                SimSN = row["Sim_SN"]?.ToString(),
                Address = row["Address"]?.ToString(),
                ContactPerson = row["Contact_Person"]?.ToString(),
                ContactNo = row["Contact_No"]?.ToString(),
                Email = row["Email"]?.ToString(),
                Region = row["Region"]?.ToString(),
                AppCrc = row["App_Crc"]?.ToString(),
                AppVersion = row["App_Version"]?.ToString(),
                CreatedDate = row["Created_Date"] == DBNull.Value
                                    ? DateTime.MinValue
                                    : Convert.ToDateTime(row["Created_Date"])
            };
        }

        public async Task<ResultDto> SetPullOutMerchantAsync(int IrID)
        {
            if (IrID <= 0)
            {
                return ResultDto.Fail("Invalid merchant/request ID");
            }

            return await _Ops.PullOutMerchantAsync(IrID);
        }

    }
}
