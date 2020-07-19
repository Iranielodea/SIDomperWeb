using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioContaEmail : RepositorioBaseEF<ContaEmail>, IRepositorioContaEmail
    {
        public RepositorioContaEmail(Contexto contexto) : base(contexto)
        {
        }
    }
}
