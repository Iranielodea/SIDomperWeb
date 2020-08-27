using System.Collections.Generic;
using System.Text;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioParametro : RepositorioBaseEF<Parametro>, IRepositorioParametro
    {
        public RepositorioParametro(Contexto contexto) : base(contexto)
        {
        }

        public Parametro ObterPorParametro(int codigo, int programa)
        {
            if (programa == 0)
                return base.First(x => x.Codigo == codigo);
            else
                return base.First(x => x.Codigo == codigo && x.Programa == programa);
        }

        public IEnumerable<Parametro> BuscarTitulosChamados()
        {
            return base.Get(x => x.Codigo == 3 || x.Codigo == 4 || x.Codigo == 5 || x.Codigo == 6 || x.Codigo == 7 || x.Codigo == 8);
        }

        public string BuscarTitulosQuadro()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" Par_Codigo AS CodigoParametro,");
            sb.AppendLine(" Sta_Codigo AS CodigoStatus,");
            sb.AppendLine(" Sta_Nome AS NomeStatus");
            sb.AppendLine(" FROM Parametros");
            sb.AppendLine(" INNER JOIN Status ON Par_Valor = Sta_Codigo");
            sb.AppendLine(" WHERE Par_Codigo IN (3, 4, 5, 6, 7, 8, 12, 13, 14, 15, 16, 17, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30)");
            return sb.ToString();
        }
    }
}
