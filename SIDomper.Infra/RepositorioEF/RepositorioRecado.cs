using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioRecado : RepositorioBaseEF<Recado>, IRepositorioRecado
    {
        public RepositorioRecado(Contexto contexto) : base(contexto)
        {
        }
    }
}
