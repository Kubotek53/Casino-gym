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
            this.Wallet = new Casino_gym.RoundedButton();
            this.btnPoker = new Casino_gym.RoundedButton();
            this.btnBlackJack = new Casino_gym.RoundedButton();
            this.btnSlots = new Casino_gym.RoundedButton();
            this.btnRoulette = new Casino_gym.RoundedButton();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1724, 70);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(160, 50);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Wyloguj się";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnManageUsers_Click1
            // 
            this.btnManageUsers_Click1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManageUsers_Click1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnManageUsers_Click1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageUsers_Click1.FlatAppearance.BorderSize = 0;
            this.btnManageUsers_Click1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageUsers_Click1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnManageUsers_Click1.ForeColor = System.Drawing.Color.White;
            this.btnManageUsers_Click1.Location = new System.Drawing.Point(1724, 825);
            this.btnManageUsers_Click1.Name = "btnManageUsers_Click1";
            this.btnManageUsers_Click1.Size = new System.Drawing.Size(160, 50);
            this.btnManageUsers_Click1.TabIndex = 1;
            this.btnManageUsers_Click1.Text = "Panel administratora";
            this.btnManageUsers_Click1.UseVisualStyleBackColor = false;
            this.btnManageUsers_Click1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Wallet
            // 
            this.Wallet.GradientStartColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.Wallet.GradientEndColor = System.Drawing.Color.FromArgb(0, 80, 200);
            this.Wallet.Location = new System.Drawing.Point(1650, 12);
            this.Wallet.Name = "Wallet";
            this.Wallet.Size = new System.Drawing.Size(200, 60);
            this.Wallet.Text = "Konto";
            this.Wallet.Click += new System.EventHandler(this.Wallet_Click);

            // 
            // btnPoker
            // 
            this.btnPoker.GradientStartColor = System.Drawing.Color.FromArgb(0, 100, 0); // Dark Green
            this.btnPoker.GradientEndColor = System.Drawing.Color.FromArgb(0, 50, 0);
            this.btnPoker.Location = new System.Drawing.Point(827, 350); // Centered approx (1904/2 - 250/2)
            this.btnPoker.Name = "btnPoker";
            this.btnPoker.Size = new System.Drawing.Size(250, 70);
            this.btnPoker.TabIndex = 3;
            this.btnPoker.Text = "Poker";
            this.btnPoker.Click += new System.EventHandler(this.btnPoker_Click);
            // 
            // btnBlackJack
            // 
            this.btnBlackJack.GradientStartColor = System.Drawing.Color.FromArgb(50, 50, 50); // Dark Grey
            this.btnBlackJack.GradientEndColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.btnBlackJack.Location = new System.Drawing.Point(827, 440);
            this.btnBlackJack.Name = "btnBlackJack";
            this.btnBlackJack.Size = new System.Drawing.Size(250, 70);
            this.btnBlackJack.TabIndex = 4;
            this.btnBlackJack.Text = "BlackJack";
            this.btnBlackJack.Click += new System.EventHandler(this.btnBlackJack_Click);
            // 
            // btnSlots
            // 
            this.btnSlots.GradientStartColor = System.Drawing.Color.FromArgb(255, 140, 0); // Orange/Gold
            this.btnSlots.GradientEndColor = System.Drawing.Color.FromArgb(184, 134, 11);
            this.btnSlots.Location = new System.Drawing.Point(827, 530);
            this.btnSlots.Name = "btnSlots";
            this.btnSlots.Size = new System.Drawing.Size(250, 70);
            this.btnSlots.TabIndex = 5;
            this.btnSlots.Text = "Slots";
            this.btnSlots.Click += new System.EventHandler(this.btnSlots_Click);
            // 
            // btnRoulette
            // 
            this.btnRoulette.GradientStartColor = System.Drawing.Color.FromArgb(200, 0, 0); // Red
            this.btnRoulette.GradientEndColor = System.Drawing.Color.FromArgb(100, 0, 0);
            this.btnRoulette.Location = new System.Drawing.Point(827, 620);
            this.btnRoulette.Name = "btnRoulette";
            this.btnRoulette.Size = new System.Drawing.Size(250, 70);
            this.btnRoulette.TabIndex = 6;
            this.btnRoulette.Text = "Ruletka";
            this.btnRoulette.Click += new System.EventHandler(this.btnRoulette_Click);
            // 
            // MainPage
            // 
            this.BackgroundImage = global::Casino_gym.Properties.Resources.cas;
            this.ClientSize = new System.Drawing.Size(1904, 1011);
            this.Controls.Add(this.btnRoulette);
            this.Controls.Add(this.btnSlots);
            this.Controls.Add(this.btnBlackJack);
            this.Controls.Add(this.btnPoker);
            this.Controls.Add(this.Wallet);
            this.Controls.Add(this.btnManageUsers_Click1);
            this.Controls.Add(this.btnLogout);
            this.Name = "MainPage";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnManageUsers_Click1;
        private Casino_gym.RoundedButton Wallet;
        private Casino_gym.RoundedButton btnPoker;
        private Casino_gym.RoundedButton btnBlackJack;
        private Casino_gym.RoundedButton btnSlots;
        private Casino_gym.RoundedButton btnRoulette;
    }
}
