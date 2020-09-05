namespace SIDomper.Win.View
{
    partial class frmFeriado
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
            this.Fer_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fer_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fer_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtData = new SIDomper.Win.Componentes.usrData();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            this.tabControl1.Size = new System.Drawing.Size(705, 450);
            // 
            // tpPesquisa
            // 
            this.tpPesquisa.Controls.Add(this.dgvDados);
            this.tpPesquisa.Margin = new System.Windows.Forms.Padding(5);
            this.tpPesquisa.Padding = new System.Windows.Forms.Padding(5);
            this.tpPesquisa.Size = new System.Drawing.Size(697, 420);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpPesquisa.Controls.SetChildIndex(this.dgvDados, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(5, 352);
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
            this.cbCampos.Size = new System.Drawing.Size(218, 25);
            // 
            // tpEditar
            // 
            this.tpEditar.Margin = new System.Windows.Forms.Padding(5);
            this.tpEditar.Padding = new System.Windows.Forms.Padding(5);
            this.tpEditar.Size = new System.Drawing.Size(697, 420);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(5, 352);
            this.groupBox3.Size = new System.Drawing.Size(687, 63);
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
            this.tabControl2.Size = new System.Drawing.Size(687, 410);
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.Controls.Add(this.label5);
            this.tbPrincipal.Controls.Add(this.label4);
            this.tbPrincipal.Controls.Add(this.txtDescricao);
            this.tbPrincipal.Controls.Add(this.txtData);
            this.tbPrincipal.Size = new System.Drawing.Size(679, 380);
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
            this.btnVoltar.Location = new System.Drawing.Point(221, 19);
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
            this.tpFiltroPrincipal.Size = new System.Drawing.Size(679, 380);
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
            this.Fer_Id,
            this.Fer_Data,
            this.Fer_Descricao});
            this.dgvDados.Location = new System.Drawing.Point(4, 68);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(688, 285);
            this.dgvDados.TabIndex = 1;
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_ColumnHeaderMouseClick);
            // 
            // Fer_Id
            // 
            this.Fer_Id.DataPropertyName = "Id";
            this.Fer_Id.HeaderText = "Id";
            this.Fer_Id.Name = "Fer_Id";
            this.Fer_Id.Visible = false;
            // 
            // Fer_Data
            // 
            this.Fer_Data.DataPropertyName = "Data";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.Fer_Data.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fer_Data.HeaderText = "Data";
            this.Fer_Data.Name = "Fer_Data";
            // 
            // Fer_Descricao
            // 
            this.Fer_Descricao.DataPropertyName = "Descricao";
            this.Fer_Descricao.HeaderText = "Descrição";
            this.Fer_Descricao.Name = "Fer_Descricao";
            this.Fer_Descricao.Width = 510;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(24, 45);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(80, 25);
            this.txtData.TabIndex = 0;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(24, 101);
            this.txtDescricao.MaxLength = 100;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(455, 23);
            this.txtDescricao.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Descrição";
            // 
            // frmFeriado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 450);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmFeriado";
            this.Tag = "123";
            this.Text = "Feriados";
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescricao;
        private Componentes.usrData txtData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fer_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fer_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fer_Descricao;
    }
}