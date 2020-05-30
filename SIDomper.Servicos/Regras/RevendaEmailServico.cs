using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Servicos.Regras
{
    public class RevendaEmailServico
    {
        private readonly RevendaEmailEF _rep;

        public RevendaEmailServico()
        {
            _rep = new RevendaEmailEF();
        }

        public RevendaEmail ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public List<RevendaEmail> ObterPorRevenda(int revendaId)
        {
            return _rep.ObterPorRevenda(revendaId).ToList();
        }
    }
}
