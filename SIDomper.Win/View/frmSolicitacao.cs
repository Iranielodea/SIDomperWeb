using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Constantes;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Funcoes;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Base;
using SIDomper.Win.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SIDomper.Win.View
{
    public partial class frmSolicitacao : frmBase
    {
        SolicitacaoApp _solicitacaoApp;
        private SolicitacaoViewModel _solicitacaoViewModel;
        int _Id;
        List<SolicitacaoConsultaViewModel> _listaConsulta = new List<SolicitacaoConsultaViewModel>();
        GridColunas<SolicitacaoConsultaViewModel> _grid = new GridColunas<SolicitacaoConsultaViewModel>();

        public frmSolicitacao()
        {
            Iniciar();
            FiltrarDados("ABCDE");
            ModoPesquisa = false;
        }

        public frmSolicitacao(string texto)
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
            Grade.Configurar(ref dgvCronograma, false, false);
            Grade.Configurar(ref dgvOcorrenciaGeral, false, false);
            Grade.Configurar(ref dgvOcorrenciaTecnica, false, false);
            Grade.Configurar(ref dgvOcorrenciaRegra, false, false);
            Grade.Configurar(ref dgvStatus, false, false);

            UsrUsuarioAbertura.Programa(EnProgramas.Usuario, false, false, "Usuário Abertura", false);
            UsrModulo.Programa(EnProgramas.Modulo);
            UsrProduto.Programa(EnProgramas.Produto, false, false, "Produto", false);
            UsrTipo.ProgramaTipo(EnProgramas.Tipo, true, true, "Tipo", true, EnTipos.Solicitacao);
            UsrStatus.ProgramaStatus(EnProgramas.Status, true, false, "Status", false, EnStatus.Solicitacao);
            UsrCliente.Programa(EnProgramas.Cliente, true, true, "Cliente");

            UsrAnalista.Programa(EnProgramas.Usuario, false, true, "Analista", true);
            UsrVersao.Programa(EnProgramas.Versao, true, true, "Versão");
            UsrTipoAnalista.ProgramaTipo(EnProgramas.Tipo, false, true, "Tipo", true, EnTipos.Solicitacao);
            UsrDesenvolvedor.Programa(EnProgramas.Usuario, true, true, "Desenvolvedor", true);
            UsrModuloAnalista.Programa(EnProgramas.Modulo);
            UsrProdutoAnalista.Programa(EnProgramas.Produto, false, false, "Produto", false);
            UsrCategoria.Programa(EnProgramas.Categoria);

            UsrCronoOperador.Programa(EnProgramas.Usuario, true, true, "Operador");
            UsrGeralUsuario.Programa(EnProgramas.Usuario, true, false, "Operador", false);
            UsrTecnicaUsuario.Programa(EnProgramas.Usuario, true, false, "Operador", false);
            UsrRegrasUsuario.Programa(EnProgramas.Usuario, true, false, "Operador", false);

            cbCampos.DataSource = Grade.ListarCampos(ref dgvDados);
            cbCampos.SelectedIndex = 6;
            cbPesquisa.Enabled = false;

            cbbNivel.SelectedIndex = 4;

            //UsrUsuario.Programa(EnProgramas.Usuario, true, false, "Usuário", false);
            //UsrTipo.ProgramaTipo(EnProgramas.Tipo, true, true, "", true, EnTipos.Solicitacao);
            //UsrStatus.ProgramaStatus(EnProgramas.Status, true, false, "", false, EnStatus.Solicitacao);
            //UsrCliente.Programa(EnProgramas.Cliente, true);

            //int altura = tpUsuario.Height;
            //int largura = tpUsuario.Width;

            _solicitacaoApp = new SolicitacaoApp();
            _solicitacaoViewModel = new SolicitacaoViewModel();

            //ursFiltroStatus.PosicaoTela(altura, largura);
            //ursFiltroTipo.PosicaoTela(altura, largura);
            //ursFiltroUsuario.PosicaoTela(altura, largura);
            //ursFiltroCliente.PosicaoTela(altura, largura);
        }

        public override void Filtrar()
        {
            FiltrarDados(txtTexto.Text, 0);
            base.Filtrar();
        }

        public override void Novo()
        {
            _solicitacaoApp = new SolicitacaoApp();
            var model = _solicitacaoApp.Novo(Funcoes.IdUsuario);
            _solicitacaoViewModel = model;
            _Id = 0;

            Funcoes.VerificarMensagem(model.Mensagem);

            base.Novo();

            LimparTela();
            UsrUsuarioAbertura.txtId.Text = model.UsuarioAberturaId.ToString();
            UsrUsuarioAbertura.SetCodigoMask(model.UsuarioAberturaCodigo.ToString());
            UsrUsuarioAbertura.txtNome.Text = model.UsuarioAberturaNome;

            UsrStatus.txtId.Text = model.StatusId.ToString();
            UsrStatus.SetCodigoMask(model.StatusCodigo.ToString());
            UsrStatus.txtNome.Text = model.StatusNome;

            txtData.txtData.Text = DateTime.Now.ToShortDateString();
            txtHora.Text = DateTime.Now.ToShortTimeString();

            txtData.txtData.Focus();
        }

        public override void Editar()
        {
            try
            {
                _solicitacaoApp = new SolicitacaoApp();
                var model = _solicitacaoApp.Editar(Funcoes.IdUsuario, Grade.RetornarId(ref dgvDados, "Sol_Id"));
                _solicitacaoViewModel = model;
                _Id = _solicitacaoViewModel.Id;

                btnSalvar.Enabled = Funcoes.PermitirEditar(model.Mensagem);

                base.Editar();

                LimparTela();

                txtCodigo.Text = _solicitacaoViewModel.Id.ToString("000000");
                txtData.txtData.Text = _solicitacaoViewModel.Data.ToShortDateString();
                txtHora.Text = _solicitacaoViewModel.Hora.ToString();

                UsrUsuarioAbertura.txtId.Text = _solicitacaoViewModel.UsuarioAberturaId.ToString();
                UsrUsuarioAbertura.SetCodigoMask(_solicitacaoViewModel.UsuarioAberturaCodigo.ToString());
                UsrUsuarioAbertura.txtNome.Text = _solicitacaoViewModel.UsuarioAberturaNome;

                if (_solicitacaoViewModel.ClienteId > 0)
                {
                    UsrCliente.txtId.Text = _solicitacaoViewModel.ClienteId.ToString();
                    UsrCliente.SetCodigoMask(_solicitacaoViewModel.ClienteCodigo.ToString());
                    UsrCliente.txtNome.Text = _solicitacaoViewModel.ClienteNome;
                }

                txtContato.Text = _solicitacaoViewModel.Contato;
                txtTitulo.Text = _solicitacaoViewModel.Titulo;

                UsrStatus.txtId.Text = _solicitacaoViewModel.StatusId.ToString();
                UsrStatus.SetCodigoMask(_solicitacaoViewModel.StatusCodigo.ToString());
                UsrStatus.txtNome.Text = _solicitacaoViewModel.StatusNome;

                if (_solicitacaoViewModel.TipoId != null)
                {
                    UsrTipo.txtId.Text = _solicitacaoViewModel.TipoId.ToString();
                    UsrTipo.SetCodigoMask(_solicitacaoViewModel.TipoCodigo.ToString());
                    UsrTipo.txtNome.Text = _solicitacaoViewModel.TipoNome;
                }

                txtVersao.Text = _solicitacaoViewModel.VersaoDescricao;

                if (_solicitacaoViewModel.ModuloId != null)
                {
                    UsrModulo.txtId.Text = _solicitacaoViewModel.ModuloId.ToString();
                    UsrModulo.SetCodigoMask(_solicitacaoViewModel.ModuloCodigo.ToString());
                    UsrModulo.txtNome.Text = _solicitacaoViewModel.ModuloNome;
                }

                if (_solicitacaoViewModel.ProdutoId != null)
                {
                    UsrProduto.txtId.Text = _solicitacaoViewModel.ProdutoId.ToString();
                    UsrProduto.SetCodigoMask(_solicitacaoViewModel.ProdutoCodigo.ToString());
                    UsrProduto.txtNome.Text = _solicitacaoViewModel.ProdutoNome;
                }

                txtAnexoAbertura.Text = _solicitacaoViewModel.Anexo;

                rbBaixo.Checked = (_solicitacaoViewModel.Nivel == 1);
                rbNormal.Checked = (_solicitacaoViewModel.Nivel == 2);
                rbAlto.Checked = (_solicitacaoViewModel.Nivel == 3);
                rbCritico.Checked = (_solicitacaoViewModel.Nivel == 4);

                DadosDescricaoAbertura(_solicitacaoViewModel);
                DadosAnalistaPrincipal(_solicitacaoViewModel);
                CarregarCronogramas(_solicitacaoViewModel);
                CarregarOcorrenciaGeral(_solicitacaoViewModel);
                CarregarOcorrenciaTecnica(_solicitacaoViewModel);
                CarregarOcorrenciaRegra(_solicitacaoViewModel);
                CarregarStatus(_solicitacaoViewModel);

                if (_solicitacaoViewModel.SolicitacaoOcorrencias.Count > 0)
                {
                    PreencherGradeInicial(1);
                    PreencherGradeInicial(2);
                    PreencherGradeInicial(3);
                }

                txtData.txtData.Focus();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void PreencherGradeInicial(int classificacao)
        {
            int id = _solicitacaoViewModel.SolicitacaoOcorrencias.FirstOrDefault(x => x.Classificacao == classificacao).Id;
            switch(classificacao)
            {
                case 1:
                    PopularOcorrenciaGeral(id);
                    break;
                case 2:
                    PopularOcorrenciaTecnica(id);
                    break;
                case 3:
                    PopularOcorrenciaRegras(id);
                    break;
            }
        }

        public override void Salvar()
        {
            try
            {
                if (btnCronoSalvar.Enabled)
                    throw new Exception("Salve o Cronograma!");
                if (btnGeralSalvar.Enabled)
                    throw new Exception("Salve a Ocorrência Geral!");
                if (btnTecnicoSalvar.Enabled)
                    throw new Exception("Salve a Ocorrência Técnica!");
                if (btnRegraSalvar.Enabled)
                    throw new Exception("Salve a Ocorrência Regra!");

                _solicitacaoViewModel.Id = _Id;
                _solicitacaoViewModel.Data = Funcoes.StrToDate(txtData.txtData.Text);
                _solicitacaoViewModel.Hora = Funcoes.StrToHora(txtHora.Text);
                _solicitacaoViewModel.ClienteId = Funcoes.StrToInt(UsrCliente.txtId.Text);
                _solicitacaoViewModel.UsuarioAberturaId = Funcoes.StrToInt(UsrUsuarioAbertura.txtId.Text);
                _solicitacaoViewModel.ModuloId = Funcoes.StrToIntNull(UsrModulo.txtId.Text);
                _solicitacaoViewModel.ProdutoId = Funcoes.StrToIntNull(UsrProduto.txtId.Text);
                _solicitacaoViewModel.Titulo = txtTitulo.Text;
                _solicitacaoViewModel.Descricao = txtDescricaoAbertura.Text;
                _solicitacaoViewModel.Nivel = RetornarNivel();
                _solicitacaoViewModel.Versao = txtVersao.Text;
                _solicitacaoViewModel.Anexo = txtAnexoAbertura.Text;
                _solicitacaoViewModel.AnalistaId = Funcoes.StrToIntNull(UsrAnalista.txtId.Text);
                _solicitacaoViewModel.StatusId = Funcoes.StrToInt(UsrStatus.txtId.Text);
                _solicitacaoViewModel.TipoId = Funcoes.StrToIntNull(UsrTipo.txtId.Text);
                _solicitacaoViewModel.TempoPrevisto = Funcoes.StrToDecimal(txtTempo.Text);
                _solicitacaoViewModel.PrevisaoEntrega = Funcoes.StrToDateNull(txtDataPrevisao.txtData.Text);
                _solicitacaoViewModel.DesenvolvedorId = Funcoes.StrToIntNull(UsrDesenvolvedor.txtId.Text);
                _solicitacaoViewModel.DescricaoLiberacao = txtDescricaoLiberacao.Rtf;
                _solicitacaoViewModel.UsuarioAtendeAtualId = Funcoes.IdUsuario;
                _solicitacaoViewModel.Contato = txtContato.Text;
                _solicitacaoViewModel.VersaoId = Funcoes.StrToIntNull(UsrVersao.txtId.Text);
                _solicitacaoViewModel.CategoriaId = Funcoes.StrToIntNull(UsrCategoria.txtId.Text);

                _solicitacaoApp = new SolicitacaoApp();
                var model = _solicitacaoApp.Salvar(_solicitacaoViewModel, Funcoes.IdUsuario, false);

                Funcoes.VerificarMensagem(model.Mensagem);
                FiltrarDados(model.Id.ToString(), model.Id);

                base.Salvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private int? RetornarNivel()
        {
            if (rbBaixo.Checked)
                return 1;
            else if (rbNormal.Checked)
                return 2;
            else if (rbAlto.Checked)
                return 3;
            else
                return 4;
        }

        private void DadosDescricaoAbertura(SolicitacaoViewModel viewModel)
        {
            txtDescricaoAbertura.Text = viewModel.Descricao;
        }

        private void DadosAnalistaPrincipal(SolicitacaoViewModel viewModel)
        {
            if (viewModel.AnalistaId.HasValue)
            {
                UsrAnalista.txtId.Text = viewModel.AnalistaId.ToString();
                UsrAnalista.SetCodigoMask(viewModel.AnalistaCodigo.ToString());
                UsrAnalista.txtNome.Text = viewModel.AnalistaNome;
            }

            if (viewModel.VersaoId.HasValue)
            {
                UsrVersao.SetCodigoMask(viewModel.VersaoId.Value.ToString());
                UsrVersao.txtId.Text = viewModel.VersaoId.Value.ToString();
                UsrVersao.txtNome.Text = viewModel.VersaoDescricao;
            }

            txtTempo.Text = Funcoes.DecimalNullToStr(viewModel.TempoPrevisto, "N2");
            txtDataPrevisao.txtData.Text = Funcoes.DateNullToStr(viewModel.PrevisaoEntrega.Value);

            if (viewModel.TipoId.HasValue)
            {
                UsrTipoAnalista.txtId.Text = viewModel.TipoId.ToString();
                UsrTipoAnalista.SetCodigoMask(viewModel.TipoCodigo.ToString());
                UsrTipoAnalista.txtNome.Text = viewModel.TipoNome;
            }

            if (viewModel.DesenvolvedorId.HasValue)
            {
                UsrDesenvolvedor.txtId.Text = viewModel.DesenvolvedorId.ToString();
                UsrDesenvolvedor.SetCodigoMask(viewModel.DesenvolvedorCodigo.ToString());
                UsrDesenvolvedor.txtNome.Text = viewModel.DesenvolvedorNome;
            }

            if (viewModel.ModuloId.HasValue)
            {
                UsrModuloAnalista.txtId.Text = viewModel.ModuloId.ToString();
                UsrModuloAnalista.SetCodigoMask(viewModel.ModuloCodigo.ToString());
                UsrModuloAnalista.txtNome.Text = viewModel.ModuloNome;
            }

            if (viewModel.ProdutoId.HasValue)
            {
                UsrProdutoAnalista.txtId.Text = viewModel.ProdutoId.ToString();
                UsrProdutoAnalista.SetCodigoMask(viewModel.ProdutoCodigo.ToString());
                UsrProdutoAnalista.txtNome.Text = viewModel.ProdutoNome;
            }

            if (viewModel.CategoriaId.HasValue)
            {
                UsrCategoria.txtId.Text = viewModel.CategoriaId.ToString();
                UsrCategoria.SetCodigoMask(viewModel.CategoriaCodigo.ToString());
                UsrCategoria.txtNome.Text = viewModel.CategoriaNome;
            }

            txtTituloAnalista.Text = viewModel.Titulo;
            txtDescricaoLiberacao.Rtf = viewModel.DescricaoLiberacao;
        }

        private void FiltrarDados(string texto, int id = 0)
        {
            try
            {
                string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

                var filtro = new SolicitacaoFiltroViewModel();
                filtro.DataInicial = txtDataInicial.txtData.Text;
                filtro.DataFinal = txtDataFinal.txtData.Text;
                filtro.Id = Funcoes.StrToInt(txtIdFiltro.txtValor.Text);
                //filtro.IdUsuarioAbertura = ursFiltroUsuario.RetornarSelecao();
                //filtro.IdCliente = ursFiltroCliente.RetornarSelecao();
                //filtro.IdTipo = ursFiltroTipo.RetornarSelecao();
                //filtro.IdStatus = ursFiltroStatus.RetornarSelecao();
                //sCampo = "Cli_Nome";
                if (id > 0)
                {
                    sCampo = "Sol_Id";
                    texto = id.ToString();
                    //filtro.Campo = "Bas_Id";
                    //filtro.Texto = id.ToString();
                }

                _listaConsulta = _solicitacaoApp.Filtrar(filtro, sCampo, texto, Funcoes.IdUsuario, cbPesquisa.SelectedIndex == 0).ToList();
                dgvDados.DataSource = _listaConsulta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimparTela()
        {
            Tela.LimparTela(tbPrincipal);
            Tela.LimparTela(tpAbertura);
            Tela.LimparTela(tpAnalistaPrincipal);
            Tela.LimparTela(tpCronograma);
            Tela.LimparTela(tpGeralEdicao);
            Tela.LimparTela(tpTecnicaEdicao);
            Tela.LimparTela(tpRegraEdicao);
            //Tela.LimparPage(ref tpOcorrencia);
            //UsrUsuario.LimparTela();
            UsrModulo.LimparTela();
            UsrProduto.LimparTela();
            UsrTipo.LimparTela();
            UsrStatus.LimparTela();
            UsrCliente.LimparTela();
            rbNormal.Checked = true;

            UsrAnalista.LimparTela();
            UsrAnalista.LimparTela();
            UsrDesenvolvedor.LimparTela();
            UsrCategoria.LimparTela();
            UsrVersao.LimparTela();
            UsrTipoAnalista.LimparTela();
            UsrModuloAnalista.LimparTela();
            UsrProdutoAnalista.LimparTela();
            txtDataPrevisao.txtData.Clear();
            txtDescricaoLiberacao.Clear();

            UsrCronoOperador.LimparTela();
            txtCronoData.txtData.Clear();

            UsrGeralUsuario.LimparTela();
            txtGeralData.txtData.Clear();
            txtDescricaoGeral.Clear();

            UsrTecnicaUsuario.LimparTela();
            txtTecnicaData.txtData.Clear();
            txtDescricaoTecnica.Clear();

            UsrRegrasUsuario.LimparTela();
            txtRegraData.txtData.Clear();
            txtDescricaoRegra.Clear();

            dgvCronograma.Rows.Clear();
            dgvOcorrenciaGeral.Rows.Clear();
            dgvOcorrenciaTecnica.Rows.Clear();
            dgvOcorrenciaRegra.Rows.Clear();
            dgvStatus.Rows.Clear();
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

        private void BuscarDados()
        {
            FiltrarDados(txtTexto.Text, 1718);
            cbCampos.Focus();
        }

        private void UsrCliente_Leave(object sender, EventArgs e)
        {
            if (UsrCliente.Modificou)
            {
                var cliente = (ClienteViewModelApi)UsrCliente.RetornarObjeto();
                BuscarModulos(cliente.Id);
            }
        }

        private void BuscarModulos(int idCliente)
        {
            UsrModulo.LimparTela();
            UsrProduto.LimparTela();

            var formulario = new frmModulo("", idCliente);
            formulario.ShowDialog();
            if (Funcoes.IdSelecionado > 0)
            {
                var model = _solicitacaoApp.BuscarModuloProduto(idCliente, Funcoes.IdSelecionado);
                if (model.ModuloId != null)
                {
                    UsrModulo.txtId.Text = model.ModuloId.ToString();
                    UsrModulo.SetCodigoMask(model.ModuloCodigo.ToString());
                    UsrModulo.txtNome.Text = model.ModuloNome;
                }

                if (model.ProdutoId != null)
                {
                    UsrProduto.txtId.Text = model.ProdutoId.ToString();
                    UsrProduto.SetCodigoMask(model.ProdutoCodigo.ToString());
                    UsrProduto.txtNome.Text = model.ProdutoNome;
                }
            }
        }

        private void txtDescricaoAbertura_Leave(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void txtDescricaoAbertura_Enter(object sender, EventArgs e)
        {
            this.KeyPreview = false;
        }

        private void txtDescricaoAbertura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Voltar();
            if (e.KeyCode == Keys.F8)
                Salvar();
            if (e.KeyCode == Keys.F9)
                BuscarDescricaoAbertura();
        }

        private void BuscarDescricaoAbertura()
        {
            frmObservacao frmObservacao = new frmObservacao(EnObservacao.Solicitação);
            if (frmObservacao.ShowDialog() == DialogResult.OK)
            {
                var obsApp = new ObservacaoApp();
                var observacao = obsApp.ObterPorId(Funcoes.IdSelecionado);
                txtDescricaoAbertura.Text = txtDescricaoAbertura.Text + " " + observacao.Descricao;
            }
        }

        private void CarregarCronogramas(SolicitacaoViewModel viewModel)
        {
            dgvCronograma.Rows.Clear();

            if (viewModel.SolicitacaoCronogramas != null)
            {
                foreach (var item in viewModel.SolicitacaoCronogramas)
                {
                    dgvCronograma.Rows.Add(item.Id, item.Data, item.HoraInicio, item.HoraFim, item.NomeUsuario, item.UsuarioId, item.CodigoUsuario);
                }
            }

            //OpenFileDialog openFile1 = new OpenFileDialog();

            //// Initialize the OpenFileDialog to look for RTF files.
            //openFile1.DefaultExt = "*.rtf";
            //openFile1.Filter = "RTF Files|*.rtf";

            //// Determine whether the user selected a file from the OpenFileDialog.
            //if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
            //   openFile1.FileName.Length > 0)
            //{
            //    // Load the contents of the file into the RichTextBox.
            //    richTextBox1.LoadFile(openFile1.FileName);
            //}


            //SaveFileDialog saveFile1 = new SaveFileDialog();

            //// Initialize the SaveFileDialog to specify the RTF extension for the file.
            //saveFile1.DefaultExt = "*.rtf";
            //saveFile1.Filter = "RTF Files|*.rtf";

            //// Determine if the user selected a file name from the saveFileDialog.
            //if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
            //   saveFile1.FileName.Length > 0)
            //{
            //    // Save the contents of the RichTextBox into the file.
            //    richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            //}
        }

        private void NovoCronograma()
        {
            Tela.BotaoPadraoNovo(ref btnCronoNovo, ref btnCronoEditar, ref btnCronoSalvar, ref btnCronoExcluir, ref btnCronoCancelar);
            BloquearCronograma(false);
            UsrCronoOperador.LimparTela();
            txtCronoData.txtData.Clear();
            txtCronoHoraInicial.Clear();
            txtCronoHoraFinal.Clear();
            txtIdCronograma.Text = _solicitacaoViewModel.CronogramaRetornarMenorId().ToString();
            UsrCronoOperador.txtCodigo.Focus();
        }

        private void PopularCronograma(int id)
        {
            if (dgvCronograma.RowCount > 0)
            {
                if (id == 0)
                    id = int.Parse(Grade.RetornarId(ref dgvCronograma, "Id").ToString());

                var model = _solicitacaoViewModel.SolicitacaoCronogramas.FirstOrDefault(x => x.Id == id);

                txtIdCronograma.Text = model.Id.ToString();
                UsrCronoOperador.txtId.Text = model.UsuarioId.ToString();
                UsrCronoOperador.SetCodigoMask(model.CodigoUsuario.ToString());
                UsrCronoOperador.txtNome.Text = model.NomeUsuario;

                txtCronoData.txtData.Text = model.Data.Value.ToShortDateString();
                txtCronoHoraInicial.Text = model.HoraInicio.ToString();
                txtCronoHoraFinal.Text = model.HoraFim.ToString();
            }
        }

        private void PopularOcorrenciaGeral(int id)
        {
            if (dgvOcorrenciaGeral.RowCount > 0)
            {
                if (id == 0)
                    id = int.Parse(Grade.RetornarId(ref dgvOcorrenciaGeral, "SOcor_Id").ToString());

                var model = _solicitacaoViewModel.SolicitacaoOcorrencias.FirstOrDefault(x => x.Id == id);

                if (model != null)
                {
                    txtIdOcorrenciaGeral.Text = model.Id.ToString();
                    UsrGeralUsuario.txtId.Text = model.UsuarioId.ToString();
                    UsrGeralUsuario.SetCodigoMask(model.CodigoUsuario.ToString());
                    UsrGeralUsuario.txtNome.Text = model.NomeUsuario;

                    txtGeralData.txtData.Text = model.Data.ToShortDateString();
                    txtGeralHora.Text = model.Hora.ToString();
                    txtDescricaoGeral.Text = model.Descricao;
                    txtAnexoGeral.Text = model.Anexo;
                }
            }
        }

        private void PopularOcorrenciaTecnica(int id)
        {
            if (dgvOcorrenciaTecnica.RowCount > 0)
            {
                if (id == 0)
                    id = int.Parse(Grade.RetornarId(ref dgvOcorrenciaGeral, "TecnicaId").ToString());

                var model = _solicitacaoViewModel.SolicitacaoOcorrencias.FirstOrDefault(x => x.Id == id);
                if (model != null)
                {
                    txtIdOcorrenciaTecnica.Text = model.Id.ToString();
                    UsrTecnicaUsuario.txtId.Text = model.UsuarioId.ToString();
                    UsrTecnicaUsuario.SetCodigoMask(model.CodigoUsuario.ToString());
                    UsrTecnicaUsuario.txtNome.Text = model.NomeUsuario;

                    txtTecnicaData.txtData.Text = model.Data.ToString();
                    txtTecnicaHora.Text = model.Hora.ToString();
                    txtDescricaoTecnica.Rtf = model.Descricao;
                    txtAnexoTecnico.Text = model.Anexo;
                }
                //txtIdOcorrenciaTecnica.Text = Grade.RetornarId(ref dgvOcorrenciaTecnica, "TecnicaId").ToString();
                //UsrTecnicaUsuario.txtId.Text = Grade.RetornarValorCampo(ref dgvOcorrenciaTecnica, "TecnicaUsuarioId");
                //UsrTecnicaUsuario.SetCodigoMask(Grade.RetornarValorCampo(ref dgvOcorrenciaTecnica, "TecnicaCodigoUsuario"));
                //UsrTecnicaUsuario.txtNome.Text = Grade.RetornarValorCampo(ref dgvOcorrenciaTecnica, "TecnicaNomeUsuario");

                //txtTecnicaData.txtData.Text = Grade.RetornarValorCampo(ref dgvOcorrenciaTecnica, "TecnicaData");
                //txtTecnicaHora.Text = Grade.RetornarValorCampo(ref dgvOcorrenciaTecnica, "TecnicaHora");
                //txtDescricaoTecnica.Rtf = Grade.RetornarValorCampo(ref dgvOcorrenciaTecnica, "TecnicaDescricao");
                //txtAnexoTecnico.Text = Grade.RetornarValorCampo(ref dgvOcorrenciaTecnica, "TecnicaAnexo");

            }
        }

        private void PopularOcorrenciaRegras(int id)
        {
            if (dgvOcorrenciaRegra.RowCount > 0)
            {
                if (id == 0)
                    id = int.Parse(Grade.RetornarId(ref dgvOcorrenciaGeral, "RegraId").ToString());

                var model = _solicitacaoViewModel.SolicitacaoOcorrencias.FirstOrDefault(x => x.Id == id);
                if (model != null)
                {
                    txtIdOcorrenciaRegra.Text = model.Id.ToString();
                    UsrRegrasUsuario.txtId.Text = model.UsuarioId.ToString();
                    UsrRegrasUsuario.SetCodigoMask(model.CodigoUsuario.ToString());
                    UsrRegrasUsuario.txtNome.Text = model.NomeUsuario;

                    txtRegraData.txtData.Text = model.Data.ToString();
                    txtRegraHora.Text = model.Hora.ToString();
                    txtDescricaoRegra.Text = model.Descricao;
                    txtAnexoRegra.Text = model.Anexo;
                }

                //txtIdOcorrenciaRegra.Text = Grade.RetornarId(ref dgvOcorrenciaRegra, "RegraId").ToString();
                //UsrRegrasUsuario.txtId.Text = Grade.RetornarValorCampo(ref dgvOcorrenciaRegra, "RegraUsuarioId");
                //UsrRegrasUsuario.SetCodigoMask(Grade.RetornarValorCampo(ref dgvOcorrenciaRegra, "RegraCodigoUsuario"));
                //UsrRegrasUsuario.txtNome.Text = Grade.RetornarValorCampo(ref dgvOcorrenciaRegra, "RegraNomeUsuario");

                //txtRegraData.txtData.Text = Grade.RetornarValorCampo(ref dgvOcorrenciaRegra, "RegraData");
                //txtRegraHora.Text = Grade.RetornarValorCampo(ref dgvOcorrenciaRegra, "RegraHora");
                //txtDescricaoRegra.Text = Grade.RetornarValorCampo(ref dgvOcorrenciaRegra, "RegraDescricao");
                //txtAnexoRegra.Text = Grade.RetornarValorCampo(ref dgvOcorrenciaRegra, "RegraAnexo");
            }
        }

        private void EditarCronograma()
        {
            if (dgvCronograma.RowCount > 0)
            {
                Tela.BotaoPadraoEditar(ref btnCronoNovo, ref btnCronoEditar, ref btnCronoSalvar, ref btnCronoExcluir, ref btnCronoCancelar);
                PopularCronograma(0);
                BloquearCronograma(false);
            }
        }

        private void ExcluirCronograma()
        {
            if (dgvCronograma.RowCount > 0)
            {
                if (Funcoes.Confirmar("Deseja Excluir?"))
                {
                    int id = Grade.RetornarId(ref dgvCronograma, "Id");
                    var model = _solicitacaoViewModel.SolicitacaoCronogramas.FirstOrDefault(x => x.Id == id);
                    if (model != null)
                        _solicitacaoViewModel.SolicitacaoCronogramas.Remove(model);

                    Grade.ExcluirRegistro(ref dgvCronograma);
                    PopularCronograma(id);
                    CarregarCronogramas(_solicitacaoViewModel);
                    Tela.BotaoPadraoExcluir(ref btnCronoNovo, ref btnCronoEditar, ref btnCronoSalvar, ref btnCronoExcluir, ref btnCronoCancelar);
                }
            }
        }

        private void SalvarCronograma()
        {
            var model = _solicitacaoViewModel.SolicitacaoCronogramas.FirstOrDefault(x => x.Id == Convert.ToInt32(txtIdCronograma.Text));

            if (model == null)
                model = new SolicitacaoCronogramaViewModel();

            model.HoraInicio = TimeSpan.Parse(txtCronoHoraInicial.Text);
            model.HoraFim = TimeSpan.Parse(txtCronoHoraFinal.Text);
            model.Id = int.Parse(txtIdCronograma.Text);
            model.SolicitacaoId = _solicitacaoViewModel.Id;
            model.UsuarioId = int.Parse(UsrCronoOperador.txtId.Text);
            model.Data = DateTime.Parse(txtCronoData.txtData.Text);
            model.CodigoUsuario = Funcoes.StrToInt(UsrCronoOperador.txtCodigo.txtValor.Text);
            model.NomeUsuario = UsrCronoOperador.txtNome.Text;

            if (model.Id <= 0)
                _solicitacaoViewModel.SolicitacaoCronogramas.Add(model);

            CarregarCronogramas(_solicitacaoViewModel);
            Tela.BotaoPadraoSalvar(ref btnCronoNovo, ref btnCronoEditar, ref btnCronoSalvar, ref btnCronoExcluir, ref btnCronoCancelar);
            BloquearCronograma(true);
        }

        private void CancelarCronograma()
        {
            Tela.BotaoPadraoCancelar(ref btnCronoNovo, ref btnCronoEditar, ref btnCronoSalvar, ref btnCronoExcluir, ref btnCronoCancelar);
            PopularCronograma(0);
            //ela.HabilitarDesabilitar(tpGeralEdicao, true);
            BloquearCronograma(true);
        }

        private void NovoGeral()
        {
            Tela.BotaoPadraoNovo(ref btnGeralNovo, ref btnGeralEditar, ref btnGeralSalvar, ref btnGeralExcluir, ref btnGeralCancelar);
            UsrGeralUsuario.LimparTela();
            Tela.HabilitarDesabilitar(tpGeralEdicao, true);
            UsrGeralUsuario.txtId.Text = Funcoes.IdUsuario.ToString();
            UsrGeralUsuario.SetCodigoMask(Funcoes.CodigoUsuarioLogado.ToString());
            UsrGeralUsuario.txtNome.Text = Funcoes.NomeUsuarioLogado;
            txtGeralData.txtData.Text = DateTime.Now.ToShortDateString();
            txtGeralHora.Text = DateTime.Now.ToShortTimeString();
            txtDescricaoGeral.Clear();
            txtAnexoGeral.Clear();
            tabControl5.SelectedIndex = 0;
            txtIdOcorrenciaGeral.Text = _solicitacaoViewModel.OcorrenciaRetornarMenorId().ToString();
            txtGeralData.Focus();
        }

        private void BloquearCronograma(bool bloquear)
        {
            UsrCronoOperador.Enabled = !bloquear;
            txtCronoData.Enabled = !bloquear;
            txtCronoHoraInicial.Enabled = !bloquear;
            txtCronoHoraFinal.Enabled = !bloquear;
        }

        private void EditarGeral()
        {
            if (dgvOcorrenciaGeral.RowCount > 0)
            {
                if (UsuarioPermissaoMenu.Lib_Solicitacao_Ocorr_Geral_Alt == false)
                {
                    MessageBox.Show(Mensagem.UsuarioSemPermissao);
                    return;
                }

                Tela.HabilitarDesabilitar(tpGeralEdicao, true);
                Tela.BotaoPadraoEditar(ref btnGeralNovo, ref btnGeralEditar, ref btnGeralSalvar, ref btnGeralExcluir, ref btnGeralCancelar);
                tabControl5.SelectedIndex = 0;
                PopularOcorrenciaGeral(0);
                txtGeralData.Focus();
            }
        }

        private void SalvarGeral()
        {
            SalvarOcorrencias(
                Funcoes.StrToInt(txtIdOcorrenciaGeral.Text),
                txtAnexoGeral.Text,
                1,
                Funcoes.StrToInt(UsrGeralUsuario.txtId.Text),
                Funcoes.StrToInt(UsrGeralUsuario.txtCodigo.txtValor.Text),
                UsrGeralUsuario.txtNome.Text,
                Funcoes.StrToDate(txtGeralData.txtData.Text),
                txtDescricaoGeral.Text,
                Funcoes.StrToHora(txtGeralHora.Text)
            );

            CarregarOcorrenciaGeral(_solicitacaoViewModel);

            Tela.BotaoPadraoSalvar(ref btnGeralNovo, ref btnGeralEditar, ref btnGeralSalvar, ref btnGeralExcluir, ref btnGeralCancelar);
            Tela.HabilitarDesabilitar(tpGeralEdicao, false);
        }

        private void ExcluirGeral()
        {
            if (dgvOcorrenciaGeral.RowCount > 0)
            {
                if (UsuarioPermissaoMenu.Lib_Solicitacao_Ocorr_Geral_Exc == false)
                {
                    MessageBox.Show(Mensagem.UsuarioSemPermissao);
                    return;
                }

                if (Funcoes.Confirmar("Deseja Excluir?"))
                {
                    int id = Grade.RetornarId(ref dgvOcorrenciaGeral, "SOcor_Id");
                    var model = _solicitacaoViewModel.SolicitacaoOcorrencias.FirstOrDefault(x => x.Id == id);

                    if (model != null)
                        _solicitacaoViewModel.SolicitacaoOcorrencias.Remove(model);

                    Grade.ExcluirRegistro(ref dgvOcorrenciaGeral);
                    Tela.BotaoPadraoExcluir(ref btnGeralNovo, ref btnGeralEditar, ref btnGeralSalvar, ref btnGeralExcluir, ref btnGeralCancelar);
                    PopularOcorrenciaGeral(id);
                }
            }
        }

        private void CancelarGeral()
        {
            Tela.BotaoPadraoCancelar(ref btnGeralNovo, ref btnGeralEditar, ref btnGeralSalvar, ref btnGeralExcluir, ref btnGeralCancelar);
            PopularOcorrenciaGeral(0);
            Tela.HabilitarDesabilitar(tpGeralEdicao, false);
        }

        private void NovoTecnica()
        {
            Tela.HabilitarDesabilitar(tpTecnicaEdicao, true);
            Tela.BotaoPadraoNovo(ref btnTecnicoNovo, ref btnTecnicoEditar, ref btnTecnicoSalvar, ref btnTecnicoExcluir, ref btnTecnicoCancelar);
            UsrTecnicaUsuario.LimparTela();

            UsrTecnicaUsuario.txtId.Text = Funcoes.IdUsuario.ToString();
            UsrTecnicaUsuario.SetCodigoMask(Funcoes.CodigoUsuarioLogado.ToString());
            UsrTecnicaUsuario.txtNome.Text = Funcoes.NomeUsuarioLogado;
            txtTecnicaData.txtData.Text = DateTime.Now.ToShortDateString();
            txtTecnicaHora.Text = DateTime.Now.ToShortTimeString();
            txtDescricaoTecnica.Clear();
            txtAnexoTecnico.Clear();
            tabControl6.SelectedIndex = 0;
            txtIdOcorrenciaTecnica.Text = _solicitacaoViewModel.OcorrenciaRetornarMenorId().ToString();
            txtTecnicaData.Focus();
        }

        private void EditarTecnica()
        {
            if (dgvOcorrenciaTecnica.RowCount > 0)
            {
                if (UsuarioPermissaoMenu.Lib_Solicitacao_Ocorr_Tecnica_Alt == false)
                {
                    MessageBox.Show(Mensagem.UsuarioSemPermissao);
                    return;
                }

                Tela.HabilitarDesabilitar(tpTecnicaEdicao, true);
                Tela.BotaoPadraoEditar(ref btnTecnicoNovo, ref btnTecnicoEditar, ref btnTecnicoSalvar, ref btnTecnicoExcluir, ref btnTecnicoCancelar);
                tabControl6.SelectedIndex = 0;
                PopularOcorrenciaTecnica(0);
                txtTecnicaData.Focus();
            }
        }

        private void SalvarTecnica()
        {
            SalvarOcorrencias(
                Funcoes.StrToInt(txtIdOcorrenciaTecnica.Text),
                txtAnexoTecnico.Text,
                2,
                Funcoes.StrToInt(UsrTecnicaUsuario.txtId.Text),
                Funcoes.StrToInt(UsrTecnicaUsuario.txtCodigo.txtValor.Text),
                UsrTecnicaUsuario.txtNome.Text,
                Funcoes.StrToDate(txtTecnicaData.txtData.Text),
                txtDescricaoTecnica.Rtf,
                Funcoes.StrToHora(txtTecnicaHora.Text)
            );

            CarregarOcorrenciaTecnica(_solicitacaoViewModel);

            Tela.HabilitarDesabilitar(tpTecnicaEdicao, false);
            Tela.BotaoPadraoSalvar(ref btnTecnicoNovo, ref btnTecnicoEditar, ref btnTecnicoSalvar, ref btnTecnicoExcluir, ref btnTecnicoCancelar);
        }

        private void ExcluirTecnica()
        {
            if (dgvOcorrenciaTecnica.RowCount > 0)
            {
                if (UsuarioPermissaoMenu.Lib_Solicitacao_Ocorr_Tecnica_Exc == false)
                {
                    MessageBox.Show(Mensagem.UsuarioSemPermissao);
                    return;
                }

                if (Funcoes.Confirmar("Deseja Excluir?"))
                {
                    int id = Grade.RetornarId(ref dgvOcorrenciaTecnica, "TecnicaId");
                    var model = _solicitacaoViewModel.SolicitacaoOcorrencias.FirstOrDefault(x => x.Id == id);

                    if (model != null)
                        _solicitacaoViewModel.SolicitacaoOcorrencias.Remove(model);

                    Grade.ExcluirRegistro(ref dgvOcorrenciaTecnica);
                    Tela.BotaoPadraoExcluir(ref btnTecnicoNovo, ref btnTecnicoEditar, ref btnTecnicoSalvar, ref btnTecnicoExcluir, ref btnTecnicoCancelar);
                    PopularOcorrenciaTecnica(0);
                }
            }
        }

        private void CancelarTecnica()
        {
            Tela.HabilitarDesabilitar(tpTecnicaEdicao, false);
            Tela.BotaoPadraoCancelar(ref btnTecnicoNovo, ref btnTecnicoEditar, ref btnTecnicoSalvar, ref btnTecnicoExcluir, ref btnTecnicoCancelar);
            PopularOcorrenciaTecnica(0);
        }

        private void NovoRegra()
        {
            Tela.HabilitarDesabilitar(tpRegraEdicao, true);
            Tela.BotaoPadraoNovo(ref btnRegraNovo, ref btnRegraEditar, ref btnRegraSalvar, ref btnRegraExcluir, ref btnRegraCancelar);
            UsrRegrasUsuario.LimparTela();

            UsrRegrasUsuario.txtId.Text = Funcoes.IdUsuario.ToString();
            UsrRegrasUsuario.SetCodigoMask(Funcoes.CodigoUsuarioLogado.ToString());
            UsrRegrasUsuario.txtNome.Text = Funcoes.NomeUsuarioLogado;
            txtRegraData.txtData.Text = DateTime.Now.ToShortDateString();
            txtRegraHora.Text = DateTime.Now.ToShortTimeString();
            txtDescricaoRegra.Clear();
            txtAnexoRegra.Clear();
            tabControl7.SelectedIndex = 0;
            txtIdOcorrenciaRegra.Text = _solicitacaoViewModel.OcorrenciaRetornarMenorId().ToString();
            txtRegraData.Focus();
        }

        private void EditarRegra()
        {
            if (dgvOcorrenciaRegra.RowCount > 0)
            {
                if (UsuarioPermissaoMenu.Lib_Solicitacao_Ocorr_Regra_Alt == false)
                {
                    MessageBox.Show(Mensagem.UsuarioSemPermissao);
                    return;
                }

                Tela.HabilitarDesabilitar(tpRegraEdicao, true);
                Tela.BotaoPadraoEditar(ref btnRegraNovo, ref btnRegraEditar, ref btnRegraSalvar, ref btnRegraExcluir, ref btnRegraCancelar);
                tabControl7.SelectedIndex = 0;
                PopularOcorrenciaRegras(0);
                txtRegraData.Focus();
            }
        }

        private void SalvarOcorrencias(int id, string anexo, int classificacao,
            int usuarioId, int codigoUsuario, string nomeUsuario, DateTime data, string descricao,
            TimeSpan hora)
        {
            var model = _solicitacaoViewModel.SolicitacaoOcorrencias.FirstOrDefault(x => x.Id == id);

            if (model == null)
                model = new SolicitacaoOcorrenciaViewModel();

            model.Anexo = anexo;
            model.Classificacao = classificacao;
            model.UsuarioId = usuarioId;
            model.CodigoUsuario = codigoUsuario;
            model.NomeUsuario = nomeUsuario;
            model.Data = data;
            model.Descricao = descricao;
            model.Hora = hora;
            model.Id = id;
            model.SolicitacaoId = _solicitacaoViewModel.Id;

            if (model.Id <= 0)
                _solicitacaoViewModel.SolicitacaoOcorrencias.Add(model);

            if (classificacao == 1)
                CarregarOcorrenciaGeral(_solicitacaoViewModel);
            if (classificacao == 2)
                CarregarOcorrenciaTecnica(_solicitacaoViewModel);
            if (classificacao == 3)
                CarregarOcorrenciaRegra(_solicitacaoViewModel);
        }

        private void SalvarRegra()
        {
            SalvarOcorrencias(
                Funcoes.StrToInt(txtIdOcorrenciaRegra.Text),
                txtAnexoRegra.Text,
                3,
                Funcoes.StrToInt(UsrRegrasUsuario.txtId.Text),
                Funcoes.StrToInt(UsrRegrasUsuario.txtCodigo.txtValor.Text),
                UsrRegrasUsuario.txtNome.Text,
                Funcoes.StrToDate(txtRegraData.txtData.Text),
                txtDescricaoRegra.Text,
                Funcoes.StrToHora(txtRegraHora.Text)
            );

            CarregarOcorrenciaRegra(_solicitacaoViewModel);

            Tela.HabilitarDesabilitar(tpRegraEdicao, false);
            Tela.BotaoPadraoSalvar(ref btnRegraNovo, ref btnRegraEditar, ref btnRegraSalvar, ref btnRegraExcluir, ref btnRegraCancelar);
        }

        private void ExcluirRegra()
        {
            if (dgvOcorrenciaRegra.RowCount > 0)
            {
                if (UsuarioPermissaoMenu.Lib_Solicitacao_Ocorr_Regra_Exc == false)
                {
                    MessageBox.Show(Mensagem.UsuarioSemPermissao);
                    return;
                }

                if (Funcoes.Confirmar("Deseja Excluir?"))
                {
                    int id = Grade.RetornarId(ref dgvOcorrenciaRegra, "RegraId");
                    var model = _solicitacaoViewModel.SolicitacaoOcorrencias.FirstOrDefault(x => x.Id == id);
                    if (model != null)
                        _solicitacaoViewModel.SolicitacaoOcorrencias.Remove(model);

                    Grade.ExcluirRegistro(ref dgvOcorrenciaRegra);
                    Tela.BotaoPadraoExcluir(ref btnRegraNovo, ref btnRegraEditar, ref btnRegraSalvar, ref btnRegraExcluir, ref btnRegraCancelar);
                    PopularOcorrenciaRegras(0);
                }
            }
        }

        private void CancelarRegra()
        {
            Tela.HabilitarDesabilitar(tpRegraEdicao, false);
            Tela.BotaoPadraoCancelar(ref btnRegraNovo, ref btnRegraEditar, ref btnRegraSalvar, ref btnRegraExcluir, ref btnRegraCancelar);
            PopularOcorrenciaRegras(0);
        }

        private void btnCronoEditar_Click(object sender, EventArgs e)
        {
            EditarCronograma();
        }

        private void btnCronoNovo_Click(object sender, EventArgs e)
        {
            NovoCronograma();
        }

        private void btnCronoExcluir_Click(object sender, EventArgs e)
        {
            ExcluirCronograma();
        }

        private void btnCronoSalvar_Click(object sender, EventArgs e)
        {
            SalvarCronograma();
        }

        private void btnCronoCancelar_Click(object sender, EventArgs e)
        {
            CancelarCronograma();
        }

        private void dgvCronograma_KeyUp(object sender, KeyEventArgs e)
        {
            CancelarCronograma();
        }

        private void dgvCronograma_MouseUp(object sender, MouseEventArgs e)
        {
            CancelarCronograma();
        }

        private void CarregarOcorrenciaGeral(SolicitacaoViewModel viewModel)
        {
            dgvOcorrenciaGeral.Rows.Clear();

            if (viewModel.SolicitacaoOcorrencias != null)
            {
                var lista = viewModel.SolicitacaoOcorrencias.Where(x => x.Classificacao == 1);
                foreach (var item in lista)
                {
                    dgvOcorrenciaGeral.Rows.Add(item.Id, item.Data, item.Hora, item.UsuarioId, item.CodigoUsuario, item.NomeUsuario, item.Anexo, item.Descricao);
                }
            }
        }

        private void CarregarOcorrenciaTecnica(SolicitacaoViewModel viewModel)
        {
            dgvOcorrenciaTecnica.Rows.Clear();

            if (viewModel.SolicitacaoOcorrencias != null)
            {
                var lista = viewModel.SolicitacaoOcorrencias.Where(x => x.Classificacao == 2);
                foreach (var item in lista)
                {
                    dgvOcorrenciaTecnica.Rows.Add(item.Id, item.Data, item.Hora, item.UsuarioId, item.CodigoUsuario, item.NomeUsuario, item.Anexo, item.Descricao);
                }
            }
        }

        private void CarregarOcorrenciaRegra(SolicitacaoViewModel viewModel)
        {
            dgvOcorrenciaRegra.Rows.Clear();

            if (viewModel.SolicitacaoOcorrencias != null)
            {
                var lista = viewModel.SolicitacaoOcorrencias.Where(x => x.Classificacao == 3);
                foreach (var item in lista)
                {
                    dgvOcorrenciaRegra.Rows.Add(item.Id, item.Data, item.Hora, item.UsuarioId, item.CodigoUsuario, item.NomeUsuario, item.Anexo, item.Descricao);
                }
            }
        }

        private void CarregarStatus(SolicitacaoViewModel viewModel)
        {
            dgvStatus.Rows.Clear();

            if (viewModel.SolicitacaoStatus != null)
            {
                foreach (var item in viewModel.SolicitacaoStatus)
                {
                    dgvStatus.Rows.Add(item.Id, item.Data, item.Hora, item.NomeStatus, item.NomeUsuario);
                }
            }
        }

        private void btnGeralNovo_Click(object sender, EventArgs e)
        {
            NovoGeral();
        }

        private void btnGeralEditar_Click(object sender, EventArgs e)
        {
            EditarGeral();
        }

        private void btnGeralSalvar_Click(object sender, EventArgs e)
        {
            SalvarGeral();
        }

        private void btnGeralExcluir_Click(object sender, EventArgs e)
        {
            ExcluirGeral();
        }

        private void btnGeralCancelar_Click(object sender, EventArgs e)
        {
            CancelarGeral();
        }

        private void btnTecnicoNovo_Click(object sender, EventArgs e)
        {
            NovoTecnica();
        }

        private void btnTecnicoEditar_Click(object sender, EventArgs e)
        {
            EditarTecnica();
        }

        private void btnTecnicoSalvar_Click(object sender, EventArgs e)
        {
            SalvarTecnica();
        }

        private void btnTecnicoExcluir_Click(object sender, EventArgs e)
        {
            ExcluirTecnica();
        }

        private void btnTecnicoCancelar_Click(object sender, EventArgs e)
        {
            CancelarTecnica();
        }

        private void btnRegraNovo_Click(object sender, EventArgs e)
        {
            NovoRegra();
        }

        private void btnRegraEditar_Click(object sender, EventArgs e)
        {
            EditarRegra();
        }

        private void btnRegraSalvar_Click(object sender, EventArgs e)
        {
            SalvarRegra();
        }

        private void btnRegraExcluir_Click(object sender, EventArgs e)
        {
            ExcluirRegra();
        }

        private void btnRegraCancelar_Click(object sender, EventArgs e)
        {
            CancelarRegra();
        }

        private void dgvOcorrenciaGeral_KeyUp(object sender, KeyEventArgs e)
        {
            CancelarGeral();
        }

        private void dgvOcorrenciaGeral_MouseUp(object sender, MouseEventArgs e)
        {
            CancelarGeral();
        }

        private void dgvOcorrenciaTecnica_KeyUp(object sender, KeyEventArgs e)
        {
            CancelarTecnica();
        }

        private void dgvOcorrenciaTecnica_MouseUp(object sender, MouseEventArgs e)
        {
            CancelarTecnica();
        }

        private void dgvOcorrenciaRegra_KeyUp(object sender, KeyEventArgs e)
        {
            CancelarRegra();
        }

        private void dgvOcorrenciaRegra_MouseUp(object sender, MouseEventArgs e)
        {
            CancelarRegra();
        }

        private void btnAnexoAb_Click(object sender, EventArgs e)
        {
            Funcoes.AbrirAnexo(ref txtAnexoAbertura);
        }

        private void btnVisualizarAb_Click(object sender, EventArgs e)
        {
            Funcoes.VisualizarAnexo(ref txtAnexoAbertura);
        }

        private void btnAnexoGeral_Click(object sender, EventArgs e)
        {
            Funcoes.AbrirAnexo(ref txtAnexoGeral);
        }

        private void btnVisualizarGeral_Click(object sender, EventArgs e)
        {
            Funcoes.VisualizarAnexo(ref txtAnexoGeral);
        }

        private void btnAnexoTecnico_Click(object sender, EventArgs e)
        {
            Funcoes.AbrirAnexo(ref txtAnexoTecnico);
        }

        private void btnVisualizarTecnico_Click(object sender, EventArgs e)
        {
            Funcoes.VisualizarAnexo(ref txtAnexoTecnico);
        }

        private void btnAnexoRegra_Click(object sender, EventArgs e)
        {
            Funcoes.AbrirAnexo(ref txtAnexoRegra);
        }

        private void btnVisualizarRegra_Click(object sender, EventArgs e)
        {
            Funcoes.VisualizarAnexo(ref txtAnexoRegra);
        }

        private void dgvDados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _grid.OrdenarColunas(ref dgvDados, _listaConsulta, e);
            cbCampos.SelectedIndex = e.ColumnIndex;
        }
    }
}
