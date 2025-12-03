namespace Casino_gym
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textboxUsername = new System.Windows.Forms.TextBox();
            this.textboxPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnSkipLogin = new System.Windows.Forms.Button();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textboxUsername
            // 
            this.textboxUsername.Location = new System.Drawing.Point(110, 40);
            this.textboxUsername.Name = "textboxUsername";
            this.textboxUsername.Size = new System.Drawing.Size(169, 20);
            this.textboxUsername.TabIndex = 0;
            this.textboxUsername.TextChanged += new System.EventHandler(this.textboxUsername_TextChanged);
            // 
            // textboxPassword
            // 
            this.textboxPassword.Location = new System.Drawing.Point(110, 80);
            this.textboxPassword.Name = "textboxPassword";
            this.textboxPassword.PasswordChar = '*';
            this.textboxPassword.Size = new System.Drawing.Size(169, 20);
            this.textboxPassword.TabIndex = 1;
            this.textboxPassword.TextChanged += new System.EventHandler(this.textboxPassword_TextChanged_1);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(13, 110, 253); // niebieski (primary)
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Location = new System.Drawing.Point(100, 120);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 35);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Zaloguj";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Click += new System.EventHandler(this.Logowanie2_Click);

            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(25, 135, 84); // zielony (success)
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegister.Location = new System.Drawing.Point(210, 120);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(110, 35);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "Rejestracja";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // 
            // btnSkipLogin
            // 
            this.btnSkipLogin.BackColor = System.Drawing.Color.FromArgb(108, 117, 125); // szary (secondary)
            this.btnSkipLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkipLogin.FlatAppearance.BorderSize = 0;
            this.btnSkipLogin.ForeColor = System.Drawing.Color.White;
            this.btnSkipLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSkipLogin.Location = new System.Drawing.Point(100, 170);
            this.btnSkipLogin.Name = "btnSkipLogin";
            this.btnSkipLogin.Size = new System.Drawing.Size(220, 35);
            this.btnSkipLogin.TabIndex = 4;
            this.btnSkipLogin.Text = "Kontynuuj bez logowania";
            this.btnSkipLogin.UseVisualStyleBackColor = false;
            this.btnSkipLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSkipLogin.Click += new System.EventHandler(this.btnSkipLogin_Click);

            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(30, 43);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(74, 13);
            this.labelUsername.TabIndex = 5;
            this.labelUsername.Text = "Użytkownik:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(30, 83);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(42, 13);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Hasło:";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(340, 210);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.btnSkipLogin);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.textboxPassword);
            this.Controls.Add(this.textboxUsername);
            this.Name = "Login";
            this.Text = "Logowanie";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textboxUsername;
        private System.Windows.Forms.TextBox textboxPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnSkipLogin;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
    }
}
