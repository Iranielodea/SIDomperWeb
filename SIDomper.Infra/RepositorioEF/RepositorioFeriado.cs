using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioFeriado : RepositorioBaseEF<Feriado>, IRepositorioFeriado
    {
        public RepositorioFeriado(Contexto contexto) : base(contexto)
        {
        }
    }
}
