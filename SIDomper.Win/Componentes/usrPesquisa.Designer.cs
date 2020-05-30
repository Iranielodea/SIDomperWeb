namespace SIDomper.Win.Componentes
{
    partial class usrPesquisa
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNome = new System.Windows.Forms.Label();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtCodigo = new SIDomper.Win.Componentes.usrSoNumero();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(-1, 1);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(47, 17);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "label1";
            // 
            // btnConsulta
            // 
            this.btnConsulta.Location = new System.Drawing.Point(71, 21);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(38, 24);
            this.btnConsulta.TabIndex = 2;
            this.btnConsulta.TabStop = false;
            this.btnConsulta.Text = "...";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.Location = new System.Drawing.Point(113, 21);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(459, 23);
            this.txtNome.TabIndex = 3;
            this.txtNome.Leave += new System.EventHandler(this.txtNome_Leave);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.DarkGray;
            this.txtId.Location = new System.Drawing.Point(158, 3);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(27, 23);
            this.txtId.TabIndex = 4;
            this.txtId.TabStop = false;
            this.txtId.Visible = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(0, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(70, 25);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // usrPesquisa
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtCodigo);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "usrPesquisa";
            this.Size = new System.Drawing.Size(576, 49);
            this.Enter += new System.EventHandler(this.usrPesquisa_Enter);
            this.Resize += new System.EventHandler(this.usrPesquisa_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public usrSoNumero txtCodigo;
        public System.Windows.Forms.Label lblNome;
        public System.Windows.Forms.Button btnConsulta;
        public System.Windows.Forms.TextBox txtNome;
        public System.Windows.Forms.TextBox txtId;
    }
}
