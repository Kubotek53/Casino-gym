using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Casino_gym
{
    public partial class Login : Form
    {
        // 🔹 Przechowuje aktualną rolę użytkownika (dostępna globalnie)
        public static string CurrentUserRole = "guest";

        public Login()
        {
            InitializeComponent();
        }

        // ================================
        // ZDARZENIA FORMULARZA
        // ================================
        private void Login_Load(object sender, EventArgs e)
        {
            // Można dodać inicjalizację połączenia, jeśli potrzebna
        }

        private void textboxUsername_TextChanged(object sender, EventArgs e) { }

        private void textboxPassword_TextChanged(object sender, EventArgs e) { }

        // ================================
        // PRZYCISKI
        // ================================
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

        // 🔹 Przycisk — kontynuuj bez logowania
        private void btnSkipLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kontynuujesz jako gość.", "Tryb gościa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CurrentUserRole = "guest"; // przypisanie roli gościa
            MainPage main = new MainPage();
            main.Show();
            this.Hide();
        }

        // ================================
        // LOGIKA LOGOWANIA
        // ================================
        private void DoLogin()
        {
            string user = textboxUsername.Text.Trim().ToLower(); // 🔹 lowercase
            string pass = textboxPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!");
                return;
            }

            string hashedPassword = GetSHA256(pass); // haszowanie hasła

            try
            {
                string connectionString = "server=127.0.0.1;port=3306;user=root;password=zaq1@WSX;database=casino_gym;SslMode=none;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // 🔹 Pobierz rolę użytkownika po poprawnym loginie i haśle
                    string query = "SELECT role FROM users WHERE LOWER(username) = @user AND password = @pass LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", user);
                        cmd.Parameters.AddWithValue("@pass", hashedPassword);

                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string role = reader["role"].ToString();
                            CurrentUserRole = role;

                            MessageBox.Show($"Zalogowano jako: {user} ({role})", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MainPage main = new MainPage();
                            main.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Niepoprawny login lub hasło!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // ================================
        // FUNKCJA HASHUJĄCA SHA256
        // ================================
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

        private void textboxPassword_TextChanged_1(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }
    }
}
