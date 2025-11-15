using System;
using System.Windows.Forms;

namespace Casino_gym
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit(); // NATYCHMIAST zamyka aplikację
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // ================================
        // PANEL ADMINA
        // ================================
        private void button1_Click(object sender, EventArgs e)
        {
            if (Login.CurrentUserRole == "Administrator")
            {
                UserManagement panel = new UserManagement();
                panel.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tylko administrator ma dostęp do tego panelu!");
            }
        }

        // ================================
        // PORTFEL
        // ================================
        private void Wallet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Login.CurrentLoggedUsername))
            {
                MessageBox.Show("Błąd! Brak nazwy użytkownika. Zaloguj się ponownie.");
                return;
            }

            WalletSimpleForm wallet = new WalletSimpleForm(Login.CurrentLoggedUsername);
            wallet.Show();
            this.Close();
        }
    }
}
