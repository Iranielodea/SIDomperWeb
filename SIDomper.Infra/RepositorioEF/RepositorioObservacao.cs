using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;
using System.Linq;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioObservacao : RepositorioBaseEF<Observacao>, IRepositorioObservacao
    {
        public RepositorioObservacao(Contexto contexto) : base(contexto)
        {
        }

        public Observacao ObterEmailPadrao(int? programa)
        {
            return base.First(x => x.EmailPadrao == true && x.Programa == programa && x.Ativo);
        }

        public Observacao ObterPadrao(int? programa)
        {
            return base.First(x => x.Padrao == true && x.Programa == programa && x.Ativo);
        }
    }
}
