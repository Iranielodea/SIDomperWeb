using SIDomper.Dominio.Funcoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Funcoes
{
    public static class FuncaoGeral
    {
        public static string SomenteNumero(string valor)
        {
            return Utils.SomenteNumero(valor);
            //if (string.IsNullOrEmpty(valor))
            //    return "";

            //List<char> numbers = new List<char>("0123456789");
            //StringBuilder toReturn = new StringBuilder(valor.Length);
            //CharEnumerator enumerator = valor.GetEnumerator();

            //while (enumerator.MoveNext())
            //{
            //    if (numbers.Contains(enumerator.Current))
            //        toReturn.Append(enumerator.Current);
            //}

            //return toReturn.ToString();
        }

        public static void CalcularParcelas(int qtdeParcelas, decimal valor, ref decimal valorPrimeira, ref decimal valorOutras)
        {
            decimal divisao = Math.Truncate(valor / qtdeParcelas);
            decimal mult = (qtdeParcelas * divisao);
            decimal dif = (valor - mult);

            valorPrimeira = (divisao + dif);
            valorOutras = divisao;

        }

        public static string DataIngles(string data)
        {
            return Infra.Comun.Funcoes.DataIngles(data);
        }

        public static double CalcularDatas(DateTime dataInicial, DateTime dataFinal)
        {
            TimeSpan data = dataFinal.Subtract(dataInicial);
            return data.TotalDays;
        }

        public static bool DataEmBranco(string data)
        {
            return (data.Trim() == "/  /");
        }

        public static DateTime PrimeiroDiaMesCorrente()
        {
            DateTime data = DateTime.Today;
            DateTime dataInicio = new DateTime(data.Year, data.Month, 1);
            return dataInicio;
        }

        public static DateTime UltimoDiaMesCorrente()
        {
            DateTime data = DateTime.Today;
            DateTime ultimoDiaDoMes = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
            return ultimoDiaDoMes;
        }
    }
}
