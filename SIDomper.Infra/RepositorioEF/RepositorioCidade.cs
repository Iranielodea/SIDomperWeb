using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioCidade : RepositorioBaseEF<Cidade>, IRepositorioCidade
    {
        public RepositorioCidade(Contexto contexto) : base(contexto)
        {
        }
    }
}
