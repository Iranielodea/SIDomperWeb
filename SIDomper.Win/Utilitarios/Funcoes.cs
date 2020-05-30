using System;
using System.Windows.Forms;

namespace SIDomper.Win.Utilitarios
{
    public static class Funcoes
    {
        public static int IdUsuario { get; set; }
        public static int CodigoUsuarioLogado { get; set; }
        public static string NomeUsuarioLogado { get; set; }
        public static int IdSelecionado { get; set; }
        public static bool UsuarioADM { get; set; }

        public static bool Confirmar(string mensagem)
        {
            return
                (MessageBox.Show(mensagem, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes);
        }

        public static void Binding(ref TextBox objTexto, object datasource, string campo)
        {
            objTexto.DataBindings.Clear();
            objTexto.DataBindings.Add("Text", datasource, campo, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public static void BindingMask(ref MaskedTextBox objTexto, object datasource, string campo)
        {
            objTexto.DataBindings.Clear();
            objTexto.DataBindings.Add("Text", datasource, campo, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public static string FormatStrDecimal(string mascara, string valor)
        {
            try
            {
                return decimal.Parse(valor).ToString(mascara);
            }
            catch
            {
                return decimal.Parse("0").ToString(mascara);
            }
        }

        public static void AbrirTela(Form formulario)
        {
            formulario.Show();
        }

        public static string StrtoStr(string value)
        {
            try
            {
                int valor = Convert.ToInt32(value);
                if (valor > 0)
                    return value;
                else
                    return "";
            }
            catch
            {
                return "";
            }
        }

        public static int StrToInt(string value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }

        public static string StrToStrNull(string value)
        {
            try
            {
                return Convert.ToInt32(value).ToString();
            }
            catch
            {
                return "";
            }
        }

        public static int? StrToIntNull(string value)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(value))
                    return null;
                else
                    return Convert.ToInt32(value);
            }
            catch
            {
                return null;
            }
        }

        public static string IntNullToStr(int? value)
        {
            try
            {
                return value.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static string DecimalNullToStr(decimal? value, string casas = "")
        {
            try
            {
                if (casas != "")
                    return value.Value.ToString(casas);
                else
                    return value.Value.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static string DateNullToStr(DateTime? value)
        {
            try
            {
                return value.Value.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static void VerificarMensagem(string mensagem)
        {
            if (mensagem != "OK")
                throw new Exception(mensagem);
        }

        public static bool PermitirEditar(string mensagem)
        {
            return (mensagem.ToUpper() == "OK");
        }

        public static TimeSpan? StrToHoraNull(string hora)
        {
            try
            {
                return TimeSpan.Parse(hora);
            }
            catch
            {
                return null;
            }
        }

        public static TimeSpan StrToHora(string hora)
        {
            try
            {
                return TimeSpan.Parse(hora);
            }
            catch
            {
                throw;
            }
        }

        public static DateTime StrToDate(string value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                throw;
            }
        }

        public static bool DataEmBranco(string data)
        {
            if (data.Trim() == "/  /")
                return true;
            else
                return false;
        }

        public static bool HoraEmBranco(string hora)
        {
            if (hora.Trim() == " :")
                return true;
            else
                return false;
        }

        public static DateTime? StrToDateNull(string data)
        {
            try
            {
                return Convert.ToDateTime(data);
            }
            catch
            {
                return null;
            }
        }
    }
}
