namespace SIDomper.Win.View
{
    partial class frmRevenda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.Rev_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rev_Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rev_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new SIDomper.Win.Componentes.usrSoNumero();
            this.tpEmail = new System.Windows.Forms.TabPage();
            this.txtIdEmail = new System.Windows.Forms.TextBox();
            this.btnExcluirEmail = new System.Windows.Forms.Button();
            this.btnSalvarEmail = new System.Windows.Forms.Button();
            this.btnNovoEmail = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvEmail = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(703, 467);
            // 
            // tpPesquisa
            // 
            this.tpPesquisa.Controls.Add(this.dgvDados);
            this.tpPesquisa.Size = new System.Drawing.Size(695, 437);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.dgvDados, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(4, 370);
            this.groupBox2.Size = new System.Drawing.Size(687, 63);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(687, 60);
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
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tpEmail);
            this.tabControl2.Controls.SetChildIndex(this.tpEmail, 0);
            this.tabControl2.Controls.SetChildIndex(this.tbPrincipal, 0);
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.Controls.Add(this.chkAtivo);
            this.tbPrincipal.Controls.Add(this.label4);
            this.tbPrincipal.Controls.Add(this.txtNome);
            this.tbPrincipal.Controls.Add(this.label3);
            this.tbPrincipal.Controls.Add(this.txtCodigo);
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rev_Id,
            this.Rev_Codigo,
            this.Rev_Nome});
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(4, 64);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(687, 306);
            this.dgvDados.TabIndex = 1;
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_ColumnHeaderMouseClick);
            // 
            // Rev_Id
            // 
            this.Rev_Id.DataPropertyName = "Id";
            this.Rev_Id.HeaderText = "Id";
            this.Rev_Id.Name = "Rev_Id";
            this.Rev_Id.Visible = false;
            // 
            // Rev_Codigo
            // 
            this.Rev_Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.Format = "0000";
            this.Rev_Codigo.DefaultCellStyle = dataGridViewCellStyle2;
            this.Rev_Codigo.HeaderText = "Código";
            this.Rev_Codigo.Name = "Rev_Codigo";
            // 
            // Rev_Nome
            // 
            this.Rev_Nome.DataPropertyName = "Nome";
            this.Rev_Nome.HeaderText = "Nome";
            this.Rev_Nome.Name = "Rev_Nome";
            this.Rev_Nome.Width = 510;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(19, 108);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(61, 21);
            this.chkAtivo.TabIndex = 2;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nome*";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(19, 79);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(549, 23);
            this.txtNome.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(19, 34);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(91, 24);
            this.txtCodigo.TabIndex = 0;
            // 
            // tpEmail
            // 
            this.tpEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpEmail.Controls.Add(this.txtIdEmail);
            this.tpEmail.Controls.Add(this.btnExcluirEmail);
            this.tpEmail.Controls.Add(this.btnSalvarEmail);
            this.tpEmail.Controls.Add(this.btnNovoEmail);
            this.tpEmail.Controls.Add(this.txtEmail);
            this.tpEmail.Controls.Add(this.label5);
            this.tpEmail.Controls.Add(this.dgvEmail);
            this.tpEmail.Location = new System.Drawing.Point(4, 26);
            this.tpEmail.Name = "tpEmail";
            this.tpEmail.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmail.Size = new System.Drawing.Size(680, 483);
            this.tpEmail.TabIndex = 1;
            this.tpEmail.Text = "Emails";
            // 
            // txtIdEmail
            // 
            this.txtIdEmail.Location = new System.Drawing.Point(628, 271);
            this.txtIdEmail.Name = "txtIdEmail";
            this.txtIdEmail.Size = new System.Drawing.Size(38, 23);
            this.txtIdEmail.TabIndex = 5;
            this.txtIdEmail.Visible = false;
            // 
            // btnExcluirEmail
            // 
            this.btnExcluirEmail.Location = new System.Drawing.Point(554, 310);
            this.btnExcluirEmail.Name = "btnExcluirEmail";
            this.btnExcluirEmail.Size = new System.Drawing.Size(117, 23);
            this.btnExcluirEmail.TabIndex = 4;
            this.btnExcluirEmail.Text = "Excluir Email";
            this.btnExcluirEmail.UseVisualStyleBackColor = true;
            this.btnExcluirEmail.Click += new System.EventHandler(this.btnExcluirEmail_Click);
            // 
            // btnSalvarEmail
            // 
            this.btnSalvarEmail.Enabled = false;
            this.btnSalvarEmail.Location = new System.Drawing.Point(431, 310);
            this.btnSalvarEmail.Name = "btnSalvarEmail";
            this.btnSalvarEmail.Size = new System.Drawing.Size(117, 23);
            this.btnSalvarEmail.TabIndex = 3;
            this.btnSalvarEmail.Text = "Salvar Email";
            this.btnSalvarEmail.UseVisualStyleBackColor = true;
            this.btnSalvarEmail.Click += new System.EventHandler(this.btnSalvarEmail_Click);
            // 
            // btnNovoEmail
            // 
            this.btnNovoEmail.Location = new System.Drawing.Point(308, 310);
            this.btnNovoEmail.Name = "btnNovoEmail";
            this.btnNovoEmail.Size = new System.Drawing.Size(117, 23);
            this.btnNovoEmail.TabIndex = 2;
            this.btnNovoEmail.Text = "Novo Email";
            this.btnNovoEmail.UseVisualStyleBackColor = true;
            this.btnNovoEmail.Click += new System.EventHandler(this.btnNovoEmail_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail.Location = new System.Drawing.Point(7, 271);
            this.txtEmail.MaxLength = 80;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(615, 23);
            this.txtEmail.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Email*";
            // 
            // dgvEmail
            // 
            this.dgvEmail.AllowUserToAddRows = false;
            this.dgvEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Email});
            this.dgvEmail.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvEmail.Location = new System.Drawing.Point(3, 3);
            this.dgvEmail.Name = "dgvEmail";
            this.dgvEmail.Size = new System.Drawing.Size(674, 236);
            this.dgvEmail.TabIndex = 0;
            this.dgvEmail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmail_CellClick);
            this.dgvEmail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvEmail_KeyUp);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.Width = 600;
            // 
            // frmRevenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 467);
            this.Name = "frmRevenda";
            this.Tag = "100";
            this.Text = "Revendas";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRevenda_KeyDown);
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
            this.tpEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rev_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rev_Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rev_Nome;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private Componentes.usrSoNumero txtCodigo;
        private System.Windows.Forms.TabPage tpEmail;
        private System.Windows.Forms.DataGridView dgvEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExcluirEmail;
        private System.Windows.Forms.Button btnSalvarEmail;
        private System.Windows.Forms.Button btnNovoEmail;
        private System.Windows.Forms.TextBox txtIdEmail;
    }
}