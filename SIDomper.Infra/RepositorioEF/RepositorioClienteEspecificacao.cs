using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioClienteEspecificacao : RepositorioBaseEF<ClienteEspecifiacao>, IRepositorioClienteEspecificacao
    {
        public RepositorioClienteEspecificacao(Contexto contexto) : base(contexto)
        {
        }
    }
}
