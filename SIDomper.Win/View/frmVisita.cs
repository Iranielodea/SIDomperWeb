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
    public partial class frmVisita : frmBase
    {
        bool _quadro;
        bool _encerrarAgendamento;
        int _idCliente;
        int _idAgenda;
        bool _editar;

        VisitaApp _visitaApp;
        int _Id;
        VisitaViewModelApi _visita;

        List<VisitaConsultaViewModelApi> _listaConsulta = new List<VisitaConsultaViewModelApi>();
        GridColunas<VisitaConsultaViewModelApi> _grid = new GridColunas<VisitaConsultaViewModelApi>();

        public frmVisita()
        {
            Iniciar();
            FiltrarDados("ABCDE");
            ModoPesquisa = false;
        }

        public frmVisita(string texto)
        {
            Iniciar();
            FiltrarDados(texto);
            ModoPesquisa = true;
        }

        public frmVisita(bool quadro, bool encerrarAgenda, int idCliente, int idAgenda)
        {
            Iniciar();
            _quadro = quadro;
            _encerrarAgendamento = encerrarAgenda;
            _idCliente = idCliente;
            _idAgenda = idAgenda;

            if (quadro)
                Novo();
        }

        public frmVisita(int id, bool editar)
        {
            Iniciar();
            _Id = id;
            _editar = editar;
        }

        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            UsrUsuario.Programa(EnProgramas.Usuario, false, false, "Consultor", false);
            UsrCliente.Programa(EnProgramas.Cliente, true);
            UsrTipo.ProgramaTipo(EnProgramas.Tipo, true, true, "", true, EnTipos.Visita);
            UsrStatus.ProgramaStatus(EnProgramas.Status, true, true, "", true, EnStatus.Visita);

            Grade.Configurar(ref dgvDados);

            int altura = tpCliente.Height;
            int largura = tpCliente.Width;

            ursFiltroCliente.PosicaoTela(altura, largura);
            ursFiltroCidade.PosicaoTela(altura, largura);
            ursFiltroRevenda.PosicaoTela(altura, largura);
            ursFiltroStatus.PosicaoTela(altura, largura);
            ursFiltroTipo.PosicaoTela(altura, largura);
            ursFiltroUsuario.PosicaoTela(altura, largura);

            cbCampos.DataSource = Grade.ListarCampos(ref dgvDados);
            cbCampos.SelectedIndex = 1;
            txtCodigo.txtValor.ReadOnly = true;
        }

        public override void Novo()
        {
            txtCodigo.txtValor.ReadOnly = false;
            try
            {
                _visitaApp = new VisitaApp();
                var model = _visitaApp.Novo(Funcoes.IdUsuario, _idCliente, _idAgenda);
                Funcoes.VerificarMensagem(model.Mensagem);

                base.Novo();
                
                _visita = new VisitaViewModelApi();

                VincularDados();
                LimparTela();
                txtCodigo.txtValor.Text = model.Id.ToString(Tela.MaskVisita);

                UsrUsuario.txtId.Text = model.UsuarioId.ToString();
                UsrUsuario.SetCodigoMask(model.CodUsuario.ToString());
                UsrUsuario.txtNome.Text = model.NomeUsuario;
                txtData.txtData.Text = model.Data.ToString();
                txtDescricao.Text = model.Descricao;

                txtData.txtData.Focus();
                _Id = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimparTela()
        {
            Tela.LimparTela(tbPrincipal);
            UsrUsuario.LimparTela();
            UsrCliente.LimparTela();
            UsrTipo.LimparTela();
            UsrStatus.LimparTela();

            txtData.txtData.Clear();
            txtHoraInicial.Clear();
            txtHoraFinal.Clear();

            txtValor.txtValor.Text = "0,00";
            txtCodigo.txtValor.ReadOnly = true;
        }

        public override void Editar()
        {
            try
            {
                _visitaApp = new VisitaApp();
                _visita = _visitaApp.Editar(Grade.RetornarId(ref dgvDados, "Vis_Id"), Funcoes.IdUsuario);
                btnSalvar.Enabled = Funcoes.PermitirEditar(_visita.Mensagem);

                base.Editar();

                LimparTela();                

                VincularDados();
                txtCodigo.txtValor.Text = _visita.Id.ToString(Tela.MaskVisita);
                txtData.txtData.Text = _visita.Data.Date.ToString();
                txtHoraInicial.Text = _visita.HoraInicio.ToString();
                txtHoraFinal.Text = _visita.HoraFim.ToString();

                UsrUsuario.txtId.Text = _visita.UsuarioId.ToString();
                UsrUsuario.SetCodigoMask(_visita.CodUsuario.ToString());
                UsrUsuario.txtNome.Text = _visita.NomeUsuario;

                UsrCliente.txtId.Text = _visita.ClienteId.ToString();
                UsrCliente.SetCodigoMask(_visita.CodCliente.ToString());
                UsrCliente.txtNome.Text = _visita.NomeCliente;

                UsrTipo.txtId.Text = _visita.TipoId.ToString();
                UsrTipo.SetCodigoMask(_visita.CodTipo.ToString());
                UsrTipo.txtNome.Text = _visita.NomeTipo;

                UsrStatus.txtId.Text = _visita.StatusId.ToString();
                UsrStatus.SetCodigoMask(_visita.CodStatus.ToString());
                UsrStatus.txtNome.Text = _visita.NomeStatus;

                txtValor.txtValor.Text = _visita.Valor.ToString("n2");
                txtVersao.Text = _visita.Versao;

                txtDocto.Focus();
                _Id = _visita.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VincularDados()
        {
            Tela.Binding(ref txtDocto, _visita, "Dcto");
            Tela.Binding(ref txtContato, _visita, "Contato");
            Tela.Binding(ref txtVersao, _visita, "Versao");
            Tela.Binding(ref txtDescricao, _visita, "Descricao");
            Tela.Binding(ref txtFormaPagto, _visita, "FormaPagto");
            Tela.Binding(ref txtAnexo, _visita, "Anexo");
            //Tela.BindingMask(ref txtHoraInicial, _visita, "HoraInicio");
            //Tela.BindingMask(ref txtHoraFinal, _visita, "HoraFim");
        }

        public override void Filtrar()
        {
            FiltrarDados(txtTexto.Text);
            base.Filtrar();
        }

        public override void Filtro()
        {
            base.Filtro();
            tabControl3.SelectTab(0);
        }

        public override void Excluir()
        {
            base.Excluir();
            if (Funcoes.Confirmar("Confirmar Exclusão?"))
            {
                try
                {
                    _visitaApp = new VisitaApp();
                    int id = Grade.RetornarId(ref dgvDados, "Vis_Id");
                    var model = _visitaApp.Excluir(id, Funcoes.IdUsuario);
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
                if (Funcoes.DataEmBranco(txtData.txtData.Text))
                    throw new Exception("Informe a Data!");

                if (txtHoraInicial.Text.Trim() == ":")
                    throw new Exception("Informe a hora inicial!");

                if (txtHoraFinal.Text.Trim() == ":")
                    throw new Exception("Informe a hora final!");

                TimeSpan horaInicial = TimeSpan.Parse(txtHoraInicial.Text);
                TimeSpan horaFinal = TimeSpan.Parse(txtHoraFinal.Text);

                if (horaInicial > horaFinal)
                    throw new Exception("Hora inicial maior que hora final!");

                if (UsrCliente.txtId.Text == "")
                    throw new Exception("Informe o cliente!");

                if (UsrTipo.txtId.Text == "")
                    throw new Exception("Informe o Tipo!");

                if (UsrStatus.txtId.Text == "")
                    throw new Exception("Informe o Status!");

                _visitaApp = new VisitaApp();
                _visita.Id = _Id;
                _visita.Data = Funcoes.StrToDate(txtData.txtData.Text);
                _visita.HoraInicio = TimeSpan.Parse(txtHoraInicial.Text);
                _visita.HoraFim = TimeSpan.Parse(txtHoraFinal.Text);
                _visita.UsuarioId = int.Parse(UsrUsuario.txtId.Text);
                _visita.ClienteId = int.Parse(UsrCliente.txtId.Text);
                _visita.TipoId = int.Parse(UsrTipo.txtId.Text);
                _visita.StatusId = int.Parse(UsrStatus.txtId.Text);
                _visita.Valor = decimal.Parse(txtValor.txtValor.Text);
                _visita.Versao = txtVersao.Text;

                var model = _visitaApp.Salvar(_visita, Funcoes.IdUsuario);

                Funcoes.VerificarMensagem(model.Mensagem);


                // se encerrarAgendamento entao pegar o id da visita em uma variavel
                if (_encerrarAgendamento)
                    Funcoes.IdSelecionado = model.Id;

                //se quadro = true entao sair da tela
                if (_quadro)
                {
                    this.Close();
                    return;
                }

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

                var filtro = new VisitaFiltroViewModelApi();
                filtro.Campo = sCampo;
                filtro.Texto = texto;
                filtro.DataInicial = txtDataInicial.txtData.Text;
                filtro.DataFinal = txtDataFinal.txtData.Text;

                filtro.RevendaId = ursFiltroRevenda.RetornarSelecao();
                filtro.CidadeId = ursFiltroCidade.RetornarSelecao();
                filtro.UsuarioId = ursFiltroUsuario.RetornarSelecao();
                filtro.ClienteId = ursFiltroCliente.RetornarSelecao();
                filtro.TipoId = ursFiltroTipo.RetornarSelecao();
                filtro.StatusId = ursFiltroStatus.RetornarSelecao();
                filtro.Perfil = txtPerfil.Text;
                filtro.Id = Funcoes.StrToInt(txtIdFiltro.txtValor.Text);

                if (id > 0)
                {
                    filtro.Campo = "Vis_Id";
                    filtro.Texto = id.ToString();
                }

                _visitaApp = new VisitaApp();

                _listaConsulta = _visitaApp.Filtrar(filtro, Funcoes.IdUsuario, filtro.Campo, filtro.Texto).ToList();
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
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "Vis_Id");
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

        private void tabControl3_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedTab == tpFiltroPrincipal)
            {
                txtDataInicial.Focus();
            }

            if (tabControl3.SelectedTab == tpConsultor)
            {
                ursFiltroUsuario.TipoDeCadastro(Filtros.TipoCadastro.Usuario);
                ursFiltroUsuario.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpCliente)
            {
                ursFiltroCliente.TipoDeCadastro(Filtros.TipoCadastro.Cliente);
                ursFiltroCliente.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpTipo)
            {
                ursFiltroTipo.TipoDeCadastro(Filtros.TipoCadastro.Tipo, EnStatus.Versao, EnTipos.Visita);
                ursFiltroTipo.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpStatus)
            {
                ursFiltroStatus.TipoDeCadastro(Filtros.TipoCadastro.Status, EnStatus.Versao, EnTipos.Visita);
                ursFiltroStatus.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpRevenda)
            {
                ursFiltroRevenda.TipoDeCadastro(Filtros.TipoCadastro.Revenda);
                ursFiltroRevenda.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpCidade)
            {
                ursFiltroCidade.TipoDeCadastro(Filtros.TipoCadastro.Cidade);
                ursFiltroCidade.txtCodigo.txtValor.Focus();
            }
        }

        private void frmVisita_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (UsrCliente.txtCodigo.txtValor.Focused)
                    UsrCliente.PressionarF9(EnProgramas.Cliente);
                if (UsrTipo.txtCodigo.txtValor.Focused)
                    UsrTipo.PressionarF9(EnProgramas.Tipo);
                if (UsrStatus.txtCodigo.txtValor.Focused)
                    UsrStatus.PressionarF9(EnProgramas.Status);


                if (tabControl3.SelectedTab == tpCliente)
                    ursFiltroCliente.AbrirTela();
                else if (tabControl3.SelectedTab == tpConsultor)
                    ursFiltroUsuario.AbrirTela();
                else if (tabControl3.SelectedTab == tpTipo)
                    ursFiltroTipo.AbrirTela();
                else if (tabControl3.SelectedTab == tpStatus)
                    ursFiltroStatus.AbrirTela();
                else if (tabControl3.SelectedTab == tpRevenda)
                    ursFiltroRevenda.AbrirTela();
                else if (tabControl3.SelectedTab == tpCidade)
                    ursFiltroCidade.AbrirTela();
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

        private void txtDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            BuscarObservacao(sender, e, 1);
        }

        private void BuscarObservacao(object sender, KeyEventArgs e, int tipo)
        {
            if (e.KeyCode == Keys.F8)
            {
                btnSalvar.Focus();
                Salvar();
                return;
            }

            if (e.KeyCode == Keys.F9)
            {
                BuscarDescricao(tipo);
                return;
            }

            if (e.KeyCode == Keys.Escape)
                Voltar();
        }

        private void BuscarDescricao(int tipo)
        {
            frmObservacao frmObservacao = new frmObservacao(EnObservacao.Visita);
            if (frmObservacao.ShowDialog() == DialogResult.OK)
            {
                var obsApp = new ObservacaoApp();
                var observacao = obsApp.ObterPorId(Funcoes.IdSelecionado);
                if (tipo == 1)
                    txtDescricao.Text = txtDescricao.Text + " " + observacao.Descricao;
                else
                    txtFormaPagto.Text = txtFormaPagto.Text + " " + observacao.Descricao;
            }
        }

        private void txtFormaPagto_KeyDown(object sender, KeyEventArgs e)
        {
            BuscarObservacao(sender, e, 2);
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            this.KeyPreview = false;
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void txtFormaPagto_Leave(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void txtFormaPagto_Enter(object sender, EventArgs e)
        {
            this.KeyPreview = false;
        }

        private void enviarEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnviarEmail();
        }

        private void EnviarEmail()
        {
            if (dgvDados.Rows.Count > 0)
            {
                try
                {
                    _visitaApp = new VisitaApp();
                    _visita = new VisitaViewModelApi();
                    _visita.Id = Grade.RetornarId(ref dgvDados, "Vis_Id");
                    _visita = _visitaApp.EnviarEmail(_visita, Funcoes.IdUsuario);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message + Environment.NewLine + _visita.Mensagem);
                }
            }
        }

        private void frmVisita_Shown(object sender, EventArgs e)
        {
           //if (_quadro == true)
                // novo

           //if (_editar == true)
            // _editar

            // caminho
            // MostrarAnexo
            // MostrarFiltro
        }

        private void UsrCliente_Leave(object sender, EventArgs e)
        {
            if (UsrCliente.Modificou)
            {
                var cliente = (ClienteViewModelApi)UsrCliente.RetornarObjeto();
                txtVersao.Text = cliente.Versao;
            }
        }
    }
}
