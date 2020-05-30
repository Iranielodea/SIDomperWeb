namespace SIDomper.Win.View
{
    partial class frmRecado
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
            this.Rec_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeUsuarioLancamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_Nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_RazaoSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeUsuarioDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sta_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtHora = new System.Windows.Forms.MaskedTextBox();
            this.usrData = new SIDomper.Win.Componentes.usrData();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new SIDomper.Win.Componentes.usrSoNumero();
            this.UsrUsuarioLcto = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrCliente = new SIDomper.Win.Componentes.usrPesquisa();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRazao = new System.Windows.Forms.TextBox();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.UsrUsuarioDestino = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrTipo = new SIDomper.Win.Componentes.usrPesquisa();
            this.UsrStatus = new SIDomper.Win.Componentes.usrPesquisa();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbCritico = new System.Windows.Forms.RadioButton();
            this.rbAlto = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbBaixo = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescricaoInicial = new System.Windows.Forms.TextBox();
            this.tpEncerramento = new System.Windows.Forms.TabPage();
            this.btnEncerrar = new System.Windows.Forms.Button();
            this.txtHoraFinal = new System.Windows.Forms.MaskedTextBox();
            this.txtDataFinal = new SIDomper.Win.Componentes.usrData();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDescricaoFinal = new System.Windows.Forms.TextBox();
            this.txtDataFiltroInicial = new SIDomper.Win.Componentes.usrData();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDataFiltroFinal = new SIDomper.Win.Componentes.usrData();
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
            this.tpEncerramento.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(984, 641);
            // 
            // tpPesquisa
            // 
            this.tpPesquisa.Controls.Add(this.dgvDados);
            this.tpPesquisa.Size = new System.Drawing.Size(976, 611);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.dgvDados, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(4, 544);
            this.groupBox2.Size = new System.Drawing.Size(968, 63);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(968, 60);
            // 
            // txtTexto
            // 
            this.txtTexto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTexto_KeyDown);
            // 
            // cbCampos
            // 
            this.cbCampos.Size = new System.Drawing.Size(218, 25);
            // 
            // tpEditar
            // 
            this.tpEditar.Size = new System.Drawing.Size(976, 611);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(4, 544);
            this.groupBox3.Size = new System.Drawing.Size(968, 63);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tpEncerramento);
            this.tabControl2.Size = new System.Drawing.Size(968, 603);
            this.tabControl2.Click += new System.EventHandler(this.tabControl2_Click);
            this.tabControl2.Controls.SetChildIndex(this.tpEncerramento, 0);
            this.tabControl2.Controls.SetChildIndex(this.tbPrincipal, 0);
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.Controls.Add(this.txtDescricaoInicial);
            this.tbPrincipal.Controls.Add(this.label11);
            this.tbPrincipal.Controls.Add(this.groupBox5);
            this.tbPrincipal.Controls.Add(this.UsrStatus);
            this.tbPrincipal.Controls.Add(this.UsrTipo);
            this.tbPrincipal.Controls.Add(this.UsrUsuarioDestino);
            this.tbPrincipal.Controls.Add(this.txtContato);
            this.tbPrincipal.Controls.Add(this.label10);
            this.tbPrincipal.Controls.Add(this.txtTelefone);
            this.tbPrincipal.Controls.Add(this.label9);
            this.tbPrincipal.Controls.Add(this.txtEndereco);
            this.tbPrincipal.Controls.Add(this.label8);
            this.tbPrincipal.Controls.Add(this.txtFantasia);
            this.tbPrincipal.Controls.Add(this.label7);
            this.tbPrincipal.Controls.Add(this.txtRazao);
            this.tbPrincipal.Controls.Add(this.label4);
            this.tbPrincipal.Controls.Add(this.UsrCliente);
            this.tbPrincipal.Controls.Add(this.UsrUsuarioLcto);
            this.tbPrincipal.Controls.Add(this.txtHora);
            this.tbPrincipal.Controls.Add(this.usrData);
            this.tbPrincipal.Controls.Add(this.label6);
            this.tbPrincipal.Controls.Add(this.label5);
            this.tbPrincipal.Controls.Add(this.label3);
            this.tbPrincipal.Controls.Add(this.txtCodigo);
            this.tbPrincipal.Size = new System.Drawing.Size(960, 573);
            this.tbPrincipal.Text = "Abertura";
            // 
            // tabControl3
            // 
            this.tabControl3.Click += new System.EventHandler(this.tabControl3_Click);
            // 
            // tpFiltroPrincipal
            // 
            this.tpFiltroPrincipal.Controls.Add(this.txtDataFiltroFinal);
            this.tpFiltroPrincipal.Controls.Add(this.label16);
            this.tpFiltroPrincipal.Controls.Add(this.label15);
            this.tpFiltroPrincipal.Controls.Add(this.txtDataFiltroInicial);
            this.tpFiltroPrincipal.Size = new System.Drawing.Size(960, 573);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.lblAtivo, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.cboAtivo, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.txtDataFiltroInicial, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.label15, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.label16, 0);
            this.tpFiltroPrincipal.Controls.SetChildIndex(this.txtDataFiltroFinal, 0);
            // 
            // cboAtivo
            // 
            this.cboAtivo.Location = new System.Drawing.Point(579, 42);
            this.cboAtivo.Visible = false;
            // 
            // lblAtivo
            // 
            this.lblAtivo.Location = new System.Drawing.Point(576, 22);
            this.lblAtivo.Visible = false;
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rec_Id,
            this.Rec_Data,
            this.NomeUsuarioLancamento,
            this.Rec_Nivel,
            this.Rec_RazaoSocial,
            this.Rec_Telefone,
            this.NomeUsuarioDestino,
            this.Sta_Nome});
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(4, 64);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(968, 480);
            this.dgvDados.TabIndex = 3;
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_ColumnHeaderMouseClick);
            // 
            // Rec_Id
            // 
            this.Rec_Id.DataPropertyName = "Id";
            this.Rec_Id.HeaderText = "Id";
            this.Rec_Id.Name = "Rec_Id";
            this.Rec_Id.Visible = false;
            // 
            // Rec_Data
            // 
            this.Rec_Data.DataPropertyName = "Data";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Rec_Data.DefaultCellStyle = dataGridViewCellStyle1;
            this.Rec_Data.HeaderText = "Data";
            this.Rec_Data.Name = "Rec_Data";
            this.Rec_Data.Width = 80;
            // 
            // NomeUsuarioLancamento
            // 
            this.NomeUsuarioLancamento.DataPropertyName = "NomeUsuarioLancamento";
            this.NomeUsuarioLancamento.HeaderText = "Usuário Lançamento";
            this.NomeUsuarioLancamento.Name = "NomeUsuarioLancamento";
            this.NomeUsuarioLancamento.Width = 150;
            // 
            // Rec_Nivel
            // 
            this.Rec_Nivel.DataPropertyName = "Nivel";
            this.Rec_Nivel.HeaderText = "Nível";
            this.Rec_Nivel.Name = "Rec_Nivel";
            this.Rec_Nivel.Width = 60;
            // 
            // Rec_RazaoSocial
            // 
            this.Rec_RazaoSocial.DataPropertyName = "RazaoSocial";
            this.Rec_RazaoSocial.HeaderText = "Razão Social";
            this.Rec_RazaoSocial.Name = "Rec_RazaoSocial";
            this.Rec_RazaoSocial.Width = 300;
            // 
            // Rec_Telefone
            // 
            this.Rec_Telefone.DataPropertyName = "Telefone";
            this.Rec_Telefone.HeaderText = "Telefone";
            this.Rec_Telefone.Name = "Rec_Telefone";
            // 
            // NomeUsuarioDestino
            // 
            this.NomeUsuarioDestino.DataPropertyName = "NomeUsuarioDestino";
            this.NomeUsuarioDestino.HeaderText = "Usuário Destino";
            this.NomeUsuarioDestino.Name = "NomeUsuarioDestino";
            this.NomeUsuarioDestino.Width = 150;
            // 
            // Sta_Nome
            // 
            this.Sta_Nome.DataPropertyName = "NomeStatus";
            this.Sta_Nome.HeaderText = "Status";
            this.Sta_Nome.Name = "Sta_Nome";
            this.Sta_Nome.Width = 150;
            // 
            // txtHora
            // 
            this.txtHora.Location = new System.Drawing.Point(188, 32);
            this.txtHora.Mask = "90:00";
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(50, 23);
            this.txtHora.TabIndex = 2;
            this.txtHora.ValidatingType = typeof(System.DateTime);
            // 
            // usrData
            // 
            this.usrData.Location = new System.Drawing.Point(96, 33);
            this.usrData.Name = "usrData";
            this.usrData.Size = new System.Drawing.Size(86, 25);
            this.usrData.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(185, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Hora*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Data*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Id";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(8, 32);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(81, 26);
            this.txtCodigo.TabIndex = 0;
            // 
            // UsrUsuarioLcto
            // 
            this.UsrUsuarioLcto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrUsuarioLcto.Location = new System.Drawing.Point(253, 11);
            this.UsrUsuarioLcto.Modificou = false;
            this.UsrUsuarioLcto.Name = "UsrUsuarioLcto";
            this.UsrUsuarioLcto.Size = new System.Drawing.Size(479, 49);
            this.UsrUsuarioLcto.TabIndex = 3;
            // 
            // UsrCliente
            // 
            this.UsrCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrCliente.Location = new System.Drawing.Point(8, 61);
            this.UsrCliente.Modificou = false;
            this.UsrCliente.Name = "UsrCliente";
            this.UsrCliente.Size = new System.Drawing.Size(724, 49);
            this.UsrCliente.TabIndex = 4;
            this.UsrCliente.Leave += new System.EventHandler(this.UsrCliente_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Razão Social*";
            // 
            // txtRazao
            // 
            this.txtRazao.Location = new System.Drawing.Point(10, 133);
            this.txtRazao.Name = "txtRazao";
            this.txtRazao.Size = new System.Drawing.Size(468, 23);
            this.txtRazao.TabIndex = 5;
            // 
            // txtFantasia
            // 
            this.txtFantasia.Location = new System.Drawing.Point(10, 181);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.Size = new System.Drawing.Size(468, 23);
            this.txtFantasia.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Fantasia";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(10, 229);
            this.txtEndereco.Multiline = true;
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(468, 72);
            this.txtEndereco.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Endereço";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(10, 329);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(468, 23);
            this.txtTelefone.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 309);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Telefone";
            // 
            // txtContato
            // 
            this.txtContato.Location = new System.Drawing.Point(10, 376);
            this.txtContato.Multiline = true;
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(468, 72);
            this.txtContato.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 356);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 17);
            this.label10.TabIndex = 22;
            this.label10.Text = "Contato";
            // 
            // UsrUsuarioDestino
            // 
            this.UsrUsuarioDestino.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrUsuarioDestino.Location = new System.Drawing.Point(10, 454);
            this.UsrUsuarioDestino.Modificou = false;
            this.UsrUsuarioDestino.Name = "UsrUsuarioDestino";
            this.UsrUsuarioDestino.Size = new System.Drawing.Size(316, 49);
            this.UsrUsuarioDestino.TabIndex = 12;
            // 
            // UsrTipo
            // 
            this.UsrTipo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrTipo.Location = new System.Drawing.Point(332, 454);
            this.UsrTipo.Modificou = false;
            this.UsrTipo.Name = "UsrTipo";
            this.UsrTipo.Size = new System.Drawing.Size(320, 49);
            this.UsrTipo.TabIndex = 13;
            // 
            // UsrStatus
            // 
            this.UsrStatus.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrStatus.Location = new System.Drawing.Point(658, 454);
            this.UsrStatus.Modificou = false;
            this.UsrStatus.Name = "UsrStatus";
            this.UsrStatus.Size = new System.Drawing.Size(295, 49);
            this.UsrStatus.TabIndex = 14;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Silver;
            this.groupBox5.Controls.Add(this.rbCritico);
            this.groupBox5.Controls.Add(this.rbAlto);
            this.groupBox5.Controls.Add(this.rbNormal);
            this.groupBox5.Controls.Add(this.rbBaixo);
            this.groupBox5.Location = new System.Drawing.Point(484, 133);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(460, 59);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            // 
            // rbCritico
            // 
            this.rbCritico.AutoSize = true;
            this.rbCritico.Location = new System.Drawing.Point(293, 22);
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
            this.rbAlto.Location = new System.Drawing.Point(224, 22);
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
            this.rbNormal.Location = new System.Drawing.Point(130, 22);
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
            this.rbBaixo.Location = new System.Drawing.Point(53, 22);
            this.rbBaixo.Name = "rbBaixo";
            this.rbBaixo.Size = new System.Drawing.Size(71, 21);
            this.rbBaixo.TabIndex = 0;
            this.rbBaixo.TabStop = true;
            this.rbBaixo.Text = "1-Baixo";
            this.rbBaixo.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(487, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 17);
            this.label11.TabIndex = 28;
            this.label11.Text = "Descrição*";
            // 
            // txtDescricaoInicial
            // 
            this.txtDescricaoInicial.Location = new System.Drawing.Point(484, 215);
            this.txtDescricaoInicial.Multiline = true;
            this.txtDescricaoInicial.Name = "txtDescricaoInicial";
            this.txtDescricaoInicial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricaoInicial.Size = new System.Drawing.Size(468, 233);
            this.txtDescricaoInicial.TabIndex = 11;
            this.txtDescricaoInicial.Enter += new System.EventHandler(this.txtDescricaoInicial_Enter);
            this.txtDescricaoInicial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescricaoInicial_KeyDown);
            this.txtDescricaoInicial.Leave += new System.EventHandler(this.txtDescricaoInicial_Leave);
            // 
            // tpEncerramento
            // 
            this.tpEncerramento.Controls.Add(this.btnEncerrar);
            this.tpEncerramento.Controls.Add(this.txtHoraFinal);
            this.tpEncerramento.Controls.Add(this.txtDataFinal);
            this.tpEncerramento.Controls.Add(this.label14);
            this.tpEncerramento.Controls.Add(this.label13);
            this.tpEncerramento.Controls.Add(this.label12);
            this.tpEncerramento.Controls.Add(this.txtDescricaoFinal);
            this.tpEncerramento.Location = new System.Drawing.Point(4, 26);
            this.tpEncerramento.Name = "tpEncerramento";
            this.tpEncerramento.Padding = new System.Windows.Forms.Padding(3);
            this.tpEncerramento.Size = new System.Drawing.Size(680, 483);
            this.tpEncerramento.TabIndex = 1;
            this.tpEncerramento.Text = "Encerramento";
            this.tpEncerramento.UseVisualStyleBackColor = true;
            // 
            // btnEncerrar
            // 
            this.btnEncerrar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncerrar.Location = new System.Drawing.Point(861, 364);
            this.btnEncerrar.Name = "btnEncerrar";
            this.btnEncerrar.Size = new System.Drawing.Size(93, 40);
            this.btnEncerrar.TabIndex = 3;
            this.btnEncerrar.Text = "Encerrar";
            this.btnEncerrar.UseVisualStyleBackColor = true;
            this.btnEncerrar.Click += new System.EventHandler(this.btnEncerrar_Click);
            // 
            // txtHoraFinal
            // 
            this.txtHoraFinal.Location = new System.Drawing.Point(19, 432);
            this.txtHoraFinal.Mask = "00:00";
            this.txtHoraFinal.Name = "txtHoraFinal";
            this.txtHoraFinal.Size = new System.Drawing.Size(80, 23);
            this.txtHoraFinal.TabIndex = 2;
            this.txtHoraFinal.TabStop = false;
            this.txtHoraFinal.ValidatingType = typeof(System.DateTime);
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Location = new System.Drawing.Point(19, 384);
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(80, 25);
            this.txtDataFinal.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 412);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 17);
            this.label14.TabIndex = 3;
            this.label14.Text = "Hora";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 364);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "Data";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "Descrição";
            // 
            // txtDescricaoFinal
            // 
            this.txtDescricaoFinal.Location = new System.Drawing.Point(19, 41);
            this.txtDescricaoFinal.Multiline = true;
            this.txtDescricaoFinal.Name = "txtDescricaoFinal";
            this.txtDescricaoFinal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricaoFinal.Size = new System.Drawing.Size(935, 306);
            this.txtDescricaoFinal.TabIndex = 0;
            this.txtDescricaoFinal.Enter += new System.EventHandler(this.txtDescricaoFinal_Enter);
            this.txtDescricaoFinal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescricaoFinal_KeyDown);
            this.txtDescricaoFinal.Leave += new System.EventHandler(this.txtDescricaoFinal_Leave);
            // 
            // txtDataFiltroInicial
            // 
            this.txtDataFiltroInicial.Location = new System.Drawing.Point(15, 42);
            this.txtDataFiltroInicial.Name = "txtDataFiltroInicial";
            this.txtDataFiltroInicial.Size = new System.Drawing.Size(85, 25);
            this.txtDataFiltroInicial.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 17);
            this.label15.TabIndex = 3;
            this.label15.Text = "Data Inicial";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(105, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 17);
            this.label16.TabIndex = 4;
            this.label16.Text = "Data Final";
            // 
            // txtDataFiltroFinal
            // 
            this.txtDataFiltroFinal.Location = new System.Drawing.Point(108, 42);
            this.txtDataFiltroFinal.Name = "txtDataFiltroFinal";
            this.txtDataFiltroFinal.Size = new System.Drawing.Size(85, 25);
            this.txtDataFiltroFinal.TabIndex = 1;
            // 
            // frmRecado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 641);
            this.Name = "frmRecado";
            this.Text = "Recado";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRecado_KeyDown);
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
            this.tpEncerramento.ResumeLayout(false);
            this.tpEncerramento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.MaskedTextBox txtHora;
        private Componentes.usrData usrData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private Componentes.usrSoNumero txtCodigo;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRazao;
        private System.Windows.Forms.Label label4;
        private Componentes.usrPesquisa UsrCliente;
        private Componentes.usrPesquisa UsrUsuarioLcto;
        private Componentes.usrPesquisa UsrTipo;
        private Componentes.usrPesquisa UsrUsuarioDestino;
        private System.Windows.Forms.TextBox txtDescricaoInicial;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbCritico;
        private System.Windows.Forms.RadioButton rbAlto;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbBaixo;
        private Componentes.usrPesquisa UsrStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeUsuarioLancamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_Nivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_RazaoSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_Telefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeUsuarioDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sta_Nome;
        private System.Windows.Forms.TabPage tpEncerramento;
        private System.Windows.Forms.Button btnEncerrar;
        private System.Windows.Forms.MaskedTextBox txtHoraFinal;
        private Componentes.usrData txtDataFinal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDescricaoFinal;
        private Componentes.usrData txtDataFiltroFinal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private Componentes.usrData txtDataFiltroInicial;
    }
}