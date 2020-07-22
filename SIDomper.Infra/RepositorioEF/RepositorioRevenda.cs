using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioRevenda : RepositorioBaseEF<Revenda>, IRepositorioRevenda
    {
        public RepositorioRevenda(Contexto contexto) : base(contexto)
        {
        }
    }
}
