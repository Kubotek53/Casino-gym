namespace Casino_gym
{
    partial class SlotsForm
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

        #region Windows Form Designer generated code

     
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
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbReel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBet)).BeginInit();
            this.SuspendLayout();
         
            this.pbReel1.Location = new System.Drawing.Point(220, 150);
            this.pbReel1.Name = "pbReel1";
            this.pbReel1.Size = new System.Drawing.Size(100, 100);
            this.pbReel1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbReel1.TabIndex = 0;
            this.pbReel1.TabStop = false;
         
            this.pbReel2.Location = new System.Drawing.Point(350, 150);
            this.pbReel2.Name = "pbReel2";
            this.pbReel2.Size = new System.Drawing.Size(100, 100);
            this.pbReel2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbReel2.TabIndex = 1;
            this.pbReel2.TabStop = false;
           
            this.pbReel3.Location = new System.Drawing.Point(480, 150);
            this.pbReel3.Name = "pbReel3";
            this.pbReel3.Size = new System.Drawing.Size(100, 100);
            this.pbReel3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbReel3.TabIndex = 2;
            this.pbReel3.TabStop = false;
            this.pbReel3.Click += new System.EventHandler(this.pbReel3_Click);
          
            this.btnSpin.BackColor = System.Drawing.Color.Gold;
            this.btnSpin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSpin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpin.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSpin.ForeColor = System.Drawing.Color.Black;
            this.btnSpin.Location = new System.Drawing.Point(300, 300);
            this.btnSpin.Name = "btnSpin";
            this.btnSpin.Size = new System.Drawing.Size(200, 60);
            this.btnSpin.TabIndex = 3;
            this.btnSpin.Text = "SPIN";
            this.btnSpin.UseVisualStyleBackColor = false;
            this.btnSpin.Click += new System.EventHandler(this.btnSpin_Click_1);
          
            this.nudBet.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.nudBet.Location = new System.Drawing.Point(350, 80);
            this.nudBet.Name = "nudBet";
            this.nudBet.Size = new System.Drawing.Size(100, 29);
            this.nudBet.TabIndex = 4;
            this.nudBet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudBet.ValueChanged += new System.EventHandler(this.nudBet_ValueChanged);
         
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSaldo.ForeColor = System.Drawing.Color.White;
            this.lblSaldo.Location = new System.Drawing.Point(350, 50);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(100, 21);
            this.lblSaldo.TabIndex = 5;
            this.lblSaldo.Text = "Saldo: $0.00";
            this.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSaldo.Click += new System.EventHandler(this.lblSaldo_Click);
        
            this.timerSpin.Tick += new System.EventHandler(this.timerSpin_Tick);
          
            this.btnBack.BackColor = System.Drawing.Color.DimGray;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 30);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Powrót";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
        
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.nudBet);
            this.Controls.Add(this.btnSpin);
            this.Controls.Add(this.pbReel3);
            this.Controls.Add(this.pbReel2);
            this.Controls.Add(this.pbReel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SlotsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Slots Machine";
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
        private System.Windows.Forms.Button btnBack;
    }
}