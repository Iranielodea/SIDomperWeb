using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioCliente : RepositorioBaseEF<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(Contexto contexto) : base(contexto)
        {
        }
    }
}
