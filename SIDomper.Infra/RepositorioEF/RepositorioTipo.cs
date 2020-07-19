using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioTipo : RepositorioBaseEF<Tipo>, IRepositorioTipo
    {
        public RepositorioTipo(Contexto contexto) : base(contexto)
        {
        }
    }
}
