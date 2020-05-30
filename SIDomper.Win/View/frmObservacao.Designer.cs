namespace SIDomper.Win.View
{
    partial class frmObservacao
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
            this.Obs_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Obs_Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Obs_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new SIDomper.Win.Componentes.usrSoNumero();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.grPrograma = new System.Windows.Forms.GroupBox();
            this.rbOrcamento = new System.Windows.Forms.RadioButton();
            this.rbAgendamento = new System.Windows.Forms.RadioButton();
            this.rbAtividade = new System.Windows.Forms.RadioButton();
            this.rbBaseConh = new System.Windows.Forms.RadioButton();
            this.rbQualidade = new System.Windows.Forms.RadioButton();
            this.rbVersao = new System.Windows.Forms.RadioButton();
            this.rbSolicitacao = new System.Windows.Forms.RadioButton();
            this.rbVisita = new System.Windows.Forms.RadioButton();
            this.rbChamado = new System.Windows.Forms.RadioButton();
            this.chkPadrao = new System.Windows.Forms.CheckBox();
            this.tbEmail = new System.Windows.Forms.TabPage();
            this.chkEmailPadrao = new System.Windows.Forms.CheckBox();
            this.txtObsEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.grPrograma.SuspendLayout();
            this.tbEmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(705, 563);
            // 
            // tpPesquisa
            // 
            this.tpPesquisa.Controls.Add(this.dgvDados);
            this.tpPesquisa.Size = new System.Drawing.Size(697, 533);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.dgvDados, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(4, 466);
            this.groupBox2.Size = new System.Drawing.Size(689, 63);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(689, 60);
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
            this.tabControl2.Controls.Add(this.tbEmail);
            this.tabControl2.Controls.SetChildIndex(this.tbEmail, 0);
            this.tabControl2.Controls.SetChildIndex(this.tbPrincipal, 0);
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.Controls.Add(this.chkPadrao);
            this.tbPrincipal.Controls.Add(this.grPrograma);
            this.tbPrincipal.Controls.Add(this.txtDescricao);
            this.tbPrincipal.Controls.Add(this.label5);
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
            this.Obs_Id,
            this.Obs_Codigo,
            this.Obs_Nome});
            this.dgvDados.Location = new System.Drawing.Point(4, 68);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(689, 395);
            this.dgvDados.TabIndex = 3;
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_ColumnHeaderMouseClick);
            // 
            // Obs_Id
            // 
            this.Obs_Id.DataPropertyName = "Id";
            this.Obs_Id.HeaderText = "Id";
            this.Obs_Id.Name = "Obs_Id";
            this.Obs_Id.Visible = false;
            // 
            // Obs_Codigo
            // 
            this.Obs_Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.Format = "0000";
            this.Obs_Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Obs_Codigo.HeaderText = "Código";
            this.Obs_Codigo.Name = "Obs_Codigo";
            // 
            // Obs_Nome
            // 
            this.Obs_Nome.DataPropertyName = "Nome";
            this.Obs_Nome.HeaderText = "Nome";
            this.Obs_Nome.Name = "Obs_Nome";
            this.Obs_Nome.Width = 510;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(19, 393);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(61, 21);
            this.chkAtivo.TabIndex = 4;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(19, 83);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(655, 23);
            this.txtNome.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(19, 37);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(81, 25);
            this.txtCodigo.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Descrição*";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(19, 135);
            this.txtDescricao.MaxLength = 2000;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricao.Size = new System.Drawing.Size(655, 125);
            this.txtDescricao.TabIndex = 2;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescricao_KeyDown);
            this.txtDescricao.Leave += new System.EventHandler(this.txtDescricao_Leave);
            // 
            // grPrograma
            // 
            this.grPrograma.BackColor = System.Drawing.Color.Silver;
            this.grPrograma.Controls.Add(this.rbOrcamento);
            this.grPrograma.Controls.Add(this.rbAgendamento);
            this.grPrograma.Controls.Add(this.rbAtividade);
            this.grPrograma.Controls.Add(this.rbBaseConh);
            this.grPrograma.Controls.Add(this.rbQualidade);
            this.grPrograma.Controls.Add(this.rbVersao);
            this.grPrograma.Controls.Add(this.rbSolicitacao);
            this.grPrograma.Controls.Add(this.rbVisita);
            this.grPrograma.Controls.Add(this.rbChamado);
            this.grPrograma.Location = new System.Drawing.Point(19, 266);
            this.grPrograma.Name = "grPrograma";
            this.grPrograma.Size = new System.Drawing.Size(655, 100);
            this.grPrograma.TabIndex = 3;
            this.grPrograma.TabStop = false;
            this.grPrograma.Text = "Programa:";
            this.grPrograma.Leave += new System.EventHandler(this.grPrograma_Leave);
            // 
            // rbOrcamento
            // 
            this.rbOrcamento.AutoSize = true;
            this.rbOrcamento.Location = new System.Drawing.Point(355, 73);
            this.rbOrcamento.Name = "rbOrcamento";
            this.rbOrcamento.Size = new System.Drawing.Size(112, 21);
            this.rbOrcamento.TabIndex = 8;
            this.rbOrcamento.Text = "9-Orçamento";
            this.rbOrcamento.UseVisualStyleBackColor = true;
            // 
            // rbAgendamento
            // 
            this.rbAgendamento.AutoSize = true;
            this.rbAgendamento.Location = new System.Drawing.Point(355, 49);
            this.rbAgendamento.Name = "rbAgendamento";
            this.rbAgendamento.Size = new System.Drawing.Size(132, 21);
            this.rbAgendamento.TabIndex = 7;
            this.rbAgendamento.Text = "8-Agendamento";
            this.rbAgendamento.UseVisualStyleBackColor = true;
            // 
            // rbAtividade
            // 
            this.rbAtividade.AutoSize = true;
            this.rbAtividade.Location = new System.Drawing.Point(355, 22);
            this.rbAtividade.Name = "rbAtividade";
            this.rbAtividade.Size = new System.Drawing.Size(100, 21);
            this.rbAtividade.TabIndex = 6;
            this.rbAtividade.Text = "7-Atividade";
            this.rbAtividade.UseVisualStyleBackColor = true;
            // 
            // rbBaseConh
            // 
            this.rbBaseConh.AutoSize = true;
            this.rbBaseConh.Location = new System.Drawing.Point(175, 73);
            this.rbBaseConh.Name = "rbBaseConh";
            this.rbBaseConh.Size = new System.Drawing.Size(168, 21);
            this.rbBaseConh.TabIndex = 5;
            this.rbBaseConh.Text = "6-Base Conhecimento";
            this.rbBaseConh.UseVisualStyleBackColor = true;
            // 
            // rbQualidade
            // 
            this.rbQualidade.AutoSize = true;
            this.rbQualidade.Location = new System.Drawing.Point(175, 49);
            this.rbQualidade.Name = "rbQualidade";
            this.rbQualidade.Size = new System.Drawing.Size(106, 21);
            this.rbQualidade.TabIndex = 4;
            this.rbQualidade.Text = "5-Qualidade";
            this.rbQualidade.UseVisualStyleBackColor = true;
            // 
            // rbVersao
            // 
            this.rbVersao.AutoSize = true;
            this.rbVersao.Location = new System.Drawing.Point(175, 22);
            this.rbVersao.Name = "rbVersao";
            this.rbVersao.Size = new System.Drawing.Size(81, 21);
            this.rbVersao.TabIndex = 3;
            this.rbVersao.Text = "4-Versão";
            this.rbVersao.UseVisualStyleBackColor = true;
            // 
            // rbSolicitacao
            // 
            this.rbSolicitacao.AutoSize = true;
            this.rbSolicitacao.Location = new System.Drawing.Point(6, 76);
            this.rbSolicitacao.Name = "rbSolicitacao";
            this.rbSolicitacao.Size = new System.Drawing.Size(109, 21);
            this.rbSolicitacao.TabIndex = 2;
            this.rbSolicitacao.Text = "3-Solicitação";
            this.rbSolicitacao.UseVisualStyleBackColor = true;
            // 
            // rbVisita
            // 
            this.rbVisita.AutoSize = true;
            this.rbVisita.Location = new System.Drawing.Point(6, 49);
            this.rbVisita.Name = "rbVisita";
            this.rbVisita.Size = new System.Drawing.Size(71, 21);
            this.rbVisita.TabIndex = 1;
            this.rbVisita.Text = "2-Visita";
            this.rbVisita.UseVisualStyleBackColor = true;
            // 
            // rbChamado
            // 
            this.rbChamado.AutoSize = true;
            this.rbChamado.Checked = true;
            this.rbChamado.Location = new System.Drawing.Point(6, 22);
            this.rbChamado.Name = "rbChamado";
            this.rbChamado.Size = new System.Drawing.Size(105, 21);
            this.rbChamado.TabIndex = 0;
            this.rbChamado.TabStop = true;
            this.rbChamado.Text = "1-Chamado";
            this.rbChamado.UseVisualStyleBackColor = true;
            // 
            // chkPadrao
            // 
            this.chkPadrao.AutoSize = true;
            this.chkPadrao.Location = new System.Drawing.Point(86, 393);
            this.chkPadrao.Name = "chkPadrao";
            this.chkPadrao.Size = new System.Drawing.Size(75, 21);
            this.chkPadrao.TabIndex = 5;
            this.chkPadrao.Text = "Padrão";
            this.chkPadrao.UseVisualStyleBackColor = true;
            // 
            // tbEmail
            // 
            this.tbEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbEmail.Controls.Add(this.chkEmailPadrao);
            this.tbEmail.Controls.Add(this.txtObsEmail);
            this.tbEmail.Controls.Add(this.label6);
            this.tbEmail.Location = new System.Drawing.Point(4, 26);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Padding = new System.Windows.Forms.Padding(3);
            this.tbEmail.Size = new System.Drawing.Size(680, 483);
            this.tbEmail.TabIndex = 1;
            this.tbEmail.Text = "Email";
            // 
            // chkEmailPadrao
            // 
            this.chkEmailPadrao.AutoSize = true;
            this.chkEmailPadrao.Location = new System.Drawing.Point(19, 268);
            this.chkEmailPadrao.Name = "chkEmailPadrao";
            this.chkEmailPadrao.Size = new System.Drawing.Size(75, 21);
            this.chkEmailPadrao.TabIndex = 2;
            this.chkEmailPadrao.Text = "Padrão";
            this.chkEmailPadrao.UseVisualStyleBackColor = true;
            // 
            // txtObsEmail
            // 
            this.txtObsEmail.Location = new System.Drawing.Point(19, 43);
            this.txtObsEmail.MaxLength = 2000;
            this.txtObsEmail.Multiline = true;
            this.txtObsEmail.Name = "txtObsEmail";
            this.txtObsEmail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObsEmail.Size = new System.Drawing.Size(646, 204);
            this.txtObsEmail.TabIndex = 1;
            this.txtObsEmail.Enter += new System.EventHandler(this.txtObsEmail_Enter);
            this.txtObsEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtObsEmail_KeyDown);
            this.txtObsEmail.Leave += new System.EventHandler(this.txtObsEmail_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Observação para Email";
            // 
            // frmObservacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 563);
            this.Name = "frmObservacao";
            this.Tag = "116";
            this.Text = "Observações";
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
            this.grPrograma.ResumeLayout(false);
            this.grPrograma.PerformLayout();
            this.tbEmail.ResumeLayout(false);
            this.tbEmail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.GroupBox grPrograma;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private Componentes.usrSoNumero txtCodigo;
        private System.Windows.Forms.RadioButton rbOrcamento;
        private System.Windows.Forms.RadioButton rbAgendamento;
        private System.Windows.Forms.RadioButton rbAtividade;
        private System.Windows.Forms.RadioButton rbBaseConh;
        private System.Windows.Forms.RadioButton rbQualidade;
        private System.Windows.Forms.RadioButton rbVersao;
        private System.Windows.Forms.RadioButton rbSolicitacao;
        private System.Windows.Forms.RadioButton rbVisita;
        private System.Windows.Forms.RadioButton rbChamado;
        private System.Windows.Forms.CheckBox chkPadrao;
        private System.Windows.Forms.TabPage tbEmail;
        private System.Windows.Forms.CheckBox chkEmailPadrao;
        private System.Windows.Forms.TextBox txtObsEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Obs_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Obs_Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Obs_Nome;
    }
}