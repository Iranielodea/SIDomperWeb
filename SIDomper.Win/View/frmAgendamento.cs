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
    public partial class frmAgendamento : frmBase
    {
        AgendamentoApp _agendamentoApp;
        int _Id;
        List<AgendamentoConsultaViewModel> _listaConsulta = new List<AgendamentoConsultaViewModel>();
        GridColunas<AgendamentoConsultaViewModel> _grid = new GridColunas<AgendamentoConsultaViewModel>();

        public frmAgendamento()
        {
            Iniciar();
            FiltrarDados("ABCDE");
            ModoPesquisa = false;
        }

        public frmAgendamento(string texto)
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

            cbCampos.DataSource = Grade.ListarCampos(ref dgvDados);
            cbCampos.SelectedIndex = 2;
            cbPesquisa.Enabled = false;

            UsrUsuario.Programa(EnProgramas.Usuario, true, false, "Usuário", false);
            UsrTipo.ProgramaTipo(EnProgramas.Tipo, true, true, "", true, EnTipos.Agendamento);
            UsrStatus.ProgramaStatus(EnProgramas.Status, true, false, "", false, EnStatus.Agendamento);
            UsrCliente.Programa(EnProgramas.Cliente, true);

            int altura = tpUsuario.Height;
            int largura = tpUsuario.Width;

            _agendamentoApp = new AgendamentoApp();

            ursFiltroStatus.PosicaoTela(altura, largura);
            ursFiltroTipo.PosicaoTela(altura, largura);
            ursFiltroUsuario.PosicaoTela(altura, largura);
            ursFiltroCliente.PosicaoTela(altura, largura);
        }

        public override void Novo()
        {
            txtCodigo.txtValor.ReadOnly = true;
            try
            {
                _agendamentoApp = new AgendamentoApp();
                var model = _agendamentoApp.Novo(Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(model.Mensagem);

                base.Novo();

                Tela.LimparTela(tbPrincipal);
                usrData.txtData.Text = model.Data.ToString();
                txtHora.Text = model.Hora.ToString();

                UsrUsuario.txtId.Text = model.UsuarioId.ToString();
                UsrUsuario.SetCodigoMask(model.CodigoUsuario.ToString());
                UsrUsuario.txtNome.Text = model.NomeUsuario;

                UsrTipo.txtId.Text = model.TipoId.ToString();
                UsrTipo.SetCodigoMask(model.CodigoTipo.ToString());
                UsrTipo.txtNome.Text = model.NomeTipo;

                UsrStatus.txtId.Text = model.StatusId.ToString();
                UsrStatus.SetCodigoMask(model.CodigoStatus.ToString());
                UsrStatus.txtNome.Text = model.NomeStatus;

                rbVisita.Checked = (model.Programa == 2);
                rbAtividade.Checked = (model.Programa == 7);

                usrData.txtData.Focus();
                _Id = 0;
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
            UsrUsuario.LimparTela();
        }

        public override void Editar()
        {
            try
            {
                _agendamentoApp = new AgendamentoApp();
                var model = _agendamentoApp.Editar(Funcoes.IdUsuario, Grade.RetornarId(ref dgvDados, "Age_Id"));
                btnSalvar.Enabled = Funcoes.PermitirEditar(model.Mensagem);

                base.Editar();

                Tela.LimparTela(tbPrincipal);
                LimparTela();

                txtCodigo.txtValor.Text = model.Id.ToString("000000");
                txtContato.Text = model.Contato;
                usrData.txtData.Text = model.Data.ToString();
                txtHora.Text = model.Hora.ToString();

                UsrUsuario.txtId.Text = model.UsuarioId.ToString();
                UsrUsuario.SetCodigoMask(model.CodigoUsuario.ToString());
                UsrUsuario.txtNome.Text = model.NomeUsuario;

                UsrCliente.txtId.Text = model.ClienteId.ToString();
                UsrCliente.SetCodigoMask(model.CodigoCliente.ToString());
                UsrCliente.txtNome.Text = model.NomeCliente;

                UsrTipo.txtId.Text = model.TipoId.ToString();
                UsrTipo.SetCodigoMask(model.CodigoTipo.ToString());
                UsrTipo.txtNome.Text = model.NomeTipo;

                UsrStatus.txtId.Text = model.StatusId.ToString();
                UsrStatus.SetCodigoMask(model.CodigoStatus.ToString());
                UsrStatus.txtNome.Text = model.NomeStatus;

                rbVisita.Checked = (model.Programa == 2);
                rbAtividade.Checked = (model.Programa == 7);

                txtDescricao.Text = model.Descricao;

                usrData.txtData.Focus();
                _Id = model.Id;
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
                    _agendamentoApp = new AgendamentoApp();
                    int id = Grade.RetornarId(ref dgvDados, "Age_Id");
                    var model = _agendamentoApp.Excluir(Funcoes.IdUsuario, id);
                    Funcoes.VerificarMensagem(model.Mensagem);

                    _listaConsulta.Remove(_listaConsulta.First(x => x.Id == id));
                    dgvDados.DataSource = _listaConsulta.ToArray();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Validar(AgendamentoViewModel model)
        {
            if (model.ClienteId == 0)
                throw new Exception("Informe o Cliente!");
            if (model.TipoId == 0)
                throw new Exception("Informe o Tipo!");
            if (string.IsNullOrEmpty(model.Descricao))
                throw new Exception("Informe a Descrição!");
        }

        public override void Salvar()
        {
            try
            {
                _agendamentoApp = new AgendamentoApp();
                var agendamento = new AgendamentoViewModel();
                agendamento.Id = _Id;
                agendamento.Data = Funcoes.StrToDate(usrData.txtData.Text);
                agendamento.ClienteId = Funcoes.StrToInt(UsrCliente.txtId.Text);
                agendamento.Contato = txtContato.Text;
                agendamento.Descricao = txtDescricao.Text;
                agendamento.Hora = Funcoes.StrToHora(txtHora.Text);
                agendamento.NomeCliente = UsrCliente.txtNome.Text;
                agendamento.Programa = rbVisita.Checked ? 2 : 7;
                agendamento.StatusId = Funcoes.StrToInt(UsrStatus.txtId.Text);
                agendamento.TipoId = Funcoes.StrToInt(UsrTipo.txtId.Text);
                agendamento.UsuarioId = Funcoes.StrToInt(UsrUsuario.txtId.Text);

                Validar(agendamento);

                var model = _agendamentoApp.Salvar(agendamento, Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(model.Mensagem);

                Funcoes.VerificarMensagem(model.Mensagem);

                FiltrarDados(model.Id.ToString(), model.Id);

                base.Salvar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FiltrarDados(string texto, int id = 0)
        {
            try
            {
                string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

                var filtro = new AgendamentoFiltroViewModel();
                filtro.DataInicial = txtDataInicial.txtData.Text;
                filtro.DataFinal = txtDataFinal.txtData.Text;
                filtro.IdUsuario = ursFiltroUsuario.RetornarSelecao();
                filtro.IdCliente = ursFiltroCliente.RetornarSelecao();
                filtro.IdTipo = ursFiltroTipo.RetornarSelecao();
                filtro.IdStatus = ursFiltroStatus.RetornarSelecao();

                if (id > 0)
                {
                    sCampo = "Age_Id";
                    texto = id.ToString();
                    //filtro.Campo = "Bas_Id";
                    //filtro.Texto = id.ToString();
                }

                _listaConsulta = _agendamentoApp.Filtrar(filtro, sCampo, texto, Funcoes.IdUsuario, cbPesquisa.SelectedIndex == 0).ToList();
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
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "Age_Id");
                DialogResult = DialogResult.OK;
                base.Pesquisar();
            }
        }

        private void BuscarDados()
        {
            FiltrarDados(txtTexto.Text);
            cbCampos.Focus();
        }

        private void BuscarObservacoes()
        {
            frmObservacao frmObservacao = new frmObservacao(EnObservacao.Agendamento);
            if (frmObservacao.ShowDialog() == DialogResult.OK)
            {
                var obsApp = new ObservacaoApp();
                var observacao = obsApp.ObterPorId(Funcoes.IdSelecionado);
                txtDescricao.Text = txtDescricao.Text + " " + observacao.Descricao;
            }
        }

        private void txtTexto_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
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
            cbCampos.SelectedIndex = e.ColumnIndex-1;
        }

        private void frmAgendamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (UsrCliente.txtCodigo.txtValor.Focused)
                    UsrCliente.PressionarF9(EnProgramas.Cliente);
                if (UsrTipo.txtCodigo.txtValor.Focused)
                    UsrTipo.PressionarF9(EnProgramas.Tipo);
                if (txtDescricao.Focused)
                    BuscarObservacoes();

                if (tabControl3.SelectedTab == tpUsuario)
                    ursFiltroUsuario.AbrirTela();
                if (tabControl3.SelectedTab == tpCliente)
                    ursFiltroCliente.AbrirTela();
                if (tabControl3.SelectedTab == tpTipo)
                    ursFiltroTipo.AbrirTela();
                if (tabControl3.SelectedTab == tpStatus)
                    ursFiltroStatus.AbrirTela();
            }
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            this.KeyPreview = false;
        }

        private void txtDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
                Salvar();
            if (e.KeyCode == Keys.Escape)
                Voltar();
        }

        private void tabControl3_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedTab == tpUsuario)
            {
                ursFiltroUsuario.TipoDeCadastro(Filtros.TipoCadastro.Usuario);
                ursFiltroUsuario.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpTipo)
            {
                ursFiltroTipo.TipoDeCadastro(Filtros.TipoCadastro.Tipo, EnStatus.Agendamento, EnTipos.Agendamento);
                ursFiltroTipo.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpStatus)
            {
                ursFiltroStatus.TipoDeCadastro(Filtros.TipoCadastro.Status, EnStatus.Agendamento, EnTipos.Agendamento);
                ursFiltroStatus.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpCliente)
            {
                ursFiltroCliente.TipoDeCadastro(Filtros.TipoCadastro.Cliente);
                ursFiltroCliente.txtCodigo.txtValor.Focus();
            }
        }
    }
}
