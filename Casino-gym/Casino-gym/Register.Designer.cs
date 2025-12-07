namespace Casino_gym
{
    partial class Register
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Zwolnij zasoby.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta Windows Forms

        /// <summary>
        /// Metoda wymagana do obsługi projektanta.
        /// </summary>
        private void InitializeComponent()
        {
            this.textboxUsername = new System.Windows.Forms.TextBox();
            this.textboxPassword = new System.Windows.Forms.TextBox();
            this.textboxAge = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textboxUsername
            // 
            this.textboxUsername.Location = new System.Drawing.Point(120, 50);
            this.textboxUsername.Name = "textboxUsername";
            this.textboxUsername.Size = new System.Drawing.Size(150, 20);
            this.textboxUsername.TabIndex = 0;
            // 
            // textboxPassword
            // 
            this.textboxPassword.Location = new System.Drawing.Point(120, 90);
            this.textboxPassword.Name = "textboxPassword";
            this.textboxPassword.PasswordChar = '*';
            this.textboxPassword.Size = new System.Drawing.Size(150, 20);
            this.textboxPassword.TabIndex = 1;
            // 
            // textboxAge
            // 
            this.textboxAge.Location = new System.Drawing.Point(120, 130);
            this.textboxAge.Name = "textboxAge";
            this.textboxAge.Size = new System.Drawing.Size(150, 20);
            this.textboxAge.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nazwa konta:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasło:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Wiek:";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(25, 135, 84); // zielony (Bootstrap 'success')
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegister.Location = new System.Drawing.Point(110, 170);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(170, 40);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Zarejestruj się";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(108, 117, 125); // szary (Bootstrap 'secondary')
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.Location = new System.Drawing.Point(110, 230);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(170, 40);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Powrót do logowania";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(334, 300);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textboxAge);
            this.Controls.Add(this.textboxPassword);
            this.Controls.Add(this.textboxUsername);
            this.Name = "Register";
            this.Text = "Rejestracja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textboxUsername;
        private System.Windows.Forms.TextBox textboxPassword;
        private System.Windows.Forms.TextBox textboxAge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnBack;
    }
}
