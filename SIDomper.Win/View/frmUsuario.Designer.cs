namespace SIDomper.Win.View
{
    partial class frmUsuario
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
            this.Usu_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usu_Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usu_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usu_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new SIDomper.Win.Componentes.usrSoNumero();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.tpPermissao = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.btnRetornaTodos = new System.Windows.Forms.Button();
            this.btnRetorna1 = new System.Windows.Forms.Button();
            this.btnPassaTodos = new System.Windows.Forms.Button();
            this.btnPassa1 = new System.Windows.Forms.Button();
            this.dgvPermissao = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sigla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.lstPermissao = new System.Windows.Forms.ListBox();
            this.tpFiltroRevenda = new System.Windows.Forms.TabPage();
            this.usrRevendaFiltro = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.tpFiltroDepartamento = new System.Windows.Forms.TabPage();
            this.usrDepartamentoFiltro = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.tpFiltroCliente = new System.Windows.Forms.TabPage();
            this.usrClienteFiltro = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.UsrDepartamento = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrContaEmail = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrRevenda = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrCliente = new SIDomper.Win.Componentes.usrPesquisa();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
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
            this.tpPermissao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissao)).BeginInit();
            this.tpFiltroRevenda.SuspendLayout();
            this.tpFiltroDepartamento.SuspendLayout();
            this.tpFiltroCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(775, 567);
            // 
            // tpPesquisa
            // 
            this.tpPesquisa.Controls.Add(this.dgvDados);
            this.tpPesquisa.Size = new System.Drawing.Size(767, 537);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.dgvDados, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(4, 470);
            this.groupBox2.Size = new System.Drawing.Size(759, 63);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(759, 60);
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
            this.tpEditar.Size = new System.Drawing.Size(767, 537);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(4, 470);
            this.groupBox3.Size = new System.Drawing.Size(759, 63);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tpPermissao);
            this.tabControl2.Size = new System.Drawing.Size(759, 529);
            this.tabControl2.Controls.SetChildIndex(this.tpPermissao, 0);
            this.tabControl2.Controls.SetChildIndex(this.tbPrincipal, 0);
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.Controls.Add(this.txtTelefone);
            this.tbPrincipal.Controls.Add(this.label8);
            this.tbPrincipal.Controls.Add(this.UsrCliente);
            this.tbPrincipal.Controls.Add(this.UsrRevenda);
            this.tbPrincipal.Controls.Add(this.UsrContaEmail);
            this.tbPrincipal.Controls.Add(this.UsrDepartamento);
            this.tbPrincipal.Controls.Add(this.chkAtivo);
            this.tbPrincipal.Controls.Add(this.chkAdmin);
            this.tbPrincipal.Controls.Add(this.label7);
            this.tbPrincipal.Controls.Add(this.txtEmail);
            this.tbPrincipal.Controls.Add(this.label6);
            this.tbPrincipal.Controls.Add(this.txtSenha);
            this.tbPrincipal.Controls.Add(this.label5);
            this.tbPrincipal.Controls.Add(this.txtUsuario);
            this.tbPrincipal.Controls.Add(this.label4);
            this.tbPrincipal.Controls.Add(this.txtNome);
            this.tbPrincipal.Controls.Add(this.label3);
            this.tbPrincipal.Controls.Add(this.txtCodigo);
            this.tbPrincipal.Size = new System.Drawing.Size(751, 499);
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tpFiltroRevenda);
            this.tabControl3.Controls.Add(this.tpFiltroDepartamento);
            this.tabControl3.Controls.Add(this.tpFiltroCliente);
            this.tabControl3.Click += new System.EventHandler(this.tabControl3_Click);
            this.tabControl3.Controls.SetChildIndex(this.tpFiltroCliente, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpFiltroDepartamento, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpFiltroRevenda, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpFiltroPrincipal, 0);
            // 
            // tpFiltroPrincipal
            // 
            this.tpFiltroPrincipal.Size = new System.Drawing.Size(751, 538);
            // 
            // cboAtivo
            // 
            this.cboAtivo.Size = new System.Drawing.Size(121, 25);
            // 
            // cbPesquisa
            // 
            this.cbPesquisa.Size = new System.Drawing.Size(133, 25);
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Usu_Id,
            this.Usu_Codigo,
            this.Usu_Nome,
            this.Usu_Email});
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(4, 64);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(759, 406);
            this.dgvDados.TabIndex = 1;
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_ColumnHeaderMouseClick);
            // 
            // Usu_Id
            // 
            this.Usu_Id.DataPropertyName = "Id";
            this.Usu_Id.HeaderText = "Id";
            this.Usu_Id.Name = "Usu_Id";
            this.Usu_Id.Visible = false;
            // 
            // Usu_Codigo
            // 
            this.Usu_Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.Format = "0000";
            this.Usu_Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Usu_Codigo.HeaderText = "Código";
            this.Usu_Codigo.Name = "Usu_Codigo";
            this.Usu_Codigo.Width = 80;
            // 
            // Usu_Nome
            // 
            this.Usu_Nome.DataPropertyName = "Nome";
            this.Usu_Nome.HeaderText = "Nome";
            this.Usu_Nome.Name = "Usu_Nome";
            this.Usu_Nome.Width = 300;
            // 
            // Usu_Email
            // 
            this.Usu_Email.DataPropertyName = "Email";
            this.Usu_Email.HeaderText = "Email";
            this.Usu_Email.Name = "Usu_Email";
            this.Usu_Email.Width = 300;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nome*";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(19, 77);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(549, 23);
            this.txtNome.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(19, 31);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(81, 25);
            this.txtCodigo.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Usuário*";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(19, 126);
            this.txtUsuario.MaxLength = 50;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(182, 23);
            this.txtUsuario.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Senha*";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(207, 126);
            this.txtSenha.MaxLength = 50;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(162, 23);
            this.txtSenha.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Email*";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(19, 177);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(549, 23);
            this.txtEmail.TabIndex = 5;
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.Location = new System.Drawing.Point(17, 416);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(117, 21);
            this.chkAdmin.TabIndex = 10;
            this.chkAdmin.Text = "Administrador";
            this.chkAdmin.UseVisualStyleBackColor = true;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.Location = new System.Drawing.Point(140, 416);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(61, 21);
            this.chkAtivo.TabIndex = 11;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // tpPermissao
            // 
            this.tpPermissao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpPermissao.Controls.Add(this.label13);
            this.tpPermissao.Controls.Add(this.btnRetornaTodos);
            this.tpPermissao.Controls.Add(this.btnRetorna1);
            this.tpPermissao.Controls.Add(this.btnPassaTodos);
            this.tpPermissao.Controls.Add(this.btnPassa1);
            this.tpPermissao.Controls.Add(this.dgvPermissao);
            this.tpPermissao.Controls.Add(this.label12);
            this.tpPermissao.Controls.Add(this.lstPermissao);
            this.tpPermissao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpPermissao.Location = new System.Drawing.Point(4, 26);
            this.tpPermissao.Name = "tpPermissao";
            this.tpPermissao.Padding = new System.Windows.Forms.Padding(3);
            this.tpPermissao.Size = new System.Drawing.Size(751, 499);
            this.tpPermissao.TabIndex = 1;
            this.tpPermissao.Text = "Permissões";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(445, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(151, 16);
            this.label13.TabIndex = 7;
            this.label13.Text = "Permissões do Usuário";
            // 
            // btnRetornaTodos
            // 
            this.btnRetornaTodos.Location = new System.Drawing.Point(313, 193);
            this.btnRetornaTodos.Name = "btnRetornaTodos";
            this.btnRetornaTodos.Size = new System.Drawing.Size(45, 23);
            this.btnRetornaTodos.TabIndex = 6;
            this.btnRetornaTodos.Text = "<<";
            this.btnRetornaTodos.UseVisualStyleBackColor = true;
            this.btnRetornaTodos.Click += new System.EventHandler(this.btnRetornaTodos_Click);
            // 
            // btnRetorna1
            // 
            this.btnRetorna1.Location = new System.Drawing.Point(313, 164);
            this.btnRetorna1.Name = "btnRetorna1";
            this.btnRetorna1.Size = new System.Drawing.Size(45, 23);
            this.btnRetorna1.TabIndex = 5;
            this.btnRetorna1.Text = "<";
            this.btnRetorna1.UseVisualStyleBackColor = true;
            this.btnRetorna1.Click += new System.EventHandler(this.btnRetorna1_Click);
            // 
            // btnPassaTodos
            // 
            this.btnPassaTodos.Location = new System.Drawing.Point(313, 115);
            this.btnPassaTodos.Name = "btnPassaTodos";
            this.btnPassaTodos.Size = new System.Drawing.Size(45, 23);
            this.btnPassaTodos.TabIndex = 4;
            this.btnPassaTodos.Text = ">>";
            this.btnPassaTodos.UseVisualStyleBackColor = true;
            this.btnPassaTodos.Click += new System.EventHandler(this.btnPassaTodos_Click);
            // 
            // btnPassa1
            // 
            this.btnPassa1.Location = new System.Drawing.Point(313, 86);
            this.btnPassa1.Name = "btnPassa1";
            this.btnPassa1.Size = new System.Drawing.Size(45, 23);
            this.btnPassa1.TabIndex = 3;
            this.btnPassa1.Text = ">";
            this.btnPassa1.UseVisualStyleBackColor = true;
            this.btnPassa1.Click += new System.EventHandler(this.btnPassa1_Click);
            // 
            // dgvPermissao
            // 
            this.dgvPermissao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermissao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Sigla});
            this.dgvPermissao.Location = new System.Drawing.Point(373, 48);
            this.dgvPermissao.Name = "dgvPermissao";
            this.dgvPermissao.Size = new System.Drawing.Size(372, 327);
            this.dgvPermissao.TabIndex = 2;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Sigla
            // 
            this.Sigla.DataPropertyName = "Sigla";
            this.Sigla.HeaderText = "Opções";
            this.Sigla.Name = "Sigla";
            this.Sigla.Width = 300;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(58, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 16);
            this.label12.TabIndex = 1;
            this.label12.Text = "Permissões Disponíveis";
            // 
            // lstPermissao
            // 
            this.lstPermissao.FormattingEnabled = true;
            this.lstPermissao.ItemHeight = 17;
            this.lstPermissao.Location = new System.Drawing.Point(7, 48);
            this.lstPermissao.Name = "lstPermissao";
            this.lstPermissao.Size = new System.Drawing.Size(300, 327);
            this.lstPermissao.TabIndex = 0;
            // 
            // tpFiltroRevenda
            // 
            this.tpFiltroRevenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpFiltroRevenda.Controls.Add(this.usrRevendaFiltro);
            this.tpFiltroRevenda.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpFiltroRevenda.Location = new System.Drawing.Point(4, 26);
            this.tpFiltroRevenda.Name = "tpFiltroRevenda";
            this.tpFiltroRevenda.Padding = new System.Windows.Forms.Padding(3);
            this.tpFiltroRevenda.Size = new System.Drawing.Size(751, 538);
            this.tpFiltroRevenda.TabIndex = 1;
            this.tpFiltroRevenda.Text = "Revenda";
            // 
            // usrRevendaFiltro
            // 
            this.usrRevendaFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.usrRevendaFiltro.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.usrRevendaFiltro.Location = new System.Drawing.Point(7, 6);
            this.usrRevendaFiltro.Name = "usrRevendaFiltro";
            this.usrRevendaFiltro.Size = new System.Drawing.Size(738, 479);
            this.usrRevendaFiltro.TabIndex = 0;
            // 
            // tpFiltroDepartamento
            // 
            this.tpFiltroDepartamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpFiltroDepartamento.Controls.Add(this.usrDepartamentoFiltro);
            this.tpFiltroDepartamento.Location = new System.Drawing.Point(4, 26);
            this.tpFiltroDepartamento.Name = "tpFiltroDepartamento";
            this.tpFiltroDepartamento.Padding = new System.Windows.Forms.Padding(3);
            this.tpFiltroDepartamento.Size = new System.Drawing.Size(751, 538);
            this.tpFiltroDepartamento.TabIndex = 2;
            this.tpFiltroDepartamento.Text = "Departamento";
            // 
            // usrDepartamentoFiltro
            // 
            this.usrDepartamentoFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.usrDepartamentoFiltro.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.usrDepartamentoFiltro.Location = new System.Drawing.Point(7, 6);
            this.usrDepartamentoFiltro.Name = "usrDepartamentoFiltro";
            this.usrDepartamentoFiltro.Size = new System.Drawing.Size(738, 479);
            this.usrDepartamentoFiltro.TabIndex = 0;
            // 
            // tpFiltroCliente
            // 
            this.tpFiltroCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpFiltroCliente.Controls.Add(this.usrClienteFiltro);
            this.tpFiltroCliente.Location = new System.Drawing.Point(4, 26);
            this.tpFiltroCliente.Name = "tpFiltroCliente";
            this.tpFiltroCliente.Padding = new System.Windows.Forms.Padding(3);
            this.tpFiltroCliente.Size = new System.Drawing.Size(751, 538);
            this.tpFiltroCliente.TabIndex = 3;
            this.tpFiltroCliente.Text = "Cliente";
            // 
            // usrClienteFiltro
            // 
            this.usrClienteFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.usrClienteFiltro.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.usrClienteFiltro.Location = new System.Drawing.Point(7, 6);
            this.usrClienteFiltro.Name = "usrClienteFiltro";
            this.usrClienteFiltro.Size = new System.Drawing.Size(738, 479);
            this.usrClienteFiltro.TabIndex = 0;
            // 
            // UsrDepartamento
            // 
            this.UsrDepartamento.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrDepartamento.Location = new System.Drawing.Point(19, 204);
            this.UsrDepartamento.Modificou = false;
            this.UsrDepartamento.Name = "UsrDepartamento";
            this.UsrDepartamento.Size = new System.Drawing.Size(554, 49);
            this.UsrDepartamento.TabIndex = 6;
            // 
            // UsrContaEmail
            // 
            this.UsrContaEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrContaEmail.Location = new System.Drawing.Point(19, 253);
            this.UsrContaEmail.Modificou = false;
            this.UsrContaEmail.Name = "UsrContaEmail";
            this.UsrContaEmail.Size = new System.Drawing.Size(554, 49);
            this.UsrContaEmail.TabIndex = 7;
            // 
            // UsrRevenda
            // 
            this.UsrRevenda.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrRevenda.Location = new System.Drawing.Point(19, 306);
            this.UsrRevenda.Modificou = false;
            this.UsrRevenda.Name = "UsrRevenda";
            this.UsrRevenda.Size = new System.Drawing.Size(554, 49);
            this.UsrRevenda.TabIndex = 8;
            // 
            // UsrCliente
            // 
            this.UsrCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrCliente.Location = new System.Drawing.Point(19, 361);
            this.UsrCliente.Modificou = false;
            this.UsrCliente.Name = "UsrCliente";
            this.UsrCliente.Size = new System.Drawing.Size(554, 49);
            this.UsrCliente.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(375, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Telefone";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(378, 127);
            this.txtTelefone.MaxLength = 20;
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(190, 23);
            this.txtTelefone.TabIndex = 4;
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 567);
            this.Name = "frmUsuario";
            this.Tag = "104";
            this.Text = "Usuários";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsuario_KeyDown);
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
            this.tpPermissao.ResumeLayout(false);
            this.tpPermissao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissao)).EndInit();
            this.tpFiltroRevenda.ResumeLayout(false);
            this.tpFiltroDepartamento.ResumeLayout(false);
            this.tpFiltroCliente.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usu_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usu_Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usu_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usu_Email;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private Componentes.usrSoNumero txtCodigo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.TabPage tpPermissao;
        private System.Windows.Forms.Button btnPassaTodos;
        private System.Windows.Forms.Button btnPassa1;
        private System.Windows.Forms.DataGridView dgvPermissao;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox lstPermissao;
        private System.Windows.Forms.Button btnRetornaTodos;
        private System.Windows.Forms.Button btnRetorna1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tpFiltroRevenda;
        private Filtros.ursFiltroPadrao usrDepartamentoFiltro;
        public System.Windows.Forms.TabPage tpFiltroDepartamento;
        private Filtros.ursFiltroPadrao usrRevendaFiltro;
        private System.Windows.Forms.TabPage tpFiltroCliente;
        private Filtros.ursFiltroPadrao usrClienteFiltro;
        private Componentes.usrPesquisa UsrDepartamento;
        private Componentes.usrPesquisa UsrContaEmail;
        private Componentes.usrPesquisa UsrRevenda;
        private Componentes.usrPesquisa UsrCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sigla;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label label8;
    }
}