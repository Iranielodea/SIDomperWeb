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
    public partial class frmObservacao : frmBase
    {
        ObservacaoApp _observacaoApp;
        int _Id;
        List<ObservacaoConsultaViewModel> _listaConsulta = new List<ObservacaoConsultaViewModel>();
        GridColunas<ObservacaoConsultaViewModel> _grid = new GridColunas<ObservacaoConsultaViewModel>();

        public frmObservacao()
        {
            Iniciar();
            FiltrarDados("ABCDE");
            ModoPesquisa = false;
        }

        public frmObservacao(string texto)
        {
            Iniciar();
            FiltrarDados(texto);
            ModoPesquisa = true;
        }

        public frmObservacao(EnObservacao enObservacao)
        {
            Iniciar();

            cbCampos.Enabled = false;
            txtTexto.Enabled = false;
            ModoPesquisa = true;

            int tipo = (int)enObservacao;

            _observacaoApp = new ObservacaoApp();
            _listaConsulta = _observacaoApp.Filtrar("Obs_Programa", tipo.ToString()).ToList();
            dgvDados.DataSource = _listaConsulta;
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

        private void FiltrarDados(string texto)
        {
            string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

            _observacaoApp = new ObservacaoApp();
            string ativo = cboAtivo.Text;

            _listaConsulta = _observacaoApp.Filtrar(sCampo, texto, ativo.Substring(0, 1)).ToList();
            dgvDados.DataSource = _listaConsulta;
        }

        public override void Novo()
        {
            txtCodigo.txtValor.ReadOnly = false;
            try
            {
                _observacaoApp = new ObservacaoApp();
                var model = _observacaoApp.Novo(Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(model.Mensagem);

                base.Novo();

                tabControl2.SelectedIndex = 0;

                Tela.LimparTela(tbPrincipal);
                Tela.LimparTela(tbEmail);

                txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                txtCodigo.txtValor.ReadOnly = false;
                chkAtivo.Checked = true;
                rbChamado.Checked = true;

                MostrarObsEmail();

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
                _observacaoApp = new ObservacaoApp();
                var model = _observacaoApp.Editar(Grade.RetornarId(ref dgvDados, "Obs_Id"), Funcoes.IdUsuario);
                btnSalvar.Enabled = Funcoes.PermitirEditar(model.Mensagem);

                base.Editar();

                Tela.LimparTela(tbPrincipal);
                Tela.LimparTela(tbEmail);

                _Id = model.Id;
                txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                txtNome.Text = model.Nome;
                txtDescricao.Text = model.Descricao;
                txtObsEmail.Text = model.ObsEmail;

                chkAtivo.Checked = model.Ativo;
                chkPadrao.Checked = model.Padrao;
                chkEmailPadrao.Checked = model.EmailPadrao;

                rbChamado.Checked = (model.Programa == 1);
                rbVisita.Checked = (model.Programa == 2);
                rbSolicitacao.Checked = (model.Programa == 3);
                rbVersao.Checked = (model.Programa == 4);
                rbQualidade.Checked = (model.Programa == 5);
                rbBaseConh.Checked = (model.Programa == 6);
                rbAtividade.Checked = (model.Programa == 7);
                rbAgendamento.Checked = (model.Programa == 8);
                rbOrcamento.Checked = (model.Programa == 9);

                MostrarObsEmail();

                txtNome.Focus();
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
                    _observacaoApp = new ObservacaoApp();
                    int id = Grade.RetornarId(ref dgvDados, "Obs_Id");
                    var model = _observacaoApp.Excluir(id, Funcoes.IdUsuario);
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
                _observacaoApp = new ObservacaoApp();
                var observacao = new ObservacaoViewModel();
                observacao.Id = _Id;
                observacao.Ativo = chkAtivo.Checked;
                observacao.Padrao = chkPadrao.Checked;
                observacao.EmailPadrao = chkEmailPadrao.Checked;
                observacao.Codigo = Funcoes.StrToInt(txtCodigo.txtValor.Text);
                observacao.Nome = txtNome.Text;
                observacao.Descricao = txtDescricao.Text;
                observacao.ObsEmail = txtObsEmail.Text;

                if (rbChamado.Checked)
                    observacao.Programa = 1;
                else if (rbVisita.Checked)
                    observacao.Programa = 2;
                else if (rbSolicitacao.Checked)
                    observacao.Programa = 3;
                else if (rbVersao.Checked)
                    observacao.Programa = 4;
                else if (rbQualidade.Checked)
                    observacao.Programa = 5;
                else if (rbBaseConh.Checked)
                    observacao.Programa = 6;
                else if (rbAtividade.Checked)
                    observacao.Programa = 7;
                else if (rbAgendamento.Checked)
                    observacao.Programa = 8;
                else if (rbOrcamento.Checked)
                    observacao.Programa = 9;

                var model = _observacaoApp.Salvar(observacao);
                Funcoes.VerificarMensagem(model.Mensagem);

                _listaConsulta = _observacaoApp.Filtrar("Obs_Id", model.Id.ToString(), "T", false).ToList();
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
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "Obs_Id");
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

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            this.KeyPreview = false;
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void txtObsEmail_Leave(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void txtObsEmail_Enter(object sender, EventArgs e)
        {
            this.KeyPreview = false;
        }

        private void txtDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            TeclasAtalho(e);
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

        private void txtObsEmail_KeyDown(object sender, KeyEventArgs e)
        {
            TeclasAtalho(e);
        }

        private void grPrograma_Leave(object sender, EventArgs e)
        {
            MostrarObsEmail();
        }

        private void MostrarObsEmail()
        {
            if (rbOrcamento.Checked)
            {
                if (tabControl2.TabCount == 1)
                    tabControl2.TabPages.Add(tbEmail);
            }
            else
            {
                if (tabControl2.TabCount == 2)
                    tabControl2.TabPages.Remove(tbEmail);
            }
        }
    }
}
