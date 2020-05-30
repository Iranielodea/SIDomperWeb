using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Infra.Comun;
using SIDomper.Infra.EF;
using System.Collections.Generic;
using System.Text;

namespace SIDomper.Infra.RepositorioDapper
{
    public class SolicitacaoRepositorioDapper
    {
        private readonly RepositorioDapper<SolicitacaoConsultaViewModel> _repositorioConsulta;
        private readonly RepositorioDapper<QuadroSolicitacaoViewModel> _repositorioDapperQuadro;

        public SolicitacaoRepositorioDapper()
        {
            _repositorioConsulta = new RepositorioDapper<SolicitacaoConsultaViewModel>();
            _repositorioDapperQuadro = new RepositorioDapper<QuadroSolicitacaoViewModel>();
        }

        public IEnumerable<SolicitacaoConsultaViewModel> Filtrar(SolicitacaoFiltroViewModel filtro, string campo, string texto, int usuarioId, bool contem)
        {
            var sb = new StringBuilder();

            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            sb.AppendLine(" SELECT");
            sb.AppendLine("  Sol_Id as Id,");
            sb.AppendLine("  Sol_Data as Data,");
            sb.AppendLine("  Sol_Hora as Hora,");
            sb.AppendLine("  Sol_Cliente as ClienteId,");
            sb.AppendLine("  Sol_Status as StatusId,");
            sb.AppendLine("  Sol_Titulo as Titulo,");
            sb.AppendLine("  CASE Sol_Nivel");
            sb.AppendLine("    WHEN 1 THEN '1-Baixo'");
            sb.AppendLine("    WHEN 2 THEN '2-Normal'");
            sb.AppendLine("    WHEN 3 THEN '3-Alto'");
            sb.AppendLine("    WHEN 4 THEN '4-Crítico'");
            sb.AppendLine("  END AS Nivel,");
            sb.AppendLine("  Cli_Codigo as ClienteCodigo,");
            sb.AppendLine("  Cli_Nome as RazaoSocial,");
            sb.AppendLine("  Cli_Fantasia as NomeFantasia,");
            sb.AppendLine("  Sta_Nome as StatusNome,");
            sb.AppendLine("  Tip_Nome as TipoNome,");
            sb.AppendLine("  Ver_Versao as Versao");
            sb.AppendLine(" FROM Solicitacao");
            sb.AppendLine("  INNER JOIN Cliente ON Sol_Cliente = Cli_Id");
            sb.AppendLine("  INNER JOIN Status ON Sol_Status = Sta_Id");
            sb.AppendLine("  LEFT JOIN Tipo ON Sol_Tipo = Tip_Id");
            sb.AppendLine("  LEFT JOIN Versao On Sol_VersaoId = Ver_Id");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine("WHERE Cha_Id > 0");
            }

            sb.AppendLine(FiltrarDados(usuarioId, filtro));

            //_rep.context.Database.SqlQuery<SolicitacaoConsulta>(sb.ToString());

            var lista = _repositorioConsulta.GetAll(sb.ToString());

            return lista;
        }

        public IEnumerable<QuadroSolicitacaoViewModel> Quadro(int idUsuario, Usuario usuario, int codParametro)
        {
            var usuarioCliente = new UsuarioEF();

            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" 	Sol_Id as Id,");
            sb.AppendLine(" 	Sol_Titulo as Titulo,");
            sb.AppendLine(" 	Sol_UsuarioAtendeAtual as IdUsuarioAtendeAtual,");
            sb.AppendLine(" 	Cli_Nome as ClienteNome,");
            sb.AppendLine(" 	Usu_Nome as UsuarioNome,");
            sb.AppendLine(" 	Sol_Status as IdStatus");
            sb.AppendLine(" FROM Solicitacao");
            sb.AppendLine(" 	INNER JOIN Cliente ON Sol_Cliente = Cli_Id");
            sb.AppendLine(" 	INNER JOIN Status ON Sol_Status = Sta_Id");
            sb.AppendLine(" 	INNER JOIN Parametros ON Sta_Codigo = COALESCE(Par_Valor, 0)");
            sb.AppendLine("   LEFT JOIN Usuario ON Sol_UsuarioAtendeAtual = Usu_Id");

            sb.AppendLine(" WHERE Par_Codigo = " + codParametro);
            sb.AppendLine(" AND Par_Programa = 3");
            sb.AppendLine(usuarioCliente.PermissaoUsuario(idUsuario));
            //sb.AppendLine(usuarioCliente.UsuarioCliente(idUsuario));
            sb.AppendLine(" ORDER BY Sol_Data");

            var lista = _repositorioDapperQuadro.GetAll(sb.ToString());
            //var lista = _rep.context.Database.SqlQuery<QuadroSolicitacao>(sb.ToString());

