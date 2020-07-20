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
    }
}
