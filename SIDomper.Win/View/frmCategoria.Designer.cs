namespace SIDomper.Win.View
{
    partial class frmCategoria
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
            this.Cat_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cat_Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cat_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigo = new SIDomper.Win.Componentes.usrSoNumero();
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
            this.tbPrincipal.Controls.Add(this.chkAtivo);
            this.tbPrincipal.Controls.Add(this.label4);
            this.tbPrincipal.Controls.Add(this.txtNome);
            this.tbPrincipal.Controls.Add(this.label5);
            this.tbPrincipal.Controls.Add(this.txtCodigo);
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
            this.btnVoltar.Location = new System.Drawing.Point(221, 18);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(118, 19);
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
            this.tpFiltroPrincipal.Size = new System.Drawing.Size(678, 481);
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
            this.Cat_Id,
            this.Cat_Codigo,
            this.Cat_Nome});
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(5, 65);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(687, 287);
            this.dgvDados.TabIndex = 3;
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_ColumnHeaderMouseClick);
            // 
            // Cat_Id
            // 
            this.Cat_Id.DataPropertyName = "Id";
            this.Cat_Id.HeaderText = "Id";
            this.Cat_Id.Name = "Cat_Id";
            this.Cat_Id.Visible = false;
            // 
            // Cat_Codigo
            // 
            this.Cat_Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.Format = "0000";
            this.Cat_Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Cat_Codigo.HeaderText = "Código";
            this.Cat_Codigo.Name = "Cat_Codigo";
            // 
            // Cat_Nome
            // 
            this.Cat_Nome.DataPropertyName = "Nome";
            this.Cat_Nome.HeaderText = "Nome";
            this.Cat_Nome.Name = "Cat_Nome";
            this.Cat_Nome.Width = 510;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(11, 110);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(61, 21);
            this.chkAtivo.TabIndex = 2;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(11, 81);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(549, 23);
            this.txtNome.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(11, 35);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(81, 25);
            this.txtCodigo.TabIndex = 0;
            // 
            // frmCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 450);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmCategoria";
            this.Tag = "124";
            this.Text = "Categorias";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Cat_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cat_Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cat_Nome;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label5;
        private Componentes.usrSoNumero txtCodigo;
    }
}