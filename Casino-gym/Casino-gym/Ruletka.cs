using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Casino_gym
{
    public partial class Ruletka : Form
    {
        private string currentUser;
        private Random rng = new Random();

        private int[] redNumbers = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };

        private Dictionary<string, decimal> currentBets = new Dictionary<string, decimal>();

        public Ruletka(string username)
        {
            InitializeComponent();
            currentUser = username;
            LoadBalance();
            InitCasinoTable();
        }

        private void LoadBalance()
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
                    lblBankroll.Text = $"Bankroll: ${balance:0.00}";
                }
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd pobierania salda: " + ex.Message);
            }
        }

        private void InitCasinoTable()
        {
            pnlBoard.Controls.Clear();
            pnlBoard.BackColor = Color.DarkGreen;

            int btnSize = 50;
            int padding = 5;
            int startX = 60; 
            int startY = 10;

            Button btnZero = CreateBetButton("0", "0", Color.Green, 0, startY, 50, btnSize * 3 + padding * 2);
            pnlBoard.Controls.Add(btnZero);

            for (int i = 1; i <= 36; i++)
            {
                int col = (i - 1) / 3;
                int row = 2 - ((i - 1) % 3); 

                int x = startX + col * (btnSize + padding);
                int y = startY + row * (btnSize + padding);

                Color bg = IsRed(i) ? Color.Red : Color.Black;
                Button btn = CreateBetButton(i.ToString(), i.ToString(), bg, x, y, btnSize, btnSize);
                pnlBoard.Controls.Add(btn);
            }

            int sideBetY = startY + 3 * (btnSize + padding) + 10;
            int halfWidth = (12 * (btnSize + padding)) / 2; 
            
            int sideBtnWidth = 100;

            pnlBoard.Controls.Add(CreateBetButton("Red", "CZERWONE", Color.Red, startX, sideBetY, sideBtnWidth, 40));
            pnlBoard.Controls.Add(CreateBetButton("Black", "CZARNE", Color.Black, startX + sideBtnWidth + padding, sideBetY, sideBtnWidth, 40));
            pnlBoard.Controls.Add(CreateBetButton("Even", "PARZYSTE", Color.FromArgb(64, 64, 64), startX + (sideBtnWidth + padding) * 2, sideBetY, sideBtnWidth, 40));
            pnlBoard.Controls.Add(CreateBetButton("Odd", "N.PARZYSTE", Color.FromArgb(64, 64, 64), startX + (sideBtnWidth + padding) * 3, sideBetY, sideBtnWidth, 40));
        }

        private Button CreateBetButton(string tag, string text, Color color, int x, int y, int w, int h)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Tag = tag;
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.White;
            btn.Font = new Font("Arial", 10, FontStyle.Bold);
            btn.Location = new Point(x, y);
            btn.Size = new Size(w, h);
            btn.Click += BetButton_Click;
            return btn;
        }

        private void BetButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            decimal amount = numericBet.Value;
            string key = btn.Tag.ToString();

            if (currentBets.ContainsKey(key))
            {
                currentBets[key] += amount;
            }
            else
            {
                currentBets[key] = amount;
            }

            UpdateTotalBetDisplay();
            
            string baseText = GetBaseText(key);
            btn.Text = $"{baseText}\n${currentBets[key]}";
        }

        private string GetBaseText(string key)
        {
            if (key == "Red") return "CZERWONE";
            if (key == "Black") return "CZARNE";
            if (key == "Even") return "PARZYSTE";
            if (key == "Odd") return "N.PARZYSTE";
            return key; 
        }

        private void UpdateTotalBetDisplay()
        {
            decimal total = currentBets.Values.Sum();
            lblTotalBet.Text = $"Aktualny zakład: ${total:0.00}";
        }

        private void btnSpin_Click(object sender, EventArgs e)
        {
            decimal totalBet = currentBets.Values.Sum();

            if (totalBet <= 0)
            {
                MessageBox.Show("Proszę obstawić zakład!");
                return;
            }

            decimal balance = GetBalance();
            if (totalBet > balance)
            {
                MessageBox.Show("Brak wystarczających środków na pokrycie wszystkich zakładów!");
                return;
            }

            UpdateBalance(-totalBet, "Ruletka - Przegrana");

            int winningNumber = rng.Next(0, 37); 
            bool isRed = IsRed(winningNumber);
            bool isBlack = !isRed && winningNumber != 0;
            bool isEven = (winningNumber != 0 && winningNumber % 2 == 0);
            bool isOdd = (winningNumber != 0 && winningNumber % 2 != 0);

            decimal totalWin = 0;

            foreach (var bet in currentBets)
            {
                string choice = bet.Key;
                decimal val = bet.Value;
                decimal payout = 0;

                if (choice == "Red" && isRed) payout = val * 2;
                else if (choice == "Black" && isBlack) payout = val * 2;
                else if (choice == "Even" && isEven) payout = val * 2;
                else if (choice == "Odd" && isOdd) payout = val * 2;
                else
                {
                    if (int.TryParse(choice, out int num))
                    {
                        if (num == winningNumber) payout = val * 36;
                    }
                }

                totalWin += payout;
            }

            lblResultNumber.Text = winningNumber.ToString();
            if (winningNumber == 0) lblResultNumber.ForeColor = Color.Green;
            else if (isRed) lblResultNumber.ForeColor = Color.Red;
            else lblResultNumber.ForeColor = Color.Black; 
            if (!isRed && winningNumber != 0) lblResultNumber.ForeColor = Color.White; 

            lblResult.Visible = true;
            if (totalWin > 0)
            {
                UpdateBalance(totalWin, "Ruletka - Wygrana");
                lblResult.Text = $"Wygrałeś ${totalWin}!";
                lblResult.ForeColor = Color.Lime;
            }
            else
            {
                lblResult.Text = "Przegrana.";
                lblResult.ForeColor = Color.Red;
            }

            ClearBets();
        }

        private void ClearBets()
        {
            currentBets.Clear();
            UpdateTotalBetDisplay();
            foreach (Control c in pnlBoard.Controls)
            {
                if (c is Button btn)
                {
                    btn.Text = GetBaseText(btn.Tag.ToString());
                }
            }
        }

        private decimal GetBalance()
        {
            decimal currentBalance = 0;
            try
            {
                Database db = new Database();
                db.OpenConnection();
                string getQuery = "SELECT balance FROM users WHERE username=@username LIMIT 1";
                using (var cmd = new SQLiteCommand(getQuery, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", currentUser);
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        currentBalance = Convert.ToDecimal(result);
                }
                db.CloseConnection();
            }
            catch { }
            return currentBalance;
        }

        private void UpdateBalance(decimal change, string transactionType)
        {
            try
            {
                Database db = new Database();
                db.OpenConnection();

                decimal currentBalance = 0;
                string getQuery = "SELECT balance FROM users WHERE username=@username LIMIT 1";
                using (var cmd = new SQLiteCommand(getQuery, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", currentUser);
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        currentBalance = Convert.ToDecimal(result);
                }

                decimal newBalance = currentBalance + change;
                string updateQuery = "UPDATE users SET balance=@balance WHERE username=@username";
                using (var cmd = new SQLiteCommand(updateQuery, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@balance", newBalance);
                    cmd.Parameters.AddWithValue("@username", currentUser);
                    cmd.ExecuteNonQuery();
                }

                string historyQuery = "INSERT INTO transactions (username, amount, transaction_type) VALUES (@username, @amount, @type)";
                using (var cmd = new SQLiteCommand(historyQuery, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", currentUser);
                    cmd.Parameters.AddWithValue("@amount", change);
                    cmd.Parameters.AddWithValue("@type", transactionType);
                    cmd.ExecuteNonQuery();
                }

                db.CloseConnection();
                LoadBalance(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd aktualizacji salda: " + ex.Message);
            }
        }

        private bool IsRed(int number)
        {
            return redNumbers.Contains(number);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            MainPage main = new MainPage();
            main.Show();
            this.Close();
        }
    }
}
