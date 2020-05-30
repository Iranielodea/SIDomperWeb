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
    public partial class frmBaseConhecimento : frmBase
    {
        BaseConhApp _baseConhApp;
        int _Id;
        List<BaseConhConsultaViewModel> _listaConsulta = new List<BaseConhConsultaViewModel>();
        GridColunas<BaseConhConsultaViewModel> _grid = new GridColunas<BaseConhConsultaViewModel>();

        public frmBaseConhecimento()
        {
            Iniciar();
        }

        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            UsrUsuario.Programa(EnProgramas.Usuario, false, false, "", false);
            UsrModulo.Programa(EnProgramas.Modulo);
            UsrProduto.Programa(EnProgramas.Produto);
            UsrTipo.ProgramaTipo(EnProgramas.Tipo, true, true, "", true, EnTipos.BaseConhecimento);
            UsrStatus.ProgramaStatus(EnProgramas.Status, true, true, "", true, EnStatus.BaseConhecimento);

            int altura = tpUsuario.Height;
            int largura = tpUsuario.Width;

            ursFiltroStatus.PosicaoTela(altura, largura);
            ursFiltroTipo.PosicaoTela(altura, largura);
            ursFiltroUsuario.PosicaoTela(altura, largura);
            ursFiltroModulo.PosicaoTela(altura, largura);

            Grade.Configurar(ref dgvDados);

            cbCampos.DataSource = Grade.ListarCampos(ref dgvDados);
            cbCampos.SelectedIndex = 2;
            txtCodigo.txtValor.ReadOnly = true;
        }

        private void LimparTela()
        {
            Tela.LimparTela(tbPrincipal);

            UsrUsuario.LimparTela();
            UsrModulo.LimparTela();
            UsrProduto.LimparTela();
            UsrTipo.LimparTela();
            UsrStatus.LimparTela();
        }

        public override void Novo()
        {
            try
            {
                _baseConhApp = new BaseConhApp();
                var model = _baseConhApp.Novo(Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(model.Mensagem);

                base.Novo();

                tabControl2.SelectedIndex = 0;

                LimparTela();

                UsrUsuario.txtId.Text = model.UsuarioId.ToString();
                UsrUsuario.txtCodigo.txtValor.Text = model.CodUsuario.ToString("0000");
                UsrUsuario.txtNome.Text = model.NomeUsuario;

                UsrTipo.txtId.Text = model.TipoId.ToString();
                UsrTipo.txtCodigo.txtValor.Text = model.CodTipo.ToString("0000");
                UsrTipo.txtNome.Text = model.NomeTipo;

                txtData.txtData.Text = model.Data.ToString();

                txtData.txtData.Focus();
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
                _baseConhApp = new BaseConhApp();
                var model = _baseConhApp.Editar(Grade.RetornarId(ref dgvDados, "Bas_Id"), Funcoes.IdUsuario);
                btnSalvar.Enabled = Funcoes.PermitirEditar(model.Mensagem);

                base.Editar();

                LimparTela();
                tabControl2.SelectedIndex = 0;                

                txtCodigo.txtValor.Text = model.Id.ToString("000000");
                txtData.txtData.Text = model.Data.ToString();
                txtNome.Text = model.Nome;

                UsrUsuario.txtId.Text = model.UsuarioId.ToString();
                UsrUsuario.txtCodigo.txtValor.Text = model.CodUsuario.ToString("0000");
                UsrUsuario.txtNome.Text = model.NomeUsuario;

                if (model.ModuloId != null)
                {
                    UsrModulo.txtId.Text = model.ModuloId.ToString();
                    UsrModulo.txtCodigo.txtValor.Text = model.CodModulo.ToString("0000");
                    UsrModulo.txtNome.Text = model.NomeModulo;
                }

                if (model.ProdutoId != null)
                {
                    UsrProduto.txtId.Text = model.ProdutoId.ToString();
                    UsrProduto.txtCodigo.txtValor.Text = model.CodProduto.Value.ToString("0000");
                    UsrProduto.txtNome.Text = model.NomeProduto;
                }

                UsrTipo.txtId.Text = model.TipoId.ToString();
                UsrTipo.txtCodigo.txtValor.Text = model.CodTipo.ToString("0000");
                UsrTipo.txtNome.Text = model.NomeTipo;

                UsrStatus.txtId.Text = model.StatusId.ToString();
                UsrStatus.txtCodigo.txtValor.Text = model.CodStatus.ToString("0000");
                UsrStatus.txtNome.Text = model.NomeStatus;

                txtAnexo.Text = model.Anexo;
                txtDescricao.Text = model.Descricao;

                txtNome.Focus();
                _Id = model.Id;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            txtDataInicial.Focus();
        }

        public override void Excluir()
        {
            base.Excluir();
            if (Funcoes.Confirmar("Confirmar Exclusão?"))
            {
                try
                {
                    _baseConhApp = new BaseConhApp();
                    int id = Grade.RetornarId(ref dgvDados, "Bas_Id");
                    var model = _baseConhApp.Excluir(id, Funcoes.IdUsuario);
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
                if (string.IsNullOrEmpty(txtNome.Text))
                    throw new Exception("Informe o Nome!");
                if (string.IsNullOrEmpty(UsrTipo.txtId.Text))
                    throw new Exception("Informe o Tipo!");
                if (string.IsNullOrEmpty(UsrStatus.txtId.Text))
                    throw new Exception("Informe o Status!");
                if (string.IsNullOrEmpty(txtDescricao.Text))
                    throw new Exception("Informe a Descrição!");

                _baseConhApp = new BaseConhApp();
                var modelBase = new BaseConhViewModel();
               
                modelBase.Id = _Id;
                modelBase.Anexo = txtAnexo.Text;
                modelBase.Data = Funcoes.StrToDate(txtData.txtData.Text);
                modelBase.Nome = txtNome.Text;
                modelBase.UsuarioId = Funcoes.StrToInt(UsrUsuario.txtId.Text);
                modelBase.ModuloId = Funcoes.StrToIntNull(UsrModulo.txtId.Text);
                modelBase.ProdutoId = Funcoes.StrToIntNull(UsrProduto.txtId.Text);
                modelBase.TipoId = Funcoes.StrToInt(UsrTipo.txtId.Text);
                modelBase.StatusId = Funcoes.StrToInt(UsrStatus.txtId.Text);
                modelBase.Descricao = txtDescricao.Text;

                var model = _baseConhApp.Salvar(modelBase);

                Funcoes.VerificarMensagem(model.Mensagem);

                FiltrarDados(model.Id.ToString(), model.Id);

                base.Salvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FiltrarDados(string texto, int id = 0)
        {
            try
            {
                string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

                var filtro = new BaseConhecimentoFiltroViewModel();
                filtro.Campo = sCampo;
                filtro.Texto = texto;
                filtro.DataInicial = txtDataInicial.txtData.Text;
                filtro.DataFinal = txtDataFinal.txtData.Text;
                filtro.UsuarioId = ursFiltroUsuario.RetornarSelecao();
                filtro.ModuloId = ursFiltroModulo.RetornarSelecao();
                filtro.TipoId = ursFiltroTipo.RetornarSelecao();
                filtro.StatusId = ursFiltroStatus.RetornarSelecao();

                if (id > 0)
                {
                    filtro.Campo = "Bas_Id";
                    filtro.Texto = id.ToString();
                }

                _baseConhApp = new BaseConhApp();

                _listaConsulta = _baseConhApp.Filtrar(filtro, Funcoes.IdUsuario, cbPesquisa.SelectedIndex == 0).ToList();
                dgvDados.DataSource = _listaConsulta;
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
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "Bas_Id");
                DialogResult = DialogResult.OK;
                base.Pesquisar();
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

        private void BuscarDados()
        {
            FiltrarDados(txtTexto.Text);
            cbCampos.Focus();
        }

        private void dgvDados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _grid.OrdenarColunas(ref dgvDados, _listaConsulta, e);
            cbCampos.SelectedIndex = e.ColumnIndex; // - 1;
        }

        private void frmBaseConhecimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (UsrModulo.txtCodigo.txtValor.Focused)
                    UsrModulo.PressionarF9(EnProgramas.Modulo);
                if (UsrProduto.txtCodigo.txtValor.Focused)
                    UsrProduto.PressionarF9(EnProgramas.Produto);
                if (UsrTipo.txtCodigo.txtValor.Focused)
                    UsrTipo.PressionarF9(EnProgramas.Tipo);
                if (UsrStatus.txtCodigo.txtValor.Focused)
                    UsrStatus.PressionarF9(EnProgramas.Status);

                if (tabControl3.SelectedTab == tpUsuario)
                    ursFiltroUsuario.AbrirTela();
                else if (tabControl3.SelectedTab == tpModulo)
                    ursFiltroModulo.AbrirTela();
                if (tabControl3.SelectedTab == tpTipo)
                    ursFiltroTipo.AbrirTela();
                if (tabControl3.SelectedTab == tpStatus)
                    ursFiltroStatus.AbrirTela();
            }
        }

        private void btnAnexar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtAnexo.Text = openFileDialog.FileName;
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (txtAnexo.Text.Trim() == "")
            {
                MessageBox.Show("Não arquivo para visualizar!");
                return;
            }
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = txtAnexo.Text;
            System.Diagnostics.Process.Start(startInfo);
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            this.KeyPreview = false;
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        public override void Voltar()
        {
            base.Voltar();
        }

        private void txtDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                btnSalvar.Focus();
                Salvar();
                return;
            }

            if (e.KeyCode == Keys.F9)
            {
                BuscarObservacoes();
                return;
            }

            if (e.KeyCode == Keys.Escape)
                Voltar();
        }

        private void tabControl3_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedTab == tpFiltroPrincipal)
            {
                txtDataInicial.Focus();
            }

            if (tabControl3.SelectedTab == tpUsuario)
            {
                ursFiltroUsuario.TipoDeCadastro(Filtros.TipoCadastro.Usuario);
                ursFiltroUsuario.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpModulo)
            {
                ursFiltroModulo.TipoDeCadastro(Filtros.TipoCadastro.Modulo);
                ursFiltroModulo.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpTipo)
            {
                ursFiltroTipo.TipoDeCadastro(Filtros.TipoCadastro.Tipo, EnStatus.BaseConhecimento, EnTipos.BaseConhecimento);
                ursFiltroTipo.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpStatus)
            {
                ursFiltroStatus.TipoDeCadastro(Filtros.TipoCadastro.Status, EnStatus.BaseConhecimento, EnTipos.BaseConhecimento);
                ursFiltroStatus.txtCodigo.txtValor.Focus();
            }
        }

        private void BuscarObservacoes()
        {
            frmObservacao frmObservacao = new frmObservacao(EnObservacao.BaseConhecimento);
            if (frmObservacao.ShowDialog() == DialogResult.OK)
            {
                var obsApp = new ObservacaoApp();
                var observacao = obsApp.ObterPorId(Funcoes.IdSelecionado);
                txtDescricao.Text = txtDescricao.Text + " " + observacao.Descricao;
            }
        }

        private void AbrirDetalhes(int id)
        {
            frmBaseConhecimentoDetalhe formulario = new frmBaseConhecimentoDetalhe(id, EnProgramas.BaseConh);
            formulario.ShowDialog();
        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCodigo.txtValor.Text))
                AbrirDetalhes(int.Parse(txtCodigo.txtValor.Text));
        }

        private void btnDetalhes2_Click(object sender, EventArgs e)
        {
            if (dgvDados.Rows.Count > 0)
                AbrirDetalhes(Grade.RetornarId(ref dgvDados, "Bas_Id"));
        }
    }
}
