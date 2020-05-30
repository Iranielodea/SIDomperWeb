namespace SIDomper.Win.View
{
    partial class frmAgendamento
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigo = new SIDomper.Win.Componentes.usrSoNumero();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.usrData = new SIDomper.Win.Componentes.usrData();
            this.txtHora = new System.Windows.Forms.MaskedTextBox();
            this.UsrUsuario = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrCliente = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrTipo = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrStatus = new SIDomper.Win.Componentes.usrPesquisa();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbAtividade = new System.Windows.Forms.RadioButton();
            this.rbVisita = new System.Windows.Forms.RadioButton();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataFinal = new SIDomper.Win.Componentes.usrData();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDataInicial = new SIDomper.Win.Componentes.usrData();
            this.label13 = new System.Windows.Forms.Label();
            this.tpUsuario = new System.Windows.Forms.TabPage();
            this.ursFiltroUsuario = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.tpCliente = new System.Windows.Forms.TabPage();
            this.ursFiltroCliente = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.tpTipo = new System.Windows.Forms.TabPage();
            this.ursFiltroTipo = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.tpStatus = new System.Windows.Forms.TabPage();
            this.ursFiltroStatus = new SIDomper.Win.Filtros.ursFiltroPadrao();
            this.Age_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age_Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age_NomeCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tip_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sta_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usu_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.groupBox5.SuspendLayout();
            this.tpUsuario.SuspendLayout();
            this.tpCliente.SuspendLayout();
            this.tpTipo.SuspendLayout();
            this.tpStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(984, 601);
            // 
            // tpPesquisa
            // 
            this.tpPesquisa.Controls.Add(this.dgvDados);
            this.tpPesquisa.Size = new System.Drawing.Size(976, 571);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.dgvDados, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(4, 504);
            this.groupBox2.Size = new System.Drawing.Size(968, 63);
            this.groupBox2.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(968, 59);
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(376, 32);
            this.txtTexto.Size = new System.Drawing.Size(237, 23);
            this.txtTexto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTexto_KeyDown);
            // 
            // cbCampos
            // 
            this.cbCampos.Location = new System.Drawing.Point(11, 30);
            this.cbCampos.Size = new System.Drawing.Size(218, 25);
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.Controls.Add(this.label7);
            this.tbPrincipal.Controls.Add(this.txtDescricao);
            this.tbPrincipal.Controls.Add(this.groupBox5);
            this.tbPrincipal.Controls.Add(this.UsrStatus);
            this.tbPrincipal.Controls.Add(this.UsrTipo);
            this.tbPrincipal.Controls.Add(this.UsrCliente);
            this.tbPrincipal.Controls.Add(this.UsrUsuario);
            this.tbPrincipal.Controls.Add(this.txtHora);
            this.tbPrincipal.Controls.Add(this.usrData);
            this.tbPrincipal.Controls.Add(this.label6);
            this.tbPrincipal.Controls.Add(this.label5);
            this.tbPrincipal.Controls.Add(this.label4);
            this.tbPrincipal.Controls.Add(this.txtContato);
            this.tbPrincipal.Controls.Add(this.label3);
            this.tbPrincipal.Controls.Add(this.txtCodigo);
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tpUsuario);
            this.tabControl3.Controls.Add(this.tpCliente);
            this.tabControl3.Controls.Add(this.tpTipo);
            this.tabControl3.Controls.Add(this.tpStatus);
            this.tabControl3.Click += new System.EventHandler(this.tabControl3_Click);
            this.tabControl3.Controls.SetChildIndex(this.tpStatus, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpTipo, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpCliente, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpUsuario, 0);
            this.tabControl3.Controls.SetChildIndex(this.tpFiltroPrincipal, 0);
            // 
            // tpFiltroPrincipal
            // 
            this.tpFiltroPrincipal.Controls.Add(this.txtDataFinal);
            this.tpFiltroPrincipal.Controls.Add(this.label14);
            this.tpFiltroPrincipal.Controls.Add(this.txtDataInicial);
            this.tpFiltroPrincipal.Controls.Add(this.label13);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.lblAtivo, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.cboAtivo, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.label13, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.txtDataInicial, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.label14, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.txtDataFinal, 0);
            // 
            // cboAtivo
            // 
            this.cboAtivo.Location = new System.Drawing.Point(474, 48);
            this.cboAtivo.Visible = false;
            // 
            // lblAtivo
            // 
            this.lblAtivo.Location = new System.Drawing.Point(471, 28);
            this.lblAtivo.Visible = false;
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Age_Id,
            this.Age_Data,
            this.Age_Hora,
            this.Age_NomeCliente,
            this.Tip_Nome,
            this.Sta_Nome,
            this.Usu_Nome});
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(4, 63);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(968, 441);
            this.dgvDados.TabIndex = 2;
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_ColumnHeaderMouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Id";
            // 
            // txtContato
            // 
            this.txtContato.Location = new System.Drawing.Point(19, 235);
            this.txtContato.MaxLength = 100;
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(478, 23);
            this.txtContato.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Contato";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(19, 37);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(81, 26);
            this.txtCodigo.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Data*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(105, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Hora*";
            // 
            // usrData
            // 
            this.usrData.Location = new System.Drawing.Point(19, 87);
            this.usrData.Name = "usrData";
            this.usrData.Size = new System.Drawing.Size(86, 25);
            this.usrData.TabIndex = 1;
            // 
            // txtHora
            // 
            this.txtHora.Location = new System.Drawing.Point(108, 87);
            this.txtHora.Mask = "90:00";
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(50, 23);
            this.txtHora.TabIndex = 2;
            this.txtHora.ValidatingType = typeof(System.DateTime);
            // 
            // UsrUsuario
            // 
            this.UsrUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrUsuario.Location = new System.Drawing.Point(19, 118);
            this.UsrUsuario.Modificou = false;
            this.UsrUsuario.Name = "UsrUsuario";
            this.UsrUsuario.Size = new System.Drawing.Size(482, 55);
            this.UsrUsuario.TabIndex = 3;
            // 
            // UsrCliente
            // 
            this.UsrCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrCliente.Location = new System.Drawing.Point(19, 164);
            this.UsrCliente.Modificou = false;
            this.UsrCliente.Name = "UsrCliente";
            this.UsrCliente.Size = new System.Drawing.Size(482, 49);
            this.UsrCliente.TabIndex = 4;
            // 
            // UsrTipo
            // 
            this.UsrTipo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrTipo.Location = new System.Drawing.Point(19, 264);
            this.UsrTipo.Modificou = false;
            this.UsrTipo.Name = "UsrTipo";
            this.UsrTipo.Size = new System.Drawing.Size(482, 49);
            this.UsrTipo.TabIndex = 6;
            // 
            // UsrStatus
            // 
            this.UsrStatus.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrStatus.Location = new System.Drawing.Point(19, 309);
            this.UsrStatus.Modificou = false;
            this.UsrStatus.Name = "UsrStatus";
            this.UsrStatus.Size = new System.Drawing.Size(482, 49);
            this.UsrStatus.TabIndex = 7;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Silver;
            this.groupBox5.Controls.Add(this.rbAtividade);
            this.groupBox5.Controls.Add(this.rbVisita);
            this.groupBox5.Location = new System.Drawing.Point(19, 364);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(210, 100);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Programa:";
            // 
            // rbAtividade
            // 
            this.rbAtividade.AutoSize = true;
            this.rbAtividade.Location = new System.Drawing.Point(22, 49);
            this.rbAtividade.Name = "rbAtividade";
            this.rbAtividade.Size = new System.Drawing.Size(149, 21);
            this.rbAtividade.TabIndex = 1;
            this.rbAtividade.TabStop = true;
            this.rbAtividade.Text = "7-Atividade Interna";
            this.rbAtividade.UseVisualStyleBackColor = true;
            // 
            // rbVisita
            // 
            this.rbVisita.AutoSize = true;
            this.rbVisita.Location = new System.Drawing.Point(22, 22);
            this.rbVisita.Name = "rbVisita";
            this.rbVisita.Size = new System.Drawing.Size(71, 21);
            this.rbVisita.TabIndex = 0;
            this.rbVisita.TabStop = true;
            this.rbVisita.Text = "2-Visita";
            this.rbVisita.UseVisualStyleBackColor = true;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(522, 140);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricao.Size = new System.Drawing.Size(431, 324);
            this.txtDescricao.TabIndex = 9;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescricao_KeyDown);
            this.txtDescricao.Leave += new System.EventHandler(this.txtDescricao_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(519, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Descrição*";
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Location = new System.Drawing.Point(10, 78);
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(90, 25);
            this.txtDataFinal.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 17);
            this.label14.TabIndex = 8;
            this.label14.Text = "Data Final";
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.Location = new System.Drawing.Point(10, 28);
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.Size = new System.Drawing.Size(90, 25);
            this.txtDataInicial.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 17);
            this.label13.TabIndex = 6;
            this.label13.Text = "Data Inicial";
            // 
            // tpUsuario
            // 
            this.tpUsuario.Controls.Add(this.ursFiltroUsuario);
            this.tpUsuario.Location = new System.Drawing.Point(4, 26);
            this.tpUsuario.Name = "tpUsuario";
            this.tpUsuario.Padding = new System.Windows.Forms.Padding(3);
            this.tpUsuario.Size = new System.Drawing.Size(680, 483);
            this.tpUsuario.TabIndex = 1;
            this.tpUsuario.Text = "Usuário";
            this.tpUsuario.UseVisualStyleBackColor = true;
            // 
            // ursFiltroUsuario
            // 
            this.ursFiltroUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroUsuario.Location = new System.Drawing.Point(7, 6);
            this.ursFiltroUsuario.Name = "ursFiltroUsuario";
            this.ursFiltroUsuario.Size = new System.Drawing.Size(950, 461);
            this.ursFiltroUsuario.TabIndex = 1;
            // 
            // tpCliente
            // 
            this.tpCliente.Controls.Add(this.ursFiltroCliente);
            this.tpCliente.Location = new System.Drawing.Point(4, 26);
            this.tpCliente.Name = "tpCliente";
            this.tpCliente.Padding = new System.Windows.Forms.Padding(3);
            this.tpCliente.Size = new System.Drawing.Size(680, 483);
            this.tpCliente.TabIndex = 2;
            this.tpCliente.Text = "Cliente";
            this.tpCliente.UseVisualStyleBackColor = true;
            // 
            // ursFiltroCliente
            // 
            this.ursFiltroCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroCliente.Location = new System.Drawing.Point(7, 6);
            this.ursFiltroCliente.Name = "ursFiltroCliente";
            this.ursFiltroCliente.Size = new System.Drawing.Size(947, 461);
            this.ursFiltroCliente.TabIndex = 1;
            // 
            // tpTipo
            // 
            this.tpTipo.Controls.Add(this.ursFiltroTipo);
            this.tpTipo.Location = new System.Drawing.Point(4, 26);
            this.tpTipo.Name = "tpTipo";
            this.tpTipo.Padding = new System.Windows.Forms.Padding(3);
            this.tpTipo.Size = new System.Drawing.Size(680, 483);
            this.tpTipo.TabIndex = 3;
            this.tpTipo.Text = "Tipo";
            this.tpTipo.UseVisualStyleBackColor = true;
            // 
            // ursFiltroTipo
            // 
            this.ursFiltroTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroTipo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroTipo.Location = new System.Drawing.Point(7, 6);
            this.ursFiltroTipo.Name = "ursFiltroTipo";
            this.ursFiltroTipo.Size = new System.Drawing.Size(950, 461);
            this.ursFiltroTipo.TabIndex = 1;
            // 
            // tpStatus
            // 
            this.tpStatus.Controls.Add(this.ursFiltroStatus);
            this.tpStatus.Location = new System.Drawing.Point(4, 26);
            this.tpStatus.Name = "tpStatus";
            this.tpStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tpStatus.Size = new System.Drawing.Size(680, 483);
            this.tpStatus.TabIndex = 4;
            this.tpStatus.Text = "Status";
            this.tpStatus.UseVisualStyleBackColor = true;
            // 
            // ursFiltroStatus
            // 
            this.ursFiltroStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ursFiltroStatus.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ursFiltroStatus.Location = new System.Drawing.Point(7, 6);
            this.ursFiltroStatus.Name = "ursFiltroStatus";
            this.ursFiltroStatus.Size = new System.Drawing.Size(950, 461);
            this.ursFiltroStatus.TabIndex = 1;
            // 
            // Age_Id
            // 
            this.Age_Id.DataPropertyName = "Id";
            this.Age_Id.HeaderText = "Id";
            this.Age_Id.Name = "Age_Id";
            this.Age_Id.Visible = false;
            // 
            // Age_Data
            // 
            this.Age_Data.DataPropertyName = "Data";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Age_Data.DefaultCellStyle = dataGridViewCellStyle1;
            this.Age_Data.HeaderText = "Data";
            this.Age_Data.Name = "Age_Data";
            // 
            // Age_Hora
            // 
            this.Age_Hora.DataPropertyName = "Hora";
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            this.Age_Hora.DefaultCellStyle = dataGridViewCellStyle2;
            this.Age_Hora.HeaderText = "Hora";
            this.Age_Hora.Name = "Age_Hora";
            this.Age_Hora.Width = 60;
            // 
            // Age_NomeCliente
            // 
            this.Age_NomeCliente.DataPropertyName = "NomeCliente";
            this.Age_NomeCliente.HeaderText = "Cliente";
            this.Age_NomeCliente.Name = "Age_NomeCliente";
            this.Age_NomeCliente.Width = 300;
            // 
            // Tip_Nome
            // 
            this.Tip_Nome.DataPropertyName = "TipoNome";
            this.Tip_Nome.HeaderText = "Tipo";
            this.Tip_Nome.Name = "Tip_Nome";
            this.Tip_Nome.Width = 150;
            // 
            // Sta_Nome
            // 
            this.Sta_Nome.DataPropertyName = "StatusNome";
            this.Sta_Nome.HeaderText = "Status";
            this.Sta_Nome.Name = "Sta_Nome";
            this.Sta_Nome.Width = 150;
            // 
            // Usu_Nome
            // 
            this.Usu_Nome.DataPropertyName = "UsuarioNome";
            this.Usu_Nome.HeaderText = "Usuário";
            this.Usu_Nome.Name = "Usu_Nome";
            this.Usu_Nome.Width = 150;
            // 
            // frmAgendamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 601);
            this.Name = "frmAgendamento";
            this.Tag = "101";
            this.Text = "Agendamentos";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAgendamento_KeyDown);
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tpUsuario.ResumeLayout(false);
            this.tpCliente.ResumeLayout(false);
            this.tpTipo.ResumeLayout(false);
            this.tpStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Label label3;
        private Componentes.usrSoNumero txtCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbAtividade;
        private System.Windows.Forms.RadioButton rbVisita;
        private Componentes.usrPesquisa UsrStatus;
        private Componentes.usrPesquisa UsrTipo;
        private Componentes.usrPesquisa UsrCliente;
        private Componentes.usrPesquisa UsrUsuario;
        private System.Windows.Forms.MaskedTextBox txtHora;
        private Componentes.usrData usrData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Componentes.usrData txtDataFinal;
        private System.Windows.Forms.Label label14;
        private Componentes.usrData txtDataInicial;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tpUsuario;
        private System.Windows.Forms.TabPage tpCliente;
        private System.Windows.Forms.TabPage tpTipo;
        private System.Windows.Forms.TabPage tpStatus;
        private Filtros.ursFiltroPadrao ursFiltroUsuario;
        private Filtros.ursFiltroPadrao ursFiltroTipo;
        private Filtros.ursFiltroPadrao ursFiltroStatus;
        private Filtros.ursFiltroPadrao ursFiltroCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age_Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age_NomeCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tip_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sta_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usu_Nome;
    }
}