            return lista;
        }

        private string FiltrarDados(int idUsuario, SolicitacaoFiltroViewModel filtro)
        {
            var usuarioCliente = new UsuarioEF();
            var sb = new StringBuilder();

            sb.AppendLine(usuarioCliente.PermissaoUsuario(idUsuario));

            if ((!string.IsNullOrWhiteSpace(filtro.DataInicial)) && (filtro.DataInicial.Trim() != "/  /"))
                sb.AppendLine(" AND Sol_Data >=" + Funcoes.DataIngles(filtro.DataInicial));

            if ((!string.IsNullOrWhiteSpace(filtro.DataFinal)) && (filtro.DataFinal.Trim() != "/  /"))
                sb.AppendLine(" AND Sol_Data <=" + Funcoes.DataIngles(filtro.DataFinal));

            if (!string.IsNullOrWhiteSpace(filtro.IdUsuarioAbertura))
                sb.AppendLine(" AND Sol_UsuarioAbertura IN " + filtro.IdUsuarioAbertura);

            if (!string.IsNullOrWhiteSpace(filtro.IdCliente))
                sb.AppendLine(" AND Sol_Cliente IN " + filtro.IdCliente);

            if (!string.IsNullOrWhiteSpace(filtro.IdModulo))
                sb.AppendLine(" AND Sol_Modulo IN " + filtro.IdModulo);

            if (!string.IsNullOrWhiteSpace(filtro.IdProduto))
                sb.AppendLine(" AND Sol_Produto IN " + filtro.IdProduto);

            if (!string.IsNullOrWhiteSpace(filtro.IdAnalista))
                sb.AppendLine(" AND Sol_Analista IN " + filtro.IdAnalista);

            if (!string.IsNullOrWhiteSpace(filtro.IdTipo))
                sb.AppendLine(" AND Sol_Tipo IN " + filtro.IdTipo);

            if (!string.IsNullOrWhiteSpace(filtro.IdDesenvolvedor))
                sb.AppendLine(" AND Sol_Desenvolvedor IN " + filtro.IdDesenvolvedor);

            if (!string.IsNullOrWhiteSpace(filtro.IdStatus))
                sb.AppendLine(" AND Sol_Status IN " + filtro.IdStatus);

            //if (filtro.Nivel < 5)
            //    sb.AppendLine(" AND Sol_Nivel = " + filtro.Nivel);

            //if (filtro.ClienteFiltro.UsuarioId != "")
            //    sb.AppendLine(" AND Cli_Usuario IN " + filtro.ClienteFiltro.UsuarioId);

            if (!string.IsNullOrWhiteSpace(filtro.IdVersao))
                sb.AppendLine(" AND Sol_VersaoId IN " + filtro.IdVersao);

            if (filtro.Id > 0)
                sb.AppendLine(" AND Sol_Id = " + filtro.Id);

            return sb.ToString();
        }

        private string RetornarSQLQuadro(int idUsuario)
        {
            var sb = new StringBuilder();
            sb.AppendLine(MontarQuadro(idUsuario, "Q01", 12));
            sb.AppendLine(MontarQuadro(idUsuario, "Q02", 13));
            sb.AppendLine(MontarQuadro(idUsuario, "Q03", 14));
            sb.AppendLine(MontarQuadro(idUsuario, "Q04", 15));
            sb.AppendLine(MontarQuadro(idUsuario, "Q05", 16));
            sb.AppendLine(MontarQuadro(idUsuario, "Q06", 17));
            sb.AppendLine(MontarQuadro(idUsuario, "Q07", 19));
            sb.AppendLine(MontarQuadro(idUsuario, "Q08", 20));
            sb.AppendLine(MontarQuadro(idUsuario, "Q09", 21));
            sb.AppendLine(MontarQuadro(idUsuario, "Q10", 22));
            sb.AppendLine(MontarQuadro(idUsuario, "Q11", 23));
            sb.AppendLine(MontarQuadro(idUsuario, "Q12", 24));
            return sb.ToString();
        }

        private string MontarQuadro(int idUsuario, string quadro, int parCodigo)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" '" + quadro + "' As Quadro,");
            sb.AppendLine(" (");
            sb.AppendLine("     SELECT 1 FROM Solicitacao_Tempo");
            sb.AppendLine("         WHERE Sol_Id = STemp_Solicitacao");
            sb.AppendLine("         AND STemp_Data IS NOT NULL");
            sb.AppendLine("         AND STemp_HoraFim IS NULL");
            sb.AppendLine(" ) AS Aberta,");
            sb.AppendLine(" Sol_Id as Id,");
            sb.AppendLine(" Sol_Titulo as Titulo,");
            sb.AppendLine(" Sol_UsuarioAtendeAtual as IdUsuarioAtendeAtual,");
            sb.AppendLine(" Sol_Nivel as Nivel,");
            sb.AppendLine(" Cli_Nome as ClienteNome,");
            sb.AppendLine(" Usu_Nome as UsuarioNome,");
            sb.AppendLine(" Sol_Status as IdStatus");
            sb.AppendLine(" FROM Solicitacao");
            sb.AppendLine(" INNER JOIN Cliente ON Sol_Cliente = Cli_Id");
            sb.AppendLine(" INNER JOIN Status ON Sol_Status = Sta_Id");
            sb.AppendLine(" INNER JOIN Parametros ON Sta_Codigo = COALESCE(Par_Valor, 0)");
            sb.AppendLine(" LEFT JOIN Usuario ON Sol_UsuarioAtendeAtual = Usu_Id");
            sb.AppendLine(" WHERE Par_Codigo = " + parCodigo);
            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" SELECT 1 FROM Usuario WHERE((Cli_Revenda = Usu_Revenda) OR(Usu_Revenda IS NULL))");
            sb.AppendLine(" AND Usu_Id = " + idUsuario + ")");
            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" SELECT 1 FROM Usuario WHERE((Cli_Id = Usu_Cliente) OR(Usu_Cliente IS NULL))");
            sb.AppendLine(" AND Usu_Id = " + idUsuario + ")");

            if (parCodigo < 24)
                sb.AppendLine(" UNION ");

            return sb.ToString();
        }
    }
}
