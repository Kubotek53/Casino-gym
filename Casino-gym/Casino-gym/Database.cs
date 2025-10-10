﻿using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Casino_gym
{
    internal class Database
    {
        private MySqlConnection connection;

        public Database()
        {
            string connectionString = "server=localhost;user=root;password=zaq1@WSX;database=casino_gym;";
            connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
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
                MessageBox.Show("Błąd połączenia z bazą danych: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
    }
}
