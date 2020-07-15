using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioProduto : RepositorioBaseEF<Produto>, IRepositorioProduto
    {
        public RepositorioProduto(Contexto contexto) : base(contexto)
        {
        }
    }
}
