using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Casino_gym
{
    public partial class Login : Form
    {
        public static string CurrentUserRole = "guest";
        public static string CurrentLoggedUsername = "";   // 👈 TU zapisujemy zalogowanego użytkownika

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DoLogin();
        }

        private void Logowanie2_Click(object sender, EventArgs e)
        {
            DoLogin();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Hide();
        }
        private void textboxUsername_TextChanged(object sender, EventArgs e)
        {
            // nic nie musi tu być
        }

        private void textboxPassword_TextChanged_1(object sender, EventArgs e)
        {
            // nic nie musi tu być
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // opcjonalnie
        }

        private void btnSkipLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kontynuujesz jako gość.", "Tryb gościa");
            CurrentUserRole = "guest";
            CurrentLoggedUsername = "guest";   // 👈 dodane
            MainPage main = new MainPage();
            main.Show();
            this.Hide();
        }

        private void DoLogin()
        {
            string user = textboxUsername.Text.Trim().ToLower();
            string pass = textboxPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!");
                return;
            }

            string hashedPassword = GetSHA256(pass);

            try
            {
                string connectionString =
                    "server=127.0.0.1;port=3306;user=root;password=zaq1@WSX;database=casino_gym;SslMode=none;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT role FROM users WHERE LOWER(username)=@user AND password=@pass LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", user);
                        cmd.Parameters.AddWithValue("@pass", hashedPassword);

                        var reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string role = reader["role"].ToString();

                            CurrentUserRole = role;        // 👈 Zapisujemy rolę
                            CurrentLoggedUsername = user;  // 👈 ZAPISUJEMY LOGIN UŻYTKOWNIKA

                            MessageBox.Show($"Zalogowano jako: {user} ({role})");

                            MainPage main = new MainPage();
                            main.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Niepoprawny login lub hasło!");
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas logowania: " + ex.Message);
            }
        }

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
    }
}
