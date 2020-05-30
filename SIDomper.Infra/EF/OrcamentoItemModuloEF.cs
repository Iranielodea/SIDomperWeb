using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System.Linq;

namespace SIDomper.Infra.EF
{
    public class OrcamentoItemModuloEF
    {
        private readonly Repositorio<OrcamentoItemModulo> _rep;

        public OrcamentoItemModuloEF()
        {
            _rep = new Repositorio<OrcamentoItemModulo>();
        }

        public OrcamentoItemModulo ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IQueryable<OrcamentoItemModulo> ObterPorOrcamentoId(int idOrcamento)
        {
            return _rep.Get(x => x.OrcamentoItemId == idOrcamento);
        }
    }
}
