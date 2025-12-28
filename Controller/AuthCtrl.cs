using MIS_Admin.Services;
using static MIS_Admin.Model.Authenticate;

namespace MIS_Admin.Controller
{
    static class AuthCtrl
    {
        private static readonly Auth auth = new Auth();

        public static Task<UserSession> AuthenticateAsync(string username, string password)
            => auth.GetUserAccountAsync(username, password);

        public static Task<bool> SignOutUserAsync(int id)
            => auth.SignOutStatusAsync(id);

        public static Task<bool> SignInUserAsync(int id)
            => auth.SignInStatusAsync(id);
    }
}
