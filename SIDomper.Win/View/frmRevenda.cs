using SIDomper.Apresentacao.App;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Base;
using SIDomper.Win.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SIDomper.Win.View
{
    public partial class frmRevenda : frmBase
    {
        RevendaApp _revendaApp;
        RevendaViewModel _revenda;
        int _Id;
        List<RevendaConsultaViewModel> _listaConsulta = new List<RevendaConsultaViewModel>();
        GridColunas<RevendaConsultaViewModel> _grid = new GridColunas<RevendaConsultaViewModel>();

        public frmRevenda()
        {
            Iniciar();
            FiltrarDados("ABCDE");
            ModoPesquisa = false;
        }

        public frmRevenda(string texto)
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
            Grade.Configurar(ref dgvEmail);

            cbCampos.DataSource = Grade.ListarCampos(ref dgvDados);
            cbCampos.SelectedIndex = 1;
            cbPesquisa.Enabled = false;
        }

        private void FiltrarDados(string texto)
        {
            string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

            _revendaApp = new RevendaApp();
            string ativo = cboAtivo.Text;
            _listaConsulta = _revendaApp.Filtrar(sCampo, texto, ativo.Substring(0, 1)).ToList();
            dgvDados.DataSource = _listaConsulta;
        }

        public override void Novo()
        {
            txtCodigo.txtValor.ReadOnly = false;
            try
            {
                _revendaApp = new RevendaApp();
                _revenda = new RevendaViewModel();

                var model = _revendaApp.Novo(Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(model.Mensagem);
                tabControl2.SelectTab(0);
                dgvEmail.Rows.Clear();

                base.Novo();

                LimparTela();
                txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                txtCodigo.txtValor.ReadOnly = false;
                chkAtivo.Checked = true;
                txtCodigo.txtValor.Focus();
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
            Tela.LimparTela(tpEmail);
        }

        public override void Editar()
        {
            try
            {
                _revendaApp = new RevendaApp();
                _revenda = new RevendaViewModel();

                _revenda = _revendaApp.Editar(Grade.RetornarId(ref dgvDados, "Rev_Id"), Funcoes.IdUsuario);
                btnSalvar.Enabled = Funcoes.PermitirEditar(_revenda.Mensagem);

                base.Editar();

                LimparTela();
                tabControl2.SelectTab(0);

                txtCodigo.txtValor.Text = _revenda.Codigo.ToString("0000");
                txtNome.Text = _revenda.Nome;
                chkAtivo.Checked = _revenda.Ativo;
                CarregarEmail();

                txtNome.Focus();
                _Id = _revenda.Id;

                NavegarEmail();
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
                    _revendaApp = new RevendaApp();
                    int id = Grade.RetornarId(ref dgvDados, "Rev_Id");
                    var model = _revendaApp.Excluir(id, Funcoes.IdUsuario);
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
                _revendaApp = new RevendaApp();

                _revenda.Id = _Id;
                _revenda.Ativo = chkAtivo.Checked;
                _revenda.Codigo = Funcoes.StrToInt(txtCodigo.txtValor.Text);
                _revenda.Nome = txtNome.Text;

                if (_revenda.RevendaEmails == null)
                    _revenda.RevendaEmails = new List<RevendaEmailViewModel>();

                _revenda.RevendaEmails.Clear();
                foreach (DataGridViewRow item in this.dgvEmail.Rows)
                {
                    var email = new RevendaEmailViewModel();
                    email.Email = item.Cells["Email"].Value.ToString();
                    email.Id = int.Parse(item.Cells["Id"].Value.ToString());
                    email.RevendaId = _Id;

                    _revenda.RevendaEmails.Add(email);
                }

                var model = _revendaApp.Salvar(_revenda);
                Funcoes.VerificarMensagem(model.Mensagem);

                _listaConsulta = _revendaApp.Filtrar("Rev_Id", model.Id.ToString(), "T").ToList();

                dgvDados.DataSource = _listaConsulta.Where(x => x.Id == model.Id).ToArray();

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
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "Rev_Id");
                DialogResult = DialogResult.OK;
                base.Pesquisar();
            }
        }

        private void BuscarDados()
        {
            FiltrarDados(txtTexto.Text);
            cbCampos.Focus();
        }

        private void NovoEmail()
        {
            EditarEmail();

            txtIdEmail.Text = "0";
            txtEmail.Clear();
            txtEmail.Focus();
        }

        private void SalvarEmail()
        {
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Email é obrigatório!");
                txtEmail.Focus();
                return;
            }

            int idEmail = 0;
            int.TryParse(txtIdEmail.Text, out idEmail);

            if (idEmail == 0)
            {
                dgvEmail.Rows.Add(idEmail, txtEmail.Text);
            }
            else
            {
                if (dgvDados.Rows.Count > 0)
                {
                    dgvEmail.CurrentRow.Cells["Email"].Value = txtEmail.Text;
                }
            }
            NavegarEmail();
            btnNovoEmail.Focus();
        }

        private void ExcluirEmail()
        {
            if (dgvEmail.RowCount > 0)
            {
                if (Funcoes.Confirmar("Confirmar Exclusão?"))
                {
                    dgvEmail.Rows.RemoveAt(this.dgvEmail.SelectedRows[0].Index);
                    PegarDadosEmail();
                    NavegarEmail();
                }
            }
        }

        private void EditarEmail()
        {
            btnNovoEmail.Enabled = false;
            btnExcluirEmail.Enabled = false;
            btnSalvarEmail.Enabled = true;
        }

        private void NavegarEmail()
        {
            btnNovoEmail.Enabled = true;
            btnExcluirEmail.Enabled = true;
            btnSalvarEmail.Enabled = true;
        }

        private void CarregarEmail()
        {
            dgvEmail.Rows.Clear();

            foreach (var item in _revenda.RevendaEmails)
            {
                dgvEmail.Rows.Add(item.Id, item.Email);
            }
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

        private void btnNovoEmail_Click(object sender, EventArgs e)
        {
            NovoEmail();
        }

        private void btnSalvarEmail_Click(object sender, EventArgs e)
        {
            SalvarEmail();
        }

        private void btnExcluirEmail_Click(object sender, EventArgs e)
        {
            ExcluirEmail();
        }

        private void dgvEmail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PegarDadosEmail();
        }

        private void PegarDadosEmail()
        {
            if (dgvEmail.RowCount > 0)
            {
                txtIdEmail.Text = Grade.RetornarValorCampo(ref dgvEmail, "Id");
                txtEmail.Text = Grade.RetornarValorCampo(ref dgvEmail, "Email");
                NavegarEmail();
            }
        }

        private void dgvEmail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                PegarDadosEmail();
        }

        private void frmRevenda_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    if (tabControl2.SelectedTab == tpEmail)
                    {
                        if (btnNovoEmail.Enabled)
                            NovoEmail();
                    }
                    break;
            }
            if (e.Control)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (tabControl2.SelectedTab == tpEmail)
                    {
                        if (btnExcluirEmail.Enabled && dgvEmail.Focused == false)
                            ExcluirEmail();
                    }
                }
            }
        }
    }
}
