using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System.Collections.Generic;

namespace SIDomper.Servicos.Regras
{
    public class FormaPagtoItensServico
    {
        private readonly FormaPagtoItensEF _rep;

        public FormaPagtoItensServico()
        {
            _rep = new FormaPagtoItensEF();
        }

        public FormaPagtoItens ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public List<FormaPagtoItens> ListarPorForma(int idFormaPagto)
        {
            return _rep.ListarPorForma(idFormaPagto);
        }
    }
}
