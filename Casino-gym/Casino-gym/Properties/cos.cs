using System;
using System.Windows.Forms;

namespace PrzykladOkna
{
	public class MainForm : Form
	{
		private Button buttonZagraj;

		public MainForm()
		{
			// Ustawienia okna
			this.Text = "Moje Okno";
			this.Width = 300;
			this.Height = 200;

			// Tworzymy przycisk
			buttonZagraj = new Button();
			buttonZagraj.Text = "Zagraj";
			buttonZagraj.Width = 100;
			buttonZagraj.Height = 40;
			buttonZagraj.Top = (this.ClientSize.Height - buttonZagraj.Height) / 2;
			buttonZagraj.Left = (this.ClientSize.Width - buttonZagraj.Width) / 2;

			// Dodajemy event klikniêcia
			buttonZagraj.Click += ButtonZagraj_Click;

			// Dodajemy przycisk do formularza
			this.Controls.Add(buttonZagraj);
		}

		private void ButtonZagraj_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Przycisk Zagraj zosta³ klikniêty!");
		}

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new MainForm());
		}

		public cos()
		{
			InitializeComponent();
		}
	}
}