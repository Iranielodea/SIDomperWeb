using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class ContatoServico
    {
        private readonly ContatoEF _rep;

        public ContatoServico()
        {
            _rep = new ContatoEF();
        }

        public Contato ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }
    }
}
