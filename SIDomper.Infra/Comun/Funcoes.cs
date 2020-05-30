using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.Comun
{
    public static class Funcoes
    {
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
            if (data == null)
                return true;

            return (data.Trim() == "/  /");
        }
    }
}
