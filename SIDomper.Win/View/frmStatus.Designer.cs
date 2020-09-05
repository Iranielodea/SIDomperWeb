namespace SIDomper.Win.View
{
    partial class frmStatus
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
            this.Sta_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sta_Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sta_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomePrograma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new SIDomper.Win.Componentes.usrSoNumero();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbRecado = new System.Windows.Forms.RadioButton();
            this.rbAgendamento = new System.Windows.Forms.RadioButton();
            this.rbAtividade = new System.Windows.Forms.RadioButton();
            this.rbBaseConh = new System.Windows.Forms.RadioButton();
            this.rbQualidade = new System.Windows.Forms.RadioButton();
            this.rbVersao = new System.Windows.Forms.RadioButton();
            this.rbSolicitacao = new System.Windows.Forms.RadioButton();
            this.rbVisita = new System.Windows.Forms.RadioButton();
            this.rbChamado = new System.Windows.Forms.RadioButton();
            this.grNotificacao = new System.Windows.Forms.GroupBox();
            this.chkNotRevenda = new System.Windows.Forms.CheckBox();
            this.chkNotConsultor = new System.Windows.Forms.CheckBox();
            this.chkNotSupervisor = new System.Windows.Forms.CheckBox();
            this.chkNotCliente = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConceito = new System.Windows.Forms.TextBox();
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
            this.grNotificacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(705, 527);
            // 
            // tpPesquisa
            // 
            this.tpPesquisa.Controls.Add(this.dgvDados);
            this.tpPesquisa.Margin = new System.Windows.Forms.Padding(5);
            this.tpPesquisa.Padding = new System.Windows.Forms.Padding(5);
            this.tpPesquisa.Size = new System.Drawing.Size(697, 497);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.dgvDados, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(5, 429);
            this.groupBox2.Size = new System.Drawing.Size(687, 63);
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
            this.groupBox1.Size = new System.Drawing.Size(687, 60);
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
            this.tpEditar.Size = new System.Drawing.Size(697, 497);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(5, 429);
            this.groupBox3.Size = new System.Drawing.Size(687, 63);
            this.groupBox3.TabIndex = 6;
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
            this.tabControl2.Size = new System.Drawing.Size(687, 487);
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.Controls.Add(this.txtConceito);
            this.tbPrincipal.Controls.Add(this.label5);
            this.tbPrincipal.Controls.Add(this.grNotificacao);
            this.tbPrincipal.Controls.Add(this.groupBox5);
            this.tbPrincipal.Controls.Add(this.chkAtivo);
            this.tbPrincipal.Controls.Add(this.label4);
            this.tbPrincipal.Controls.Add(this.txtNome);
            this.tbPrincipal.Controls.Add(this.label3);
            this.tbPrincipal.Controls.Add(this.txtCodigo);
            this.tbPrincipal.Size = new System.Drawing.Size(679, 457);
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
            this.tabControl3.Location = new System.Drawing.Point(5, 5);
            this.tabControl3.Size = new System.Drawing.Size(686, 511);
            // 
            // tpFiltroPrincipal
            // 
            this.tpFiltroPrincipal.Size = new System.Drawing.Size(679, 457);
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
            this.Sta_Id,
            this.Sta_Codigo,
            this.Sta_Nome,
            this.NomePrograma});
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(5, 65);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(687, 364);
            this.dgvDados.TabIndex = 1;
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_ColumnHeaderMouseClick);
            // 
            // Sta_Id
            // 
            this.Sta_Id.DataPropertyName = "Id";
            this.Sta_Id.HeaderText = "Id";
            this.Sta_Id.Name = "Sta_Id";
            this.Sta_Id.Visible = false;
            // 
            // Sta_Codigo
            // 
            this.Sta_Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.Format = "0000";
            this.Sta_Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Sta_Codigo.HeaderText = "Código";
            this.Sta_Codigo.Name = "Sta_Codigo";
            // 
            // Sta_Nome
            // 
            this.Sta_Nome.DataPropertyName = "Nome";
            this.Sta_Nome.HeaderText = "Nome";
            this.Sta_Nome.Name = "Sta_Nome";
            this.Sta_Nome.Width = 250;
            // 
            // NomePrograma
            // 
            this.NomePrograma.DataPropertyName = "NomePrograma";
            this.NomePrograma.HeaderText = "Programa";
            this.NomePrograma.Name = "NomePrograma";
            this.NomePrograma.Width = 250;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(538, 373);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(61, 21);
            this.chkAtivo.TabIndex = 5;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(23, 83);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(582, 23);
            this.txtNome.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(23, 37);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(81, 26);
            this.txtCodigo.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Silver;
            this.groupBox5.Controls.Add(this.rbRecado);
            this.groupBox5.Controls.Add(this.rbAgendamento);
            this.groupBox5.Controls.Add(this.rbAtividade);
            this.groupBox5.Controls.Add(this.rbBaseConh);
            this.groupBox5.Controls.Add(this.rbQualidade);
            this.groupBox5.Controls.Add(this.rbVersao);
            this.groupBox5.Controls.Add(this.rbSolicitacao);
            this.groupBox5.Controls.Add(this.rbVisita);
            this.groupBox5.Controls.Add(this.rbChamado);
            this.groupBox5.Location = new System.Drawing.Point(23, 112);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(337, 176);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Programa:";
            // 
            // rbRecado
            // 
            this.rbRecado.AutoSize = true;
            this.rbRecado.Location = new System.Drawing.Point(163, 104);
            this.rbRecado.Name = "rbRecado";
            this.rbRecado.Size = new System.Drawing.Size(95, 21);
            this.rbRecado.TabIndex = 8;
            this.rbRecado.TabStop = true;
            this.rbRecado.Text = "10-Recado";
            this.rbRecado.UseVisualStyleBackColor = true;
            // 
            // rbAgendamento
            // 
            this.rbAgendamento.AutoSize = true;
            this.rbAgendamento.Location = new System.Drawing.Point(163, 77);
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
            this.rbAtividade.Location = new System.Drawing.Point(163, 50);
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
            this.rbBaseConh.Location = new System.Drawing.Point(163, 23);
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
            // grNotificacao
            // 
            this.grNotificacao.BackColor = System.Drawing.Color.Silver;
            this.grNotificacao.Controls.Add(this.chkNotRevenda);
            this.grNotificacao.Controls.Add(this.chkNotConsultor);
            this.grNotificacao.Controls.Add(this.chkNotSupervisor);
            this.grNotificacao.Controls.Add(this.chkNotCliente);
            this.grNotificacao.Location = new System.Drawing.Point(366, 112);
            this.grNotificacao.Name = "grNotificacao";
            this.grNotificacao.Size = new System.Drawing.Size(239, 176);
            this.grNotificacao.TabIndex = 3;
            this.grNotificacao.TabStop = false;
            this.grNotificacao.Text = "Notificação:";
            // 
            // chkNotRevenda
            // 
            this.chkNotRevenda.AutoSize = true;
            this.chkNotRevenda.Location = new System.Drawing.Point(16, 104);
            this.chkNotRevenda.Name = "chkNotRevenda";
            this.chkNotRevenda.Size = new System.Drawing.Size(144, 21);
            this.chkNotRevenda.TabIndex = 3;
            this.chkNotRevenda.Text = "Notificar Revenda";
            this.chkNotRevenda.UseVisualStyleBackColor = true;
            // 
            // chkNotConsultor
            // 
            this.chkNotConsultor.AutoSize = true;
            this.chkNotConsultor.Location = new System.Drawing.Point(16, 77);
            this.chkNotConsultor.Name = "chkNotConsultor";
            this.chkNotConsultor.Size = new System.Drawing.Size(148, 21);
            this.chkNotConsultor.TabIndex = 2;
            this.chkNotConsultor.Text = "Notificar Consultor";
            this.chkNotConsultor.UseVisualStyleBackColor = true;
            // 
            // chkNotSupervisor
            // 
            this.chkNotSupervisor.AutoSize = true;
            this.chkNotSupervisor.Location = new System.Drawing.Point(16, 49);
            this.chkNotSupervisor.Name = "chkNotSupervisor";
            this.chkNotSupervisor.Size = new System.Drawing.Size(150, 21);
            this.chkNotSupervisor.TabIndex = 1;
            this.chkNotSupervisor.Text = "Notificar Supervisor";
            this.chkNotSupervisor.UseVisualStyleBackColor = true;
            // 
            // chkNotCliente
            // 
            this.chkNotCliente.AutoSize = true;
            this.chkNotCliente.Location = new System.Drawing.Point(16, 23);
            this.chkNotCliente.Name = "chkNotCliente";
            this.chkNotCliente.Size = new System.Drawing.Size(132, 21);
            this.chkNotCliente.TabIndex = 0;
            this.chkNotCliente.Text = "Notificar Cliente";
            this.chkNotCliente.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Conceito";
            // 
            // txtConceito
            // 
            this.txtConceito.Location = new System.Drawing.Point(23, 313);
            this.txtConceito.Multiline = true;
            this.txtConceito.Name = "txtConceito";
            this.txtConceito.Size = new System.Drawing.Size(509, 81);
            this.txtConceito.TabIndex = 4;
            // 
            // frmStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 527);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmStatus";
            this.Tag = "107";
            this.Text = "Status";
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
            this.grNotificacao.ResumeLayout(false);
            this.grNotificacao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private Componentes.usrSoNumero txtCodigo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbChamado;
        private System.Windows.Forms.RadioButton rbRecado;
        private System.Windows.Forms.RadioButton rbAgendamento;
        private System.Windows.Forms.RadioButton rbAtividade;
        private System.Windows.Forms.RadioButton rbBaseConh;
        private System.Windows.Forms.RadioButton rbQualidade;
        private System.Windows.Forms.RadioButton rbVersao;
        private System.Windows.Forms.RadioButton rbSolicitacao;
        private System.Windows.Forms.RadioButton rbVisita;
        private System.Windows.Forms.GroupBox grNotificacao;
        private System.Windows.Forms.CheckBox chkNotRevenda;
        private System.Windows.Forms.CheckBox chkNotConsultor;
        private System.Windows.Forms.CheckBox chkNotSupervisor;
        private System.Windows.Forms.CheckBox chkNotCliente;
        private System.Windows.Forms.TextBox txtConceito;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sta_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sta_Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sta_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomePrograma;
    }
}