using static MIS_Admin.Model.Authenticate;
using MIS_Admin.Services;

namespace MIS_Admin.Controller
{
    static class AuthCtrl
    {
        private static Auth auth = new Auth();

        public static UserSession? Authenticate(string username, string password)
            => auth.GetUserAccount(username, password);

        public static bool SignOutUser(int id)
           => auth.SignOutStatus(id);

        public static bool SignInUser(int id)
            => auth.SignInStatus(id);
    }
}
