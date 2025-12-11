namespace Casino_gym
{
    partial class UpperLower
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.Button btnHigher;
        private System.Windows.Forms.Button btnLower;
        private System.Windows.Forms.Button btnDeal;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.NumericUpDown nudBet;
        private System.Windows.Forms.Label lblBetLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCard = new System.Windows.Forms.Label();
            this.btnHigher = new System.Windows.Forms.Button();
            this.btnLower = new System.Windows.Forms.Button();
            this.btnDeal = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.nudBet = new System.Windows.Forms.NumericUpDown();
            this.lblBetLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudBet)).BeginInit();
            this.SuspendLayout();

           
            this.lblCard.BackColor = System.Drawing.Color.White;
            this.lblCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCard.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold);
            this.lblCard.Location = new System.Drawing.Point(300, 100);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(200, 300);
            this.lblCard.TabIndex = 0;
            this.lblCard.Text = "?";
            this.lblCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

          
            this.btnHigher.BackColor = System.Drawing.Color.Green;
            this.btnHigher.Enabled = false;
            this.btnHigher.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnHigher.ForeColor = System.Drawing.Color.White;
            this.btnHigher.Location = new System.Drawing.Point(550, 150);
            this.btnHigher.Name = "btnHigher";
            this.btnHigher.Size = new System.Drawing.Size(150, 80);
            this.btnHigher.TabIndex = 1;
            this.btnHigher.Text = "WYŻSZA";
            this.btnHigher.UseVisualStyleBackColor = false;
            this.btnHigher.Click += new System.EventHandler(this.btnHigher_Click);

            
            this.btnLower.BackColor = System.Drawing.Color.Red;
            this.btnLower.Enabled = false;
            this.btnLower.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnLower.ForeColor = System.Drawing.Color.White;
            this.btnLower.Location = new System.Drawing.Point(550, 270);
            this.btnLower.Name = "btnLower";
            this.btnLower.Size = new System.Drawing.Size(150, 80);
            this.btnLower.TabIndex = 2;
            this.btnLower.Text = "NIŻSZA";
            this.btnLower.UseVisualStyleBackColor = false;
            this.btnLower.Click += new System.EventHandler(this.btnLower_Click);

           
            this.btnDeal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnDeal.Location = new System.Drawing.Point(50, 200);
            this.btnDeal.Name = "btnDeal";
            this.btnDeal.Size = new System.Drawing.Size(150, 60);
            this.btnDeal.TabIndex = 3;
            this.btnDeal.Text = "GRAJ";
            this.btnDeal.UseVisualStyleBackColor = true;
            this.btnDeal.Click += new System.EventHandler(this.btnDeal_Click);

         
            this.btnReturn.Location = new System.Drawing.Point(12, 12);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(100, 40);
            this.btnReturn.TabIndex = 4;
            this.btnReturn.Text = "Powrót";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);

          
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBalance.ForeColor = System.Drawing.Color.Gold;
            this.lblBalance.Location = new System.Drawing.Point(500, 20);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(150, 30);
            this.lblBalance.TabIndex = 5;
            this.lblBalance.Text = "Saldo: $0.00";
 
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblResult.ForeColor = System.Drawing.Color.White;
            this.lblResult.Location = new System.Drawing.Point(200, 420);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(400, 40);
            this.lblResult.TabIndex = 6;
            this.lblResult.Text = "Postaw zakład i naciśnij GRAJ";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

         
            this.nudBet.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.nudBet.Location = new System.Drawing.Point(50, 150);
            this.nudBet.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudBet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBet.Name = "nudBet";
            this.nudBet.Size = new System.Drawing.Size(150, 29);
            this.nudBet.TabIndex = 7;
            this.nudBet.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});

       
            this.lblBetLabel.AutoSize = true;
            this.lblBetLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBetLabel.ForeColor = System.Drawing.Color.White;
            this.lblBetLabel.Location = new System.Drawing.Point(50, 120);
            this.lblBetLabel.Name = "lblBetLabel";
            this.lblBetLabel.Size = new System.Drawing.Size(69, 21);
            this.lblBetLabel.TabIndex = 8;
            this.lblBetLabel.Text = "Stawka:";

     
        
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.lblBetLabel);
            this.Controls.Add(this.nudBet);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnDeal);
            this.Controls.Add(this.btnLower);
            this.Controls.Add(this.btnHigher);
            this.Controls.Add(this.lblCard);
            this.Name = "UpperLower";
            this.Text = "Upper Lower";
            ((System.ComponentModel.ISupportInitialize)(this.nudBet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
