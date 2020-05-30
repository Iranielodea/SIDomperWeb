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
    public partial class frmRecado : frmBase
    {
        RecadoApp _recadoApp;
        int _Id;
        List<RecadoConsultaViewModel> _listaConsulta = new List<RecadoConsultaViewModel>();
        GridColunas<RecadoConsultaViewModel> _grid = new GridColunas<RecadoConsultaViewModel>();
        string _operacao;

        public frmRecado()
        {
            Iniciar();
            _operacao = "A";

        }

        public frmRecado(string operacao, bool quadro)
        {
            Iniciar();
            _operacao = operacao;

            if (quadro)
            {
                if (operacao == "E")
                {
                    tabControl2.TabPages.Remove(tbPrincipal);
                    txtDescricaoFinal.Focus();
                } 
            }
        }
        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            Grade.Configurar(ref dgvDados);

            cbCampos.DataSource = Grade.ListarCampos(ref dgvDados);
            cbCampos.SelectedIndex = 3;
            cbPesquisa.Enabled = false;

            UsrUsuarioLcto.Programa(EnProgramas.Usuario, true, false, "Usuário Lançamento", false);
            UsrUsuarioDestino.Programa(EnProgramas.Usuario, true, true, "Usuário Destino", true);
            UsrTipo.ProgramaTipo(EnProgramas.Tipo, true, true, "", true, EnTipos.Recado);
            UsrStatus.ProgramaStatus(EnProgramas.Status, true, false, "", false, EnStatus.Recado);
            UsrCliente.Programa(EnProgramas.Cliente, true);

            txtCodigo.txtValor.ReadOnly = true;

            _recadoApp = new RecadoApp();

            //int altura = tpUsuario.Height;
            //int largura = tpUsuario.Width;

            //ursFiltroStatus.PosicaoTela(altura, largura);
            //ursFiltroTipo.PosicaoTela(altura, largura);
            //ursFiltroUsuario.PosicaoTela(altura, largura);
            //ursFiltroCliente.PosicaoTela(altura, largura);
        }

        public override void Novo()
        {            
            try
            {
                _recadoApp = new RecadoApp();
                var model = _recadoApp.Novo(Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(model.Mensagem);

                base.Novo();

                Tela.LimparTela(tbPrincipal);
                LimparTela();

                usrData.txtData.Text = model.Data.ToString();
                txtHora.Text = model.Hora.ToString();

                UsrUsuarioLcto.txtId.Text = model.UsuarioLctoId.ToString();
                UsrUsuarioLcto.SetCodigoMask(model.CodigoUsuarioLcto.ToString());
                UsrUsuarioLcto.txtNome.Text = model.NomeUsuarioLancamento;

                UsrTipo.txtId.Text = model.TipoId.ToString();
                UsrTipo.SetCodigoMask(model.CodigoTipo.ToString());
                UsrTipo.txtNome.Text = model.NomeTipo;

                UsrStatus.txtId.Text = model.StatusId.ToString();
                UsrStatus.SetCodigoMask(model.CodigoStatus.ToString());
                UsrStatus.txtNome.Text = model.NomeStatus;

                rbNormal.Checked = true;
                RecadoEncerrado(model);

                txtDataFinal.txtData.Clear();
                txtHoraFinal.Text = "";
                txtDescricaoFinal.Text = "";
                UsrCliente.txtCodigo.Focus();
                _Id = 0;
                _operacao = "A";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimparTela()
        {
            UsrCliente.LimparTela();
            UsrStatus.LimparTela();
            UsrTipo.LimparTela();
            UsrUsuarioLcto.LimparTela();
            UsrUsuarioDestino.LimparTela();
        }

        public override void Editar()
        {
            try
            {
                Tela.LimparTela(tbPrincipal);
                LimparTela();

                _recadoApp = new RecadoApp();
                var model = _recadoApp.Editar(Funcoes.IdUsuario, Grade.RetornarId(ref dgvDados, "Rec_Id"));
                btnSalvar.Enabled = Funcoes.PermitirEditar(model.Mensagem);

                base.Editar();

                _Id = model.Id;
                txtCodigo.txtValor.Text = model.Id.ToString("000000");
                usrData.txtData.Text = model.Data.ToString();
                txtHora.Text = model.Hora.ToString();

                UsrUsuarioLcto.txtId.Text = model.UsuarioLctoId.ToString();
                UsrUsuarioLcto.SetCodigoMask(model.CodigoUsuarioLcto.ToString());
                UsrUsuarioLcto.txtNome.Text = model.NomeUsuarioLancamento;

                UsrUsuarioDestino.txtId.Text = model.UsuarioDestinoId.ToString();
                UsrUsuarioDestino.SetCodigoMask(model.CodigoUsuarioDest.ToString());
                UsrUsuarioDestino.txtNome.Text = model.NomeUsuarioDestino;

                UsrCliente.txtId.Text = model.ClienteId.ToString();
                UsrCliente.SetCodigoMask(model.CodigoCliente.ToString());
                UsrCliente.txtNome.Text = model.NomeCliente;

                txtRazao.Text = model.RazaoSocial;
                txtFantasia.Text = model.Fantasia;
                txtEndereco.Text = model.Endereco;
                txtTelefone.Text = model.Telefone;
                txtContato.Text = model.Contato;

                UsrTipo.txtId.Text = model.TipoId.ToString();
                UsrTipo.SetCodigoMask(model.CodigoTipo.ToString());
                UsrTipo.txtNome.Text = model.NomeTipo;

                UsrStatus.txtId.Text = model.StatusId.ToString();
                UsrStatus.SetCodigoMask(model.CodigoStatus.ToString());
                UsrStatus.txtNome.Text = model.NomeStatus;

                rbBaixo.Checked = (model.Nivel.Value == 1);
                rbNormal.Checked = (model.Nivel.Value == 2);
                rbAlto.Checked = (model.Nivel.Value == 3);
                rbCritico.Checked = (model.Nivel.Value == 4);

                RecadoEncerrado(model);

                txtDescricaoInicial.Text = model.DescricaoInicial;
                txtDescricaoFinal.Text = model.DescricaoFinal;

                if (model.DataFinal != null)
                    txtDataFinal.txtData.Text = model.DataFinal.Value.ToShortDateString();

                if (model.HoraFinal != null)
                    txtHoraFinal.Text = model.HoraFinal.Value.ToString();

                usrData.txtData.Focus();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void Filtrar()
        {
            FiltrarDados(txtTexto.Text, 0);
            base.Filtrar();
        }

        public override void Excluir()
        {
            base.Excluir();
            if (Funcoes.Confirmar("Confirmar Exclusão?"))
            {
                try
                {
                    _recadoApp = new RecadoApp();
                    int id = Grade.RetornarId(ref dgvDados, "Rec_Id");
                    var model = _recadoApp.Excluir(Funcoes.IdUsuario, id);
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

        public override void Filtro()
        {
            base.Filtro();
            txtDataFiltroInicial.txtData.Focus();
        }

        private void Validar(RecadoViewModel model)
        {
            if (string.IsNullOrWhiteSpace(txtRazao.Text))
                throw new Exception("Informe o Cliente!");
            if (model.TipoId == 0)
                throw new Exception("Informe o Tipo!");
            if (model.UsuarioDestinoId == 0)
                throw new Exception("Informe o Usuário Destino!");
            if (string.IsNullOrEmpty(model.DescricaoInicial))
                throw new Exception("Informe a Descrição!");
        }

        private int RetornoNivel()
        {
            int retorno = 1;
            
            if (rbNormal.Checked)
                retorno = 2;
            else if (rbAlto.Checked)
                retorno = 3;
            else if (rbCritico.Checked)
                retorno = 4;
            return retorno;
        }

        public override void Salvar()
        {
            try
            {
                _recadoApp = new RecadoApp();
                var recado = new RecadoViewModel();
                if (_Id > 0)
                    recado = _recadoApp.Editar(Funcoes.IdUsuario, _Id);
                recado.Id = _Id;
                recado.Data = Funcoes.StrToDate(usrData.txtData.Text);
                recado.ClienteId = Funcoes.StrToIntNull(UsrCliente.txtId.Text);
                recado.Contato = txtContato.Text;
                recado.DescricaoInicial = txtDescricaoInicial.Text;
                recado.Hora = Funcoes.StrToHoraNull(txtHora.Text).Value; //Funcoes.StrToHora(txtHora.Text);
                recado.RazaoSocial = txtRazao.Text;
                recado.Fantasia = txtFantasia.Text;
                recado.Endereco = txtEndereco.Text;
                recado.Telefone = txtTelefone.Text;
                recado.Contato = txtContato.Text;
                recado.Nivel = RetornoNivel();

                recado.StatusId = Funcoes.StrToInt(UsrStatus.txtId.Text);
                recado.TipoId = Funcoes.StrToInt(UsrTipo.txtId.Text);
                recado.UsuarioLctoId = Funcoes.StrToInt(UsrUsuarioLcto.txtId.Text);
                recado.UsuarioDestinoId = Funcoes.StrToInt(UsrUsuarioDestino.txtId.Text);
                recado.DescricaoFinal = txtDescricaoFinal.Text;
                recado.DataFinal = Funcoes.StrToDateNull(txtDataFinal.txtData.Text);
                recado.HoraFinal = Funcoes.StrToHoraNull(txtHoraFinal.Text);
                recado.ModoAbrEnc = _operacao;

                Validar(recado);

                var model = _recadoApp.Salvar(recado);
                Funcoes.VerificarMensagem(model.Mensagem);

                FiltrarDados(model.Id.ToString(), model.Id);

                base.Salvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Encerrar()
        {
            txtDataFinal.txtData.Text = DateTime.Now.Date.ToShortDateString();
            txtHoraFinal.Text = DateTime.Now.ToShortTimeString();
            _operacao = "E";

            Salvar();
        }

        private void FiltrarDados(string texto, int id = 0)
        {
            try
            {
                string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

                if (sCampo == "NomeUsuarioLancamento")
                    sCampo = " Lcto.Usu_Nome";

                if (sCampo == "NomeUsuarioDestino")
                    sCampo = " Dest.Usu_Nome";

                var filtro = new RecadoFiltroViewModel();
                filtro.Campo = sCampo;
                filtro.Texto = txtTexto.Text;
                filtro.Contem = cbPesquisa.SelectedIndex == 0;
                filtro.DataInicial = txtDataFiltroInicial.txtData.Text;
                filtro.DataFinal = txtDataFiltroFinal.txtData.Text;
                //filtro.IdUsuario = ursFiltroUsuario.RetornarSelecao();
                //filtro.IdCliente = ursFiltroCliente.RetornarSelecao();
                //filtro.IdTipo = ursFiltroTipo.RetornarSelecao();
                //filtro.IdStatus = ursFiltroStatus.RetornarSelecao();

                if (id > 0)
                {
                    filtro.Campo = "Rec_Id";
                    filtro.Texto = id.ToString();
                }

                _listaConsulta = _recadoApp.Filtrar(filtro).ToList();
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
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "Rec_Id");
                DialogResult = DialogResult.OK;
                base.Pesquisar();
            }
        }

        private void BuscarDados()
        {
            FiltrarDados(txtTexto.Text);
            cbCampos.Focus();
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

        private void frmRecado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (UsrCliente.txtCodigo.txtValor.Focused)
                    UsrCliente.PressionarF9(EnProgramas.Cliente);
                if (UsrTipo.txtCodigo.txtValor.Focused)
                    UsrTipo.PressionarF9(EnProgramas.Tipo);
                if (UsrUsuarioDestino.txtCodigo.txtValor.Focused)
                    UsrUsuarioDestino.PressionarF9(EnProgramas.Usuario);

                //if (txtDescricao.Focused)
                //    BuscarObservacoes();

                //if (tabControl3.SelectedTab == tpUsuario)
                //    ursFiltroUsuario.AbrirTela();
                //if (tabControl3.SelectedTab == tpCliente)
                //    ursFiltroCliente.AbrirTela();
                //if (tabControl3.SelectedTab == tpTipo)
                //    ursFiltroTipo.AbrirTela();
                //if (tabControl3.SelectedTab == tpStatus)
                //    ursFiltroStatus.AbrirTela();
            }
        }

        private void TeclasAtalho(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
                Salvar();
            if (e.KeyCode == Keys.Escape)
                Voltar();
        }

        private void txtDescricaoInicial_KeyDown(object sender, KeyEventArgs e)
        {
            TeclasAtalho(e);
        }

        private void txtDescricaoInicial_Enter(object sender, EventArgs e)
        {
            this.KeyPreview = false;
        }

        private void txtDescricaoInicial_Leave(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void UsrCliente_Leave(object sender, EventArgs e)
        {
            if (UsrCliente.Modificou)
            {
                txtRazao.Clear();
                txtFantasia.Clear();
                txtEndereco.Clear();
                txtTelefone.Clear();
                txtContato.Clear();

                var cliente = (ClienteViewModelApi)UsrCliente.RetornarObjeto();
                if (cliente != null)
                {
                    txtRazao.Text = cliente.Nome;
                    txtFantasia.Text = cliente.Fantasia;
                    txtEndereco.Text = cliente.Endereco;
                    txtTelefone.Text = cliente.Telefone;

                    PopularEnderecoCliente(cliente);
                    PopularTelefonesCliente(cliente);
                    PopularContatosCliente(cliente);
                }
            }
        }

        private void PopularEnderecoCliente(ClienteViewModelApi cliente)
        {
            string endereco = cliente.Logradouro;
            if (!string.IsNullOrEmpty(cliente.Bairro))
                endereco = endereco + Environment.NewLine + cliente.Bairro;
            if (!string.IsNullOrEmpty(cliente.CEP))
                endereco = endereco + Environment.NewLine + cliente.CEP;
            if (cliente.Cidade != null)
            {
                if (!string.IsNullOrEmpty(cliente.Cidade.Nome))
                    endereco = endereco + Environment.NewLine + cliente.Cidade.Nome;
            }
            txtEndereco.Text = endereco;
        }

        private void PopularTelefonesCliente(ClienteViewModelApi cliente)
        {
            string telefones = cliente.Fone1;
            if (!string.IsNullOrEmpty(cliente.Fone2))
                telefones = telefones + " / " + cliente.Fone2;
            if (!string.IsNullOrEmpty(cliente.Celular))
                telefones = telefones + " / " + cliente.Celular;
            if (!string.IsNullOrEmpty(cliente.OutroFone))
                telefones = telefones + " / " + cliente.OutroFone;
            txtTelefone.Text = telefones;
        }

        private void PopularContatosCliente(ClienteViewModelApi cliente)
        {
            string contatos = cliente.ContatoCompraVenda;
            if (!string.IsNullOrEmpty(cliente.ContatoFinanceiro))
                contatos = contatos + cliente.ContatoFinanceiro;
            txtContato.Text = contatos;
        }

        private bool RecadoEncerrado(RecadoViewModel viewModel)
        {
            var encerrado = (viewModel.DataFinal != null);
            UsrStatus.txtCodigo.Enabled = (!encerrado);
            UsrStatus.btnConsulta.Enabled = (!encerrado);

            return encerrado;
        }

        private void txtDescricaoFinal_KeyDown(object sender, KeyEventArgs e)
        {
            TeclasAtalho(e);
        }

        private void txtDescricaoFinal_Enter(object sender, EventArgs e)
        {
            this.KeyPreview = false;
        }

        private void txtDescricaoFinal_Leave(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            Encerrar();
        }

        private void tabControl3_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedTab == tpFiltroPrincipal)
            {
                txtDataFiltroInicial.txtData.Focus();
            }
        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab == tpEncerramento)
            {
                txtDescricaoFinal.Focus();
            }
        }
    }
}
