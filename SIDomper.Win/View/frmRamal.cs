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
    public partial class frmRamal : frmBase
    {
        private DataGridViewCell _celWasEndEdit;

        RamalApp _ramalApp;
        RamalViewModel _ramal;
        int _Id;
        List<RamalConsultaViewModel> _listaConsulta = new List<RamalConsultaViewModel>();
        GridColunas<RamalConsultaViewModel> _grid = new GridColunas<RamalConsultaViewModel>();

        public frmRamal()
        {
            Iniciar();
            FiltrarDados("ABCDE");
            ModoPesquisa = false;
        }

        public frmRamal(string texto)
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
            Grade.Configurar(ref dgvRamal, true, true);

            cbCampos.DataSource = Grade.ListarCampos(ref dgvDados);
            cbCampos.SelectedIndex = 0;
            cbPesquisa.Enabled = false;
        }

        private void FiltrarDados(string texto)
        {
            string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

            _ramalApp = new RamalApp();
            string ativo = cboAtivo.Text;
            _listaConsulta = _ramalApp.Filtrar(sCampo, texto).ToList();
            dgvDados.DataSource = _listaConsulta;
        }

        public override void Novo()
        {
            try
            {
                _ramalApp = new RamalApp();
                _ramal = new RamalViewModel();

                var model = _ramalApp.Novo(Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(model.Mensagem);
                tabControl2.SelectTab(0);
                dgvRamal.Rows.Clear();

                base.Novo();

                LimparTela();
                txtNome.Text = _ramal.Departamento;
                txtNome.Focus();
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
        }

        public override void Editar()
        {
            try
            {
                _ramalApp = new RamalApp();
                _ramal = new RamalViewModel();

                _ramal = _ramalApp.Editar(Grade.RetornarId(ref dgvDados, "Ram_Id"), Funcoes.IdUsuario);
                btnSalvar.Enabled = Funcoes.PermitirEditar(_ramal.Mensagem);

                base.Editar();

                LimparTela();
                tabControl2.SelectTab(0);

                txtNome.Text = _ramal.Departamento;
                CarregarRamais();
                txtNome.Focus();
                _Id = _ramal.Id;
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
                    _ramalApp = new RamalApp();
                    int id = Grade.RetornarId(ref dgvDados, "Ram_Id");
                    var model = _ramalApp.Excluir(id, Funcoes.IdUsuario);
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
                _ramalApp = new RamalApp();

                _ramal.Id = _Id;
                _ramal.Departamento = txtNome.Text;

                if (_ramal.RamalItens == null)
                    _ramal.RamalItens = new List<RamalItensViewModel>();

                _ramal.RamalItens.Clear();
                foreach (DataGridViewRow item in this.dgvRamal.Rows)
                {
                    if (item.Cells["Nome"].Value == null)
                        continue;

                    var itemRamal = new RamalItensViewModel();

                    int id;
                    try
                    {
                        id = Funcoes.StrToInt(item.Cells["Id"].Value.ToString());
                    }
                    catch
                    {
                        id = 0;
                    }

                    itemRamal.Id = id;
                    itemRamal.Numero = int.Parse(item.Cells["Numero"].Value.ToString());
                    itemRamal.Nome = item.Cells["Nome"].Value.ToString();
                    itemRamal.RamalId = _Id;

                    _ramal.RamalItens.Add(itemRamal);
                }

                var model = _ramalApp.Salvar(_ramal);
                Funcoes.VerificarMensagem(model.Mensagem);

                _listaConsulta = _ramalApp.Filtrar("Ram_Id", model.Id.ToString(), false).ToList();

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
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "Ram_Id");
                DialogResult = DialogResult.OK;
                base.Pesquisar();
            }
        }

        private void BuscarDados()
        {
            FiltrarDados(txtTexto.Text);
            cbCampos.Focus();
        }

        private void CarregarRamais()
        {
            dgvRamal.Rows.Clear();

            if (_ramal.RamalItens != null)
            {
                foreach (var item in _ramal.RamalItens)
                {
                    dgvRamal.Rows.Add(item.Id, item.Numero, item.Nome);
                }
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

        private void dgvRamal_KeyDown(object sender, KeyEventArgs e)
        {
            Grade.TeclaEnterKeyDown(ref dgvRamal, e, 1);

            switch(e.KeyCode)
            {
                case Keys.F8:
                    Salvar();
                    break;
                case Keys.Escape:
                    Voltar();
                    break;
            }

            if (e.Control)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (tabControl2.SelectedTab == tbPrincipal)
                    {
                        ExcluirRamal();
                    }
                }
            }
        }

        private void dgvRamal_Enter(object sender, EventArgs e)
        {
            this.KeyPreview = false;
        }

        private void dgvRamal_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _celWasEndEdit = dgvRamal[e.ColumnIndex, e.RowIndex];
        }

        private void dgvRamal_SelectionChanged(object sender, EventArgs e)
        {
            Grade.TelcaEnterSelectionChanged(ref dgvRamal, 1, _celWasEndEdit);
        }

        private void dgvRamal_Leave(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void ExcluirRamal()
        {
            if (Funcoes.Confirmar("Confirmar exclusão?"))
            {
                int selectedIndex = dgvRamal.CurrentCell.RowIndex;
                if (selectedIndex > -1)
                {
                    dgvRamal.Rows.RemoveAt(selectedIndex);
                    dgvRamal.Refresh();
                }
            }
        }
    }
}
