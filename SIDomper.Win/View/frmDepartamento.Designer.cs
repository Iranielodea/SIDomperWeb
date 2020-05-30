namespace SIDomper.Win.View
{
    partial class frmDepartamento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.Dep_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dep_Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dep_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpEmail = new System.Windows.Forms.TabPage();
            this.btnExcluirEmail = new System.Windows.Forms.Button();
            this.dgvEmail = new System.Windows.Forms.DataGridView();
            this.DepAc_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpHorario = new System.Windows.Forms.TabPage();
            this.txtHoraFinal = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHoraInicial = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigo = new SIDomper.Win.Componentes.usrSoNumero();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.dgvAcesso = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Programa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescPrograma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Acesso = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ProgIncluir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ProgEditar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ProgExcluir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ProgRelatorio = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tcProgramas = new System.Windows.Forms.TabControl();
            this.tpChamado = new System.Windows.Forms.TabPage();
            this.chkChaQuadro = new System.Windows.Forms.CheckBox();
            this.chkChaStatus = new System.Windows.Forms.CheckBox();
            this.chkChaOcorrencia = new System.Windows.Forms.CheckBox();
            this.chkChaAbertura = new System.Windows.Forms.CheckBox();
            this.tpAtividade = new System.Windows.Forms.TabPage();
            this.chkAtiQuadro = new System.Windows.Forms.CheckBox();
            this.chkAtiStatus = new System.Windows.Forms.CheckBox();
            this.chkAtiOcorrencia = new System.Windows.Forms.CheckBox();
            this.chkAtiAbertura = new System.Windows.Forms.CheckBox();
            this.tpSolicitacao = new System.Windows.Forms.TabPage();
            this.chkSolQuadro = new System.Windows.Forms.CheckBox();
            this.chkSolStatus = new System.Windows.Forms.CheckBox();
            this.chkSolOcorRegra = new System.Windows.Forms.CheckBox();
            this.chkSolOcorTecnica = new System.Windows.Forms.CheckBox();
            this.chkSolOcorGeral = new System.Windows.Forms.CheckBox();
            this.chkSolAnalise = new System.Windows.Forms.CheckBox();
            this.chkSolAbertura = new System.Windows.Forms.CheckBox();
            this.tpAgendamento = new System.Windows.Forms.TabPage();
            this.chkAgeQuadro = new System.Windows.Forms.CheckBox();
            this.chkAnexo = new System.Windows.Forms.CheckBox();
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
            this.tpEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).BeginInit();
            this.tpHorario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcesso)).BeginInit();
            this.tcProgramas.SuspendLayout();
            this.tpChamado.SuspendLayout();
            this.tpAtividade.SuspendLayout();
            this.tpSolicitacao.SuspendLayout();
            this.tpAgendamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(708, 536);
            // 
            // tpPesquisa
            // 
            this.tpPesquisa.Controls.Add(this.dgvDados);
            this.tpPesquisa.Size = new System.Drawing.Size(700, 506);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.dgvDados, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(4, 439);
            this.groupBox2.Size = new System.Drawing.Size(692, 63);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(692, 60);
            this.groupBox1.TabIndex = 0;
            // 
            // txtTexto
            // 
            this.txtTexto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTexto_KeyDown);
            // 
            // cbCampos
            // 
            this.cbCampos.Size = new System.Drawing.Size(218, 25);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tpEmail);
            this.tabControl2.Controls.Add(this.tpHorario);
            this.tabControl2.Controls.SetChildIndex(this.tpHorario, 0);
            this.tabControl2.Controls.SetChildIndex(this.tpEmail, 0);
            this.tabControl2.Controls.SetChildIndex(this.tbPrincipal, 0);
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.Controls.Add(this.chkAnexo);
            this.tbPrincipal.Controls.Add(this.tcProgramas);
            this.tbPrincipal.Controls.Add(this.dgvAcesso);
            this.tbPrincipal.Controls.Add(this.chkAtivo);
            this.tbPrincipal.Controls.Add(this.txtNome);
            this.tbPrincipal.Controls.Add(this.txtCodigo);
            this.tbPrincipal.Controls.Add(this.label4);
            this.tbPrincipal.Controls.Add(this.label3);
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dep_Id,
            this.Dep_Codigo,
            this.Dep_Nome});
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(4, 64);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(692, 375);
            this.dgvDados.TabIndex = 1;
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_ColumnHeaderMouseClick);
            // 
            // Dep_Id
            // 
            this.Dep_Id.DataPropertyName = "Id";
            this.Dep_Id.HeaderText = "Id";
            this.Dep_Id.Name = "Dep_Id";
            this.Dep_Id.Visible = false;
            // 
            // Dep_Codigo
            // 
            this.Dep_Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.Format = "0000";
            this.Dep_Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Dep_Codigo.HeaderText = "Código";
            this.Dep_Codigo.Name = "Dep_Codigo";
            // 
            // Dep_Nome
            // 
            this.Dep_Nome.DataPropertyName = "Nome";
            this.Dep_Nome.HeaderText = "Nome";
            this.Dep_Nome.Name = "Dep_Nome";
            this.Dep_Nome.Width = 510;
            // 
            // tpEmail
            // 
            this.tpEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpEmail.Controls.Add(this.btnExcluirEmail);
            this.tpEmail.Controls.Add(this.dgvEmail);
            this.tpEmail.Location = new System.Drawing.Point(4, 26);
            this.tpEmail.Name = "tpEmail";
            this.tpEmail.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmail.Size = new System.Drawing.Size(680, 483);
            this.tpEmail.TabIndex = 1;
            this.tpEmail.Text = "Email Supervisor";
            // 
            // btnExcluirEmail
            // 
            this.btnExcluirEmail.Location = new System.Drawing.Point(545, 365);
            this.btnExcluirEmail.Name = "btnExcluirEmail";
            this.btnExcluirEmail.Size = new System.Drawing.Size(133, 23);
            this.btnExcluirEmail.TabIndex = 5;
            this.btnExcluirEmail.Text = "Excluir Email";
            this.btnExcluirEmail.UseVisualStyleBackColor = true;
            this.btnExcluirEmail.Click += new System.EventHandler(this.btnExcluirEmail_Click);
            // 
            // dgvEmail
            // 
            this.dgvEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DepAc_Id,
            this.Email});
            this.dgvEmail.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvEmail.Location = new System.Drawing.Point(3, 3);
            this.dgvEmail.Name = "dgvEmail";
            this.dgvEmail.Size = new System.Drawing.Size(674, 346);
            this.dgvEmail.TabIndex = 4;
            this.dgvEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvEmail_KeyDown);
            // 
            // DepAc_Id
            // 
            this.DepAc_Id.DataPropertyName = "Id";
            this.DepAc_Id.HeaderText = "Id";
            this.DepAc_Id.Name = "DepAc_Id";
            this.DepAc_Id.Visible = false;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.Width = 600;
            // 
            // tpHorario
            // 
            this.tpHorario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpHorario.Controls.Add(this.txtHoraFinal);
            this.tpHorario.Controls.Add(this.label7);
            this.tpHorario.Controls.Add(this.txtHoraInicial);
            this.tpHorario.Controls.Add(this.label6);
            this.tpHorario.Controls.Add(this.label5);
            this.tpHorario.Location = new System.Drawing.Point(4, 26);
            this.tpHorario.Name = "tpHorario";
            this.tpHorario.Padding = new System.Windows.Forms.Padding(3);
            this.tpHorario.Size = new System.Drawing.Size(680, 483);
            this.tpHorario.TabIndex = 2;
            this.tpHorario.Text = "Horários";
            // 
            // txtHoraFinal
            // 
            this.txtHoraFinal.Location = new System.Drawing.Point(124, 79);
            this.txtHoraFinal.Mask = "00:00";
            this.txtHoraFinal.Name = "txtHoraFinal";
            this.txtHoraFinal.Size = new System.Drawing.Size(77, 23);
            this.txtHoraFinal.TabIndex = 3;
            this.txtHoraFinal.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(121, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Hora Inicial";
            // 
            // txtHoraInicial
            // 
            this.txtHoraInicial.Location = new System.Drawing.Point(24, 79);
            this.txtHoraInicial.Mask = "00:00";
            this.txtHoraInicial.Name = "txtHoraInicial";
            this.txtHoraInicial.Size = new System.Drawing.Size(77, 23);
            this.txtHoraInicial.TabIndex = 2;
            this.txtHoraInicial.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Hora Inicial";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(674, 37);
            this.label5.TabIndex = 0;
            this.label5.Text = "Horários para entrar no sistema SIDomper. Se deixado em branco terá acesso em qua" +
    "lquer horário.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Código*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nome*";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(7, 26);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(87, 25);
            this.txtCodigo.TabIndex = 0;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(101, 27);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(460, 23);
            this.txtNome.TabIndex = 1;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(577, 31);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(61, 21);
            this.chkAtivo.TabIndex = 2;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // dgvAcesso
            // 
            this.dgvAcesso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAcesso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Programa,
            this.DescPrograma,
            this.Acesso,
            this.ProgIncluir,
            this.ProgEditar,
            this.ProgExcluir,
            this.ProgRelatorio});
            this.dgvAcesso.Location = new System.Drawing.Point(7, 58);
            this.dgvAcesso.Name = "dgvAcesso";
            this.dgvAcesso.Size = new System.Drawing.Size(670, 224);
            this.dgvAcesso.TabIndex = 3;
            this.dgvAcesso.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAcesso_CellClick);
            this.dgvAcesso.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAcesso_ColumnHeaderMouseClick);
            this.dgvAcesso.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvAcesso_KeyUp);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Programa
            // 
            this.Programa.DataPropertyName = "Programa";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "0000";
            this.Programa.DefaultCellStyle = dataGridViewCellStyle2;
            this.Programa.HeaderText = "Programa";
            this.Programa.Name = "Programa";
            this.Programa.ReadOnly = true;
            this.Programa.Width = 80;
            // 
            // DescPrograma
            // 
            this.DescPrograma.DataPropertyName = "DescPrograma";
            this.DescPrograma.HeaderText = "Descrição";
            this.DescPrograma.Name = "DescPrograma";
            this.DescPrograma.ReadOnly = true;
            this.DescPrograma.Width = 200;
            // 
            // Acesso
            // 
            this.Acesso.DataPropertyName = "Acesso";
            this.Acesso.HeaderText = "Acesso";
            this.Acesso.Name = "Acesso";
            this.Acesso.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Acesso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Acesso.Width = 60;
            // 
            // ProgIncluir
            // 
            this.ProgIncluir.DataPropertyName = "ProgIncluir";
            this.ProgIncluir.HeaderText = "Incluir";
            this.ProgIncluir.Name = "ProgIncluir";
            this.ProgIncluir.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProgIncluir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProgIncluir.Width = 60;
            // 
            // ProgEditar
            // 
            this.ProgEditar.DataPropertyName = "ProgEditar";
            this.ProgEditar.HeaderText = "Editar";
            this.ProgEditar.Name = "ProgEditar";
            this.ProgEditar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProgEditar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProgEditar.Width = 60;
            // 
            // ProgExcluir
            // 
            this.ProgExcluir.DataPropertyName = "ProgExcluir";
            this.ProgExcluir.HeaderText = "Excluir";
            this.ProgExcluir.Name = "ProgExcluir";
            this.ProgExcluir.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProgExcluir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProgExcluir.Width = 60;
            // 
            // ProgRelatorio
            // 
            this.ProgRelatorio.DataPropertyName = "ProgRelatorio";
            this.ProgRelatorio.HeaderText = "Relatório";
            this.ProgRelatorio.Name = "ProgRelatorio";
            this.ProgRelatorio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProgRelatorio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProgRelatorio.Width = 80;
            // 
            // tcProgramas
            // 
            this.tcProgramas.Controls.Add(this.tpChamado);
            this.tcProgramas.Controls.Add(this.tpAtividade);
            this.tcProgramas.Controls.Add(this.tpSolicitacao);
            this.tcProgramas.Controls.Add(this.tpAgendamento);
            this.tcProgramas.Location = new System.Drawing.Point(7, 288);
            this.tcProgramas.Name = "tcProgramas";
            this.tcProgramas.SelectedIndex = 0;
            this.tcProgramas.Size = new System.Drawing.Size(503, 114);
            this.tcProgramas.TabIndex = 4;
            // 
            // tpChamado
            // 
            this.tpChamado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpChamado.Controls.Add(this.chkChaQuadro);
            this.tpChamado.Controls.Add(this.chkChaStatus);
            this.tpChamado.Controls.Add(this.chkChaOcorrencia);
            this.tpChamado.Controls.Add(this.chkChaAbertura);
            this.tpChamado.Location = new System.Drawing.Point(4, 26);
            this.tpChamado.Name = "tpChamado";
            this.tpChamado.Padding = new System.Windows.Forms.Padding(3);
            this.tpChamado.Size = new System.Drawing.Size(495, 84);
            this.tpChamado.TabIndex = 0;
            this.tpChamado.Text = "Chamado";
            // 
            // chkChaQuadro
            // 
            this.chkChaQuadro.AutoSize = true;
            this.chkChaQuadro.Location = new System.Drawing.Point(117, 33);
            this.chkChaQuadro.Name = "chkChaQuadro";
            this.chkChaQuadro.Size = new System.Drawing.Size(77, 21);
            this.chkChaQuadro.TabIndex = 3;
            this.chkChaQuadro.Text = "Quadro";
            this.chkChaQuadro.UseVisualStyleBackColor = true;
            // 
            // chkChaStatus
            // 
            this.chkChaStatus.AutoSize = true;
            this.chkChaStatus.Location = new System.Drawing.Point(117, 6);
            this.chkChaStatus.Name = "chkChaStatus";
            this.chkChaStatus.Size = new System.Drawing.Size(65, 21);
            this.chkChaStatus.TabIndex = 2;
            this.chkChaStatus.Text = "Status";
            this.chkChaStatus.UseVisualStyleBackColor = true;
            // 
            // chkChaOcorrencia
            // 
            this.chkChaOcorrencia.AutoSize = true;
            this.chkChaOcorrencia.Location = new System.Drawing.Point(6, 33);
            this.chkChaOcorrencia.Name = "chkChaOcorrencia";
            this.chkChaOcorrencia.Size = new System.Drawing.Size(99, 21);
            this.chkChaOcorrencia.TabIndex = 1;
            this.chkChaOcorrencia.Text = "Ocorrência";
            this.chkChaOcorrencia.UseVisualStyleBackColor = true;
            // 
            // chkChaAbertura
            // 
            this.chkChaAbertura.AutoSize = true;
            this.chkChaAbertura.Location = new System.Drawing.Point(6, 6);
            this.chkChaAbertura.Name = "chkChaAbertura";
            this.chkChaAbertura.Size = new System.Drawing.Size(83, 21);
            this.chkChaAbertura.TabIndex = 0;
            this.chkChaAbertura.Text = "Abertura";
            this.chkChaAbertura.UseVisualStyleBackColor = true;
            // 
            // tpAtividade
            // 
            this.tpAtividade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpAtividade.Controls.Add(this.chkAtiQuadro);
            this.tpAtividade.Controls.Add(this.chkAtiStatus);
            this.tpAtividade.Controls.Add(this.chkAtiOcorrencia);
            this.tpAtividade.Controls.Add(this.chkAtiAbertura);
            this.tpAtividade.Location = new System.Drawing.Point(4, 26);
            this.tpAtividade.Name = "tpAtividade";
            this.tpAtividade.Padding = new System.Windows.Forms.Padding(3);
            this.tpAtividade.Size = new System.Drawing.Size(495, 84);
            this.tpAtividade.TabIndex = 1;
            this.tpAtividade.Text = "Atividade";
            // 
            // chkAtiQuadro
            // 
            this.chkAtiQuadro.AutoSize = true;
            this.chkAtiQuadro.Location = new System.Drawing.Point(117, 33);
            this.chkAtiQuadro.Name = "chkAtiQuadro";
            this.chkAtiQuadro.Size = new System.Drawing.Size(77, 21);
            this.chkAtiQuadro.TabIndex = 7;
            this.chkAtiQuadro.Text = "Quadro";
            this.chkAtiQuadro.UseVisualStyleBackColor = true;
            // 
            // chkAtiStatus
            // 
            this.chkAtiStatus.AutoSize = true;
            this.chkAtiStatus.Location = new System.Drawing.Point(117, 6);
            this.chkAtiStatus.Name = "chkAtiStatus";
            this.chkAtiStatus.Size = new System.Drawing.Size(65, 21);
            this.chkAtiStatus.TabIndex = 6;
            this.chkAtiStatus.Text = "Status";
            this.chkAtiStatus.UseVisualStyleBackColor = true;
            // 
            // chkAtiOcorrencia
            // 
            this.chkAtiOcorrencia.AutoSize = true;
            this.chkAtiOcorrencia.Location = new System.Drawing.Point(6, 33);
            this.chkAtiOcorrencia.Name = "chkAtiOcorrencia";
            this.chkAtiOcorrencia.Size = new System.Drawing.Size(99, 21);
            this.chkAtiOcorrencia.TabIndex = 5;
            this.chkAtiOcorrencia.Text = "Ocorrência";
            this.chkAtiOcorrencia.UseVisualStyleBackColor = true;
            // 
            // chkAtiAbertura
            // 
            this.chkAtiAbertura.AutoSize = true;
            this.chkAtiAbertura.Location = new System.Drawing.Point(6, 6);
            this.chkAtiAbertura.Name = "chkAtiAbertura";
            this.chkAtiAbertura.Size = new System.Drawing.Size(83, 21);
            this.chkAtiAbertura.TabIndex = 4;
            this.chkAtiAbertura.Text = "Abertura";
            this.chkAtiAbertura.UseVisualStyleBackColor = true;
            // 
            // tpSolicitacao
            // 
            this.tpSolicitacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpSolicitacao.Controls.Add(this.chkSolQuadro);
            this.tpSolicitacao.Controls.Add(this.chkSolStatus);
            this.tpSolicitacao.Controls.Add(this.chkSolOcorRegra);
            this.tpSolicitacao.Controls.Add(this.chkSolOcorTecnica);
            this.tpSolicitacao.Controls.Add(this.chkSolOcorGeral);
            this.tpSolicitacao.Controls.Add(this.chkSolAnalise);
            this.tpSolicitacao.Controls.Add(this.chkSolAbertura);
            this.tpSolicitacao.Location = new System.Drawing.Point(4, 26);
            this.tpSolicitacao.Name = "tpSolicitacao";
            this.tpSolicitacao.Padding = new System.Windows.Forms.Padding(3);
            this.tpSolicitacao.Size = new System.Drawing.Size(495, 84);
            this.tpSolicitacao.TabIndex = 2;
            this.tpSolicitacao.Text = "Solicitação";
            // 
            // chkSolQuadro
            // 
            this.chkSolQuadro.AutoSize = true;
            this.chkSolQuadro.Location = new System.Drawing.Point(339, 6);
            this.chkSolQuadro.Name = "chkSolQuadro";
            this.chkSolQuadro.Size = new System.Drawing.Size(77, 21);
            this.chkSolQuadro.TabIndex = 7;
            this.chkSolQuadro.Text = "Quadro";
            this.chkSolQuadro.UseVisualStyleBackColor = true;
            // 
            // chkSolStatus
            // 
            this.chkSolStatus.AutoSize = true;
            this.chkSolStatus.Location = new System.Drawing.Point(159, 57);
            this.chkSolStatus.Name = "chkSolStatus";
            this.chkSolStatus.Size = new System.Drawing.Size(65, 21);
            this.chkSolStatus.TabIndex = 6;
            this.chkSolStatus.Text = "Status";
            this.chkSolStatus.UseVisualStyleBackColor = true;
            // 
            // chkSolOcorRegra
            // 
            this.chkSolOcorRegra.AutoSize = true;
            this.chkSolOcorRegra.Location = new System.Drawing.Point(159, 33);
            this.chkSolOcorRegra.Name = "chkSolOcorRegra";
            this.chkSolOcorRegra.Size = new System.Drawing.Size(141, 21);
            this.chkSolOcorRegra.TabIndex = 5;
            this.chkSolOcorRegra.Text = "Ocorrência Regra";
            this.chkSolOcorRegra.UseVisualStyleBackColor = true;
            // 
            // chkSolOcorTecnica
            // 
            this.chkSolOcorTecnica.AutoSize = true;
            this.chkSolOcorTecnica.Location = new System.Drawing.Point(159, 6);
            this.chkSolOcorTecnica.Name = "chkSolOcorTecnica";
            this.chkSolOcorTecnica.Size = new System.Drawing.Size(152, 21);
            this.chkSolOcorTecnica.TabIndex = 4;
            this.chkSolOcorTecnica.Text = "Ocorrência Técnica";
            this.chkSolOcorTecnica.UseVisualStyleBackColor = true;
            // 
            // chkSolOcorGeral
            // 
            this.chkSolOcorGeral.AutoSize = true;
            this.chkSolOcorGeral.Location = new System.Drawing.Point(6, 57);
            this.chkSolOcorGeral.Name = "chkSolOcorGeral";
            this.chkSolOcorGeral.Size = new System.Drawing.Size(138, 21);
            this.chkSolOcorGeral.TabIndex = 3;
            this.chkSolOcorGeral.Text = "Ocorrência Geral";
            this.chkSolOcorGeral.UseVisualStyleBackColor = true;
            // 
            // chkSolAnalise
            // 
            this.chkSolAnalise.AutoSize = true;
            this.chkSolAnalise.Location = new System.Drawing.Point(6, 33);
            this.chkSolAnalise.Name = "chkSolAnalise";
            this.chkSolAnalise.Size = new System.Drawing.Size(72, 21);
            this.chkSolAnalise.TabIndex = 2;
            this.chkSolAnalise.Text = "Análise";
            this.chkSolAnalise.UseVisualStyleBackColor = true;
            // 
            // chkSolAbertura
            // 
            this.chkSolAbertura.AutoSize = true;
            this.chkSolAbertura.Location = new System.Drawing.Point(6, 6);
            this.chkSolAbertura.Name = "chkSolAbertura";
            this.chkSolAbertura.Size = new System.Drawing.Size(83, 21);
            this.chkSolAbertura.TabIndex = 1;
            this.chkSolAbertura.Text = "Abertura";
            this.chkSolAbertura.UseVisualStyleBackColor = true;
            // 
            // tpAgendamento
            // 
            this.tpAgendamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpAgendamento.Controls.Add(this.chkAgeQuadro);
            this.tpAgendamento.Location = new System.Drawing.Point(4, 26);
            this.tpAgendamento.Name = "tpAgendamento";
            this.tpAgendamento.Padding = new System.Windows.Forms.Padding(3);
            this.tpAgendamento.Size = new System.Drawing.Size(495, 84);
            this.tpAgendamento.TabIndex = 3;
            this.tpAgendamento.Text = "Agendamento";
            // 
            // chkAgeQuadro
            // 
            this.chkAgeQuadro.AutoSize = true;
            this.chkAgeQuadro.Location = new System.Drawing.Point(6, 6);
            this.chkAgeQuadro.Name = "chkAgeQuadro";
            this.chkAgeQuadro.Size = new System.Drawing.Size(77, 21);
            this.chkAgeQuadro.TabIndex = 8;
            this.chkAgeQuadro.Text = "Quadro";
            this.chkAgeQuadro.UseVisualStyleBackColor = true;
            // 
            // chkAnexo
            // 
            this.chkAnexo.AutoSize = true;
            this.chkAnexo.Location = new System.Drawing.Point(554, 381);
            this.chkAnexo.Name = "chkAnexo";
            this.chkAnexo.Size = new System.Drawing.Size(123, 21);
            this.chkAnexo.TabIndex = 5;
            this.chkAnexo.Text = "Mostrar Anexos";
            this.chkAnexo.UseVisualStyleBackColor = true;
            // 
            // frmDepartamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 536);
            this.Name = "frmDepartamento";
            this.Tag = "105";
            this.Text = "Departamentos";
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
            this.tpEmail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).EndInit();
            this.tpHorario.ResumeLayout(false);
            this.tpHorario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcesso)).EndInit();
            this.tcProgramas.ResumeLayout(false);
            this.tpChamado.ResumeLayout(false);
            this.tpChamado.PerformLayout();
            this.tpAtividade.ResumeLayout(false);
            this.tpAtividade.PerformLayout();
            this.tpSolicitacao.ResumeLayout(false);
            this.tpSolicitacao.PerformLayout();
            this.tpAgendamento.ResumeLayout(false);
            this.tpAgendamento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dep_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dep_Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dep_Nome;
        private System.Windows.Forms.TabPage tpEmail;
        private System.Windows.Forms.TabPage tpHorario;
        private System.Windows.Forms.CheckBox chkAnexo;
        private System.Windows.Forms.TabControl tcProgramas;
        private System.Windows.Forms.TabPage tpChamado;
        private System.Windows.Forms.TabPage tpAtividade;
        private System.Windows.Forms.TabPage tpSolicitacao;
        private System.Windows.Forms.TabPage tpAgendamento;
        private System.Windows.Forms.DataGridView dgvAcesso;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.TextBox txtNome;
        private Componentes.usrSoNumero txtCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvEmail;
        private System.Windows.Forms.CheckBox chkChaQuadro;
        private System.Windows.Forms.CheckBox chkChaStatus;
        private System.Windows.Forms.CheckBox chkChaOcorrencia;
        private System.Windows.Forms.CheckBox chkChaAbertura;
        private System.Windows.Forms.CheckBox chkSolQuadro;
        private System.Windows.Forms.CheckBox chkSolStatus;
        private System.Windows.Forms.CheckBox chkSolOcorRegra;
        private System.Windows.Forms.CheckBox chkSolOcorTecnica;
        private System.Windows.Forms.CheckBox chkSolOcorGeral;
        private System.Windows.Forms.CheckBox chkSolAnalise;
        private System.Windows.Forms.CheckBox chkSolAbertura;
        private System.Windows.Forms.CheckBox chkAtiQuadro;
        private System.Windows.Forms.CheckBox chkAtiStatus;
        private System.Windows.Forms.CheckBox chkAtiOcorrencia;
        private System.Windows.Forms.CheckBox chkAtiAbertura;
        private System.Windows.Forms.CheckBox chkAgeQuadro;
        private System.Windows.Forms.MaskedTextBox txtHoraFinal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox txtHoraInicial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Programa;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescPrograma;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Acesso;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ProgIncluir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ProgEditar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ProgExcluir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ProgRelatorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepAc_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.Button btnExcluirEmail;
    }
}