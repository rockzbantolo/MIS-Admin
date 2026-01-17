using MIS_Admin.Repository;
using Next.Extention;
using System.Data;

namespace MIS_Admin.Services
{
    public class UserService
    {
        private readonly UserRepo _repo;

        public UserService() { 
            _repo = new UserRepo();
        }

        public async Task<DataTable> GetUsersAsync(
            int? id = null,
            string search = null,
            IEnumerable<string> filter = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            int page = 1,
            int pageSize = 100)
        {
            var pagedResult = await _repo.GetAllUsersAsync(
                id,
                search,
                filter,
                startDate,
                endDate,
                page,
                pageSize
            );

            return pagedResult.Data
                .Select(u => new
                {
                    u.Id,
                    u.Personel,
                    u.ContactNo,
                    u.Email
                })
                .ToDataTable("Users");
        }

        public async Task<DataTable> GetSelectedDispatchersAsync(string search = null, int page = 1, int pageSize = 100)
        {
            var result = await _repo.GetAllUsersAsync(
                search: search,
                filter: new[] { "Employee" },
                page: page,
                pageSize: pageSize
            );

            return result.Data
                .Select(u => new { u.Id, u.Personel, u.ContactNo, u.Email })
                .ToDataTable("Dispatchers");
        }

        public async Task<DataTable> GetSelectedFieldEngineersAsync(string search = null, int page = 1, int pageSize = 100)
        {
            var result = await _repo.GetAllUsersAsync(
                search: search,
                filter: new[] { "Field Engineer" },
                page: page,
                pageSize: pageSize
            );

            return result.Data
                .Select(u => new { u.Id, u.Personel, u.ContactNo, u.Email })
                .ToDataTable("FieldEngineers");
        }

        public void Save() { }
        public void Delete() { }
        public void Update() { }

    }
}
