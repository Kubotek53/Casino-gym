using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Casino_gym
{
    internal class Database
    {
        private static string dbFile = "casino.db";
        private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dbFile);

        private SQLiteConnection connection;

        public Database()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            CreateTables();

            string connectionString = $"Data Source={dbPath};Version=3;";
            connection = new SQLiteConnection(connectionString);
        }

        public SQLiteConnection GetConnection()
        {
            return connection;
        }

        public void OpenConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Błąd połączenia z bazą danych: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        private void CreateTables()
        {
            try
            {
                using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    conn.Open();

                    string sql = @"
                        CREATE TABLE IF NOT EXISTS users (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            username TEXT NOT NULL UNIQUE,
                            password TEXT NOT NULL,
                            role TEXT DEFAULT 'user',
                            balance REAL DEFAULT 0,
                            age INTEGER
                        );

                        CREATE TABLE IF NOT EXISTS transactions (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            username TEXT NOT NULL,
                            amount REAL NOT NULL,
                            transaction_type TEXT NOT NULL,
                            timestamp DATETIME DEFAULT CURRENT_TIMESTAMP
                        );
                    ";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠ Błąd tworzenia tabel: " + ex.Message);
            }
        }
    }
}
