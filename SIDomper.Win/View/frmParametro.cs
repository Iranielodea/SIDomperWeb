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
    public partial class frmParametro : frmBase
    {
        ParametroApp _parametroApp;
        int _Id;
        List<ParametroConsultaViewModel> _listaConsulta = new List<ParametroConsultaViewModel>();
        GridColunas<ParametroConsultaViewModel> _grid = new GridColunas<ParametroConsultaViewModel>();

        public frmParametro()
        {
            Iniciar();
            FiltrarDados("ABCDE");
            ModoPesquisa = false;
        }

        public frmParametro(string texto)
        {
            Iniciar();
            FiltrarDados(texto);
            ModoPesquisa = true;
        }

        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            Grade.Configurar(ref dgvDados);
            lblAtivo.Visible = false;
            cboAtivo.Visible = false;

            cbCampos.DataSource = Grade.ListarCampos(ref dgvDados);
            cbCampos.SelectedIndex = 2;
            cbPesquisa.Enabled = false;
        }

        private void FiltrarDados(string texto)
        {
            string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

            _parametroApp = new ParametroApp();
            string ativo = cboAtivo.Text;

            _listaConsulta = _parametroApp.Filtrar(sCampo, texto).ToList();
            dgvDados.DataSource = _listaConsulta;
        }

        public override void Novo()
        {
            txtCodigo.txtValor.ReadOnly = false;
            try
            {
                _parametroApp = new ParametroApp();
                var model = _parametroApp.Novo(Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(model.Mensagem);

                base.Novo();

                Tela.LimparTela(tbPrincipal);
                txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                txtCodigo.txtValor.ReadOnly = false;

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
                _parametroApp = new ParametroApp();
                var model = _parametroApp.Editar(RetornarId(), Funcoes.IdUsuario);
                btnSalvar.Enabled = Funcoes.PermitirEditar(model.Mensagem);

                base.Editar();

                Tela.LimparTela(tbPrincipal);

                txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                txtNome.Text = model.Nome;
                txtObservacao.Text = model.Observacao;
                txtPrograma.Text = Funcoes.IntNullToStr(model.Programa);
                txtValor.Text = model.Valor;

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
                    _parametroApp = new ParametroApp();
                    int id = RetornarId();
                    var model = _parametroApp.Excluir(id, Funcoes.IdUsuario);
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
                _parametroApp = new ParametroApp();
                var parametro = new ParametroViewModel();
                parametro.Id = _Id;
                parametro.Codigo = Funcoes.StrToInt(txtCodigo.txtValor.Text);
                parametro.Nome = txtNome.Text;
                parametro.Observacao = txtObservacao.Text;
                parametro.Programa = Funcoes.StrToIntNull(txtPrograma.Text);
                parametro.Valor = txtValor.Text;

                var model = _parametroApp.Salvar(parametro);
                Funcoes.VerificarMensagem(model.Mensagem);

                _listaConsulta = _parametroApp.Filtrar("Par_Id", model.Id.ToString(), false).ToList();
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
            return Grade.RetornarId(ref dgvDados, "Par_Id");
        }

        private void TeclasAtalho(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    base.Voltar();
                    break;
                case Keys.F8:
                    Salvar();
                    break;
            }
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

        private void txtObservacao_Enter(object sender, EventArgs e)
        {
            this.KeyPreview = false;
        }

        private void txtObservacao_Leave(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void txtObservacao_KeyDown(object sender, KeyEventArgs e)
        {
            TeclasAtalho(e);
        }
    }
}
