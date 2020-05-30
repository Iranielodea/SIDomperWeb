using SIDomper.Dominio.ViewModel;
using System.Collections.Generic;
using System.Text;

namespace SIDomper.Infra.RepositorioDapper
{
    public class BaseConhecimentoRepositorioDapper
    {
        private readonly RepositorioDapper<BaseConhConsultaViewModel> _repositorioConsulta;

        public BaseConhecimentoRepositorioDapper()
        {
            _repositorioConsulta = new RepositorioDapper<BaseConhConsultaViewModel>();
        }

        public IEnumerable<BaseConhConsultaViewModel> Filtrar(BaseConhecimentoFiltroViewModel filtro, string campo, string texto, int usuarioId, bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" Bas_Id as Id, ");
            sb.AppendLine(" Bas_Data as Data, ");
            sb.AppendLine(" Bas_Nome as Nome, ");
            sb.AppendLine(" Usu_Nome as NomeUsuario, ");
            sb.AppendLine(" Tip_Nome as NomeTipo, ");
            sb.AppendLine(" Sta_Nome as NomeStatus ");
            sb.AppendLine(" FROM Base");
            sb.AppendLine(" INNER JOIN Usuario ON Bas_Usuario = Usu_id");
            sb.AppendLine(" INNER JOIN Tipo ON Bas_Tipo = Tip_id");
            sb.AppendLine(" INNER JOIN Status ON Bas_Status = Sta_Id");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine(" WHERE Bas_Id > 0");

            if (!Comun.Funcoes.DataEmBranco(filtro.DataInicial))
                sb.AppendLine(" AND Bas_Data >= " + Comun.Funcoes.DataIngles(filtro.DataInicial));

            if (!Comun.Funcoes.DataEmBranco(filtro.DataFinal))
                sb.AppendLine(" AND Bas_Data <= " + Comun.Funcoes.DataIngles(filtro.DataFinal));

            if (!string.IsNullOrWhiteSpace(filtro.ModuloId))
                sb.AppendLine(" AND Bas_Modulo IN (" + filtro.ModuloId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.ProdutoId))
                sb.AppendLine(" AND Bas_Produto IN (" + filtro.ModuloId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.StatusId))
                sb.AppendLine(" AND Bas_Status IN (" + filtro.StatusId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.TipoId))
                sb.AppendLine(" AND Bas_Tipo IN (" + filtro.TipoId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.UsuarioId))
                sb.AppendLine(" AND Bas_Usuario IN (" + filtro.UsuarioId + ")");

            sb.AppendLine(" ORDER BY " + campo);

            var lista = _repositorioConsulta.GetAll(sb.ToString());

            return lista;
        }
    }
}
