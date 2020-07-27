using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioVisita : RepositorioBaseEF<Visita>, IRepositorioVisita
    {
        public RepositorioVisita(Contexto contexto) : base(contexto)
        {
        }
    }
}
