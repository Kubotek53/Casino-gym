using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Casino_gym
{
    public partial class WalletSimpleForm : Form
    {
        private string currentUsername;
        private string connectionString =
            "server=127.0.0.1;port=3306;user=root;password=zaq1@WSX;database=casino_gym;SslMode=none;";

        public WalletSimpleForm(string username)
        {
            InitializeComponent();
            currentUsername = username;

            if (string.IsNullOrEmpty(currentUsername))
            {
                MessageBox.Show("BŁĄD! Użytkownik nie został poprawnie przekazany!", "Błąd");
                return;
            }

            LoadBalance();
        }

        // ======================
        // ŁADOWANIE SALDA
        // ======================
        private void LoadBalance()
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT balance FROM users WHERE username=@username LIMIT 1";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", currentUsername);

                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                        {
                            lblBalance.Text = "Saldo: 0.00 zł";
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

        // ======================
        // Wpłata
        // ======================
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Wprowadź poprawną kwotę!", "Błąd");
                return;
            }

            UpdateBalance(amount);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            MainPage main = new MainPage();
            main.Show();
            this.Hide();
        }


        // ======================
        // Aktualizacja salda
        // ======================
        private void UpdateBalance(decimal amount)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Pobranie aktualnego salda
                    string getQuery = "SELECT balance FROM users WHERE username=@username LIMIT 1";
                    decimal currentBalance = 0;

                    using (var cmd = new MySqlCommand(getQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", currentUsername);
                        currentBalance = Convert.ToDecimal(cmd.ExecuteScalar());
                    }

                    // Wyliczenie nowego salda
                    decimal newBalance = currentBalance + amount;

                    // Zapis
                    string updateQuery = "UPDATE users SET balance=@balance WHERE username=@username";

                    using (var cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@balance", newBalance);
                        cmd.Parameters.AddWithValue("@username", currentUsername);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Wpłata zakończona pomyślnie.");

                    LoadBalance();
                    txtAmount.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas wpłaty: " + ex.Message);
            }
        }
    }
}
