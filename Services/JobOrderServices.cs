using MIS_Admin.Models;
using MIS_Admin.Repository;
using MIS_Admin.UI.Dto.Lookup;
using Next.Extention;
using System.Data;

namespace MIS_Admin.Services
{
    public class JobOrderServices
    {
        private readonly JobOrderRepository _repo;


        public JobOrderServices() { 
            _repo = new JobOrderRepository();
        }

        public async Task<DataTable> GetJobOrdersAsync(
            string search = null,
            int? userId = null,
            IEnumerable<string> statuses = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            int page = 1,
            int pageSize = 50)
        {
            // PagedResult<ServiceDto>
            var pagedResult = await _repo.GetAllJobOrders(
                id: userId,
                search: search,
                filters: statuses,
                startDate: startDate,
                endDate: endDate,
                page: page,
                pageSize: pageSize
            );

            // Convert Data to DataTable
            return pagedResult.Data.ToDataTable("Services");
        }

        public async Task<JobOrderModel> GetJobOrderInfoAsync(int jobId)
        {
            return await _repo.GetJobOrderInfoAsync(jobId);
        }

        public async Task<DataTable> GetJobOrderHistory(int id)
        {
            var history = await _repo.GetAllJobOrderMerchantHistory(id);
            return history.ToDataTable("JobOrderHistory");
        }

        // Statuses
        public async Task<DataTable> GetSelectedServiceTypesAsync(int? id = null, int? limit = 10)
        {
            var data = await _repo.GetSelectedServiceTypesAsync(id, limit);

            return data.ToDataTable("ServiceTypes");
        }
        
        public async Task<DataTable> GetSelectedServiceResultsAsync(int? id = null, int? limit = 10)
        {
            var data = await _repo.GetSelectedServiceResultsAsync(id, limit);

            return data.ToDataTable("ServiceResults");
        }


        public void SaveJobOrder() { }
        public void DeleteJobOrder() { }
        public void UpdateJobOrder() { }
    }
}
