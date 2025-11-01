using MySql.Data.MySqlClient;


namespace MIS_Admin.Core
{
    public abstract class Connection
    {
        private readonly string _connectionString =
            "Persist Security Info=false;" +
            "Server=18.142.99.40;" +
            "Port=3306;" +
            "Database=miscastlesdb;" +
            "User=miscastles;" +
            "Password=G@X0_Fg.wae];" +
            "Connect Timeout = 5000";

        /*
        private readonly string _connectionString =
           "Persist Security Info=false;" +
           "Server=18.141.223.103;" +
           "Port=3306;" +
           "Database=miscastlesdb;" +
           "User=miscastles;" +
           "Password=G@X0_Fg.wae];" +
           "Connect Timeout = 5000";
        */

        // Protected so only child classes can use
        // Always return a *new, unopened* connection.

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
