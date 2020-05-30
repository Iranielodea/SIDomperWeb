using System;
using System.Windows.Forms;

namespace SIDomper.Win.Componentes
{
    public partial class usrData : UserControl
    {
        public usrData()
        {
            InitializeComponent();
        }

        private void txtData_Leave(object sender, EventArgs e)
        {
            if (txtData.Text.Trim() != "/  /")
            {
                try
                {
                    DateTime data = Convert.ToDateTime(txtData.Text);
                    txtData.Text = data.ToString("dd/MM/yyyy");
                }
                catch
                {
                    MessageBox.Show("Data Inválida!");
                    txtData.Focus();
                }
            }
        }
    }
}
