namespace SIDomper.Win.View
{
    partial class frmContaEmail
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
            this.CtaEm_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CtaEm_Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CtaEm_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CtaEm_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new SIDomper.Win.Componentes.usrSoNumero();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSMTP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkAutenticar = new System.Windows.Forms.CheckBox();
            this.chkAutenticarSSL = new System.Windows.Forms.CheckBox();
            this.txtPorta = new SIDomper.Win.Componentes.usrSoNumero();
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
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(705, 460);
            // 
            // tpPesquisa
            // 
            this.tpPesquisa.Controls.Add(this.dgvDados);
            this.tpPesquisa.Size = new System.Drawing.Size(697, 430);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.dgvDados, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(4, 363);
            this.groupBox2.Size = new System.Drawing.Size(689, 63);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(689, 60);
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(401, 33);
            this.txtTexto.Size = new System.Drawing.Size(256, 23);
            this.txtTexto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTexto_KeyDown);
            // 
            // cbCampos
            // 
            this.cbCampos.Size = new System.Drawing.Size(243, 25);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(398, 14);
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.Controls.Add(this.txtPorta);
            this.tbPrincipal.Controls.Add(this.chkAutenticarSSL);
            this.tbPrincipal.Controls.Add(this.chkAutenticar);
            this.tbPrincipal.Controls.Add(this.label8);
            this.tbPrincipal.Controls.Add(this.label7);
            this.tbPrincipal.Controls.Add(this.txtSenha);
            this.tbPrincipal.Controls.Add(this.label6);
            this.tbPrincipal.Controls.Add(this.txtSMTP);
            this.tbPrincipal.Controls.Add(this.label5);
            this.tbPrincipal.Controls.Add(this.txtEmail);
            this.tbPrincipal.Controls.Add(this.chkAtivo);
            this.tbPrincipal.Controls.Add(this.label4);
            this.tbPrincipal.Controls.Add(this.txtNome);
            this.tbPrincipal.Controls.Add(this.label3);
            this.tbPrincipal.Controls.Add(this.txtCodigo);
            this.tbPrincipal.Size = new System.Drawing.Size(681, 392);
            // 
            // tpFiltroPrincipal
            // 
            this.tpFiltroPrincipal.Size = new System.Drawing.Size(681, 392);
            // 
            // lblPesquisa
            // 
            this.lblPesquisa.Location = new System.Drawing.Point(258, 11);
            // 
            // cbPesquisa
            // 
            this.cbPesquisa.Location = new System.Drawing.Point(261, 31);
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CtaEm_Id,
            this.CtaEm_Codigo,
            this.CtaEm_Nome,
            this.CtaEm_Email});
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(4, 64);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(689, 299);
            this.dgvDados.TabIndex = 3;
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_ColumnHeaderMouseClick);
            // 
            // CtaEm_Id
            // 
            this.CtaEm_Id.DataPropertyName = "Id";
            this.CtaEm_Id.HeaderText = "Id";
            this.CtaEm_Id.Name = "CtaEm_Id";
            this.CtaEm_Id.Visible = false;
            // 
            // CtaEm_Codigo
            // 
            this.CtaEm_Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.Format = "0000";
            this.CtaEm_Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.CtaEm_Codigo.HeaderText = "Código";
            this.CtaEm_Codigo.Name = "CtaEm_Codigo";
            this.CtaEm_Codigo.Width = 80;
            // 
            // CtaEm_Nome
            // 
            this.CtaEm_Nome.DataPropertyName = "Nome";
            this.CtaEm_Nome.HeaderText = "Nome";
            this.CtaEm_Nome.Name = "CtaEm_Nome";
            this.CtaEm_Nome.Width = 270;
            // 
            // CtaEm_Email
            // 
            this.CtaEm_Email.DataPropertyName = "Email";
            this.CtaEm_Email.HeaderText = "Email";
            this.CtaEm_Email.Name = "CtaEm_Email";
            this.CtaEm_Email.Width = 270;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(19, 308);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(61, 21);
            this.chkAtivo.TabIndex = 6;
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
            this.txtNome.MaxLength = 60;
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
            this.txtCodigo.Location = new System.Drawing.Point(19, 33);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(81, 25);
            this.txtCodigo.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Email*";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(19, 129);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(549, 23);
            this.txtEmail.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "SMTP*";
            // 
            // txtSMTP
            // 
            this.txtSMTP.Location = new System.Drawing.Point(19, 176);
            this.txtSMTP.MaxLength = 100;
            this.txtSMTP.Name = "txtSMTP";
            this.txtSMTP.Size = new System.Drawing.Size(549, 23);
            this.txtSMTP.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Senha*";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(19, 225);
            this.txtSenha.MaxLength = 30;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(158, 23);
            this.txtSenha.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Porta*";
            // 
            // chkAutenticar
            // 
            this.chkAutenticar.AutoSize = true;
            this.chkAutenticar.Location = new System.Drawing.Point(107, 308);
            this.chkAutenticar.Name = "chkAutenticar";
            this.chkAutenticar.Size = new System.Drawing.Size(94, 21);
            this.chkAutenticar.TabIndex = 7;
            this.chkAutenticar.Text = "Autenticar";
            this.chkAutenticar.UseVisualStyleBackColor = true;
            // 
            // chkAutenticarSSL
            // 
            this.chkAutenticarSSL.AutoSize = true;
            this.chkAutenticarSSL.Location = new System.Drawing.Point(207, 308);
            this.chkAutenticarSSL.Name = "chkAutenticarSSL";
            this.chkAutenticarSSL.Size = new System.Drawing.Size(116, 21);
            this.chkAutenticarSSL.TabIndex = 8;
            this.chkAutenticarSSL.Text = "Autenticar SSL";
            this.chkAutenticarSSL.UseVisualStyleBackColor = true;
            // 
            // txtPorta
            // 
            this.txtPorta.Location = new System.Drawing.Point(25, 357);
            this.txtPorta.Margin = new System.Windows.Forms.Padding(4);
            this.txtPorta.Name = "txtPorta";
            this.txtPorta.Size = new System.Drawing.Size(133, 33);
            this.txtPorta.TabIndex = 5;
            // 
            // frmContaEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 460);
            this.Name = "frmContaEmail";
            this.Tag = "110";
            this.Text = "Contas Emails";
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.DataGridViewTextBoxColumn CtaEm_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CtaEm_Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CtaEm_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn CtaEm_Email;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private Componentes.usrSoNumero txtCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSMTP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private Componentes.usrSoNumero txtPorta;
        private System.Windows.Forms.CheckBox chkAutenticarSSL;
        private System.Windows.Forms.CheckBox chkAutenticar;
    }
}