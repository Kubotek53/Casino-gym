namespace Casino_gym
{
    partial class Ruletka
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBankroll = new System.Windows.Forms.Label();
            this.numericBet = new System.Windows.Forms.NumericUpDown();
            this.lblBetAmount = new System.Windows.Forms.Label();
            this.btnSpin = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblResultNumber = new System.Windows.Forms.Label();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.lblTotalBet = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericBet)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.Color.Gold;
            this.lblTitle.Location = new System.Drawing.Point(400, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(130, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ruletka";
            // 
            // lblBankroll
            // 
            this.lblBankroll.AutoSize = true;
            this.lblBankroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBankroll.ForeColor = System.Drawing.Color.White;
            this.lblBankroll.Location = new System.Drawing.Point(30, 30);
            this.lblBankroll.Name = "lblBankroll";
            this.lblBankroll.Size = new System.Drawing.Size(113, 24);
            this.lblBankroll.TabIndex = 1;
            this.lblBankroll.Text = "Bankroll: $0";
            // 
            // numericBet
            // 
            this.numericBet.DecimalPlaces = 2;
            this.numericBet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numericBet.Location = new System.Drawing.Point(34, 150);
            this.numericBet.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericBet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericBet.Name = "numericBet";
            this.numericBet.Size = new System.Drawing.Size(120, 26);
            this.numericBet.TabIndex = 4;
            this.numericBet.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblBetAmount
            // 
            this.lblBetAmount.AutoSize = true;
            this.lblBetAmount.ForeColor = System.Drawing.Color.White;
            this.lblBetAmount.Location = new System.Drawing.Point(31, 130);
            this.lblBetAmount.Name = "lblBetAmount";
            this.lblBetAmount.Size = new System.Drawing.Size(120, 13);
            this.lblBetAmount.TabIndex = 5;
            this.lblBetAmount.Text = "Wartość żetonu (Stawka)";
            // 
            // btnSpin
            // 
            this.btnSpin.BackColor = System.Drawing.Color.Gold;
            this.btnSpin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnSpin.ForeColor = System.Drawing.Color.Black;
            this.btnSpin.Location = new System.Drawing.Point(34, 250);
            this.btnSpin.Name = "btnSpin";
            this.btnSpin.Size = new System.Drawing.Size(200, 50);
            this.btnSpin.TabIndex = 8;
            this.btnSpin.Text = "ZAKRĘĆ";
            this.btnSpin.UseVisualStyleBackColor = false;
            this.btnSpin.Click += new System.EventHandler(this.btnSpin_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturn.BackColor = System.Drawing.Color.IndianRed;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnReturn.ForeColor = System.Drawing.Color.Black;
            this.btnReturn.Location = new System.Drawing.Point(850, 500);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(100, 40);
            this.btnReturn.TabIndex = 9;
            this.btnReturn.Text = "Powrót";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblResult.ForeColor = System.Drawing.Color.White;
            this.lblResult.Location = new System.Drawing.Point(280, 450);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(68, 24);
            this.lblResult.TabIndex = 10;
            this.lblResult.Text = "Wynik";
            this.lblResult.Visible = false;
            // 
            // lblResultNumber
            // 
            this.lblResultNumber.AutoSize = true;
            this.lblResultNumber.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold);
            this.lblResultNumber.ForeColor = System.Drawing.Color.Gold;
            this.lblResultNumber.Location = new System.Drawing.Point(600, 430);
            this.lblResultNumber.Name = "lblResultNumber";
            this.lblResultNumber.Size = new System.Drawing.Size(0, 75);
            this.lblResultNumber.TabIndex = 11;
            // 
            // pnlBoard
            // 
            this.pnlBoard.BackColor = System.Drawing.Color.Green;
            this.pnlBoard.Location = new System.Drawing.Point(300, 100);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(600, 300);
            this.pnlBoard.TabIndex = 12;
            // 
            // lblTotalBet
            // 
            this.lblTotalBet.AutoSize = true;
            this.lblTotalBet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTotalBet.ForeColor = System.Drawing.Color.Gold;
            this.lblTotalBet.Location = new System.Drawing.Point(30, 200);
            this.lblTotalBet.Name = "lblTotalBet";
            this.lblTotalBet.Size = new System.Drawing.Size(176, 20);
            this.lblTotalBet.TabIndex = 13;
            this.lblTotalBet.Text = "Aktualny zakład: $0.00";
            // 
            // Ruletka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.lblTotalBet);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.lblResultNumber);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnSpin);
            this.Controls.Add(this.lblBetAmount);
            this.Controls.Add(this.numericBet);
            this.Controls.Add(this.lblBankroll);
            this.Controls.Add(this.lblTitle);
            this.Name = "Ruletka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ruletka - Casino Gym";
            ((System.ComponentModel.ISupportInitialize)(this.numericBet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblBankroll;
        private System.Windows.Forms.NumericUpDown numericBet;
        private System.Windows.Forms.Label lblBetAmount;
        private System.Windows.Forms.Button btnSpin;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblResultNumber;
        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Label lblTotalBet;
    }
}