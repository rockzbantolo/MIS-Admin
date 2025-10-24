using MIS_Admin.Model;
using MIS_Admin.Repository;
using System.Data;
using static MIS_Admin.Model.Authenticate;

namespace MIS_Admin.Services
{
    internal class Auth
    {
        private User _user;
        private readonly Authenticate _auth;

        public Auth()
        {
            _user = new User();
            _auth = new Authenticate();
        }

        public UserSession? GetUserAccount(string username, string password)
        {
            object param = string.IsNullOrWhiteSpace(username) ? DBNull.Value : username;
            DataTable dt = _user.FindAccount(param); // repository call

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];
            string dbPassword = row["Password"]?.ToString() ?? string.Empty;
            string encryptedInput = _auth.EncryptString(password);

            // Compare encrypted input with DB password
            if (!string.Equals(dbPassword, encryptedInput, StringComparison.Ordinal))
                return null;

            return new UserSession
            {
                UserID = Convert.ToInt32(row["UserID"]),
                UserName = row["UserName"]?.ToString(),
                FullName = row["FullName"]?.ToString(),
                Role = row["UserType"]?.ToString()
            };
        }

        public bool SignInStatus(object id)
        {
            try
            {
                return _user.UpdateUserStatus(id, 1, "LOGIN"); ;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SignOutStatus(object id)
        {
            try
            {
                return _user.UpdateUserStatus(id, 2, "LOGOUT"); ;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
