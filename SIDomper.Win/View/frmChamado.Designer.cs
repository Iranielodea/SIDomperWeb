namespace SIDomper.Win.View
{
    partial class frmChamado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.Cha_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cha_DataAbertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cha_HoraAbertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cha_Nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cli_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cli_Fantasia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tip_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sta_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usu_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigo = new SIDomper.Win.Componentes.usrSoNumero();
            this.txtDataAbertura = new SIDomper.Win.Componentes.usrData();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.txtDadosCliente = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAlterarDataHora = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.liberarDataEHoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDataInicial = new SIDomper.Win.Componentes.usrData();
            this.txtDataFinal = new SIDomper.Win.Componentes.usrData();
            this.label14 = new System.Windows.Forms.Label();
            this.tpUsuario = new System.Windows.Forms.TabPage();
            this.ursFiltroUsuario = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.tpModulo = new System.Windows.Forms.TabPage();
            this.ursFiltroModulo = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.tpTipo = new System.Windows.Forms.TabPage();
            this.ursFiltroTipo = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.tpStatus = new System.Windows.Forms.TabPage();
            this.ursFiltroStatus = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.btnDetalhes = new System.Windows.Forms.Button();
            this.btnDetalhes2 = new System.Windows.Forms.Button();
            this.txtHoraAbertura = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.grNivel = new System.Windows.Forms.GroupBox();
            this.rbCritico = new System.Windows.Forms.RadioButton();
            this.rbAlto = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbBaixo = new System.Windows.Forms.RadioButton();
            this.tpOcorrencia = new System.Windows.Forms.TabPage();
            this.btnColaborador = new System.Windows.Forms.Button();
            this.btnExcluirOco = new System.Windows.Forms.Button();
            this.UsrUsuarioOco = new SIDomper.Win.Componentes.usrPesquisa();
            this.txtIdOcorrencia = new System.Windows.Forms.TextBox();
            this.btnSalvarOco = new System.Windows.Forms.Button();
            this.btnNovoOco = new System.Windows.Forms.Button();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnAnexo = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.txtAnexo = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtDescricaoSolucao = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtDescricaoProblema = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtDadosClienteOco = new System.Windows.Forms.TextBox();
            this.txtVersao = new System.Windows.Forms.TextBox();
            this.txtHoraFinalOco = new System.Windows.Forms.MaskedTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtHoraInicialOco = new System.Windows.Forms.MaskedTextBox();
            this.txtDataOco = new SIDomper.Win.Componentes.usrData();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dgvOcorrencia = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraFim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsrModulo = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrProduto = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrTipo = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrStatus = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrCliente = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrUsuario = new SIDomper.Win.Componentes.usrPesquisa();
            this.btnEspecificao = new System.Windows.Forms.Button();
            this.btnModulo = new System.Windows.Forms.Button();
            this.btnSolucao = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnAnexo2 = new System.Windows.Forms.Button();
            this.tpStatusOcorrencia = new System.Windows.Forms.TabPage();
            this.dgvStatus = new System.Windows.Forms.DataGridView();
            this.StatusData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tpPesquisa.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpEditar.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tbPrincipal.SuspendLayout();
            this.tpFiltro.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tpFiltroPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tpUsuario.SuspendLayout();
            this.tpModulo.SuspendLayout();
            this.tpTipo.SuspendLayout();
            this.tpStatus.SuspendLayout();
            this.grNivel.SuspendLayout();
            this.tpOcorrencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcorrencia)).BeginInit();
            this.tpStatusOcorrencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(1041, 596);
            // 
            // tpPesquisa
            // 
            this.tpPesquisa.Controls.Add(this.dgvDados);
            this.tpPesquisa.Margin = new System.Windows.Forms.Padding(5);
            this.tpPesquisa.Padding = new System.Windows.Forms.Padding(5);
            this.tpPesquisa.Size = new System.Drawing.Size(1033, 566);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.dgvDados, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDetalhes2);
            this.groupBox2.Location = new System.Drawing.Point(5, 498);
            this.groupBox2.Size = new System.Drawing.Size(1023, 63);
            this.groupBox2.Controls.SetChildIndex(this.btnNovo, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnEditar, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnExcluir, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnSair, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnFiltro, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnDetalhes2, 0);
            // 
            // btnFiltro
            // 
            this.btnFiltro.Location = new System.Drawing.Point(324, 18);
            this.btnFiltro.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(427, 18);
            this.btnSair.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(221, 18);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(118, 18);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(15, 18);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(5);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Size = new System.Drawing.Size(1023, 60);
            this.groupBox1.TabIndex = 0;
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(430, 32);
            this.txtTexto.Margin = new System.Windows.Forms.Padding(5);
            this.txtTexto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTexto_KeyDown);
            // 
            // cbCampos
            // 
            this.cbCampos.Size = new System.Drawing.Size(271, 25);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(427, 13);
            // 
            // tpEditar
            // 
            this.tpEditar.Margin = new System.Windows.Forms.Padding(5);
            this.tpEditar.Padding = new System.Windows.Forms.Padding(5);
            this.tpEditar.Size = new System.Drawing.Size(1033, 566);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAnexo2);
            this.groupBox3.Controls.Add(this.btnCliente);
            this.groupBox3.Controls.Add(this.btnSolucao);
            this.groupBox3.Controls.Add(this.btnModulo);
            this.groupBox3.Controls.Add(this.btnEspecificao);
            this.groupBox3.Controls.Add(this.btnDetalhes);
            this.groupBox3.Location = new System.Drawing.Point(5, 498);
            this.groupBox3.Size = new System.Drawing.Size(1023, 63);
            this.groupBox3.Controls.SetChildIndex(this.btnSalvar, 0);
            this.groupBox3.Controls.SetChildIndex(this.btnVoltar2, 0);
            this.groupBox3.Controls.SetChildIndex(this.btnDetalhes, 0);
            this.groupBox3.Controls.SetChildIndex(this.btnEspecificao, 0);
            this.groupBox3.Controls.SetChildIndex(this.btnModulo, 0);
            this.groupBox3.Controls.SetChildIndex(this.btnSolucao, 0);
            this.groupBox3.Controls.SetChildIndex(this.btnCliente, 0);
            this.groupBox3.Controls.SetChildIndex(this.btnAnexo2, 0);
            // 
            // btnVoltar2
            // 
            this.btnVoltar2.Location = new System.Drawing.Point(118, 19);
            this.btnVoltar2.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(15, 19);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(5);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tpOcorrencia);
            this.tabControl2.Controls.Add(this.tpStatusOcorrencia);
            this.tabControl2.Location = new System.Drawing.Point(5, 5);
            this.tabControl2.Size = new System.Drawing.Size(1023, 556);
            this.tabControl2.Click += new System.EventHandler(this.tabControl2_Click);
            this.tabControl2.Controls.SetChildIndex(this.tpStatusOcorrencia, 0);
            this.tabControl2.Controls.SetChildIndex(this.tpOcorrencia, 0);
            this.tabControl2.Controls.SetChildIndex(this.tbPrincipal, 0);
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.Controls.Add(this.UsrUsuario);
            this.tbPrincipal.Controls.Add(this.UsrCliente);
            this.tbPrincipal.Controls.Add(this.UsrStatus);
            this.tbPrincipal.Controls.Add(this.UsrTipo);
            this.tbPrincipal.Controls.Add(this.UsrProduto);
            this.tbPrincipal.Controls.Add(this.UsrModulo);
            this.tbPrincipal.Controls.Add(this.grNivel);
            this.tbPrincipal.Controls.Add(this.label15);
            this.tbPrincipal.Controls.Add(this.txtHoraAbertura);
            this.tbPrincipal.Controls.Add(this.txtDescricao);
            this.tbPrincipal.Controls.Add(this.label12);
            this.tbPrincipal.Controls.Add(this.label11);
            this.tbPrincipal.Controls.Add(this.txtDadosCliente);
            this.tbPrincipal.Controls.Add(this.txtContato);
            this.tbPrincipal.Controls.Add(this.label4);
            this.tbPrincipal.Controls.Add(this.label3);
            this.tbPrincipal.Controls.Add(this.txtDataAbertura);
            this.tbPrincipal.Controls.Add(this.label5);
            this.tbPrincipal.Controls.Add(this.txtCodigo);
            this.tbPrincipal.Size = new System.Drawing.Size(1015, 526);
            this.tbPrincipal.Text = "Abertura";
            // 
            // tpFiltro
            // 
            this.tpFiltro.Margin = new System.Windows.Forms.Padding(5);
            this.tpFiltro.Padding = new System.Windows.Forms.Padding(5);
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(5, 453);
            this.groupBox4.Size = new System.Drawing.Size(686, 63);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(221, 18);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(118, 18);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(15, 18);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(5);
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tpUsuario);
            this.tabControl3.Controls.Add(this.tpModulo);
            this.tabControl3.Controls.Add(this.tpTipo);
            this.tabControl3.Controls.Add(this.tpStatus);
            this.tabControl3.Location = new System.Drawing.Point(5, 5);
            this.tabControl3.Size = new System.Drawing.Size(686, 511);
            this.tabControl3.Click += new System.EventHandler(this.tabControl3_Click);
            this.tabControl3.Controls.SetChildIndex(this.tpStatus, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpTipo, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpModulo, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpUsuario, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpFiltroPrincipal, 0);
            // 
            // tpFiltroPrincipal
            // 
            this.tpFiltroPrincipal.Controls.Add(this.txtDataFinal);
            this.tpFiltroPrincipal.Controls.Add(this.label14);
            this.tpFiltroPrincipal.Controls.Add(this.txtDataInicial);
            this.tpFiltroPrincipal.Controls.Add(this.label13);
            this.tpFiltroPrincipal.Size = new System.Drawing.Size(678, 481);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.lblAtivo, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.cboAtivo, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.label13, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.txtDataInicial, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.label14, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.txtDataFinal, 0);
            // 
            // cboAtivo
            // 
            this.cboAtivo.Location = new System.Drawing.Point(189, 45);
            this.cboAtivo.Size = new System.Drawing.Size(121, 25);
            // 
            // lblAtivo
            // 
            this.lblAtivo.Location = new System.Drawing.Point(186, 25);
            // 
            // lblPesquisa
            // 
            this.lblPesquisa.Location = new System.Drawing.Point(286, 10);
            // 
            // cbPesquisa
            // 
            this.cbPesquisa.Location = new System.Drawing.Point(289, 30);
            this.cbPesquisa.Size = new System.Drawing.Size(133, 25);
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cha_Id,
            this.Cha_DataAbertura,
            this.Cha_HoraAbertura,
            this.Cha_Nivel,
            this.Cli_Nome,
            this.Cli_Fantasia,
            this.Tip_Nome,
            this.Sta_Nome,
            this.Usu_Nome});
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(5, 65);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(1023, 433);
            this.dgvDados.TabIndex = 1;
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_ColumnHeaderMouseClick);
            // 
            // Cha_Id
            // 
            this.Cha_Id.DataPropertyName = "Id";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "000000";
            this.Cha_Id.DefaultCellStyle = dataGridViewCellStyle1;
            this.Cha_Id.HeaderText = "Id";
            this.Cha_Id.Name = "Cha_Id";
            this.Cha_Id.Width = 80;
            // 
            // Cha_DataAbertura
            // 
            this.Cha_DataAbertura.DataPropertyName = "DataAbertura";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.Cha_DataAbertura.DefaultCellStyle = dataGridViewCellStyle2;
            this.Cha_DataAbertura.HeaderText = "Data";
            this.Cha_DataAbertura.Name = "Cha_DataAbertura";
            // 
            // Cha_HoraAbertura
            // 
            this.Cha_HoraAbertura.DataPropertyName = "HoraAbertura";
            this.Cha_HoraAbertura.HeaderText = "Hora";
            this.Cha_HoraAbertura.Name = "Cha_HoraAbertura";
            this.Cha_HoraAbertura.Width = 60;
            // 
            // Cha_Nivel
            // 
            this.Cha_Nivel.DataPropertyName = "Nivel";
            this.Cha_Nivel.HeaderText = "Nível";
            this.Cha_Nivel.Name = "Cha_Nivel";
            // 
            // Cli_Nome
            // 
            this.Cli_Nome.DataPropertyName = "RazaoSocial";
            this.Cli_Nome.HeaderText = "Cliente";
            this.Cli_Nome.Name = "Cli_Nome";
            this.Cli_Nome.Width = 200;
            // 
            // Cli_Fantasia
            // 
            this.Cli_Fantasia.DataPropertyName = "Fantasia";
            this.Cli_Fantasia.HeaderText = "Nome Fantasia";
            this.Cli_Fantasia.Name = "Cli_Fantasia";
            this.Cli_Fantasia.Width = 200;
            // 
            // Tip_Nome
            // 
            this.Tip_Nome.DataPropertyName = "NomeTipo";
            this.Tip_Nome.HeaderText = "Tipo";
            this.Tip_Nome.Name = "Tip_Nome";
            this.Tip_Nome.Width = 150;
            // 
            // Sta_Nome
            // 
            this.Sta_Nome.DataPropertyName = "NomeStatus";
            this.Sta_Nome.HeaderText = "Status";
            this.Sta_Nome.Name = "Sta_Nome";
            this.Sta_Nome.Width = 150;
            // 
            // Usu_Nome
            // 
            this.Usu_Nome.DataPropertyName = "NomeUsuario";
            this.Usu_Nome.HeaderText = "Usuário Abertura";
            this.Usu_Nome.Name = "Usu_Nome";
            this.Usu_Nome.Width = 150;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "ID";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(11, 30);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(92, 29);
            this.txtCodigo.TabIndex = 0;
            // 
            // txtDataAbertura
            // 
            this.txtDataAbertura.Location = new System.Drawing.Point(110, 31);
            this.txtDataAbertura.Name = "txtDataAbertura";
            this.txtDataAbertura.Size = new System.Drawing.Size(99, 25);
            this.txtDataAbertura.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Data Abertura*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Contato";
            // 
            // txtContato
            // 
            this.txtContato.Location = new System.Drawing.Point(11, 125);
            this.txtContato.MaxLength = 100;
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(577, 23);
            this.txtContato.TabIndex = 5;
            // 
            // txtDadosCliente
            // 
            this.txtDadosCliente.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDadosCliente.Location = new System.Drawing.Point(11, 371);
            this.txtDadosCliente.MaxLength = 5000;
            this.txtDadosCliente.Multiline = true;
            this.txtDadosCliente.Name = "txtDadosCliente";
            this.txtDadosCliente.ReadOnly = true;
            this.txtDadosCliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDadosCliente.Size = new System.Drawing.Size(572, 85);
            this.txtDadosCliente.TabIndex = 17;
            this.txtDadosCliente.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 351);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 17);
            this.label11.TabIndex = 34;
            this.label11.Text = "Dados do Cliente";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(595, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 17);
            this.label12.TabIndex = 37;
            this.label12.Text = "Descrição*";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(598, 31);
            this.txtDescricao.MaxLength = 1000;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricao.Size = new System.Drawing.Size(407, 425);
            this.txtDescricao.TabIndex = 11;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescricao_KeyDown);
            this.txtDescricao.Leave += new System.EventHandler(this.txtDescricao_Leave);
            // 
            // btnAlterarDataHora
            // 
            this.btnAlterarDataHora.ContextMenuStrip = this.contextMenuStrip1;
            this.btnAlterarDataHora.Location = new System.Drawing.Point(455, 132);
            this.btnAlterarDataHora.Name = "btnAlterarDataHora";
            this.btnAlterarDataHora.Size = new System.Drawing.Size(35, 23);
            this.btnAlterarDataHora.TabIndex = 26;
            this.btnAlterarDataHora.Text = "...";
            this.toolTip1.SetToolTip(this.btnAlterarDataHora, "Alterar Data e Hora");
            this.btnAlterarDataHora.UseVisualStyleBackColor = true;
            this.btnAlterarDataHora.Click += new System.EventHandler(this.btnAlterarDataHora_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liberarDataEHoraToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 26);
            // 
            // liberarDataEHoraToolStripMenuItem
            // 
            this.liberarDataEHoraToolStripMenuItem.Name = "liberarDataEHoraToolStripMenuItem";
            this.liberarDataEHoraToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.liberarDataEHoraToolStripMenuItem.Text = "Liberar Data e Hora";
            this.liberarDataEHoraToolStripMenuItem.Click += new System.EventHandler(this.liberarDataEHoraToolStripMenuItem_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "Data Inicial";
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.Location = new System.Drawing.Point(24, 45);
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.Size = new System.Drawing.Size(90, 25);
            this.txtDataInicial.TabIndex = 3;
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Location = new System.Drawing.Point(24, 95);
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(90, 25);
            this.txtDataFinal.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 17);
            this.label14.TabIndex = 4;
            this.label14.Text = "Data Final";
            // 
            // tpUsuario
            // 
            this.tpUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpUsuario.Controls.Add(this.ursFiltroUsuario);
            this.tpUsuario.Location = new System.Drawing.Point(4, 26);
            this.tpUsuario.Name = "tpUsuario";
            this.tpUsuario.Padding = new System.Windows.Forms.Padding(3);
            this.tpUsuario.Size = new System.Drawing.Size(678, 481);
            this.tpUsuario.TabIndex = 1;
            this.tpUsuario.Text = "Usuário";
            // 
            // ursFiltroUsuario
            // 
            this.ursFiltroUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroUsuario.Location = new System.Drawing.Point(11, 6);
            this.ursFiltroUsuario.Name = "ursFiltroUsuario";
            this.ursFiltroUsuario.Size = new System.Drawing.Size(995, 547);
            this.ursFiltroUsuario.TabIndex = 0;
            // 
            // tpModulo
            // 
            this.tpModulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpModulo.Controls.Add(this.ursFiltroModulo);
            this.tpModulo.Location = new System.Drawing.Point(4, 26);
            this.tpModulo.Name = "tpModulo";
            this.tpModulo.Padding = new System.Windows.Forms.Padding(3);
            this.tpModulo.Size = new System.Drawing.Size(678, 481);
            this.tpModulo.TabIndex = 2;
            this.tpModulo.Text = "Módulo";
            // 
            // ursFiltroModulo
            // 
            this.ursFiltroModulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroModulo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroModulo.Location = new System.Drawing.Point(11, 6);
            this.ursFiltroModulo.Name = "ursFiltroModulo";
            this.ursFiltroModulo.Size = new System.Drawing.Size(998, 547);
            this.ursFiltroModulo.TabIndex = 0;
            // 
            // tpTipo
            // 
            this.tpTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpTipo.Controls.Add(this.ursFiltroTipo);
            this.tpTipo.Location = new System.Drawing.Point(4, 26);
            this.tpTipo.Name = "tpTipo";
            this.tpTipo.Padding = new System.Windows.Forms.Padding(3);
            this.tpTipo.Size = new System.Drawing.Size(678, 481);
            this.tpTipo.TabIndex = 3;
            this.tpTipo.Text = "Tipo";
            // 
            // ursFiltroTipo
            // 
            this.ursFiltroTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroTipo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroTipo.Location = new System.Drawing.Point(11, 6);
            this.ursFiltroTipo.Name = "ursFiltroTipo";
            this.ursFiltroTipo.Size = new System.Drawing.Size(995, 547);
            this.ursFiltroTipo.TabIndex = 0;
            // 
            // tpStatus
            // 
            this.tpStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpStatus.Controls.Add(this.ursFiltroStatus);
            this.tpStatus.Location = new System.Drawing.Point(4, 26);
            this.tpStatus.Name = "tpStatus";
            this.tpStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tpStatus.Size = new System.Drawing.Size(678, 481);
            this.tpStatus.TabIndex = 4;
            this.tpStatus.Text = "Status";
            // 
            // ursFiltroStatus
            // 
            this.ursFiltroStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroStatus.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroStatus.Location = new System.Drawing.Point(11, 6);
            this.ursFiltroStatus.Name = "ursFiltroStatus";
            this.ursFiltroStatus.Size = new System.Drawing.Size(995, 547);
            this.ursFiltroStatus.TabIndex = 0;
            // 
            // btnDetalhes
            // 
            this.btnDetalhes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDetalhes.Location = new System.Drawing.Point(219, 19);
            this.btnDetalhes.Name = "btnDetalhes";
            this.btnDetalhes.Size = new System.Drawing.Size(93, 40);
            this.btnDetalhes.TabIndex = 8;
            this.btnDetalhes.Text = "Detalhes";
            this.btnDetalhes.UseVisualStyleBackColor = true;
            this.btnDetalhes.Click += new System.EventHandler(this.btnDetalhes_Click);
            // 
            // btnDetalhes2
            // 
            this.btnDetalhes2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDetalhes2.Location = new System.Drawing.Point(528, 18);
            this.btnDetalhes2.Name = "btnDetalhes2";
            this.btnDetalhes2.Size = new System.Drawing.Size(93, 40);
            this.btnDetalhes2.TabIndex = 5;
            this.btnDetalhes2.Text = "Detalhes";
            this.btnDetalhes2.UseVisualStyleBackColor = true;
            this.btnDetalhes2.Click += new System.EventHandler(this.btnDetalhes2_Click);
            // 
            // txtHoraAbertura
            // 
            this.txtHoraAbertura.Location = new System.Drawing.Point(215, 31);
            this.txtHoraAbertura.Mask = "00:00";
            this.txtHoraAbertura.Name = "txtHoraAbertura";
            this.txtHoraAbertura.Size = new System.Drawing.Size(100, 23);
            this.txtHoraAbertura.TabIndex = 2;
            this.txtHoraAbertura.ValidatingType = typeof(System.DateTime);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(212, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 17);
            this.label15.TabIndex = 44;
            this.label15.Text = "Hora Abertura*";
            // 
            // grNivel
            // 
            this.grNivel.BackColor = System.Drawing.Color.Silver;
            this.grNivel.Controls.Add(this.rbCritico);
            this.grNivel.Controls.Add(this.rbAlto);
            this.grNivel.Controls.Add(this.rbNormal);
            this.grNivel.Controls.Add(this.rbBaixo);
            this.grNivel.Location = new System.Drawing.Point(11, 154);
            this.grNivel.Name = "grNivel";
            this.grNivel.Size = new System.Drawing.Size(577, 44);
            this.grNivel.TabIndex = 8;
            this.grNivel.TabStop = false;
            this.grNivel.Text = "Nível:";
            // 
            // rbCritico
            // 
            this.rbCritico.AutoSize = true;
            this.rbCritico.Location = new System.Drawing.Point(407, 17);
            this.rbCritico.Name = "rbCritico";
            this.rbCritico.Size = new System.Drawing.Size(80, 21);
            this.rbCritico.TabIndex = 3;
            this.rbCritico.TabStop = true;
            this.rbCritico.Text = "4-Crítico";
            this.rbCritico.UseVisualStyleBackColor = true;
            // 
            // rbAlto
            // 
            this.rbAlto.AutoSize = true;
            this.rbAlto.Location = new System.Drawing.Point(271, 17);
            this.rbAlto.Name = "rbAlto";
            this.rbAlto.Size = new System.Drawing.Size(63, 21);
            this.rbAlto.TabIndex = 2;
            this.rbAlto.TabStop = true;
            this.rbAlto.Text = "3-Alto";
            this.rbAlto.UseVisualStyleBackColor = true;
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(111, 17);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(85, 21);
            this.rbNormal.TabIndex = 1;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "2-Normal";
            this.rbNormal.UseVisualStyleBackColor = true;
            // 
            // rbBaixo
            // 
            this.rbBaixo.AutoSize = true;
            this.rbBaixo.Location = new System.Drawing.Point(7, 17);
            this.rbBaixo.Name = "rbBaixo";
            this.rbBaixo.Size = new System.Drawing.Size(71, 21);
            this.rbBaixo.TabIndex = 0;
            this.rbBaixo.TabStop = true;
            this.rbBaixo.Text = "1-Baixo";
            this.rbBaixo.UseVisualStyleBackColor = true;
            // 
            // tpOcorrencia
            // 
            this.tpOcorrencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpOcorrencia.Controls.Add(this.btnColaborador);
            this.tpOcorrencia.Controls.Add(this.btnExcluirOco);
            this.tpOcorrencia.Controls.Add(this.UsrUsuarioOco);
            this.tpOcorrencia.Controls.Add(this.btnAlterarDataHora);
            this.tpOcorrencia.Controls.Add(this.txtIdOcorrencia);
            this.tpOcorrencia.Controls.Add(this.btnSalvarOco);
            this.tpOcorrencia.Controls.Add(this.btnNovoOco);
            this.tpOcorrencia.Controls.Add(this.btnVisualizar);
            this.tpOcorrencia.Controls.Add(this.btnAnexo);
            this.tpOcorrencia.Controls.Add(this.label26);
            this.tpOcorrencia.Controls.Add(this.txtAnexo);
            this.tpOcorrencia.Controls.Add(this.label25);
            this.tpOcorrencia.Controls.Add(this.txtDescricaoSolucao);
            this.tpOcorrencia.Controls.Add(this.label24);
            this.tpOcorrencia.Controls.Add(this.txtDescricaoProblema);
            this.tpOcorrencia.Controls.Add(this.label23);
            this.tpOcorrencia.Controls.Add(this.label22);
            this.tpOcorrencia.Controls.Add(this.txtDadosClienteOco);
            this.tpOcorrencia.Controls.Add(this.txtVersao);
            this.tpOcorrencia.Controls.Add(this.txtHoraFinalOco);
            this.tpOcorrencia.Controls.Add(this.label20);
            this.tpOcorrencia.Controls.Add(this.txtHoraInicialOco);
            this.tpOcorrencia.Controls.Add(this.txtDataOco);
            this.tpOcorrencia.Controls.Add(this.label19);
            this.tpOcorrencia.Controls.Add(this.label18);
            this.tpOcorrencia.Controls.Add(this.txtDocumento);
            this.tpOcorrencia.Controls.Add(this.label17);
            this.tpOcorrencia.Controls.Add(this.dgvOcorrencia);
            this.tpOcorrencia.Location = new System.Drawing.Point(4, 26);
            this.tpOcorrencia.Name = "tpOcorrencia";
            this.tpOcorrencia.Padding = new System.Windows.Forms.Padding(3);
            this.tpOcorrencia.Size = new System.Drawing.Size(1015, 526);
            this.tpOcorrencia.TabIndex = 1;
            this.tpOcorrencia.Text = "Ocorrência";
            // 
            // btnColaborador
            // 
            this.btnColaborador.Location = new System.Drawing.Point(351, 386);
            this.btnColaborador.Name = "btnColaborador";
            this.btnColaborador.Size = new System.Drawing.Size(138, 38);
            this.btnColaborador.TabIndex = 28;
            this.btnColaborador.Text = "Colaborador";
            this.btnColaborador.UseVisualStyleBackColor = true;
            this.btnColaborador.Click += new System.EventHandler(this.btnColaborador_Click);
            // 
            // btnExcluirOco
            // 
            this.btnExcluirOco.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnExcluirOco.Location = new System.Drawing.Point(844, 430);
            this.btnExcluirOco.Name = "btnExcluirOco";
            this.btnExcluirOco.Size = new System.Drawing.Size(78, 25);
            this.btnExcluirOco.TabIndex = 13;
            this.btnExcluirOco.Text = "Excluir";
            this.btnExcluirOco.UseVisualStyleBackColor = true;
            this.btnExcluirOco.Click += new System.EventHandler(this.btnExcluirOco_Click);
            // 
            // UsrUsuarioOco
            // 
            this.UsrUsuarioOco.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrUsuarioOco.Location = new System.Drawing.Point(11, 157);
            this.UsrUsuarioOco.Modificou = false;
            this.UsrUsuarioOco.Name = "UsrUsuarioOco";
            this.UsrUsuarioOco.Size = new System.Drawing.Size(356, 45);
            this.UsrUsuarioOco.TabIndex = 27;
            // 
            // txtIdOcorrencia
            // 
            this.txtIdOcorrencia.Location = new System.Drawing.Point(455, 156);
            this.txtIdOcorrencia.Name = "txtIdOcorrencia";
            this.txtIdOcorrencia.Size = new System.Drawing.Size(34, 23);
            this.txtIdOcorrencia.TabIndex = 24;
            this.txtIdOcorrencia.Visible = false;
            // 
            // btnSalvarOco
            // 
            this.btnSalvarOco.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSalvarOco.Location = new System.Drawing.Point(928, 430);
            this.btnSalvarOco.Name = "btnSalvarOco";
            this.btnSalvarOco.Size = new System.Drawing.Size(78, 25);
            this.btnSalvarOco.TabIndex = 14;
            this.btnSalvarOco.Text = "Salvar";
            this.btnSalvarOco.UseVisualStyleBackColor = true;
            this.btnSalvarOco.Click += new System.EventHandler(this.btnSalvarOco_Click);
            // 
            // btnNovoOco
            // 
            this.btnNovoOco.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnNovoOco.Location = new System.Drawing.Point(760, 430);
            this.btnNovoOco.Name = "btnNovoOco";
            this.btnNovoOco.Size = new System.Drawing.Size(78, 25);
            this.btnNovoOco.TabIndex = 12;
            this.btnNovoOco.Text = "Novo";
            this.btnNovoOco.UseVisualStyleBackColor = true;
            this.btnNovoOco.Click += new System.EventHandler(this.btnNovoOco_Click);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(453, 430);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(33, 23);
            this.btnVisualizar.TabIndex = 23;
            this.btnVisualizar.TabStop = false;
            this.btnVisualizar.Text = "...";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnAnexo
            // 
            this.btnAnexo.Location = new System.Drawing.Point(418, 430);
            this.btnAnexo.Name = "btnAnexo";
            this.btnAnexo.Size = new System.Drawing.Size(33, 23);
            this.btnAnexo.TabIndex = 22;
            this.btnAnexo.TabStop = false;
            this.btnAnexo.Text = "...";
            this.btnAnexo.UseVisualStyleBackColor = true;
            this.btnAnexo.Click += new System.EventHandler(this.btnAnexo_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(8, 410);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(48, 17);
            this.label26.TabIndex = 21;
            this.label26.Text = "Anexo";
            // 
            // txtAnexo
            // 
            this.txtAnexo.Location = new System.Drawing.Point(11, 430);
            this.txtAnexo.MaxLength = 1000;
            this.txtAnexo.Name = "txtAnexo";
            this.txtAnexo.Size = new System.Drawing.Size(406, 23);
            this.txtAnexo.TabIndex = 11;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(493, 271);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(150, 17);
            this.label25.TabIndex = 19;
            this.label25.Text = "Descrição da Solução";
            // 
            // txtDescricaoSolucao
            // 
            this.txtDescricaoSolucao.Location = new System.Drawing.Point(496, 291);
            this.txtDescricaoSolucao.MaxLength = 2000;
            this.txtDescricaoSolucao.Multiline = true;
            this.txtDescricaoSolucao.Name = "txtDescricaoSolucao";
            this.txtDescricaoSolucao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricaoSolucao.Size = new System.Drawing.Size(510, 133);
            this.txtDescricaoSolucao.TabIndex = 10;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(493, 112);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(161, 17);
            this.label24.TabIndex = 17;
            this.label24.Text = "Descrição do Problema";
            // 
            // txtDescricaoProblema
            // 
            this.txtDescricaoProblema.Location = new System.Drawing.Point(496, 132);
            this.txtDescricaoProblema.MaxLength = 1000;
            this.txtDescricaoProblema.Multiline = true;
            this.txtDescricaoProblema.Name = "txtDescricaoProblema";
            this.txtDescricaoProblema.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricaoProblema.Size = new System.Drawing.Size(510, 136);
            this.txtDescricaoProblema.TabIndex = 9;
            this.txtDescricaoProblema.Enter += new System.EventHandler(this.txtDescricaoProblema_Enter);
            this.txtDescricaoProblema.Leave += new System.EventHandler(this.txtDescricaoProblema_Leave);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(8, 209);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(100, 17);
            this.label23.TabIndex = 15;
            this.label23.Text = "Dados Cliente";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(365, 159);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(52, 17);
            this.label22.TabIndex = 14;
            this.label22.Text = "Versão";
            // 
            // txtDadosClienteOco
            // 
            this.txtDadosClienteOco.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.txtDadosClienteOco.Location = new System.Drawing.Point(11, 229);
            this.txtDadosClienteOco.Multiline = true;
            this.txtDadosClienteOco.Name = "txtDadosClienteOco";
            this.txtDadosClienteOco.ReadOnly = true;
            this.txtDadosClienteOco.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDadosClienteOco.Size = new System.Drawing.Size(475, 151);
            this.txtDadosClienteOco.TabIndex = 8;
            this.txtDadosClienteOco.TabStop = false;
            // 
            // txtVersao
            // 
            this.txtVersao.Location = new System.Drawing.Point(368, 179);
            this.txtVersao.MaxLength = 25;
            this.txtVersao.Name = "txtVersao";
            this.txtVersao.Size = new System.Drawing.Size(122, 23);
            this.txtVersao.TabIndex = 7;
            // 
            // txtHoraFinalOco
            // 
            this.txtHoraFinalOco.Location = new System.Drawing.Point(368, 132);
            this.txtHoraFinalOco.Mask = "90:00";
            this.txtHoraFinalOco.Name = "txtHoraFinalOco";
            this.txtHoraFinalOco.Size = new System.Drawing.Size(84, 23);
            this.txtHoraFinalOco.TabIndex = 4;
            this.txtHoraFinalOco.TabStop = false;
            this.txtHoraFinalOco.ValidatingType = typeof(System.DateTime);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(368, 112);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(78, 17);
            this.label20.TabIndex = 7;
            this.label20.Text = "Hora Final*";
            // 
            // txtHoraInicialOco
            // 
            this.txtHoraInicialOco.Location = new System.Drawing.Point(279, 132);
            this.txtHoraInicialOco.Mask = "90:00";
            this.txtHoraInicialOco.Name = "txtHoraInicialOco";
            this.txtHoraInicialOco.Size = new System.Drawing.Size(83, 23);
            this.txtHoraInicialOco.TabIndex = 3;
            this.txtHoraInicialOco.TabStop = false;
            this.txtHoraInicialOco.ValidatingType = typeof(System.DateTime);
            // 
            // txtDataOco
            // 
            this.txtDataOco.ContextMenuStrip = this.contextMenuStrip1;
            this.txtDataOco.Location = new System.Drawing.Point(183, 132);
            this.txtDataOco.Name = "txtDataOco";
            this.txtDataOco.Size = new System.Drawing.Size(90, 25);
            this.txtDataOco.TabIndex = 2;
            this.txtDataOco.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(276, 112);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 17);
            this.label19.TabIndex = 4;
            this.label19.Text = "Hora Inicial*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(180, 112);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 17);
            this.label18.TabIndex = 3;
            this.label18.Text = "Data*";
            // 
            // txtDocumento
            // 
            this.txtDocumento.ContextMenuStrip = this.contextMenuStrip1;
            this.txtDocumento.Location = new System.Drawing.Point(11, 132);
            this.txtDocumento.MaxLength = 25;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(166, 23);
            this.txtDocumento.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 112);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 17);
            this.label17.TabIndex = 1;
            this.label17.Text = "Documento";
            // 
            // dgvOcorrencia
            // 
            this.dgvOcorrencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOcorrencia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Data,
            this.HoraInicio,
            this.HoraFim,
            this.Documento,
            this.NomeUsuario,
            this.UsuarioId,
            this.CodUsuario});
            this.dgvOcorrencia.Location = new System.Drawing.Point(11, 6);
            this.dgvOcorrencia.Name = "dgvOcorrencia";
            this.dgvOcorrencia.ReadOnly = true;
            this.dgvOcorrencia.Size = new System.Drawing.Size(995, 97);
            this.dgvOcorrencia.TabIndex = 0;
            this.dgvOcorrencia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOcorrencia_CellClick_1);
            this.dgvOcorrencia.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvOcorrencia_UserDeletingRow);
            this.dgvOcorrencia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvOcorrencia_KeyUp);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Data
            // 
            this.Data.DataPropertyName = "Data";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.Data.DefaultCellStyle = dataGridViewCellStyle3;
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // HoraInicio
            // 
            this.HoraInicio.DataPropertyName = "HoraInicio";
            this.HoraInicio.HeaderText = "Hora Inicial";
            this.HoraInicio.Name = "HoraInicio";
            this.HoraInicio.ReadOnly = true;
            this.HoraInicio.Width = 120;
            // 
            // HoraFim
            // 
            this.HoraFim.DataPropertyName = "HoraFim";
            this.HoraFim.HeaderText = "Hora Final";
            this.HoraFim.Name = "HoraFim";
            this.HoraFim.ReadOnly = true;
            this.HoraFim.Width = 120;
            // 
            // Documento
            // 
            this.Documento.DataPropertyName = "Documento";
            this.Documento.HeaderText = "Documento";
            this.Documento.Name = "Documento";
            this.Documento.ReadOnly = true;
            this.Documento.Width = 200;
            // 
            // NomeUsuario
            // 
            this.NomeUsuario.DataPropertyName = "NomeUsuario";
            this.NomeUsuario.HeaderText = "Usuário";
            this.NomeUsuario.Name = "NomeUsuario";
            this.NomeUsuario.ReadOnly = true;
            this.NomeUsuario.Width = 380;
            // 
            // UsuarioId
            // 
            this.UsuarioId.DataPropertyName = "UsuarioId";
            this.UsuarioId.HeaderText = "UsuarioId";
            this.UsuarioId.Name = "UsuarioId";
            this.UsuarioId.ReadOnly = true;
            this.UsuarioId.Visible = false;
            // 
            // CodUsuario
            // 
            this.CodUsuario.DataPropertyName = "CodUsuario";
            this.CodUsuario.HeaderText = "CodUsuario";
            this.CodUsuario.Name = "CodUsuario";
            this.CodUsuario.ReadOnly = true;
            this.CodUsuario.Visible = false;
            // 
            // UsrModulo
            // 
            this.UsrModulo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrModulo.Location = new System.Drawing.Point(10, 204);
            this.UsrModulo.Modificou = false;
            this.UsrModulo.Name = "UsrModulo";
            this.UsrModulo.Size = new System.Drawing.Size(576, 49);
            this.UsrModulo.TabIndex = 7;
            // 
            // UsrProduto
            // 
            this.UsrProduto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrProduto.Location = new System.Drawing.Point(11, 250);
            this.UsrProduto.Modificou = false;
            this.UsrProduto.Name = "UsrProduto";
            this.UsrProduto.Size = new System.Drawing.Size(576, 49);
            this.UsrProduto.TabIndex = 8;
            // 
            // UsrTipo
            // 
            this.UsrTipo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrTipo.Location = new System.Drawing.Point(11, 299);
            this.UsrTipo.Modificou = false;
            this.UsrTipo.Name = "UsrTipo";
            this.UsrTipo.Size = new System.Drawing.Size(278, 49);
            this.UsrTipo.TabIndex = 9;
            // 
            // UsrStatus
            // 
            this.UsrStatus.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrStatus.Location = new System.Drawing.Point(295, 298);
            this.UsrStatus.Modificou = false;
            this.UsrStatus.Name = "UsrStatus";
            this.UsrStatus.Size = new System.Drawing.Size(292, 46);
            this.UsrStatus.TabIndex = 10;
            // 
            // UsrCliente
            // 
            this.UsrCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrCliente.Location = new System.Drawing.Point(11, 60);
            this.UsrCliente.Modificou = false;
            this.UsrCliente.Name = "UsrCliente";
            this.UsrCliente.Size = new System.Drawing.Size(581, 49);
            this.UsrCliente.TabIndex = 4;
            this.UsrCliente.Leave += new System.EventHandler(this.UsrCliente_Leave);
            // 
            // UsrUsuario
            // 
            this.UsrUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrUsuario.Location = new System.Drawing.Point(324, 10);
            this.UsrUsuario.Modificou = false;
            this.UsrUsuario.Name = "UsrUsuario";
            this.UsrUsuario.Size = new System.Drawing.Size(268, 49);
            this.UsrUsuario.TabIndex = 3;
            // 
            // btnEspecificao
            // 
            this.btnEspecificao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnEspecificao.Location = new System.Drawing.Point(318, 19);
            this.btnEspecificao.Name = "btnEspecificao";
            this.btnEspecificao.Size = new System.Drawing.Size(93, 40);
            this.btnEspecificao.TabIndex = 9;
            this.btnEspecificao.Text = "Especif.";
            this.btnEspecificao.UseVisualStyleBackColor = true;
            this.btnEspecificao.Click += new System.EventHandler(this.btnEspecificao_Click);
            // 
            // btnModulo
            // 
            this.btnModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnModulo.Location = new System.Drawing.Point(417, 19);
            this.btnModulo.Name = "btnModulo";
            this.btnModulo.Size = new System.Drawing.Size(93, 40);
            this.btnModulo.TabIndex = 10;
            this.btnModulo.Text = "Módulos";
            this.btnModulo.UseVisualStyleBackColor = true;
            this.btnModulo.Click += new System.EventHandler(this.btnModulo_Click);
            // 
            // btnSolucao
            // 
            this.btnSolucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSolucao.Location = new System.Drawing.Point(516, 19);
            this.btnSolucao.Name = "btnSolucao";
            this.btnSolucao.Size = new System.Drawing.Size(93, 40);
            this.btnSolucao.TabIndex = 11;
            this.btnSolucao.Text = "Soluções";
            this.btnSolucao.UseVisualStyleBackColor = true;
            this.btnSolucao.Click += new System.EventHandler(this.btnSolucao_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCliente.Location = new System.Drawing.Point(615, 19);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(93, 40);
            this.btnCliente.TabIndex = 12;
            this.btnCliente.Text = "Clientes";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnAnexo2
            // 
            this.btnAnexo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAnexo2.Location = new System.Drawing.Point(714, 19);
            this.btnAnexo2.Name = "btnAnexo2";
            this.btnAnexo2.Size = new System.Drawing.Size(93, 40);
            this.btnAnexo2.TabIndex = 13;
            this.btnAnexo2.Text = "Anexos";
            this.btnAnexo2.UseVisualStyleBackColor = true;
            this.btnAnexo2.Click += new System.EventHandler(this.btnAnexo2_Click);
            // 
            // tpStatusOcorrencia
            // 
            this.tpStatusOcorrencia.Controls.Add(this.dgvStatus);
            this.tpStatusOcorrencia.Location = new System.Drawing.Point(4, 26);
            this.tpStatusOcorrencia.Name = "tpStatusOcorrencia";
            this.tpStatusOcorrencia.Padding = new System.Windows.Forms.Padding(3);
            this.tpStatusOcorrencia.Size = new System.Drawing.Size(678, 481);
            this.tpStatusOcorrencia.TabIndex = 2;
            this.tpStatusOcorrencia.Text = "Status";
            this.tpStatusOcorrencia.UseVisualStyleBackColor = true;
            // 
            // dgvStatus
            // 
            this.dgvStatus.AllowUserToDeleteRows = false;
            this.dgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StatusData,
            this.Hora,
            this.StatusNome,
            this.UsuarioNome});
            this.dgvStatus.Location = new System.Drawing.Point(6, 6);
            this.dgvStatus.Name = "dgvStatus";
            this.dgvStatus.Size = new System.Drawing.Size(1003, 454);
            this.dgvStatus.TabIndex = 0;
            this.dgvStatus.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStatus_CellFormatting);
            // 
            // StatusData
            // 
            this.StatusData.DataPropertyName = "Data";
            this.StatusData.HeaderText = "Data";
            this.StatusData.Name = "StatusData";
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "Hora";
            dataGridViewCellStyle4.NullValue = null;
            this.Hora.DefaultCellStyle = dataGridViewCellStyle4;
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            // 
            // StatusNome
            // 
            this.StatusNome.DataPropertyName = "NomeStatus";
            this.StatusNome.HeaderText = "Status";
            this.StatusNome.Name = "StatusNome";
            this.StatusNome.Width = 250;
            // 
            // UsuarioNome
            // 
            this.UsuarioNome.DataPropertyName = "NomeUsuario";
            this.UsuarioNome.HeaderText = "Usuário";
            this.UsuarioNome.Name = "UsuarioNome";
            this.UsuarioNome.Width = 450;
            // 
            // frmChamado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 596);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmChamado";
            this.Tag = "6";
            this.Text = "Chamados";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChamado_KeyDown);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tpPesquisa.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpEditar.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tbPrincipal.ResumeLayout(false);
            this.tbPrincipal.PerformLayout();
            this.tpFiltro.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tpFiltroPrincipal.ResumeLayout(false);
            this.tpFiltroPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tpUsuario.ResumeLayout(false);
            this.tpModulo.ResumeLayout(false);
            this.tpTipo.ResumeLayout(false);
            this.tpStatus.ResumeLayout(false);
            this.grNivel.ResumeLayout(false);
            this.grNivel.PerformLayout();
            this.tpOcorrencia.ResumeLayout(false);
            this.tpOcorrencia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcorrencia)).EndInit();
            this.tpStatusOcorrencia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Label label5;
        private Componentes.usrSoNumero txtCodigo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDadosCliente;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Componentes.usrData txtDataAbertura;
        private System.Windows.Forms.ToolTip toolTip1;
        private Componentes.usrData txtDataFinal;
        private System.Windows.Forms.Label label14;
        private Componentes.usrData txtDataInicial;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tpUsuario;
        private Filtros.ursFiltroPadrao ursFiltroUsuario;
        private System.Windows.Forms.TabPage tpModulo;
        private Filtros.ursFiltroPadrao ursFiltroModulo;
        private System.Windows.Forms.TabPage tpTipo;
        private Filtros.ursFiltroPadrao ursFiltroTipo;
        private System.Windows.Forms.TabPage tpStatus;
        private Filtros.ursFiltroPadrao ursFiltroStatus;
        private System.Windows.Forms.Button btnDetalhes;
        private System.Windows.Forms.Button btnDetalhes2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cha_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cha_DataAbertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cha_HoraAbertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cha_Nivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_Fantasia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tip_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sta_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usu_Nome;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MaskedTextBox txtHoraAbertura;
        private System.Windows.Forms.GroupBox grNivel;
        private System.Windows.Forms.RadioButton rbCritico;
        private System.Windows.Forms.RadioButton rbAlto;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbBaixo;
        private System.Windows.Forms.TabPage tpOcorrencia;
        private System.Windows.Forms.DataGridView dgvOcorrencia;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtDescricaoSolucao;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtDescricaoProblema;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtDadosClienteOco;
        private System.Windows.Forms.TextBox txtVersao;
        private System.Windows.Forms.MaskedTextBox txtHoraFinalOco;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.MaskedTextBox txtHoraInicialOco;
        private Componentes.usrData txtDataOco;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Button btnAnexo;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtAnexo;
        private System.Windows.Forms.Button btnSalvarOco;
        private System.Windows.Forms.Button btnNovoOco;
        private System.Windows.Forms.TextBox txtIdOcorrencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraFim;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodUsuario;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem liberarDataEHoraToolStripMenuItem;
        private System.Windows.Forms.Button btnAlterarDataHora;
        private Componentes.usrPesquisa UsrModulo;
        private Componentes.usrPesquisa UsrProduto;
        private Componentes.usrPesquisa UsrTipo;
        private Componentes.usrPesquisa UsrStatus;
        private Componentes.usrPesquisa UsrCliente;
        private Componentes.usrPesquisa UsrUsuario;
        private Componentes.usrPesquisa UsrUsuarioOco;
        private System.Windows.Forms.Button btnExcluirOco;
        private System.Windows.Forms.Button btnAnexo2;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnSolucao;
        private System.Windows.Forms.Button btnModulo;
        private System.Windows.Forms.Button btnEspecificao;
        private System.Windows.Forms.Button btnColaborador;
        private System.Windows.Forms.TabPage tpStatusOcorrencia;
        private System.Windows.Forms.DataGridView dgvStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioNome;
    }
}