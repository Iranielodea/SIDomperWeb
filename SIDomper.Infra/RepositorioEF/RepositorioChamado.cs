using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioChamado : RepositorioBaseEF<Chamado>, IRepositorioChamado
    {
        public RepositorioChamado(Contexto contexto) : base(contexto)
        {
        }
    }
}
