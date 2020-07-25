using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioVersao : RepositorioBaseEF<Versao>, IRepositorioVersao
    {
        public RepositorioVersao(Contexto contexto) : base(contexto)
        {
        }
    }
}
