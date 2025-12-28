using Next.Clients.Providers;
using System.Configuration;
using System.Diagnostics;

namespace MIS_Admin.Core
{
    public class Database
    {
        private static readonly Lazy<MySqlDb> _instance = new Lazy<MySqlDb>(Create, isThreadSafe: true);

        public static MySqlDb Instance => _instance.Value;

        private static MySqlDb Create()
        {
            var cs = ConfigurationManager.ConnectionStrings["MySqlDB"];

            if (cs == null)
                throw new InvalidOperationException("Connection string not found.");

            return new MySqlDb(cs.ConnectionString, Log);
        }

        private static void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
