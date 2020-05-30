using SIDomper.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.ADO
{
    public class VisitaADO
    {
        public List<VisitaConsulta> Filtrar(int idUsuario, VisitaFiltro filtro)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" Vis_Id, Vis_Data, Vis_Dcto, Cli_Nome, Cli_Fantasia, Usu_Nome");
            sb.AppendLine(" FROM Visita");
            sb.AppendLine(" INNER JOIN Cliente ON Vis_Cliente = Cli_Id");
            sb.AppendLine(" LEFT JOIN Usuario ON Vis_Usuario = Usu_Id");

            if (filtro.Id == 0)
                sb.AppendLine(" WHERE Vis_Id IS NOT NULL");
            else
                sb.AppendLine(" WHERE Vis_Id = " + filtro.Id);

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Revenda = Usu_Revenda) OR (Usu_Revenda IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Id = Usu_Cliente) OR (Usu_Cliente IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            if (!string.IsNullOrEmpty(filtro.RazaoSocial))
                sb.AppendLine(" AND Cli_Nome like '%" + filtro.RazaoSocial + "%'");

            if (filtro.ClienteId > 0)
                sb.AppendLine(" AND Vis_Cliente = " + filtro.ClienteId);

            if (filtro.DataInicial != null)
                sb.AppendLine(" AND Vis_Data >= '" + filtro.DataInicial + "'");

            if (filtro.DataFinal != null)
                sb.AppendLine(" AND Vis_Data <= '" + filtro.DataFinal + "'");

            if (filtro.RevendaId > 0)
                sb.AppendLine(" AND Cli_Revenda = " + filtro.RevendaId);

            if (filtro.StatusId > 0)
                sb.AppendLine(" AND Vis_Status = " + filtro.StatusId);

            if (filtro.TipoId > 0)
                sb.AppendLine(" AND Vis_Tipo = " + filtro.TipoId);

            if (filtro.UsuarioId > 0)
                sb.AppendLine(" AND Vis_Usuario = " + filtro.UsuarioId);
            sb.AppendLine(" ORDER BY Vis_Data");

            var lista = new List<VisitaConsulta>();

            using (var db = new BancoADO())
            {
                db.RetornoReader(sb.ToString());

                while (db.Read())
                {
                    var model = new VisitaConsulta
                    {
                        //Data = db.CampoData("Vis_Data").ToShortDateString(),
                        NomeCliente = db.CampoStr("Cli_Nome"),
                        NomeFantasia = db.CampoStr("Cli_Fantasia"),
                        Documento = db.CampoStr("Vis_Dcto"),
                        Id = db.CampoInt32("Vis_Id"),
                        NomeConsultor = db.CampoStr("Usu_Nome"),
                    };
                    lista.Add(model);
                }
                db.CloseReader();
            }
            return lista;
        }

        public List<VisitaConsulta> Filtrar(int idUsuario, VisitaFiltro filtro, string campo, string valor)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" Vis_Id, Vis_Data, Vis_Dcto, Cli_Nome, Cli_Fantasia, Usu_Nome");
            sb.AppendLine(" FROM Visita");
            sb.AppendLine(" INNER JOIN Cliente ON Vis_Cliente = Cli_Id");
            sb.AppendLine(" LEFT JOIN Usuario ON Vis_Usuario = Usu_Id");
            sb.AppendLine(" WHERE " + campo + " LIKE'%" + valor + "%'");

            //if (filtro.Id == 0)
            //    sb.AppendLine(" WHERE Vis_Id IS NOT NULL");
            //else
            //    sb.AppendLine(" WHERE Vis_Id = " + filtro.Id);

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Revenda = Usu_Revenda) OR (Usu_Revenda IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Id = Usu_Cliente) OR (Usu_Cliente IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            if (!string.IsNullOrEmpty(filtro.RazaoSocial))
                sb.AppendLine(" AND Cli_Nome like '%" + filtro.RazaoSocial + "%'");

            if (filtro.ClienteId > 0)
                sb.AppendLine(" AND Vis_Cliente = " + filtro.ClienteId);

            if (filtro.DataInicial != null)
                sb.AppendLine(" AND Vis_Data >= '" + filtro.DataInicial + "'");

            if (filtro.DataFinal != null)
                sb.AppendLine(" AND Vis_Data <= '" + filtro.DataFinal + "'");

            if (filtro.RevendaId > 0)
                sb.AppendLine(" AND Cli_Revenda = " + filtro.RevendaId);

            if (filtro.StatusId > 0)
                sb.AppendLine(" AND Vis_Status = " + filtro.StatusId);

            if (filtro.TipoId > 0)
                sb.AppendLine(" AND Vis_Tipo = " + filtro.TipoId);

            if (filtro.UsuarioId > 0)
                sb.AppendLine(" AND Vis_Usuario = " + filtro.UsuarioId);
            sb.AppendLine(" ORDER BY Vis_Data");

            var lista = new List<VisitaConsulta>();

            using (var db = new BancoADO())
            {
                db.RetornoReader(sb.ToString());

                while (db.Read())
                {
                    var model = new VisitaConsulta
                    {
                        //Data = db.CampoData("Vis_Data").ToShortDateString(),
                        NomeCliente = db.CampoStr("Cli_Nome"),
                        NomeFantasia = db.CampoStr("Cli_Fantasia"),
                        Documento = db.CampoStr("Vis_Dcto"),
                        Id = db.CampoInt32("Vis_Id"),
                        NomeConsultor = db.CampoStr("Usu_Nome"),
                    };
                    lista.Add(model);
                }
                db.CloseReader();
            }
            return lista;
        }
    }
}
