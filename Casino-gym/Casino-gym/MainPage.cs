using System;
using System.Windows.Forms;

namespace Casino_gym
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();

            // Dodajemy event do ładowania formularza
            this.Load += MainPage_Load;
        }

        // ================================
        // UKRYWANIE PRZYCISKU ADMINA
        // ================================
        private void MainPage_Load(object sender, EventArgs e)
        {
            // Jeśli użytkownik nie jest administratorem → ukryj przycisk
            btnManageUsers_Click1.Visible = (Login.CurrentUserRole == "Administrator");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        // ================================
        // GRY
        // ================================
        private void btnPoker_Click(object sender, EventArgs e)
        {
            poker pokerForm = new poker();
            pokerForm.Show();
            this.Close();
        }

        private void btnBlackJack_Click(object sender, EventArgs e)
        {
            Blackjack blackjackForm = new Blackjack(Login.CurrentLoggedUsername);
            blackjackForm.Show();
            this.Close();
        }

        private void btnSlots_Click(object sender, EventArgs e)
        {
            SlotsForm slotsForm = new SlotsForm(Login.CurrentLoggedUsername);
            slotsForm.Show();
            this.Close();
        }

        private void btnRoulette_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ruletka - Wkrótce dostępna!");
        }
    }
}
