using SIDomper.Dominio.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.RepositorioDapper
{
    public class ClienteRepositorioDapper
    {
        private readonly RepositorioDapper<ClienteConsultaViewModelApi> _repositorioConsulta;

        public ClienteRepositorioDapper()
        {
            _repositorioConsulta = new RepositorioDapper<ClienteConsultaViewModelApi>();
        }

        public IEnumerable<ClienteConsultaViewModelApi> Filtrar(int idUsuario, ClienteFiltroViewModelApi filtro, int modelo, string campo, string valor, bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + valor + "%'";
            if (contem)
                sTexto = "'%" + valor + "%'";

            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" Cli_Codigo as Codigo");
            sb.AppendLine(",Cli_Perfil as Perfil");
            sb.AppendLine(",Cli_Versao as Versao");
            sb.AppendLine(",Cli_Id as Id");
            sb.AppendLine(",cli_Fantasia as Fantasia");
            sb.AppendLine(",cli_Nome as Razao");
            sb.AppendLine(",cli_Dcto as Documento");
            sb.AppendLine(",Cli_Fone1 as Telefone");
            sb.AppendLine(",Cli_Enquadramento as Enquadramento");
            sb.AppendLine(",Usu_Nome as NomeConsultor, Rev_Nome");
            sb.AppendLine(",Rev_Nome as NomeRevenda");
            sb.AppendLine(" FROM Cliente");
            sb.AppendLine(" INNER JOIN Revenda ON Cli_Revenda = Rev_Id");
            sb.AppendLine(" LEFT JOIN Usuario ON Cli_Usuario = Usu_Id");
            sb.AppendLine(" WHERE Cli_Id IS NOT NULL");
            sb.AppendLine(" AND " + campo + " LIKE " + sTexto);

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Revenda = Usu_Revenda) OR (Usu_Revenda IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Id = Usu_Cliente) OR (Usu_Cliente IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            if (filtro.Ativo != "T")
            {
                if (filtro.Ativo == "A")
                    sb.AppendLine(" AND Cli_Ativo = 1");
                else
                    sb.AppendLine(" AND Cli_Ativo = 0");
            }

            if (filtro.UsuarioId > 0)
                sb.AppendLine("  AND Cli_Usuario =" + filtro.UsuarioId);

            if (filtro.RevendaId > 0)
                sb.AppendLine("  AND Cli_Revenda =" + filtro.RevendaId);

            if (!string.IsNullOrEmpty(filtro.FiltroIdUsuario))
                sb.AppendLine("  AND Cli_Usuario in (" + filtro.FiltroIdUsuario + ")");

            if (filtro.Restricao < 2)
            {
                if (filtro.Restricao == 0)
                    sb.AppendLine("  AND Cli_Restricao = 1");

                if (filtro.Restricao == 1)
                    sb.AppendLine("  AND Cli_Restricao = 0");
            }

            if (filtro.Id > 0)
                sb.AppendLine("  AND Cli_Id =" + filtro.Id);

            if (!string.IsNullOrWhiteSpace(filtro.Enquadramento))
                sb.AppendLine("  AND Cli_Enquadramento = '" + filtro.Enquadramento + "'");

            if (filtro.CidadeId > 0)
                sb.AppendLine("  AND Cli_Cidade =" + filtro.CidadeId);

            if (!string.IsNullOrEmpty(filtro.FiltroIdCidade))
                sb.AppendLine("  AND Cli_Cidade in (" + filtro.FiltroIdCidade + ")");

            if (!string.IsNullOrWhiteSpace(filtro.Versao))
                sb.AppendLine("  AND Cli_Versao = '" + filtro.Versao + "'");

            if (filtro.EmpresaVinculada == "S")
                sb.AppendLine("  AND Cli_EmpresaVinculada > 0");

            if (filtro.EmpresaVinculada == "N")
                sb.AppendLine(" AND ((Cli_EmpresaVinculada = 0) OR (Cli_EmpresaVinculada IS NULL))");

            if (!string.IsNullOrWhiteSpace(filtro.Perfil))
                sb.AppendLine(" AND Cli_Perfil = '" + filtro.Perfil + "'");

            if (modelo == 2)
            {
                if (filtro.ModuloId > 0)
                    sb.AppendLine(" AND CliMod_Modulo = " + filtro.ModuloId);

                if (!string.IsNullOrEmpty(filtro.filtroIdModulo))
                    sb.AppendLine("  AND CliMod_Modulo in (" + filtro.filtroIdModulo + ")");

                if (filtro.ProdutoId > 0)
                    sb.AppendLine(" AND CliMod_Produto = " + filtro.ProdutoId);

                if (!string.IsNullOrEmpty(filtro.FiltroIdProduto))
                    sb.AppendLine("  AND CliMod_Produto in (" + filtro.FiltroIdProduto + ")");
            }
            else
            {
                if (filtro.ModuloId > 0)
                {
                    sb.AppendLine(" AND EXISTS(SELECT 1 FROM Cliente_Modulo ");
                    sb.AppendLine(" WHERE Cli_Id = CliMod_Cliente ");
                    sb.AppendLine("  AND CliMod_Modulo = " + filtro.ModuloId + ")");
                }

                if (!string.IsNullOrEmpty(filtro.filtroIdModulo))
                {
                    sb.AppendLine(" AND EXISTS(SELECT 1 FROM Cliente_Modulo ");
                    sb.AppendLine(" WHERE Cli_Id = CliMod_Cliente ");
                    sb.AppendLine("  AND CliMod_Modulo IN (" + filtro.filtroIdModulo + "))");
                }

                if (filtro.ProdutoId > 0)
                {
                    sb.AppendLine(" AND EXISTS(SELECT 1 FROM Cliente_Modulo ");
                    sb.AppendLine(" WHERE Cli_Id = CliMod_Cliente ");
                    sb.AppendLine("  AND CliMod_Produto = " + filtro.ProdutoId + ")");
                }

                if (!string.IsNullOrEmpty(filtro.FiltroIdProduto))
                {
                    sb.AppendLine(" AND EXISTS(SELECT 1 FROM Cliente_Modulo ");
                    sb.AppendLine(" WHERE Cli_Id = CliMod_Cliente ");
                    sb.AppendLine("  AND CliMod_Produto in (" + filtro.FiltroIdProduto + "))");
                }
            }
            sb.AppendLine(" ORDER BY " + campo);

            return _repositorioConsulta.GetAll(sb.ToString());
        }
    }
}
