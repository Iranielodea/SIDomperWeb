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
    public partial class frmCidade : frmBase
    {
        CidadeApp _cidadeApp;
        int _Id;
        CidadeViewModel _cidade;
        List<CidadeViewModel> _listaConsulta = new List<CidadeViewModel>();
        GridColunas<CidadeViewModel> _grid = new GridColunas<CidadeViewModel>();

        public frmCidade()
        {
            Iniciar();
            FiltrarDados("ABCDE");
            ModoPesquisa = false;
        }

        public frmCidade(string texto)
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
            cbCampos.SelectedIndex = 1;
            cbPesquisa.Enabled = false;
        }

        private void FiltrarDados(string texto)
        {
            string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

            _cidadeApp = new CidadeApp();
            string ativo = cboAtivo.Text;
            _listaConsulta = _cidadeApp.Filtrar(sCampo, texto, ativo.Substring(0, 1)).ToList();
            dgvDados.DataSource = _listaConsulta;
        }

        public override void Novo()
        {
            txtCodigo.txtValor.ReadOnly = false;
            try
            {
                _cidadeApp = new CidadeApp();
                var model = _cidadeApp.Novo(Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(model.Mensagem);

                base.Novo();

                _cidade = new CidadeViewModel();
                _cidade.Ativo = true;
                VincularDados();
                Tela.LimparTela(tbPrincipal);
                txtCodigo.txtValor.Text = model.Codigo.ToString("0000000");
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
                _cidadeApp = new CidadeApp();
                _cidade = _cidadeApp.Editar(Grade.RetornarId(ref dgvDados, "Cid_Id"), Funcoes.IdUsuario);
                btnSalvar.Enabled = Funcoes.PermitirEditar(_cidade.Mensagem);

                base.Editar();

                Tela.LimparTela(tbPrincipal);

                VincularDados();
                txtCodigo.txtValor.Text = _cidade.Codigo.ToString("0000000");

                txtNome.Focus();
                _Id = _cidade.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VincularDados()
        {
            Tela.Binding(ref txtNome, _cidade, "Nome");
            Tela.Binding(ref txtUF, _cidade, "UF");
            Tela.BindingCheckBox(ref chkAtivo, _cidade, "Ativo");
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
                    _cidadeApp = new CidadeApp();
                    int id = Grade.RetornarId(ref dgvDados, "Cid_Id");
                    var model = _cidadeApp.Excluir(id, Funcoes.IdUsuario);
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
                _cidadeApp = new CidadeApp();
                _cidade.Id = _Id;
                _cidade.Codigo = Funcoes.StrToInt(txtCodigo.txtValor.Text);

                var model = _cidadeApp.Salvar(_cidade);

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
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "Cid_Id");
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
            cbCampos.SelectedIndex = e.ColumnIndex - 1;
        }
    }
}
