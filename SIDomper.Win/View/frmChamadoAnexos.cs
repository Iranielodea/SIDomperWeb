using SIDomper.Apresentacao.App;
using SIDomper.Win.Utilitarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIDomper.Win.View
{
    public partial class frmChamadoAnexos : Form
    {
        private ChamadoApp _chamadoApp;
        public frmChamadoAnexos()
        {
            InitializeComponent();
        }

        public frmChamadoAnexos(int id)
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpSolicitacao);
            Grade.Configurar(ref dgvDados);

            _chamadoApp = new ChamadoApp();
            var lista = _chamadoApp.BuscarAnexos(id, Dominio.Enumeracao.EnumChamado.Chamado);
            if (lista.Count() > 0)
            {
                var model = lista.FirstOrDefault(); //[0];
                string hora = model.HoraAbertura.Hours.ToString("D2") + ":" + model.HoraAbertura.Minutes.ToString("D2");
                txtId.Text = model.Id.ToString(Tela.MaskChamado);
                txtData.Text = model.DataAbertura.ToShortDateString();
                txtHora.Text = hora;
                txtNomeCliente.Text = model.NomeCliente;
                txtContato.Text = model.Contato;

                dgvDados.DataSource = lista;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmChamadoAnexos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
