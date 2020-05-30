using System;
using System.Windows.Forms;

namespace SIDomper.Win.Componentes
{
    public partial class usrValor : UserControl
    {
        public usrValor()
        {
            InitializeComponent();
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal valorRetorno = 0;
                decimal.TryParse(txtValor.Text, out valorRetorno);
                txtValor.Text = valorRetorno.ToString("N2");
            }
            catch
            {
                txtValor.Text = "0,00";
            }
        }
    }
}
