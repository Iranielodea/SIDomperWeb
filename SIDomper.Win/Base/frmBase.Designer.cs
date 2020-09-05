namespace SIDomper.Win.Base
{
    partial class frmBase
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPesquisa = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPesquisa = new System.Windows.Forms.Label();
            this.cbPesquisa = new System.Windows.Forms.ComboBox();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.cbCampos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpEditar = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnVoltar2 = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tbPrincipal = new System.Windows.Forms.TabPage();
            this.tpFiltro = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tpFiltroPrincipal = new System.Windows.Forms.TabPage();
            this.cboAtivo = new System.Windows.Forms.ComboBox();
            this.lblAtivo = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tpPesquisa.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpEditar.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tpFiltro.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tpFiltroPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPesquisa);
            this.tabControl1.Controls.Add(this.tpEditar);
            this.tabControl1.Controls.Add(this.tpFiltro);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(704, 551);
            this.tabControl1.TabIndex = 2;
            // 
            // tpPesquisa
            // 
            this.tpPesquisa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpPesquisa.Controls.Add(this.groupBox2);
            this.tpPesquisa.Controls.Add(this.groupBox1);
            this.tpPesquisa.Location = new System.Drawing.Point(4, 26);
            this.tpPesquisa.Margin = new System.Windows.Forms.Padding(4);
            this.tpPesquisa.Name = "tpPesquisa";
            this.tpPesquisa.Padding = new System.Windows.Forms.Padding(4);
            this.tpPesquisa.Size = new System.Drawing.Size(696, 521);
            this.tpPesquisa.TabIndex = 0;
            this.tpPesquisa.Text = "Consulta";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.Controls.Add(this.btnFiltro);
            this.groupBox2.Controls.Add(this.btnSair);
            this.groupBox2.Controls.Add(this.btnExcluir);
            this.groupBox2.Controls.Add(this.btnEditar);
            this.groupBox2.Controls.Add(this.btnNovo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(4, 454);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(688, 63);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnFiltro
            // 
            this.btnFiltro.BackColor = System.Drawing.Color.Transparent;
            this.btnFiltro.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltro.ImageIndex = 3;
            this.btnFiltro.Location = new System.Drawing.Point(376, 20);
            this.btnFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(93, 39);
            this.btnFiltro.TabIndex = 3;
            this.btnFiltro.Text = "&Filtrar";
            this.toolTip1.SetToolTip(this.btnFiltro, "F3");
            this.btnFiltro.UseVisualStyleBackColor = false;
            // 
            // btnSair
            // 
            this.btnSair.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.ImageIndex = 4;
            this.btnSair.Location = new System.Drawing.Point(283, 20);
            this.btnSair.Margin = new System.Windows.Forms.Padding(4);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(93, 39);
            this.btnSair.TabIndex = 4;
            this.btnSair.Text = "&Sair";
            this.toolTip1.SetToolTip(this.btnSair, "Esc");
            this.btnSair.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.ImageIndex = 2;
            this.btnExcluir.Location = new System.Drawing.Point(190, 20);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(93, 39);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "E&xcluir";
            this.toolTip1.SetToolTip(this.btnExcluir, "Ctrl + del");
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.ImageIndex = 1;
            this.btnEditar.Location = new System.Drawing.Point(97, 20);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(93, 39);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "&Editar";
            this.toolTip1.SetToolTip(this.btnEditar, "F2");
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            this.btnNovo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.ImageIndex = 0;
            this.btnNovo.Location = new System.Drawing.Point(4, 20);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(93, 39);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "&Novo";
            this.toolTip1.SetToolTip(this.btnNovo, "Insert");
            this.btnNovo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gray;
            this.groupBox1.Controls.Add(this.lblPesquisa);
            this.groupBox1.Controls.Add(this.cbPesquisa);
            this.groupBox1.Controls.Add(this.txtTexto);
            this.groupBox1.Controls.Add(this.cbCampos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(688, 60);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lblPesquisa
            // 
            this.lblPesquisa.AutoSize = true;
            this.lblPesquisa.Location = new System.Drawing.Point(233, 10);
            this.lblPesquisa.Name = "lblPesquisa";
            this.lblPesquisa.Size = new System.Drawing.Size(63, 17);
            this.lblPesquisa.TabIndex = 5;
            this.lblPesquisa.Text = "Pesquisa";
            // 
            // cbPesquisa
            // 
            this.cbPesquisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPesquisa.FormattingEnabled = true;
            this.cbPesquisa.Items.AddRange(new object[] {
            "Contêm",
            "Iniciais"});
            this.cbPesquisa.Location = new System.Drawing.Point(236, 30);
            this.cbPesquisa.Name = "cbPesquisa";
            this.cbPesquisa.Size = new System.Drawing.Size(133, 25);
            this.cbPesquisa.TabIndex = 3;
            this.cbPesquisa.TabStop = false;
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(376, 31);
            this.txtTexto.Margin = new System.Windows.Forms.Padding(4);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(295, 23);
            this.txtTexto.TabIndex = 4;
            this.txtTexto.Enter += new System.EventHandler(this.txtTexto_Enter);
            // 
            // cbCampos
            // 
            this.cbCampos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCampos.FormattingEnabled = true;
            this.cbCampos.Location = new System.Drawing.Point(11, 29);
            this.cbCampos.Margin = new System.Windows.Forms.Padding(4);
            this.cbCampos.Name = "cbCampos";
            this.cbCampos.Size = new System.Drawing.Size(218, 25);
            this.cbCampos.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Texto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Campos";
            // 
            // tpEditar
            // 
            this.tpEditar.Controls.Add(this.groupBox3);
            this.tpEditar.Controls.Add(this.tabControl2);
            this.tpEditar.Location = new System.Drawing.Point(4, 26);
            this.tpEditar.Margin = new System.Windows.Forms.Padding(4);
            this.tpEditar.Name = "tpEditar";
            this.tpEditar.Padding = new System.Windows.Forms.Padding(4);
            this.tpEditar.Size = new System.Drawing.Size(696, 521);
            this.tpEditar.TabIndex = 2;
            this.tpEditar.Text = "Editar";
            this.tpEditar.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox3.Controls.Add(this.btnVoltar2);
            this.groupBox3.Controls.Add(this.btnSalvar);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(4, 454);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(688, 63);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // btnVoltar2
            // 
            this.btnVoltar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnVoltar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar2.ImageIndex = 6;
            this.btnVoltar2.Location = new System.Drawing.Point(97, 20);
            this.btnVoltar2.Margin = new System.Windows.Forms.Padding(4);
            this.btnVoltar2.Name = "btnVoltar2";
            this.btnVoltar2.Size = new System.Drawing.Size(93, 39);
            this.btnVoltar2.TabIndex = 4;
            this.btnVoltar2.Text = "&Voltar";
            this.toolTip1.SetToolTip(this.btnVoltar2, "Esc");
            this.btnVoltar2.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.ImageIndex = 5;
            this.btnSalvar.Location = new System.Drawing.Point(4, 20);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(93, 39);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "&Salvar";
            this.toolTip1.SetToolTip(this.btnSalvar, "F8");
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tbPrincipal);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(4, 4);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(688, 513);
            this.tabControl2.TabIndex = 0;
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbPrincipal.Location = new System.Drawing.Point(4, 26);
            this.tbPrincipal.Margin = new System.Windows.Forms.Padding(4);
            this.tbPrincipal.Name = "tbPrincipal";
            this.tbPrincipal.Padding = new System.Windows.Forms.Padding(4);
            this.tbPrincipal.Size = new System.Drawing.Size(680, 483);
            this.tbPrincipal.TabIndex = 0;
            this.tbPrincipal.Text = "Principal";
            // 
            // tpFiltro
            // 
            this.tpFiltro.Controls.Add(this.groupBox4);
            this.tpFiltro.Controls.Add(this.tabControl3);
            this.tpFiltro.Location = new System.Drawing.Point(4, 26);
            this.tpFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.tpFiltro.Name = "tpFiltro";
            this.tpFiltro.Padding = new System.Windows.Forms.Padding(4);
            this.tpFiltro.Size = new System.Drawing.Size(696, 521);
            this.tpFiltro.TabIndex = 1;
            this.tpFiltro.Text = "Filtro";
            this.tpFiltro.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox4.Controls.Add(this.btnVoltar);
            this.groupBox4.Controls.Add(this.btnImprimir);
            this.groupBox4.Controls.Add(this.btnFiltrar);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(4, 454);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(688, 63);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar.ImageIndex = 6;
            this.btnVoltar.Location = new System.Drawing.Point(210, 15);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(4);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(93, 40);
            this.btnVoltar.TabIndex = 6;
            this.btnVoltar.Text = "&Voltar";
            this.toolTip1.SetToolTip(this.btnVoltar, "Esc");
            this.btnVoltar.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.ImageIndex = 7;
            this.btnImprimir.Location = new System.Drawing.Point(109, 15);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(93, 40);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Tag = "";
            this.btnImprimir.Text = "&Imprimir";
            this.toolTip1.SetToolTip(this.btnImprimir, "F5");
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.ImageIndex = 3;
            this.btnFiltrar.Location = new System.Drawing.Point(8, 14);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(93, 40);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Tag = "";
            this.btnFiltrar.Text = "&Filtrar";
            this.toolTip1.SetToolTip(this.btnFiltrar, "F4");
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tpFiltroPrincipal);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(4, 4);
            this.tabControl3.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(688, 513);
            this.tabControl3.TabIndex = 1;
            // 
            // tpFiltroPrincipal
            // 
            this.tpFiltroPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpFiltroPrincipal.Controls.Add(this.cboAtivo);
            this.tpFiltroPrincipal.Controls.Add(this.lblAtivo);
            this.tpFiltroPrincipal.Location = new System.Drawing.Point(4, 26);
            this.tpFiltroPrincipal.Margin = new System.Windows.Forms.Padding(4);
            this.tpFiltroPrincipal.Name = "tpFiltroPrincipal";
            this.tpFiltroPrincipal.Padding = new System.Windows.Forms.Padding(4);
            this.tpFiltroPrincipal.Size = new System.Drawing.Size(680, 483);
            this.tpFiltroPrincipal.TabIndex = 0;
            this.tpFiltroPrincipal.Text = "Principal";
            // 
            // cboAtivo
            // 
            this.cboAtivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAtivo.FormattingEnabled = true;
            this.cboAtivo.Items.AddRange(new object[] {
            "Ativo",
            "Inativo",
            "Todos"});
            this.cboAtivo.Location = new System.Drawing.Point(25, 42);
            this.cboAtivo.Name = "cboAtivo";
            this.cboAtivo.Size = new System.Drawing.Size(121, 25);
            this.cboAtivo.TabIndex = 1;
            this.cboAtivo.TabStop = false;
            // 
            // lblAtivo
            // 
            this.lblAtivo.AutoSize = true;
            this.lblAtivo.Location = new System.Drawing.Point(22, 22);
            this.lblAtivo.Name = "lblAtivo";
            this.lblAtivo.Size = new System.Drawing.Size(65, 17);
            this.lblAtivo.TabIndex = 0;
            this.lblAtivo.Text = "Situação";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 551);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBase";
            this.Shown += new System.EventHandler(this.frmBase_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBase_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmBase_KeyPress);
            this.tabControl1.ResumeLayout(false);
            this.tpPesquisa.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpEditar.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tpFiltro.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tpFiltroPrincipal.ResumeLayout(false);
            this.tpFiltroPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tpPesquisa;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button btnFiltro;
        public System.Windows.Forms.Button btnSair;
        public System.Windows.Forms.Button btnExcluir;
        public System.Windows.Forms.Button btnEditar;
        public System.Windows.Forms.Button btnNovo;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtTexto;
        public System.Windows.Forms.ComboBox cbCampos;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TabPage tpEditar;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Button btnVoltar2;
        public System.Windows.Forms.Button btnSalvar;
        public System.Windows.Forms.TabControl tabControl2;
        public System.Windows.Forms.TabPage tbPrincipal;
        public System.Windows.Forms.TabPage tpFiltro;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Button btnVoltar;
        public System.Windows.Forms.Button btnImprimir;
        public System.Windows.Forms.Button btnFiltrar;
        public System.Windows.Forms.TabControl tabControl3;
        public System.Windows.Forms.TabPage tpFiltroPrincipal;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.ComboBox cboAtivo;
        public System.Windows.Forms.Label lblAtivo;
        public System.Windows.Forms.Label lblPesquisa;
        public System.Windows.Forms.ComboBox cbPesquisa;
    }
}