using MIS_Admin.Repository;
using Next.Extention;
using System.Data;

namespace MIS_Admin.Services
{
    public class HelpdeskService
    {
        private readonly HelpdeskRepo _repo;

        public HelpdeskService() { 
            _repo = new HelpdeskRepo();
        }

        public async Task<DataTable> GetHelpdeskRequestAsync(string search = null, int? id = null)
        {
            var data = await _repo.GetAllHelpdeskRequestAsync(search, id);

            return data.ToDataTable("HelpdeskRequests");
        }

    }
}
