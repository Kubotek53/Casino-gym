using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

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
            string username = textboxUsername.Text.Trim();
            string password = textboxPassword.Text.Trim();

            // Sprawdzenie poprawności danych
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hashowanie hasła
            string hashedPassword = GetSHA256(password);

            // 🔹 ZMIEŃ TYLKO TO jeśli masz inną bazę, użytkownika lub hasło
            string connectionString = "server=localhost;uid=root;pwd=zaq1@WSX;database=casino_gym;";

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // 1️⃣ Sprawdzenie, czy użytkownik już istnieje
                    using (var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM users WHERE username = @username", conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);
                        int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (userExists > 0)
                        {
                            MessageBox.Show("Ten użytkownik już istnieje. Wybierz inny login.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // 2️⃣ Rejestracja nowego użytkownika z domyślną rolą "Użytkownicy"
                    using (var insertCmd = new MySqlCommand("INSERT INTO users (username, password, role) VALUES (@username, @password, @role)", conn))
                    {
                        insertCmd.Parameters.AddWithValue("@username", username);
                        insertCmd.Parameters.AddWithValue("@password", hashedPassword);
                        insertCmd.Parameters.AddWithValue("@role", "Użytkownik"); // 🔹 domyślna rola

                        int rowsAffected = insertCmd.ExecuteNonQuery();

                        if (rowsAffected == 1)
                        {
                            MessageBox.Show("Rejestracja zakończona pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new Login().Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Nie udało się utworzyć konta. Spróbuj ponownie.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nieoczekiwany błąd: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        // Funkcja hashująca hasło (SHA256)
        private static string GetSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Niepotrzebne zdarzenie – można usunąć, ale nie przeszkadza
        }
    }
}
