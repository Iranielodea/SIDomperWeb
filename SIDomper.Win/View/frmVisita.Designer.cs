namespace SIDomper.Win.View
{
    partial class frmVisita
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
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.Vis_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vis_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vis_Dcto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cli_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cli_Fantasia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usu_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enviarEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDocto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigo = new SIDomper.Win.Componentes.usrSoNumero();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.txtData = new SIDomper.Win.Componentes.usrData();
            this.txtHoraInicial = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHoraFinal = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtVersao = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtFormaPagto = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtAnexo = new System.Windows.Forms.TextBox();
            this.btnAnexar = new System.Windows.Forms.Button();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtValor = new SIDomper.Win.Componentes.usrValor();
            this.txtDataInicial = new SIDomper.Win.Componentes.usrData();
            this.txtDataFinal = new SIDomper.Win.Componentes.usrData();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtIdFiltro = new SIDomper.Win.Componentes.usrSoNumero();
            this.txtPerfil = new System.Windows.Forms.TextBox();
            this.tpCliente = new System.Windows.Forms.TabPage();
            this.ursFiltroCliente = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.tpConsultor = new System.Windows.Forms.TabPage();
            this.ursFiltroUsuario = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.tpTipo = new System.Windows.Forms.TabPage();
            this.ursFiltroTipo = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.tpStatus = new System.Windows.Forms.TabPage();
            this.ursFiltroStatus = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.tpRevenda = new System.Windows.Forms.TabPage();
            this.ursFiltroRevenda = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.tpCidade = new System.Windows.Forms.TabPage();
            this.ursFiltroCidade = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.UsrUsuario = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrCliente = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrTipo = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrStatus = new SIDomper.Win.Componentes.usrPesquisa();
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
            this.tpCliente.SuspendLayout();
            this.tpConsultor.SuspendLayout();
            this.tpTipo.SuspendLayout();
            this.tpStatus.SuspendLayout();
            this.tpRevenda.SuspendLayout();
            this.tpCidade.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(946, 581);
            this.tabControl1.Tag = "2";
            // 
            // tpPesquisa
            // 
            this.tpPesquisa.Controls.Add(this.dgvDados);
            this.tpPesquisa.Size = new System.Drawing.Size(938, 551);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.dgvDados, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(4, 484);
            this.groupBox2.Size = new System.Drawing.Size(930, 63);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(930, 60);
            this.groupBox1.TabIndex = 0;
            // 
            // txtTexto
            // 
            this.txtTexto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTexto_KeyDown);
            // 
            // cbCampos
            // 
            this.cbCampos.Location = new System.Drawing.Point(11, 30);
            this.cbCampos.Size = new System.Drawing.Size(218, 25);
            // 
            // tpEditar
            // 
            this.tpEditar.Size = new System.Drawing.Size(938, 551);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(4, 484);
            this.groupBox3.Size = new System.Drawing.Size(930, 63);
            // 
            // tabControl2
            // 
            this.tabControl2.Size = new System.Drawing.Size(930, 543);
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.Controls.Add(this.UsrStatus);
            this.tbPrincipal.Controls.Add(this.UsrTipo);
            this.tbPrincipal.Controls.Add(this.UsrCliente);
            this.tbPrincipal.Controls.Add(this.UsrUsuario);
            this.tbPrincipal.Controls.Add(this.txtValor);
            this.tbPrincipal.Controls.Add(this.label17);
            this.tbPrincipal.Controls.Add(this.btnVisualizar);
            this.tbPrincipal.Controls.Add(this.btnAnexar);
            this.tbPrincipal.Controls.Add(this.txtAnexo);
            this.tbPrincipal.Controls.Add(this.txtFormaPagto);
            this.tbPrincipal.Controls.Add(this.label16);
            this.tbPrincipal.Controls.Add(this.label15);
            this.tbPrincipal.Controls.Add(this.txtDescricao);
            this.tbPrincipal.Controls.Add(this.label14);
            this.tbPrincipal.Controls.Add(this.label13);
            this.tbPrincipal.Controls.Add(this.txtVersao);
            this.tbPrincipal.Controls.Add(this.label8);
            this.tbPrincipal.Controls.Add(this.txtHoraFinal);
            this.tbPrincipal.Controls.Add(this.label7);
            this.tbPrincipal.Controls.Add(this.label6);
            this.tbPrincipal.Controls.Add(this.txtHoraInicial);
            this.tbPrincipal.Controls.Add(this.txtData);
            this.tbPrincipal.Controls.Add(this.label3);
            this.tbPrincipal.Controls.Add(this.txtContato);
            this.tbPrincipal.Controls.Add(this.label4);
            this.tbPrincipal.Controls.Add(this.txtDocto);
            this.tbPrincipal.Controls.Add(this.label5);
            this.tbPrincipal.Controls.Add(this.txtCodigo);
            this.tbPrincipal.Size = new System.Drawing.Size(922, 513);
            // 
            // tpFiltro
            // 
            this.tpFiltro.Size = new System.Drawing.Size(938, 551);
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(4, 484);
            this.groupBox4.Size = new System.Drawing.Size(930, 63);
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tpCliente);
            this.tabControl3.Controls.Add(this.tpConsultor);
            this.tabControl3.Controls.Add(this.tpTipo);
            this.tabControl3.Controls.Add(this.tpStatus);
            this.tabControl3.Controls.Add(this.tpRevenda);
            this.tabControl3.Controls.Add(this.tpCidade);
            this.tabControl3.Size = new System.Drawing.Size(930, 543);
            this.tabControl3.Click += new System.EventHandler(this.tabControl3_Click);
            this.tabControl3.Controls.SetChildIndex(this.tpCidade, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpRevenda, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpStatus, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpTipo, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpConsultor, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpCliente, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpFiltroPrincipal, 0);
            // 
            // tpFiltroPrincipal
            // 
            this.tpFiltroPrincipal.Controls.Add(this.txtPerfil);
            this.tpFiltroPrincipal.Controls.Add(this.txtIdFiltro);
            this.tpFiltroPrincipal.Controls.Add(this.label21);
            this.tpFiltroPrincipal.Controls.Add(this.label20);
            this.tpFiltroPrincipal.Controls.Add(this.label19);
            this.tpFiltroPrincipal.Controls.Add(this.label18);
            this.tpFiltroPrincipal.Controls.Add(this.txtDataFinal);
            this.tpFiltroPrincipal.Controls.Add(this.txtDataInicial);
            this.tpFiltroPrincipal.Size = new System.Drawing.Size(922, 513);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.lblAtivo, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.cboAtivo, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.txtDataInicial, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.txtDataFinal, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.label18, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.label19, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.label20, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.label21, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.txtIdFiltro, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.txtPerfil, 0);
            // 
            // cboAtivo
            // 
            this.cboAtivo.Location = new System.Drawing.Point(368, 35);
            this.cboAtivo.Visible = false;
            // 
            // lblAtivo
            // 
            this.lblAtivo.Location = new System.Drawing.Point(365, 15);
            this.lblAtivo.Visible = false;
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Vis_Id,
            this.Vis_Data,
            this.Vis_Dcto,
            this.Cli_Nome,
            this.Cli_Fantasia,
            this.Usu_Nome});
            this.dgvDados.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(4, 64);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(930, 420);
            this.dgvDados.TabIndex = 1;
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_ColumnHeaderMouseClick);
            // 
            // Vis_Id
            // 
            this.Vis_Id.DataPropertyName = "Id";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "000000";
            this.Vis_Id.DefaultCellStyle = dataGridViewCellStyle1;
            this.Vis_Id.HeaderText = "Id";
            this.Vis_Id.Name = "Vis_Id";
            this.Vis_Id.Width = 80;
            // 
            // Vis_Data
            // 
            this.Vis_Data.DataPropertyName = "Data";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Vis_Data.DefaultCellStyle = dataGridViewCellStyle2;
            this.Vis_Data.HeaderText = "Data";
            this.Vis_Data.Name = "Vis_Data";
            // 
            // Vis_Dcto
            // 
            this.Vis_Dcto.DataPropertyName = "Documento";
            this.Vis_Dcto.HeaderText = "Documento";
            this.Vis_Dcto.Name = "Vis_Dcto";
            // 
            // Cli_Nome
            // 
            this.Cli_Nome.DataPropertyName = "NomeCliente";
            this.Cli_Nome.HeaderText = "Cliente";
            this.Cli_Nome.Name = "Cli_Nome";
            this.Cli_Nome.Width = 200;
            // 
            // Cli_Fantasia
            // 
            this.Cli_Fantasia.DataPropertyName = "NomeFantasia";
            this.Cli_Fantasia.HeaderText = "Fantasia";
            this.Cli_Fantasia.Name = "Cli_Fantasia";
            this.Cli_Fantasia.Width = 150;
            // 
            // Usu_Nome
            // 
            this.Usu_Nome.DataPropertyName = "NomeConsultor";
            this.Usu_Nome.HeaderText = "Consultor";
            this.Usu_Nome.Name = "Usu_Nome";
            this.Usu_Nome.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarEmailToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 26);
            // 
            // enviarEmailToolStripMenuItem
            // 
            this.enviarEmailToolStripMenuItem.Name = "enviarEmailToolStripMenuItem";
            this.enviarEmailToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.enviarEmailToolStripMenuItem.Text = "Enviar Email";
            this.enviarEmailToolStripMenuItem.Click += new System.EventHandler(this.enviarEmailToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Documento";
            // 
            // txtDocto
            // 
            this.txtDocto.Location = new System.Drawing.Point(19, 79);
            this.txtDocto.MaxLength = 25;
            this.txtDocto.Name = "txtDocto";
            this.txtDocto.Size = new System.Drawing.Size(182, 23);
            this.txtDocto.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "ID";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(19, 30);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(9);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(83, 24);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Contato";
            // 
            // txtContato
            // 
            this.txtContato.Location = new System.Drawing.Point(20, 267);
            this.txtContato.MaxLength = 100;
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(340, 23);
            this.txtContato.TabIndex = 9;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(108, 30);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(93, 25);
            this.txtData.TabIndex = 1;
            // 
            // txtHoraInicial
            // 
            this.txtHoraInicial.Location = new System.Drawing.Point(207, 30);
            this.txtHoraInicial.Mask = "90:00";
            this.txtHoraInicial.Name = "txtHoraInicial";
            this.txtHoraInicial.Size = new System.Drawing.Size(83, 23);
            this.txtHoraInicial.TabIndex = 2;
            this.txtHoraInicial.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(105, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Data*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Hora Inicial*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(293, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Hora Final*";
            // 
            // txtHoraFinal
            // 
            this.txtHoraFinal.Location = new System.Drawing.Point(296, 30);
            this.txtHoraFinal.Mask = "90:00";
            this.txtHoraFinal.Name = "txtHoraFinal";
            this.txtHoraFinal.Size = new System.Drawing.Size(83, 23);
            this.txtHoraFinal.TabIndex = 3;
            this.txtHoraFinal.ValidatingType = typeof(System.DateTime);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(375, 248);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 17);
            this.label13.TabIndex = 39;
            this.label13.Text = "Versão";
            // 
            // txtVersao
            // 
            this.txtVersao.Location = new System.Drawing.Point(378, 267);
            this.txtVersao.MaxLength = 25;
            this.txtVersao.Name = "txtVersao";
            this.txtVersao.Size = new System.Drawing.Size(84, 23);
            this.txtVersao.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 290);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 17);
            this.label14.TabIndex = 40;
            this.label14.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(20, 310);
            this.txtDescricao.MaxLength = 2000;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(411, 129);
            this.txtDescricao.TabIndex = 11;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescricao_KeyDown);
            this.txtDescricao.Leave += new System.EventHandler(this.txtDescricao_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(470, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 17);
            this.label15.TabIndex = 43;
            this.label15.Text = "Valor";
            // 
            // txtFormaPagto
            // 
            this.txtFormaPagto.Location = new System.Drawing.Point(473, 91);
            this.txtFormaPagto.MaxLength = 500;
            this.txtFormaPagto.Multiline = true;
            this.txtFormaPagto.Name = "txtFormaPagto";
            this.txtFormaPagto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFormaPagto.Size = new System.Drawing.Size(436, 298);
            this.txtFormaPagto.TabIndex = 13;
            this.txtFormaPagto.Enter += new System.EventHandler(this.txtFormaPagto_Enter);
            this.txtFormaPagto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFormaPagto_KeyDown);
            this.txtFormaPagto.Leave += new System.EventHandler(this.txtFormaPagto_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(470, 71);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(152, 17);
            this.label16.TabIndex = 44;
            this.label16.Text = "Forma de Pagamento";
            // 
            // txtAnexo
            // 
            this.txtAnexo.Location = new System.Drawing.Point(473, 416);
            this.txtAnexo.MaxLength = 200;
            this.txtAnexo.Name = "txtAnexo";
            this.txtAnexo.Size = new System.Drawing.Size(371, 23);
            this.txtAnexo.TabIndex = 14;
            // 
            // btnAnexar
            // 
            this.btnAnexar.Location = new System.Drawing.Point(850, 416);
            this.btnAnexar.Name = "btnAnexar";
            this.btnAnexar.Size = new System.Drawing.Size(29, 23);
            this.btnAnexar.TabIndex = 51;
            this.btnAnexar.TabStop = false;
            this.btnAnexar.Text = "...";
            this.btnAnexar.UseVisualStyleBackColor = true;
            this.btnAnexar.Click += new System.EventHandler(this.btnAnexar_Click);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(880, 416);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(29, 23);
            this.btnVisualizar.TabIndex = 52;
            this.btnVisualizar.TabStop = false;
            this.btnVisualizar.Text = "...";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(470, 396);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 17);
            this.label17.TabIndex = 53;
            this.label17.Text = "Anexo";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(473, 29);
            this.txtValor.Margin = new System.Windows.Forms.Padding(7);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(123, 23);
            this.txtValor.TabIndex = 12;
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.Location = new System.Drawing.Point(20, 35);
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.Size = new System.Drawing.Size(94, 25);
            this.txtDataInicial.TabIndex = 2;
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Location = new System.Drawing.Point(20, 86);
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(94, 25);
            this.txtDataFinal.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 17);
            this.label18.TabIndex = 4;
            this.label18.Text = "Data Inicial";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 63);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 17);
            this.label19.TabIndex = 5;
            this.label19.Text = "Data Final";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(137, 15);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 17);
            this.label20.TabIndex = 6;
            this.label20.Text = "ID";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(137, 63);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(38, 17);
            this.label21.TabIndex = 7;
            this.label21.Text = "Perfil";
            // 
            // txtIdFiltro
            // 
            this.txtIdFiltro.Location = new System.Drawing.Point(140, 35);
            this.txtIdFiltro.Name = "txtIdFiltro";
            this.txtIdFiltro.Size = new System.Drawing.Size(100, 25);
            this.txtIdFiltro.TabIndex = 8;
            // 
            // txtPerfil
            // 
            this.txtPerfil.Location = new System.Drawing.Point(140, 86);
            this.txtPerfil.Name = "txtPerfil";
            this.txtPerfil.Size = new System.Drawing.Size(100, 23);
            this.txtPerfil.TabIndex = 9;
            // 
            // tpCliente
            // 
            this.tpCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpCliente.Controls.Add(this.ursFiltroCliente);
            this.tpCliente.Location = new System.Drawing.Point(4, 26);
            this.tpCliente.Name = "tpCliente";
            this.tpCliente.Padding = new System.Windows.Forms.Padding(3);
            this.tpCliente.Size = new System.Drawing.Size(922, 513);
            this.tpCliente.TabIndex = 1;
            this.tpCliente.Text = "Cliente";
            // 
            // ursFiltroCliente
            // 
            this.ursFiltroCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroCliente.Location = new System.Drawing.Point(6, 6);
            this.ursFiltroCliente.Name = "ursFiltroCliente";
            this.ursFiltroCliente.Size = new System.Drawing.Size(910, 445);
            this.ursFiltroCliente.TabIndex = 0;
            // 
            // tpConsultor
            // 
            this.tpConsultor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpConsultor.Controls.Add(this.ursFiltroUsuario);
            this.tpConsultor.Location = new System.Drawing.Point(4, 26);
            this.tpConsultor.Name = "tpConsultor";
            this.tpConsultor.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsultor.Size = new System.Drawing.Size(922, 513);
            this.tpConsultor.TabIndex = 2;
            this.tpConsultor.Text = "Consultor";
            // 
            // ursFiltroUsuario
            // 
            this.ursFiltroUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroUsuario.Location = new System.Drawing.Point(6, 6);
            this.ursFiltroUsuario.Name = "ursFiltroUsuario";
            this.ursFiltroUsuario.Size = new System.Drawing.Size(909, 445);
            this.ursFiltroUsuario.TabIndex = 0;
            // 
            // tpTipo
            // 
            this.tpTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpTipo.Controls.Add(this.ursFiltroTipo);
            this.tpTipo.Location = new System.Drawing.Point(4, 26);
            this.tpTipo.Name = "tpTipo";
            this.tpTipo.Padding = new System.Windows.Forms.Padding(3);
            this.tpTipo.Size = new System.Drawing.Size(922, 513);
            this.tpTipo.TabIndex = 3;
            this.tpTipo.Text = "Tipo";
            // 
            // ursFiltroTipo
            // 
            this.ursFiltroTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroTipo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroTipo.Location = new System.Drawing.Point(6, 6);
            this.ursFiltroTipo.Name = "ursFiltroTipo";
            this.ursFiltroTipo.Size = new System.Drawing.Size(910, 499);
            this.ursFiltroTipo.TabIndex = 0;
            // 
            // tpStatus
            // 
            this.tpStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpStatus.Controls.Add(this.ursFiltroStatus);
            this.tpStatus.Location = new System.Drawing.Point(4, 26);
            this.tpStatus.Name = "tpStatus";
            this.tpStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tpStatus.Size = new System.Drawing.Size(922, 513);
            this.tpStatus.TabIndex = 4;
            this.tpStatus.Text = "Status";
            // 
            // ursFiltroStatus
            // 
            this.ursFiltroStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroStatus.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroStatus.Location = new System.Drawing.Point(6, 6);
            this.ursFiltroStatus.Name = "ursFiltroStatus";
            this.ursFiltroStatus.Size = new System.Drawing.Size(910, 445);
            this.ursFiltroStatus.TabIndex = 0;
            // 
            // tpRevenda
            // 
            this.tpRevenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpRevenda.Controls.Add(this.ursFiltroRevenda);
            this.tpRevenda.Location = new System.Drawing.Point(4, 26);
            this.tpRevenda.Name = "tpRevenda";
            this.tpRevenda.Padding = new System.Windows.Forms.Padding(3);
            this.tpRevenda.Size = new System.Drawing.Size(922, 513);
            this.tpRevenda.TabIndex = 5;
            this.tpRevenda.Text = "Revenda";
            // 
            // ursFiltroRevenda
            // 
            this.ursFiltroRevenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroRevenda.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroRevenda.Location = new System.Drawing.Point(6, 6);
            this.ursFiltroRevenda.Name = "ursFiltroRevenda";
            this.ursFiltroRevenda.Size = new System.Drawing.Size(910, 499);
            this.ursFiltroRevenda.TabIndex = 0;
            // 
            // tpCidade
            // 
            this.tpCidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpCidade.Controls.Add(this.ursFiltroCidade);
            this.tpCidade.Location = new System.Drawing.Point(4, 26);
            this.tpCidade.Name = "tpCidade";
            this.tpCidade.Padding = new System.Windows.Forms.Padding(3);
            this.tpCidade.Size = new System.Drawing.Size(922, 513);
            this.tpCidade.TabIndex = 6;
            this.tpCidade.Text = "Cidade";
            // 
            // ursFiltroCidade
            // 
            this.ursFiltroCidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroCidade.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroCidade.Location = new System.Drawing.Point(7, 6);
            this.ursFiltroCidade.Name = "ursFiltroCidade";
            this.ursFiltroCidade.Size = new System.Drawing.Size(909, 499);
            this.ursFiltroCidade.TabIndex = 0;
            // 
            // UsrUsuario
            // 
            this.UsrUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrUsuario.Location = new System.Drawing.Point(207, 57);
            this.UsrUsuario.Modificou = false;
            this.UsrUsuario.Name = "UsrUsuario";
            this.UsrUsuario.Size = new System.Drawing.Size(259, 49);
            this.UsrUsuario.TabIndex = 5;
            // 
            // UsrCliente
            // 
            this.UsrCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrCliente.Location = new System.Drawing.Point(20, 108);
            this.UsrCliente.Modificou = false;
            this.UsrCliente.Name = "UsrCliente";
            this.UsrCliente.Size = new System.Drawing.Size(447, 49);
            this.UsrCliente.TabIndex = 6;
            this.UsrCliente.Leave += new System.EventHandler(this.UsrCliente_Leave);
            // 
            // UsrTipo
            // 
            this.UsrTipo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrTipo.Location = new System.Drawing.Point(20, 154);
            this.UsrTipo.Modificou = false;
            this.UsrTipo.Name = "UsrTipo";
            this.UsrTipo.Size = new System.Drawing.Size(447, 49);
            this.UsrTipo.TabIndex = 7;
            // 
            // UsrStatus
            // 
            this.UsrStatus.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrStatus.Location = new System.Drawing.Point(19, 199);
            this.UsrStatus.Modificou = false;
            this.UsrStatus.Name = "UsrStatus";
            this.UsrStatus.Size = new System.Drawing.Size(447, 49);
            this.UsrStatus.TabIndex = 8;
            // 
            // frmVisita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 581);
            this.Name = "frmVisita";
            this.Tag = "121";
            this.Text = "Visitas";
            this.Shown += new System.EventHandler(this.frmVisita_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVisita_KeyDown);
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
            this.tpCliente.ResumeLayout(false);
            this.tpConsultor.ResumeLayout(false);
            this.tpTipo.ResumeLayout(false);
            this.tpStatus.ResumeLayout(false);
            this.tpRevenda.ResumeLayout(false);
            this.tpCidade.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDocto;
        private System.Windows.Forms.Label label5;
        private Componentes.usrSoNumero txtCodigo;
        private System.Windows.Forms.TextBox txtFormaPagto;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtVersao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox txtHoraFinal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtHoraInicial;
        private Componentes.usrData txtData;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Button btnAnexar;
        private System.Windows.Forms.TextBox txtAnexo;
        private System.Windows.Forms.Label label17;
        private Componentes.usrValor txtValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vis_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vis_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vis_Dcto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_Fantasia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usu_Nome;
        private System.Windows.Forms.TextBox txtPerfil;
        private Componentes.usrSoNumero txtIdFiltro;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private Componentes.usrData txtDataFinal;
        private Componentes.usrData txtDataInicial;
        private System.Windows.Forms.TabPage tpCliente;
        private Filtros.ursFiltroPadrao ursFiltroCliente;
        private System.Windows.Forms.TabPage tpConsultor;
        private System.Windows.Forms.TabPage tpTipo;
        private System.Windows.Forms.TabPage tpStatus;
        private System.Windows.Forms.TabPage tpRevenda;
        private System.Windows.Forms.TabPage tpCidade;
        private Filtros.ursFiltroPadrao ursFiltroUsuario;
        private Filtros.ursFiltroPadrao ursFiltroTipo;
        private Filtros.ursFiltroPadrao ursFiltroStatus;
        private Filtros.ursFiltroPadrao ursFiltroRevenda;
        private Filtros.ursFiltroPadrao ursFiltroCidade;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem enviarEmailToolStripMenuItem;
        private Componentes.usrPesquisa UsrUsuario;
        private Componentes.usrPesquisa UsrCliente;
        private Componentes.usrPesquisa UsrTipo;
        private Componentes.usrPesquisa UsrStatus;
    }
}