using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Funcoes;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Consumo;
using SIDomper.Win.Utilitarios;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIDomper.Win.View
{
    public partial class frmQuadro : Form
    {
        ChamadoQuadroViewModel _chamadoQuadroViewModel;

        public frmQuadro()
        {
            InitializeComponent();

            Grade.Configurar(ref dgvChamado1);
            Grade.Configurar(ref dgvChamado2);
            Grade.Configurar(ref dgvChamado3);
            Grade.Configurar(ref dgvChamado4);
            Grade.Configurar(ref dgvChamado5);
            Grade.Configurar(ref dgvChamado6);

            _chamadoQuadroViewModel = new ChamadoQuadroViewModel();
        }

        private void frmQuadro_Shown(object sender, EventArgs e)
        {
            //var chamadoApp = new ChamadoApp();
            //var model = chamadoApp.AbrirQuadro(1, 0, Dominio.Enumeracao.EnumChamado.Chamado);
            //dgvChamado1.DataSource = model;
            /*
             * No ONShow do quadro fazer duas requisições:
             * QuadroViewModel
             * =====================================
             * buscar as permissoes retornar boolean
             * permissao para: chamadoQuadro, Atividade, Solicitacao, agendamento, recados
             * Coluna Tempo (chamados e atividades) Mostrar Tempos
             *  CodstatusChamadoAbertura parametro(9, 1)
             *  CodstatusChamadoOcorrenciaAtendimento parametro(10, 1)
             *  CodStatusAtividadeAbertura(31,111)
             *  CodStatusAtividadeOcorrenciaAtendimento(32,111)
             *  Chamado:
             * Se o quadro que tem o codigoStatus = parametro 9 (CodstatusChamadoAbertura)
             *      CTempo
             * SeNao CodigoStatus = CodstatusChamadoOcorrenciaAtendimento (parametro 10)
             *      CTempoPar10
             * SeNao
             *      CTempoParOutro
             * o mesmo para Atividades
             * 
             * Permissao Solicitacao, mostar as opções do PopMenu das solicitações
             * Grades Altura e lagura
             * 
             * controle titulo tempo solicitacao nas grids parametro(45,3)
             * 
             * MostrarCheckBoxRecado
             * =====================================
             * Se tem Recados Então
             *      Abrir tela dos recados
             * Se não
             *      Abrir tela dos Chamados
             * Abrir o Timer intervalo de 60000 - a cada 1 minuto
             */
            BuscarQuadroChamado();
        }

        private void EntrarChamadoOcorrencia(ref DataGridView grid)
        {
            if (!PermissaoDepartamento.DadosUsuario.Departamento.ChamadoOcorrencia)
            {
                MessageBox.Show("Usuário sem Permissão!");
                return;
            }

            if (!UsuarioPermissaoMenu.Lib_Chamado_Ocorr_Alt)
            {
                MessageBox.Show("Usuário sem Permissão!");
                return;
            }

            if (grid.RowCount == 0)
            {
                MessageBox.Show("Não há Registro!");
                return;
            }

            int id = Grade.RetornarId(ref grid, "Cha1_Id");

            ExecutaTimer(false);

            // pode entrar
            if (grid.Name == "dgvChamado1")
            {
                if (_chamadoQuadroViewModel.CodigoStatusQuadro1 != _chamadoQuadroViewModel.Quadro1.FirstOrDefault(x => x.Id == id).CodigoStatus) // codigo status do chamado
                {
                    MessageBox.Show("Chamado em Atendimento por outra Pessoa!");
                    return;
                }

                if (_chamadoQuadroViewModel.StatusChamadoAtendimentoCodigo == _chamadoQuadroViewModel.CodigoStatusQuadro1) // status do quadro
                {
                    if (Funcoes.IdUsuario != _chamadoQuadroViewModel.Quadro1.FirstOrDefault(x => x.Id == id).UsuarioAtendeAtualId) // chamadoUsuarioAtendeAtualId
                    {
                        MessageBox.Show("Chamado em Atendimento por outra Pessoa!");
                        return;
                    }
                }
            }

            // Gravar hora atual
            if (_chamadoQuadroViewModel.StatusChamadoAtendimentoCodigo != _chamadoQuadroViewModel.CodigoStatusQuadro1)
            {
                var appChamado = new ChamadoApp();
                var model = new ChamadoGravaHoraAtualViewModel();
                model.IdChamado = id;
                model.IdStatus = _chamadoQuadroViewModel.Quadro1.FirstOrDefault(x => x.Id == id).IdStatus;
                model.IdUsuario = Funcoes.IdUsuario;
                appChamado.GravarHoraAtual(model);
            }

            frmChamado frmChamado = new frmChamado(id, true, true, EnumChamado.Chamado);
            frmChamado.ShowDialog();
            // entrar no chamado
            // TODO: implementar

        }

        private async Task BuscarQuadroChamado()
        {
            int idRevenda = 0;
            var chamadoConsumo = new ChamadoConsumo();
            _chamadoQuadroViewModel = await chamadoConsumo.GetQuadroAsync(Funcoes.IdUsuario, idRevenda, EnumChamado.Chamado);

            var QtdeRegistros1 = _chamadoQuadroViewModel.Quadro1.Count();
            var QtdeRegistros2 = _chamadoQuadroViewModel.Quadro2.Count();
            var QtdeRegistros3 = _chamadoQuadroViewModel.Quadro3.Count();
            var QtdeRegistros4 = _chamadoQuadroViewModel.Quadro4.Count();
            var QtdeRegistros5 = _chamadoQuadroViewModel.Quadro5.Count();
            var QtdeRegistros6 = _chamadoQuadroViewModel.Quadro6.Count();

            lblTituloChamado1.Text = _chamadoQuadroViewModel.Titulo1 + " ( " + QtdeRegistros1 + " )";
            lblTituloChamado2.Text = _chamadoQuadroViewModel.Titulo2 + " ( " + QtdeRegistros2 + " )";
            lblTituloChamado3.Text = _chamadoQuadroViewModel.Titulo3 + " ( " + QtdeRegistros3 + " )";
            lblTituloChamado4.Text = _chamadoQuadroViewModel.Titulo4 + " ( " + QtdeRegistros4 + " )";
            lblTituloChamado5.Text = _chamadoQuadroViewModel.Titulo5 + " ( " + QtdeRegistros5 + " )";
            lblTituloChamado6.Text = _chamadoQuadroViewModel.Titulo6 + " ( " + QtdeRegistros6 + " )";

            dgvChamado1.DataSource = _chamadoQuadroViewModel.Quadro1;
            dgvChamado2.DataSource = _chamadoQuadroViewModel.Quadro2;
            dgvChamado3.DataSource = _chamadoQuadroViewModel.Quadro3;
            dgvChamado4.DataSource = _chamadoQuadroViewModel.Quadro4;
            dgvChamado5.DataSource = _chamadoQuadroViewModel.Quadro5;
            dgvChamado6.DataSource = _chamadoQuadroViewModel.Quadro6;
        }

        private void AjustarTela()
        {
            AlturaGradesChamados();
            ComprimentoGradeChamados();
            MostrarTitulosChamados();
            ChamadosCampos();
            
            //BuscarTitulosChamados();
        }

        private void ChamadosCampos()
        {
            GradeChamadoCampos(ref dgvChamado1);
            GradeChamadoCampos(ref dgvChamado2);
            GradeChamadoCampos(ref dgvChamado3);
            GradeChamadoCampos(ref dgvChamado4);
            GradeChamadoCampos(ref dgvChamado5);
            GradeChamadoCampos(ref dgvChamado6);

            //GradeChamadoCampos(ref dgvAtividade1);
            //GradeChamadoCampos(ref dgvAtividade2);
            //GradeChamadoCampos(ref dgvAtividade3);
            //GradeChamadoCampos(ref dgvAtividade4);
            //GradeChamadoCampos(ref dgvAtividade5);
            //GradeChamadoCampos(ref dgvAtividade6);
        }

        private void GradeChamadoCampos(ref DataGridView grid)
        {
            grid.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
            grid.RowHeadersVisible = false;
            grid.Columns[0].Width = 60;
            grid.Columns[1].Width = 80;
            grid.Columns[2].Width = 60;
            grid.Columns[3].Width = 250;
            grid.Columns[4].Width = 50;
            grid.Columns[5].Width = 50;
            grid.Columns[6].Width = 100;
            grid.Columns[7].Width = 60;

            grid.Columns[3].Width = grid.Width - 480;
        }

        private void MostrarTitulosChamados()
        {
            TitulosChamados(ref dgvChamado2, ref lblTituloChamado2);
            TitulosChamados(ref dgvChamado3, ref lblTituloChamado3);
            TitulosChamados(ref dgvChamado4, ref lblTituloChamado4);
            TitulosChamados(ref dgvChamado5, ref lblTituloChamado5);
            TitulosChamados(ref dgvChamado6, ref lblTituloChamado6);
        }

        private void TitulosChamados(ref DataGridView dataGridView, ref Label label)
        {
            label.Top = dataGridView.Top - 20;
            label.Left = dataGridView.Left;
            label.Width = dataGridView.Width;
        }

        private void ComprimentoGradeChamados()
        {
            double comprimento = (tabChamado.Width / 2) - 20;
            dgvChamado1.Top = 40;
            dgvChamado1.Left = 10;
            dgvChamado1.Width = (int)comprimento;

            dgvChamado2.Top = dgvChamado1.Top;
            dgvChamado2.Left = dgvChamado1.Left + dgvChamado1.Width + 10;
            dgvChamado2.Width = dgvChamado1.Width;

            dgvChamado3.Top = dgvChamado1.Top + dgvChamado1.Height + 30;
            dgvChamado3.Left = dgvChamado1.Left;
            dgvChamado3.Width = dgvChamado1.Width;

            dgvChamado4.Top = dgvChamado3.Top;
            dgvChamado4.Left = dgvChamado1.Left + dgvChamado1.Width + 10;
            dgvChamado4.Width = dgvChamado1.Width;

            dgvChamado5.Top = dgvChamado3.Top + dgvChamado1.Height + 30;
            dgvChamado5.Left = dgvChamado1.Left;
            dgvChamado5.Width = dgvChamado1.Width;

            dgvChamado6.Top = dgvChamado5.Top;
            dgvChamado6.Left = dgvChamado4.Left;
            dgvChamado6.Width = dgvChamado4.Width;

            btnAbrirChamado.Left = dgvChamado1.Left;
            btnAbrirChamado.Top = dgvChamado1.Top - 30;

            lblTituloChamado1.Top = dgvChamado1.Top - 20;
            lblTituloChamado1.Width = dgvChamado1.Width;
        }

        private void AlturaGradesChamados()
        {
            int altura = (tabChamado.Height / 3) - (groupBox1.Height - 10);
            dgvChamado1.Height = (int)altura;

            dgvChamado2.Height = dgvChamado1.Height;
            dgvChamado3.Height = dgvChamado1.Height;
            dgvChamado4.Height = dgvChamado1.Height;
            dgvChamado5.Height = dgvChamado1.Height - 25;
            dgvChamado6.Height = dgvChamado5.Height;
        }

        private void btnAbrirChamado_Click(object sender, EventArgs e)
        {
            EntrarChamadoOcorrencia(ref dgvChamado1);
            //BuscarQuadroChamado();
        }

        private void tabChamado_Resize(object sender, EventArgs e)
        {
            AjustarTela();
        }

        private void PopMenuChamados()
        {
            ContextMenuStrip menuCha1 = new ContextMenuStrip();
            menuCha1.Items.Add("Detalhes");
            dgvChamado1.ContextMenuStrip = menuCha1;
            menuCha1.ItemClicked += new ToolStripItemClickedEventHandler(menuCha1_ItemClicked);

            ContextMenuStrip menuCha2 = new ContextMenuStrip();
            menuCha2.Items.Add("Detalhes");
            dgvChamado2.ContextMenuStrip = menuCha2;
            menuCha2.ItemClicked += new ToolStripItemClickedEventHandler(menuCha2_ItemClicked);

            ContextMenuStrip menuCha3 = new ContextMenuStrip();
            menuCha3.Items.Add("Detalhes");
            dgvChamado3.ContextMenuStrip = menuCha3;
            menuCha3.ItemClicked += new ToolStripItemClickedEventHandler(menuCha3_ItemClicked);

            ContextMenuStrip menuCha4 = new ContextMenuStrip();
            menuCha4.Items.Add("Detalhes");
            dgvChamado4.ContextMenuStrip = menuCha4;
            menuCha4.ItemClicked += new ToolStripItemClickedEventHandler(menuCha4_ItemClicked);

            ContextMenuStrip menuCha5 = new ContextMenuStrip();
            menuCha5.Items.Add("Detalhes");
            dgvChamado5.ContextMenuStrip = menuCha5;
            menuCha5.ItemClicked += new ToolStripItemClickedEventHandler(menuCha5_ItemClicked);

            ContextMenuStrip menuCha6 = new ContextMenuStrip();
            menuCha6.Items.Add("Detalhes");
            menuCha6.Items.Add("Texto");
            dgvChamado6.ContextMenuStrip = menuCha6;
            menuCha6.ItemClicked += new ToolStripItemClickedEventHandler(menuCha6_ItemClicked);
        }

        private void menuCha6_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dgvChamado6.RowCount == 0)
            {
                MessageBox.Show("Não há Registro!");
                return;
            }

            ExecutaTimer(false);
            var id = Grade.RetornarId(ref dgvChamado6, "Cha6_Id");
            frmBaseConhecimentoDetalhe formulario = new frmBaseConhecimentoDetalhe(id, EnProgramas.Chamado);
            formulario.ShowDialog();
            ExecutaTimer(true);


            //if (e.ClickedItem.Text == "Detalhes")
            //{
            //    var id = Grade.RetornarId(ref dgvChamado6, "Cha6_Id");
            //    MessageBox.Show(id.ToString());
            //}
            //else
            //{
            //    MessageBox.Show(e.ClickedItem.Text);
            //}
        }

        private void menuCha5_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dgvChamado5.RowCount == 0)
            {
                MessageBox.Show("Não há Registro!");
                return;
            }

            ExecutaTimer(false);
            var id = Grade.RetornarId(ref dgvChamado5, "Cha5_Id");
            frmBaseConhecimentoDetalhe formulario = new frmBaseConhecimentoDetalhe(id, EnProgramas.Chamado);
            formulario.ShowDialog();
            ExecutaTimer(true);
        }

        private void menuCha4_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dgvChamado4.RowCount == 0)
            {
                MessageBox.Show("Não há Registro!");
                return;
            }

            ExecutaTimer(false);
            var id = Grade.RetornarId(ref dgvChamado4, "Cha4_Id");
            frmBaseConhecimentoDetalhe formulario = new frmBaseConhecimentoDetalhe(id, EnProgramas.Chamado);
            formulario.ShowDialog();
            ExecutaTimer(true);
        }

        private void menuCha3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dgvChamado3.RowCount == 0)
            {
                MessageBox.Show("Não há Registro!");
                return;
            }

            ExecutaTimer(false);
            var id = Grade.RetornarId(ref dgvChamado3, "Cha3_Id");
            frmBaseConhecimentoDetalhe formulario = new frmBaseConhecimentoDetalhe(id, EnProgramas.Chamado);
            formulario.ShowDialog();
            ExecutaTimer(true);
        }

        private void menuCha2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dgvChamado2.RowCount == 0)
            {
                MessageBox.Show("Não há Registro!");
                return;
            }

            ExecutaTimer(false);
            var id = Grade.RetornarId(ref dgvChamado2, "Cha2_Id");
            frmBaseConhecimentoDetalhe formulario = new frmBaseConhecimentoDetalhe(id, EnProgramas.Chamado);
            formulario.ShowDialog();
            ExecutaTimer(true);
        }

        private void ExecutaTimer(bool executar)
        {
            if (executar)
                timer1.Start();
            else
                timer1.Stop();
        }

        private void frmQuadro_Load(object sender, EventArgs e)
        {
            PopMenuChamados();
            ExecutaTimer(true);
        }

        private void menuCha1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dgvChamado1.RowCount == 0)
            {
                MessageBox.Show("Não há Registro!");
                return;
            }
            // parar timer
            ExecutaTimer(false);
            var id = Grade.RetornarId(ref dgvChamado1, "Cha1_Id");
            frmBaseConhecimentoDetalhe formulario = new frmBaseConhecimentoDetalhe(id, EnProgramas.Chamado);
            formulario.ShowDialog();
            ExecutaTimer(true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BuscarQuadroChamado();
        }

        private void dgvChamado1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EntrarChamadoOcorrencia(ref dgvChamado1);
        }

        private void frmQuadro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
