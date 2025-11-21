using System;
using System.Windows.Forms;

namespace Casino_gym
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // To jest metoda, która się wykona po kliknięciu przycisku "Wejdź jako Gość"
        // (Upewnij się, że w Designerze przycisk nazywa się btnGuestLogin i ma podpięte to zdarzenie)
        private void btnGuestLogin_Click(object sender, EventArgs e)
        {
            // 1. Tworzymy nowe okno z grą Slotsy
            SlotsForm slotsGame = new SlotsForm();

            // 2. Ukrywamy obecne okno (Form1 - Menu Główne)
            this.Hide();

            // 3. Obsługa zdarzenia: Co ma się stać, gdy zamkniemy okno gry?
            // Chcemy, żeby Menu Główne (Form1) wróciło.
            slotsGame.FormClosed += (s, args) => this.Show();

            // 4. Pokazujemy grę
            slotsGame.Show();
        }
    }
}