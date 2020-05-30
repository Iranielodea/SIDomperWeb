using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class FormaPagtoServico
    {
        private readonly FormaPagtoEF _rep;

        public FormaPagtoServico()
        {
            _rep = new FormaPagtoEF();
        }

        public FormaPagto ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public List<FormaPagto> Listar(string nome)
        {
            return _rep.Listar(nome).ToList();
        }

        public void Salvar(FormaPagto model)
        {
            if (model.Codigo <= 0)
                throw new Exception("Informe o código!");
            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("Informe o nome!");

            _rep.Salvar(model);
            _rep.Commit();
        }
    }
}
