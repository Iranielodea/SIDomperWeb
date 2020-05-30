using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;

namespace SIDomper.Servicos.Regras
{
    public class ProspectServico
    {
        private readonly ProspectEF _rep;

        public ProspectServico()
        {
            _rep = new ProspectEF();
        }

        public Prospect ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }
    }
}
