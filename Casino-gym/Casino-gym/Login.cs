using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Casino_gym
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        // ================================
        // ZDARZENIA FORMULARZA
        // ================================
        private void Login_Load(object sender, EventArgs e)
        {
            // Tutaj możesz dodać np. inicjalizację połączenia z bazą danych
        }

        private void textboxUsername_TextChanged(object sender, EventArgs e)
        {
            // opcjonalne
        }

        private void textboxPassword_TextChanged(object sender, EventArgs e)
        {
            // opcjonalne
        }

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
            MainPage main = new MainPage();
            main.Show();
            this.Hide();
        }

        // ================================
        // LOGIKA LOGOWANIA
        // ================================
        private void DoLogin()
        {
            string user = textboxUsername.Text.Trim();
            string pass = textboxPassword.Text.Trim();

            if (user == "" || pass == "")
            {
                MessageBox.Show("Uzupełnij wszystkie pola!");
                return;
            }

            string hashedPassword = GetSHA256(pass); // 🔹 haszowanie hasła (TAK SAMO jak w Register.cs)

            try
            {
                Database db = new Database();
                db.OpenConnection();

                string query = "SELECT * FROM users WHERE username = @user AND password = @pass";
                MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", hashedPassword);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Close();
                    db.CloseConnection();

                    MessageBox.Show("Zalogowano pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainPage main = new MainPage();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    reader.Close();
                    db.CloseConnection();
                    MessageBox.Show("Niepoprawny login lub hasło!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void textboxPassword_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
