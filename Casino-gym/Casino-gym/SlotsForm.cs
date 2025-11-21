using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Casino_gym
{
    public partial class SlotsForm : Form
    {
        // Zmienne gry
        private Random rnd = new Random();
        private List<Image> symbols = new List<Image>();

        // Indeksy aktualnie wyświetlanych obrazków
        private int reel1Index = 0;
        private int reel2Index = 0;
        private int reel3Index = 0;

        // Zmienne do sterowania czasem (animacją)
        private int ticks = 0;
        private readonly int stopTicksReel1 = 20;
        private readonly int stopTicksReel2 = 40;
        private readonly int stopTicksReel3 = 60;

        private bool spinning = false;

        public SlotsForm()
        {
            InitializeComponent();
            LoadSymbols();
            LoadSaldoToUI();

            // Ustawienie startowych obrazków
            if (symbols.Count > 0) UpdateReelImages();
        }

        private void LoadSymbols()
        {
            try
            {
                symbols.Clear();
                // Upewnij się, że te obrazki istnieją w Resources!
                symbols.Add(Properties.Resources.sym1);
                symbols.Add(Properties.Resources.sym2);
                symbols.Add(Properties.Resources.sym3);
                symbols.Add(Properties.Resources.sym4);
                symbols.Add(Properties.Resources.sym5);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: Brak obrazków w Resources. " + ex.Message);
            }
        }

        private void LoadSaldoToUI()
        {
            decimal saldo = Properties.Settings.Default.Saldo;
            lblSaldo.Text = $"Saldo: {saldo:C}";
        }

        private void SaveSaldo(decimal newSaldo)
        {
            Properties.Settings.Default.Saldo = newSaldo;
            Properties.Settings.Default.Save();
            LoadSaldoToUI();
        }

        private void StartSpinning()
        {
            spinning = true;
            ticks = 0;

            // Losowy start
            reel1Index = rnd.Next(symbols.Count);
            reel2Index = rnd.Next(symbols.Count);
            reel3Index = rnd.Next(symbols.Count);

            timerSpin.Interval = 50;
            timerSpin.Start();
        }

        private void timerSpin_Tick(object sender, EventArgs e)
        {
            ticks++;

            // Animacja bębnów
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

            // Koniec gry
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

            // Logika wygranych
            if (reel1Index == reel2Index && reel2Index == reel3Index)
            {
                payout = bet * 10;
                MessageBox.Show($"JACKPOT! Wygrywasz {payout:C}!");
            }
            else if (reel1Index == reel2Index || reel2Index == reel3Index || reel1Index == reel3Index)
            {
                payout = bet * 2;
                MessageBox.Show($"Para! Wygrywasz {payout:C}!");
            }

            if (payout > 0)
            {
                decimal currentSaldo = Properties.Settings.Default.Saldo;
                SaveSaldo(currentSaldo + payout);
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

        // --- PONIŻEJ METODY PODPIĘTE PRZEZ DESIGNERA ---

        // To jest ta metoda, którą klika Twój przycisk (z końcówką _1)
        private void btnSpin_Click_1(object sender, EventArgs e)
        {
            if (spinning) return;

            decimal saldo = Properties.Settings.Default.Saldo;
            decimal bet = nudBet.Value;

            if (bet <= 0)
            {
                MessageBox.Show("Stawka musi być większa niż 0!");
                return;
            }

            if (saldo < bet)
            {
                MessageBox.Show("Brak wystarczających środków.");
                return;
            }

            saldo -= bet;
            SaveSaldo(saldo);
            StartSpinning();
        }

        // Te metody muszą zostać puste, bo Designer ich używa
        // Jeśli je usuniesz, formularz wyrzuci błąd
        private void nudBet_ValueChanged(object sender, EventArgs e) { }
        private void lblSaldo_Click(object sender, EventArgs e) { }
        private void pbReel3_Click(object sender, EventArgs e) { }
    }
}