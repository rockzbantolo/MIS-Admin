using MIS_Admin.Model;
using MIS_Admin.Repository;
using System.Data;

namespace MIS_Admin.Services
{
    internal class Auth
    {
        private User login = new User();
        private readonly Authenticate _auth = new Authenticate();

        public Authenticate.UserSession? GetUserAccount(string username, string password)
        {
            object param = string.IsNullOrWhiteSpace(username) ? DBNull.Value : username;
            DataTable dt = login.FindUser(param); // repository call

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];
            string dbPassword = row["Password"]?.ToString() ?? string.Empty;
            string encryptedInput = _auth.EncryptString(password);

            // Compare encrypted input with DB password
            if (!string.Equals(dbPassword, encryptedInput, StringComparison.Ordinal))
                return null;

            return new Authenticate.UserSession
            {
                UserID = Convert.ToInt32(row["UserID"]),
                UserName = row["UserName"]?.ToString(),
                FullName = row["FullName"]?.ToString(),
                Role = row["UserType"]?.ToString()
            };
        }

    }
}
