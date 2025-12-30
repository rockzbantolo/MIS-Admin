using MIS_Admin.Model;
using MIS_Admin.Repository;
using static MIS_Admin.Model.Authenticate;

namespace MIS_Admin.Services
{
    public sealed class AuthService
    {
        private readonly User _user;
        private readonly Authenticate _auth;

        public AuthService()
        {
            _user = new User();
            _auth = new Authenticate();
        }

        public async Task<UserSession> GetUserAccountAsync(string username, string password)
        {
            object param = string.IsNullOrWhiteSpace(username) ? DBNull.Value : username;
            
            var rows = await _user.FindAccountAsync(param).ConfigureAwait(false);

            var row = rows.FirstOrDefault();
            if (row == null)
                return null;

            string dbPassword = row.Password?.ToString() ?? string.Empty;
            string encryptedInput = _auth.EncryptString(password);

            if (!string.Equals(dbPassword, encryptedInput, StringComparison.Ordinal))
                return null;

            return new UserSession
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
                return await _user.UpdateUserStatusAsync(id, 1, "LOGIN").ConfigureAwait(false);
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
                return await _user.UpdateUserStatusAsync(id, 2, "LOGOUT").ConfigureAwait(false);
            }
            catch
            {
                return false;
            }
        }
    }
}
