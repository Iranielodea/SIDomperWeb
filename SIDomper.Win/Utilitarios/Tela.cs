using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIDomper.Win.Utilitarios
{
    public static class Tela
    {
        public const string MaskProduto = "0000";
        public const string MaskModulo = "0000";
        public const string MaskCliente = "000000";
        public const string MaskTipo = "0000";
        public const string MaskStatus = "0000";
        public const string MaskChamado = "000000";
        public const string MaskVersao = "000000";
        public const string MaskVisita = "000000";

        public static void LimparPage(ref TabPage controle)
        {
            foreach (Control ctr in controle.Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
                else if (ctr is CheckedListBox)
                {
                    CheckedListBox clb = (CheckedListBox)ctr;
                    foreach (int checkedItemIndex in clb.CheckedIndices)
                    {
                        clb.SetItemChecked(checkedItemIndex, false);
                    }
                }
                else if (ctr is CheckBox)
                {
                    ((CheckBox)ctr).Checked = true;
                }
                else if (ctr is ComboBox)
                {
                    ((ComboBox)ctr).SelectedIndex = 0;
                }
            }
        }

        public static void LimparTela(Control controle)
        {
            foreach (Control ctr in controle.Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
                else if (ctr is CheckedListBox)
                {
                    CheckedListBox clb = (CheckedListBox)ctr;
                    foreach (int checkedItemIndex in clb.CheckedIndices)
                    {
                        clb.SetItemChecked(checkedItemIndex, false);
                    }
                }
                else if (ctr is CheckBox)
                {
                    ((CheckBox)ctr).Checked = false;
                }
                else if (ctr is ComboBox)
                {
                    ((ComboBox)ctr).SelectedIndex = 0;
                }
                else if (ctr is MaskedTextBox)
                {
                    ctr.Text = "";
                }
            }
        }

        public static void HabilitarDesabilitar(Control controle, bool habilitar)
        {
            foreach (Control ctr in controle.Controls)
            {
                try
                {
                    ctr.Enabled = habilitar;
                }
                catch
                {
                    // nada
                }
            }
        }

        public static void AbrirFormulario(Form formulario)
        {
            //PermissaoAcesso(formulario);
            formulario.Show();
        }

        public static bool AbrirFormularioModal(Form formulario)
        {
            PermissaoAcesso(formulario);
            if (formulario.ShowDialog() == DialogResult.OK)
                return true;
            else
                return false;
        }

        private static void PermissaoAcesso(Form formulario)
        {
            int idPrograma;
            try
            {

                idPrograma = int.Parse(formulario.Tag.ToString());
            }
            catch
            {
                throw new Exception("Formulário sem código do programa");
            }

            if (!PermissaoDepartamento.Listar.Any(x => x.IdPrograma == idPrograma && x.Acesso))
                throw new Exception("Usuário sem permissão!");
        }

        public static void Binding(ref TextBox text, object objeto, string propriedade)
        {
            text.DataBindings.Clear();
            text.DataBindings.Add("Text", objeto, propriedade);
        }

        public static void BindingMask(ref MaskedTextBox text, object objeto, string propriedade)
        {
            text.DataBindings.Clear();
            text.DataBindings.Add("Text", objeto, propriedade);
        }

        public static void BindingCheckBox(ref CheckBox checkBox, object objeto, string propriedade)
        {
            checkBox.DataBindings.Clear();
            checkBox.DataBindings.Add("Checked", objeto, propriedade);
        }

        public static void BotaoPadraoNovo(ref Button butNovo, ref Button butEditar, ref Button butSalvar, ref Button butExcluir, ref Button butCancelar)
        {
            butNovo.Enabled = false;
            butEditar.Enabled = false;
            butExcluir.Enabled = false;
            butSalvar.Enabled = true;
            butCancelar.Enabled = true;
        }

        public static void BotaoPadraoEditar(ref Button butNovo, ref Button butEditar, ref Button butSalvar, ref Button butExcluir, ref Button butCancelar)
        {
            butNovo.Enabled = false;
            butEditar.Enabled = false;
            butExcluir.Enabled = false;
            butSalvar.Enabled = true;
            butCancelar.Enabled = true;
        }

        public static void BotaoPadraoSalvar(ref Button butNovo, ref Button butEditar, ref Button butSalvar, ref Button butExcluir, ref Button butCancelar)
        {
            butNovo.Enabled = true;
            butEditar.Enabled = true;
            butExcluir.Enabled = true;
            butSalvar.Enabled = false;
            butCancelar.Enabled = false;
        }

        public static void BotaoPadraoExcluir(ref Button butNovo, ref Button butEditar, ref Button butSalvar, ref Button butExcluir, ref Button butCancelar)
        {
            butNovo.Enabled = true;
            butEditar.Enabled = true;
            butExcluir.Enabled = true;
            butSalvar.Enabled = false;
            butCancelar.Enabled = false;
        }

        public static void BotaoPadraoCancelar(ref Button butNovo, ref Button butEditar, ref Button butSalvar, ref Button butExcluir, ref Button butCancelar)
        {
            butNovo.Enabled = true;
            butEditar.Enabled = true;
            butExcluir.Enabled = true;
            butSalvar.Enabled = false;
            butCancelar.Enabled = false;
        }
    }
}
