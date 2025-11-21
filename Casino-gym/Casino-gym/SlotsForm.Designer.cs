namespace Casino_gym
{
    partial class SlotsForm
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
            this.components = new System.ComponentModel.Container();
            this.pbReel1 = new System.Windows.Forms.PictureBox();
            this.pbReel2 = new System.Windows.Forms.PictureBox();
            this.pbReel3 = new System.Windows.Forms.PictureBox();
            this.btnSpin = new System.Windows.Forms.Button();
            this.nudBet = new System.Windows.Forms.NumericUpDown();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.timerSpin = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbReel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBet)).BeginInit();
            this.SuspendLayout();
            // 
            // pbReel1
            // 
            this.pbReel1.Location = new System.Drawing.Point(105, 289);
            this.pbReel1.Name = "pbReel1";
            this.pbReel1.Size = new System.Drawing.Size(92, 60);
            this.pbReel1.TabIndex = 0;
            this.pbReel1.TabStop = false;
            // 
            // pbReel2
            // 
            this.pbReel2.Location = new System.Drawing.Point(337, 289);
            this.pbReel2.Name = "pbReel2";
            this.pbReel2.Size = new System.Drawing.Size(94, 60);
            this.pbReel2.TabIndex = 1;
            this.pbReel2.TabStop = false;
            // 
            // pbReel3
            // 
            this.pbReel3.Location = new System.Drawing.Point(600, 289);
            this.pbReel3.Name = "pbReel3";
            this.pbReel3.Size = new System.Drawing.Size(105, 60);
            this.pbReel3.TabIndex = 2;
            this.pbReel3.TabStop = false;
            this.pbReel3.Click += new System.EventHandler(this.pbReel3_Click);
            // 
            // btnSpin
            // 
            this.btnSpin.Location = new System.Drawing.Point(937, 305);
            this.btnSpin.Name = "btnSpin";
            this.btnSpin.Size = new System.Drawing.Size(75, 23);
            this.btnSpin.TabIndex = 3;
            this.btnSpin.Text = "Spin";
            this.btnSpin.UseVisualStyleBackColor = true;
            this.btnSpin.Click += new System.EventHandler(this.btnSpin_Click_1);
            // 
            // nudBet
            // 
            this.nudBet.Location = new System.Drawing.Point(982, 63);
            this.nudBet.Name = "nudBet";
            this.nudBet.Size = new System.Drawing.Size(75, 20);
            this.nudBet.TabIndex = 4;
            this.nudBet.ValueChanged += new System.EventHandler(this.nudBet_ValueChanged);
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location = new System.Drawing.Point(826, 63);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(32, 13);
            this.lblSaldo.TabIndex = 5;
            this.lblSaldo.Text = "saldo";
            this.lblSaldo.Click += new System.EventHandler(this.lblSaldo_Click);
            // 
            // timerSpin
            // 
            this.timerSpin.Tick += new System.EventHandler(this.timerSpin_Tick);
            // 
            // SlotsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 706);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.nudBet);
            this.Controls.Add(this.btnSpin);
            this.Controls.Add(this.pbReel3);
            this.Controls.Add(this.pbReel2);
            this.Controls.Add(this.pbReel1);
            this.Name = "SlotsForm";
            this.Text = "SlotsForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbReel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbReel1;
        private System.Windows.Forms.PictureBox pbReel2;
        private System.Windows.Forms.PictureBox pbReel3;
        private System.Windows.Forms.Button btnSpin;
        private System.Windows.Forms.NumericUpDown nudBet;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Timer timerSpin;
    }
}