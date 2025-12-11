using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Casino_gym
{
    public partial class UpperLower : Form
    {
        private string currentUser;
        private List<ULCard> deck; 
        private ULCard currentCard;
        private ULCard nextCard;
        private Random rng = new Random();
        private bool gameInProgress = false;

        public UpperLower(string username)
        {
            InitializeComponent();
            currentUser = username;
            LoadBalance();
            ResetGameUI();
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
                    lblBalance.Text = $"Saldo: ${balance:0.00}";


                    if (balance < nudBet.Value && balance > 0) nudBet.Value = balance;
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

                string getQuery = "SELECT balance FROM users WHERE username=@username LIMIT 1";
                decimal currentBalance = 0;
                using (var cmd = new SQLiteCommand(getQuery, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", currentUser);
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value) currentBalance = Convert.ToDecimal(result);
                }

                decimal newBalance = currentBalance + amount;
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
                    cmd.Parameters.AddWithValue("@amount", amount);
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



        private void btnDeal_Click(object sender, EventArgs e)
        {
            decimal bet = nudBet.Value;
            if (bet <= 0) return;


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

            if (bet > currentBalance)
            {
                MessageBox.Show("Brak wystarczających środków!");
                return;
            }

            UpdateBalance(-bet, "Upper Lower - Przegrana");

            StartRound();
        }

        private void StartRound()
        {
            gameInProgress = true;
            deck = CreateDeck();
            Shuffle(deck);

            currentCard = DrawCard();
            ShowCard(currentCard);

            btnDeal.Enabled = false;
            nudBet.Enabled = false;
            btnHigher.Enabled = true;
            btnLower.Enabled = true;
            lblResult.Text = "Wyższa czy Niższa?";
            lblResult.ForeColor = Color.White;
        }

        private void btnHigher_Click(object sender, EventArgs e)
        {
            ResolveRound(true);
        }

        private void btnLower_Click(object sender, EventArgs e)
        {
            ResolveRound(false);
        }

        private void ResolveRound(bool guessedHigher)
        {
            nextCard = DrawCard();


            string msg = "";
            decimal bet = nudBet.Value;
            decimal winnings = 0;
            bool win = false;
            bool push = false;

            if (nextCard.Value > currentCard.Value)
            {
                if (guessedHigher) win = true;
                else win = false;
            }
            else if (nextCard.Value < currentCard.Value)
            {
                if (guessedHigher) win = false;
                else win = true;
            }
            else 
            {
                push = true;
            }


            ShowCard(nextCard);

            if (push)
            {
                msg = $"Remis! ({currentCard} -> {nextCard}). Zwrot stawki.";
                winnings = bet;
            }
            else if (win)
            {
                msg = $"Wygrana! ({currentCard} -> {nextCard}).";
                winnings = bet * 2; 
            }
            else
            {
                msg = $"Przegrana. ({currentCard} -> {nextCard}).";
                winnings = 0;
            }

            if (winnings > 0)
            {
                UpdateBalance(winnings, "Upper Lower - Wygrana");
            }

            lblResult.Text = msg;
            if (win) lblResult.ForeColor = Color.Lime;
            else if (push) lblResult.ForeColor = Color.Gold;
            else lblResult.ForeColor = Color.Red;

            MessageBox.Show(msg);

            ResetGameUI();
            LoadBalance();
        }

        private void ResetGameUI()
        {
            gameInProgress = false;
            btnDeal.Enabled = true;
            nudBet.Enabled = true;
            btnHigher.Enabled = false;
            btnLower.Enabled = false;
        }

        private void ShowCard(ULCard c)
        {
            lblCard.Text = c.ToString();
            
            if (c.Suit == "♥" || c.Suit == "♦") lblCard.ForeColor = Color.Red;
            else lblCard.ForeColor = Color.Black;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            MainPage main = new MainPage();
            main.Show();
            this.Close();
        }



        private List<ULCard> CreateDeck()
        {
            var suits = new[] { "♠", "♥", "♦", "♣" };
            var ranks = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            var d = new List<ULCard>();


            foreach (var s in suits)
            {
                for (int i = 0; i < ranks.Length; i++)
                {
                    d.Add(new ULCard { Rank = ranks[i], Suit = s, Value = i + 2 });
                }
            }
            return d;
        }

        private void Shuffle(List<ULCard> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                var tmp = list[i];
                list[i] = list[j];
                list[j] = tmp;
            }
        }

        private ULCard DrawCard()
        {
            if (deck.Count == 0) deck = CreateDeck();
            var c = deck[0];
            deck.RemoveAt(0);
            return c;
        }

        private class ULCard
        {
            public string Rank { get; set; }
            public string Suit { get; set; }
            public int Value { get; set; }
            public override string ToString() => $"{Rank}{Suit}";
        }
    }
}
