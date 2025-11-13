using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Casino_gym
{
    public partial class WalletForm : Form
    {
        private string currentUsername;
        private readonly string connectionString = "server=127.0.0.1;port=3306;user=root;password=zaq1@WSX;database=casino_gym;SslMode=none;";

        public WalletForm(string username)
        {
            InitializeComponent();
            currentUsername = username;
            LoadBalance();
        }

        private void LoadBalance()
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT balance FROM users WHERE username = @username LIMIT 1";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", currentUsername);
                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                        {
                            MessageBox.Show($"Nie znaleziono użytkownika: {currentUsername}");
                            lblBalance.Text = "Saldo: 0,00 zł";
                        }
                        else
                        {
                            decimal balance = Convert.ToDecimal(result);
                            lblBalance.Text = $"Saldo: {balance:0.00} zł";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania salda: " + ex.Message);
            }
        }

        private void UpdateBalance(decimal amountChange)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string getBalanceQuery = "SELECT balance FROM users WHERE username = @username LIMIT 1";
                    decimal currentBalance = 0;

                    using (var cmd = new MySqlCommand(getBalanceQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", currentUsername);
                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                        {
                            MessageBox.Show($"Nie znaleziono użytkownika: {currentUsername}");
                            return;
                        }

                        currentBalance = Convert.ToDecimal(result);
                    }

                    decimal newBalance = currentBalance + amountChange;

                    if (newBalance < 0)
                    {
                        MessageBox.Show("Brak wystarczających środków.");
                        return;
                    }

                    string updateQuery = "UPDATE users SET balance = @balance WHERE username = @username";
                    using (var cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@balance", newBalance);
                        cmd.Parameters.AddWithValue("@username", currentUsername);

                        int rows = cmd.ExecuteNonQuery(); // liczba zmienionych wierszy

                        if (rows == 0)
                        {
                            MessageBox.Show($"⚠️ Nie zaktualizowano żadnego rekordu! Użytkownik: '{currentUsername}' nie istnieje.");
                            return;
                        }
                    }

                    MessageBox.Show($"✅ Saldo zaktualizowane!\nNowe saldo: {newBalance:0.00} zł\nUżytkownik: {currentUsername}");
                    LoadBalance();
                    txtAmount.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas aktualizacji salda: " + ex.Message);
            }
        }


        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amount) && amount > 0)
                UpdateBalance(amount);
            else
                MessageBox.Show("Podaj poprawną kwotę!");
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amount) && amount > 0)
                UpdateBalance(-amount);
            else
                MessageBox.Show("Podaj poprawną kwotę!");
        }

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Hide();
        }
    }
}
