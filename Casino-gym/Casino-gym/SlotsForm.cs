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
        
        // Indeksy aktualnie wyświetlanych obrazków (0-4)
        private int reel1Index = 0;
        private int reel2Index = 0;
        private int reel3Index = 0;

        // Zmienne do sterowania czasem (animacją)
        private int ticks = 0;
        private readonly int stopTicksReel1 = 20; // Kiedy staje 1 bęben
        private readonly int stopTicksReel2 = 40; // Kiedy staje 2 bęben
        private readonly int stopTicksReel3 = 60; // Kiedy staje 3 bęben (koniec)
        
        private bool spinning = false;

        public SlotsForm()
        {
            InitializeComponent();
            LoadSymbols();
            LoadSaldoToUI();

            // Ustawienie startowych obrazków (jeśli są dostępne)
            if (symbols.Count > 0)
            {
                UpdateReelImages();
            }
        }

        private void LoadSymbols()
        {
            try
            {
                symbols.Clear();
                // WAŻNE: Upewnij się, że masz te pliki w Resources.resx!
                // Jeśli nazwałeś je inaczej, popraw tutaj nazwy (np. Resources.cherry)
                symbols.Add(Properties.Resources.sym1);
                symbols.Add(Properties.Resources.sym2);
                symbols.Add(Properties.Resources.sym3);
                symbols.Add(Properties.Resources.sym4);
                symbols.Add(Properties.Resources.sym5);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania symboli! Sprawdź Resources.\n" + ex.Message);
            }
        }

        private void LoadSaldoToUI()
        {
            // Upewnij się, że w Project -> Properties -> Settings masz ustawienie 'Saldo' (typ decimal)
            decimal saldo = Properties.Settings.Default.Saldo;
            lblSaldo.Text = $"Saldo: {saldo:C}"; // Formatowanie walutowe
        }

        private void SaveSaldo(decimal newSaldo)
        {
            Properties.Settings.Default.Saldo = newSaldo;
            Properties.Settings.Default.Save();
            LoadSaldoToUI();
        }

        private void btnSpin_Click(object sender, EventArgs e)
        {
            if (spinning) return; // Blokada podwójnego kliknięcia

            decimal saldo = Properties.Settings.Default.Saldo;
            decimal bet = nudBet.Value; // Upewnij się, że masz kontrolkę NumericUpDown o nazwie nudBet

            if (bet <= 0)
            {
                MessageBox.Show("Stawka musi być większa niż 0!");
                return;
            }

            if (saldo < bet)
            {
                MessageBox.Show("Brak wystarczających środków na koncie.");
                return;
            }

            // Pobranie opłaty za spin
            saldo -= bet;
            SaveSaldo(saldo);

            // Start animacji
            StartSpinning();
        }

        private void StartSpinning()
        {
            spinning = true;
            ticks = 0;
            
            // Losujemy początkowe przesunięcia, żeby bębny nie startowały zawsze z tego samego miejsca
            reel1Index = rnd.Next(symbols.Count);
            reel2Index = rnd.Next(symbols.Count);
            reel3Index = rnd.Next(symbols.Count);

            timerSpin.Interval = 50; // Prędkość obrotu (im mniej tym szybciej)
            timerSpin.Start();
        }

        private void timerSpin_Tick(object sender, EventArgs e)
        {
            ticks++;

            // --- LOGIKA ANIMACJI ---
            
            // Bęben 1 kręci się dopóki ticks jest mniejsze niż limit
            if (ticks < stopTicksReel1)
            {
                reel1Index = (reel1Index + 1) % symbols.Count; // Przesuń o jeden symbol
                pbReel1.Image = symbols[reel1Index];
            }

            // Bęben 2 kręci się dłużej
            if (ticks < stopTicksReel2)
            {
                reel2Index = (reel2Index + 1) % symbols.Count;
                pbReel2.Image = symbols[reel2Index];
            }

            // Bęben 3 kręci się najdłużej
            if (ticks < stopTicksReel3)
            {
                reel3Index = (reel3Index + 1) % symbols.Count;
                pbReel3.Image = symbols[reel3Index];
            }

            // --- KONIEC GRY ---
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

            // Sprawdzamy wygraną na podstawie indeksów
            // Indeksy odpowiadają konkretnym obrazkom z listy symbols
            
            if (reel1Index == reel2Index && reel2Index == reel3Index)
            {
                // JACKPOT: 3 takie same
                payout = bet * 10; 
                MessageBox.Show($"JACKPOT! Wygrywasz {payout:C}!");
            }
            else if (reel1Index == reel2Index || reel2Index == reel3Index || reel1Index == reel3Index)
            {
                // Para: 2 takie same
                payout = bet * 2;
                MessageBox.Show($"Dobra robota! Para. Wygrywasz {payout:C}!");
            }
            else
            {
                // Przegrana
                // Opcjonalnie: jakiś dźwięk przegranej
            }

            if (payout > 0)
            {
                decimal currentSaldo = Properties.Settings.Default.Saldo;
                SaveSaldo(currentSaldo + payout);
            }
        }

        // Metoda pomocnicza do odświeżenia obrazków (np. przy starcie)
        private void UpdateReelImages()
        {
            if (symbols.Count > 0)
            {
                pbReel1.Image = symbols[reel1Index];
                pbReel2.Image = symbols[reel2Index];
                pbReel3.Image = symbols[reel3Index];
            }
        }

        // Przycisk "Dodaj monety" (cheat button do testów)
        private void btnAddCoins_Click(object sender, EventArgs e)
        {
            decimal currentSaldo = Properties.Settings.Default.Saldo;
            SaveSaldo(currentSaldo + 500);
        }

        private void btnSpin_Click_1(object sender, EventArgs e)
        {

        }

        private void nudBet_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblSaldo_Click(object sender, EventArgs e)
        {

        }

        private void pbReel3_Click(object sender, EventArgs e)
        {

        }
    }
}