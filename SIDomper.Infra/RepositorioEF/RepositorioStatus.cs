using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioStatus : RepositorioBaseEF<Status>, IRepositorioStatus
    {
        public RepositorioStatus(Contexto contexto) : base(contexto)
        {
        }
    }
}
