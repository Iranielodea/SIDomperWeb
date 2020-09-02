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
    public partial class frmUsuario : frmBase
    {
        UsuarioApp _usuarioApp;
        UsuarioViewModel _usuario;
        List<string> _listaPermissao = new List<string>();
        int _Id;
        List<UsuarioConsultaViewModel> _listaConsulta = new List<UsuarioConsultaViewModel>();
        GridColunas<UsuarioConsultaViewModel> _grid = new GridColunas<UsuarioConsultaViewModel>();

        public frmUsuario()
        {
            Iniciar();
            FiltrarDados("ABCDE");
            ModoPesquisa = false;
        }

        public frmUsuario(string texto)
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

            UsrDepartamento.Programa(EnProgramas.Departamento, true);
            UsrContaEmail.Programa(EnProgramas.ContaEmail);
            UsrRevenda.Programa(EnProgramas.Revenda);
            UsrCliente.Programa(EnProgramas.Cliente);

            int altura = tpFiltroRevenda.Height;
            int largura = tpFiltroRevenda.Width;

            usrClienteFiltro.PosicaoTela(altura, largura);
            usrRevendaFiltro.PosicaoTela(altura, largura);
            usrDepartamentoFiltro.PosicaoTela(altura, largura);

            Grade.Configurar(ref dgvDados);
            Grade.Configurar(ref dgvPermissao, false, false);

            cbCampos.DataSource = Grade.ListarCampos(ref dgvDados);
            cbCampos.SelectedIndex = 1;
            _listaPermissao = new List<string>();
            cbPesquisa.Enabled = false;
        }

        private void FiltrarDados(string texto, int id = 0)
        {
            string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

            var filtro = new UsuarioFiltroViewModel();
            filtro.Ativo = cboAtivo.Text.Substring(0, 1);
            filtro.Campo = sCampo;
            filtro.Texto = texto;
            filtro.IdRevenda = usrRevendaFiltro.RetornarSelecao();
            filtro.IdDepartamento = usrDepartamentoFiltro.RetornarSelecao();
            filtro.IdCliente = usrClienteFiltro.RetornarSelecao();

            if (id > 0)
            {
                filtro.Campo = "Usu_Id";
                filtro.Texto = id.ToString();
                filtro.Ativo = "T";
                filtro.Contem = false;
            }

            _usuarioApp = new UsuarioApp();

            _listaConsulta = _usuarioApp.Filtrar(filtro).ToList();
            dgvDados.DataSource = _listaConsulta;
        }

        public override void Novo()
        {
            txtCodigo.txtValor.ReadOnly = false;
            try
            {
                _usuarioApp = new UsuarioApp();
                _usuario = new UsuarioViewModel();

                var model = _usuarioApp.Novo(Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(model.Mensagem);
                tabControl2.SelectTab(0);
                dgvPermissao.Rows.Clear();
                ListarPermissaoPadrao();

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

        public override void Editar()
        {
            try
            {
                _usuarioApp = new UsuarioApp();
                _usuario = new UsuarioViewModel();

                _usuario = _usuarioApp.Editar(Grade.RetornarId(ref dgvDados, "Usu_Id"), Funcoes.IdUsuario);
                btnSalvar.Enabled = Funcoes.PermitirEditar(_usuario.Mensagem);

                base.Editar();

                LimparTela();
                tabControl2.SelectTab(0);

                txtCodigo.txtValor.Text = _usuario.Codigo.ToString("0000");
                txtNome.Text = _usuario.Nome;
                txtUsuario.Text = _usuario.UserName;
                txtSenha.Text = _usuario.Password;
                txtEmail.Text = _usuario.Email;
                UsrDepartamento.txtCodigo.txtValor.Text = _usuario.Departamento.Codigo.ToString("0000");
                UsrDepartamento.txtNome.Text = _usuario.Departamento.Nome;
                UsrDepartamento.txtId.Text = _usuario.DepartamentoId.ToString();

                if (_usuario.ContaEmail != null)
                {
                    UsrContaEmail.txtCodigo.txtValor.Text = _usuario.ContaEmail.Codigo.ToString("0000");
                    UsrContaEmail.txtNome.Text = _usuario.ContaEmail.Nome;
                    UsrContaEmail.txtId.Text = Funcoes.IntNullToStr(_usuario.ContaEmailId.Value);
                }

                if (_usuario.Revenda != null)
                {
                    UsrRevenda.txtCodigo.txtValor.Text = _usuario.Revenda.Codigo.ToString("0000");
                    UsrRevenda.txtNome.Text = _usuario.Revenda.Nome;
                    UsrRevenda.txtId.Text = Funcoes.IntNullToStr(_usuario.RevendaId);
                }

                if (_usuario.ClienteId != null)
                {
                    UsrCliente.txtId.Text = Funcoes.IntNullToStr(_usuario.ClienteId);
                    UsrCliente.txtCodigo.txtValor.Text = _usuario.ClienteCodigo.ToString("000000");
                    UsrCliente.txtNome.Text = _usuario.NomeCliente;
                }

                chkAdmin.Checked = _usuario.Adm;
                chkAtivo.Checked = _usuario.Ativo;
                txtTelefone.Text = _usuario.Telefone;

                ListarPermissaoPadrao();
                CarregarPermissoesSelecionadas();

                txtNome.Focus();
                _Id = _usuario.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void Excluir()
        {
            base.Excluir();
            if (Funcoes.Confirmar("Confirmar Exclusão?"))
            {
                try
                {
                    _usuarioApp = new UsuarioApp();
                    int id = Grade.RetornarId(ref dgvDados, "Usu_Id");
                    var model = _usuarioApp.Excluir(id, Funcoes.IdUsuario);
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
                if (txtCodigo.txtValor.Text.Trim() == "")
                    throw new Exception("O código é obrigatório!");
                if (txtNome.Text.Trim() == "")
                    throw new Exception("O nome é obrigatório!");
                if (txtUsuario.Text.Trim() == "")
                    throw new Exception("O usuário é obrigatório!");
                if (txtSenha.Text.Trim() == "")
                    throw new Exception("A senha é obrigatório!");
                if (txtEmail.Text.Trim() == "")
                    throw new Exception("O email é obrigatório!");
                if (UsrDepartamento.txtId.Text.Trim() == "")
                    throw new Exception("O departamento é obrigatório!");

                _usuario.Adm = chkAdmin.Checked;
                _usuario.Ativo = chkAtivo.Checked;
                _usuario.ClienteId = Funcoes.StrToIntNull(UsrCliente.txtId.Text);
                _usuario.Codigo = int.Parse(txtCodigo.txtValor.Text);
                _usuario.ContaEmailId = Funcoes.StrToIntNull(UsrContaEmail.txtId.Text);
                _usuario.DepartamentoId = int.Parse(UsrDepartamento.txtId.Text);
                _usuario.Email = txtEmail.Text;
                _usuario.Id = _Id;
                _usuario.Nome = txtNome.Text;
                _usuario.Password = txtSenha.Text;
                _usuario.RevendaId = Funcoes.StrToIntNull(UsrRevenda.txtId.Text);
                _usuario.UserName = txtUsuario.Text;
                _usuario.ClienteId = Funcoes.StrToIntNull(UsrCliente.txtId.Text);
                _usuario.Telefone = txtTelefone.Text;

                SalvarPermissao();
                var model = _usuarioApp.Salvar(_usuario);
                Funcoes.VerificarMensagem(model.Mensagem);


                FiltrarDados(model.Id.ToString(), model.Id);
                base.Salvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SalvarPermissao()
        {
            _usuarioApp = new UsuarioApp();

            _usuario.Id = _Id;
            _usuario.Nome = txtNome.Text;

            if (_usuario.UsuariosPermissao == null)
                _usuario.UsuariosPermissao = new List<UsuarioPermissaoViewModel>();

            _usuario.UsuariosPermissao.Clear();
            foreach (DataGridViewRow item in this.dgvPermissao.Rows)
            {
                if (item.Cells["Sigla"].Value == null)
                    continue;

                var itemUsuario = new UsuarioPermissaoViewModel();

                int id;
                try
                {
                    id = Funcoes.StrToInt(item.Cells["Id"].Value.ToString());
                }
                catch
                {
                    id = 0;
                }

                itemUsuario.Id = id;
                itemUsuario.Sigla = item.Cells["Sigla"].Value.ToString();
                itemUsuario.UsuarioId = _Id;

                _usuario.UsuariosPermissao.Add(itemUsuario);
            }
        }

        public override void Pesquisar()
        {
            if (dgvDados.RowCount > 0 && ModoPesquisa)
            {
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "Usu_Id");
                DialogResult = DialogResult.OK;
                base.Pesquisar();
            }
        }

        private void LimparTela()
        {
            Tela.LimparTela(tbPrincipal);
            dgvPermissao.Rows.Clear();

            UsrDepartamento.txtCodigo.txtValor.Clear();
            UsrDepartamento.txtId.Clear();
            UsrDepartamento.txtNome.Clear();

            UsrContaEmail.txtCodigo.txtValor.Clear();
            UsrContaEmail.txtId.Clear();
            UsrContaEmail.txtNome.Clear();

            UsrRevenda.txtCodigo.txtValor.Clear();
            UsrRevenda.txtId.Clear();
            UsrRevenda.txtNome.Clear();

            UsrCliente.txtCodigo.txtValor.Clear();
            UsrCliente.txtId.Clear();
            UsrCliente.txtNome.Clear();
        }

        public override void Filtrar()
        {
            FiltrarDados(txtTexto.Text);
            base.Filtrar();
        }

        public override void Filtro()
        {
            base.Filtro();
            tabControl3.SelectedIndex = 0;
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

        private void ListarPermissaoPadrao()
        {
            List<string> Lista = new List<string>();
            Lista.Add("Lib_Chamado_Ocorr_Alt_Data_Hora");
            Lista.Add("Lib_Chamado_Ocorr_Alt");
            Lista.Add("Lib_Chamado_Ocorr_Exc");
            Lista.Add("Lib_Solicitacao_Ocorr_Geral_Alt");
            Lista.Add("Lib_Solicitacao_Ocorr_Geral_Exc");
            Lista.Add("Lib_Solicitacao_Ocorr_Tecnica_Alt");
            Lista.Add("Lib_Solicitacao_Ocorr_Tecnica_Exc");
            Lista.Add("Lib_Solicitacao_Ocorr_Regra_Alt");
            Lista.Add("Lib_Solicitacao_Ocorr_Regra_Exc");
            Lista.Add("Lib_Atividade_Ocorr_Alt_Data_Hora");
            Lista.Add("Lib_Atividade_Ocorr_Alt");
            Lista.Add("Lib_Atividade_Ocorr_Exc");
            Lista.Add("Lib_Solicitacao_Tempo");
            Lista.Add("Lib_Conferencia_Tempo_Geral");
            Lista.Add("Lib_Orcamento_Alt_Situacao");
            Lista.Add("Lib_Orcamento_Usuario");

            lstPermissao.DataSource = Lista;
        }

        private void NovaPermissao(string nome)
        {
            bool existe = false;
            foreach (DataGridViewRow row in dgvPermissao.Rows)
            {
                if (row.Cells["Sigla"].Value.ToString() == nome)
                {
                    existe = true;
                    break;
                }
            }

            if (!existe)
            {
                dgvPermissao.Rows.Add(0, nome);
            }
        }

        private void btnPassa1_Click(object sender, EventArgs e)
        {
            NovaPermissao(lstPermissao.SelectedValue.ToString());
        }

        private void CarregarPermissoesSelecionadas()
        {
            dgvPermissao.Rows.Clear();

            foreach (var item in _usuario.UsuariosPermissao)
            {
                dgvPermissao.Rows.Add(item.Id, item.Sigla);
            }
        }

        private void btnPassaTodos_Click(object sender, EventArgs e)
        {
            int count = lstPermissao.Items.Count;
            string nome = "";
            for (int i = 0; i < count; i++)
            {
                nome = lstPermissao.Items[i].ToString();
                NovaPermissao(nome);
            }
        }

        private void ExcluirPermissao()
        {
            int selectedIndex = dgvPermissao.CurrentCell.RowIndex;
            if (selectedIndex > -1)
            {
                dgvPermissao.Rows.RemoveAt(selectedIndex);
                dgvPermissao.Refresh();
            }
        }

        private void btnRetorna1_Click(object sender, EventArgs e)
        {
            ExcluirPermissao();
        }

        private void btnRetornaTodos_Click(object sender, EventArgs e)
        {
            dgvPermissao.Rows.Clear();
        }

        //private void btnRevenda_Click(object sender, EventArgs e)
        //{
        //}

        private void frmUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (UsrDepartamento.txtCodigo.txtValor.Focused)
                    UsrDepartamento.PressionarF9(EnProgramas.Departamento);
                if (UsrContaEmail.txtCodigo.txtValor.Focused)
                    UsrContaEmail.PressionarF9(EnProgramas.ContaEmail);
                if (UsrRevenda.txtCodigo.txtValor.Focused)
                    UsrRevenda.PressionarF9(EnProgramas.Revenda);
                if (UsrCliente.txtCodigo.txtValor.Focused)
                    UsrCliente.PressionarF9(EnProgramas.Cliente);
            }
        }

        private void dgvDados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _grid.OrdenarColunas(ref dgvDados, _listaConsulta, e);
            cbCampos.SelectedIndex = e.ColumnIndex - 1;
        }

        private void usrRevendaFiltro1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                MessageBox.Show("Mostrar");
        }

        private void usrRevendaFiltro1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                MessageBox.Show("Mostrar II");
        }

        private void tabControl3_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedTab == tpFiltroPrincipal)
            {
                cboAtivo.Focus();
            }

            if (tabControl3.SelectedTab == tpFiltroRevenda)
            {
                usrRevendaFiltro.TipoDeCadastro(Filtros.TipoCadastro.Revenda);
                usrRevendaFiltro.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpFiltroDepartamento)
            {
                usrDepartamentoFiltro.TipoDeCadastro(Filtros.TipoCadastro.Departamento);
                usrDepartamentoFiltro.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpFiltroCliente)
            {
                usrClienteFiltro.TipoDeCadastro(Filtros.TipoCadastro.Cliente);
                usrClienteFiltro.txtCodigo.txtValor.Focus();
            }
        }
    }
}

