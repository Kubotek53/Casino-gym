using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BlackjackWinForms
{
    public partial class Form1 : Form
    {
        private List<Card> deck;
        private List<Card> playerHand;
        private List<Card> dealerHand;
        private Random rng = new Random();
        private int bankroll = 1000;
        private bool roundInProgress = false;

        public Form1()
        {
            InitializeComponent();
            InitGame();
        }

        private void InitGame()
        {
            lblBankroll.Text = $"Bankroll: ${bankroll}";
            numericBet.Minimum = 1;
            numericBet.Maximum = bankroll;
            btnHit.Enabled = false;
            btnStand.Enabled = false;
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            int bet = (int)numericBet.Value;
            if (bet <= 0 || bet > bankroll)
            {
                MessageBox.Show("Nieprawidłowa stawka.");
                return;
            }

            StartRound(bet);
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

            // Initial dealing
            playerHand.Add(DrawCard());
            dealerHand.Add(DrawCard());
            playerHand.Add(DrawCard());
            dealerHand.Add(DrawCard());

            UpdateHandsDisplay(showDealerHoleCard: false);

            // Check for blackjack
            int playerVal = HandValue(playerHand);
            int dealerVal = HandValue(dealerHand);
            if (playerVal == 21 || dealerVal == 21)
            {
                // End round immediately
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
                EndRound(false);
            }
            else if (playerVal == 21)
            {
                // Auto stand
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
            // Dealer reveals and hits until 17 or higher (soft 17 counts as 17 here)
            while (HandValue(dealerHand) < 17)
            {
                dealerHand.Add(DrawCard());
            }

            // determine result
            ResolveRound((int)numericBet.Value, revealDealer: true);
        }

        private void ResolveRound(int bet, bool revealDealer)
        {
            UpdateHandsDisplay(showDealerHoleCard: revealDealer);

            int playerVal = HandValue(playerHand);
            int dealerVal = HandValue(dealerHand);

            string msg;
            if (playerVal > 21)
            {
                msg = $"Przegrałeś — przekroczyłeś 21 ({playerVal}). Strata ${bet}.";
                bankroll -= bet;
            }
            else if (dealerVal > 21)
            {
                msg = $"Dealer przegrał ({dealerVal}). Wygrałeś ${bet}!";
                bankroll += bet;
            }
            else if (playerVal == dealerVal)
            {
                // push (tie)
                msg = $"Remis ({playerVal}). Stawka zwrócona.";
            }
            else
            {
                bool playerBlackjack = (playerVal == 21 && playerHand.Count == 2);
                bool dealerBlackjack = (dealerVal == 21 && dealerHand.Count == 2);
                if (playerBlackjack && !dealerBlackjack)
                {
                    int win = (int)Math.Ceiling(bet * 1.5);
                    msg = $"Blackjack! Wygrałeś ${win}!";
                    bankroll += win;
                }
                else if (dealerBlackjack && !playerBlackjack)
                {
                    msg = $"Dealer ma Blackjack. Przegrana ${bet}.";
                    bankroll -= bet;
                }
                else if (playerVal > dealerVal)
                {
                    msg = $"Wygrałeś! {playerVal} vs {dealerVal}. Zysk ${bet}.";
                    bankroll += bet;
                }
                else
                {
                    msg = $"Przegrałeś {playerVal} vs {dealerVal}. Strata ${bet}.";
                    bankroll -= bet;
                }
            }

            MessageBox.Show(msg, "Wynik rundy");

            EndRoundCleanup();
        }

        private void EndRound(bool playerBust)
        {
            // Called when player busts immediately
            int bet = (int)numericBet.Value;
            UpdateHandsDisplay(showDealerHoleCard: true);
            MessageBox.Show($"Przekroczyłeś 21 — przegrana ${bet}.", "Bust");
            bankroll -= bet;
            EndRoundCleanup();
        }

        private void EndRoundCleanup()
        {
            roundInProgress = false;
            lblBankroll.Text = $"Bankroll: ${bankroll}";
            btnHit.Enabled = false;
            btnStand.Enabled = false;
            btnDeal.Enabled = true;
            numericBet.Enabled = true;
            numericBet.Maximum = Math.Max(1, bankroll);
            if (bankroll <= 0)
            {
                MessageBox.Show("Koniec środków. Gra skończona.", "Koniec gry");
                btnDeal.Enabled = false;
                numericBet.Enabled = false;
            }
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
                // show only dealer's visible card value
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
                    if (r == "A") value = 11; // treat A as 11 initially
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
            // reduce A from 11 to 1 as necessary
            while (total > 21 && aces > 0)
            {
                total -= 10; // counting one ace as 1 instead of 11
                aces--;
            }
            return total;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            bankroll = 1000;
            InitGame();
            listBoxPlayer.Items.Clear();
            listBoxDealer.Items.Clear();
            lblPlayerValue.Text = "Wartość: 0";
            lblDealerValue.Text = "Wartość: 0";
            numericBet.Value = 10;
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
