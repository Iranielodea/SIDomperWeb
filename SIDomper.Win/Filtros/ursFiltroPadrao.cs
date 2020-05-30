using SIDomper.Dominio.Enumeracao;
using SIDomper.Win.Pesquisas;
using SIDomper.Win.Utilitarios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SIDomper.Win.Filtros
{
    public enum TipoCadastro
    {
        Revenda,
        Departamento,
        Usuario,
        Cidade,
        Modulo,
        Produto,
        Cliente,
        Tipo,
        Status,
        Categoria,
        StatusGeral
    }

    public partial class ursFiltroPadrao : UserControl
    {
        private TipoCadastro _tipoCadastro;
        private EnTipos _enTipos;
        private EnStatus _enStatus;

        public void TipoDeCadastro(TipoCadastro tipoCadastro)
        {
            _tipoCadastro = tipoCadastro;
        }

        public void PosicaoTela(int altura, int largura)
        {
            this.Top = 0;
            this.Left = 0;
            this.Height = altura - 60;
            this.Width = largura;
        }

        public void TipoDeCadastro(TipoCadastro tipoCadastro, EnStatus enStatus, EnTipos enTipos)
        {
            _tipoCadastro = tipoCadastro;
            _enStatus = enStatus;
            _enTipos = enTipos;
        }

        public ursFiltroPadrao()
        {
            InitializeComponent();
            Grade.Configurar(ref dgvFiltro);
            dgvFiltro.Columns[2].Width = 550;
            if (_tipoCadastro == TipoCadastro.Cliente)
                dgvFiltro.Columns[1].DefaultCellStyle.Format = "000000";
            else
                dgvFiltro.Columns[1].DefaultCellStyle.Format = "0000";
        }

        public string RetornarSelecao()
        {
            string ret = "";
            string pegar = "";
            var Lista = new List<string>();
            int i = 0;
            foreach (DataGridViewRow item in this.dgvFiltro.Rows)
            {
                if (item.Cells["Id"].Value == null)
                    continue;

                pegar = item.Cells["Id"].Value.ToString();
                if (i == 0)
                    ret += pegar;
                else
                    ret += "," + pegar;
                i++;
            }
            return ret;
        }

        private void ConsultarPadrao(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            try
            {
                if (_tipoCadastro == TipoCadastro.Departamento)
                    ConsultarDepartamento(codigo, nome, tipoPesquisa);
                if (_tipoCadastro == TipoCadastro.Revenda)
                    ConsultarRevenda(codigo, nome, tipoPesquisa);
                if (_tipoCadastro == TipoCadastro.Usuario)
                    ConsultarUsuario(codigo, nome, tipoPesquisa);
                if (_tipoCadastro == TipoCadastro.Cidade)
                    ConsultarCidade(codigo, nome, tipoPesquisa);
                if (_tipoCadastro == TipoCadastro.Modulo)
                    ConsultarModulo(codigo, nome, tipoPesquisa);
                if (_tipoCadastro == TipoCadastro.Produto)
                    ConsultarProduto(codigo, nome, tipoPesquisa);
                if (_tipoCadastro == TipoCadastro.Cliente)
                    ConsultarCliente(codigo, nome, tipoPesquisa);
                if (_tipoCadastro == TipoCadastro.Tipo)
                    ConsultarTipo(codigo, nome, tipoPesquisa, _enTipos);
                if (_tipoCadastro == TipoCadastro.Status)
                    ConsultarStatus(codigo, nome, tipoPesquisa, _enStatus);
                if (_tipoCadastro == TipoCadastro.StatusGeral)
                    ConsultarStatus(codigo, nome, tipoPesquisa, EnStatus.Todos);
                if (_tipoCadastro == TipoCadastro.Categoria)
                    ConsultarCategoria(codigo, nome, tipoPesquisa);

                txtCodigo.txtValor.Modified = false;
                txtNome.Modified = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConsultarDepartamento(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaDepartamento();
            if (tipoPesquisa != TipoPesquisa.Tela)
            {
                txtCodigo.txtValor.Text = "";
                txtNome.Text = "";
            }
            var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
            if (model != null)
            {
                dgvFiltro.Rows.Add(model.Id, model.Codigo, model.Nome);
                txtCodigo.txtValor.Focus();
            }
        }

        private void ConsultarRevenda(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaRevenda();
            if (tipoPesquisa != TipoPesquisa.Tela)
            {
                txtCodigo.txtValor.Text = "";
                txtNome.Text = "";
            }
            var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
            if (model != null)
            {
                dgvFiltro.Rows.Add(model.Id, model.Codigo, model.Nome);
                txtCodigo.txtValor.Focus();
            }
        }

        private void ConsultarUsuario(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaUsuario();
            if (tipoPesquisa != TipoPesquisa.Tela)
            {
                txtCodigo.txtValor.Text = "";
                txtNome.Text = "";
            }
            var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
            if (model != null)
            {
                dgvFiltro.Rows.Add(model.Id, model.Codigo, model.Nome);
                txtCodigo.txtValor.Focus();
            }
        }

        private void ConsultarCidade(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaCidade();
            if (tipoPesquisa != TipoPesquisa.Tela)
            {
                txtCodigo.txtValor.Text = "";
                txtNome.Text = "";
            }
            var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
            if (model != null)
            {
                dgvFiltro.Rows.Add(model.Id, model.Codigo, model.Nome);
                txtCodigo.txtValor.Focus();
            }
        }

        private void ConsultarModulo(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaModulo();
            if (tipoPesquisa != TipoPesquisa.Tela)
            {
                txtCodigo.txtValor.Text = "";
                txtNome.Text = "";
            }
            var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
            if (model != null)
            {
                dgvFiltro.Rows.Add(model.Id, model.Codigo, model.Nome);
                txtCodigo.txtValor.Focus();
            }
        }

        private void ConsultarProduto(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaProduto();
            if (tipoPesquisa != TipoPesquisa.Tela)
            {
                txtCodigo.txtValor.Text = "";
                txtNome.Text = "";
            }
            var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
            if (model != null)
            {
                dgvFiltro.Rows.Add(model.Id, model.Codigo, model.Nome);
                txtCodigo.txtValor.Focus();
            }
        }

        private void ConsultarCliente(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaCliente();
            if (tipoPesquisa != TipoPesquisa.Tela)
            {
                txtCodigo.txtValor.Text = "";
                txtNome.Text = "";
            }
            var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
            if (model != null)
            {
                dgvFiltro.Rows.Add(model.Id, model.Codigo, model.Nome);
                txtCodigo.txtValor.Focus();
            }
        }

        private void ConsultarTipo(int codigo, string nome, TipoPesquisa tipoPesquisa, EnTipos enTipos)
        {
            var consulta = new ConsultaTipo();
            if (tipoPesquisa != TipoPesquisa.Tela)
            {
                txtCodigo.txtValor.Text = "";
                txtNome.Text = "";
            }
            var model = consulta.Pesquisar(codigo, nome, tipoPesquisa, enTipos);
            if (model != null)
            {
                dgvFiltro.Rows.Add(model.Id, model.Codigo, model.Nome);
                txtCodigo.txtValor.Focus();
            }
        }

        private void ConsultarStatus(int codigo, string nome, TipoPesquisa tipoPesquisa, EnStatus enStatus)
        {
            var consulta = new ConsultaStatus();
            if (tipoPesquisa != TipoPesquisa.Tela)
            {
                txtCodigo.txtValor.Text = "";
                txtNome.Text = "";
            }
            var model = consulta.Pesquisar(codigo, nome, tipoPesquisa, enStatus);
            if (model != null)
            {
                dgvFiltro.Rows.Add(model.Id, model.Codigo, model.Nome);
                txtCodigo.txtValor.Focus();
            }
        }

        private void ConsultarCategoria(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaCategoria();
            if (tipoPesquisa != TipoPesquisa.Tela)
            {
                txtCodigo.txtValor.Text = "";
                txtNome.Text = "";
            }
            var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
            if (model != null)
            {
                dgvFiltro.Rows.Add(model.Id, model.Codigo, model.Nome);
                txtCodigo.txtValor.Focus();
            }
        }

        public void Adicionar(TipoCadastro tipoCadastro)
        {
            _tipoCadastro = tipoCadastro;
            ConsultarPadrao(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, TipoPesquisa.Id);
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (txtCodigo.txtValor.Modified)
                ConsultarPadrao(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, TipoPesquisa.Id);
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            ConsultarPadrao(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, TipoPesquisa.Tela);
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            if (txtNome.Modified)
                ConsultarPadrao(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, TipoPesquisa.Descricao);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                btnPesquisa_Click(sender, e);
        }

        private void btnPesquisa_Click_1(object sender, EventArgs e)
        {
            ConsultarPadrao(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, TipoPesquisa.Tela);
            txtNome.Focus();
        }

        public void AbrirTela()
        {
            ConsultarPadrao(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, TipoPesquisa.Tela);
            txtNome.Focus();
        }
    }
}
