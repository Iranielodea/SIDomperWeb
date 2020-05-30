using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Win.Utilitarios;
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
    public partial class frmSenhaPermissao : Form
    {
        private int _idUsuarioGravado;
        private string _siglaPermissao;

        public frmSenhaPermissao()
        {
            InitializeComponent();
        }

        public frmSenhaPermissao(string sigla, int idUsuarioGravado)
        {
            InitializeComponent();
            _idUsuarioGravado = idUsuarioGravado;
            _siglaPermissao = sigla;
        }

        private void frmSenhaPermissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private bool PermissaoChamadoAlterarDataHora()
        {
            ChamadoOcorrenciaApp chamadoOcorrenciaApp = new ChamadoOcorrenciaApp();
            var model = chamadoOcorrenciaApp.PermissaoAlterarDataHora(int.Parse(txtIdUsuario.Text), _idUsuarioGravado, EnumChamado.Chamado);
            bool permissao = Funcoes.PermitirEditar(model.Mensagem);
            if (!permissao)
                MessageBox.Show("Usuário sem Permissão!");
            return permissao;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtIdUsuario.Text.Trim() == "" && txtSenha.Text.Trim() == "")
            {
                txtUsuario.Focus();
                MessageBox.Show("Informe o Usuário e Senha!");
                return;
            }

            UsuarioApp usuarioApp = new UsuarioApp();
            try
            {
                var usuario = usuarioApp.ObterPorUsuario(txtUsuario.Text, txtSenha.Text);
                Funcoes.VerificarMensagem(usuario.Mensagem);
                txtIdUsuario.Text = usuario.Id.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            bool permissao = false;
            if (_siglaPermissao == "Lib_Chamado_Ocorr_Alt_Data_Hora" || _siglaPermissao == "Lib_Atividade_Ocorr_Alt_Data_Hora")
                permissao = PermissaoChamadoAlterarDataHora();

            if (permissao)
            {
                Close();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
