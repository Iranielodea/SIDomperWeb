using SIDomper.Apresentacao.App;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Base;
using SIDomper.Win.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SIDomper.Win.View
{
    public partial class frmContaEmail : frmBase
    {
        ContaEmailApp _contaEmailApp;
        int _Id;
        List<ContaEmailConsultaViewModel> _listaConsulta = new List<ContaEmailConsultaViewModel>();
        GridColunas<ContaEmailConsultaViewModel> _grid = new GridColunas<ContaEmailConsultaViewModel>();

        public frmContaEmail()
        {
            Iniciar();
            FiltrarDados("ABCDE");
            ModoPesquisa = false;
        }

        public frmContaEmail(string texto)
        {
            Iniciar();
            FiltrarDados(texto);
            ModoPesquisa = true;
        }

        private void Iniciar()
        {
            InitializeComponent();

            txtPorta.txtValor.TextAlign = HorizontalAlignment.Left;
            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            Grade.Configurar(ref dgvDados);
            lblAtivo.Visible = false;
            cboAtivo.Visible = false;

            cbCampos.DataSource = Grade.ListarCampos(ref dgvDados);
            cbCampos.SelectedIndex = 1;
            cbPesquisa.Enabled = false;
        }

        private void FiltrarDados(string texto)
        {
            string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

            _contaEmailApp = new ContaEmailApp();
            string ativo = cboAtivo.Text;

            _listaConsulta = _contaEmailApp.Filtrar(sCampo, texto).ToList();
            dgvDados.DataSource = _listaConsulta;
        }

        public override void Novo()
        {
            txtCodigo.txtValor.ReadOnly = false;
            try
            {
                _contaEmailApp = new ContaEmailApp();
                var model = _contaEmailApp.Novo(Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(model.Mensagem);

                base.Novo();

                Tela.LimparTela(tbPrincipal);
                txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                chkAtivo.Checked = true;
                chkAutenticar.Checked = true;
                chkAutenticarSSL.Checked = true;
                txtCodigo.txtValor.ReadOnly = false;
                txtPorta.txtValor.Clear();

                txtCodigo.txtValor.Focus();
                _Id = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                _contaEmailApp = new ContaEmailApp();
                var model = _contaEmailApp.Editar(RetornarId(), Funcoes.IdUsuario);
                btnSalvar.Enabled = Funcoes.PermitirEditar(model.Mensagem);

                base.Editar();

                Tela.LimparTela(tbPrincipal);

                txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                txtNome.Text = model.Nome;
                txtEmail.Text = model.Email;
                txtPorta.txtValor.Text = model.Porta.ToString();
                txtSenha.Text = model.Senha;
                txtSMTP.Text = model.SMTP;

                chkAtivo.Checked = model.Ativo;
                chkAutenticar.Checked = model.Autenticar;
                chkAutenticarSSL.Checked = model.AutenticarSSL;
                txtCodigo.txtValor.ReadOnly = false;

                txtNome.Focus();
                _Id = model.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void Filtrar()
        {
            FiltrarDados(txtTexto.Text);
            base.Filtrar();
        }

        public override void Excluir()
        {
            base.Excluir();
            if (Funcoes.Confirmar("Confirmar Exclusão?"))
            {
                try
                {
                    _contaEmailApp = new ContaEmailApp();
                    int id = RetornarId();
                    var model = _contaEmailApp.Excluir(id, Funcoes.IdUsuario);
                    Funcoes.VerificarMensagem(model.Mensagem);

                    _listaConsulta.Remove(_listaConsulta.First(x => x.Id == id));
                    dgvDados.DataSource = _listaConsulta.ToArray();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public override void Salvar()
        {
            try
            {
                _contaEmailApp = new ContaEmailApp();
                var contaEmail = new ContaEmailViewModel();
                contaEmail.Id = _Id;
                contaEmail.Codigo = Funcoes.StrToInt(txtCodigo.txtValor.Text);
                contaEmail.Nome = txtNome.Text;
                contaEmail.Ativo = chkAtivo.Checked;
                contaEmail.Autenticar = chkAutenticar.Checked;
                contaEmail.AutenticarSSL = chkAutenticarSSL.Checked;
                contaEmail.Email = txtEmail.Text;
                contaEmail.Porta = Funcoes.StrToInt(txtPorta.txtValor.Text);
                contaEmail.Senha = txtSenha.Text;
                contaEmail.SMTP = txtSMTP.Text;

                var model = _contaEmailApp.Salvar(contaEmail);
                Funcoes.VerificarMensagem(model.Mensagem);

                _listaConsulta = _contaEmailApp.Filtrar("CtaEm_Id", model.Id.ToString(), "T", false).ToList();
                dgvDados.DataSource = _listaConsulta;

                base.Salvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void Pesquisar()
        {
            if (dgvDados.RowCount > 0 && ModoPesquisa)
            {
                Funcoes.IdSelecionado = RetornarId();
                DialogResult = DialogResult.OK;
                base.Pesquisar();
            }
        }

        private void BuscarDados()
        {
            FiltrarDados(txtTexto.Text);
            cbCampos.Focus();
        }

        private int RetornarId()
        {
            return Grade.RetornarId(ref dgvDados, "CtaEm_Id");
        }

        private void txtTexto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
                    BuscarDados();
                    break;
                case Keys.Down:
                    Grade.ProximoRegistro(ref dgvDados);
                    break;
                case Keys.Up:
                    Grade.RegistroAnterior(ref dgvDados);
                    break;
            }
        }

        private void dgvDados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _grid.OrdenarColunas(ref dgvDados, _listaConsulta, e);
            cbCampos.SelectedIndex = e.ColumnIndex - 1;
        }
    }
}
