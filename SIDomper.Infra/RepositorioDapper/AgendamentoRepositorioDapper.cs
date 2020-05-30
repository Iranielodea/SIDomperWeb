using SIDomper.Dominio.ViewModel;
using SIDomper.Infra.Comun;
using SIDomper.Infra.EF;
using System.Collections.Generic;
using System.Text;

namespace SIDomper.Infra.RepositorioDapper
{
    public class AgendamentoRepositorioDapper
    {
        private readonly RepositorioDapper<AgendamentoConsultaViewModel> _repositorioConsulta;
        private readonly RepositorioDapper<AgendamentoQuadroViewModel> _repositorioQuadro;

        public AgendamentoRepositorioDapper()
        {
            _repositorioConsulta = new RepositorioDapper<AgendamentoConsultaViewModel>();
            _repositorioQuadro = new RepositorioDapper<AgendamentoQuadroViewModel>();
        }

        public IEnumerable<AgendamentoConsultaViewModel> Filtrar(AgendamentoFiltroViewModel filtro, string campo, string texto, int idUsuario, bool contem = true)

        {
            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();
            var usuarioCliente = new UsuarioEF();

            sb.AppendLine(" SELECT");
            sb.AppendLine(" Age_Id as Id,");
            sb.AppendLine("	Age_Data as Data,");
            sb.AppendLine("	Age_Hora as Hora,");
            sb.AppendLine(" Age_Cliente as ClienteId,");
            sb.AppendLine(" Age_NomeCliente as NomeCliente,");
            sb.AppendLine(" Tip_Nome as TipoNome,");
            sb.AppendLine(" Usu_Nome as UsuarioNome,");
            sb.AppendLine(" Sta_Nome as StatusNome");
            sb.AppendLine(" FROM Agendamento");
            sb.AppendLine("     INNER JOIN Cliente ON Age_Cliente = Cli_Id");
            sb.AppendLine(" 	INNER JOIN Tipo ON Age_Tipo = Tip_Id");
            sb.AppendLine(" 	INNER JOIN Usuario ON Age_Usuario = Usu_Id");
            sb.AppendLine(" 	INNER JOIN Status ON Age_Status = Status.Sta_Id");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine("WHERE Age_Id > 0");
            }

            sb.AppendLine(usuarioCliente.PermissaoUsuario(idUsuario));

            if ((!string.IsNullOrWhiteSpace(filtro.DataInicial)) && (filtro.DataInicial.Trim() != "/  /"))
                sb.AppendLine(" AND Age_Data >=" + Funcoes.DataIngles(filtro.DataInicial));

            if ((!string.IsNullOrWhiteSpace(filtro.DataFinal)) && (filtro.DataFinal.Trim() != "/  /"))
                sb.AppendLine(" AND Age_Data <=" + Funcoes.DataIngles(filtro.DataFinal));

            if (!string.IsNullOrWhiteSpace(filtro.IdCliente))
                sb.AppendLine(" AND Age_Cliente IN (" + filtro.IdCliente + ")");

            if (!string.IsNullOrWhiteSpace(filtro.IdTipo))
                sb.AppendLine(" AND Age_Tipo IN (" + filtro.IdTipo + ")");

            if (!string.IsNullOrWhiteSpace(filtro.IdStatus))
                sb.AppendLine(" AND Age_Status IN (" + filtro.IdStatus + ")");

            if (!string.IsNullOrWhiteSpace(filtro.IdUsuario))
                sb.AppendLine(" AND Age_Usuario IN (" + filtro.IdUsuario + ")");

            var lista = _repositorioConsulta.GetAll(sb.ToString());
            return lista;
        }

        public IEnumerable<AgendamentoQuadroViewModel> Quadros(string dataInicial, string dataFinal, int idUsuario, int idRevenda)
        {
            var sb = new StringBuilder();
            var usuarioCliente = new UsuarioEF();

            sb.AppendLine("SELECT");
            sb.AppendLine("	Age_Id as Id,");
            sb.AppendLine("	Age_Data as Data,");
            sb.AppendLine("	Age_Hora as Hora,");
            sb.AppendLine("  Age_Cliente as ClienteId,");
            sb.AppendLine("	Age_NomeCliente as ClienteNome,");
            sb.AppendLine("	Usu_Nome as UsuarioNome,");
            sb.AppendLine("	Sta_Nome as StatusNome");
            sb.AppendLine(" FROM Agendamento");
            sb.AppendLine(" INNER JOIN Cliente ON  Age_Cliente = Cli_Id");
            sb.AppendLine(" INNER JOIN Usuario ON Age_Usuario = Usu_Id");
            sb.AppendLine(" INNER JOIN Status ON Age_Status = Sta_Id");
            sb.AppendLine(" WHERE Age_Data >=" + Funcoes.DataIngles(dataInicial));
            sb.AppendLine(" AND Age_Data <=" + Funcoes.DataIngles(dataFinal));

            if (idRevenda > 0)
                sb.AppendLine(" AND Cli_Revenda = " + idRevenda);

            sb.AppendLine(usuarioCliente.PermissaoUsuario(idUsuario));

            sb.AppendLine(" ORDER BY Age_Data");

            var lista = _repositorioQuadro.GetAll(sb.ToString());
            return lista;
        }
    }
}
