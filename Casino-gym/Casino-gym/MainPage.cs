using System;
using System.Windows.Forms;

namespace Casino_gym
{
    public partial class MainPage : Form
    {
        private bool isLoggingOut = false;
        private bool isNavigatingToGame = false;

        public MainPage()
        {
            InitializeComponent();
            ResponsiveHelper.MakeResponsive(this);

            this.Load += MainPage_Load;
            this.FormClosed += MainForm_FormClosed;
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            btnManageUsers_Click1.Visible = (Login.CurrentUserRole == "Administrator");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            isLoggingOut = true;
            
            bool found = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form is Login)
                {
                    form.Show();
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Login login = new Login();
                login.Show();
            }

            this.Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isLoggingOut && !isNavigatingToGame)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Login.CurrentUserRole == "Administrator")
            {
                isNavigatingToGame = true;
                UserManagement panel = new UserManagement();
                panel.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tylko administrator ma dostęp do tego panelu!");
            }
        }

        private void Wallet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Login.CurrentLoggedUsername))
            {
                MessageBox.Show("Błąd! Brak nazwy użytkownika. Zaloguj się ponownie.");
                return;
            }

            isNavigatingToGame = true;
            WalletSimpleForm wallet = new WalletSimpleForm(Login.CurrentLoggedUsername);
            wallet.Show();
            this.Close();
        }

        private void btnPoker_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gra chwilowo nie dostępna :(");
        }

        private void btnBlackJack_Click(object sender, EventArgs e)
        {
            isNavigatingToGame = true;
            Blackjack blackjackForm = new Blackjack(Login.CurrentLoggedUsername);
            blackjackForm.Show();
            this.Close();
        }

        private void btnSlots_Click(object sender, EventArgs e)
        {
            isNavigatingToGame = true;
            SlotsForm slotsForm = new SlotsForm(Login.CurrentLoggedUsername);
            slotsForm.Show();
            this.Close();
        }

        private void btnRoulette_Click(object sender, EventArgs e)
        {
            isNavigatingToGame = true;
            Ruletka rouletteForm = new Ruletka(Login.CurrentLoggedUsername);
            rouletteForm.Show();
            this.Close();
        }

        private void btnUpperLower_Click(object sender, EventArgs e)
        {
            isNavigatingToGame = true;
            UpperLower game = new UpperLower(Login.CurrentLoggedUsername);
            game.Show();
            this.Close();
        }
    }
}
