using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Infra.Comun;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.RepositorioDapper
{
    public class ChamadoRepositorioDapper
    {
        private readonly RepositorioDapper<ChamadoConsultaViewModel> _repositorioConsulta;
        private readonly RepositorioDapper<QuadroViewModelChamado> _repositorioQuadro;
        private readonly RepositorioDapper<ChamadoAplicativoViewModel> _repositorioAplicativo;

        public ChamadoRepositorioDapper()
        {
            _repositorioConsulta = new RepositorioDapper<ChamadoConsultaViewModel>();
            _repositorioQuadro = new RepositorioDapper<QuadroViewModelChamado>();
            _repositorioAplicativo = new RepositorioDapper<ChamadoAplicativoViewModel>();
        }

        public IEnumerable<ChamadoConsultaViewModel> Filtrar(ChamadoFiltroViewModel filtro, string campo, string texto, int usuarioId, bool contem, EnumChamado tipo)
        {
            var usuarioCliente = new UsuarioEF();
            var sb = new StringBuilder();
            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'" + texto + "%'";

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Cha_Id as Id,");
            sb.AppendLine(" '' as Descricao,");
            sb.AppendLine(" Cha_DataAbertura as DataAbertura,");
            sb.AppendLine(" Cha_HoraAbertura as HoraAbertura,");
            sb.AppendLine(" Sta_Nome as NomeStatus,");
            sb.AppendLine(" Cha_Status as IdStatus,");
            sb.AppendLine(" Tip_Nome as NomeTipo,");
            sb.AppendLine(" Cli_Nome as RazaoSocial,");
            sb.AppendLine(" Cli_Fantasia as Fantasia,");
            sb.AppendLine(" CASE Cha_Nivel");
            sb.AppendLine("   WHEN 1 THEN '1-Baixo'");
            sb.AppendLine("   WHEN 2 THEN '2-Normal'");
            sb.AppendLine("   WHEN 3 THEN '3-Alto'");
            sb.AppendLine("   WHEN 4 THEN '4-Crítico'");
            sb.AppendLine(" END AS Nivel,");
            sb.AppendLine(" Usu_Nome as NomeUsuario");
            sb.AppendLine(" FROM Chamado");
            sb.AppendLine("	INNER JOIN Status  ON Cha_Status = Sta_Id");
            sb.AppendLine("	INNER JOIN Tipo    ON Cha_Tipo = Tip_Id");
            sb.AppendLine(" INNER JOIN Cliente ON Cha_Cliente = Cli_Id");
            sb.AppendLine("	INNER JOIN Usuario ON Cha_UsuarioAbertura = Usu_Id");
            sb.AppendLine(" LEFT JOIN Revenda ON Cli_Revenda = Rev_Id");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine("WHERE Cha_Id > 0");
            }

            if (filtro.Id > 0)
                sb.AppendLine(" AND Cha_Id = " + filtro.Id);

            if (tipo == EnumChamado.Chamado)
                sb.AppendLine(" AND Cha_TipoMovimento = 1");
            else
                sb.AppendLine(" AND Cha_TipoMovimento = 2");

            sb.AppendLine(usuarioCliente.PermissaoUsuario(usuarioId));

            if ((!string.IsNullOrWhiteSpace(filtro.DataInicial)) && (filtro.DataInicial.Trim() != "/  /"))
                sb.AppendLine(" AND Cha_DataAbertura >=" + Funcoes.DataIngles(filtro.DataInicial));

            if ((!string.IsNullOrWhiteSpace(filtro.DataFinal)) && (filtro.DataFinal.Trim() != "/  /"))
                sb.AppendLine(" AND Cha_DataAbertura <=" + Funcoes.DataIngles(filtro.DataFinal));

            if (!string.IsNullOrWhiteSpace(filtro.IdCliente))
                sb.AppendLine(" AND Cha_Cliente IN " + filtro.IdCliente);

            if (!string.IsNullOrWhiteSpace(filtro.idTipo))
                sb.AppendLine(" AND Cha_Tipo IN " + filtro.idTipo);

            if (!string.IsNullOrWhiteSpace(filtro.IdStatus))
                sb.AppendLine(" AND Cha_Status IN " + filtro.IdStatus);

            if (!string.IsNullOrWhiteSpace(filtro.IdModulo))
                sb.AppendLine(" AND Cha_Modulo IN " + filtro.IdModulo);

            if (!string.IsNullOrWhiteSpace(filtro.IdRevenda))
                sb.AppendLine(" AND Cha_Revenda IN " + filtro.IdRevenda);

            if (!string.IsNullOrWhiteSpace(filtro.IdUsuarioAbertura))
                sb.AppendLine(" AND Cha_UsuarioAbertura IN " + filtro.IdUsuarioAbertura);

            if (filtro.clienteFiltro.UsuarioId > 0)
                sb.AppendLine(" AND Cli_Usuario IN " + filtro.clienteFiltro.UsuarioId);
            sb.AppendLine(" ORDER BY " + campo);

            var lista = _repositorioConsulta.GetAll(sb.ToString());

            return lista;
        }

        public IEnumerable<QuadroViewModelChamado> QuadroChamado(int idUsuario, int idRevenda, EnumChamado tipo)
        {
            var sb = new StringBuilder();

            if (tipo == EnumChamado.Chamado)
                sb.AppendLine(RetornarChamadoQuadro(idUsuario, idRevenda));
            else
                sb.AppendLine(RetornarAtividadeQuadro(idUsuario, idRevenda));

            var lista = _repositorioQuadro.GetAll(sb.ToString());

            return lista;
        }

        public IEnumerable<ChamadoAplicativoViewModel> RetornarDadosAplicativo(string cnpj)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT TOP(20)");
            sb.AppendLine(" Cha_Id as Id,");
            sb.AppendLine(" Cha_DataAbertura as Data,");
            sb.AppendLine(" Sta_Nome as Status ");
            sb.AppendLine("FROM Chamado");
            sb.AppendLine(" INNER JOIN Status ON Cha_Status = Sta_Id");
            sb.AppendLine(" INNER JOIN Cliente ON Cha_Cliente = Cli_Id");
            sb.AppendLine("WHERE Cli_Dcto = '"  + cnpj + "'");
            return _repositorioAplicativo.GetAll(sb.ToString());
        }

        private string RetornarSQLQuadro(int idUsuario, int idRevenda, int codigoParametro, string campoQuadro, EnumChamado tipo)
        {
            var usuario = new UsuarioEF();
            string sConsulta = usuario.PermissaoUsuario(idUsuario);

            var sb = new StringBuilder();

            sb.AppendLine(" SELECT");
            sb.Append(campoQuadro);
            sb.AppendLine("	Cha_Id as Id,");
            sb.AppendLine("	Cha_DataAbertura as DataAbertura,");
            sb.AppendLine("	Cha_HoraAbertura as HoraAbertura,");
            sb.AppendLine("	Cli_Nome as NomeCliente,");
            sb.AppendLine("	CASE cha_Nivel");
            sb.AppendLine("		WHEN 1 THEN '1-Baixo'");
            sb.AppendLine("		WHEN 2 THEN '2-Normal'");
            sb.AppendLine("		WHEN 3 THEN '3-Alto'");
            sb.AppendLine("		WHEN 4 THEN '4-Crítico'");
            sb.AppendLine("	END as NivelDescricao,");
            sb.AppendLine("  Cha_Nivel as Nivel,");
            sb.AppendLine("  Cha_UsuarioAtendeAtual as UsuarioAtendeAtualId,");
            sb.AppendLine("  Sta_Codigo as CodigoStatus,");
            sb.AppendLine("  Cli_Codigo as CodigoCliente,");
            sb.AppendLine("	Tip_Nome as NomeTipo,");
            sb.AppendLine("  UltimaHora = dbo.Func_Chamado_BuscarUltimaHoraOcorrencia (Cha_Id),");
            sb.AppendLine("	cha_HoraAtendeAtual as HoraAtendeAtual,");
            sb.AppendLine("  (");
            sb.AppendLine("	   SELECT MAX(CHAO.ChOco_Data) FROM dbo.Chamado_Ocorrencia AS CHAO");
            sb.AppendLine("		WHERE CHAO.ChOco_Chamado = dbo.Chamado.Cha_Id");
            sb.AppendLine(" 	) AS UltimaData,");
            sb.AppendLine("  Par_Codigo as CodigoParametro,");
            sb.AppendLine("	Usu_Nome as NomeUsuario");
            sb.AppendLine("FROM Chamado");
            sb.AppendLine("	INNER JOIN Cliente ON Cha_Cliente = Cli_Id");
            sb.AppendLine("	INNER JOIN Tipo ON Cha_Tipo = Tip_Id");
            sb.AppendLine("	INNER JOIN Status ON Cha_Status = Sta_Id");
            sb.AppendLine("	LEFT JOIN Parametros ON Sta_Codigo = COALESCE(Par_Valor, 0)");
            sb.AppendLine("  LEFT JOIN Usuario ON Cha_UsuarioAtendeAtual = Usu_Id");
            sb.AppendLine("WHERE par_Codigo = " + codigoParametro);
            sb.AppendLine(sConsulta);
            //sb.AppendLine("AND EXISTS(");
            //sb.AppendLine("	SELECT 1 FROM Usuario WHERE ((Cli_Revenda = Usu_Revenda) OR (Usu_Revenda IS NULL))");
            //sb.AppendLine("	AND Usu_Id = " + idUsuario + ")");
            //sb.AppendLine("AND EXISTS(");
            //sb.AppendLine("	SELECT 1 FROM Usuario WHERE ((Cli_Id = Usu_Cliente) OR (Usu_Cliente IS NULL))");
            //sb.AppendLine("	AND Usu_Id = " + idUsuario + ")");

            if (idRevenda > 0)
                sb.AppendLine("AND (Cli_Revenda = " + idUsuario + ")");

            sb.AppendLine(" --=============================================================================");

            if (tipo == EnumChamado.Chamado)
            {
                if (codigoParametro < 8)
                    sb.AppendLine(" UNION ");
            }
            else
            {
                if (codigoParametro < 30)
                    sb.AppendLine(" UNION ");
            }
            return sb.ToString();
        }

        private string RetornarChamadoQuadro(int idUsuario, int idRevenda)
        {
            var sb = new StringBuilder();
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 3, "'Q1' AS Quadro,", EnumChamado.Chamado));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 4, "'Q2' AS Quadro,", EnumChamado.Chamado));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 5, "'Q3' AS Quadro,", EnumChamado.Chamado));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 6, "'Q4' AS Quadro,", EnumChamado.Chamado));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 7, "'Q5' AS Quadro,", EnumChamado.Chamado));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 8, "'Q6' AS Quadro,", EnumChamado.Chamado));

            return sb.ToString();
        }

        private string RetornarAtividadeQuadro(int idUsuario, int idRevenda)
        {
            var sb = new StringBuilder();
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 25, "'Q1' AS Quadro,", EnumChamado.Atividade));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 26, "'Q2' AS Quadro,", EnumChamado.Atividade));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 27, "'Q3' AS Quadro,", EnumChamado.Atividade));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 28, "'Q4' AS Quadro,", EnumChamado.Atividade));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 29, "'Q5' AS Quadro,", EnumChamado.Atividade));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 30, "'Q6' AS Quadro,", EnumChamado.Atividade));

            return sb.ToString();
        }
    }
}
