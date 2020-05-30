using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class ProspectEF
    {
        private readonly Repositorio<Prospect> _rep;

        public ProspectEF()
        {
            _rep = new Repositorio<Prospect>();
        }

        public Prospect ObterPorId(int id)
        {
            return _rep.find(id);
        }
    }
}
