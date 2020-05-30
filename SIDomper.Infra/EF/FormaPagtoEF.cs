using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class FormaPagtoEF
    {
        private readonly Repositorio<FormaPagto> _rep;

        public FormaPagtoEF()
        {
            _rep = new Repositorio<FormaPagto>();
        }

        public FormaPagto ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IQueryable<FormaPagto> Listar(string nome)
        {
            return _rep.Get(x => x.Nome.Contains(nome) && x.Ativo == true).OrderBy(b => b.Nome);
        }

        public void Salvar(FormaPagto model)
        {
            if (model.Id == 0)
                _rep.Add(model);
            else
                _rep.Update(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }
    }
}
