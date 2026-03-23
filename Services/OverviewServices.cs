using MIS_Admin.Repository;
using Mysqlx.Crud;
using Next.Extention;
using System.Data;


namespace MIS_Admin.Services
{
    public class OverviewServices
    {
        private readonly JobOrderRepository _jobs;
        private readonly HelpdeskRepository _hd;
        private readonly TerminalRepository _term;

        public OverviewServices() {
            _jobs = new JobOrderRepository();
            _hd = new HelpdeskRepository();
            _term = new TerminalRepository();
        }

        public async Task<DataTable> GetRecentJobOrdersAsync()
        {
            var result = await _jobs.GetAllJobOrders(
                page: 1,
                pageSize: 10
            );

            return result.Data
                .ToDataTable("RecentServices")
                .DefaultView
                .ToTable(false, "Job_ID", "Merchant", "Status");
        }

        public async Task<DataTable> GetMonthlyJobOrderCountAsync(int? id = null)
        {
            var data = await _jobs.GetAllMonthlyJobOrderCountAsync(id);
            return data.ToDataTable("MonthlyJobOderCount");
        }

        public async Task<DataTable> GetJobOrderRequestAsync(DateTime? targetDate = null)
        {
            var data = await _jobs.GetAllJobOrderRequestAsync(targetDate ?? DateTime.Now);
            return data.ToDataTable("JobOrderRequest");
        }

        public async Task<DataTable> GetJobOrderSummaryAsync(DateTime? targetDate = null, int? id = null)
        {
            var data = await _jobs.GetAllJobOrderSummaryAsync(targetDate ?? DateTime.Now, id);
            return data.ToDataTable("JobOrderSummary");
        }

        public async Task<DataTable> GetJobOrderAreaSummaryAsync(DateTime? targetDate = null, int? id = null)
        {
            var data = await _jobs.GetAllJobOrderAreaSummaryAsync(targetDate ?? DateTime.Now, id);
            return data.ToDataTable("JobOrderAreaSummary");
        }

        public async Task<DataTable> GetMonthlySlaAsync(DateTime? targetDate = null, int? id = null)
        {
            var data = await _jobs.GetAllMonthlySlaAsync(targetDate ?? DateTime.Now, id);

            return data.ToDataTable("MonthlySLA");
        }

        public async Task<DataTable> GetUnclosedTicketsAsync(DateTime? targetDate = null, int? id = null)
        {
            var data = await _jobs.GetAllUnclosedTicketsAsync(targetDate ?? DateTime.Now, id);
            return data.ToDataTable("UnclosedTickets");
        }

        public async Task<DataTable> GetInstalledTerminalCountAsync(int? regionId = null)
        {
            var data = await _term.GetAllInstalledTerminalCountAsync(regionId);
            return data.ToDataTable("InstalledTerminalCount");
        }

        public async Task<DataTable> GetDispatchJobOrdersAsync(DateTime? targetDate = null, int? id = null)
        {
            var data = await _jobs.GetAllDispatchJobOrdersAsync(targetDate ?? DateTime.Now, id);
            return data.ToDataTable("DispatchersServices");
        }

        public async Task<DataTable> GetHelpdeskRequestAsync(string search = null, int? id = null)
        {
            var data = await _hd.GetAllHelpdeskRequestAsync(search, id);

            return data.ToDataTable("HelpdeskRequests");
        }

    }
}
