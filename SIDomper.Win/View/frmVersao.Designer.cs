namespace SIDomper.Win.View
{
    partial class frmVersao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.Ver_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ver_DataInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ver_DataLiberacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ver_Versao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ver_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tip_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sta_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usu_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new SIDomper.Win.Componentes.usrSoNumero();
            this.txtDataInicio = new SIDomper.Win.Componentes.usrData();
            this.txtDataLib = new SIDomper.Win.Componentes.usrData();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtVersao = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tpUsuario = new System.Windows.Forms.TabPage();
            this.ursFiltroUsuario = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.tpTipo = new System.Windows.Forms.TabPage();
            this.ursFiltroTipo = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.tpStatus = new System.Windows.Forms.TabPage();
            this.ursFiltroStatus = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.tpProduto = new System.Windows.Forms.TabPage();
            this.ursFiltroProduto = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.txtDataInicialFiltro = new SIDomper.Win.Componentes.usrData();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDataFinalFiltro = new SIDomper.Win.Componentes.usrData();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDataLibInicialFiltro = new SIDomper.Win.Componentes.usrData();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDataFinalLibFiltro = new SIDomper.Win.Componentes.usrData();
            this.UsrUsuario = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrTipo = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrStatus = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrProduto = new SIDomper.Win.Componentes.usrPesquisa();
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
            this.tpUsuario.SuspendLayout();
            this.tpTipo.SuspendLayout();
            this.tpStatus.SuspendLayout();
            this.tpProduto.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(1067, 588);
            // 
            // tpPesquisa
            // 
            this.tpPesquisa.Controls.Add(this.dgvDados);
            this.tpPesquisa.Margin = new System.Windows.Forms.Padding(5);
            this.tpPesquisa.Padding = new System.Windows.Forms.Padding(5);
            this.tpPesquisa.Size = new System.Drawing.Size(1059, 558);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.dgvDados, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(5, 490);
            this.groupBox2.Size = new System.Drawing.Size(1049, 63);
            // 
            // btnFiltro
            // 
            this.btnFiltro.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnSair
            // 
            this.btnSair.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnEditar
            // 
            this.btnEditar.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnNovo
            // 
            this.btnNovo.Margin = new System.Windows.Forms.Padding(5);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Size = new System.Drawing.Size(1049, 60);
            this.groupBox1.TabIndex = 0;
            // 
            // txtTexto
            // 
            this.txtTexto.Margin = new System.Windows.Forms.Padding(5);
            this.txtTexto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTexto_KeyDown);
            // 
            // cbCampos
            // 
            this.cbCampos.Location = new System.Drawing.Point(11, 30);
            this.cbCampos.Size = new System.Drawing.Size(218, 25);
            // 
            // tpEditar
            // 
            this.tpEditar.Margin = new System.Windows.Forms.Padding(5);
            this.tpEditar.Padding = new System.Windows.Forms.Padding(5);
            this.tpEditar.Size = new System.Drawing.Size(1059, 558);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(5, 490);
            this.groupBox3.Size = new System.Drawing.Size(1049, 63);
            // 
            // btnVoltar2
            // 
            this.btnVoltar2.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(5);
            // 
            // tabControl2
            // 
            this.tabControl2.Location = new System.Drawing.Point(5, 5);
            this.tabControl2.Size = new System.Drawing.Size(1049, 548);
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.Controls.Add(this.UsrProduto);
            this.tbPrincipal.Controls.Add(this.UsrStatus);
            this.tbPrincipal.Controls.Add(this.UsrTipo);
            this.tbPrincipal.Controls.Add(this.UsrUsuario);
            this.tbPrincipal.Controls.Add(this.label11);
            this.tbPrincipal.Controls.Add(this.txtVersao);
            this.tbPrincipal.Controls.Add(this.txtDescricao);
            this.tbPrincipal.Controls.Add(this.label10);
            this.tbPrincipal.Controls.Add(this.label5);
            this.tbPrincipal.Controls.Add(this.label4);
            this.tbPrincipal.Controls.Add(this.txtDataLib);
            this.tbPrincipal.Controls.Add(this.txtDataInicio);
            this.tbPrincipal.Controls.Add(this.label3);
            this.tbPrincipal.Controls.Add(this.txtCodigo);
            this.tbPrincipal.Size = new System.Drawing.Size(1041, 518);
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
            this.tabControl3.Controls.Add(this.tpTipo);
            this.tabControl3.Controls.Add(this.tpStatus);
            this.tabControl3.Controls.Add(this.tpProduto);
            this.tabControl3.Location = new System.Drawing.Point(5, 5);
            this.tabControl3.Size = new System.Drawing.Size(686, 511);
            this.tabControl3.Click += new System.EventHandler(this.tabControl3_Click);
            this.tabControl3.Controls.SetChildIndex(this.tpProduto, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpStatus, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpTipo, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpUsuario, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpFiltroPrincipal, 0);
            // 
            // tpFiltroPrincipal
            // 
            this.tpFiltroPrincipal.Controls.Add(this.label15);
            this.tpFiltroPrincipal.Controls.Add(this.txtDataFinalLibFiltro);
            this.tpFiltroPrincipal.Controls.Add(this.label14);
            this.tpFiltroPrincipal.Controls.Add(this.txtDataLibInicialFiltro);
            this.tpFiltroPrincipal.Controls.Add(this.label13);
            this.tpFiltroPrincipal.Controls.Add(this.txtDataFinalFiltro);
            this.tpFiltroPrincipal.Controls.Add(this.label12);
            this.tpFiltroPrincipal.Controls.Add(this.txtDataInicialFiltro);
            this.tpFiltroPrincipal.Size = new System.Drawing.Size(1041, 518);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.lblAtivo, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.cboAtivo, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.txtDataInicialFiltro, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.label12, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.txtDataFinalFiltro, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.label13, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.txtDataLibInicialFiltro, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.label14, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.txtDataFinalLibFiltro, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.label15, 0);
            // 
            // cboAtivo
            // 
            this.cboAtivo.Location = new System.Drawing.Point(390, 47);
            this.cboAtivo.Size = new System.Drawing.Size(121, 25);
            this.cboAtivo.Visible = false;
            // 
            // lblAtivo
            // 
            this.lblAtivo.Location = new System.Drawing.Point(387, 27);
            this.lblAtivo.Visible = false;
            // 
            // cbPesquisa
            // 
            this.cbPesquisa.Size = new System.Drawing.Size(133, 25);
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ver_Id,
            this.Ver_DataInicio,
            this.Ver_DataLiberacao,
            this.Ver_Versao,
            this.Ver_Descricao,
            this.Tip_Nome,
            this.Sta_Nome,
            this.Usu_Nome});
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(5, 65);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(1049, 425);
            this.dgvDados.TabIndex = 1;
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_ColumnHeaderMouseClick);
            // 
            // Ver_Id
            // 
            this.Ver_Id.DataPropertyName = "Id";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "000000";
            this.Ver_Id.DefaultCellStyle = dataGridViewCellStyle1;
            this.Ver_Id.HeaderText = "Id";
            this.Ver_Id.Name = "Ver_Id";
            this.Ver_Id.Width = 80;
            // 
            // Ver_DataInicio
            // 
            this.Ver_DataInicio.DataPropertyName = "DataInicio";
            this.Ver_DataInicio.HeaderText = "Data Início";
            this.Ver_DataInicio.Name = "Ver_DataInicio";
            // 
            // Ver_DataLiberacao
            // 
            this.Ver_DataLiberacao.DataPropertyName = "DataLiberacao";
            this.Ver_DataLiberacao.HeaderText = "Data Liberação";
            this.Ver_DataLiberacao.Name = "Ver_DataLiberacao";
            // 
            // Ver_Versao
            // 
            this.Ver_Versao.DataPropertyName = "VersaoStr";
            this.Ver_Versao.HeaderText = "Versão";
            this.Ver_Versao.Name = "Ver_Versao";
            this.Ver_Versao.Width = 80;
            // 
            // Ver_Descricao
            // 
            this.Ver_Descricao.DataPropertyName = "Descricao";
            this.Ver_Descricao.HeaderText = "Descrição";
            this.Ver_Descricao.Name = "Ver_Descricao";
            this.Ver_Descricao.Width = 300;
            // 
            // Tip_Nome
            // 
            this.Tip_Nome.DataPropertyName = "NomeTipo";
            this.Tip_Nome.HeaderText = "Tipo";
            this.Tip_Nome.Name = "Tip_Nome";
            this.Tip_Nome.Width = 90;
            // 
            // Sta_Nome
            // 
            this.Sta_Nome.DataPropertyName = "NomeStatus";
            this.Sta_Nome.HeaderText = "Status";
            this.Sta_Nome.Name = "Sta_Nome";
            // 
            // Usu_Nome
            // 
            this.Usu_Nome.DataPropertyName = "NomeUsuario";
            this.Usu_Nome.HeaderText = "Usuário";
            this.Usu_Nome.Name = "Usu_Nome";
            this.Usu_Nome.Width = 200;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "ID";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(11, 30);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(79, 25);
            this.txtCodigo.TabIndex = 0;
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.Location = new System.Drawing.Point(98, 30);
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.Size = new System.Drawing.Size(109, 25);
            this.txtDataInicio.TabIndex = 1;
            // 
            // txtDataLib
            // 
            this.txtDataLib.Location = new System.Drawing.Point(213, 30);
            this.txtDataLib.Name = "txtDataLib";
            this.txtDataLib.Size = new System.Drawing.Size(116, 25);
            this.txtDataLib.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Data Início*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Data Liberação*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 260);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 17);
            this.label10.TabIndex = 34;
            this.label10.Text = "Descrição*";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(8, 280);
            this.txtDescricao.MaxLength = 100;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricao.Size = new System.Drawing.Size(1023, 172);
            this.txtDescricao.TabIndex = 8;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescricao_KeyDown);
            this.txtDescricao.Leave += new System.EventHandler(this.txtDescricao_Leave);
            // 
            // txtVersao
            // 
            this.txtVersao.Location = new System.Drawing.Point(536, 229);
            this.txtVersao.MaxLength = 25;
            this.txtVersao.Name = "txtVersao";
            this.txtVersao.Size = new System.Drawing.Size(118, 23);
            this.txtVersao.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(533, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 17);
            this.label11.TabIndex = 37;
            this.label11.Text = "Versão";
            // 
            // tpUsuario
            // 
            this.tpUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpUsuario.Controls.Add(this.ursFiltroUsuario);
            this.tpUsuario.Location = new System.Drawing.Point(4, 26);
            this.tpUsuario.Name = "tpUsuario";
            this.tpUsuario.Padding = new System.Windows.Forms.Padding(3);
            this.tpUsuario.Size = new System.Drawing.Size(1041, 518);
            this.tpUsuario.TabIndex = 1;
            this.tpUsuario.Text = "Usuário";
            // 
            // ursFiltroUsuario
            // 
            this.ursFiltroUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroUsuario.Location = new System.Drawing.Point(11, 6);
            this.ursFiltroUsuario.Name = "ursFiltroUsuario";
            this.ursFiltroUsuario.Size = new System.Drawing.Size(1031, 446);
            this.ursFiltroUsuario.TabIndex = 0;
            // 
            // tpTipo
            // 
            this.tpTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpTipo.Controls.Add(this.ursFiltroTipo);
            this.tpTipo.Location = new System.Drawing.Point(4, 26);
            this.tpTipo.Name = "tpTipo";
            this.tpTipo.Padding = new System.Windows.Forms.Padding(3);
            this.tpTipo.Size = new System.Drawing.Size(1041, 518);
            this.tpTipo.TabIndex = 2;
            this.tpTipo.Text = "Tipo";
            // 
            // ursFiltroTipo
            // 
            this.ursFiltroTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroTipo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroTipo.Location = new System.Drawing.Point(11, 6);
            this.ursFiltroTipo.Name = "ursFiltroTipo";
            this.ursFiltroTipo.Size = new System.Drawing.Size(1024, 446);
            this.ursFiltroTipo.TabIndex = 0;
            // 
            // tpStatus
            // 
            this.tpStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpStatus.Controls.Add(this.ursFiltroStatus);
            this.tpStatus.Location = new System.Drawing.Point(4, 26);
            this.tpStatus.Name = "tpStatus";
            this.tpStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tpStatus.Size = new System.Drawing.Size(1041, 518);
            this.tpStatus.TabIndex = 3;
            this.tpStatus.Text = "Status";
            // 
            // ursFiltroStatus
            // 
            this.ursFiltroStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroStatus.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroStatus.Location = new System.Drawing.Point(11, 6);
            this.ursFiltroStatus.Name = "ursFiltroStatus";
            this.ursFiltroStatus.Size = new System.Drawing.Size(1024, 446);
            this.ursFiltroStatus.TabIndex = 0;
            // 
            // tpProduto
            // 
            this.tpProduto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpProduto.Controls.Add(this.ursFiltroProduto);
            this.tpProduto.Location = new System.Drawing.Point(4, 26);
            this.tpProduto.Name = "tpProduto";
            this.tpProduto.Padding = new System.Windows.Forms.Padding(3);
            this.tpProduto.Size = new System.Drawing.Size(1041, 518);
            this.tpProduto.TabIndex = 4;
            this.tpProduto.Text = "Produto";
            // 
            // ursFiltroProduto
            // 
            this.ursFiltroProduto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroProduto.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroProduto.Location = new System.Drawing.Point(11, 6);
            this.ursFiltroProduto.Name = "ursFiltroProduto";
            this.ursFiltroProduto.Size = new System.Drawing.Size(1024, 446);
            this.ursFiltroProduto.TabIndex = 0;
            // 
            // txtDataInicialFiltro
            // 
            this.txtDataInicialFiltro.Location = new System.Drawing.Point(24, 47);
            this.txtDataInicialFiltro.Name = "txtDataInicialFiltro";
            this.txtDataInicialFiltro.Size = new System.Drawing.Size(149, 25);
            this.txtDataInicialFiltro.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 17);
            this.label12.TabIndex = 3;
            this.label12.Text = "Data Inicial";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(177, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 17);
            this.label13.TabIndex = 5;
            this.label13.Text = "Data Final";
            // 
            // txtDataFinalFiltro
            // 
            this.txtDataFinalFiltro.Location = new System.Drawing.Point(180, 47);
            this.txtDataFinalFiltro.Name = "txtDataFinalFiltro";
            this.txtDataFinalFiltro.Size = new System.Drawing.Size(148, 25);
            this.txtDataFinalFiltro.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(151, 17);
            this.label14.TabIndex = 7;
            this.label14.Text = "Data Liberação Inicial";
            // 
            // txtDataLibInicialFiltro
            // 
            this.txtDataLibInicialFiltro.Location = new System.Drawing.Point(25, 96);
            this.txtDataLibInicialFiltro.Name = "txtDataLibInicialFiltro";
            this.txtDataLibInicialFiltro.Size = new System.Drawing.Size(148, 25);
            this.txtDataLibInicialFiltro.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(177, 76);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(143, 17);
            this.label15.TabIndex = 9;
            this.label15.Text = "Data Liberação Final";
            // 
            // txtDataFinalLibFiltro
            // 
            this.txtDataFinalLibFiltro.Location = new System.Drawing.Point(180, 96);
            this.txtDataFinalLibFiltro.Name = "txtDataFinalLibFiltro";
            this.txtDataFinalLibFiltro.Size = new System.Drawing.Size(148, 25);
            this.txtDataFinalLibFiltro.TabIndex = 8;
            // 
            // UsrUsuario
            // 
            this.UsrUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrUsuario.Location = new System.Drawing.Point(11, 59);
            this.UsrUsuario.Modificou = false;
            this.UsrUsuario.Name = "UsrUsuario";
            this.UsrUsuario.Size = new System.Drawing.Size(505, 49);
            this.UsrUsuario.TabIndex = 3;
            // 
            // UsrTipo
            // 
            this.UsrTipo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrTipo.Location = new System.Drawing.Point(11, 108);
            this.UsrTipo.Modificou = false;
            this.UsrTipo.Name = "UsrTipo";
            this.UsrTipo.Size = new System.Drawing.Size(505, 49);
            this.UsrTipo.TabIndex = 4;
            // 
            // UsrStatus
            // 
            this.UsrStatus.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrStatus.Location = new System.Drawing.Point(11, 160);
            this.UsrStatus.Modificou = false;
            this.UsrStatus.Name = "UsrStatus";
            this.UsrStatus.Size = new System.Drawing.Size(505, 49);
            this.UsrStatus.TabIndex = 5;
            // 
            // UsrProduto
            // 
            this.UsrProduto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrProduto.Location = new System.Drawing.Point(11, 208);
            this.UsrProduto.Modificou = false;
            this.UsrProduto.Name = "UsrProduto";
            this.UsrProduto.Size = new System.Drawing.Size(505, 49);
            this.UsrProduto.TabIndex = 6;
            // 
            // frmVersao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 588);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmVersao";
            this.Tag = "4";
            this.Text = "Versão";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVersao_KeyDown);
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
            this.tpUsuario.ResumeLayout(false);
            this.tpTipo.ResumeLayout(false);
            this.tpStatus.ResumeLayout(false);
            this.tpProduto.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Componentes.usrData txtDataLib;
        private Componentes.usrData txtDataInicio;
        private System.Windows.Forms.Label label3;
        private Componentes.usrSoNumero txtCodigo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtVersao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ver_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ver_DataInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ver_DataLiberacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ver_Versao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ver_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tip_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sta_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usu_Nome;
        private System.Windows.Forms.TabPage tpUsuario;
        private Filtros.ursFiltroPadrao ursFiltroUsuario;
        private System.Windows.Forms.TabPage tpTipo;
        private Filtros.ursFiltroPadrao ursFiltroTipo;
        private System.Windows.Forms.TabPage tpStatus;
        private Filtros.ursFiltroPadrao ursFiltroStatus;
        private System.Windows.Forms.TabPage tpProduto;
        private Filtros.ursFiltroPadrao ursFiltroProduto;
        private System.Windows.Forms.Label label15;
        private Componentes.usrData txtDataFinalLibFiltro;
        private System.Windows.Forms.Label label14;
        private Componentes.usrData txtDataLibInicialFiltro;
        private System.Windows.Forms.Label label13;
        private Componentes.usrData txtDataFinalFiltro;
        private System.Windows.Forms.Label label12;
        private Componentes.usrData txtDataInicialFiltro;
        private Componentes.usrPesquisa UsrUsuario;
        private Componentes.usrPesquisa UsrTipo;
        private Componentes.usrPesquisa UsrStatus;
        private Componentes.usrPesquisa UsrProduto;
    }
}