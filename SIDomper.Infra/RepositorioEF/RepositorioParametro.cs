using System.Collections.Generic;
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
    }
}
