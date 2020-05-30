using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class FormaPagtoItensEF
    {
        private readonly Repositorio<FormaPagtoItens> _rep;

        public FormaPagtoItensEF()
        {
            _rep = new Repositorio<FormaPagtoItens>();
        }

        public FormaPagtoItens ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public List<FormaPagtoItens> ListarPorForma(int idFormaPagto)
        {
            return _rep.Get(x => x.FormaPagtoId == idFormaPagto).ToList();
        }
    }
}
