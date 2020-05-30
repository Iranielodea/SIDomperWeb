using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class ClienteEmailServico
    {
        private readonly ClienteEmailEF _rep;

        public ClienteEmailServico()
        {
            _rep = new ClienteEmailEF();
        }

        public ClienteEmail ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }
    }
}
