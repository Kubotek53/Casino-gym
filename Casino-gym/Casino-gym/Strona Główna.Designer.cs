namespace Casino_gym
{
    partial class Form2
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
            this.Logowanie2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Logowanie2
            // 
            this.Logowanie2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Logowanie2.Location = new System.Drawing.Point(0, 0);
            this.Logowanie2.Name = "Logowanie2";
            this.Logowanie2.Size = new System.Drawing.Size(75, 23);
            this.Logowanie2.TabIndex = 0;
            this.Logowanie2.Text = "Logowanie2";
            this.Logowanie2.UseVisualStyleBackColor = false;
            this.Logowanie2.Click += new System.EventHandler(this.Logowanie2_Click);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(502, 417);
            this.Controls.Add(this.Logowanie2);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Logowanie;
        private System.Windows.Forms.Button Logowanie2;
    }
}

