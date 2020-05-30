using SIDomper.Dominio.ViewModel;
using SIDomper.Infra.Comun;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.RepositorioDapper
{
    public class VisitaRepositorioDapper
    {
        private readonly RepositorioDapper<VisitaConsultaViewModelApi> _repositorioConsulta;

        public VisitaRepositorioDapper()
        {
            _repositorioConsulta = new RepositorioDapper<VisitaConsultaViewModelApi>();
        }

        public IEnumerable<VisitaConsultaViewModelApi> FiltrarAPI(int idUsuario, VisitaFiltroViewModelApi filtro, string campo, string valor)
        {
            var sb = new StringBuilder();

            sb.AppendLine(MontarSql(idUsuario, campo, valor));

            if (filtro.Id > 0)
                sb.AppendLine(" AND Vis_Id = " + filtro.Id);

            if (!string.IsNullOrWhiteSpace(filtro.Perfil))
                sb.AppendLine(" AND Cli_Perfil = '" + filtro.Perfil + "'");

            if (!Funcoes.DataEmBranco(filtro.DataInicial))
                sb.AppendLine(" AND Vis_Data >= '" + filtro.DataInicial + "'");

            if (!Funcoes.DataEmBranco(filtro.DataFinal))
                sb.AppendLine(" AND Vis_Data <= '" + filtro.DataFinal + "'");

            if (!string.IsNullOrWhiteSpace(filtro.ClienteId))
                sb.AppendLine(" AND Vis_Cliente IN (" + filtro.ClienteId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.RevendaId))
                sb.AppendLine(" AND Cli_Revenda IN (" + filtro.RevendaId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.StatusId))
                sb.AppendLine(" AND Vis_Status IN (" + filtro.StatusId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.TipoId))
                sb.AppendLine(" AND Vis_Tipo IN (" + filtro.TipoId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.UsuarioId))
                sb.AppendLine(" AND Vis_Usuario IN (" + filtro.UsuarioId + ")");

            sb.AppendLine(" ORDER BY " + campo);

            var lista = _repositorioConsulta.GetAll(sb.ToString());

            return lista.ToList();
        }

        private string MontarSql(int idUsuario, string campo, string valor)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" Vis_Id as Id");
            //sb.AppendLine(",'' as Data");
            //sb.AppendLine(",Vis_Data as DataD");
            sb.AppendLine(",Vis_Data as Data");
            sb.AppendLine(",Vis_Dcto as Documento");
            sb.AppendLine(",Cli_Nome as NomeCliente");
            sb.AppendLine(",Cli_Fantasia as NomeFantasia");
            sb.AppendLine(",Usu_Nome as NomeConsultor");
            sb.AppendLine(",Vis_Dcto as Documento");

            sb.AppendLine(" FROM Visita");
            sb.AppendLine(" INNER JOIN Cliente ON Vis_Cliente = Cli_Id");
            sb.AppendLine(" LEFT JOIN Usuario ON Vis_Usuario = Usu_Id");
            sb.AppendLine(" WHERE " + campo + " LIKE'%" + valor + "%'");

            return sb.ToString();
        }
    }
}
