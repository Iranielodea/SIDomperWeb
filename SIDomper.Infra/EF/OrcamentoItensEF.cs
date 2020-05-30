using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System.Linq;

namespace SIDomper.Infra.EF
{
    public class OrcamentoItensEF
    {
        private readonly Repositorio<OrcamentoItem> _rep;
        public OrcamentoItensEF()
        {
            _rep = new Repositorio<OrcamentoItem>();
        }

        public OrcamentoItem ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IQueryable<OrcamentoItem> ObterPorOrcamentoId(int idOrcamento)
        {
            return _rep.Get(x => x.OrcamentoId == idOrcamento);
        }
    }
}
