using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioObservacao : RepositorioBaseEF<Observacao>, IRepositorioObservacao
    {
        public RepositorioObservacao(Contexto contexto) : base(contexto)
        {
        }
    }
}
