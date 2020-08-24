using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;
using System.Linq;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioSolicitacao : RepositorioBaseEF<Solicitacao>, IRepositorioSolicitacao
    {
        public RepositorioSolicitacao(Contexto contexto) : base(contexto)
        {
        }

        public string RetornarCaminhoAnexo()
        {
            return base.context.Parametros.FirstOrDefault(x => x.Codigo == 48 && x.Programa == 0).Valor;
        }

        public string StatusAbertura()
        {
            return base.context.Parametros.FirstOrDefault(x => x.Codigo == 18 && x.Programa == 3).Valor;
        }

        public string StatusEncerramento()
        {
            return base.context.Parametros.FirstOrDefault(x => x.Codigo == 46 && x.Programa == 3).Valor;
        }

        public string StatusOcorrencia()
        {
            return base.context.Parametros.FirstOrDefault(x => x.Codigo == 19 && x.Programa == 3).Valor;
        }
    }
}
