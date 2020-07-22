using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioRamal : RepositorioBaseEF<Ramal>, IRepositorioRamal
    {
        public RepositorioRamal(Contexto contexto) : base(contexto)
        {
        }
    }
}
