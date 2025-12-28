using MIS_Admin.Model;
using MIS_Admin.Model.Dto;
using MIS_Admin.Repository;
using Next.Controls.Extention;
using System.Data;


namespace MIS_Admin.Services
{
    internal class OperationsSvc
    {
        private Operations Ops;

        public OperationsSvc() 
        {
            Ops = new Operations();
        }

        public DataTable getServices(string search)
        {
            object param = string.IsNullOrWhiteSpace(search) 
                ? DBNull.Value 
                : search;

            return Ops.FindServices(param);
        }

        public async Task<DataTable> getServicesAsync(string search = null)
            => (await Ops.FindServicesAsync(string.IsNullOrWhiteSpace(search) ? DBNull.Value : search, 100)).ToDataTable("Services");

        /*
        public async Task<DataTable> getServicesAsync(string search)
        {
            object filter = string.IsNullOrWhiteSpace(search)
                ? DBNull.Value 
                : search;

            return await Ops.FindServicesAsync(filter, 100);
        }
        */

        public async Task<DataTable> getHelpdeskRequestAsync(string search)
        {
            object filter = string.IsNullOrWhiteSpace(search)
                ? DBNull.Value
                : search;

            return await Ops.FindHelpdeskRequestAsync(filter, DBNull.Value, 100);
        }

        public async Task<DataTable> getRecentServices() =>
            (await Ops.FindServicesAsync(DBNull.Value, 10))
                .ToDataTable("RecentServices")
                .DefaultView
                .ToTable(false, "Order No", "Merchant", "Status");


        /*
        public async Task<DataTable> getRecentServices()
        {
            var details = await Ops.FindServicesAsync(string.Empty, 10);

            return details.DefaultView.ToTable(false, "Order No", "Merchant", "Status");
        }
        */

        public async Task<DataTable> getServiceSummary(int? id)
        {
            object userid = id.HasValue 
                ? id.Value 
                : DBNull.Value;

            return await Ops.FindServiceSummary(userid, DateTime.Now);
        }

        public async Task<DataTable> getServiceAreaSummary(int? id)
        {
            object userid = id.HasValue
                ? id.Value
                : DBNull.Value;

            return await Ops.FindServiceAreaSummary(userid, DateTime.Now);
        }

        public async Task<DataTable> getInstalledTerminalCount(int? id)
        {
            object regionId = id.HasValue
                ? id.Value
                : DBNull.Value;

            return await Ops.FindInstalledTerminalCount(regionId);
        }

        public async Task<DataTable> getServiceRequestAsync(DateTime? date)
        {
            object param = date.HasValue
                ? date.Value
                : DBNull.Value;

            return await Ops.FindServiceRequestAsync(param);
        }

        public async Task<DataTable> getMonthlyServiceCountAsync(int? id)
        {
            object param = id.HasValue
                ? id.Value
                : DBNull.Value;

            return await Ops.FindMonthlyServiceCountAsync(param);
        }

        public async Task<DataTable> getMonthlySLA(int? id, DateTime? targetDate)
        {
            object param = id.HasValue
              ? id.Value
              : DBNull.Value;

            DateTime dateValue = targetDate ?? DateTime.Now;

            return await Ops.FindMonthlySLA(param, dateValue);
        }

        public async Task<DataTable> getUnclosedTicketsAsync(int? id, DateTime? targetDate)
        {
            object param = id.HasValue
             ? id.Value
             : DBNull.Value;

            DateTime dateValue = targetDate ?? DateTime.Now;

            return await Ops.FindUnclosedTicketsAsync(param, dateValue);
        }

        public async Task<DataTable> getDispatchersServices(int? id, DateTime? targetDate)
        {
            object param = id.HasValue
             ? id.Value
             : DBNull.Value;

            DateTime dateValue = targetDate ?? DateTime.Now;

            return await Ops.FindDispatcherServices(param, dateValue);
        }

