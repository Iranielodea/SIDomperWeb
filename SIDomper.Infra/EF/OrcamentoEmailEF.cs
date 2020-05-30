using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System.Linq;

namespace SIDomper.Infra.EF
{
    public class OrcamentoEmailEF
    {
        private readonly Repositorio<OrcamentoEmail> _rep;

        public OrcamentoEmailEF()
        {
            _rep = new Repositorio<OrcamentoEmail>();
        }

        public OrcamentoEmail ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IQueryable<OrcamentoEmail> ObterPorOrcamentoId(int idOrcamento)
        {
            return _rep.Get(x => x.OrcamentoId == idOrcamento);
        }
    }
}
