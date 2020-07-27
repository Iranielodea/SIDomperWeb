using SIDomper.Apresentacao.App;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FazerLogin()
        {
            var usuarioApp = new UsuarioApp();
            var usuario = usuarioApp.ObterPorUsuario(txtUsuario.Text, txtSenha.Text);
            if (usuario == null)
            {
                MessageBox.Show("Usuário não Cadastrado!");
                return;
            }

            if (usuario.Ativo == false)
            {
                MessageBox.Show("Usuário não está Ativo!");
                return;
            }

            frmMenuPrincipal frmMenuPrincipal = new frmMenuPrincipal(txtUsuario.Text, txtSenha.Text);
            frmMenuPrincipal.Show();
            this.Visible = false;// Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            FazerLogin();
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            BtnOk.Focus();
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            if ((e.KeyChar.CompareTo((char)Keys.Escape)) == 0)
                Close();
        }
    }
}
