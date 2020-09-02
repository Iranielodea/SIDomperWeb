using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Funcoes;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Utilitarios;
using SIDomper.Win.View;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SIDomper.Win
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal(string userName, string password)
        {
            InitializeComponent();

            PermissaoDepartamento.Listar = PermissaoDepartamento.ListaPermissaoDepartamentos(userName, password);
            //PermissaoDepartamento.Listar = PermissaoDepartamento.ListaPermissaoDepartamentos("ielodea", "12");
            //PermissaoDepartamento.Listar = PermissaoDepartamento.ListaPermissaoDepartamentos("jrsilva", "jr231123");

            Funcoes.IdUsuario = PermissaoDepartamento.Listar.FirstOrDefault(x => x.IdPrograma == 1).IdUsuario;
            Funcoes.UsuarioADM = PermissaoDepartamento.Listar.FirstOrDefault(x => x.IdPrograma == 1).UsuarioADM;

            var usuarioApp = new UsuarioApp();
            var usuario = usuarioApp.ObterPorId(Funcoes.IdUsuario);

            PermissaoDepartamento.DadosUsuario = usuario;

            Funcoes.CodigoUsuarioLogado = usuario.Codigo;
            Funcoes.NomeUsuarioLogado = usuario.Nome;
            BuscarUsuarioPermissao(usuario);

            //LerMenus();
        }

        public frmMenuPrincipal()
        {
            InitializeComponent();

            //PermissaoDepartamento.Listar = PermissaoDepartamento.ListaPermissaoDepartamentos("esilva", "esil@2006");
            ////PermissaoDepartamento.Listar = PermissaoDepartamento.ListaPermissaoDepartamentos("ielodea", "12");
            ////PermissaoDepartamento.Listar = PermissaoDepartamento.ListaPermissaoDepartamentos("jrsilva", "jr231123");

            //Funcoes.IdUsuario = PermissaoDepartamento.Listar.FirstOrDefault(x => x.IdPrograma == 1).IdUsuario;
            //Funcoes.UsuarioADM = PermissaoDepartamento.Listar.FirstOrDefault(x => x.IdPrograma == 1).UsuarioADM;

            //var usuarioApp = new UsuarioApp();
            //var usuario = usuarioApp.ObterPorId(Funcoes.IdUsuario);

            //Funcoes.CodigoUsuarioLogado = usuario.Codigo;
            //Funcoes.NomeUsuarioLogado = usuario.Nome;
            //BuscarUsuarioPermissao(usuario);

            //LerMenus();
        }

        private void BuscarUsuarioPermissao(UsuarioViewModel usuario)
        {
            UsuarioPermissaoMenu.Lib_Solicitacao_Ocorr_Geral_Alt = usuario.UsuariosPermissao.Any(x => x.Sigla == "Lib_Solicitacao_Ocorr_Geral_Alt");
            UsuarioPermissaoMenu.Lib_Solicitacao_Ocorr_Geral_Exc = usuario.UsuariosPermissao.Any(x => x.Sigla == "Lib_Solicitacao_Ocorr_Geral_Exc");
            UsuarioPermissaoMenu.Lib_Solicitacao_Ocorr_Tecnica_Alt = usuario.UsuariosPermissao.Any(x => x.Sigla == "Lib_Solicitacao_Ocorr_Tecnica_Alt");
            UsuarioPermissaoMenu.Lib_Solicitacao_Ocorr_Tecnica_Exc = usuario.UsuariosPermissao.Any(x => x.Sigla == "Lib_Solicitacao_Ocorr_Tecnica_Exc");
            UsuarioPermissaoMenu.Lib_Solicitacao_Ocorr_Regra_Alt = usuario.UsuariosPermissao.Any(x => x.Sigla == "Lib_Solicitacao_Ocorr_Regra_Alt");
            UsuarioPermissaoMenu.Lib_Solicitacao_Ocorr_Regra_Exc = usuario.UsuariosPermissao.Any(x => x.Sigla == "Lib_Solicitacao_Ocorr_Regra_Exc");
            UsuarioPermissaoMenu.Lib_Solicitacao_Tempo = usuario.UsuariosPermissao.Any(x => x.Sigla == "Lib_Solicitacao_Tempo");

            UsuarioPermissaoMenu.Lib_Chamado_Ocorr_Alt_Data_Hora = usuario.UsuariosPermissao.Any(x => x.Sigla == "Lib_Chamado_Ocorr_Alt_Data_Hora");
            UsuarioPermissaoMenu.Lib_Chamado_Ocorr_Alt = usuario.UsuariosPermissao.Any(x => x.Sigla == "Lib_Chamado_Ocorr_Alt");
            UsuarioPermissaoMenu.Lib_Chamado_Ocorr_Exc = usuario.UsuariosPermissao.Any(x => x.Sigla == "Lib_Chamado_Ocorr_Exc");

            UsuarioPermissaoMenu.Lib_Atividade_Ocorr_Alt_Data_Hora = usuario.UsuariosPermissao.Any(x => x.Sigla == "Lib_Atividade_Ocorr_Alt_Data_Hora");
            UsuarioPermissaoMenu.Lib_Atividade_Ocorr_Alt = usuario.UsuariosPermissao.Any(x => x.Sigla == "Lib_Atividade_Ocorr_Alt");
            UsuarioPermissaoMenu.Lib_Atividade_Ocorr_Exc = usuario.UsuariosPermissao.Any(x => x.Sigla == "Lib_Atividade_Ocorr_Exc");

            UsuarioPermissaoMenu.Lib_Conferencia_Tempo_Geral = usuario.UsuariosPermissao.Any(x => x.Sigla == "Lib_Conferencia_Tempo_Geral");

            UsuarioPermissaoMenu.Lib_Orcamento_Alt_Situacao = usuario.UsuariosPermissao.Any(x => x.Sigla == "Lib_Orcamento_Alt_Situacao");
            UsuarioPermissaoMenu.Lib_Orcamento_Usuario = usuario.UsuariosPermissao.Any(x => x.Sigla == "Lib_Orcamento_Usuario");
        }

        private bool FormularioExiste(string nomeFormulario)
        {
            var form = Application.OpenForms[nomeFormulario];
            if (form != null)
                return true;
            else
                return false;
        }

        private void mProdutos_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioExiste("frmProduto"))
                {
                    var formulario = new frmProduto();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mModulos_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioExiste("frmModulo"))
                {
                    var formulario = new frmModulo();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mFeriados_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioExiste("frmFeriado"))
                {
                    var formulario = new frmFeriado();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioExiste("frmStatus"))
                {
                    var formulario = new frmStatus(Dominio.Enumeracao.EnStatus.Todos);
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mTipos_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioExiste("frmTipo"))
                {
                    var formulario = new frmTipo(Dominio.Enumeracao.EnTipos.Todos);
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mObservacoes_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioExiste("frmObservacao"))
                {
                    var formulario = new frmObservacao();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mParametros_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioExiste("frmParametro"))
                {
                    var formulario = new frmParametro();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mContasEmails_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioExiste("frmContaEmail"))
                {
                    var formulario = new frmContaEmail();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mOrganizaCascata_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void LerMenus()
        {
            bool visivel;
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                foreach (ToolStripItem objSubItem in item.DropDownItems)
                {
                    visivel = true;
                    int idPrograma = int.Parse(objSubItem.Tag.ToString());

                    if (idPrograma == 0)
                        continue;

                    if (!PermissaoDepartamento.Listar.Any(x => x.IdPrograma == idPrograma && x.Acesso))
                        visivel = false;

                    objSubItem.Visible = visivel;

                    if (objSubItem.Name == "mClientes")
                    {
                        btnCliente.Visible = visivel;
                    }
                    if (objSubItem.Name == "mBaseConhecimentos")
                    {
                        btnBaseConh.Visible = visivel;
                    }
                    if (objSubItem.Name == "mChamados")
                    {
                        btnchamado.Visible = visivel;
                    }
                    if (objSubItem.Name == "mSolicitacoes")
                    {
                        btnSolicitacao.Visible = visivel;
                    }
                    if (objSubItem.Name == "mVersoes")
                    {
                        btnVersao.Visible = visivel;
                    }
                    if (objSubItem.Name == "mVisitas")
                    {
                        btnVisita.Visible = visivel;
                    }
                    if (objSubItem.Name == "mAtividades")
                    {
                        btnAtividade.Visible = visivel;
                    }
                    if (objSubItem.Name == "mAgendamentos")
                    {
                        btnAgendamento.Visible = visivel;
                    }
                    if (objSubItem.Name == "mOrcamentos")
                    {
                        btnOrcamento.Visible = visivel;
                    }
                    if (objSubItem.Name == "mRecados")
                    {
                        btnRecado.Visible = visivel;
                    }
                }
            }
        }

        private void mRevendas_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioExiste("frmRevenda"))
                {
                    var formulario = new frmRevenda();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mRamais_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioExiste("frmRamal"))
                {
                    var formulario = new frmRamal();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mDepartamentos_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioExiste("frmDepartamento"))
                {
                    var formulario = new frmDepartamento();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioExiste("frmUsuario"))
                {
                    var formulario = new frmUsuario();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarClientes()
        {
            try
            {
                if (!FormularioExiste("frmCliente"))
                {
                    var formulario = new frmCliente();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mClientes_Click(object sender, EventArgs e)
        {
            MostrarClientes();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            MostrarClientes();
        }

        private void mCidades_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioExiste("frmCidade"))
                {
                    var formulario = new frmCidade();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mBaseConhecimentos_Click(object sender, EventArgs e)
        {
            MostrarBaseConhecimentos();
        }

        private void MostrarBaseConhecimentos()
        {
            try
            {
                if (!FormularioExiste("frmBaseConhecimento"))
                {
                    var formulario = new frmBaseConhecimento();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBaseConh_Click(object sender, EventArgs e)
        {
            MostrarBaseConhecimentos();
        }

        private void MostrarVersao()
        {
            try
            {
                if (!FormularioExiste("frmVersao"))
                {
                    var formulario = new frmVersao();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarVisitas()
        {
            try
            {
                if (!FormularioExiste("frmVisita"))
                {
                    var formulario = new frmVisita();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarAgendamento()
        {
            try
            {
                if (!FormularioExiste("frmAgendamento"))
                {
                    var formulario = new frmAgendamento();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarRecados()
        {
            try
            {
                if (!FormularioExiste("frmRecado"))
                {
                    var formulario = new frmRecado();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarSolicitacoes()
        {
            try
            {
                if (!FormularioExiste("frmSolicitacao"))
                {
                    var formulario = new frmSolicitacao();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarModeloRelatorios()
        {
            try
            {
                if (!FormularioExiste("frmModeloRelatorio"))
                {
                    var formulario = new frmModeloRelatorio();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarChamado(EnumChamado enChamado, int idEncerramento, bool quadro, int idClienteAgendamento, int idAgendamento)
        {
            try
            {
                if (!FormularioExiste("frmChamado"))
                {
                    var formulario = new frmChamado(enChamado, idEncerramento, quadro, false, idClienteAgendamento, idAgendamento);
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mVersoes_Click(object sender, EventArgs e)
        {
            MostrarVersao();
        }

        private void btnVersao_Click(object sender, EventArgs e)
        {
            MostrarVersao();
        }

        private void mVisitas_Click(object sender, EventArgs e)
        {
            MostrarVisitas();
        }

        private void btnVisita_Click(object sender, EventArgs e)
        {
            MostrarVisitas();
        }

        private void mChamados_Click(object sender, EventArgs e)
        {
            MostrarChamado(EnumChamado.Chamado, 0, false, 0, 0);
        }

        private void mAtividades_Click(object sender, EventArgs e)
        {
            MostrarChamado(EnumChamado.Atividade, 0, false, 0, 0);
        }

        private void btnchamado_Click(object sender, EventArgs e)
        {
            MostrarChamado(EnumChamado.Chamado, 0, false, 0, 0);
        }

        private void btnAtividade_Click(object sender, EventArgs e)
        {
            MostrarChamado(EnumChamado.Atividade, 0, false, 0, 0);
        }

        private void btnAgendamento_Click(object sender, EventArgs e)
        {
            MostrarAgendamento();
        }

        private void mAgendamentos_Click(object sender, EventArgs e)
        {
            MostrarAgendamento();
        }

        private void mRecados_Click(object sender, EventArgs e)
        {
            MostrarRecados();
        }

        private void btnRecado_Click(object sender, EventArgs e)
        {
            MostrarRecados();
        }

        private void mCategorias_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioExiste("frmCategoria"))
                {
                    var formulario = new frmCategoria();
                    formulario.MdiParent = this;
                    Tela.AbrirFormulario(formulario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mSolicitacoes_Click(object sender, EventArgs e)
        {
            MostrarSolicitacoes();
        }

        private void btnSolicitacao_Click(object sender, EventArgs e)
        {
            MostrarSolicitacoes();
        }

        private void mModeloRelatorios_Click(object sender, EventArgs e)
        {
            MostrarModeloRelatorios();
        }

        private void frmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnQuadro_Click(object sender, EventArgs e)
        {
            frmQuadro quadro = new frmQuadro();
            quadro.Show();
        }
    }
}
