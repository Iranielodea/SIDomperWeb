namespace SIDomper.Win.View
{
    partial class frmBaseConhecimento
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
            this.Bas_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bas_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bas_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usu_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tip_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sta_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigo = new SIDomper.Win.Componentes.usrSoNumero();
            this.txtData = new SIDomper.Win.Componentes.usrData();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtAnexo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAnexar = new System.Windows.Forms.Button();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.UsrUsuario = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrModulo = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrProduto = new SIDomper.Win.Componentes.usrPesquisa();
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
            this.tpUsuario.SuspendLayout();
            this.tpModulo.SuspendLayout();
            this.tpTipo.SuspendLayout();
            this.tpStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(1038, 538);
            // 
            // tpPesquisa
            // 
            this.tpPesquisa.Controls.Add(this.dgvDados);
            this.tpPesquisa.Margin = new System.Windows.Forms.Padding(5);
            this.tpPesquisa.Padding = new System.Windows.Forms.Padding(5);
            this.tpPesquisa.Size = new System.Drawing.Size(1030, 508);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.dgvDados, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDetalhes2);
            this.groupBox2.Location = new System.Drawing.Point(5, 440);
            this.groupBox2.Size = new System.Drawing.Size(1020, 63);
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
            this.groupBox1.Size = new System.Drawing.Size(1020, 60);
            this.groupBox1.TabIndex = 0;
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(427, 31);
            this.txtTexto.Margin = new System.Windows.Forms.Padding(5);
            this.txtTexto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTexto_KeyDown);
            // 
            // cbCampos
            // 
            this.cbCampos.Size = new System.Drawing.Size(271, 25);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(424, 12);
            // 
            // tpEditar
            // 
            this.tpEditar.Margin = new System.Windows.Forms.Padding(5);
            this.tpEditar.Padding = new System.Windows.Forms.Padding(5);
            this.tpEditar.Size = new System.Drawing.Size(1030, 508);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDetalhes);
            this.groupBox3.Location = new System.Drawing.Point(5, 440);
            this.groupBox3.Size = new System.Drawing.Size(1020, 63);
            this.groupBox3.Controls.SetChildIndex(this.btnSalvar, 0);
            this.groupBox3.Controls.SetChildIndex(this.btnVoltar2, 0);
            this.groupBox3.Controls.SetChildIndex(this.btnDetalhes, 0);
            // 
            // btnVoltar2
            // 
            this.btnVoltar2.Location = new System.Drawing.Point(118, 19);
            this.btnVoltar2.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(15, 18);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(5);
            // 
            // tabControl2
            // 
            this.tabControl2.Location = new System.Drawing.Point(5, 5);
            this.tabControl2.Size = new System.Drawing.Size(1020, 498);
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.Controls.Add(this.UsrStatus);
            this.tbPrincipal.Controls.Add(this.UsrTipo);
            this.tbPrincipal.Controls.Add(this.UsrProduto);
            this.tbPrincipal.Controls.Add(this.UsrModulo);
            this.tbPrincipal.Controls.Add(this.UsrUsuario);
            this.tbPrincipal.Controls.Add(this.txtDescricao);
            this.tbPrincipal.Controls.Add(this.label12);
            this.tbPrincipal.Controls.Add(this.btnVisualizar);
            this.tbPrincipal.Controls.Add(this.btnAnexar);
            this.tbPrincipal.Controls.Add(this.label11);
            this.tbPrincipal.Controls.Add(this.txtAnexo);
            this.tbPrincipal.Controls.Add(this.txtNome);
            this.tbPrincipal.Controls.Add(this.label4);
            this.tbPrincipal.Controls.Add(this.label3);
            this.tbPrincipal.Controls.Add(this.txtData);
            this.tbPrincipal.Controls.Add(this.label5);
            this.tbPrincipal.Controls.Add(this.txtCodigo);
            this.tbPrincipal.Size = new System.Drawing.Size(1012, 468);
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
            this.tpFiltroPrincipal.Size = new System.Drawing.Size(1012, 468);
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
            // 
            // lblAtivo
            // 
            this.lblAtivo.Location = new System.Drawing.Point(186, 25);
            // 
            // lblPesquisa
            // 
            this.lblPesquisa.Location = new System.Drawing.Point(286, 9);
            // 
            // cbPesquisa
            // 
            this.cbPesquisa.Location = new System.Drawing.Point(289, 29);
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bas_Id,
            this.Bas_Data,
            this.Bas_Nome,
            this.Usu_Nome,
            this.Tip_Nome,
            this.Sta_Nome});
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(5, 65);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(1020, 375);
            this.dgvDados.TabIndex = 1;
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_ColumnHeaderMouseClick);
            // 
            // Bas_Id
            // 
            this.Bas_Id.DataPropertyName = "Id";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "000000";
            this.Bas_Id.DefaultCellStyle = dataGridViewCellStyle1;
            this.Bas_Id.HeaderText = "Id";
            this.Bas_Id.Name = "Bas_Id";
            this.Bas_Id.Width = 80;
            // 
            // Bas_Data
            // 
            this.Bas_Data.DataPropertyName = "Data";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.Bas_Data.DefaultCellStyle = dataGridViewCellStyle2;
            this.Bas_Data.HeaderText = "Data";
            this.Bas_Data.Name = "Bas_Data";
            // 
            // Bas_Nome
            // 
            this.Bas_Nome.DataPropertyName = "Nome";
            this.Bas_Nome.HeaderText = "Nome";
            this.Bas_Nome.Name = "Bas_Nome";
            this.Bas_Nome.Width = 200;
            // 
            // Usu_Nome
            // 
            this.Usu_Nome.DataPropertyName = "NomeUsuario";
            this.Usu_Nome.HeaderText = "Usuário";
            this.Usu_Nome.Name = "Usu_Nome";
            this.Usu_Nome.Width = 200;
            // 
            // Tip_Nome
            // 
            this.Tip_Nome.DataPropertyName = "NomeTipo";
            this.Tip_Nome.HeaderText = "Tipo";
            this.Tip_Nome.Name = "Tip_Nome";
            this.Tip_Nome.Width = 200;
            // 
            // Sta_Nome
            // 
            this.Sta_Nome.DataPropertyName = "NomeStatus";
            this.Sta_Nome.HeaderText = "Status";
            this.Sta_Nome.Name = "Sta_Nome";
            this.Sta_Nome.Width = 200;
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
            this.txtCodigo.Location = new System.Drawing.Point(11, 31);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(92, 29);
            this.txtCodigo.TabIndex = 0;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(115, 32);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(92, 25);
            this.txtData.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Data*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nome*";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(11, 78);
            this.txtNome.MaxLength = 200;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(542, 23);
            this.txtNome.TabIndex = 2;
            // 
            // txtAnexo
            // 
            this.txtAnexo.Location = new System.Drawing.Point(11, 374);
            this.txtAnexo.MaxLength = 200;
            this.txtAnexo.Name = "txtAnexo";
            this.txtAnexo.Size = new System.Drawing.Size(503, 23);
            this.txtAnexo.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 354);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 17);
            this.label11.TabIndex = 34;
            this.label11.Text = "Anexo";
            // 
            // btnAnexar
            // 
            this.btnAnexar.Location = new System.Drawing.Point(519, 374);
            this.btnAnexar.Name = "btnAnexar";
            this.btnAnexar.Size = new System.Drawing.Size(33, 23);
            this.btnAnexar.TabIndex = 35;
            this.btnAnexar.TabStop = false;
            this.btnAnexar.Text = "...";
            this.toolTip1.SetToolTip(this.btnAnexar, "Anexar Arquivo");
            this.btnAnexar.UseVisualStyleBackColor = true;
            this.btnAnexar.Click += new System.EventHandler(this.btnAnexar_Click);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(558, 374);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(33, 23);
            this.btnVisualizar.TabIndex = 36;
            this.btnVisualizar.TabStop = false;
            this.btnVisualizar.Text = "...";
            this.toolTip1.SetToolTip(this.btnVisualizar, "Visualizar Arquivo");
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
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
            this.txtDescricao.Location = new System.Drawing.Point(598, 34);
            this.txtDescricao.MaxLength = 2000;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricao.Size = new System.Drawing.Size(407, 363);
            this.txtDescricao.TabIndex = 14;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescricao_KeyDown);
            this.txtDescricao.Leave += new System.EventHandler(this.txtDescricao_Leave);
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
            this.tpUsuario.Size = new System.Drawing.Size(1012, 468);
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
            this.tpModulo.Size = new System.Drawing.Size(1012, 468);
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
            this.tpTipo.Size = new System.Drawing.Size(1012, 468);
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
            this.tpStatus.Size = new System.Drawing.Size(1012, 468);
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
            // UsrUsuario
            // 
            this.UsrUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrUsuario.Location = new System.Drawing.Point(11, 102);
            this.UsrUsuario.Modificou = false;
            this.UsrUsuario.Name = "UsrUsuario";
            this.UsrUsuario.Size = new System.Drawing.Size(545, 49);
            this.UsrUsuario.TabIndex = 3;
            // 
            // UsrModulo
            // 
            this.UsrModulo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrModulo.Location = new System.Drawing.Point(11, 150);
            this.UsrModulo.Modificou = false;
            this.UsrModulo.Name = "UsrModulo";
            this.UsrModulo.Size = new System.Drawing.Size(545, 49);
            this.UsrModulo.TabIndex = 4;
            // 
            // UsrProduto
            // 
            this.UsrProduto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrProduto.Location = new System.Drawing.Point(11, 200);
            this.UsrProduto.Modificou = false;
            this.UsrProduto.Name = "UsrProduto";
            this.UsrProduto.Size = new System.Drawing.Size(546, 49);
            this.UsrProduto.TabIndex = 5;
            // 
            // UsrTipo
            // 
            this.UsrTipo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrTipo.Location = new System.Drawing.Point(11, 250);
            this.UsrTipo.Modificou = false;
            this.UsrTipo.Name = "UsrTipo";
            this.UsrTipo.Size = new System.Drawing.Size(546, 49);
            this.UsrTipo.TabIndex = 6;
            // 
            // UsrStatus
            // 
            this.UsrStatus.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrStatus.Location = new System.Drawing.Point(11, 302);
            this.UsrStatus.Modificou = false;
            this.UsrStatus.Name = "UsrStatus";
            this.UsrStatus.Size = new System.Drawing.Size(546, 49);
            this.UsrStatus.TabIndex = 7;
            // 
            // frmBaseConhecimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 538);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmBaseConhecimento";
            this.Tag = "6";
            this.Text = "Base de Conhecimento";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBaseConhecimento_KeyDown);
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
            this.tpModulo.ResumeLayout(false);
            this.tpTipo.ResumeLayout(false);
            this.tpStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bas_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bas_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bas_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usu_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tip_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sta_Nome;
        private System.Windows.Forms.Label label5;
        private Componentes.usrSoNumero txtCodigo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Button btnAnexar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAnexo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Componentes.usrData txtData;
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
        private Componentes.usrPesquisa UsrUsuario;
        private Componentes.usrPesquisa UsrModulo;
        private Componentes.usrPesquisa UsrProduto;
        private Componentes.usrPesquisa UsrTipo;
        private Componentes.usrPesquisa UsrStatus;
    }
}