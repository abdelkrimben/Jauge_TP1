using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jauge_TP1
{
    public partial class GaugeControl : UserControl
    {
        private float _value = 50;
        private float _minValue = 0;
        private float _maxValue = 100;

        private int _noOfDivisions = 10;
        private int _noOfSubDivisions = 5;

        private string _dialText = "Jauge";
        private Color _dialColor = Color.LightBlue;

        public GaugeControl()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Meilleure performance pour le dessin
        }

        // Propriétés
        public float Value
        {
            get { return _value; }
            set
            {
                if (value >= _minValue && value <= _maxValue)
                {
                    _value = value;
                    this.Refresh();
                }
            }
        }

        public float MinValue
        {
            get { return _minValue; }
            set { _minValue = value; this.Refresh(); }
        }

        public float MaxValue
        {
            get { return _maxValue; }
            set { _maxValue = value; this.Refresh(); }
        }

        public int NoOfDivisions
        {
            get { return _noOfDivisions; }
            set { _noOfDivisions = value; this.Refresh(); }
        }

        public int NoOfSubDivisions
        {
            get { return _noOfSubDivisions; }
            set { _noOfSubDivisions = value; this.Refresh(); }
        }

        public string DialText
        {
            get { return _dialText; }
            set { _dialText = value; this.Refresh(); }
        }

        public Color DialColor
        {
            get { return _dialColor; }
            set { _dialColor = value; this.Refresh(); }
        }

        // Dessiner la jauge
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Définir la zone de la jauge
            Rectangle rect = new Rectangle(10, 10, this.Width - 20, this.Height - 20);
            g.FillRectangle(new SolidBrush(_dialColor), rect);

            // Tracer les divisions principales
            Pen blackPen = new Pen(Color.Black, 2);
            int centerY = this.Height / 2;
            int startX = 20;
            int endX = this.Width - 20;
            int divisionWidth = (endX - startX) / _noOfDivisions;

            for (int i = 0; i <= _noOfDivisions; i++)
            {
                int x = startX + i * divisionWidth;
                g.DrawLine(blackPen, x, centerY - 10, x, centerY + 10);

                // Afficher les valeurs
                float divisionValue = _minValue + i * ((_maxValue - _minValue) / _noOfDivisions);
                string valueText = divisionValue.ToString("0");
                SizeF textSize = g.MeasureString(valueText, this.Font);
                g.DrawString(valueText, this.Font, Brushes.Black, x - textSize.Width / 2, centerY + 15);
            }

            // Dessiner l'indicateur
            float percentage = (_value - _minValue) / (_maxValue - _minValue);
            int indicatorX = startX + (int)(percentage * (endX - startX));
            Brush indicatorBrush = new SolidBrush(Color.OrangeRed);
            g.FillRectangle(indicatorBrush, indicatorX - 10, centerY - 20, 20, 40);

            // Ajouter le texte au centre
            SizeF dialTextSize = g.MeasureString(_dialText, this.Font);
            g.DrawString(_dialText, this.Font, Brushes.Black, this.Width / 2 - dialTextSize.Width / 2, 10);
        }
    }
}
