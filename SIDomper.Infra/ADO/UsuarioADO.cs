using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.ADO
{
    public class UsuarioADO
    {
        public string UsuarioCliente(int idUsuario)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Revenda = Usu_Revenda) OR (Usu_Revenda IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Id = Usu_Cliente) OR (Usu_Cliente IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            return sb.ToString();
        }
    }
}
