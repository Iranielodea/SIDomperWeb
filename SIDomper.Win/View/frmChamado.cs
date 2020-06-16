using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Base;
using SIDomper.Win.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIDomper.Win.View
{
    public partial class frmChamado : frmBase
    {
        ChamadoApp _chamadoApp;
        ChamadoOcorrenciaApp _chamadoOcorrenciaApp;
        ChamadoViewModel _chamadoViewModel;

        int _Id;
        List<ChamadoConsultaViewModel> _listaConsulta = new List<ChamadoConsultaViewModel>();
        GridColunas<ChamadoConsultaViewModel> _grid = new GridColunas<ChamadoConsultaViewModel>();
        EnumChamado _enChamado;
        //EnStatus _enStatus;
        //EnTipos _enTipos;
        int _idEncerramento;
        bool _quadro;
        bool _ocorrencia;
        int _idClienteAgendamento;
        int _idAgendamento;

        public frmChamado()
        {
            Iniciar();
        }

        private void HabilitarDataHora(bool ativar)
        {
            if (ativar == false)
                ativar = _chamadoViewModel.UsuarioAdm;

            txtDataOco.txtData.ReadOnly = !ativar;
            txtHoraInicialOco.ReadOnly = !ativar;
            txtHoraFinalOco.ReadOnly = !ativar;
        }

        public frmChamado(EnumChamado enChamado, int idEncerramento, bool quadro, bool ocorrencia, int idClienteAgendamento, int idAgendamento)
        {
            _enChamado = enChamado;
            _idEncerramento = idEncerramento;
            _quadro = quadro;
            _ocorrencia = ocorrencia;
            _idClienteAgendamento = idClienteAgendamento;
            _idAgendamento = idAgendamento;
            //EnStatus enStatus;
            //EnTipos enTipos;

            Iniciar();

            //if (enChamado == EnumChamado.Chamado)
            //{
            //    enStatus = EnStatus.Chamado;
            //    enTipos = EnTipos.Chamado;
            //}
            //else
            //{
            //    enStatus = EnStatus.Atividade;
            //    enTipos = EnTipos.Atividade;
            //}
        }

        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            UsrUsuario.Programa(EnProgramas.Usuario, false, false, "Usuário Abertura", false);
            UsrModulo.Programa(EnProgramas.Modulo, false, true, "Módulo");
            UsrProduto.Programa(EnProgramas.Produto, false, false, "", false);
            UsrTipo.ProgramaTipo(EnProgramas.Tipo, true, true, "", true, EnTipos.Chamado);
            UsrStatus.ProgramaStatus(EnProgramas.Status, true, false, "", false, EnStatus.Chamado);
            UsrCliente.Programa(EnProgramas.Cliente, true);
            UsrUsuarioOco.Programa(EnProgramas.Usuario, false, false, "", false);

            int altura = tpUsuario.Height;
            int largura = tpUsuario.Width;

            ursFiltroStatus.PosicaoTela(altura, largura);
            ursFiltroTipo.PosicaoTela(altura, largura);
            ursFiltroUsuario.PosicaoTela(altura, largura);
            ursFiltroModulo.PosicaoTela(altura, largura);

            Grade.Configurar(ref dgvDados);
            Grade.Configurar(ref dgvOcorrencia);
            Grade.Configurar(ref dgvStatus);

            cbCampos.DataSource = Grade.ListarCampos(ref dgvDados);
            cbCampos.SelectedIndex = 4;
            txtCodigo.txtValor.ReadOnly = true;

            if (_enChamado == EnumChamado.Atividade)
                this.Text = "Atividades";

            lblAtivo.Visible = false;
            cboAtivo.Visible = false;

            txtDataOco.txtData.ReadOnly = true;
            txtDataOco.txtData.TabStop = false;

            txtHoraInicialOco.ReadOnly = true;
            txtHoraInicialOco.TabStop = false;

            txtHoraFinalOco.ReadOnly = true;
            txtHoraFinalOco.TabStop = false;
            _chamadoViewModel = new ChamadoViewModel();
        }

        private void LimparTela()
        {
            Tela.LimparTela(tbPrincipal);
            Tela.LimparPage(ref tpOcorrencia);
            UsrUsuario.LimparTela();
            UsrModulo.LimparTela();
            UsrProduto.LimparTela();
            UsrTipo.LimparTela();
            UsrStatus.LimparTela();
            UsrCliente.LimparTela();
            rbNormal.Checked = true;
            dgvOcorrencia.Rows.Clear();
        }

        public override void Novo()
        {
            try
            {
                _chamadoApp = new ChamadoApp();
                var model = _chamadoApp.Novo(Funcoes.IdUsuario, _enChamado, _idEncerramento, _quadro, _idClienteAgendamento, _idAgendamento);
                _chamadoViewModel = model;

                Funcoes.VerificarMensagem(model.Mensagem);

                base.Novo();

                LimparTela();

                UsrUsuario.txtId.Text = model.UsuarioAberturaId.ToString();
                UsrUsuario.SetCodigoMask(model.CodUsuario.ToString());
                UsrUsuario.txtNome.Text = model.NomeUsuario;

                UsrStatus.txtId.Text = model.StatusId.ToString();
                UsrStatus.SetCodigoMask(model.CodStatus.ToString());
                UsrStatus.txtNome.Text = model.NomeStatus;

                txtDataAbertura.txtData.Text = DateTime.Now.ToShortDateString();
                txtHoraAbertura.Text = DateTime.Now.ToShortTimeString();

                _chamadoViewModel.ChamadoOcorrencias.Clear();

                HabilitarDataHora(model.UsuarioPermissaoAlterarDataHora);

                txtDataAbertura.txtData.Focus();
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
                _chamadoApp = new ChamadoApp();
                var model = _chamadoApp.Editar(Funcoes.IdUsuario, Grade.RetornarId(ref dgvDados, "Cha_Id"));
                _chamadoViewModel = model;

                btnSalvar.Enabled = Funcoes.PermitirEditar(model.Mensagem);
                PermissaoAlterarOcorrencia();
                PermissaoExcluirOcorrencia();

                base.Editar();

                LimparTela();

                txtCodigo.txtValor.Text = model.Id.ToString(Tela.MaskChamado);
                txtDataAbertura.txtData.Text = model.DataAbertura.ToString();
                txtHoraAbertura.Text = model.HoraAbertura.ToString();

                UsrUsuario.txtId.Text = model.UsuarioAberturaId.ToString();
                UsrUsuario.SetCodigoMask(model.CodUsuario.ToString());
                UsrUsuario.txtNome.Text = model.NomeUsuario;

                UsrCliente.txtId.Text = model.ClienteId.ToString();
                UsrCliente.SetCodigoMask(model.CodCliente.ToString());
                UsrCliente.txtNome.Text = model.NomeCliente;
                txtVersao.Text = model.Versao;
                txtContato.Text = model.Contato;

                rbBaixo.Checked = (model.Nivel == 1);
                rbNormal.Checked = (model.Nivel == 2);
                rbAlto.Checked = (model.Nivel == 3);
                rbCritico.Checked = (model.Nivel == 4);

                if (model.ModuloId != null)
                {
                    UsrModulo.txtId.Text = model.ModuloId.ToString();
                    UsrModulo.SetCodigoMask(model.CodModulo.ToString());
                    UsrModulo.txtNome.Text = model.NomeModulo;
                }

                if (model.ProdutoId != null)
                {
                    UsrProduto.txtId.Text = model.ProdutoId.ToString();
                    UsrProduto.SetCodigoMask(model.CodProduto.ToString());
                    UsrProduto.txtNome.Text = model.NomeProduto;
                }

                UsrTipo.txtId.Text = model.TipoId.ToString();
                UsrTipo.SetCodigoMask(model.CodTipo.ToString());
                UsrTipo.txtNome.Text = model.NomeTipo;

                UsrStatus.txtId.Text = model.StatusId.ToString();
                UsrStatus.SetCodigoMask(model.CodStatus.ToString());
                UsrStatus.txtNome.Text = model.NomeStatus;

                if (model.ModuloId != null)
                {
                    UsrModulo.txtId.Text = model.ModuloId.ToString();
                    UsrModulo.SetCodigoMask(model.CodModulo.ToString());
                    UsrModulo.txtNome.Text = model.NomeModulo;
                }

                if (model.ProdutoId != null)
                {
                    UsrProduto.txtId.Text = model.ProdutoId.ToString();
                    UsrProduto.SetCodigoMask(model.CodProduto.ToString());
                    UsrProduto.txtNome.Text = model.NomeProduto;
                }

                txtDescricao.Text = model.Descricao;

                DadosCliente(model);

                CarregarOcorrencia(model);

                dgvStatus.DataSource = model.ChamadosStatus;

                HabilitarDataHora(model.UsuarioPermissaoAlterarDataHora);

                txtContato.Focus();
                _Id = model.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DadosCliente(ChamadoViewModel model)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Id..........:" + model.Id.ToString(Tela.MaskChamado));
            sb.AppendLine("Razão Social:" + model.NomeCliente);
            sb.AppendLine("Fantasia....:" + model.NomeFantasia);
            sb.AppendLine("Revenda.....:" + model.NomeRevenda);
            sb.AppendLine("Consultor...:" + model.NomeConsultor);
            sb.AppendLine("Fone1.......:" + model.Fone1);
            sb.AppendLine("Fone2.......:" + model.Fone2);
            sb.AppendLine("Celular.....:" + model.Celular);
            sb.AppendLine("Outro Fone..:" + model.OutroFone);
            sb.AppendLine("Contato Financeiro..:" + model.ContatoFinanceiro);
            sb.AppendLine("Contato Compra/Venda:" + model.ContatoCompraVenda);

            txtDadosCliente.Text = sb.ToString();
            txtDadosClienteOco.Text = sb.ToString();
        }

        private void DadosClienteII(ClienteViewModelApi model)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Id..........:" + txtCodigo.txtValor.Text);
            sb.AppendLine("Razão Social:" + model.Nome);
            sb.AppendLine("Fantasia....:" + model.Fantasia);
            sb.AppendLine("Revenda.....:" + model.Revenda.Nome);
            sb.AppendLine("Consultor...:" + model.NomeUsuario);
            sb.AppendLine("Fone1.......:" + model.Fone1);
            sb.AppendLine("Fone2.......:" + model.Fone2);
            sb.AppendLine("Celular.....:" + model.Celular);
            sb.AppendLine("Outro Fone..:" + model.OutroFone);
            sb.AppendLine("Contato Financeiro..:" + model.ContatoFinanceiro);
            sb.AppendLine("Contato Compra/Venda:" + model.ContatoCompraVenda);
            txtVersao.Text = model.Versao;

            txtDadosCliente.Text = sb.ToString();
            txtDadosClienteOco.Text = sb.ToString();

            BuscarModulos(model.Id);
        }

        private void BuscarModulos(int idCliente)
        {
            UsrModulo.LimparTela();
            UsrProduto.LimparTela();

            var formulario = new frmModulo("", idCliente);
            formulario.ShowDialog();
            if (Funcoes.IdSelecionado > 0)
            {
                var model = _chamadoApp.BuscarModuloProduto(idCliente, Funcoes.IdSelecionado);
                if (model.ModuloId != null)
                {
                    UsrModulo.txtId.Text = model.ModuloId.ToString();
                    UsrModulo.SetCodigoMask(model.CodModulo.ToString());
                    UsrModulo.txtNome.Text = model.NomeModulo;
                }

                if (model.ProdutoId != null)
                {
                    UsrProduto.txtId.Text = model.ProdutoId.ToString();
                    UsrProduto.SetCodigoMask(model.CodProduto.ToString());
                    UsrProduto.txtNome.Text = model.NomeProduto;
                }
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
                    _chamadoApp = new ChamadoApp();
                    int id = Grade.RetornarId(ref dgvDados, "Cha_Id");
                    var model = _chamadoApp.Excluir(id, Funcoes.IdUsuario);
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
                if (string.IsNullOrEmpty(txtContato.Text))
                    throw new Exception("Informe o Nome!");
                if (string.IsNullOrEmpty(UsrTipo.txtId.Text))
                    throw new Exception("Informe o Tipo!");
                if (string.IsNullOrEmpty(UsrStatus.txtId.Text))
                    throw new Exception("Informe o Status!");
                if (string.IsNullOrEmpty(txtDescricao.Text))
                    throw new Exception("Informe a Descrição!");

                _chamadoApp = new ChamadoApp();
                //var modelBase = new ChamadoViewModel();

                _chamadoViewModel.Id = _Id;
                _chamadoViewModel.DataAbertura = Funcoes.StrToDate(txtDataAbertura.txtData.Text);
                _chamadoViewModel.HoraAbertura = Funcoes.StrToHora(txtHoraAbertura.Text);
                _chamadoViewModel.UsuarioAberturaId = Funcoes.StrToInt(UsrUsuario.txtId.Text);
                _chamadoViewModel.ClienteId = Funcoes.StrToInt(UsrCliente.txtId.Text);
                _chamadoViewModel.Contato = txtContato.Text;

                if (rbBaixo.Checked) _chamadoViewModel.Nivel = 1;
                if (rbNormal.Checked) _chamadoViewModel.Nivel = 2;
                if (rbAlto.Checked) _chamadoViewModel.Nivel = 3;
                if (rbCritico.Checked) _chamadoViewModel.Nivel = 4;

                _chamadoViewModel.TipoId = Funcoes.StrToInt(UsrTipo.txtId.Text);
                _chamadoViewModel.StatusId = Funcoes.StrToInt(UsrStatus.txtId.Text);
                _chamadoViewModel.Descricao = txtDescricao.Text;
                _chamadoViewModel.ModuloId = Funcoes.StrToIntNull(UsrModulo.txtId.Text);
                _chamadoViewModel.ProdutoId = Funcoes.StrToIntNull(UsrProduto.txtId.Text);

                //tipomovimento 1 chamado 2 atividade
                if (_enChamado == EnumChamado.Chamado)
                    _chamadoViewModel.TipoMovimento = 1;
                else
                    _chamadoViewModel.TipoMovimento = 2;

                //var ocorrencia = new ChamadoOcorrenciaViewModel();

                //_chamadoViewModel.ChamadoOcorrenciasConsulta.Add(ocorrencia);

                //_chamadoViewModel.ChamadoOcorrenciasConsulta = _chamadoViewModel.ChamadoOcorrenciasConsulta;

                var temp = new ChamadoViewModel();

                if (_Id > 0)
                    temp = _chamadoApp.ObterPorId(_Id);
                temp = _chamadoViewModel;

                var model = _chamadoApp.Salvar(_chamadoViewModel, Funcoes.IdUsuario, _ocorrencia);

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

                var filtro = new ChamadoFiltroViewModel();

                filtro.Campo = sCampo;
                filtro.Texto = texto;
                filtro.DataInicial = txtDataInicial.txtData.Text;
                filtro.DataFinal = txtDataFinal.txtData.Text;
                filtro.IdUsuarioAbertura = ursFiltroUsuario.RetornarSelecao();
                filtro.IdModulo = ursFiltroModulo.RetornarSelecao();
                filtro.idTipo = ursFiltroTipo.RetornarSelecao();
                filtro.IdStatus = ursFiltroStatus.RetornarSelecao();

                if (id > 0)
                {
                    //filtro.Campo = "Cha_Id";
                    //filtro.Texto = id.ToString();
                    filtro.Id = id;
                }

                bool contem = cbPesquisa.SelectedIndex == 0;

                _chamadoApp = new ChamadoApp();

                _listaConsulta = _chamadoApp.Filtrar(filtro, Funcoes.IdUsuario, filtro.Campo, filtro.Texto, contem, _enChamado).ToList();
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
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "Cha_Id");
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

        //private void txtCodStatus_Leave(object sender, EventArgs e)
        //{
        //}

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
                txtDataInicial.txtData.Focus();
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
                ursFiltroTipo.TipoDeCadastro(Filtros.TipoCadastro.Tipo, EnStatus.Chamado, EnTipos.Chamado);
                ursFiltroTipo.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpStatus)
            {
                ursFiltroStatus.TipoDeCadastro(Filtros.TipoCadastro.Status, EnStatus.Chamado, EnTipos.Chamado);
                ursFiltroStatus.txtCodigo.txtValor.Focus();
            }
        }

        private void BuscarObservacoes()
        {
            frmObservacao frmObservacao = new frmObservacao(EnObservacao.Chamado);
            if (frmObservacao.ShowDialog() == DialogResult.OK)
            {
                var obsApp = new ObservacaoApp();
                var observacao = obsApp.ObterPorId(Funcoes.IdSelecionado);
                txtDescricao.Text = txtDescricao.Text + " " + observacao.Descricao;
            }
        }

        private void AbrirDetalhes(int id)
        {
            frmBaseConhecimentoDetalhe formulario = new frmBaseConhecimentoDetalhe(id, EnProgramas.Chamado);
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
                AbrirDetalhes(Grade.RetornarId(ref dgvDados, "Cha_Id"));
        }

        //private void txtCodCliente_Leave(object sender, EventArgs e)
        //{
        //}

        //private void txtNomeCliente_Leave(object sender, EventArgs e)
        //{
        //}

        //private void btnCliente_Click(object sender, EventArgs e)
        //{
        //}

        private void frmChamado_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl2.SelectedTab == tpOcorrencia)
            {
                if (e.KeyCode == Keys.Insert)
                {
                    if (btnNovoOco.Enabled)
                        NovoOcorrencia();
                }
            }

            if (e.KeyCode == Keys.F9)
            {
                if (UsrModulo.txtCodigo.txtValor.Focused)
                    UsrModulo.PressionarF9(EnProgramas.Modulo);

                if (UsrCliente.txtCodigo.txtValor.Focused)
                    UsrCliente.PressionarF9(EnProgramas.Cliente);

                if (UsrTipo.txtCodigo.txtValor.Focused)
                    UsrTipo.PressionarF9(EnProgramas.Tipo);
            }
        }

        private void DecrementarIdOcorrencia()
        {
            txtIdOcorrencia.Text = _chamadoViewModel.OcorrenciaRetornarMenorId().ToString();
        }

        private void NovoOcorrencia()
        {
            txtDataOco.txtData.Text = DateTime.Now.ToShortDateString();
            txtHoraInicialOco.Text = DateTime.Now.ToShortTimeString();

            var chamadoOcorrenciaApp = new ChamadoOcorrenciaApp();
            var model = chamadoOcorrenciaApp.Novo(Funcoes.IdUsuario);
            UsrUsuarioOco.txtId.Text = Funcoes.IdUsuario.ToString();
            UsrUsuarioOco.SetCodigoMask(model.CodUsuario.ToString());
            UsrUsuarioOco.txtNome.Text = model.NomeUsuario;
            DecrementarIdOcorrencia();
            txtDocumento.Clear();
            txtHoraFinalOco.Clear();
            txtDescricaoProblema.Clear();
            txtDescricaoSolucao.Clear();
            txtAnexo.Clear();

            HabilitarDataHora(false);
            txtDocumento.Focus();
        }

        private bool EntrarTelaStatus()
        {
            frmTrocaStatus frmTrocaStatus = new frmTrocaStatus(EnStatus.Chamado, EnTipos.Chamado);
            frmTrocaStatus.txtIdTipo.Text = UsrTipo.txtId.Text;
            frmTrocaStatus.txtCodTipo.txtValor.Text = UsrTipo.txtCodigo.txtValor.Text;
            frmTrocaStatus.txtNomeTipo.Text = UsrTipo.txtNome.Text;

            if (frmTrocaStatus.ShowDialog() == DialogResult.OK)
            {
                UsrTipo.txtId.Text = frmTrocaStatus.txtIdTipo.Text;
                UsrTipo.txtCodigo.txtValor.Text = frmTrocaStatus.txtCodTipo.txtValor.Text;
                UsrTipo.txtNome.Text = frmTrocaStatus.txtNomeTipo.Text;

                if (frmTrocaStatus.txtIdStatus.Text != "")
                {
                    UsrStatus.txtId.Text = frmTrocaStatus.txtIdStatus.Text;
                    UsrStatus.txtCodigo.txtValor.Text = frmTrocaStatus.txtCodStatus.txtValor.Text;
                    UsrStatus.txtNome.Text = frmTrocaStatus.txtNomeStatus.Text;
                }
                return true;
            }
            else
                return true;
        }

        private void PermissaoAlterarOcorrencia()
        {
            if (_enChamado == EnumChamado.Chamado)
            {
                btnSalvarOco.Enabled = _chamadoViewModel.PermissaoAlterarOcorrenciaChamado;
            }
            else
            {
                btnSalvarOco.Enabled = _chamadoViewModel.PermissaoAlterarOcorrenciaAtividade;
            }
        }

        private void SalvarOcorrencia()
        {
            try
            {
                int idOcorrencia = int.Parse(txtIdOcorrencia.Text);

                var model = new ChamadoOcorrenciaViewModel();
                model.Id = idOcorrencia;
                model.Anexo = txtAnexo.Text;
                model.ChamadoId = _Id;
                model.Data = DateTime.Parse(txtDataOco.txtData.Text);
                model.DescricaoSolucao = txtDescricaoSolucao.Text;
                model.DescricaoTecnica = txtDescricaoProblema.Text;
                model.Documento = txtDocumento.Text;
                model.HoraInicio = TimeSpan.Parse(txtHoraInicialOco.Text);
                model.HoraFim = Funcoes.StrToHoraNull(txtHoraFinalOco.Text);
                model.Versao = txtVersao.Text;
                model.UsuarioId = Funcoes.StrToInt(UsrUsuarioOco.txtId.Text);
                model.CodUsuario = Funcoes.StrToInt(UsrUsuarioOco.GetCodigoMask());
                model.NomeUsuario = UsrUsuarioOco.txtNome.Text;

                if (_chamadoViewModel.DataAbertura > model.Data)
                    throw new Exception("Data da Ocorrência menor que data de abertura!");

                bool RetornoStatus = true;

                if (Funcoes.StrToInt(txtIdOcorrencia.Text) <= 0)
                    RetornoStatus = EntrarTelaStatus();

                if (RetornoStatus)
                {
                    var modelAltera = _chamadoViewModel.ChamadoOcorrencias.FirstOrDefault(x => x.Id == model.Id);
                    if (modelAltera == null)
                        _chamadoViewModel.ChamadoOcorrencias.Add(model);
                    else
                    {
                        modelAltera.Anexo = model.Anexo;
                        modelAltera.ChamadoId = model.ChamadoId;
                        modelAltera.Data = model.Data;
                        modelAltera.DescricaoSolucao = model.DescricaoSolucao;
                        modelAltera.DescricaoTecnica = model.DescricaoTecnica;
                        modelAltera.Documento = model.Documento;
                        modelAltera.HoraFim = model.HoraFim;
                        modelAltera.HoraInicio = model.HoraInicio;
                        modelAltera.Id = model.Id;
                        modelAltera.TotalHoras = model.TotalHoras;
                        modelAltera.UsuarioId = model.UsuarioId;
                        modelAltera.Versao = model.Versao;
                    }

                    CarregarOcorrencia(_chamadoViewModel);

                    if (_quadro && _ocorrencia)
                    {
                        //Salvar();
                        this.Close();
                        return;
                    }
                    txtDocumento.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NavegarOco()
        {
            if (dgvOcorrencia.Rows.Count > 0)
            {
                try
                {
                    int idOcorrencia = Grade.RetornarId(ref dgvOcorrencia, "Id");
                    var ocorrencia = _chamadoViewModel.ChamadoOcorrencias.FirstOrDefault(x => x.Id == idOcorrencia); // Grade.RetornarId(ref dgvOcorrencia, "Id");
                    if (ocorrencia != null)
                    {
                        txtIdOcorrencia.Text = idOcorrencia.ToString();
                        txtDocumento.Text = ocorrencia.Documento;
                        txtDataOco.txtData.Text = ocorrencia.Data.ToShortDateString();
                        txtHoraInicialOco.Text = ocorrencia.HoraInicio.ToString();
                        txtHoraFinalOco.Text = ocorrencia.HoraFim.ToString();

                        UsrUsuarioOco.txtId.Text = ocorrencia.UsuarioId.ToString();
                        UsrUsuarioOco.SetCodigoMask(ocorrencia.CodUsuario.ToString());
                        UsrUsuarioOco.txtNome.Text = ocorrencia.NomeUsuario;

                        txtDescricaoProblema.Text = ocorrencia.DescricaoTecnica;
                        txtDescricaoSolucao.Text = ocorrencia.DescricaoSolucao;
                        txtVersao.Text = ocorrencia.Versao;
                        txtAnexo.Text = ocorrencia.Anexo;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtDescricaoProblema_Enter(object sender, EventArgs e)
        {
            this.KeyPreview = false;
        }

        private void txtDescricaoProblema_Leave(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void btnNovoOco_Click(object sender, EventArgs e)
        {
            NovoOcorrencia();
        }

        private void btnSalvarOco_Click(object sender, EventArgs e)
        {
            SalvarOcorrencia();
        }

        private void BtnAnexo_Click(object sender, EventArgs e)
        {
            Funcoes.AbrirAnexo(ref txtAnexo);
        }

        private void BtnVisualizar_Click(object sender, EventArgs e)
        {
            Funcoes.VisualizarAnexo(ref txtAnexo);
        }

        private void dgvOcorrencia_KeyUp(object sender, KeyEventArgs e)
        {
            NavegarOco();
        }

        private void CarregarOcorrencia(ChamadoViewModel model)
        {
            if (model.ChamadoOcorrencias == null)
                return;

            dgvOcorrencia.Rows.Clear();
            foreach (var item in model.ChamadoOcorrencias)
            {
                PreencherGridOcorrencia(
                    item.Id,
                    item.Data,
                    item.HoraInicio,
                    item.HoraFim,
                    item.Documento,
                    item.NomeUsuario,
                    item.UsuarioId,
                    item.CodUsuario
                    );
            }
        }

        private void AlterarDataHora()
        {
            if (btnSalvar.Enabled == false)
                return;

            _chamadoOcorrenciaApp = new ChamadoOcorrenciaApp();
            var chamadoOcorrenciaViewModel = new ChamadoOcorrenciaViewModel();
            if (_enChamado == EnumChamado.Chamado)
                chamadoOcorrenciaViewModel = _chamadoOcorrenciaApp.PermissaoAlterarDataHora(Funcoes.IdUsuario, int.Parse(UsrUsuarioOco.txtId.Text), EnumChamado.Chamado);
            else
                chamadoOcorrenciaViewModel = _chamadoOcorrenciaApp.PermissaoAlterarDataHora(Funcoes.IdUsuario, int.Parse(UsrUsuarioOco.txtId.Text), EnumChamado.Atividade);

            bool permissao = Funcoes.PermitirEditar(chamadoOcorrenciaViewModel.Mensagem);
            if (!permissao)
            {
                // abrir tela senha
                if (_enChamado == EnumChamado.Chamado)
                {
                    frmSenhaPermissao frmSenhaPermissao = new frmSenhaPermissao("Lib_Chamado_Ocorr_Alt_Data_Hora", int.Parse(UsrUsuarioOco.txtId.Text));
                    frmSenhaPermissao.ShowDialog();
                    if (frmSenhaPermissao.DialogResult == DialogResult.OK)
                        HabilitarDataHora(true);
                }
                else
                {
                    frmSenhaPermissao frmSenhaPermissao = new frmSenhaPermissao("Lib_Atividade_Ocorr_Alt_Data_Hora", int.Parse(UsrUsuarioOco.txtId.Text));
                    frmSenhaPermissao.ShowDialog();
                    if (DialogResult == DialogResult.OK)
                        HabilitarDataHora(true);
                }
            }
            else
                HabilitarDataHora(permissao);
        }

        private void PreencherGridOcorrencia(int id, DateTime data, TimeSpan horaInicial, TimeSpan? horaFinal, string documento, string nomeUsuario, int usuarioId, int codUsuario)
        {
            dgvOcorrencia.Rows.Add(
                    id,
                    data,
                    horaInicial,
                    horaFinal,
                    documento,
                    nomeUsuario,
                    usuarioId,
                    codUsuario
                    );
        }

        private void dgvOcorrencia_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = Grade.RetornarId(ref dgvOcorrencia, "Id");
            var model = _chamadoViewModel.ChamadoOcorrencias.FirstOrDefault(x => x.Id == id);
            _chamadoViewModel.ChamadoOcorrencias.Remove(model);
        }

        private void dgvOcorrencia_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            NavegarOco();
        }

        private void TabControl2_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab == tpOcorrencia)
            {
                NavegarOco();
            }
        }

        private void LiberarDataEHoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlterarDataHora();
        }

        private void BtnAlterarDataHora_Click(object sender, EventArgs e)
        {
            AlterarDataHora();
        }

        private void UsrCliente_Leave(object sender, EventArgs e)
        {
            if (UsrCliente.Modificou)
            {
                var cliente = (ClienteViewModelApi)UsrCliente.RetornarObjeto();
                DadosClienteII(cliente);
            }
        }

        private void PermissaoExcluirOcorrencia()
        {
            if (_enChamado == EnumChamado.Chamado)
                btnExcluirOco.Enabled = _chamadoViewModel.PermissaoExcluirOcorrenciaChamado;
            else
                btnExcluirOco.Enabled = _chamadoViewModel.PermissaoExcluirOcorrenciaAtividade;
        }

        private void BtnExcluirOco_Click(object sender, EventArgs e)
        {
            if (dgvOcorrencia.RowCount == 0)
            {
                MessageBox.Show("Não há Registros!");
                return;
            }

            if (Funcoes.Confirmar("Deseja Excluir esta Ocorrência?"))
            {
                int id = Grade.RetornarId(ref dgvOcorrencia, "Id");
                var model = _chamadoViewModel.ChamadoOcorrencias.FirstOrDefault(x => x.Id == id);
                if (model != null)
                    _chamadoViewModel.ChamadoOcorrencias.Remove(model);

                Grade.ExcluirRegistro(ref dgvOcorrencia);
            }
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            var formulario = new frmCliente();
            //formulario.MdiParent = this;
            Tela.AbrirFormulario(formulario);
        }

        private void BtnEspecificao_Click(object sender, EventArgs e)
        {
            if (Funcoes.StrToInt(UsrCliente.txtId.Text) == 0)
            {
                MessageBox.Show("Não há Registros!");
                return;
            }

            frmClienteEspecificacao formulario = new frmClienteEspecificacao(Funcoes.StrToInt(UsrCliente.txtId.Text));
            formulario.ShowDialog();
        }

        private void BtnModulo_Click(object sender, EventArgs e)
        {
            frmClienteModulo formulario = new frmClienteModulo(int.Parse(UsrCliente.txtId.Text));
            formulario.ShowDialog();
        }

        private void BtnAnexo2_Click(object sender, EventArgs e)
        {
            frmChamadoAnexos frmChamadoAnexos = new frmChamadoAnexos(Grade.RetornarId(ref dgvDados, "Cha_Id"));
            frmChamadoAnexos.ShowDialog();
        }

        private void BtnSolucao_Click(object sender, EventArgs e)
        {
            frmChamadoProblemaSolucao formulario = new frmChamadoProblemaSolucao(_chamadoViewModel.ClienteId,
                Funcoes.IdUsuario, EnumChamado.Chamado);
            formulario.ShowDialog();
        }

        private void BtnColaborador_Click(object sender, EventArgs e)
        {
            if (dgvOcorrencia.RowCount > 0)
            {
                int id = Grade.RetornarId(ref dgvOcorrencia, "Id");
                var ocorrencia = _chamadoViewModel.ChamadoOcorrencias.FirstOrDefault(x => x.Id == id);
                frmChamadoColaborador formulario = new frmChamadoColaborador(ocorrencia);
                formulario.ShowDialog();
            }
        }
    }
}
