using MIS_Admin.Repository;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace MIS_Admin.Services
{
    internal class OperationsSvc
    {
        private Operations Ops = new Operations();

        public DataTable getServices(string? search)
        {
            object param = string.IsNullOrWhiteSpace(search) 
                ? DBNull.Value 
                : search;

            return Ops.FindServices(param);
        }

        public async Task<DataTable> getServicesAsync(string? search)
        {
            object param = string.IsNullOrWhiteSpace(search)
                ? DBNull.Value 
                : search;

            return await Ops.FindServicesAsync(param, 100);
        }

        public async Task<DataTable> getHelpdeskRequestAsync(string? search)
        {
            object param = string.IsNullOrWhiteSpace(search)
                ? DBNull.Value
                : search;

            return await Ops.FindHelpdeskRequestAsync(param, DBNull.Value, 100);
        }

        public async Task<DataTable> getRecentServices()
        {
            var fullTable = await Ops.FindServicesAsync(string.Empty, 10);

            // Keep only required columns
            var result = fullTable.DefaultView.ToTable(false, "Order No", "Merchant", "Status");
            return result;
        }

        public async Task<DataTable> getServiceSummary(int? id)
        {
            object param = id.HasValue 
                ? id.Value 
                : DBNull.Value;

            return await Ops.FindServiceSummary(param);
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



        public DataTable getStores(string? search)
        {
            object param = string.IsNullOrWhiteSpace(search) 
                ? DBNull.Value 
                : search;

            return Ops.FindStores(param);
        }

        public async Task<DataTable> getStoresAsync(string? search)
        {
            object param = string.IsNullOrWhiteSpace(search)
                ? DBNull.Value
                : search;

            return await Ops.FindStoresAsync(param);
        }

        public DataTable getTerminals(string? search)
        {
            object param = string.IsNullOrWhiteSpace(search) 
                ? DBNull.Value 
                : search;

            return Ops.FindTerminals(param);
        }

        public DataTable getSimCards(string? search)
        {
            object param = string.IsNullOrWhiteSpace(search) 
                ? DBNull.Value 
                : search;

            return Ops.FindTerminals(param);
        }
    }
}
