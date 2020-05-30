using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Funcoes
{
    public class Horas
    {
        public static double Frac(double valor)
        {
            return Dominio.Funcoes.Utils.Frac(valor);
            //return (int)Math.Round((valor - (int)valor) * 100);
        }

        public static double HoraToDecimal(string hora)
        {
            return Dominio.Funcoes.Utils.HoraToDecimal(hora);
            //double d = 0;
            //try
            //{
            //    double a = Convert.ToDouble((hora.Substring(3, 2)));
            //    double b = a / 60;
            //    double c = (int)Convert.ToDouble(hora.Substring(0, 2));
            //    d = c + b;
            //}
            //catch
            //{
            //    d = 0;
            //}
            //return d;
        }

        public static string DecimalToHora(double hora)
        {
            return Dominio.Funcoes.Utils.DecimalToHora(hora);
            //string f = "";
            //try
            //{
            //    double a = Frac(hora);
            //    double b = (int)hora;
            //    double c = (a * 60);
            //    f = c.ToString("00");
            //    if (f == "60")
            //    {
            //        c = 0;
            //        b = b + 1;
            //    }
            //    string d = b.ToString("00");
            //    string e = c.ToString("00");
            //    e = e.Substring(0, 2);
            //    f = d + ":" + e;
            //}
            //catch
            //{
            //    f = "00:00";
            //}
            //return f;
        }

        public static string FormatarHora(TimeSpan hora)
        {
            return Dominio.Funcoes.Utils.FormatarHora(hora);            
        }

        public static TimeSpan CalcularHoras(TimeSpan horaInicial, TimeSpan horaFinal)
        {
            return Dominio.Funcoes.Utils.CalcularHoras(horaInicial, horaFinal);
        }
    }
}
