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
    public partial class frmClienteEspecificacao : frmBase
    {
        ClienteEspecificacaoApp _clienteEspecificacaoApp;
        int _Id;
        int _idCliente;
        ClienteEspecificacaoViewModel _clienteEspecificacao;
        List<ClienteEspecificacaoViewModel> _listaConsulta = new List<ClienteEspecificacaoViewModel>();
        GridColunas<ClienteEspecificacaoViewModel> _grid = new GridColunas<ClienteEspecificacaoViewModel>();

        public frmClienteEspecificacao()
        {
            Iniciar();
            ModoPesquisa = false;
        }

        public frmClienteEspecificacao(int idCliente)
        {
            Iniciar();

            _idCliente = idCliente;
            FiltrarDados(idCliente);
            ModoPesquisa = true;

            label2.Visible = false;
            txtTexto.Visible = false;
            label1.Visible = false;
            cbCampos.Visible = false;
        }

        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            UsrUsuario.Programa(EnProgramas.Usuario, true);

            Grade.Configurar(ref dgvDados);

            cbCampos.DataSource = Grade.ListarCampos(ref dgvDados);
            cbCampos.SelectedIndex = 1;
            txtCodigo.txtValor.Enabled = false;
            lblPesquisa.Visible = false;
            cbPesquisa.Visible = false;
        }

        private void FiltrarDados(int idCliente)
        {
            string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

            _clienteEspecificacaoApp = new ClienteEspecificacaoApp();
            string ativo = cboAtivo.Text;
            _listaConsulta = _clienteEspecificacaoApp.Filtrar(idCliente).ToList();
            dgvDados.DataSource = _listaConsulta;
        }

        private int ProximoItem()
        {
            try
            {
                return _listaConsulta.Max(x => x.Item) + 1;
            }
            catch
            {
                return 1;
            }
        }

        public override void Novo()
        {
            txtCodigo.txtValor.ReadOnly = false;
            try
            {
                _clienteEspecificacaoApp = new ClienteEspecificacaoApp();
                var model = _clienteEspecificacaoApp.Novo(Funcoes.IdUsuario);
                txtData.txtData.Text = model.Data.ToShortDateString();
                //Funcoes.VerificarMensagem(model.Mensagem);

                base.Novo();

                _clienteEspecificacao = new ClienteEspecificacaoViewModel();
                VincularDados();
                Tela.LimparTela(tbPrincipal);
                txtCodigo.txtValor.Text = ProximoItem().ToString("0000");
                UsrUsuario.txtId.Clear();
                UsrUsuario.txtCodigo.txtValor.Clear();
                UsrUsuario.txtNome.Clear();
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
                _clienteEspecificacaoApp = new ClienteEspecificacaoApp();
                _clienteEspecificacao = _clienteEspecificacaoApp.ObterPorId(Grade.RetornarId(ref dgvDados, "Id"));

                base.Editar();

                Tela.LimparTela(tbPrincipal);

                VincularDados();
                txtCodigo.txtValor.Text = _clienteEspecificacao.Item.ToString("0000");
                txtData.txtData.Text = _clienteEspecificacao.Data.ToString();

                UsrUsuario.txtId.Text = _clienteEspecificacao.UsuarioId.ToString();
                UsrUsuario.txtCodigo.txtValor.Text = _clienteEspecificacao.CodUsuario.ToString("0000");
                UsrUsuario.txtNome.Text = _clienteEspecificacao.NomeUsuario;

                txtNome.Focus();
                _Id = _clienteEspecificacao.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void VincularDados()
        {
            Tela.Binding(ref txtNome, _clienteEspecificacao, "Nome");
            Tela.Binding(ref txtDescricao, _clienteEspecificacao, "Descricao");
            Tela.Binding(ref txtNomeArquivo, _clienteEspecificacao, "Anexo");
        }

        public override void Filtrar()
        {
            //FiltrarDados(txtTexto.Text);
            base.Filtrar();
        }

        public override void Excluir()
        {
            base.Excluir();
            if (Funcoes.Confirmar("Confirmar Exclusão?"))
            {
                try
                {
                    _clienteEspecificacaoApp = new ClienteEspecificacaoApp();
                    int id = Grade.RetornarId(ref dgvDados, "Id");
                    var model = _clienteEspecificacaoApp.Excluir(id, Funcoes.IdUsuario);
                    //Funcoes.VerificarMensagem(model.Mensagem);

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
                if (Funcoes.StrToInt(txtCodigo.txtValor.Text) == 0)
                    throw new Exception("Informe o Item");

                if (Funcoes.DataEmBranco(txtData.txtData.Text))
                    throw new Exception("Informe a Data");

                if (Funcoes.StrToInt(UsrUsuario.txtId.Text) == 0)
                    throw new Exception("Informe o Usuário");

                if (string.IsNullOrEmpty(txtDescricao.Text))
                    throw new Exception("Informe a Descrição");

                if (_idCliente == 0)
                    throw new Exception("Informe a Id do Cliente");

                _clienteEspecificacaoApp = new ClienteEspecificacaoApp();
                _clienteEspecificacao.Id = _Id;
                _clienteEspecificacao.ClienteId = _idCliente;
                _clienteEspecificacao.Item = Funcoes.StrToInt(txtCodigo.txtValor.Text);
                _clienteEspecificacao.UsuarioId = Funcoes.StrToInt(UsrUsuario.txtId.Text);
                _clienteEspecificacao.Data = Funcoes.StrToDate(txtData.txtData.Text);

                var model = _clienteEspecificacaoApp.Salvar(_clienteEspecificacao);

                //Funcoes.VerificarMensagem(model.Mensagem);

                if (_Id > 0)
                {
                    var temp = _listaConsulta.First(x => x.Id == _Id);
                    _listaConsulta.Remove(temp);
                };

                _listaConsulta.Add(model);

                dgvDados.DataSource = _clienteEspecificacaoApp.Filtrar(_idCliente);

                //dgvDados.DataSource = _listaConsulta.Where(x => x.Id == model.Id).ToArray();

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
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "Id");
                DialogResult = DialogResult.OK;
                base.Pesquisar();
            }
        }

        private void dgvDados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _grid.OrdenarColunas(ref dgvDados, _listaConsulta, e);
            //cbCampos.SelectedIndex = e.ColumnIndex - 1;
        }

        private void frmClienteEspecificacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedTab == tpPesquisa)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }

            if (e.KeyCode == Keys.F9)
            {
                if (UsrUsuario.txtCodigo.txtValor.Focused)
                    UsrUsuario.PressionarF9(EnProgramas.Usuario);
            }
        }

        private void btnAnexar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtNomeArquivo.Text = openFileDialog.FileName;
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (txtNomeArquivo.Text.Trim() == "")
            {
                MessageBox.Show("Não arquivo para visualizar!");
                return;
            }
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = txtNomeArquivo.Text;
            System.Diagnostics.Process.Start(startInfo);
        }
    }
}
