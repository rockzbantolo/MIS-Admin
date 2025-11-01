using MIS_Admin.Model;
using MIS_Admin.Services;
using System.Data;

namespace MIS_Admin.Controller
{
    static class OperationsCtrl
    {
        private static OperationsSvc Ops = new OperationsSvc();


        // SERVICES
        public static DataTable getAllServices(string? search = null)
            => Ops.getServices(search);

        public static async Task<DataTable> getAllServicesAsync(string? search = null) 
            => await Ops.getServicesAsync(search);

        public static async Task<DataTable> getAllHelpdeskRequest(string? search = null) 
            => await Ops.getHelpdeskRequestAsync(search);

        public static async Task<DataTable> getAllRecentServices() 
            => await Ops.getRecentServices();

        public static async Task<DataTable> getAllServiceSummary(int? id = null) 
            => await Ops.getServiceSummary(id);

        public static async Task<DataTable> getAllAreaSummary(int? id = null)
           => await Ops.getAreaSummary(id);

        public static async Task<DataTable> getAllServiceRequest(DateTime? date = null) 
            => await Ops.getServiceRequestAsync(date);

        public static async Task<DataTable> getAllMonthlyServiceCount(int? id = null)
            => await Ops.getMonthlyServiceCountAsync(id);

        public static async Task<DataTable> getAllMonthlySLACount(int? id = null) 
            => await Ops.getMonthlySLA(id, null);

        public static async Task<DataTable> getAllUnclosedTickets(int? id = null)
            => await Ops.getUnclosedTicketsAsync(id, null);

        public static async Task<DataTable> getAllDispatchersServices(int? id = null)
            => await Ops.getDispatchersServices(id, null);

        // RECORDS
        public static DataTable getAllStores(string? search = null)
            => Ops.getStores(search);

        public static async Task<DataTable> getAllMerchantAsync(string? search = null)
            => await Ops.getMerchantAsync(search);

        public static async Task<DataTable> getAllListOfTerminals(string? search = null)
            => await Ops.getListOfTerminals(search);

        public static DataTable getAllListOfSimCards(string? search = null)
            => Ops.getListOfSimCards(search);

        public static async Task<DataTable> getAllAvailableTerminals(string? search = null)
            => await Ops.getAvailableTerminals(search);

        public static DataTable getAllAvailableSimCards(string? search = null)
            => Ops.getAvailableSims(search);

        public static ProcedureResult ReplaceDevice(int Id, string terminalSN, string simSN)
            => Ops.SetReplaceDevice(Id, terminalSN, simSN);

        public static async Task<InstallationDetails> getInstallationDetails(int? Id = null)
            => await Ops.GetInstallationRecord(Id);

    }
}
