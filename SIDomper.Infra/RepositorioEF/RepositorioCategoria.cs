using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioCategoria : RepositorioBaseEF<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoria(Contexto contexto) : base(contexto)
        {
        }
    }
}
