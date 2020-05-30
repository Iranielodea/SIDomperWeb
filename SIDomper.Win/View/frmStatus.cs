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
    public partial class frmStatus : frmBase
    {
        StatusApp _statusApp;
        int _Id;
        List<StatusConsultaViewModel> _listaConsulta = new List<StatusConsultaViewModel>();
        GridColunas<StatusConsultaViewModel> _grid = new GridColunas<StatusConsultaViewModel>();
        EnStatus _enStatus;

        public frmStatus(EnStatus enStatus)
        {
            Iniciar();
            FiltrarDados("ABCDE", enStatus);
            ModoPesquisa = false;
            _enStatus = enStatus;
        }

        public frmStatus(string texto, EnStatus enStatus)
        {
            Iniciar();
            FiltrarDados(texto, enStatus);
            ModoPesquisa = true;
            _enStatus = enStatus;
        }

        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            Grade.Configurar(ref dgvDados);

            cbCampos.DataSource = Grade.ListarCampos(ref dgvDados);
            cbCampos.SelectedIndex = 1;
            cbPesquisa.Enabled = false;
        }

        private void FiltrarDados(string texto, EnStatus enStatus)
        {
            string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

            _statusApp = new StatusApp();
            string ativo = cboAtivo.Text;

            if (sCampo == "NomePrograma")
                sCampo = "Sta_Programa";

            _listaConsulta = _statusApp.Filtrar(sCampo, texto, enStatus, ativo.Substring(0, 1)).ToList();
            dgvDados.DataSource = _listaConsulta;
        }

        public override void Novo()
        {
            txtCodigo.txtValor.ReadOnly = false;
            try
            {
                _statusApp = new StatusApp();
                var model = _statusApp.Novo(Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(model.Mensagem);

                base.Novo();

                Tela.LimparTela(tbPrincipal);
                Tela.LimparTela(grNotificacao);
                txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                txtCodigo.txtValor.ReadOnly = false;
                rbChamado.Checked = true;
                chkAtivo.Checked = true;
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
                _statusApp = new StatusApp();
                var model = _statusApp.Editar(Grade.RetornarId(ref dgvDados, "Sta_Id"), Funcoes.IdUsuario, EnStatus.Todos);
                btnSalvar.Enabled =  Funcoes.PermitirEditar(model.Mensagem);

                base.Editar();

                Tela.LimparTela(tbPrincipal);

                txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                txtNome.Text = model.Nome;
                txtConceito.Text = model.Conceito;
                chkAtivo.Checked = model.Ativo;

                rbChamado.Checked = (model.Programa == 1);
                rbVisita.Checked = (model.Programa == 2);
                rbSolicitacao.Checked = (model.Programa == 3);
                rbVersao.Checked = (model.Programa == 4);
                rbQualidade.Checked = (model.Programa == 5);
                rbBaseConh.Checked = (model.Programa == 6);
                rbAtividade.Checked = (model.Programa == 7);
                rbAgendamento.Checked = (model.Programa == 8);
                rbRecado.Checked = (model.Programa == 10);

                chkNotCliente.Checked = model.NotificarCliente;
                chkNotConsultor.Checked = model.NotificarConsultor;
                chkNotRevenda.Checked = model.NotificarRevenda;
                chkNotSupervisor.Checked = model.NotificarSupervisor;

                txtNome.Focus();
                txtCodigo.txtValor.ReadOnly = true;
                _Id = model.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void Filtrar()
        {
            FiltrarDados(txtTexto.Text, _enStatus);
            base.Filtrar();
        }

        public override void Excluir()
        {
            base.Excluir();
            if (Funcoes.Confirmar("Confirmar Exclusão?"))
            {
                try
                {
                    _statusApp = new StatusApp();
                    int id = Grade.RetornarId(ref dgvDados, "Sta_Id");
                    var model = _statusApp.Excluir(id, Funcoes.IdUsuario);
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
                _statusApp = new StatusApp();
                var status = new StatusViewModel();
                status.Id = _Id;
                status.Ativo = chkAtivo.Checked;
                status.Codigo = Funcoes.StrToInt(txtCodigo.txtValor.Text);
                status.Nome = txtNome.Text;
                status.Conceito = txtConceito.Text;

                if (rbChamado.Checked)
                    status.Programa = 1;
                else if (rbVisita.Checked)
                    status.Programa = 2;
                else if (rbSolicitacao.Checked)
                    status.Programa = 3;
                else if (rbVersao.Checked)
                    status.Programa = 4;
                else if (rbQualidade.Checked)
                    status.Programa = 5;
                else if (rbBaseConh.Checked)
                    status.Programa = 6;
                else if (rbAtividade.Checked)
                    status.Programa = 7;
                else if (rbAgendamento.Checked)
                    status.Programa = 8;
                else if (rbRecado.Checked)
                    status.Programa = 10;

                status.NotificarCliente = chkNotCliente.Checked;
                status.NotificarConsultor = chkNotConsultor.Checked;
                status.NotificarRevenda = chkNotRevenda.Checked;
                status.NotificarSupervisor = chkNotSupervisor.Checked;

                var model = _statusApp.Salvar(status);

                Funcoes.VerificarMensagem(model.Mensagem);

                _listaConsulta = _statusApp.Filtrar("Sta_Id", model.Id.ToString(), _enStatus, "T", false).ToList();
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
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "Sta_Id");
                DialogResult = DialogResult.OK;
                base.Pesquisar();
            }
        }

        private void BuscarDados()
        {
            FiltrarDados(txtTexto.Text, _enStatus);
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
    }
}
