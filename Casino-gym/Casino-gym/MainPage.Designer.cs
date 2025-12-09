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
            this.btnLogout = new Casino_gym.RoundedButton();
            this.btnManageUsers_Click1 = new Casino_gym.RoundedButton();
            this.Wallet = new Casino_gym.RoundedButton();
            this.btnPoker = new Casino_gym.RoundedButton();
            this.btnBlackJack = new Casino_gym.RoundedButton();
            this.btnSlots = new Casino_gym.RoundedButton();
            this.btnRoulette = new Casino_gym.RoundedButton();
            this.btnUpperLower = new Casino_gym.RoundedButton();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.BorderRadius = 40;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.btnLogout.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLogout.Location = new System.Drawing.Point(1668, 105);
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
            this.btnManageUsers_Click1.BackColor = System.Drawing.Color.Transparent;
            this.btnManageUsers_Click1.BorderRadius = 40;
            this.btnManageUsers_Click1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageUsers_Click1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageUsers_Click1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnManageUsers_Click1.ForeColor = System.Drawing.Color.White;
            this.btnManageUsers_Click1.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnManageUsers_Click1.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnManageUsers_Click1.Location = new System.Drawing.Point(1608, 761);
            this.btnManageUsers_Click1.Name = "btnManageUsers_Click1";
            this.btnManageUsers_Click1.Size = new System.Drawing.Size(272, 50);
            this.btnManageUsers_Click1.TabIndex = 1;
            this.btnManageUsers_Click1.Text = "Panel administratora";
            this.btnManageUsers_Click1.UseVisualStyleBackColor = false;
            this.btnManageUsers_Click1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Wallet
            // 
            this.Wallet.BackColor = System.Drawing.Color.Transparent;
            this.Wallet.BorderRadius = 40;
            this.Wallet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Wallet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Wallet.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.Wallet.ForeColor = System.Drawing.Color.White;
            this.Wallet.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.Wallet.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.Wallet.Location = new System.Drawing.Point(1632, 12);
            this.Wallet.Name = "Wallet";
            this.Wallet.Size = new System.Drawing.Size(218, 60);
            this.Wallet.TabIndex = 7;
            this.Wallet.Text = "Konto";
            this.Wallet.UseVisualStyleBackColor = false;
            this.Wallet.Click += new System.EventHandler(this.Wallet_Click);
            // 
            // btnPoker
            // 
            this.btnPoker.BackColor = System.Drawing.Color.Transparent;
            this.btnPoker.BorderRadius = 40;
            this.btnPoker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPoker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPoker.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnPoker.ForeColor = System.Drawing.Color.White;
            this.btnPoker.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(0)))));
            this.btnPoker.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.btnPoker.Location = new System.Drawing.Point(827, 350);
            this.btnPoker.Name = "btnPoker";
            this.btnPoker.Size = new System.Drawing.Size(250, 70);
            this.btnPoker.TabIndex = 3;
            this.btnPoker.Text = "Poker";
            this.btnPoker.UseVisualStyleBackColor = false;
            this.btnPoker.Click += new System.EventHandler(this.btnPoker_Click);
            // 
            // btnBlackJack
            // 
            this.btnBlackJack.BackColor = System.Drawing.Color.Transparent;
            this.btnBlackJack.BorderRadius = 40;
            this.btnBlackJack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBlackJack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlackJack.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnBlackJack.ForeColor = System.Drawing.Color.White;
            this.btnBlackJack.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnBlackJack.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnBlackJack.Location = new System.Drawing.Point(827, 440);
            this.btnBlackJack.Name = "btnBlackJack";
            this.btnBlackJack.Size = new System.Drawing.Size(250, 70);
            this.btnBlackJack.TabIndex = 4;
            this.btnBlackJack.Text = "BlackJack";
            this.btnBlackJack.UseVisualStyleBackColor = false;
            this.btnBlackJack.Click += new System.EventHandler(this.btnBlackJack_Click);
            // 
            // btnSlots
            // 
            this.btnSlots.BackColor = System.Drawing.Color.Transparent;
            this.btnSlots.BorderRadius = 40;
            this.btnSlots.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlots.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnSlots.ForeColor = System.Drawing.Color.White;
            this.btnSlots.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(134)))), ((int)(((byte)(11)))));
            this.btnSlots.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnSlots.Location = new System.Drawing.Point(827, 530);
            this.btnSlots.Name = "btnSlots";
            this.btnSlots.Size = new System.Drawing.Size(250, 70);
            this.btnSlots.TabIndex = 5;
            this.btnSlots.Text = "Slots";
            this.btnSlots.UseVisualStyleBackColor = false;
            this.btnSlots.Click += new System.EventHandler(this.btnSlots_Click);
            // 
            // btnRoulette
            // 
            this.btnRoulette.BackColor = System.Drawing.Color.Transparent;
            this.btnRoulette.BorderRadius = 40;
            this.btnRoulette.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoulette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoulette.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnRoulette.ForeColor = System.Drawing.Color.White;
            this.btnRoulette.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRoulette.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRoulette.Location = new System.Drawing.Point(827, 620);
            this.btnRoulette.Name = "btnRoulette";
            this.btnRoulette.Size = new System.Drawing.Size(250, 70);
            this.btnRoulette.TabIndex = 6;
            this.btnRoulette.Text = "Ruletka";
            this.btnRoulette.UseVisualStyleBackColor = false;
            this.btnRoulette.Click += new System.EventHandler(this.btnRoulette_Click);
            // 
            // btnUpperLower
            // 
            this.btnUpperLower.BackColor = System.Drawing.Color.Transparent;
            this.btnUpperLower.BorderRadius = 40;
            this.btnUpperLower.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpperLower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpperLower.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnUpperLower.ForeColor = System.Drawing.Color.White;
            this.btnUpperLower.GradientEndColor = System.Drawing.Color.Purple;
            this.btnUpperLower.GradientStartColor = System.Drawing.Color.Magenta;
            this.btnUpperLower.Location = new System.Drawing.Point(827, 710);
            this.btnUpperLower.Name = "btnUpperLower";
            this.btnUpperLower.Size = new System.Drawing.Size(250, 70);
            this.btnUpperLower.TabIndex = 7;
            this.btnUpperLower.Text = "Upper Lower";
            this.btnUpperLower.UseVisualStyleBackColor = false;
            this.btnUpperLower.Click += new System.EventHandler(this.btnUpperLower_Click);
            // 
            // MainPage
            // 
            this.BackgroundImage = global::Casino_gym.Properties.Resources.cas;
            this.ClientSize = new System.Drawing.Size(1904, 1011);
            this.Controls.Add(this.btnRoulette);
            this.Controls.Add(this.btnUpperLower);
            this.Controls.Add(this.btnSlots);
            this.Controls.Add(this.btnBlackJack);
            this.Controls.Add(this.btnPoker);
            this.Controls.Add(this.Wallet);
            this.Controls.Add(this.btnManageUsers_Click1);
            this.Controls.Add(this.btnLogout);
            this.Name = "MainPage";
            this.ResumeLayout(false);

        }

        private Casino_gym.RoundedButton btnLogout;
        private Casino_gym.RoundedButton btnManageUsers_Click1;
        private Casino_gym.RoundedButton Wallet;
        private Casino_gym.RoundedButton btnPoker;
        private Casino_gym.RoundedButton btnBlackJack;
        private Casino_gym.RoundedButton btnSlots;
        private Casino_gym.RoundedButton btnRoulette;
        private Casino_gym.RoundedButton btnUpperLower;
    }
}
