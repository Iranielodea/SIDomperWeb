using SIDomper.Dominio.ViewModel;
using SIDomper.Infra.Comun;
using System.Collections.Generic;
using System.Text;

namespace SIDomper.Infra.RepositorioDapper
{
    public class VersaoRepositorioDapper
    {
        private readonly RepositorioDapper<VersaoConsultaViewModel> _repositorioConsulta;

        public VersaoRepositorioDapper()
        {
            _repositorioConsulta = new RepositorioDapper<VersaoConsultaViewModel>();
        }

        public IEnumerable<VersaoConsultaViewModel> Filtrar(VersaoFiltroViewModel filtro, string campo, string texto, bool contem)
        {
            string consulta = " SELECT"
                + "  Ver_DataInicio as DataInicio,"
                + "  Ver_DataLiberacao as DataLiberacao,"
                + "  Ver_Descricao as Descricao,"
                + "  Ver_Id as Id,"
                + "  Ver_Versao as VersaoStr,"
                + "  Sta_Nome as NomeStatus,"
                + "  Tip_Nome as NomeTipo,"
                + "  Usu_Nome as NomeUsuario"
                + " FROM Versao"
                + " 	INNER JOIN Status ON Ver_Status = Sta_Id"
                + " 	INNER JOIN Tipo ON Ver_Tipo = Tip_Id"
                + " 	INNER JOIN Usuario ON Ver_Usuario = Usu_Id";

            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();
            sb.AppendLine(consulta);

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine(" WHERE Ver_Id > 0");
            }

            if (filtro.Id > 0)
                sb.AppendLine(" AND Ver_Id = " + filtro.Id);

            if (!Funcoes.DataEmBranco(filtro.DataInicial))
                sb.AppendLine(" AND Ver_DataInicio >= " + Funcoes.DataIngles(filtro.DataInicial));
            if (!Funcoes.DataEmBranco(filtro.DataFinal))
                sb.AppendLine(" AND Ver_DataInicio <= " + Funcoes.DataIngles(filtro.DataFinal));

            if (!Funcoes.DataEmBranco(filtro.DataLiberacaoInicial))
                sb.AppendLine(" AND Ver_DataLiberacao >= " + Funcoes.DataIngles(filtro.DataLiberacaoInicial));
            if (!Funcoes.DataEmBranco(filtro.DataLiberacaoFinal))
                sb.AppendLine(" AND Ver_DataLiberacao <= " + Funcoes.DataIngles(filtro.DataLiberacaoFinal));

            if (!string.IsNullOrWhiteSpace(filtro.UsuarioId))
                sb.AppendLine(" AND Ver_Usuario IN (" + filtro.UsuarioId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.StatusId))
                sb.AppendLine(" AND Ver_Status IN (" + filtro.StatusId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.TipoId))
                sb.AppendLine(" AND Ver_Tipo IN (" + filtro.TipoId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.ProdutoId))
                sb.AppendLine(" AND Ver_Produto IN (" + filtro.ProdutoId + ")");

            sb.AppendLine(" ORDER BY " + campo);
            var lista = _repositorioConsulta.GetAll(sb.ToString());

            return lista;
        }
    }
}
