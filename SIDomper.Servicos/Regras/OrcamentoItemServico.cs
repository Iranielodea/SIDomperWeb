using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class OrcamentoItemServico
    {
        private readonly OrcamentoItensEF _rep;

        public OrcamentoItemServico()
        {
            _rep = new OrcamentoItensEF();
        }

        public OrcamentoItem ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public List<OrcamentoItem> ObterPorOrcamentoId(int idOrcamento)
        {
            return _rep.ObterPorOrcamentoId(idOrcamento).ToList();
        }
    }
}
