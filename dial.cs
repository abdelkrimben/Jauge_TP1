using System;
using System.Drawing;
using System.Windows.Forms;

public class DialGauge : UserControl
{
    private float _value;
    public float Value
    {
        get { return _value; }
        set
        {
            _value = Math.Max(MinValue, Math.Min(MaxValue, value)); // Clamp value
            this.Invalidate(); // Redessiner la jauge
        }
    }

    public float MinValue { get; set; } = 0; // Valeur minimale
    public float MaxValue { get; set; } = 100; // Valeur maximale

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // Dessiner le fond
        g.FillRectangle(new SolidBrush(Color.LightGray), this.ClientRectangle);

        // Dessiner la jauge en fonction de la valeur
        int progressWidth = (int)(this.Width * ((Value - MinValue) / (MaxValue - MinValue)));
        g.FillRectangle(new SolidBrush(Color.Orange), 0, 0, progressWidth, this.Height);

        // Dessiner les bordures
        g.DrawRectangle(Pens.Black, this.ClientRectangle);
    }
}
