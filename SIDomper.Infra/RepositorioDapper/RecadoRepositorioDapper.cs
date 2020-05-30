using SIDomper.Dominio.ViewModel;
using SIDomper.Infra.Comun;
using System.Collections.Generic;
using System.Text;

namespace SIDomper.Infra.RepositorioDapper
{
    public class RecadoRepositorioDapper
    {
        private readonly RepositorioDapper<RecadoConsultaViewModel> _repositorioConsulta;

        public RecadoRepositorioDapper()
        {
            _repositorioConsulta = new RepositorioDapper<RecadoConsultaViewModel>();
        }

        public IEnumerable<RecadoConsultaViewModel> Filtrar(RecadoFiltroViewModel filtro)
        {
            string sTexto;
            sTexto = "'" + filtro.Texto + "%'";
            if (filtro.Contem)
                sTexto = "'%" + filtro.Texto + "%'";

            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine(" Rec_Id as Id,");
            sb.AppendLine(" Rec_Data as Data,");
            sb.AppendLine(" Rec_Nivel as Nivel,");
            sb.AppendLine(" Rec_RazaoSocial as RazaoSocial,");
            sb.AppendLine(" Rec_Telefone as Telefone,");
            sb.AppendLine(" Lcto.Usu_Nome as NomeUsuarioLancamento,");
            sb.AppendLine(" Dest.Usu_Nome as NomeUsuarioDestino,");
            sb.AppendLine(" Sta_Nome as NomeStatus");
            sb.AppendLine(" FROM Recado");
            sb.AppendLine(" INNER JOIN Usuario Lcto ON Rec_UsuarioLcto = Lcto.Usu_Id");
            sb.AppendLine(" LEFT JOIN Usuario Dest ON Rec_UsuarioDestino = Dest.Usu_Id");
            sb.AppendLine(" LEFT JOIN Status ON Rec_Status = Sta_Id");

            if (!string.IsNullOrEmpty(filtro.Texto))
            {
                if (filtro.Campo == "Rec_Data")
                    sb.AppendLine(" WHERE " + filtro.Campo + " = '" + filtro.Texto + "'");
                else
                    sb.AppendLine(" WHERE " + filtro.Campo + " LIKE " + sTexto);
            }
            else
            {
                sb.AppendLine(" WHERE Rec_Id > 0");
            }

            if (!Funcoes.DataEmBranco(filtro.DataInicial))
                sb.AppendLine(" AND Rec_Data >= " + Funcoes.DataIngles(filtro.DataInicial));
            if (!Funcoes.DataEmBranco(filtro.DataFinal))
                sb.AppendLine(" AND Rec_Data <= " + Funcoes.DataIngles(filtro.DataFinal));

            if (!Funcoes.DataEmBranco(filtro.DataInicialDest))
                sb.AppendLine(" AND Rec_Final >= " + Funcoes.DataIngles(filtro.DataInicialDest));
            if (!Funcoes.DataEmBranco(filtro.DataFinal))
                sb.AppendLine(" AND Rec_Final <= " + Funcoes.DataIngles(filtro.DataFinalDest));

            if (!string.IsNullOrWhiteSpace(filtro.IdUsuarioLcto))
                sb.AppendLine(" AND Rec_UsuarioLcto in " + filtro.IdUsuarioLcto);

            if (!string.IsNullOrWhiteSpace(filtro.IdUsuarioDestino))
                sb.AppendLine(" AND Rec_UsuarioDestino in " + filtro.IdUsuarioDestino);

            if (!string.IsNullOrWhiteSpace(filtro.IdStatus))
                sb.AppendLine(" AND Rec_Status in " + filtro.IdStatus);

            if (!string.IsNullOrWhiteSpace(filtro.IdCliente))
                sb.AppendLine(" AND Rec_Cliente in " + filtro.IdCliente);

            return _repositorioConsulta.GetAll(sb.ToString());
        }
    }
}
