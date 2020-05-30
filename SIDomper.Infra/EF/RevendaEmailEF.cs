using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class RevendaEmailEF
    {
        private readonly Repositorio<RevendaEmail> _rep;

        public RevendaEmailEF()
        {
            _rep = new Repositorio<RevendaEmail>();
        }

        public RevendaEmail ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IQueryable<RevendaEmail> ObterPorRevenda(int revendaId)
        {
            return _rep.Get(x => x.RevendaId == revendaId);
        }
    }
}
