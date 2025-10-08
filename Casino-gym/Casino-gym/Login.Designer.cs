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
            this.Powrót = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Powrót
            // 
            this.Powrót.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Powrót.Location = new System.Drawing.Point(12, 12);
            this.Powrót.Name = "Powrót";
            this.Powrót.Size = new System.Drawing.Size(200, 50);
            this.Powrót.TabIndex = 0;
            this.Powrót.Text = "Powrót na strone główną";
            this.Powrót.UseVisualStyleBackColor = false;
            this.Powrót.Click += new System.EventHandler(this.Powrót_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1011);
            this.Controls.Add(this.Powrót);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Powrót;
    }
}