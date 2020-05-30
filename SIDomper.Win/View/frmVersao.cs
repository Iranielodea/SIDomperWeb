using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Base;
using SIDomper.Win.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SIDomper.Win.View
{
    public partial class frmVersao : frmBase
    {
        VersaoApp _versaoApp;
        //VersaoViewModel _versao;
        int _Id;
        List<VersaoConsultaViewModel> _listaConsulta = new List<VersaoConsultaViewModel>();
        GridColunas<VersaoConsultaViewModel> _grid = new GridColunas<VersaoConsultaViewModel>();

        public frmVersao()
        {
            Iniciar();
            ModoPesquisa = false;
        }

        public frmVersao(string texto)
        {
            Iniciar();
            ModoPesquisa = true;
            FiltrarDados(texto);
        }

        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            UsrUsuario.Programa(EnProgramas.Usuario, false, false, "", false);
            UsrTipo.ProgramaTipo(EnProgramas.Tipo, true, true, "", true, EnTipos.Versao);
            UsrStatus.ProgramaStatus(EnProgramas.Status, true, true, "", true, EnStatus.Versao);
            UsrProduto.Programa(EnProgramas.Produto);

            int altura = tpUsuario.Height;
            int largura = tpUsuario.Width;

            ursFiltroStatus.PosicaoTela(altura, largura);
            ursFiltroTipo.PosicaoTela(altura, largura);
            ursFiltroUsuario.PosicaoTela(altura, largura);
            ursFiltroProduto.PosicaoTela(altura, largura);

            Grade.Configurar(ref dgvDados);

            cbCampos.DataSource = Grade.ListarCampos(ref dgvDados);
            cbCampos.SelectedIndex = 1;

            txtCodigo.txtValor.ReadOnly = true;

            StatusModoDesenvolvedor();
        }

        private void StatusModoDesenvolvedor()
        {
            _versaoApp = new VersaoApp();
            var model = _versaoApp.Novo(Funcoes.IdUsuario);
            ursFiltroStatus.txtCodigo.txtValor.Text = model.StatusCodigoParam.ToString();
            ursFiltroStatus.txtNome.Text = model.StatusNomeParam;
            ursFiltroStatus.Adicionar(Filtros.TipoCadastro.StatusGeral);
        }

        private void LimparTela()
        {
            Tela.LimparTela(tbPrincipal);
            UsrUsuario.LimparTela();
            UsrTipo.LimparTela();
            UsrStatus.LimparTela();
            UsrProduto.LimparTela();

            txtCodigo.txtValor.Clear();
            txtDataLib.txtData.Clear();
            txtDataInicio.txtData.Clear();
        }

        public override void Novo()
        {
            try
            {
                _versaoApp = new VersaoApp();
                var model = _versaoApp.Novo(Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(model.Mensagem);

                base.Novo();

                LimparTela();

                UsrUsuario.txtId.Text = model.UsuarioId.ToString();
                UsrUsuario.SetCodigoMask(model.CodUsuario.ToString());
                UsrUsuario.txtNome.Text = model.NomeUsuario;

                txtDataInicio.txtData.Focus();
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
                _versaoApp = new VersaoApp();
                var model = _versaoApp.Editar(Grade.RetornarId(ref dgvDados, "Ver_Id"), Funcoes.IdUsuario);
                btnSalvar.Enabled = Funcoes.PermitirEditar(model.Mensagem);

                base.Editar();

                LimparTela();

                txtCodigo.txtValor.Text = model.Id.ToString(Tela.MaskVersao);
                txtDataInicio.txtData.Text = model.DataInicio.ToShortDateString();
                txtDataLib.txtData.Text = model.DataLiberacao.ToShortDateString();

                UsrUsuario.txtId.Text = model.UsuarioId.ToString();
                UsrUsuario.SetCodigoMask(model.CodUsuario.ToString());
                UsrUsuario.txtNome.Text = model.NomeUsuario;

                if (model.ProdutoId != null)
                {
                    UsrProduto.txtId.Text = model.ProdutoId.ToString();
                    UsrProduto.SetCodigoMask(model.CodProduto.Value.ToString());
                    UsrProduto.txtNome.Text = model.NomeProduto;
                }

                UsrTipo.txtId.Text = model.TipoId.ToString();
                UsrTipo.SetCodigoMask(model.CodTipo.ToString());
                UsrTipo.txtNome.Text = model.NomeTipo;

                UsrStatus.txtId.Text = model.StatusId.ToString();
                UsrStatus.SetCodigoMask(model.CodStatus.ToString());
                UsrStatus.txtNome.Text = model.NomeStatus;

                if (model.ProdutoId != null)
                {
                    UsrProduto.txtId.Text = model.ProdutoId.ToString();
                    UsrProduto.SetCodigoMask(model.CodProduto.Value.ToString());
                    UsrProduto.txtNome.Text = model.NomeProduto;
                }

                txtVersao.Text = model.VersaoStr;
                txtDescricao.Text = model.Descricao;

                txtDataLib.txtData.Focus();
                _Id = model.Id;
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
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "Ver_Id");
                DialogResult = DialogResult.OK;
                base.Pesquisar();
            }
        }

        public override void Filtrar()
        {
            FiltrarDados(txtTexto.Text);
            base.Filtrar();
        }

        public override void Filtro()
        {
            base.Filtro();
            tabControl3.SelectedIndex = 0;
            txtDataInicialFiltro.Focus();
        }

        public override void Excluir()
        {
            base.Excluir();
            if (Funcoes.Confirmar("Confirmar Exclusão?"))
            {
                try
                {
                    _versaoApp = new VersaoApp();
                    int id = Grade.RetornarId(ref dgvDados, "Ver_Id");
                    var model = _versaoApp.Excluir(id, Funcoes.IdUsuario);
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

        private void BuscarDados()
        {
            FiltrarDados(txtTexto.Text);
            cbCampos.Focus();
        }

        private void FiltrarDados(string texto, int id = 0)
        {
            try
            {
                string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

                bool contem = true;
                var filtro = new VersaoFiltroViewModel();
                filtro.Campo = sCampo;
                filtro.Texto = texto;
                filtro.DataInicial = txtDataInicialFiltro.txtData.Text;
                filtro.DataFinal = txtDataFinalFiltro.txtData.Text;
                filtro.DataLiberacaoInicial = txtDataLibInicialFiltro.txtData.Text;
                filtro.DataLiberacaoFinal = txtDataFinalLibFiltro.txtData.Text;

                filtro.UsuarioId = ursFiltroUsuario.RetornarSelecao();
                filtro.ProdutoId = ursFiltroProduto.RetornarSelecao();
                filtro.TipoId = ursFiltroTipo.RetornarSelecao();
                filtro.StatusId = ursFiltroStatus.RetornarSelecao();

                if (id > 0)
                {
                    filtro.Id = id;
                    //filtro.Campo = "Ver_Id";
                    //filtro.Texto = id.ToString();
                }

                contem = cbPesquisa.SelectedIndex == 0;

                _versaoApp = new VersaoApp();

                _listaConsulta = _versaoApp.Filtrar(filtro, contem).ToList();
                dgvDados.DataSource = _listaConsulta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTexto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
                    {
                        BuscarDados();
                        break;
                    }
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
            cbCampos.SelectedIndex = e.ColumnIndex; // - 1;
        }

        private void BuscarObservacoes()
        {
            frmObservacao frmObservacao = new frmObservacao(EnObservacao.Versão);
            if (frmObservacao.ShowDialog() == DialogResult.OK)
            {
                var obsApp = new ObservacaoApp();
                var observacao = obsApp.ObterPorId(Funcoes.IdSelecionado);
                txtDescricao.Text = txtDescricao.Text + " " + observacao.Descricao;
            }
        }

        public override void Salvar()
        {
            try
            {
                if (Funcoes.DataEmBranco(txtDataInicio.txtData.Text))
                    throw new Exception("Informe a Data Início!");
                if (Funcoes.DataEmBranco(txtDataLib.txtData.Text))
                    throw new Exception("Informe a Data Liberação!");

                if (string.IsNullOrEmpty(UsrTipo.txtId.Text))
                    throw new Exception("Informe o Tipo!");
                if (string.IsNullOrEmpty(UsrStatus.txtId.Text))
                    throw new Exception("Informe o Status!");
                if (string.IsNullOrEmpty(txtDescricao.Text))
                    throw new Exception("Informe a Descrição!");

                _versaoApp = new VersaoApp();
                var modelBase = new VersaoViewModel();

                modelBase.Id = _Id;
                modelBase.DataInicio = Funcoes.StrToDate(txtDataInicio.txtData.Text);
                modelBase.DataLiberacao = Funcoes.StrToDate(txtDataLib.txtData.Text);
                modelBase.UsuarioId = Funcoes.StrToInt(UsrUsuario.txtId.Text);
                modelBase.TipoId = Funcoes.StrToInt(UsrTipo.txtId.Text);
                modelBase.StatusId = Funcoes.StrToInt(UsrStatus.txtId.Text);
                modelBase.ProdutoId = Funcoes.StrToIntNull(UsrProduto.txtId.Text);
                modelBase.Descricao = txtDescricao.Text;
                modelBase.VersaoStr = txtVersao.Text;

                if (modelBase.DataInicio > modelBase.DataLiberacao)
                    throw new Exception("Data de Início maior que Data de Liberação!");

                var model = _versaoApp.Salvar(modelBase);

                Funcoes.VerificarMensagem(model.Mensagem);

                FiltrarDados(model.Id.ToString(), model.Id);

                base.Salvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCodTipo_Leave(object sender, EventArgs e)
        {
        }

        private void txtNomeTipo_Leave(object sender, EventArgs e)
        {
        }

        private void btnTipo_Click(object sender, EventArgs e)
        {
        }

        private void txtCodStatus_Leave(object sender, EventArgs e)
        {
        }

        private void txtNomeStatus_Leave(object sender, EventArgs e)
        {
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
        }

        private void txtNomeProduto_Leave(object sender, EventArgs e)
        {
        }

        private void txtCodProduto_Leave(object sender, EventArgs e)
        {
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
        }

        private void frmVersao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (UsrTipo.txtCodigo.txtValor.Focused)
                    UsrTipo.PressionarF9(EnProgramas.Tipo);
                if (UsrStatus.txtCodigo.txtValor.Focused)
                    UsrStatus.PressionarF9(EnProgramas.Status);
                if (UsrProduto.txtCodigo.txtValor.Focused)
                    UsrProduto.PressionarF9(EnProgramas.Produto);
            }
        }

        private void txtDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                BuscarObservacoes();
                return;
            }

            if (e.KeyCode == Keys.F8)
            {
                btnSalvar.Focus();
                Salvar();
                return;
            }

            if (e.KeyCode == Keys.Escape)
                Voltar();
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            this.KeyPreview = false;
        }

        private void tabControl3_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedTab == tpFiltroPrincipal)
            {
                txtDataInicialFiltro.Focus();
            }

            if (tabControl3.SelectedTab == tpUsuario)
            {
                ursFiltroUsuario.TipoDeCadastro(Filtros.TipoCadastro.Usuario);
                ursFiltroUsuario.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpProduto)
            {
                ursFiltroProduto.TipoDeCadastro(Filtros.TipoCadastro.Produto);
                ursFiltroProduto.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpTipo)
            {
                ursFiltroTipo.TipoDeCadastro(Filtros.TipoCadastro.Tipo, EnStatus.Versao, EnTipos.Versao);
                ursFiltroTipo.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpStatus)
            {
                ursFiltroStatus.TipoDeCadastro(Filtros.TipoCadastro.Status, EnStatus.Versao, EnTipos.Versao);
                ursFiltroStatus.txtCodigo.txtValor.Focus();
            }
        }
    }
}
