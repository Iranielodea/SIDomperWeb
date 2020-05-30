using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIDomper.Win.Componentes
{
    public partial class usrBotoesEdicao : UserControl
    {
        public string Acao { get; set; }

        public usrBotoesEdicao()
        {
            InitializeComponent();
        }

        //public string Acao()
        //{
        //    return _acao;
        //}

        public string BotaoNovo(ref Button butNovo, ref Button butEditar, ref Button butSalvar, ref Button butExcluir, ref Button butCancelar)
        {
            butNovo.Enabled = false;
            butEditar.Enabled = false;
            butExcluir.Enabled = false;
            butSalvar.Enabled = true;
            butCancelar.Enabled = true;
            Acao = "N";
            return "N";
        }

        public string BotaoEditar(ref Button butNovo, ref Button butEditar, ref Button butSalvar, ref Button butExcluir, ref Button butCancelar)
        {
            butNovo.Enabled = false;
            butEditar.Enabled = false;
            butExcluir.Enabled = false;
            butSalvar.Enabled = true;
            butCancelar.Enabled = true;
            Acao = "E";
            return "E";
        }

        public void BotaoSalvar(ref Button butNovo, ref Button butEditar, ref Button butSalvar, ref Button butExcluir, ref Button butCancelar)
        {
            butNovo.Enabled = true;
            butEditar.Enabled = true;
            butExcluir.Enabled = true;
            butSalvar.Enabled = false;
            butCancelar.Enabled = false;
        }

        public void BotaoExcluir(ref Button butNovo, ref Button butEditar, ref Button butSalvar, ref Button butExcluir, ref Button butCancelar)
        {
            butNovo.Enabled = true;
            butEditar.Enabled = true;
            butExcluir.Enabled = true;
            butSalvar.Enabled = false;
            butCancelar.Enabled = false;
        }

        public void BotaoCancelar(ref Button butNovo, ref Button butEditar, ref Button butSalvar, ref Button butExcluir, ref Button butCancelar)
        {
            butNovo.Enabled = true;
            butEditar.Enabled = true;
            butExcluir.Enabled = true;
            butSalvar.Enabled = false;
            butCancelar.Enabled = false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            BotaoNovo(ref btnNovo, ref btnEditar, ref btnSalvar, ref btnExcluir, ref btnCancelar);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            BotaoEditar(ref btnNovo, ref btnEditar, ref btnSalvar, ref btnExcluir, ref btnCancelar);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            BotaoSalvar(ref btnNovo, ref btnEditar, ref btnSalvar, ref btnExcluir, ref btnCancelar);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            BotaoExcluir(ref btnNovo, ref btnEditar, ref btnSalvar, ref btnExcluir, ref btnCancelar);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            BotaoCancelar(ref btnNovo, ref btnEditar, ref btnSalvar, ref btnExcluir, ref btnCancelar);
        }
    }
}
