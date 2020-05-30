namespace SIDomper.Win.View
{
    partial class frmTrocaStatus
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
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtNomeTipo = new System.Windows.Forms.TextBox();
            this.btnTipo = new System.Windows.Forms.Button();
            this.txtIdTipo = new System.Windows.Forms.TextBox();
            this.txtIdStatus = new System.Windows.Forms.TextBox();
            this.btnStatus = new System.Windows.Forms.Button();
            this.txtNomeStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtCodStatus = new SIDomper.Win.Componentes.usrSoNumero();
            this.txtCodTipo = new SIDomper.Win.Componentes.usrSoNumero();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(23, 26);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(40, 17);
            this.lblTipo.TabIndex = 1;
            this.lblTipo.Text = "Tipo*";
            // 
            // txtNomeTipo
            // 
            this.txtNomeTipo.Location = new System.Drawing.Point(99, 48);
            this.txtNomeTipo.Name = "txtNomeTipo";
            this.txtNomeTipo.Size = new System.Drawing.Size(430, 23);
            this.txtNomeTipo.TabIndex = 1;
            this.txtNomeTipo.Leave += new System.EventHandler(this.txtNomeTipo_Leave);
            // 
            // btnTipo
            // 
            this.btnTipo.Location = new System.Drawing.Point(535, 48);
            this.btnTipo.Name = "btnTipo";
            this.btnTipo.Size = new System.Drawing.Size(35, 23);
            this.btnTipo.TabIndex = 3;
            this.btnTipo.TabStop = false;
            this.btnTipo.Text = "...";
            this.btnTipo.UseVisualStyleBackColor = true;
            this.btnTipo.Click += new System.EventHandler(this.btnTipo_Click);
            // 
            // txtIdTipo
            // 
            this.txtIdTipo.Location = new System.Drawing.Point(576, 48);
            this.txtIdTipo.Name = "txtIdTipo";
            this.txtIdTipo.Size = new System.Drawing.Size(27, 23);
            this.txtIdTipo.TabIndex = 4;
            this.txtIdTipo.Visible = false;
            // 
            // txtIdStatus
            // 
            this.txtIdStatus.Location = new System.Drawing.Point(576, 100);
            this.txtIdStatus.Name = "txtIdStatus";
            this.txtIdStatus.Size = new System.Drawing.Size(27, 23);
            this.txtIdStatus.TabIndex = 9;
            this.txtIdStatus.Visible = false;
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(535, 100);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(35, 23);
            this.btnStatus.TabIndex = 8;
            this.btnStatus.TabStop = false;
            this.btnStatus.Text = "...";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // txtNomeStatus
            // 
            this.txtNomeStatus.Location = new System.Drawing.Point(99, 100);
            this.txtNomeStatus.Name = "txtNomeStatus";
            this.txtNomeStatus.Size = new System.Drawing.Size(430, 23);
            this.txtNomeStatus.TabIndex = 3;
            this.txtNomeStatus.Leave += new System.EventHandler(this.txtNomeStatus_Leave);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(23, 78);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 17);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status*";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnConfirmar);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 60);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Location = new System.Drawing.Point(298, 14);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 40);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.Location = new System.Drawing.Point(189, 14);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(103, 40);
            this.btnConfirmar.TabIndex = 0;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtCodStatus
            // 
            this.txtCodStatus.Location = new System.Drawing.Point(26, 98);
            this.txtCodStatus.Name = "txtCodStatus";
            this.txtCodStatus.Size = new System.Drawing.Size(67, 25);
            this.txtCodStatus.TabIndex = 2;
            this.txtCodStatus.Leave += new System.EventHandler(this.txtCodStatus_Leave);
            // 
            // txtCodTipo
            // 
            this.txtCodTipo.Location = new System.Drawing.Point(26, 46);
            this.txtCodTipo.Name = "txtCodTipo";
            this.txtCodTipo.Size = new System.Drawing.Size(67, 25);
            this.txtCodTipo.TabIndex = 0;
            this.txtCodTipo.Leave += new System.EventHandler(this.txtCodTipo_Leave);
            // 
            // frmTrocaStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 210);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtIdStatus);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.txtNomeStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtCodStatus);
            this.Controls.Add(this.txtIdTipo);
            this.Controls.Add(this.btnTipo);
            this.Controls.Add(this.txtNomeTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtCodTipo);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTrocaStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Situação";
            this.Shown += new System.EventHandler(this.frmTrocaStatus_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTrocaStatus_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmTrocaStatus_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Button btnTipo;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        public Componentes.usrSoNumero txtCodTipo;
        public System.Windows.Forms.TextBox txtNomeTipo;
        public System.Windows.Forms.TextBox txtIdTipo;
        public System.Windows.Forms.TextBox txtIdStatus;
        public System.Windows.Forms.TextBox txtNomeStatus;
        public Componentes.usrSoNumero txtCodStatus;
    }
}