        public DataTable getStores(string search)
        {
            object filter = string.IsNullOrWhiteSpace(search) 
                ? DBNull.Value 
                : search;

            return Ops.FindStores(filter);
        }

        public async Task<DataTable> getMerchantAsync(string search, string mode = null)
        {
            object filter = string.IsNullOrWhiteSpace(search)
                ? DBNull.Value
                : search;

            object filterMode = string.IsNullOrWhiteSpace(mode)
                ? DBNull.Value
                : mode;

            return await Ops.FindMerchantAsync(filter, filterMode);
        }

        public async Task<DataTable> getListOfTerminals(string search)
        {
            object filter = string.IsNullOrWhiteSpace(search) 
                ? DBNull.Value 
                : search;

            return await Ops.FindTerminals(filter);
        }

        public DataTable getListOfSimCards(string search)
        {
            object filter = string.IsNullOrWhiteSpace(search) 
                ? DBNull.Value 
                : search;

            return Ops.FindSimCards(filter);
        }

        public async Task<DataTable> getAvailableTerminals(string search)
        {
            object filter = string.IsNullOrWhiteSpace(search)
                ? DBNull.Value
                : search;

            var dt = await Ops.FindTerminals(filter, 10);

            var filtered = dt.AsEnumerable()
                .Where(r => r.Field<string>("Status") == "AVAILABLE");

            var result = filtered.Any() ? filtered.CopyToDataTable() : dt.Clone();

            return result.DefaultView.ToTable(false, "ID", "Serial");
        }

        public DataTable getAvailableSims(string search)
        {
            object filter = string.IsNullOrWhiteSpace(search)
                ? DBNull.Value
                : search;

            var dt = Ops.FindSimCards(filter, 10);

            var filtered = dt.AsEnumerable()
                .Where(r => r.Field<string>("Status") == "AVAILABLE");

            var result = filtered.Any() ? filtered.CopyToDataTable() : dt.Clone();

            return result.DefaultView.ToTable(false, "ID", "Serial");
        }

        public ProcedureResult SetReplaceDevice(int id, string terminalSn, string simSn)
        {
            var Tsn = string.IsNullOrWhiteSpace(terminalSn) ? null : terminalSn;
            var Ssn = string.IsNullOrWhiteSpace(simSn) ? null : simSn;

            return Ops.CallReplaceDevice(id, Tsn, Ssn);
        }

        public async Task<InstallationDetails> GetInstallationRecord(int? id)
        {
            object param = id.HasValue ? id.Value : DBNull.Value;

            DataTable dt = await Ops.FindInstallationRequest(param);
            if (dt.Rows.Count == 0)
                return null;

            DataRow r = dt.Rows[0];
            return new InstallationDetails
            {
                RequestNo   = r["Request_No"]?.ToString(),
                Merchant    = r["Merchant"]?.ToString(),
                TID         = r["TID"]?.ToString(),
                MID         = r["MID"]?.ToString(),
                ModelName   = r["Model_Name"]?.ToString(),
                TerminalSN  = r["Terminal_SN"]?.ToString(),
                Carrier     = r["Carrier"]?.ToString(),
                SimSN       = r["Sim_SN"]?.ToString(),
                Address     = r["Address"]?.ToString(),
                ContactPerson = r["Contact_Person"]?.ToString(),
                ContactNo   = r["Contact_No"]?.ToString(),
                Email       = r["Email"]?.ToString(),
                Region      = r["Region"]?.ToString(),
                AppCrc      = r["App_Crc"]?.ToString(),
                AppVersion  = r["App_Version"]?.ToString(),
                CreatedDate = r["Created_Date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["Created_Date"])
            };
        }

        public ExeResult setPullOutMerchant(int? Id)
        {
            if (!Id.HasValue)
                return ExeResult.Fail("Invalid ID");

            ExeResult result = Ops.PullOutMerchant(Id.Value);

            return result;
        }

    }
}
