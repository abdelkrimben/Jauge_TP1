namespace Jauge_TP1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtValeur;
        private System.Windows.Forms.Button btnSetValue;
        private DialGauge dialGauge;

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
            this.txtValeur = new System.Windows.Forms.TextBox();
            this.btnSetValue = new System.Windows.Forms.Button();
            this.dialGauge = new Jauge_TP1.DialGauge();
            this.SuspendLayout();
            // 
            // txtValeur
            // 
            this.txtValeur.Location = new System.Drawing.Point(20, 220);
            this.txtValeur.Name = "txtValeur";
            this.txtValeur.Size = new System.Drawing.Size(100, 22);
            this.txtValeur.TabIndex = 0;
            // 
            // btnSetValue
            // 
            this.btnSetValue.Location = new System.Drawing.Point(140, 220);
            this.btnSetValue.Name = "btnSetValue";
            this.btnSetValue.Size = new System.Drawing.Size(119, 30);
            this.btnSetValue.TabIndex = 1;
            this.btnSetValue.Text = "Changer valeur";
            this.btnSetValue.UseVisualStyleBackColor = true;
            this.btnSetValue.Click += new System.EventHandler(this.btnSetValue_Click);
            // 
            // dialGauge
            // 
            this.dialGauge.Location = new System.Drawing.Point(10, 10);
            this.dialGauge.Max = 100F;
            this.dialGauge.Min = 0F;
            this.dialGauge.Name = "dialGauge";
            this.dialGauge.Size = new System.Drawing.Size(400, 200);
            this.dialGauge.TabIndex = 2;
            this.dialGauge.Value = 50F;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 270);
            this.Controls.Add(this.dialGauge);
            this.Controls.Add(this.btnSetValue);
            this.Controls.Add(this.txtValeur);
            this.Name = "Form1";
            this.Text = "Horizontal Filler Gauge 6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
