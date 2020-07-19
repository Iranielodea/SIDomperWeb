using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioModulo : RepositorioBaseEF<Modulo>, IRepositorioModulo
    {
        public RepositorioModulo(Contexto contexto) : base(contexto)
        {
        }
    }
}
