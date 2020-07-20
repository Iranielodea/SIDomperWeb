using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioEscala : RepositorioBaseEF<Escala>, IRepositorioEscala
    {
        public RepositorioEscala(Contexto contexto) : base(contexto)
        {
        }
    }
}
