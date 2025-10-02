using MIS_Admin.Services;
using System.Data;

namespace MIS_Admin.Controller
{
    static class OperationsCtrl
    {
        private static OperationsSvc Ops = new OperationsSvc();

        public static DataTable getAllServices(string? search)
        {
            return Ops.getServices(search);
        }

        public static async Task<DataTable> getAllRecentServices()
        {
            return await Ops.getRecentServices();
        }

        public static async Task<DataTable> getAllServiceSummary(int? id)
        {
            return await Ops.getServiceSummary(id);
        }

        public static async Task<DataTable> getAllServiceRequest(DateTime? date)
        {
            return await Ops.getServiceRequestAsync(date);
        }

        public static async Task<DataTable> getAllMonthlyServiceCount(int? id)
        {
            return await Ops.getMonthlyServiceCountAsync(id);
        }

        public static async Task<DataTable> getAllUnclosedTickets(int? id)
        {
            return await Ops.getUnclosedTicketsAsync(id);
        }

        public static DataTable getAllStores(string? search)
        {
            return Ops.getStores(search);
        }

        public static DataTable getAllTerminals(string? search)
        {
            return Ops.getTerminals(search);
        }

        public static DataTable getAllSimCards(string? search)
        {
            return Ops.getSimCards(search);
        }
    }
}
