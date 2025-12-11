using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace Casino_gym
{
    public partial class Blackjack : Form
    {
        private List<Card> deck;
        private List<Card> playerHand;
        private List<Card> dealerHand;
        private Random rng = new Random();
        private bool roundInProgress = false;
        private string currentUser;

        public Blackjack(string username)
        {
            InitializeComponent();
            ResponsiveHelper.MakeResponsive(this);
            currentUser = username;
            InitGame();
        }

        private void InitGame()
        {
            LoadBalance();
            btnHit.Enabled = false;
            btnStand.Enabled = false;
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
                    numericBet.Maximum = (balance > 0) ? balance : 1;
                }
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd pobierania salda: " + ex.Message);
            }
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

        private void btnDeal_Click(object sender, EventArgs e)
        {
            decimal bet = numericBet.Value;
            
            if (bet <= 0)
            {
                MessageBox.Show("Nieprawidłowa stawka.");
                return;
            }
            
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
                 MessageBox.Show("Brak środków na koncie!");
                 return;
            }

            UpdateBalance(-bet, "Blackjack - Przegrana");
            StartRound((int)bet);
        }

        private void StartRound(int bet)
        {
            roundInProgress = true;
            btnDeal.Enabled = false;
            btnHit.Enabled = true;
            btnStand.Enabled = true;
            numericBet.Enabled = false;
            listBoxPlayer.Items.Clear();
            listBoxDealer.Items.Clear();

            deck = CreateDeck();
            Shuffle(deck);

            playerHand = new List<Card>();
            dealerHand = new List<Card>();

            playerHand.Add(DrawCard());
            dealerHand.Add(DrawCard());
            playerHand.Add(DrawCard());
            dealerHand.Add(DrawCard());

            UpdateHandsDisplay(showDealerHoleCard: false);

            int playerVal = HandValue(playerHand);
            int dealerVal = HandValue(dealerHand);
            if (playerVal == 21 || dealerVal == 21)
            {
                ResolveRound(bet, revealDealer: true);
            }
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            if (!roundInProgress) return;
            playerHand.Add(DrawCard());
            UpdateHandsDisplay(showDealerHoleCard: false);

            int playerVal = HandValue(playerHand);
            if (playerVal > 21)
            {
                EndRound(bust: true);
            }
            else if (playerVal == 21)
            {
                DealerPlay();
            }
        }

        private void btnStand_Click(object sender, EventArgs e)
        {
            if (!roundInProgress) return;
            DealerPlay();
        }

        private void DealerPlay()
        {
            while (HandValue(dealerHand) < 17)
            {
                dealerHand.Add(DrawCard());
            }
            ResolveRound((int)numericBet.Value, revealDealer: true);
        }

        private void ResolveRound(int bet, bool revealDealer)
        {
            UpdateHandsDisplay(showDealerHoleCard: revealDealer);

            int playerVal = HandValue(playerHand);
            int dealerVal = HandValue(dealerHand);

            string msg;
            decimal winnings = 0;

            if (playerVal > 21)
            {
                msg = $"Przegrałeś — przekroczyłeś 21 ({playerVal}). Strata ${bet}.";
            }
            else if (dealerVal > 21)
            {
                msg = $"Dealer przegrał ({dealerVal}). Wygrałeś ${bet}!";
                winnings = bet * 2; 
            }
            else if (playerVal == dealerVal)
            {
                msg = $"Remis ({playerVal}). Stawka zwrócona.";
                winnings = bet; 
            }
            else
            {
                bool playerBlackjack = (playerVal == 21 && playerHand.Count == 2);
                bool dealerBlackjack = (dealerVal == 21 && dealerHand.Count == 2);
                if (playerBlackjack && !dealerBlackjack)
                {
                    decimal win = Math.Ceiling(bet * 1.5m);
                    msg = $"Blackjack! Wygrałeś ${win}!";
                    winnings = bet + win;
                }
                else if (dealerBlackjack && !playerBlackjack)
                {
                    msg = $"Dealer ma Blackjack. Przegrana ${bet}.";
                }
                else if (playerVal > dealerVal)
                {
                    msg = $"Wygrałeś! {playerVal} vs {dealerVal}. Zysk ${bet}.";
                    winnings = bet * 2;
                }
                else
                {
                    msg = $"Przegrałeś {playerVal} vs {dealerVal}. Strata ${bet}.";
                }
            }

            if (winnings > 0)
            {
                UpdateBalance(winnings, "Blackjack - Wygrana");
            }
            else
            {
                LoadBalance();
            }

            MessageBox.Show(msg, "Wynik rundy");
            EndRoundCleanup();
        }

        private void EndRound(bool bust)
        {
            int bet = (int)numericBet.Value;
            UpdateHandsDisplay(showDealerHoleCard: true);
            MessageBox.Show($"Przekroczyłeś 21 — przegrana ${bet}.", "Bust");
            EndRoundCleanup();
            LoadBalance();
        }

        private void EndRoundCleanup()
        {
            roundInProgress = false;
            btnHit.Enabled = false;
            btnStand.Enabled = false;
            btnDeal.Enabled = true;
            numericBet.Enabled = true;
        }

        private void UpdateHandsDisplay(bool showDealerHoleCard)
        {
            listBoxPlayer.Items.Clear();
            foreach (var c in playerHand)
                listBoxPlayer.Items.Add(c.ToString());
            lblPlayerValue.Text = $"Wartość: {HandValue(playerHand)}";

            listBoxDealer.Items.Clear();
            for (int i = 0; i < dealerHand.Count; i++)
            {
                if (i == 0 && !showDealerHoleCard)
                {
                    listBoxDealer.Items.Add("(zakryta)");
                }
                else
                {
                    listBoxDealer.Items.Add(dealerHand[i].ToString());
                }
            }

            if (showDealerHoleCard)
                lblDealerValue.Text = $"Wartość: {HandValue(dealerHand)}";
            else
            {
                var visible = new List<Card> { dealerHand[1] };
                lblDealerValue.Text = $"Widoczne: {HandValue(visible)}";
            }
        }

        private List<Card> CreateDeck()
        {
            var suits = new[] { "♠", "♥", "♦", "♣" };
            var ranks = new[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            var d = new List<Card>();
            foreach (var s in suits)
            {
                foreach (var r in ranks)
                {
                    int value;
                    if (r == "A") value = 11;
                    else if (r == "J" || r == "Q" || r == "K") value = 10;
                    else value = int.Parse(r);
                    d.Add(new Card { Rank = r, Suit = s, Value = value });
                }
            }
            return d;
        }

        private void Shuffle(List<Card> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                var tmp = list[i];
                list[i] = list[j];
                list[j] = tmp;
            }
        }

        private Card DrawCard()
        {
            if (deck.Count == 0) deck = CreateDeck();
            var c = deck[0];
            deck.RemoveAt(0);
            return c;
        }

        private int HandValue(List<Card> hand)
        {
            if (hand == null || hand.Count == 0) return 0;
            int total = hand.Sum(c => c.Value);
            int aces = hand.Count(c => c.Rank == "A");
            while (total > 21 && aces > 0)
            {
                total -= 10;
                aces--;
            }
            return total;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nie można zresetować salda w trybie online. Użyj portfela, aby doładować konto.");
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            MainPage main = new MainPage();
            main.Show();
            this.Close();
        }
    }

    class Card
    {
        public string Rank { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return $"{Rank}{Suit}";
        }
    }
}