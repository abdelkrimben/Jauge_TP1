using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Jauge_TP1
{
    public class DialGauge : Control
    {
        public float Value { get; set; } = 50; // Valeur actuelle
        public float Min { get; set; } = 0;   // Valeur minimale
        public float Max { get; set; } = 100; // Valeur maximale

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Dégradé pour le fond
            Rectangle backgroundRect = new Rectangle(10, 10, this.Width - 20, this.Height - 20);
            using (GraphicsPath fondFormBackground = FondFormShape(backgroundRect))
            using (LinearGradientBrush backgroundBrush = new LinearGradientBrush(backgroundRect, Color.FromArgb(245, 250, 255), Color.FromArgb(100, 120, 150), LinearGradientMode.Vertical))
            {
                g.FillPath(backgroundBrush, fondFormBackground);
                g.DrawPath(new Pen(Color.Gray, 2), fondFormBackground);
            }

            // Flèches et graduations
            float gaugeWidth = backgroundRect.Width - 80;
            float step = gaugeWidth / 8f; // Intervalle pour les graduations
            float yGraduation = backgroundRect.Top + 90; // Position des graduations
            float barYPosition = yGraduation + 15; // Position de la barre

            for (int i = 0; i <= 8; i++)
            {
                float x = backgroundRect.Left + 40 + (i * step);

                if (i % 4 == 0) // Fleches principales
                {
                    Point[] arrow = {
                        new Point((int)x - 7, (int)yGraduation - 5),
                        new Point((int)x + 7, (int)yGraduation - 5),
                        new Point((int)x, (int)yGraduation + 5)
                    };
                    g.FillPolygon(Brushes.Black, arrow);

                    // Valeurs principales
                    string label = (Min + (i / 4 * (Max - Min) / 2)).ToString();
                    g.DrawString(label, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, x - 15, yGraduation - 40);
                }
                else // Graduations intermediaires
                {
                    g.DrawLine(Pens.Black, x, yGraduation - 5, x, yGraduation);
                }
            }

            // Barre de proression
            float range = Max - Min;
            float position = (Value - Min) / range * gaugeWidth;
            RectangleF fullBar = new RectangleF(backgroundRect.Left + 40, barYPosition, gaugeWidth, 25);
            RectangleF filledPart = new RectangleF(backgroundRect.Left + 40, barYPosition, position, 25);

            // Dégradé blanc (effet 3D)
            using (GraphicsPath fullPath = RoundedRect(fullBar, 12))
            using (LinearGradientBrush whiteBrush = new LinearGradientBrush(fullBar, Color.FromArgb(245, 245, 245), Color.White, LinearGradientMode.Vertical))
            {
                g.FillPath(whiteBrush, fullPath);
            }

            // Dégradé orange (effet 3D)
            using (GraphicsPath filledPath = RoundedRect(filledPart, 12))
            using (LinearGradientBrush redOrangeBrush = new LinearGradientBrush(filledPart, Color.FromArgb(255, 170, 120), Color.FromArgb(255, 70, 50), LinearGradientMode.Vertical))
            {
                g.FillPath(redOrangeBrush, filledPath);
            }
        }

        // Forme du fond
        private GraphicsPath FondFormShape(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();

            // Définir la forme
            int arcWidth = 30;
            path.AddArc(rect.Left, rect.Top, arcWidth, rect.Height, 90, 180);
            path.AddLine(rect.Left + arcWidth / 2, rect.Top, rect.Right - arcWidth / 2, rect.Top);
            path.AddArc(rect.Right - arcWidth, rect.Top, arcWidth, rect.Height, 270, 180);
            path.AddLine(rect.Right - arcWidth / 2, rect.Bottom, rect.Left + arcWidth / 2, rect.Bottom);
            path.CloseFigure();

            return path;
        }

        // Forme arrondie pour les rectangles
        private GraphicsPath RoundedRect(RectangleF rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2;

            // Coins arrondis
            path.AddArc(rect.Left, rect.Top, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Top, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
