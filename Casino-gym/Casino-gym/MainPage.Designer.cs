using System.Windows.Forms;

namespace Casino_gym
{
    partial class MainPage

    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnManageUsers_Click1 = new System.Windows.Forms.Button();
            this.Wallet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1722, 58);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(130, 40);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Wyloguj się";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnManageUsers_Click1
            // 
            this.btnManageUsers_Click1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnManageUsers_Click1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageUsers_Click1.FlatAppearance.BorderSize = 0;
            this.btnManageUsers_Click1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageUsers_Click1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManageUsers_Click1.ForeColor = System.Drawing.Color.White;
            this.btnManageUsers_Click1.Location = new System.Drawing.Point(1705, 12);
            this.btnManageUsers_Click1.Name = "btnManageUsers_Click1";
            this.btnManageUsers_Click1.Size = new System.Drawing.Size(160, 40);
            this.btnManageUsers_Click1.TabIndex = 1;
            this.btnManageUsers_Click1.Text = "Panel administratora";
            this.btnManageUsers_Click1.UseVisualStyleBackColor = false;
            this.btnManageUsers_Click1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Wallet
            // 
            this.Wallet.Location = new System.Drawing.Point(12, 12);
            this.Wallet.Name = "Wallet";
            this.Wallet.Size = new System.Drawing.Size(75, 23);
            this.Wallet.TabIndex = 2;
            this.Wallet.Text = "button1";
            this.Wallet.UseVisualStyleBackColor = true;
            this.Wallet.Click += new System.EventHandler(this.Wallet_Click);
            // 
            // MainPage
            // 
            this.BackgroundImage = global::Casino_gym.Properties.Resources.cas;
            this.ClientSize = new System.Drawing.Size(1904, 1011);
            this.Controls.Add(this.Wallet);
            this.Controls.Add(this.btnManageUsers_Click1);
            this.Controls.Add(this.btnLogout);
            this.Name = "MainPage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Logowanie;
        private System.Windows.Forms.Button Logowanie2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnManageUsers_Click1;
        private Button Wallet;
    }
}

