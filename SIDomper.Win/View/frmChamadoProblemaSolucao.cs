using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIDomper.Win.View
{
    public partial class frmChamadoProblemaSolucao : Form
    {
        private EnumChamado _enumChamado;
        private int _idCliente;
        private int _idUsuario;

        public frmChamadoProblemaSolucao()
        {
            InitializeComponent();
        }

        public frmChamadoProblemaSolucao(int idCliente, int idUsuario, EnumChamado enumChamado)
        {
            InitializeComponent();

            _enumChamado = enumChamado;
            _idCliente = idCliente;
            _idUsuario = idUsuario;
        }

        private void frmChamadoProblemaSolucao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void BuscarDados()
        {
            if (txtTexto.Text.Trim() == "")
            {
                MessageBox.Show("Informe o texto a pesquisar!");
                return;
            }

            ChamadoOcorrenciaApp chamadoOcorrenciaApp = new ChamadoOcorrenciaApp();
            var lista = chamadoOcorrenciaApp.RetornarProblemasSolucoes(txtTexto.Text,
                _idUsuario, _idCliente, _enumChamado);

            int contador = 1;
            int top = contador;

            foreach (var item in lista)
            {
                top = contador * 130;

                Label lblId = new Label();
                lblId.Top = top - 23;
                lblId.Left = 10;
                lblId.Size = new Size(35, 13);
                lblId.Text = "Id";
                lblId.Name = "lblId" + contador;
                this.Controls.Add(lblId);

                TextBox txtId = new TextBox();
                txtId.Top = top;
                txtId.Left = 10;
                txtId.Size = new Size(50, 20);
                txtId.Text = item.IdChamado.ToString("D6");
                txtId.Name = "txtId" + contador;
                this.Controls.Add(txtId);
                //===================================

                Label lblData = new Label();
                lblData.Top = top - 23;
                lblData.Left = 65;
                lblData.Text = "Data";
                lblData.Size = new Size(35, 13);
                lblData.Name = "lblData" + contador;
                this.Controls.Add(lblData);

                TextBox txtData = new TextBox();
                txtData.Top = top;
                txtData.Left = 65;
                txtData.Size = new Size(67, 20);
                txtData.Text = item.HoraInicio.Hours.ToString();
                txtData.Name = "txtData" + contador;
                this.Controls.Add(txtData);
                //===================================

                Label lblProb = new Label();
                lblProb.Top = top - 23;
                lblProb.Left = 135;
                lblProb.AutoSize = true;
                lblProb.Name = "lbProb" + contador;
                lblProb.Text = "Descrição do Problema";
                this.Controls.Add(lblProb);

                TextBox txtProbl = new TextBox();
                txtProbl.Top = top;
                txtProbl.Left = 135;
                txtProbl.Multiline = true;
                txtProbl.Text = item.DescricaoTecnica;
                txtProbl.Name = "txtProbl" + contador;
                txtProbl.ScrollBars = ScrollBars.Vertical;
                txtProbl.Size = new Size(400, 100);
                this.Controls.Add(txtProbl);
                //=========================================
                Label lblTec = new Label();
                lblTec.Top = top - 23;
                lblTec.Left = 540;
                lblTec.AutoSize = true;
                lblTec.Name = "lbProb" + contador;
                lblTec.Text = "Descrição da Solução";
                this.Controls.Add(lblTec);

                TextBox txtTec = new TextBox();
                txtTec.Top = top;
                txtTec.Left = 540;
                txtTec.Text = item.DescricaoSolucao;
                txtTec.Name = "txtTec" + contador;
                txtTec.ScrollBars = ScrollBars.Vertical;
                txtTec.Multiline = true;
                txtTec.Size = new Size(400, 100);
                this.Controls.Add(txtTec);
                //=========================================

                Label lblHora = new Label();
                lblHora.Top = top + 27;
                lblHora.Left = 10;
                lblHora.AutoSize = true;
                lblHora.Size = new Size(35, 13);
                lblHora.Name = "lbProb" + contador;
                lblHora.Text = "Hora";
                this.Controls.Add(lblHora);

                TextBox txtHora = new TextBox();
                txtHora.Top = top + 23;
                txtHora.Left = 65;
                txtHora.Text = item.HoraInicio.ToString();
                txtHora.Size = new Size(67, 20);
                txtHora.Name = "lblHora" + contador;
                this.Controls.Add(txtHora);
                //==========================================

                Label lblUsuario = new Label();
                lblUsuario.Top = top + 50;
                lblUsuario.Left = 10;
                lblUsuario.AutoSize = true;
                lblUsuario.Size = new Size(35, 13);
                lblUsuario.Name = "lblUsuario" + contador;
                lblUsuario.Text = "Usuário";
                this.Controls.Add(lblUsuario);

                TextBox txtUsuario = new TextBox();
                txtUsuario.Top = top + 47;
                txtUsuario.Left = 65;
                txtUsuario.Text = item.NomeUsuario;
                txtUsuario.Size = new Size(67, 20);
                txtUsuario.Name = "txtUsuario" + contador;
                this.Controls.Add(txtUsuario);

                contador = contador + 1;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            BuscarDados();
        }
    }
}
