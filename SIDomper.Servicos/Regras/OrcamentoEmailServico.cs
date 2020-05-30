using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class OrcamentoEmailServico
    {
        private readonly OrcamentoEmailEF _rep;

        public OrcamentoEmailServico()
        {
            _rep = new OrcamentoEmailEF();
        }

        public OrcamentoEmail ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public List<OrcamentoEmail> ObterPorOrcamentoId(int idOrcamento)
        {
            return _rep.ObterPorOrcamentoId(idOrcamento).ToList();
        }
    }
}
