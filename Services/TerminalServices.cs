using MIS_Admin.Repository;
using MIS_Admin.UI.Dto;
using MIS_Admin.UI.Dto.Lookup;
using Next.Extention;
using System.Data;

namespace MIS_Admin.Services
{
    public class TerminalServices
    {
        private readonly TerminalRepository _repo;

        public TerminalServices() {
            _repo = new TerminalRepository(); 
        }

        public async Task<DataTable> GetTerminalAsync(
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

            var pagedResult = await _repo.GetAllTerminalInfosAsync(
                id: id,
                search: search,
                filters: statuses,
                startDate: startDate,
                endDate: endDate,
                page: page,
                pageSize: pageSize
            );

            // Convert
            var result = pagedResult.Data
                .Select(t => new
                {
                    t.Id,
                    t.Description,
                    t.Serial,
                    t.Status
                })
                .ToDataTable("Terminals");

            return result;
        }

        public async Task<DeviceLookupDto> GetTerminalSerial(string serial)
        {
            return (await _repo.GetTerminalsForSelectAsync(serial)).FirstOrDefault();
        }
    
    }
}
