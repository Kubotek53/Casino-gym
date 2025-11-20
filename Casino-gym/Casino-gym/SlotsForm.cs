using Casino_gym;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casino_gym
{
    public partial class SlotsForm : Form
    {
        public SlotsForm()
        {
            InitializeComponent();
        }
    }
}
SlotsForm slots = new SlotsForm();
slots.Show();

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public partial class SlotsForm : Form
{
    private Random rnd = new Random();
    private List<Image> symbols;
    private int reel1Index = 0, reel2Index = 0, reel3Index = 0;
    private int ticks = 0;
    private int stopTicksReel1 = 20, stopTicksReel2 = 32, stopTicksReel3 = 44;
    private bool spinning = false;

    public SlotsForm()
    {
        InitializeComponent();
        LoadSymbols();
        LoadSaldoToUI();
        // ustawienie domyślnych obrazków
        if (symbols.Count > 0)
        {
            pbReel1.Image = symbols[0];
            pbReel2.Image = symbols[0];
            pbReel3.Image = symbols[0];
        }
    }

    private void LoadSymbols()
    {
        symbols = new List<Image>();
        // Przykład: jeśli dodałeś do Resources nazwy sym1..sym5
        symbols.Add(Properties.Resources.sym1);
        symbols.Add(Properties.Resources.sym2);
        symbols.Add(Properties.Resources.sym3);
        symbols.Add(Properties.Resources.sym4);
        symbols.Add(Properties.Resources.sym5);
        // Dodaj lub zmień zgodnie ze swoimi zasobami
    }

    private void LoadSaldoToUI()
    {
        // Zakładam, że w Settings masz "Saldo" typu decimal lub int
        decimal saldo = Properties.Settings.Default.Saldo;
        lblSaldo.Text = $"Saldo: {saldo}";
    }

    private void SaveSaldo(decimal newSaldo)
    {
        Properties.Settings.Default.Saldo = newSaldo;
        Properties.Settings.Default.Save();
        lblSaldo.Text = $"Saldo: {newSaldo}";
    }

    private void btnSpin_Click(object sender, EventArgs e)
    {
        if (spinning) return;

        decimal saldo = Properties.Settings.Default.Saldo;
        decimal bet = nudBet.Value;

        if (bet <= 0)
        {
            MessageBox.Show("Ustaw stawkę większą niż 0.");
            return;
        }

        if (saldo < bet)
        {
            MessageBox.Show("Masz za mało środków.");
            return;
        }

        // Pobierz stawkę
        saldo -= bet;
        SaveSaldo(saldo);

        // Reset licznika i uruchom animację
        ticks = 0;
        spinning = true;
        timerSpin.Interval = 80; // szybkość animacji
        timerSpin.Start();
    }

    private void timerSpin_Tick(object sender, EventArgs e)
    {
        ticks++;

        // Losujemy nowy obrazek dla każdego bębna (zmiana co tick)
        reel1Index = (reel1Index + rnd.Next(1, symbols.Count)) % symbols.Count;
        pbReel1.Image = symbols[reel1Index];

        reel2Index = (reel2Index + rnd.Next(1, symbols.Count)) % symbols.Count;
        pbReel2.Image = symbols[reel2Index];

        reel3Index = (reel3Index + rnd.Next(1, symbols.Count)) % symbols.Count;
        pbReel3.Image = symbols[reel3Index];

        // Zatrzymujemy kolejne bębny po określonej liczbie ticków
        if (ticks >= stopTicksReel1 && ticks < stopTicksReel2)
        {
            // zatrzymaj reel1 na losowym symbolu (fix)
            // aby "udawać" stop, nie losujemy już reel1
            // ale żeby wyglądało naturalnie, ustaw konkretny index
            // (tu nic dodatkowego; po prostu nie zmieniamy reel1 później)
        }

        if (ticks >= stopTicksReel2 && ticks < stopTicksReel3)
        {
            // podobnie dla reel2
        }

        if (ticks >= stopTicksReel3)
        {
            // Koniec obrotu
            timerSpin.Stop();
            spinning = false;
            EvaluateResult();
        }
    }

    private void EvaluateResult()
    {
        // Sprawdź aktualne indeksy symboli
        // Zakładamy, że pbReelX.Image jest jednym z symbols[i]
        int i1 = reel1Index;
        int i2 = reel2Index;
        int i3 = reel3Index;

        decimal bet = nudBet.Value;
        decimal payout = 0;

        // Prosty system wypłat:
        // - 3 takie same: x5 stawki
        // - 2 takie same: x2 stawki
        // - inaczej: 0
        if (i1 == i2 && i2 == i3)
        {
            payout = bet * 5;
        }
        else if (i1 == i2 || i1 == i3 || i2 == i3)
        {
            payout = bet * 2;
        }

        if (payout > 0)
        {
            decimal newSaldo = Properties.Settings.Default.Saldo + payout;
            SaveSaldo(newSaldo);
            MessageBox.Show($"Wygrałeś {payout}!");
        }
        else
        {
            MessageBox.Show("Niestety, nic tym razem.");
        }
    }

    // Opcjonalnie: przycisk do doładowania (testowo)
    private void btnAddCoins_Click(object sender, EventArgs e)
    {
        decimal s = Properties.Settings.Default.Saldo;
        s += 50;
        SaveSaldo(s);
    }

    // Upewnij się że eventy są podpięte:
    // btnSpin.Click += btnSpin_Click;
    // timerSpin.Tick += timerSpin_Tick;
    // btnAddCoins.Click += btnAddCoins_Click;
}
