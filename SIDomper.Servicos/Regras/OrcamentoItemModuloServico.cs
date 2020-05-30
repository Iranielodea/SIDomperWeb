using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class OrcamentoItemModuloServico
    {
        private readonly OrcamentoItemModuloEF _rep;

        public OrcamentoItemModuloServico()
        {
            _rep = new OrcamentoItemModuloEF();
        }

        public OrcamentoItemModulo ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public List<OrcamentoItemModulo> ObterPorOrcamentoId(int idOrcamento)
        {
            return _rep.ObterPorOrcamentoId(idOrcamento).ToList();
        }
    }
}
