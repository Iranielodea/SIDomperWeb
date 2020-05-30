using SIDomper.Apresentacao.App;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Utilitarios;
using System;
using System.Windows.Forms;

namespace SIDomper.Win.View
{
    public partial class frmClienteModulo : Form
    {
        public frmClienteModulo()
        {
            InitializeComponent();
            Grade.Configurar(ref dgvDados);
        }

        public frmClienteModulo(int idCliente)
        {
            InitializeComponent();
            Grade.Configurar(ref dgvDados);
            var clienteApp = new ClienteApp();
            var cliente = new ClienteViewModelApi();

            cliente = clienteApp.Editar(Funcoes.IdUsuario, idCliente);
            dgvDados.DataSource = cliente.ClienteModulos;

        }

        private void frmClienteModulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
