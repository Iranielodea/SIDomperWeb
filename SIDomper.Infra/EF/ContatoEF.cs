using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class ContatoEF
    {
        private readonly Repositorio<Contato> _rep;

        public ContatoEF()
        {
            _rep = new Repositorio<Contato>();
        }

        public Contato ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public void ExcluirPorCliente(int clienteId)
        {
            _rep.DeleteAll(x => x.ClienteId == clienteId);
        }

        public void Commit()
        {
            _rep.Commit();
        }
    }
}
