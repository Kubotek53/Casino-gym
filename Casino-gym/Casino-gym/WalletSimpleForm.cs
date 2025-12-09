using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;

namespace Casino_gym
{
    public partial class WalletSimpleForm : Form
    {
        private string currentUsername;

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
            LoadTransactionHistory();
        }

        // ======================
        // ŁADOWANIE HISTORII
        // ======================
        private void LoadTransactionHistory()
        {
            try
            {
                Database db = new Database();
                db.OpenConnection();

                string query = "SELECT amount AS 'Kwota', transaction_type AS 'Typ', timestamp AS 'Data' FROM transactions WHERE username=@username ORDER BY timestamp DESC";

                using (var cmd = new SQLiteCommand(query, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", currentUsername);

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewHistory.DataSource = dt;
                }

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania historii: " + ex.Message);
            }
        }

        // ======================
        // ŁADOWANIE SALDA
        // ======================
        private void LoadBalance()
        {
            try
            {
                Database db = new Database();
                db.OpenConnection();

                string query = "SELECT balance FROM users WHERE username=@username LIMIT 1";

                using (var cmd = new SQLiteCommand(query, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", currentUsername);

                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        lblBalance.Text = "Saldo: 0.00 $";
                    }
                    else
                    {
                        decimal balance = Convert.ToDecimal(result);
                        lblBalance.Text = $"Saldo: {balance:0.00} $";
                    }
                }

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania salda: " + ex.Message);
            }
        }

        // ======================
        // WPŁATA
        // ======================
        // ======================
        // WPŁATA
        // ======================
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Wprowadź poprawną kwotę!", "Błąd");
                return;
            }

            if (amount > 1000)
            {
                MessageBox.Show("Maksymalna jednorazowa wpłata to 1000 $!", "Limit");
                return;
            }

            UpdateBalance(amount, "Wpłata");
        }

        // ======================
        // WYPŁATA
        // ======================
        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Wprowadź poprawną kwotę!", "Błąd");
                return;
            }

            // Check if sufficient funds
            decimal currentBalance = GetCurrentBalance();

            if (amount > currentBalance)
            {
                MessageBox.Show("Brak wystarczających środków na koncie.", "Błąd");
                return;
            }

            UpdateBalance(-amount, "Wypłata");
        }

        private decimal GetCurrentBalance()
        {
             try
            {
                Database db = new Database();
                db.OpenConnection();
                string query = "SELECT balance FROM users WHERE username=@username LIMIT 1";
                using (var cmd = new SQLiteCommand(query, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", currentUsername);
                    object result = cmd.ExecuteScalar();
                    db.CloseConnection();
                    if (result != null && result != DBNull.Value) return Convert.ToDecimal(result);
                }
                db.CloseConnection();
            }
             catch { }
             return 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainPage main = new MainPage();
            main.Show();
            this.Hide();
        }

        // ======================
        // AKTUALIZACJA SALDA
        // ======================
        private void UpdateBalance(decimal amount, string transactionType)
        {
            try
            {
                Database db = new Database();
                db.OpenConnection();

                // Pobranie aktualnego salda
                string getQuery = "SELECT balance FROM users WHERE username=@username LIMIT 1";
                decimal currentBalance = 0;

                using (var cmd = new SQLiteCommand(getQuery, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", currentUsername);
                    var result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                        currentBalance = Convert.ToDecimal(result);
                }

                // Nowe saldo
                decimal newBalance = currentBalance + amount;

                // Zapis nowego salda
                string updateQuery = "UPDATE users SET balance=@balance WHERE username=@username";

                using (var cmd = new SQLiteCommand(updateQuery, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@balance", newBalance);
                    cmd.Parameters.AddWithValue("@username", currentUsername);
                    cmd.ExecuteNonQuery();
                }

                // Dodanie rekordu do historii transakcji
                string historyQuery = "INSERT INTO transactions (username, amount, transaction_type) VALUES (@username, @amount, @type)";
                using (var cmd = new SQLiteCommand(historyQuery, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", currentUsername);
                    cmd.Parameters.AddWithValue("@amount", amount); // Store the signed amount? Or just magnitude?
                    // Typically deposit is +, withdrawal is -, but maybe for "Amount" column usually magnitude is best if type is explicit.
                    // However, to keep math simple for "SUM" queries, signed is better.
                    // But looking at existing code... wait, existing code was: UpdateBalance(amount). 
                    // Let's stick to signed amount for logic consistency, or absolute?
                    // "Wpłata" -> +100. "Wypłata" -> -50.
                    // The history grid shows positive numbers usually? 
                    // Let's store signed amount for now as it maps directly to balance change.
                    // Wait, previous code: UpdateBalance(decimal amount).
                    // btnDeposit called UpdateBalance(amount).
                    // logic: newBalance = currentBalance + amount.
                    // So deposit amount is positive.
                    // withdrawal amount passed to UpdateBalance should be negative (-amount).
                    // So @amount will be negative.
                    
                    cmd.Parameters.AddWithValue("@type", transactionType);
                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();

                MessageBox.Show($"{transactionType} zakończona pomyślnie.");

                LoadBalance();
                LoadTransactionHistory(); // Reload history to show new item
                txtAmount.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas transakcji: " + ex.Message);
            }
        }
    }
}
