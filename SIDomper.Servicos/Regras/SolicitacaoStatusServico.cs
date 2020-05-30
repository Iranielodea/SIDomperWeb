using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class SolicitacaoStatusServico
    {
        private readonly SolicitacaoStatusEF _rep;

        public SolicitacaoStatusServico()
        {
            _rep = new SolicitacaoStatusEF();
        }

        public void Salvar(SolicitacaoStatus model)
        {
            _rep.Salvar(model);
        }

        public void Excluir(SolicitacaoStatus model)
        {
            _rep.Excluir(model);
        }
    }
}
