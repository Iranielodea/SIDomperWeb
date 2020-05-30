using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Base;
using SIDomper.Win.Utilitarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIDomper.Win.View
{
    public partial class frmModeloRelatorio : frmBase
    {
        ModeloRelatorioApp _ModeloRelatorioApp;
        int _Id;
        List<ModeloRelatorioViewModel> _listaConsulta = new List<ModeloRelatorioViewModel>();
        GridColunas<ModeloRelatorioViewModel> _grid = new GridColunas<ModeloRelatorioViewModel>();

        public frmModeloRelatorio()
        {
            Iniciar();
            FiltrarDados("ABCDE");
            ModoPesquisa = false;
        }

        public frmModeloRelatorio(string texto)
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

            UsrRevenda.Programa(EnProgramas.Revenda, true);

            cbCampos.DataSource = Grade.ListarCampos(ref dgvDados);
            cbCampos.SelectedIndex = 1;
            cbPesquisa.Enabled = false;
        }

        private void FiltrarDados(string texto)
        {
            string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

            _ModeloRelatorioApp = new ModeloRelatorioApp();
            string ativo = cboAtivo.Text;
            _listaConsulta = _ModeloRelatorioApp.Filtrar(sCampo, texto).ToList();
            dgvDados.DataSource = _listaConsulta;
        }

        public override void Novo()
        {
            txtCodigo.txtValor.ReadOnly = false;
            try
            {
                _ModeloRelatorioApp = new ModeloRelatorioApp();
                var model = _ModeloRelatorioApp.Novo(Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(model.Mensagem);

                base.Novo();

                Tela.LimparTela(tbPrincipal);
                LimparTela();

                txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                txtCodigo.txtValor.ReadOnly = false;
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
                _ModeloRelatorioApp = new ModeloRelatorioApp();
                var model = _ModeloRelatorioApp.Editar(Grade.RetornarId(ref dgvDados, "ModR_Id"), Funcoes.IdUsuario);
                btnSalvar.Enabled = Funcoes.PermitirEditar(model.Mensagem);

                base.Editar();

                Tela.LimparTela(tbPrincipal);
                LimparTela();

                txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                txtNome.Text = model.Descricao;
                txtArquivo.Text = model.Arquivo;
                UsrRevenda.txtId.Text = model.IdRevenda.ToString();
                UsrRevenda.SetCodigoMask(model.CodigoRevenda.ToString());
                UsrRevenda.txtNome.Text = model.NomeRevenda;

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
                    _ModeloRelatorioApp = new ModeloRelatorioApp();
                    int id = Grade.RetornarId(ref dgvDados, "ModR_Id");
                    var model = _ModeloRelatorioApp.Excluir(id, Funcoes.IdUsuario);
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
                _ModeloRelatorioApp = new ModeloRelatorioApp();
                var ModeloRelatorio = new ModeloRelatorioViewModel();
                ModeloRelatorio.Id = _Id;
                ModeloRelatorio.Codigo = Funcoes.StrToInt(txtCodigo.txtValor.Text);
                ModeloRelatorio.Descricao = txtNome.Text;
                ModeloRelatorio.IdRevenda = Convert.ToInt32(UsrRevenda.txtId.Text);

                var model = _ModeloRelatorioApp.Salvar(ModeloRelatorio);
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
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "ModR_Id");
                DialogResult = DialogResult.OK;
                base.Pesquisar();
            }
        }

        private void LimparTela()
        {
            UsrRevenda.LimparTela();
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
    }
}
