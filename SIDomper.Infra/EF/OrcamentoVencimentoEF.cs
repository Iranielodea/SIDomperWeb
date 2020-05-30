using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.EF
{
    public class OrcamentoVencimentoEF
    {
        private readonly Repositorio<OrcamentoVencimento> _rep;

        public OrcamentoVencimentoEF()
        {
            _rep = new Repositorio<OrcamentoVencimento>();
        }

        public OrcamentoVencimento ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IQueryable<OrcamentoVencimento> ObterPorOrcamentoId(int idOrcamento)
        {
            return _rep.Get(x => x.OrcamentoId == idOrcamento);
        }
    }
}
