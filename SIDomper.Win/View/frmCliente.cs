using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Funcoes;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Base;
using SIDomper.Win.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SIDomper.Win.View
{
    public partial class frmCliente : frmBase
    {
        private DataGridViewCell _celWasEndEdit;
        private DataGridViewCell _celWasEndEditEmail;

        ClienteApp _clienteApp;
        ClienteViewModelApi _cliente;
        List<string> _listaPermissao = new List<string>();
        int _Id;
        List<ClienteConsultaViewModelApi> _listaConsulta = new List<ClienteConsultaViewModelApi>();
        GridColunas<ClienteConsultaViewModelApi> _grid = new GridColunas<ClienteConsultaViewModelApi>();

        public frmCliente()
        {
            Iniciar();
            FiltrarDados("ABCDE");
            ModoPesquisa = false;
        }

        public frmCliente(string texto)
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

            UsrUsuario.Programa(EnProgramas.Usuario);
            UsrRevenda.Programa(EnProgramas.Revenda, true);
            UsrCidade.Programa(EnProgramas.Cidade);
            UsrModulo.Programa(EnProgramas.Modulo, true);
            UsrProduto.Programa(EnProgramas.Produto);

            int altura = tpUsuario.Height;
            int largura = tpUsuario.Width;

            usrCidadeFiltro.PosicaoTela(altura, largura);
            usrModuloFiltro.PosicaoTela(altura, largura);
            usrProdutoFiltro.PosicaoTela(altura, largura);
            usrRevendaFiltro.PosicaoTela(altura, largura);
            usrUsuarioFiltro.PosicaoTela(altura, largura);

            Grade.Configurar(ref dgvDados);
            Grade.Configurar(ref dgvContato, true, true);
            Grade.Configurar(ref dgvEmail, true, true);
            Grade.Configurar(ref dgvModulo, false, false);

            cbCampos.DataSource = Grade.ListarCampos(ref dgvDados);
            cbCampos.SelectedIndex = 1;
            _listaPermissao = new List<string>();

            ControleTelaModulos("C");
            cbRestricao.SelectedIndex = 2;

            //txtIdRevenda.Left = txtNome.Left;
            //txtIdRevenda.Top = txtNome.Top;
            //txtIdRevenda.SendToBack();
        }

        private void FiltrarDados(string texto, int id = 0)
        {
            string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

            var filtro = new ClienteFiltroViewModelApi();
            filtro.Campo = sCampo;
            filtro.Valor = texto;
            filtro.Ativo = cboAtivo.Text.Substring(0, 1);
            filtro.FiltroIdUsuario = usrUsuarioFiltro.RetornarSelecao();
            filtro.FiltroIdRevenda = usrRevendaFiltro.RetornarSelecao();
            filtro.FiltroIdCidade = usrCidadeFiltro.RetornarSelecao();
            filtro.filtroIdModulo = usrModuloFiltro.RetornarSelecao();
            filtro.FiltroIdProduto = usrProdutoFiltro.RetornarSelecao();
            filtro.Restricao = 3;
            filtro.Modelo = 0;

            if (id > 0)
            {
                filtro.Campo = "Cli_Id";
                filtro.Valor = id.ToString();
                filtro.Ativo = "T";
                filtro.Id = id;
            }

            _clienteApp = new ClienteApp();

            try
            {
                _listaConsulta = _clienteApp.Filtrar(filtro, Funcoes.IdUsuario, cbPesquisa.SelectedIndex == 0).ToList();
                dgvDados.DataSource = _listaConsulta;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void Novo()
        {
            txtCodigo.txtValor.ReadOnly = false;
            try
            {
                _clienteApp = new ClienteApp();
                _cliente = new ClienteViewModelApi();

                var model = _clienteApp.Novo(Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(model.Mensagem);
                tabControl2.SelectTab(0);                

                base.Novo();

                LimparTela();
                CancelarModulo();
                btnEspecificacoes2.Enabled = false;
                txtCodigo.txtValor.Text = model.Codigo.ToString("000000");
                VincularDados();
                txtCodigo.txtValor.ReadOnly = false;
                txtCodigo.txtValor.Focus();
                _Id = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarEmails()
        {
            dgvEmail.Rows.Clear();

            if (_cliente.Emails != null)
            {
                foreach (var item in _cliente.Emails)
                {
                    dgvEmail.Rows.Add(item.Id, item.Email, item.Notificar);
                }
            }
        }

        private void CarregarModulos()
        {
            //dgvModulo.DataSource = _cliente.ClienteModulos;
            dgvModulo.Rows.Clear();

            if (_cliente.ClienteModulos != null)
            {
                foreach (var item in _cliente.ClienteModulos)
                {
                    dgvModulo.Rows.Add(item.Id, item.NomeModulo, item.NomeProduto, item.ModuloId, item.ProdutoId, item.CodModulo, item.CodProduto);
                }
            }
        }

        private void CarregarContatos()
        {
            dgvContato.Rows.Clear();

            if (_cliente.Contatos != null)
            {
                foreach (var item in _cliente.Contatos)
                {
                    dgvContato.Rows.Add(item.Id, item.Nome, item.Fone1, item.Fone2, item.Departamento, item.Email);
                }
            }
        }

        private void VincularDados()
        {
            Tela.Binding(ref txtNome, _cliente, "Nome");
            Tela.Binding(ref txtFantasia, _cliente, "Fantasia");
            Tela.Binding(ref txtPerfil, _cliente, "Perfil");
            Tela.BindingMask(ref txtDocumento, _cliente, "Dcto");

            Tela.Binding(ref txtInscEstadual, _cliente, "IE");
            Tela.Binding(ref txtVersao, _cliente, "Versao");
            Tela.Binding(ref txtEndereco, _cliente, "Endereco");
            Tela.Binding(ref txtBairro, _cliente, "Bairro");

            Tela.Binding(ref txtFone1, _cliente, "Fone1");
            Tela.Binding(ref txtFone2, _cliente, "Fone2");
            Tela.Binding(ref txtCelular, _cliente, "Celular");
            Tela.Binding(ref txtOutroFone, _cliente, "OutroFone");

            Tela.Binding(ref txtNomeFinanceiro, _cliente, "ContatoFinanceiro");
            Tela.Binding(ref txtFoneFinanceiro, _cliente, "FoneContatoFinanceiro");

            Tela.Binding(ref txtNomeContato, _cliente, "ContatoCompraVenda");
            Tela.Binding(ref txtFoneContato, _cliente, "FoneContatoCompraVenda");

            Tela.Binding(ref txtNomeRepr, _cliente, "RepresentanteLegal");
            Tela.BindingMask(ref txtCPFRepr, _cliente, "CPFRepresentanteLegal");
            Tela.BindingMask(ref txtCEP, _cliente, "CEP");

            Tela.BindingCheckBox(ref chkAtivo, _cliente, "Ativo");

            rbSimples.Checked = ((ClienteViewModelApi)_cliente).Enquadramento == "01";
            rbPresumido.Checked = ((ClienteViewModelApi)_cliente).Enquadramento == "02";
            rbReal.Checked = ((ClienteViewModelApi)_cliente).Enquadramento == "03";
            rbNaoDefinido.Checked = ((ClienteViewModelApi)_cliente).Enquadramento == "00";
        }

        private void MascaraDocumento(string documento)
        {
            txtDocumento.Mask = (Utils.SomenteNumero(documento).Length == 11) ? "000,000,000-00" : "00,000,000/0000-00";
        }

        public override void Editar()
        {
            try
            {
                _clienteApp = new ClienteApp();
                _cliente = new ClienteViewModelApi();

                _cliente = _clienteApp.Editar(Funcoes.IdUsuario, Grade.RetornarId(ref dgvDados, "Cli_Id"));
                btnSalvar.Enabled = Funcoes.PermitirEditar(_cliente.Mensagem);

                base.Editar();

                LimparTela();
                tabControl2.SelectTab(0);                

                txtCodigo.txtValor.Text = _cliente.Codigo.ToString("000000");
                txtEmpresaVinc.txtValor.Text = _cliente.EmpresaVinculada.ToString();
                MascaraDocumento(_cliente.Dcto);

                VincularDados();
                CarregarContatos();
                CarregarEmails();
                CarregarModulos();

                btnEspecificacoes2.Enabled = true;

                if (_cliente.Cidade != null)
                {
                    UsrCidade.txtId.Text = _cliente.CidadeId.ToString();
                    UsrCidade.txtCodigo.txtValor.Text = _cliente.Cidade.Codigo.ToString("0000");
                    UsrCidade.txtNome.Text = _cliente.Cidade.Nome;
                    txtCEP.Text = _cliente.CEP;
                    txtUF.Text = _cliente.Cidade.UF;
                }

                if (_cliente.Revenda != null)
                {
                    UsrRevenda.txtId.Text = _cliente.RevendaId.ToString();
                    UsrRevenda.txtCodigo.txtValor.Text = _cliente.Revenda.Codigo.ToString("0000");
                    UsrRevenda.txtNome.Text = _cliente.Revenda.Nome;
                }

                if (_cliente.CodigoUsuario != null)
                {
                    UsrUsuario.txtId.Text = _cliente.UsuarioId.ToString();
                    UsrUsuario.txtCodigo.txtValor.Text = _cliente.CodigoUsuario.Value.ToString("0000");
                    UsrUsuario.txtNome.Text = _cliente.NomeUsuario;
                }
                txtNome.Focus();
                _Id = _cliente.Id;
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
                    _clienteApp = new ClienteApp();
                    int id = Grade.RetornarId(ref dgvDados, "Cli_Id");
                    var model = _clienteApp.Excluir(id, Funcoes.IdUsuario);
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
                if (Utils.SomenteNumero(txtDocumento.Text).Length == 0)
                    throw new Exception("CNPJ/CPF obrigatório!");
                if (string.IsNullOrWhiteSpace(UsrRevenda.txtId.Text))
                    throw new Exception("Revenda é obrigatório!");

                if (Utils.SomenteNumero(txtDocumento.Text).Length == 11)
                {
                    if (!Validacoes.IsCpf(txtDocumento.Text))
                        throw new Exception("CPF inválido!");
                }
                else
                {
                    if (!Validacoes.IsCnpj(txtDocumento.Text))
                        throw new Exception("CNPJ inválido!");
                }

                if (Utils.SomenteNumero(txtCPFRepr.Text).Length == 11)
                {
                    if (!Validacoes.IsCpf(txtCPFRepr.Text))
                        throw new Exception("CPF inválido!");
                }

                if (rbSimples.Checked)
                    ((ClienteViewModelApi)_cliente).Enquadramento = "01";
                if (rbPresumido.Checked)
                    ((ClienteViewModelApi)_cliente).Enquadramento = "02";
                if (rbReal.Checked)
                    ((ClienteViewModelApi)_cliente).Enquadramento = "03";
                if (rbNaoDefinido.Checked)
                    ((ClienteViewModelApi)_cliente).Enquadramento = "00";

                _cliente.Codigo = int.Parse(txtCodigo.txtValor.Text);
                _cliente.CidadeId = Funcoes.StrToIntNull(UsrCidade.txtId.Text);
                _cliente.RevendaId = int.Parse(UsrRevenda.txtId.Text);
                _cliente.UsuarioId = Funcoes.StrToIntNull(UsrUsuario.txtId.Text);
                _cliente.EmpresaVinculada = Funcoes.StrToIntNull(txtEmpresaVinc.txtValor.Text);

                SalvarContato();
                SalvarEmail();
                SalvarModulos();

                var model = _clienteApp.Salvar(_cliente);
                Funcoes.VerificarMensagem(model.Mensagem);

                FiltrarDados(model.Id.ToString(), model.Id);
                base.Salvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SalvarEmail()
        {
            _clienteApp = new ClienteApp();

            _cliente.Id = _Id;

            if (_cliente.Emails == null)
                _cliente.Emails = new List<ClienteEmailViewModelApi>();

            _cliente.Emails.Clear();
            foreach (DataGridViewRow item in this.dgvEmail.Rows)
            {
                if (item.Cells["CliEm_Email"].Value == null)
                    continue;

                var itemEmail = new ClienteEmailViewModelApi();

                int id;
                try
                {
                    id = Funcoes.StrToInt(item.Cells["CliEm_Id"].Value.ToString());
                }
                catch
                {
                    id = 0;
                }

                itemEmail.Id = id;
                itemEmail.Email = item.Cells["CliEm_Email"].Value.ToString();

                if (item.Cells["CliEm_Notificar"].Value == null)
                    itemEmail.Notificar = false;
                else
                    itemEmail.Notificar = bool.Parse(item.Cells["CliEm_Notificar"].Value.ToString());
                _cliente.Emails.Add(itemEmail);
            }
        }

        private void SalvarModulos()
        {
            _clienteApp = new ClienteApp();

            if (_cliente.ClienteModulos == null)
                _cliente.ClienteModulos = new List<ClienteModuloViewModelApi>();

            _cliente.ClienteModulos.Clear();
            foreach (DataGridViewRow item in this.dgvModulo.Rows)
            {

                var model = new ClienteModuloViewModelApi();

                int id;
                int? idProduto;
                try
                {
                    id = Funcoes.StrToInt(item.Cells["ClienteModuloId"].Value.ToString());
                }
                catch
                {
                    id = 0;
                }

                model.Id = id;
                model.ModuloId = int.Parse(item.Cells["ModuloId"].Value.ToString());

                try
                {
                    idProduto = Funcoes.StrToIntNull(item.Cells["ProdutoId"].Value.ToString());
                }
                catch
                {
                    idProduto = null;
                }

                model.ProdutoId = idProduto;

                _cliente.ClienteModulos.Add(model);
            }
        }

        private void SalvarContato()
        {
            _clienteApp = new ClienteApp();

            _cliente.Id = _Id;
            _cliente.Nome = txtNome.Text;

            if (_cliente.Contatos == null)
                _cliente.Contatos = new List<ContatoViewModelApi>();

            _cliente.Contatos.Clear();
            foreach (DataGridViewRow item in this.dgvContato.Rows)
            {
                if (item.Cells["Nome"].Value == null)
                    continue;

                var itemContato = new ContatoViewModelApi();

                int id;
                try
                {
                    id = Funcoes.StrToInt(item.Cells["Id"].Value.ToString());
                }
                catch
                {
                    id = 0;
                }

                itemContato.Id = id;
                itemContato.ClienteId = _Id;
                itemContato.Departamento = item.Cells["Departamento"].Value.ToString();
                itemContato.Email = item.Cells["Email"].Value.ToString();
                itemContato.Fone1 = item.Cells["Fone1"].Value.ToString();
                itemContato.Fone2 = item.Cells["Fone2"].Value.ToString();
                itemContato.Nome = item.Cells["Nome"].Value.ToString();

                _cliente.Contatos.Add(itemContato);
            }
        }

        public override void Pesquisar()
        {
            if (dgvDados.RowCount > 0 && ModoPesquisa)
            {
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "Cli_Id");
                DialogResult = DialogResult.OK;
                base.Pesquisar();
            }
        }

        private void LimparTela()
        {
            Tela.LimparTela(tbPrincipal);
            Tela.LimparTela(grpContato);
            Tela.LimparTela(grpFinanceiro);
            Tela.LimparTela(grpRepresentante);
            Tela.LimparTela(tpModulo);

            dgvContato.Rows.Clear();
            dgvEmail.Rows.Clear();
            dgvModulo.Rows.Clear();

            UsrCidade.txtId.Clear();
            UsrCidade.txtCodigo.txtValor.Clear();
            UsrCidade.txtNome.Clear();

            UsrRevenda.txtId.Clear();
            UsrRevenda.txtCodigo.txtValor.Clear();
            UsrRevenda.txtNome.Clear();

            UsrUsuario.txtCodigo.txtValor.Clear();
            UsrUsuario.txtId.Clear();
            UsrUsuario.txtNome.Clear();
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

        private void ExcluirContato()
        {
            int selectedIndex = dgvContato.CurrentCell.RowIndex;
            if (selectedIndex > -1)
            {
                dgvContato.Rows.RemoveAt(selectedIndex);
                dgvContato.Refresh();
            }
        }

        private void ExcluirEmail()
        {
            int selectedIndex = dgvEmail.CurrentCell.RowIndex;
            if (selectedIndex > -1)
            {
                dgvEmail.Rows.RemoveAt(selectedIndex);
                dgvEmail.Refresh();
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

        private void dgvContato_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _celWasEndEdit = dgvContato[e.ColumnIndex, e.RowIndex];
        }

        private void dgvContato_SelectionChanged(object sender, EventArgs e)
        {
            Grade.TelcaEnterSelectionChanged(ref dgvContato, 1, _celWasEndEdit);
        }

        private void dgvContato_Enter(object sender, EventArgs e)
        {
            this.KeyPreview = false;
        }

        private void dgvContato_Leave(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void dgvContato_KeyDown(object sender, KeyEventArgs e)
        {
            Grade.TeclaEnterKeyDown(ref dgvContato, e, 1);
            ExcluirGrids(sender, e);

            //switch (e.KeyCode)
            //{
            //    case Keys.F8:
            //        Salvar();
            //        break;
            //    case Keys.Escape:
            //        Voltar();
            //        break;
            //}
            //if (e.Control)
            //{
            //    if (e.KeyCode == Keys.Delete)
            //    {
            //        if (tabControl2.SelectedTab == tbPrincipal)
            //        {
            //            ExcluirContato();
            //        }
            //        else if (tabControl2.SelectedTab == tpEmail)
            //        {
            //            ExcluirEmail();
            //        }
            //    }
            //}
        }

        private void txtCodRevenda_Leave(object sender, EventArgs e)
        {
        }

        private void txtNomeRevenda_Leave(object sender, EventArgs e)
        {
        }

        private void btnRevenda_Click(object sender, EventArgs e)
        {
            
        }

        private void frmCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (UsrUsuario.txtCodigo.txtValor.Focused)
                    UsrUsuario.PressionarF9(EnProgramas.Usuario);
                if (UsrRevenda.txtCodigo.txtValor.Focused)
                    UsrRevenda.PressionarF9(EnProgramas.Revenda);
                if (UsrCidade.txtCodigo.txtValor.Focused)
                    UsrCidade.PressionarF9(EnProgramas.Cidade);
                if (UsrModulo.txtCodigo.txtValor.Focused)
                    UsrModulo.PressionarF9(EnProgramas.Modulo);
                if (UsrProduto.txtCodigo.txtValor.Focused)
                    UsrProduto.PressionarF9(EnProgramas.Produto);

                //if (txtCodModulo.txtValor.Focused)
                //    btnModulo_Click(sender, e);
                //if (txtCodProduto.txtValor.Focused)
                //    btnProduto_Click(sender, e);

                //else if (tabControl3.SelectedTab == tpUsuario)
                //    usrUsuarioFiltro.AbrirTela();
                //else if (tabControl3.SelectedTab == tpRevenda)
                //    usrRevendaFiltro.AbrirTela();
                //else if (tabControl3.SelectedTab == tpCidade)
                //    usrCidadeFiltro.AbrirTela();
                //else if (tabControl3.SelectedTab == tpModuloF)
                //    usrModuloFiltro.AbrirTela();
                //else if (tabControl3.SelectedTab == tpProduto)
                //    usrProdutoFiltro.AbrirTela();
            }
        }

        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            MascaraDocumento(txtDocumento.Text);
        }

        private void txtDocumento_Enter(object sender, EventArgs e)
        {
            txtDocumento.Mask = "";
        }

        private void dgvEmail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _celWasEndEditEmail = dgvEmail[e.ColumnIndex, e.RowIndex];
        }

        private void ExcluirGrids(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
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
                        ExcluirContato();
                    }
                    else if (tabControl2.SelectedTab == tpEmail)
                    {
                        ExcluirEmail();
                    }
                }
            }
        }

        private void dgvEmail_KeyDown(object sender, KeyEventArgs e)
        {
            Grade.TeclaEnterKeyDown(ref dgvEmail, e, 1);
            ExcluirGrids(sender, e);
        }

        private void dgvEmail_SelectionChanged(object sender, EventArgs e)
        {
            Grade.TelcaEnterSelectionChanged(ref dgvEmail, 1, _celWasEndEditEmail);
        }

        private void dgvEmail_Enter(object sender, EventArgs e)
        {
            this.KeyPreview = false;
        }

        private void dgvEmail_Leave(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void NovoModulo()
        {
            ControleTelaModulos("N");
            LimparModulo();

            UsrModulo.txtCodigo.txtValor.Focus();
        }

        private void LimparModulo()
        {
            UsrModulo.txtId.Text = "0";
            UsrModulo.txtCodigo.txtValor.Clear();
            UsrModulo.txtNome.Clear();

            UsrProduto.txtId.Text = "0";
            UsrProduto.txtCodigo.txtValor.Clear();
            UsrProduto.txtNome.Clear();
        }

        private void EditarModulo()
        {
            NavegarModulo();
            if (dgvModulo.RowCount > 0)
            {
                ControleTelaModulos("E");
                UsrModulo.txtCodigo.txtValor.Focus();
            }
        }

        private void NavegarModulo()
        {
            LimparModulo();
            if (dgvModulo.RowCount > 0)
            {
                int codModulo = int.Parse(dgvModulo.CurrentRow.Cells["CodModulo"].Value.ToString());

                UsrModulo.txtId.Text = dgvModulo.CurrentRow.Cells["ModuloId"].Value.ToString();
                txtClienteModuloId.Text = dgvModulo.CurrentRow.Cells["ClienteModuloId"].Value.ToString();
                UsrModulo.txtCodigo.txtValor.Text = codModulo.ToString("0000");
                UsrModulo.txtNome.Text = dgvModulo.CurrentRow.Cells["NomeModulo"].Value.ToString();

                if (dgvModulo.CurrentRow.Cells["CodProduto"].Value != null)
                {
                    int codProduto = int.Parse(dgvModulo.CurrentRow.Cells["CodProduto"].Value.ToString());
                    UsrProduto.txtCodigo.txtValor.Text = codProduto.ToString("0000");
                    UsrProduto.txtNome.Text = dgvModulo.CurrentRow.Cells["NomeProduto"].Value.ToString();
                    UsrProduto.txtId.Text = dgvModulo.CurrentRow.Cells["ProdutoId"].Value.ToString();
                }
            }
        }

        private void SalvarModulo()
        {
            if (txtClienteModuloId.Text == "0")
                dgvModulo.Rows.Add(0, UsrModulo.txtNome.Text, UsrProduto.txtNome.Text, UsrModulo.txtId.Text, UsrProduto.txtId.Text, UsrModulo.txtCodigo.txtValor.Text, UsrProduto.txtCodigo.txtValor.Text);
            else
            {
                dgvModulo.CurrentRow.Cells["ClienteModuloId"].Value = txtClienteModuloId.Text;
                dgvModulo.CurrentRow.Cells["ModuloId"].Value = UsrModulo.txtId.Text;
                dgvModulo.CurrentRow.Cells["NomeModulo"].Value = UsrModulo.txtNome.Text;

                dgvModulo.CurrentRow.Cells["ProdutoId"].Value = UsrProduto.txtId.Text;
                dgvModulo.CurrentRow.Cells["NomeProduto"].Value = UsrProduto.txtNome.Text;
            }

            ControleTelaModulos("S");
        }

        private void ExcluirModulo()
        {
            if (dgvModulo.RowCount > 0)
            {
                if (Funcoes.Confirmar("Confirmar Exclusão?"))
                {
                    int selectedIndex = dgvModulo.CurrentCell.RowIndex;
                    if (selectedIndex > -1)
                    {
                        dgvModulo.Rows.RemoveAt(selectedIndex);
                        dgvModulo.Refresh();
                    }
                }
            }
        }

        private void CancelarModulo()
        {
            ControleTelaModulos("C");
            NavegarModulo();
        }

        private void ControleTelaModulos(string botao)
        {
            if (botao == "N")
            {
                btnNovoModulo.Enabled = false;
                btnEditarModulo.Enabled = false;
                btnSalvarModulo.Enabled = true;
                btnExcluirModulo.Enabled = false;
                btnCancelarModulo.Enabled = true;
                UsrModulo.Enabled = true;

                UsrProduto.Enabled = true;
                UsrModulo.Enabled = true;
            }

            if (botao == "E")
            {
                btnNovoModulo.Enabled = false;
                btnEditarModulo.Enabled = false;
                btnSalvarModulo.Enabled = true;
                btnExcluirModulo.Enabled = true;
                btnCancelarModulo.Enabled = true;
                UsrModulo.Enabled = true;

                UsrModulo.Enabled = true;
                UsrProduto.Enabled = true;
            }

            if (botao == "S" || botao == "C")
            {
                btnNovoModulo.Enabled = true;
                btnEditarModulo.Enabled = true;
                btnSalvarModulo.Enabled = false;
                btnExcluirModulo.Enabled = true;
                btnCancelarModulo.Enabled = false;

                UsrModulo.Enabled = false;
                UsrProduto.Enabled = false;
            }
        }

        private void btnNovoModulo_Click(object sender, EventArgs e)
        {
            NovoModulo();
        }

        private void btnEditarModulo_Click(object sender, EventArgs e)
        {
            EditarModulo();
        }

        private void btnSalvarModulo_Click(object sender, EventArgs e)
        {
            SalvarModulo();
        }

        private void btnExcluirModulo_Click(object sender, EventArgs e)
        {
            ExcluirModulo();
        }

        private void btnCancelarModulo_Click(object sender, EventArgs e)
        {
            CancelarModulo();
        }

        private void dgvModulo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CancelarModulo();
        }

        private void dgvModulo_KeyUp(object sender, KeyEventArgs e)
        {
            CancelarModulo();
        }
        
        private void TelaEspecifiacoes()
        {
            if (dgvDados.RowCount > 0)
            {
                frmClienteEspecificacao formulario = new frmClienteEspecificacao((int)dgvDados.CurrentRow.Cells["Cli_Id"].Value);
                formulario.ShowDialog();
            }
        }

        private void btnEspecificacao_Click(object sender, EventArgs e)
        {
            TelaEspecifiacoes();
        }

        private void btnEspecificacoes2_Click(object sender, EventArgs e)
        {
            TelaEspecifiacoes();
        }

        private void tabControl3_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedTab == tpFiltroPrincipal)
            {
                cboAtivo.Focus();
            }

            if (tabControl3.SelectedTab == tpUsuario)
            {
                usrUsuarioFiltro.TipoDeCadastro(Filtros.TipoCadastro.Usuario);
                usrUsuarioFiltro.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpRevenda)
            {
                usrRevendaFiltro.TipoDeCadastro(Filtros.TipoCadastro.Revenda);
                usrRevendaFiltro.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpCidade)
            {
                usrCidadeFiltro.TipoDeCadastro(Filtros.TipoCadastro.Cidade);
                usrCidadeFiltro.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpModuloF)
            {
                usrModuloFiltro.TipoDeCadastro(Filtros.TipoCadastro.Modulo);
                usrModuloFiltro.txtCodigo.txtValor.Focus();
            }

            if (tabControl3.SelectedTab == tpProduto)
            {
                usrProdutoFiltro.TipoDeCadastro(Filtros.TipoCadastro.Produto);
                usrProdutoFiltro.txtCodigo.txtValor.Focus();
            }
        }

        private void UsrCidade_Leave(object sender, EventArgs e)
        {
            if (UsrCidade.Modificou)
            {
                var cidade = (CidadeViewModel)UsrCidade.RetornarObjeto();
                if (cidade != null)
                    txtUF.Text = cidade.UF;
            }
        }
    }
}
