using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Casino_gym
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool debug = false; // ustaw na true tymczasowo jeśli chcesz widzieć nazwę bazy i wynik insertu

            string username = textboxUsername.Text ?? "";
            string password = textboxPassword.Text ?? "";

            // Normalizacja i oczyszczenie
            username = username.Trim();
            username = Regex.Replace(username, @"\s+", " ");
            username = username.Normalize(NormalizationForm.FormC);

            password = password.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola.");
                return;
            }

            string hashedPassword = GetSHA256(password);

            string connectionString = "server=localhost;uid=root;pwd=zaq1@WSX;database=casinogymdb;";

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    if (debug)
                    {
                        // pokaż, z jaką bazą się łączysz (pomocne do weryfikacji)
                        var dbName = new MySqlCommand("SELECT DATABASE()", conn).ExecuteScalar();
                        MessageBox.Show("Połączono z bazą: " + (dbName ?? "(brak)"));
                    }

                    // Używamy INSERT IGNORE -> jeśli username ma UNIQUE index, wstawienie zostanie zignorowane przy duplikacie
                    using (var cmd = new MySqlCommand(
                        "INSERT IGNORE INTO users (username, password) VALUES (@username, @password);", conn))
                    {
                        cmd.Parameters.Add("@username", MySqlDbType.VarChar, 100).Value = username;
                        cmd.Parameters.Add("@password", MySqlDbType.VarChar, 255).Value = hashedPassword;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (debug)
                        {
                            MessageBox.Show("rowsAffected = " + rowsAffected);
                        }

                        if (rowsAffected == 1)
                        {
                            MessageBox.Show("Rejestracja zakończona pomyślnie!");
                            this.Hide();
                            new Login().Show();
                            return;
                        }
                        else
                        {
                            // rowsAffected == 0 -> INSERT IGNORE zignorował wstawienie => użytkownik już istnieje
                            MessageBox.Show("Ten użytkownik już istnieje. Wybierz inny login.");
                            return;
                        }
                    }
                }
            }
            catch (MySqlException mex)
            {
                MessageBox.Show("Błąd MySQL: " + mex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

        private static string GetSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }
    }
}
