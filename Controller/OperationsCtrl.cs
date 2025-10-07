using MIS_Admin.Services;
using System.Data;

namespace MIS_Admin.Controller
{
    static class OperationsCtrl
    {
        private static OperationsSvc Ops = new OperationsSvc();

        public static DataTable getAllServices(string? search = null)
        {
            return Ops.getServices(search);
        }

        public static async Task<DataTable> getAllServicesAsync(string? search = null)
        {
            return await Ops.getServicesAsync(search);
        }

        public static async Task<DataTable> getAllHelpdeskRequest(string? search = null)
        {
            return await Ops.getHelpdeskRequestAsync(search);
        }

        public static async Task<DataTable> getAllRecentServices()
        {
            return await Ops.getRecentServices();
        }

        public static async Task<DataTable> getAllServiceSummary(int? id = null)
        {
            return await Ops.getServiceSummary(id);
        }

        public static async Task<DataTable> getAllServiceRequest(DateTime? date = null)
        {
            return await Ops.getServiceRequestAsync(date);
        }

        public static async Task<DataTable> getAllMonthlyServiceCount(int? id = null)
        {
            return await Ops.getMonthlyServiceCountAsync(id);
        }

        public static async Task<DataTable> getAllMonthlySLACount(int? id = null)
        {
            return await Ops.getMonthlySLA(id, null);
        }

        public static async Task<DataTable> getAllUnclosedTickets(int? id = null)
        {
            return await Ops.getUnclosedTicketsAsync(id, null);
        }

        public static DataTable getAllStores(string? search = null)
        {
            return Ops.getStores(search);
        }

        public static async Task<DataTable> getAllStoresAsync(string? search = null)
        {
            return await Ops.getStoresAsync(search);
        }

        public static DataTable getAllTerminals(string? search = null)
        {
            return Ops.getTerminals(search);
        }

        public static DataTable getAllSimCards(string? search = null)
        {
            return Ops.getSimCards(search);
        }
    }
}
