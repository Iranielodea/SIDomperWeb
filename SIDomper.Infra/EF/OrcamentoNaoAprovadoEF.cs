using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class OrcamentoNaoAprovadoEF
    {
        private readonly Repositorio<OrcamentoNaoAprovado> _rep;

        public OrcamentoNaoAprovadoEF()
        {
            _rep = new Repositorio<OrcamentoNaoAprovado>();
        }

        public OrcamentoNaoAprovado ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IQueryable<OrcamentoNaoAprovado> ObterPorOrcamentoId(int idOrcamento)
        {
            return _rep.Get(x => x.OrcamentoId == idOrcamento);
        }

        public void Excluir(int id)
        {
            var model = ObterPorId(id);
            _rep.Deletar(model);
            _rep.Commit();
        }

        public void Salvar(OrcamentoNaoAprovado model)
        {
            _rep.Salvar(model);
            _rep.Commit();
        }
    }
}
