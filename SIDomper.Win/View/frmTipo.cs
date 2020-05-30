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
    public partial class frmTipo : frmBase
    {
        TipoApp _tipoApp;
        int _Id;
        List<TipoConsultaViewModel> _listaConsulta = new List<TipoConsultaViewModel>();
        GridColunas<TipoConsultaViewModel> _grid = new GridColunas<TipoConsultaViewModel>();
        EnTipos _enTipo;

        public frmTipo(EnTipos enTipo)
        {
            Iniciar();
            FiltrarDados("ABCDE", enTipo);
            ModoPesquisa = false;
            _enTipo = enTipo;
        }

        public frmTipo(string texto, EnTipos enTipo)
        {
            Iniciar();
            FiltrarDados(texto, enTipo);
            ModoPesquisa = true;
            _enTipo = enTipo;
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

        private void FiltrarDados(string texto, EnTipos enTipo)
        {
            string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

            _tipoApp = new TipoApp();
            string ativo = cboAtivo.Text;

            if (sCampo == "NomePrograma")
                sCampo = "Tip_Programa";

            _listaConsulta = _tipoApp.Filtrar(sCampo, texto, enTipo, ativo.Substring(0, 1)).ToList();
            dgvDados.DataSource = _listaConsulta;
        }

        public override void Novo()
        {
            txtCodigo.txtValor.ReadOnly = false;
            try
            {
                _tipoApp = new TipoApp();
                var model = _tipoApp.Novo(Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(model.Mensagem);

                base.Novo();

                Tela.LimparTela(tbPrincipal);
                txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                txtCodigo.txtValor.ReadOnly = false;
                chkAtivo.Checked = true;

                rbChamado.Checked = true;
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
                _tipoApp = new TipoApp();
                var model = _tipoApp.Editar(Grade.RetornarId(ref dgvDados, "Tip_Id"), Funcoes.IdUsuario);
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
                rbOrcamento.Checked = (model.Programa == 9);
                rbOrcaNaoAprovado.Checked = (model.Programa == 91);
                rbRecado.Checked = (model.Programa == 10);

                txtNome.Focus();
                _Id = model.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void Filtrar()
        {
            FiltrarDados(txtTexto.Text, _enTipo);
            base.Filtrar();
        }

        public override void Excluir()
        {
            base.Excluir();
            if (Funcoes.Confirmar("Confirmar Exclusão?"))
            {
                try
                {
                    _tipoApp = new TipoApp();
                    int id = Grade.RetornarId(ref dgvDados, "Tip_Id");
                    var model = _tipoApp.Excluir(id, Funcoes.IdUsuario);
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
                _tipoApp = new TipoApp();
                var tipo = new TipoViewModel();
                tipo.Id = _Id;
                tipo.Ativo = chkAtivo.Checked;
                tipo.Codigo = Funcoes.StrToInt(txtCodigo.txtValor.Text);
                tipo.Nome = txtNome.Text;
                tipo.Conceito = txtConceito.Text;

                if (rbChamado.Checked)
                    tipo.Programa = 1;
                else if (rbVisita.Checked)
                    tipo.Programa = 2;
                else if (rbSolicitacao.Checked)
                    tipo.Programa = 3;
                else if (rbVersao.Checked)
                    tipo.Programa = 4;
                else if (rbQualidade.Checked)
                    tipo.Programa = 5;
                else if (rbBaseConh.Checked)
                    tipo.Programa = 6;
                else if (rbAtividade.Checked)
                    tipo.Programa = 7;
                else if (rbAgendamento.Checked)
                    tipo.Programa = 8;
                else if (rbOrcamento.Checked)
                    tipo.Programa = 9;
                else if (rbOrcaNaoAprovado.Checked)
                    tipo.Programa = 91;
                else if (rbRecado.Checked)
                    tipo.Programa = 10;

                var model = _tipoApp.Salvar(tipo);
                Funcoes.VerificarMensagem(model.Mensagem);

                _listaConsulta = _tipoApp.Filtrar("Tip_Id", model.Id.ToString(), _enTipo, "T", false).ToList();
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
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "Tip_Id");
                DialogResult = DialogResult.OK;
                base.Pesquisar();
            }
        }

        private void BuscarDados()
        {
            FiltrarDados(txtTexto.Text, _enTipo);
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
