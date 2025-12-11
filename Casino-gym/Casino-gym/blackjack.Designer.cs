using System.Drawing;
using System.Windows.Forms;

namespace Casino_gym
{
    partial class Blackjack
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxPlayer;
        private System.Windows.Forms.ListBox listBoxDealer;
        private System.Windows.Forms.Button btnDeal;
        private System.Windows.Forms.Button btnHit;
        private System.Windows.Forms.Button btnStand;
        private System.Windows.Forms.NumericUpDown numericBet;
        private System.Windows.Forms.Label lblBankroll;
        private System.Windows.Forms.Label lblPlayerValue;
        private System.Windows.Forms.Label lblDealerValue;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnReturn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            listBoxPlayer = new ListBox();
            listBoxDealer = new ListBox();
            btnDeal = new Button();
            btnHit = new Button();
            btnStand = new Button();
            numericBet = new NumericUpDown();
            lblBankroll = new Label();
            lblPlayerValue = new Label();
            lblDealerValue = new Label();
            btnReset = new Button();
            btnReturn = new Button();
            ((System.ComponentModel.ISupportInitialize)numericBet).BeginInit();
            SuspendLayout();

            listBoxPlayer.BackColor = Color.White;
            listBoxPlayer.Font = new Font("Segoe UI", 12F);
            listBoxPlayer.FormattingEnabled = true;
            listBoxPlayer.ItemHeight = 21;
            listBoxPlayer.Location = new Point(260, 250);
            listBoxPlayer.Name = "listBoxPlayer";
            listBoxPlayer.Size = new Size(280, 150);
            listBoxPlayer.TabIndex = 0;

            listBoxDealer.BackColor = Color.White;
            listBoxDealer.Font = new Font("Segoe UI", 12F);
            listBoxDealer.FormattingEnabled = true;
            listBoxDealer.ItemHeight = 21;
            listBoxDealer.Location = new Point(260, 50);
            listBoxDealer.Name = "listBoxDealer";
            listBoxDealer.Size = new Size(280, 150);
            listBoxDealer.TabIndex = 1;
       

            btnDeal.BackColor = Color.FromArgb(40, 167, 69); 
            btnDeal.FlatStyle = FlatStyle.Flat;
            btnDeal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDeal.ForeColor = Color.White;
            btnDeal.Location = new Point(50, 400);
            btnDeal.Name = "btnDeal";
            btnDeal.Size = new Size(120, 50);
            btnDeal.TabIndex = 2;
            btnDeal.Text = "DEAL";
            btnDeal.UseVisualStyleBackColor = false;
            btnDeal.Click += btnDeal_Click;
        
            btnHit.BackColor = Color.FromArgb(0, 123, 255); 
            btnHit.FlatStyle = FlatStyle.Flat;
            btnHit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnHit.ForeColor = Color.White;
            btnHit.Location = new Point(190, 400);
            btnHit.Name = "btnHit";
            btnHit.Size = new Size(120, 50);
            btnHit.TabIndex = 3;
            btnHit.Text = "HIT";
            btnHit.UseVisualStyleBackColor = false;
            btnHit.Click += btnHit_Click;
      
            btnStand.BackColor = Color.FromArgb(220, 53, 69); 
            btnStand.FlatStyle = FlatStyle.Flat;
            btnStand.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnStand.ForeColor = Color.White;
            btnStand.Location = new Point(330, 400);
            btnStand.Name = "btnStand";
            btnStand.Size = new Size(120, 50);
            btnStand.TabIndex = 4;
            btnStand.Text = "STAND";
            btnStand.UseVisualStyleBackColor = false;
            btnStand.Click += btnStand_Click;
    
            numericBet.Font = new Font("Segoe UI", 14F);
            numericBet.Location = new Point(600, 410);
            numericBet.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericBet.Name = "numericBet";
            numericBet.Size = new Size(120, 32);
            numericBet.TabIndex = 5;
            numericBet.TextAlign = HorizontalAlignment.Center;
            numericBet.Value = new decimal(new int[] { 10, 0, 0, 0 });
      
            lblBankroll.AutoSize = true;
            lblBankroll.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblBankroll.ForeColor = Color.Gold;
            lblBankroll.Location = new Point(600, 20);
            lblBankroll.Name = "lblBankroll";
            lblBankroll.Size = new Size(120, 25);
            lblBankroll.TabIndex = 6;
            lblBankroll.Text = "Bankroll: $0";
        
            lblPlayerValue.AutoSize = true;
            lblPlayerValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPlayerValue.ForeColor = Color.White;
            lblPlayerValue.Location = new Point(260, 225);
            lblPlayerValue.Name = "lblPlayerValue";
            lblPlayerValue.Size = new Size(81, 19);
            lblPlayerValue.TabIndex = 7;
            lblPlayerValue.Text = "Wartość: 0";
     
            lblDealerValue.AutoSize = true;
            lblDealerValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDealerValue.ForeColor = Color.White;
            lblDealerValue.Location = new Point(260, 25);
            lblDealerValue.Name = "lblDealerValue";
            lblDealerValue.Size = new Size(81, 19);
            lblDealerValue.TabIndex = 8;
            lblDealerValue.Text = "Wartość: 0";
   
            btnReset.Visible = false;
            btnReset.Location = new Point(0, 0);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(0, 0);
            btnReset.TabIndex = 9;
            btnReset.Text = "Reset";
       
            btnReturn.BackColor = Color.DimGray;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReturn.ForeColor = Color.White;
            btnReturn.Location = new Point(12, 12);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(75, 30);
            btnReturn.TabIndex = 10;
            btnReturn.Text = "Powrót";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
       
            ClientSize = new Size(800, 500);
            BackColor = Color.FromArgb(45, 45, 45);
            Controls.Add(btnReturn);
            Controls.Add(btnReset);
            Controls.Add(lblDealerValue);
            Controls.Add(lblPlayerValue);
            Controls.Add(lblBankroll);
            Controls.Add(numericBet);
            Controls.Add(btnStand);
            Controls.Add(btnHit);
            Controls.Add(btnDeal);
            Controls.Add(listBoxDealer);
            Controls.Add(listBoxPlayer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Name = "Blackjack";
            Text = "Blackjack Table";
            ((System.ComponentModel.ISupportInitialize)numericBet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}