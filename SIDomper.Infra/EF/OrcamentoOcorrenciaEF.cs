using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System.Linq;

namespace SIDomper.Infra.EF
{
    public class OrcamentoOcorrenciaEF
    {
        private readonly Repositorio<OrcamentoOcorrencia> _rep;

        public OrcamentoOcorrenciaEF()
        {
            _rep = new Repositorio<OrcamentoOcorrencia>();
        }
        
        public OrcamentoOcorrencia ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IQueryable<OrcamentoOcorrencia> ObterPorOrcamentoId(int idOrcamento)
        {
            return _rep.Get(x => x.OrcamentoId == idOrcamento);
        }

        public void Salvar(OrcamentoOcorrencia model)
        {
            _rep.Salvar(model);
            _rep.Commit();
        }

        private void Excluir(int id)
        {
            var model = ObterPorId(id);
            _rep.Deletar(model);
            _rep.Commit();
        }
    }
}
