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
    public partial class frmModulo : frmBase
    {
        ModuloApp _moduloApp;
        int _Id;
        List<ModuloViewModel> _listaConsulta = new List<ModuloViewModel>();
        GridColunas<ModuloViewModel> _grid = new GridColunas<ModuloViewModel>();

        public frmModulo()
        {
            Iniciar();
            FiltrarDados("ABCDE");
            ModoPesquisa = false;
        }

        public frmModulo(string texto, int idCliente = 0)
        {
            Iniciar();
            FiltrarDados(texto, idCliente);
            ModoPesquisa = true;
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

        private void FiltrarDados(string texto, int idCliente = 0)
        {
            string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

            _moduloApp = new ModuloApp();
            string ativo = cboAtivo.Text;
            _listaConsulta = _moduloApp.Filtrar(sCampo, texto, ativo.Substring(0, 1), idCliente).ToList();
            dgvDados.DataSource = _listaConsulta;
        }

        public override void Novo()
        {
            txtCodigo.txtValor.ReadOnly = false;
            try
            {
                _moduloApp = new ModuloApp();
                var model = _moduloApp.Novo(Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(model.Mensagem);

                base.Novo();

                Tela.LimparTela(tbPrincipal);
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

        public override void Editar()
        {
            try
            {
                _moduloApp = new ModuloApp();
                var model = _moduloApp.Editar(Grade.RetornarId(ref dgvDados, "Mod_Id"), Funcoes.IdUsuario);
                btnSalvar.Enabled = Funcoes.PermitirEditar(model.Mensagem);

                base.Editar();

                Tela.LimparTela(tbPrincipal);

                txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                txtNome.Text = model.Nome;
                chkAtivo.Checked = model.Ativo;

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
                    _moduloApp = new ModuloApp();
                    int id = Grade.RetornarId(ref dgvDados, "Mod_Id");
                    var model = _moduloApp.Excluir(id, Funcoes.IdUsuario);
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
                _moduloApp = new ModuloApp();
                var modulo = new ModuloViewModel();
                modulo.Id = _Id;
                modulo.Ativo = chkAtivo.Checked;
                modulo.Codigo = Funcoes.StrToInt(txtCodigo.txtValor.Text);
                modulo.Nome = txtNome.Text;

                var model = _moduloApp.Salvar(modulo);

                Funcoes.VerificarMensagem(model.Mensagem);

                if (_Id > 0)
                {
                    var temp = _listaConsulta.First(x => x.Id == _Id);
                    _listaConsulta.Remove(temp);
                };

                _listaConsulta.Add(model);

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
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "Mod_Id");
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

        private void dgvDados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _grid.OrdenarColunas(ref dgvDados, _listaConsulta, e);
            cbCampos.SelectedIndex = e.ColumnIndex - 1;
        }

        private void BuscarDados()
        {
            FiltrarDados(txtTexto.Text);
            cbCampos.Focus();
        }
    }
}
