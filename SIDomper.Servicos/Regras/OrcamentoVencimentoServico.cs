using SIDomper.Infra.EF;
using SIDomper.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class OrcamentoVencimentoServico
    {
        private readonly OrcamentoVencimentoEF _rep;

        public OrcamentoVencimentoServico()
        {
            _rep = new OrcamentoVencimentoEF();
        }

        public OrcamentoVencimento ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public List<OrcamentoVencimento> ObterPorOrcamentoId(int idOrcamento)
        {
            return _rep.ObterPorOrcamentoId(idOrcamento).ToList();
        }
    }
}
