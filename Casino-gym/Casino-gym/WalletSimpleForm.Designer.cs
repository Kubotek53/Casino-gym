namespace Casino_gym
{
    partial class WalletSimpleForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblBalance = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // === FORM ===
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(340, 260);
            this.Name = "WalletSimpleForm";
            this.Text = "Portfel";

            // === LABEL SALDO ===
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBalance.Location = new System.Drawing.Point(25, 25);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(160, 32);
            this.lblBalance.TabIndex = 0;
            this.lblBalance.Text = "Saldo: --- zł";

            // === POLE KWOTY ===
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtAmount.Location = new System.Drawing.Point(30, 90);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(270, 32);
            this.txtAmount.TabIndex = 1;

            // === PRZYCISK WPŁATY ===
            this.btnDeposit.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnDeposit.BackColor = System.Drawing.Color.FromArgb(0, 150, 0);
            this.btnDeposit.ForeColor = System.Drawing.Color.White;
            this.btnDeposit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeposit.FlatAppearance.BorderSize = 0;
            this.btnDeposit.Location = new System.Drawing.Point(30, 140);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(270, 45);
            this.btnDeposit.TabIndex = 2;
            this.btnDeposit.Text = "Wpłać środki";
            this.btnDeposit.UseVisualStyleBackColor = false;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);

            // === PRZYCISK POWROT ===
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(30, 144, 255);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.btnBack.Location = new System.Drawing.Point(10, 210);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 35);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Powrót";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // === ADD TO FORM ===
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnDeposit);
            this.Controls.Add(this.btnBack);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
