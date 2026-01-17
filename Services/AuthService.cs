using MIS_Admin.Models;
using MIS_Admin.Repository;
using Next.Extention;
using System.Data;
using static MIS_Admin.Models.AuthModel;

namespace MIS_Admin.Services
{
    public sealed class AuthService
    {
        private readonly UserRepo _repo;
        private readonly AuthModel _auth;

        public AuthService()
        {
            _repo = new UserRepo();
            _auth = new AuthModel();
        }

        public async Task<Session> GetUserAccountAsync(string username, string password)
        {
            object param = string.IsNullOrWhiteSpace(username) ? DBNull.Value : username;
            
            var rows = await _repo.FindAccountAsync(param).ConfigureAwait(false);

            var row = rows.FirstOrDefault();
            if (row == null)
                return null;

            string dbPassword = row.Password?.ToString() ?? string.Empty;
            string encryptedInput = _auth.EncryptString(password);

            if (!string.Equals(dbPassword, encryptedInput, StringComparison.Ordinal))
                return null;

            return new Session
            {
                UserID = Convert.ToInt32(row.UserID),
                UserName = row.UserName?.ToString(),
                FullName = row.FullName?.ToString(),
                Role = row.UserType?.ToString()
            };
        }

        public async Task<bool> SignInStatusAsync(object id)
        {
            try
            {
                return await _repo.UpdateUserStatusAsync(id, 1, "LOGIN").ConfigureAwait(false);
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SignOutStatusAsync(object id)
        {
            try
            {
                return await _repo.UpdateUserStatusAsync(id, 2, "LOGOUT").ConfigureAwait(false);
            }
            catch
            {
                return false;
            }
        }
    }
}
