using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioBaseConhecimento : RepositorioBaseEF<BaseConhecimento>, IRepositorioBaseConhecimento
    {
        public RepositorioBaseConhecimento(Contexto contexto) : base(contexto)
        {
        }
    }
}
