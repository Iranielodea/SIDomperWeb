using SIDomper.Dominio.Enumeracao;
using SIDomper.Win.Pesquisas;
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
    public partial class frmTrocaStatus : Form
    {
        EnStatus _enStatus;
        EnTipos _enTipos;

        public frmTrocaStatus()
        {
            InitializeComponent();
        }

        public frmTrocaStatus(EnStatus enStatus, EnTipos enTipos)
        {
            _enStatus = enStatus;
            _enTipos = enTipos;

            InitializeComponent();
        }

        private void Confirmar()
        {
            Close();
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Confirmar();
        }

        private void ConsultarTipo(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaTipo();
            try
            {
                if (tipoPesquisa != TipoPesquisa.Tela)
                {
                    txtIdTipo.Text = "";
                    txtCodTipo.txtValor.Text = "";
                    txtNomeTipo.Text = "";
                }
                var model = consulta.Pesquisar(codigo, nome, tipoPesquisa, _enTipos);
                if (model != null)
                {
                    txtIdTipo.Text = model.Id.ToString();
                    txtCodTipo.txtValor.Text = model.Codigo.ToString("0000");
                    txtNomeTipo.Text = model.Nome;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtCodTipo.Focus();
            }
            txtIdTipo.Modified = false;
            txtCodTipo.txtValor.Modified = false;
            txtNomeTipo.Modified = false;
        }

        private void ConsultarStatus(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaStatus();
            try
            {
                if (tipoPesquisa != TipoPesquisa.Tela)
                {
                    txtIdStatus.Text = "";
                    txtCodStatus.txtValor.Text = "";
                    txtNomeStatus.Text = "";
                }
                var model = consulta.Pesquisar(codigo, nome, tipoPesquisa, _enStatus);
                if (model != null)
                {
                    txtIdStatus.Text = model.Id.ToString();
                    txtCodStatus.txtValor.Text = model.Codigo.ToString("0000");
                    txtNomeStatus.Text = model.Nome;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtCodStatus.Focus();
            }
            txtIdStatus.Modified = false;
            txtCodStatus.txtValor.Modified = false;
            txtNomeStatus.Modified = false;
        }

        private void txtCodTipo_Leave(object sender, EventArgs e)
        {
            if (txtCodTipo.txtValor.Modified)
                ConsultarTipo(Funcoes.StrToInt(txtCodTipo.txtValor.Text), txtNomeTipo.Text, TipoPesquisa.Id);
        }

        private void txtNomeTipo_Leave(object sender, EventArgs e)
        {
            if (txtNomeTipo.Modified)
                ConsultarTipo(Funcoes.StrToInt(txtCodTipo.txtValor.Text), txtNomeTipo.Text, TipoPesquisa.Descricao);
        }

        private void btnTipo_Click(object sender, EventArgs e)
        {
            ConsultarTipo(Funcoes.StrToInt(txtCodTipo.txtValor.Text), txtNomeTipo.Text, TipoPesquisa.Tela);
            txtNomeTipo.Focus();
        }

        private void txtCodStatus_Leave(object sender, EventArgs e)
        {
            if (txtCodStatus.txtValor.Modified)
                ConsultarStatus(Funcoes.StrToInt(txtCodStatus.txtValor.Text), txtNomeStatus.Text, TipoPesquisa.Id);
        }

        private void txtNomeStatus_Leave(object sender, EventArgs e)
        {
            if (txtNomeStatus.Modified)
                ConsultarStatus(Funcoes.StrToInt(txtCodStatus.txtValor.Text), txtNomeStatus.Text, TipoPesquisa.Descricao);
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            ConsultarStatus(Funcoes.StrToInt(txtCodStatus.txtValor.Text), txtNomeStatus.Text, TipoPesquisa.Tela);
            txtNomeStatus.Focus();
        }

        private void frmTrocaStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void frmTrocaStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (txtCodTipo.txtValor.Focused)
                    btnTipo_Click(sender, e);
                if (txtCodStatus.txtValor.Focused)
                    btnStatus_Click(sender, e);
            }

            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void frmTrocaStatus_Shown(object sender, EventArgs e)
        {
            if (txtIdTipo.Text == "")
            {
                lblTipo.Visible = false;
                txtCodTipo.Visible = false;
                txtNomeTipo.Visible = false;
            }
        }
    }
}
