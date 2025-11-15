using System.Windows.Forms;

namespace Casino_gym
{
    partial class MainPage
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

        private void InitializeComponent()
        {
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnManageUsers_Click1 = new System.Windows.Forms.Button();
            this.Wallet = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // === FORM ===
            this.BackgroundImage = global::Casino_gym.Properties.Resources.cas;
            this.ClientSize = new System.Drawing.Size(1904, 1011);
            this.Name = "MainPage";

            // === PRZYCISK SALDA (WALLET) ===
            this.Wallet.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.Wallet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Wallet.FlatAppearance.BorderSize = 0;
            this.Wallet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Wallet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Wallet.ForeColor = System.Drawing.Color.White;
            this.Wallet.Location = new System.Drawing.Point(20, 20);   // <-- LEWY GÓRNY RÓG
            this.Wallet.Name = "Wallet";
            this.Wallet.Size = new System.Drawing.Size(140, 45);       // większy i elegancki
            this.Wallet.TabIndex = 2;
            this.Wallet.Text = "Saldo";
            this.Wallet.UseVisualStyleBackColor = false;
            this.Wallet.Click += new System.EventHandler(this.Wallet_Click);

            // === PRZYCISK PANEL ADMINA ===
            this.btnManageUsers_Click1.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            this.btnManageUsers_Click1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageUsers_Click1.FlatAppearance.BorderSize = 0;
            this.btnManageUsers_Click1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageUsers_Click1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManageUsers_Click1.ForeColor = System.Drawing.Color.White;

            // Umieszczony w prawym górnym rogu
            this.btnManageUsers_Click1.Location = new System.Drawing.Point(1724, 20);
            this.btnManageUsers_Click1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.btnManageUsers_Click1.Name = "btnManageUsers_Click1";
            this.btnManageUsers_Click1.Size = new System.Drawing.Size(160, 40);
            this.btnManageUsers_Click1.TabIndex = 1;
            this.btnManageUsers_Click1.Text = "Panel administratora";
            this.btnManageUsers_Click1.UseVisualStyleBackColor = false;
            this.btnManageUsers_Click1.Click += new System.EventHandler(this.button1_Click);

            // === PRZYCISK WYLOGOWANIA ===
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;

            // Obok panelu admina
            this.btnLogout.Location = new System.Drawing.Point(1724, 70);
            this.btnLogout.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(160, 40);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Wyloguj się";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // === ADD CONTROLS ===
            this.Controls.Add(this.Wallet);
            this.Controls.Add(this.btnManageUsers_Click1);
            this.Controls.Add(this.btnLogout);

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnManageUsers_Click1;
        private Button Wallet;
    }
}
