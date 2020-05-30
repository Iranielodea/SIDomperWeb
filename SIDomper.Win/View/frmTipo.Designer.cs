namespace SIDomper.Win.View
{
    partial class frmTipo
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
            this.Tip_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tip_Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tip_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomePrograma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new SIDomper.Win.Componentes.usrSoNumero();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbOrcaNaoAprovado = new System.Windows.Forms.RadioButton();
            this.rbOrcamento = new System.Windows.Forms.RadioButton();
            this.rbRecado = new System.Windows.Forms.RadioButton();
            this.rbAgendamento = new System.Windows.Forms.RadioButton();
            this.rbAtividade = new System.Windows.Forms.RadioButton();
            this.rbBaseConh = new System.Windows.Forms.RadioButton();
            this.rbQualidade = new System.Windows.Forms.RadioButton();
            this.rbVersao = new System.Windows.Forms.RadioButton();
            this.rbSolicitacao = new System.Windows.Forms.RadioButton();
            this.rbVisita = new System.Windows.Forms.RadioButton();
            this.rbChamado = new System.Windows.Forms.RadioButton();
            this.txtConceito = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
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
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(705, 478);
            // 
            // tpPesquisa
            // 
            this.tpPesquisa.Controls.Add(this.dgvDados);
            this.tpPesquisa.Size = new System.Drawing.Size(697, 448);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.dgvDados, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(4, 381);
            this.groupBox2.Size = new System.Drawing.Size(689, 63);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(689, 60);
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
            this.tpEditar.Size = new System.Drawing.Size(697, 448);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(4, 381);
            this.groupBox3.Size = new System.Drawing.Size(689, 63);
            this.groupBox3.TabIndex = 6;
            // 
            // tabControl2
            // 
            this.tabControl2.Size = new System.Drawing.Size(689, 440);
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.Controls.Add(this.chkAtivo);
            this.tbPrincipal.Controls.Add(this.txtConceito);
            this.tbPrincipal.Controls.Add(this.label5);
            this.tbPrincipal.Controls.Add(this.groupBox5);
            this.tbPrincipal.Controls.Add(this.label4);
            this.tbPrincipal.Controls.Add(this.txtNome);
            this.tbPrincipal.Controls.Add(this.label3);
            this.tbPrincipal.Controls.Add(this.txtCodigo);
            this.tbPrincipal.Size = new System.Drawing.Size(681, 410);
            // 
            // tpFiltro
            // 
            this.tpFiltro.Size = new System.Drawing.Size(697, 448);
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(4, 381);
            this.groupBox4.Size = new System.Drawing.Size(689, 63);
            // 
            // tabControl3
            // 
            this.tabControl3.Size = new System.Drawing.Size(689, 440);
            // 
            // tpFiltroPrincipal
            // 
            this.tpFiltroPrincipal.Size = new System.Drawing.Size(681, 410);
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tip_Id,
            this.Tip_Codigo,
            this.Tip_Nome,
            this.NomePrograma});
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(4, 64);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(689, 317);
            this.dgvDados.TabIndex = 1;
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_ColumnHeaderMouseClick);
            // 
            // Tip_Id
            // 
            this.Tip_Id.DataPropertyName = "Id";
            this.Tip_Id.HeaderText = "Id";
            this.Tip_Id.Name = "Tip_Id";
            this.Tip_Id.Visible = false;
            // 
            // Tip_Codigo
            // 
            this.Tip_Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.Format = "0000";
            this.Tip_Codigo.DefaultCellStyle = dataGridViewCellStyle2;
            this.Tip_Codigo.HeaderText = "Código";
            this.Tip_Codigo.Name = "Tip_Codigo";
            // 
            // Tip_Nome
            // 
            this.Tip_Nome.DataPropertyName = "Nome";
            this.Tip_Nome.HeaderText = "Nome";
            this.Tip_Nome.Name = "Tip_Nome";
            this.Tip_Nome.Width = 250;
            // 
            // NomePrograma
            // 
            this.NomePrograma.DataPropertyName = "NomePrograma";
            this.NomePrograma.HeaderText = "Programa";
            this.NomePrograma.Name = "NomePrograma";
            this.NomePrograma.Width = 250;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(19, 76);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(640, 23);
            this.txtNome.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(19, 30);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(81, 25);
            this.txtCodigo.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Silver;
            this.groupBox5.Controls.Add(this.rbOrcaNaoAprovado);
            this.groupBox5.Controls.Add(this.rbOrcamento);
            this.groupBox5.Controls.Add(this.rbRecado);
            this.groupBox5.Controls.Add(this.rbAgendamento);
            this.groupBox5.Controls.Add(this.rbAtividade);
            this.groupBox5.Controls.Add(this.rbBaseConh);
            this.groupBox5.Controls.Add(this.rbQualidade);
            this.groupBox5.Controls.Add(this.rbVersao);
            this.groupBox5.Controls.Add(this.rbSolicitacao);
            this.groupBox5.Controls.Add(this.rbVisita);
            this.groupBox5.Controls.Add(this.rbChamado);
            this.groupBox5.Location = new System.Drawing.Point(19, 105);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(354, 211);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Programa:";
            // 
            // rbOrcaNaoAprovado
            // 
            this.rbOrcaNaoAprovado.AutoSize = true;
            this.rbOrcaNaoAprovado.Location = new System.Drawing.Point(128, 103);
            this.rbOrcaNaoAprovado.Name = "rbOrcaNaoAprovado";
            this.rbOrcaNaoAprovado.Size = new System.Drawing.Size(223, 21);
            this.rbOrcaNaoAprovado.TabIndex = 9;
            this.rbOrcaNaoAprovado.TabStop = true;
            this.rbOrcaNaoAprovado.Text = "9.1-Orçamento não Aprovado";
            this.rbOrcaNaoAprovado.UseVisualStyleBackColor = true;
            // 
            // rbOrcamento
            // 
            this.rbOrcamento.AutoSize = true;
            this.rbOrcamento.Location = new System.Drawing.Point(128, 76);
            this.rbOrcamento.Name = "rbOrcamento";
            this.rbOrcamento.Size = new System.Drawing.Size(112, 21);
            this.rbOrcamento.TabIndex = 8;
            this.rbOrcamento.TabStop = true;
            this.rbOrcamento.Text = "9-Orçamento";
            this.rbOrcamento.UseVisualStyleBackColor = true;
            // 
            // rbRecado
            // 
            this.rbRecado.AutoSize = true;
            this.rbRecado.Location = new System.Drawing.Point(128, 130);
            this.rbRecado.Name = "rbRecado";
            this.rbRecado.Size = new System.Drawing.Size(95, 21);
            this.rbRecado.TabIndex = 10;
            this.rbRecado.TabStop = true;
            this.rbRecado.Text = "10-Recado";
            this.rbRecado.UseVisualStyleBackColor = true;
            // 
            // rbAgendamento
            // 
            this.rbAgendamento.AutoSize = true;
            this.rbAgendamento.Location = new System.Drawing.Point(128, 49);
            this.rbAgendamento.Name = "rbAgendamento";
            this.rbAgendamento.Size = new System.Drawing.Size(132, 21);
            this.rbAgendamento.TabIndex = 7;
            this.rbAgendamento.TabStop = true;
            this.rbAgendamento.Text = "8-Agendamento";
            this.rbAgendamento.UseVisualStyleBackColor = true;
            // 
            // rbAtividade
            // 
            this.rbAtividade.AutoSize = true;
            this.rbAtividade.Location = new System.Drawing.Point(128, 22);
            this.rbAtividade.Name = "rbAtividade";
            this.rbAtividade.Size = new System.Drawing.Size(100, 21);
            this.rbAtividade.TabIndex = 6;
            this.rbAtividade.TabStop = true;
            this.rbAtividade.Text = "7-Atividade";
            this.rbAtividade.UseVisualStyleBackColor = true;
            // 
            // rbBaseConh
            // 
            this.rbBaseConh.AutoSize = true;
            this.rbBaseConh.Location = new System.Drawing.Point(17, 157);
            this.rbBaseConh.Name = "rbBaseConh";
            this.rbBaseConh.Size = new System.Drawing.Size(168, 21);
            this.rbBaseConh.TabIndex = 5;
            this.rbBaseConh.TabStop = true;
            this.rbBaseConh.Text = "6-Base Conhecimento";
            this.rbBaseConh.UseVisualStyleBackColor = true;
            // 
            // rbQualidade
            // 
            this.rbQualidade.AutoSize = true;
            this.rbQualidade.Location = new System.Drawing.Point(17, 130);
            this.rbQualidade.Name = "rbQualidade";
            this.rbQualidade.Size = new System.Drawing.Size(106, 21);
            this.rbQualidade.TabIndex = 4;
            this.rbQualidade.TabStop = true;
            this.rbQualidade.Text = "5-Qualidade";
            this.rbQualidade.UseVisualStyleBackColor = true;
            // 
            // rbVersao
            // 
            this.rbVersao.AutoSize = true;
            this.rbVersao.Location = new System.Drawing.Point(17, 103);
            this.rbVersao.Name = "rbVersao";
            this.rbVersao.Size = new System.Drawing.Size(81, 21);
            this.rbVersao.TabIndex = 3;
            this.rbVersao.TabStop = true;
            this.rbVersao.Text = "4-Versão";
            this.rbVersao.UseVisualStyleBackColor = true;
            // 
            // rbSolicitacao
            // 
            this.rbSolicitacao.AutoSize = true;
            this.rbSolicitacao.Location = new System.Drawing.Point(17, 76);
            this.rbSolicitacao.Name = "rbSolicitacao";
            this.rbSolicitacao.Size = new System.Drawing.Size(109, 21);
            this.rbSolicitacao.TabIndex = 2;
            this.rbSolicitacao.TabStop = true;
            this.rbSolicitacao.Text = "3-Solicitação";
            this.rbSolicitacao.UseVisualStyleBackColor = true;
            // 
            // rbVisita
            // 
            this.rbVisita.AutoSize = true;
            this.rbVisita.Location = new System.Drawing.Point(17, 49);
            this.rbVisita.Name = "rbVisita";
            this.rbVisita.Size = new System.Drawing.Size(71, 21);
            this.rbVisita.TabIndex = 1;
            this.rbVisita.TabStop = true;
            this.rbVisita.Text = "2-Visita";
            this.rbVisita.UseVisualStyleBackColor = true;
            // 
            // rbChamado
            // 
            this.rbChamado.AutoSize = true;
            this.rbChamado.Location = new System.Drawing.Point(17, 22);
            this.rbChamado.Name = "rbChamado";
            this.rbChamado.Size = new System.Drawing.Size(105, 21);
            this.rbChamado.TabIndex = 0;
            this.rbChamado.TabStop = true;
            this.rbChamado.Text = "1-Chamado";
            this.rbChamado.UseVisualStyleBackColor = true;
            // 
            // txtConceito
            // 
            this.txtConceito.Location = new System.Drawing.Point(379, 127);
            this.txtConceito.Multiline = true;
            this.txtConceito.Name = "txtConceito";
            this.txtConceito.Size = new System.Drawing.Size(280, 189);
            this.txtConceito.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(379, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Conceito";
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(19, 322);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(61, 21);
            this.chkAtivo.TabIndex = 4;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // frmTipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 478);
            this.Name = "frmTipo";
            this.Tag = "106";
            this.Text = "Tipos";
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private Componentes.usrSoNumero txtCodigo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbRecado;
        private System.Windows.Forms.RadioButton rbAgendamento;
        private System.Windows.Forms.RadioButton rbAtividade;
        private System.Windows.Forms.RadioButton rbBaseConh;
        private System.Windows.Forms.RadioButton rbQualidade;
        private System.Windows.Forms.RadioButton rbVersao;
        private System.Windows.Forms.RadioButton rbSolicitacao;
        private System.Windows.Forms.RadioButton rbVisita;
        private System.Windows.Forms.RadioButton rbChamado;
        private System.Windows.Forms.TextBox txtConceito;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tip_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tip_Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tip_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomePrograma;
        private System.Windows.Forms.RadioButton rbOrcaNaoAprovado;
        private System.Windows.Forms.RadioButton rbOrcamento;
    }
}