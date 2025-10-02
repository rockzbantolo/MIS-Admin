using MIS_Admin.Repository;
using Mysqlx.Crud;
using System.Collections.Generic;
using System.Data;


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
                ? date.Value.ToString("yyyy-MM-dd") 
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

        public async Task<DataTable> getUnclosedTicketsAsync(int? id)
        {
            object param = id.HasValue
                ? id.Value
                : DBNull.Value;

            return await Ops.FindUnclosedTicketsAsync(param);
        }

        public DataTable getStores(string? search)
        {
            object param = string.IsNullOrWhiteSpace(search) 
                ? DBNull.Value 
                : search;

            return Ops.FindStores(param);
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
