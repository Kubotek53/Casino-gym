using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace Casino_gym
{
    public partial class SlotsForm : Form
    {
        private Random rnd = new Random();
        private List<Image> symbols = new List<Image>();

        private int reel1Index = 0;
        private int reel2Index = 0;
        private int reel3Index = 0;

        private int ticks = 0;
        private readonly int stopTicksReel1 = 20;
        private readonly int stopTicksReel2 = 40;
        private readonly int stopTicksReel3 = 60;

        private bool spinning = false;
        private string currentUser;

        public SlotsForm(string username)
        {
            InitializeComponent();
            currentUser = username;
            LoadSymbols();
            LoadSaldoToUI();

            if (symbols.Count > 0) UpdateReelImages();
        }

        private void LoadSymbols()
        {
            try
            {
                symbols.Clear();
                // Load images from file system to avoid incomplete Resources.resx issues
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                // Assuming standard project structure: bin/Debug -> ../../Resources
                // Adjusting path to go up two levels from bin/Debug (or Release)
                string resourcesPath = System.IO.Path.Combine(baseDir, "..", "..", "Resources");
                
                string[] files = { "sym1.png", "sym2.png", "sym3.png", "sym4.png", "sym5.png" };
                
                foreach (var file in files)
                {
                    string fullPath = System.IO.Path.Combine(resourcesPath, file);
                    if (System.IO.File.Exists(fullPath))
                    {
                        symbols.Add(Image.FromFile(fullPath));
                    }
                    else
                    {
                        // Fallback or skip
                         // Try checking direct path if running from source root? 
                         // No, BaseDirectory is reliable for running app.
                         // Let's just not add if missing to avoid crash, but show warning maybe?
                    }
                }
                
                if (symbols.Count == 0)
                {
                     // Fallback to colors or text if no images?
                     // Or assume at least one exists.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania obrazków: " + ex.Message);
            }
        }

        private void LoadSaldoToUI()
        {
            try
            {
                Database db = new Database();
                db.OpenConnection();
                string query = "SELECT balance FROM users WHERE username=@username LIMIT 1";
                using (var cmd = new SQLiteCommand(query, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", currentUser);
                    object result = cmd.ExecuteScalar();
                    decimal balance = (result != null && result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                    lblSaldo.Text = $"Saldo: ${balance:0.00}";
                }
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd pobierania salda: " + ex.Message);
            }
        }

        private void UpdateBalance(decimal amount, string transactionType)
        {
            try
            {
                Database db = new Database();
                db.OpenConnection();

                // Get current balance
                decimal currentBalance = 0;
                string getQuery = "SELECT balance FROM users WHERE username=@username LIMIT 1";
                using (var cmd = new SQLiteCommand(getQuery, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", currentUser);
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        currentBalance = Convert.ToDecimal(result);
                }

                decimal newBalance = currentBalance + amount;
                string updateQuery = "UPDATE users SET balance=@balance WHERE username=@username";
                using (var cmd = new SQLiteCommand(updateQuery, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@balance", newBalance);
                    cmd.Parameters.AddWithValue("@username", currentUser);
                    cmd.ExecuteNonQuery();
                }

                // Add transaction history
                string historyQuery = "INSERT INTO transactions (username, amount, transaction_type) VALUES (@username, @amount, @type)";
                using (var cmd = new SQLiteCommand(historyQuery, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", currentUser);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@type", transactionType);
                    cmd.ExecuteNonQuery();
                }

                db.CloseConnection();
                LoadSaldoToUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd aktualizacji salda: " + ex.Message);
            }
        }

        private void StartSpinning()
        {
            spinning = true;
            ticks = 0;
            reel1Index = rnd.Next(symbols.Count);
            reel2Index = rnd.Next(symbols.Count);
            reel3Index = rnd.Next(symbols.Count);
            timerSpin.Interval = 50;
            timerSpin.Start();
        }

        private void timerSpin_Tick(object sender, EventArgs e)
        {
            ticks++;
            if (ticks < stopTicksReel1)
            {
                reel1Index = (reel1Index + 1) % symbols.Count;
                pbReel1.Image = symbols[reel1Index];
            }
            if (ticks < stopTicksReel2)
            {
                reel2Index = (reel2Index + 1) % symbols.Count;
                pbReel2.Image = symbols[reel2Index];
            }
            if (ticks < stopTicksReel3)
            {
                reel3Index = (reel3Index + 1) % symbols.Count;
                pbReel3.Image = symbols[reel3Index];
            }
            if (ticks >= stopTicksReel3)
            {
                timerSpin.Stop();
                spinning = false;
                EvaluateResult();
            }
        }

        private void EvaluateResult()
        {
            decimal bet = nudBet.Value;
            decimal payout = 0;

            if (reel1Index == reel2Index && reel2Index == reel3Index)
            {
                payout = bet * 10;
                MessageBox.Show($"JACKPOT! Wygrywasz ${payout:0.00}!", "Wygrana", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (reel1Index == reel2Index || reel2Index == reel3Index || reel1Index == reel3Index)
            {
                payout = bet * 2;
                MessageBox.Show($"Para! Wygrywasz ${payout:0.00}!", "Wygrana", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                // Loss case
                MessageBox.Show($"Przegrałeś ${bet:0.00}", "Przegrana", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (payout > 0)
            {
                UpdateBalance(payout, "Slots - Wygrana");
            }
        }

        private void UpdateReelImages()
        {
            if (symbols.Count > 0)
            {
                pbReel1.Image = symbols[reel1Index];
                pbReel2.Image = symbols[reel2Index];
                pbReel3.Image = symbols[reel3Index];
            }
        }

        private void btnSpin_Click_1(object sender, EventArgs e)
        {
            if (spinning) return;

            decimal bet = nudBet.Value;

            if (bet <= 0)
            {
                MessageBox.Show("Stawka musi być większa niż 0!");
                return;
            }

            // Check balance
            Database db = new Database();
            db.OpenConnection();
            string query = "SELECT balance FROM users WHERE username=@username LIMIT 1";
            decimal currentBalance = 0;
            using (var cmd = new SQLiteCommand(query, db.GetConnection()))
            {
                 cmd.Parameters.AddWithValue("@username", currentUser);
                 var result = cmd.ExecuteScalar();
                 if (result != null && result != DBNull.Value) currentBalance = Convert.ToDecimal(result);
            }
            db.CloseConnection();

            if (currentBalance < bet)
            {
                MessageBox.Show("Brak wystarczających środków.");
                return;
            }

            UpdateBalance(-bet, "Slots - Przegrana");
            StartSpinning();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainPage main = new MainPage();
            main.Show();
            this.Close();
        }

        private void nudBet_ValueChanged(object sender, EventArgs e) { }
        private void lblSaldo_Click(object sender, EventArgs e) { }
        private void pbReel3_Click(object sender, EventArgs e) { }
    }
}