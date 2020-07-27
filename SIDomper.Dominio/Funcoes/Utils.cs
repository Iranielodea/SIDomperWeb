using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Funcoes
{
    public class Utils
    {
        public static string SomenteNumero(string valor)
        {
            if (string.IsNullOrEmpty(valor))
                return "";

            List<char> numbers = new List<char>("0123456789");
            StringBuilder toReturn = new StringBuilder(valor.Length);
            CharEnumerator enumerator = valor.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (numbers.Contains(enumerator.Current))
                    toReturn.Append(enumerator.Current);
            }

            return toReturn.ToString();
        }

        public static void AutoMappear(Object origem, Object destino)
        {
            Type torigem = origem.GetType();
            Type tdestino = destino.GetType();

            PropertyInfo[] propsOrigem = torigem.GetProperties();
            PropertyInfo[] propsDestino = tdestino.GetProperties();

            foreach (var propOrigem in propsOrigem)
            {
                if (propOrigem.GetMethod.IsVirtual)
                    continue;

                foreach (var propDestino in propsDestino)
                {
                    if (propOrigem.Name == propDestino.Name)
                    {
                        propDestino.SetValue(destino, propOrigem.GetValue(origem)); // = propOrigem.GetValue(destino);
                    }
                }
            }
        }

        public static double HoraToDecimal(string hora)
        {
            double d = 0;
            try
            {
                double a = Convert.ToDouble((hora.Substring(3, 2)));
                double b = a / 60;
                double c = (int)Convert.ToDouble(hora.Substring(0, 2));
                d = c + b;
            }
            catch
            {
                d = 0;
            }
            return d;
        }

        public static string DecimalToHora(double hora)
        {
            string f = "";
            try
            {
                double a = Frac(hora);
                double b = (int)hora;
                double c = (a * 60);
                f = c.ToString("00");
                if (f == "60")
                {
                    c = 0;
                    b = b + 1;
                }
                string d = b.ToString("00");
                string e = c.ToString("00");
                e = e.Substring(0, 2);
                f = d + ":" + e;
            }
            catch
            {
                f = "00:00";
            }
            return f;
        }

        public static double Frac(double valor)
        {
            return (int)Math.Round((valor - (int)valor) * 100);
        }

        public static string FormatarHora(TimeSpan hora)
        {
            return hora.ToString(@"hh\:mm");
        }

        public static string FormatarHHMMSS(TimeSpan hora)
        {
            return hora.ToString(@"hh\:mm\:ss");
        }

        public static TimeSpan CalcularHoras(TimeSpan horaInicial, TimeSpan horaFinal)
        {
            return horaFinal - horaInicial;
        }

        public static string FormatarCNPJ(string cnpj)
        {
            try
            {
                return Convert.ToUInt64(SomenteNumero(cnpj)).ToString(@"00\.000\.000\/0000\-00");
            }
            catch
            {
                return "";
            }
        }

        public static string FormatarCPF(string cpf)
        {
            try
            {
                return Convert.ToUInt64(SomenteNumero(cpf)).ToString((@"000\.000\.000\-00"));
            }
            catch
            {
                return "";
            }
        }

        public static string DataIngles(string data)
        {
            try
            {
                DateTime dataNova = Convert.ToDateTime(data);
                return "'" + dataNova.ToString("yyyy-MM-dd") + "'";
            }
            catch
            {
                return "";
            }
        }

        public static bool DataEmBranco(string data)
        {
            try
            {
                return (data.Trim() == "/  /");
            }
            catch
            {
                return true;
            }
        }
    }
}
