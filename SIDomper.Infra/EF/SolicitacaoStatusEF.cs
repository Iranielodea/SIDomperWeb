using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class SolicitacaoStatusEF
    {
        private Repositorio<SolicitacaoStatus> _rep;

        public SolicitacaoStatusEF()
        {
            _rep = new Repositorio<SolicitacaoStatus>();
        }

        public void Salvar(SolicitacaoStatus model)
        {
            if (model.Id > 0)
                _rep.Update(model);
            else
                _rep.Add(model);
        }

        public void Excluir(SolicitacaoStatus model)
        {
            _rep.Deletar(model);
        }
    }
}
