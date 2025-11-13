namespace Casino_gym
{
    partial class WalletForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Button btnBackToMain;

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
            this.lblBalance = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.btnBackToMain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblBalance.Location = new System.Drawing.Point(30, 20);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(102, 25);
            this.lblBalance.TabIndex = 0;
            this.lblBalance.Text = "Saldo: 0,00";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAmount.Location = new System.Drawing.Point(35, 60);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(150, 29);
            this.txtAmount.TabIndex = 1;
  
            // 
            // btnDeposit
            // 
            this.btnDeposit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDeposit.Location = new System.Drawing.Point(200, 60);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(100, 30);
            this.btnDeposit.TabIndex = 2;
            this.btnDeposit.Text = "Wpłać";
            this.btnDeposit.UseVisualStyleBackColor = true;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnWithdraw.Location = new System.Drawing.Point(310, 60);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(100, 30);
            this.btnWithdraw.TabIndex = 3;
            this.btnWithdraw.Text = "Wypłać";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // btnBackToMain
            // 
            this.btnBackToMain.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBackToMain.Location = new System.Drawing.Point(35, 110);
            this.btnBackToMain.Name = "btnBackToMain";
            this.btnBackToMain.Size = new System.Drawing.Size(150, 35);
            this.btnBackToMain.TabIndex = 4;
            this.btnBackToMain.Text = "Powrót do MainPage";
            this.btnBackToMain.UseVisualStyleBackColor = true;
            this.btnBackToMain.Click += new System.EventHandler(this.btnBackToMain_Click);
            // 
            // WalletForm
            // 
            this.ClientSize = new System.Drawing.Size(450, 180);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnDeposit);
            this.Controls.Add(this.btnWithdraw);
            this.Controls.Add(this.btnBackToMain);
            this.Name = "WalletForm";
            this.Text = "Portfel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
