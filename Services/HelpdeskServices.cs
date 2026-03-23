using MIS_Admin.Repository;
using Next.Extention;
using System.Data;

namespace MIS_Admin.Services
{
    public class HelpdeskServices
    {
        private readonly HelpdeskRepository _repo;

        public HelpdeskServices() { 
            _repo = new HelpdeskRepository();
        }

        public async Task<DataTable> GetHelpdeskRequestAsync(string search = null, int? id = null)
        {
            var data = await _repo.GetAllHelpdeskRequestAsync(search, id);

            return data.ToDataTable("HelpdeskRequests");
        }

    }
}
