using MySql.Data.MySqlClient;
using Next.Clients.Providers;
using Next.Common;
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
            bool isDev = bool.Parse(ConfigurationManager.AppSettings["DevMode"] ?? "false");

            // Developmnent Mode
            if (isDev)
            {
                var settings = ConfigurationManager.AppSettings;
                return MySqlDbBuilder
                    .For(settings["DevHost"], settings["DevName"])
                    .Port(uint.Parse(settings["DevPort"]))
                    .WithCredentials(settings["DevUser"], settings["DevPass"])
                    .ConnectTimeout(uint.Parse(settings["DevConnectTimeout"]))
                    .SslMode(Enum.Parse<MySqlSslMode>(settings["DevSslMode"]))
                    .Logger(msg => Logger.Info(msg))
                    .Build();
            }

            // Production Mode
            var cs = ConfigurationManager.ConnectionStrings["MySqlDB"]?.ConnectionString;
            if (string.IsNullOrEmpty(cs)) throw new InvalidOperationException("Missing connection string 'MySqlDB'");

            var csb = new MySqlConnectionStringBuilder(cs);
            return MySqlDbBuilder
                .For(csb.Server, csb.Database)
                .Port(csb.Port)
                .WithCredentials(csb.UserID, csb.Password)
                .ConnectTimeout(csb.ConnectionTimeout)
                .SslMode(csb.SslMode)
                .Logger(Log)
                .Build();
        }

        private static void Log(string message)
        {
            Debug.WriteLine(message);
        }
    
    }
}
