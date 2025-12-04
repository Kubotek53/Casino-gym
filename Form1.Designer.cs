namespace BlackjackWinForms
{
    partial class Form1
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
            ((System.ComponentModel.ISupportInitialize)numericBet).BeginInit();
            SuspendLayout();
            // 
            // listBoxPlayer
            // 
            listBoxPlayer.FormattingEnabled = true;
            listBoxPlayer.Location = new Point(28, 83);
            listBoxPlayer.Name = "listBoxPlayer";
            listBoxPlayer.Size = new Size(160, 154);
            listBoxPlayer.TabIndex = 0;
            // 
            // listBoxDealer
            // 
            listBoxDealer.FormattingEnabled = true;
            listBoxDealer.Location = new Point(212, 83);
            listBoxDealer.Name = "listBoxDealer";
            listBoxDealer.Size = new Size(160, 154);
            listBoxDealer.TabIndex = 1;
            // 
            // btnDeal
            // 
            btnDeal.Location = new Point(28, 270);
            btnDeal.Name = "btnDeal";
            btnDeal.Size = new Size(75, 30);
            btnDeal.TabIndex = 2;
            btnDeal.Text = "Deal";
            btnDeal.UseVisualStyleBackColor = true;
            btnDeal.Click += btnDeal_Click;
            // 
            // btnHit
            // 
            btnHit.Location = new Point(109, 270);
            btnHit.Name = "btnHit";
            btnHit.Size = new Size(75, 30);
            btnHit.TabIndex = 3;
            btnHit.Text = "Hit";
            btnHit.UseVisualStyleBackColor = true;
            btnHit.Click += btnHit_Click;
            // 
            // btnStand
            // 
            btnStand.Location = new Point(190, 270);
            btnStand.Name = "btnStand";
            btnStand.Size = new Size(75, 30);
            btnStand.TabIndex = 4;
            btnStand.Text = "Stand";
            btnStand.UseVisualStyleBackColor = true;
            btnStand.Click += btnStand_Click;
            // 
            // numericBet
            // 
            numericBet.Location = new Point(271, 276);
            numericBet.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericBet.Name = "numericBet";
            numericBet.Size = new Size(101, 31);
            numericBet.TabIndex = 5;
            numericBet.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblBankroll
            // 
            lblBankroll.AutoSize = true;
            lblBankroll.Location = new Point(28, 20);
            lblBankroll.Name = "lblBankroll";
            lblBankroll.Size = new Size(104, 25);
            lblBankroll.TabIndex = 6;
            lblBankroll.Text = "Bankroll: $0";
            // 
            // lblPlayerValue
            // 
            lblPlayerValue.AutoSize = true;
            lblPlayerValue.Location = new Point(28, 45);
            lblPlayerValue.Name = "lblPlayerValue";
            lblPlayerValue.Size = new Size(95, 25);
            lblPlayerValue.TabIndex = 7;
            lblPlayerValue.Text = "Wartość: 0";
            // 
            // lblDealerValue
            // 
            lblDealerValue.AutoSize = true;
            lblDealerValue.Location = new Point(209, 45);
            lblDealerValue.Name = "lblDealerValue";
            lblDealerValue.Size = new Size(95, 25);
            lblDealerValue.TabIndex = 8;
            lblDealerValue.Text = "Wartość: 0";
            // 
            // btnReset
            // 
            btnReset.Location = new Point(388, 270);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 30);
            btnReset.TabIndex = 9;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(490, 330);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Blackjack";
            ((System.ComponentModel.ISupportInitialize)numericBet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
