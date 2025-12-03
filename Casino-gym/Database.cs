using MySql.Data.MySqlClient;

namespace Casino_gym
{
    internal class Database
    {
        private static string connectionString =
            "Server=localhost;Database=casinogymdb;Uid=root;Pwd=;";
        // Uid=root, Pwd= — zostaw puste jeśli nie masz hasła w XAMPP

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
