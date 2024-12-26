using System;
using System.Windows.Forms;

namespace Jauge_TP1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSetValue_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtValeur.Text, out float newValue))
            {
                if (newValue >= dialGauge.Min && newValue <= dialGauge.Max)
                {
                    dialGauge.Value = newValue;
                    dialGauge.Invalidate(); // Redessiner la jauge
                }
                else
                {
                    MessageBox.Show("Veuillez entrer une valeur entre " + dialGauge.Min + " et " + dialGauge.Max);
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer une valeur numérique valide.");
            }
        }
    }
}
