using System;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Casino_gym
{
    public partial class Login : Form
    {
        public static string CurrentUserRole = "guest";
        public static string CurrentLoggedUsername = ""; 

        Database db = new Database();

        public Login()
        {
            InitializeComponent();
            ResponsiveHelper.MakeResponsive(this);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DoLogin();
        }

        private void Logowanie2_Click(object sender, EventArgs e)
        {
            DoLogin();
        }
        private void textboxUsername_TextChanged(object sender, EventArgs e)
        {
        }

        private void textboxPassword_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Hide();
        }

        private void btnSkipLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kontynuujesz jako gość.", "Tryb gościa");

            CurrentUserRole = "guest";
            CurrentLoggedUsername = "guest";

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
                db.OpenConnection();
                SQLiteConnection conn = db.GetConnection();

                string query = "SELECT role FROM users WHERE LOWER(username)=@user AND password=@pass LIMIT 1";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", hashedPassword);

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string role = reader["role"].ToString();

                        CurrentUserRole = role;
                        CurrentLoggedUsername = user;

                        MessageBox.Show($"Zalogowano jako: {user} ({role})");

                        MainPage main = new MainPage();
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("❌ Niepoprawny login lub hasło!");
                    }

                    reader.Close();
                }

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Błąd podczas logowania: " + ex.Message);
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
