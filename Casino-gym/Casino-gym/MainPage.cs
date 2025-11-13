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
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            // 🔹 Dostęp tylko dla administratora
            if (Login.CurrentUserRole == "Administrator")
            {
                UserManagement panel = new UserManagement();
                panel.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tylko administrator ma dostęp do tego panelu!");
            }
        }

        private void Wallet_Click(object sender, EventArgs e)
        {
            string currentUser = Login.CurrentUserRole;
            WalletForm walletForm = new WalletForm(currentUser);
            walletForm.Show();
            this.Hide();
        }
    }
}
