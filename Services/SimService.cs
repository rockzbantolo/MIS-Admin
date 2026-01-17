using MIS_Admin.Repository;
using MIS_Admin.UI.Dto;
using MIS_Admin.UI.Dto.Lookup;
using Next.Extention;
using System.Data;


namespace MIS_Admin.Services
{
    public class SimService
    {
        private readonly SimRepo _repo;

        public SimService() {
            _repo = new SimRepo();
        }

        public async Task<DataTable> GetSimCardsAsync(
            int? id = null,
            string search = null,
            IEnumerable<string> statuses = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            int page = 1,
            int pageSize = 100)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 100;

            var pagedResult = await _repo.GetAllSimCardsAsync(
                id: id,
                search: search,
                filters: statuses,
                startDate: startDate,
                endDate: endDate,
                page: page,
                pageSize: pageSize
            );

            // Convert ONLY what the grid needs
            var table = pagedResult.Data
                .Select(s => new
                {
                    s.Id,
                    s.Description,
                    s.Serial,
                    s.Status
                })
                .ToDataTable("SimCards");

            return table;
        }


        public async Task<DeviceLookupDto> GetSimSerial(string serial)
        {
            return (await _repo.GetSimsForSelectAsync(serial)).FirstOrDefault();
        }
    
    }
}
