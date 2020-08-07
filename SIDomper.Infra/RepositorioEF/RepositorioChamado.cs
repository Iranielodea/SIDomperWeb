using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;
using System.Linq;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioChamado : RepositorioBaseEF<Chamado>, IRepositorioChamado
    {
        public RepositorioChamado(Contexto contexto) : base(contexto)
        {
        }

        public string CaminhoAnexo()
        {
            return base.context.Parametros.FirstOrDefault(x => x.Codigo == 49 && x.Programa == 0).Valor;
        }

        public string StatusAbertura()
        {
            return base.context.Parametros.FirstOrDefault(x => x.Codigo == 9 && x.Programa == 1).Valor;
        }

        public string StatusAberturaAtividade()
        {
            return base.context.Parametros.FirstOrDefault(x => x.Codigo == 31 && x.Programa == 111).Valor;
        }

        public string StatusAtendimentoAtividade()
        {
            return base.context.Parametros.FirstOrDefault(x => x.Codigo == 32 && x.Programa == 111).Valor;
        }

        public string StatusAtendimentoChamado()
        {
            return base.context.Parametros.FirstOrDefault(x => x.Codigo == 10 && x.Programa == 1).Valor;
        }

        public string UsuarioAplicativo()
        {
            return base.context.Parametros.FirstOrDefault(x => x.Codigo == 54 && x.Programa == 0).Valor;
        }
    }
}
