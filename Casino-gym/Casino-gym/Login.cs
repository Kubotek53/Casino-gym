using System;
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
            // lub wczytywanie konfiguracji
        }

        private void textboxUsername_TextChanged(object sender, EventArgs e)
        {
            // Zdarzenie zmiany tekstu w polu loginu (opcjonalne)
        }

        private void textboxPassword_TextChanged(object sender, EventArgs e)
        {
            // Zdarzenie zmiany tekstu w polu hasła (opcjonalne)
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

        // 🔹 NOWY PRZYCISK — Kontynuuj bez logowania
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

            // Na początek prosty test — bez bazy danych:
            if (user == "admin" && pass == "1234")
            {
                MessageBox.Show("Zalogowano pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MainPage main = new MainPage();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Niepoprawny login lub hasło!", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
