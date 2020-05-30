using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class OrcamentoOcorrenciaServico
    {
        private readonly OrcamentoOcorrenciaEF _rep;

        public OrcamentoOcorrenciaServico()
        {
            _rep = new OrcamentoOcorrenciaEF();
        }

        public OrcamentoOcorrencia ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public List<OrcamentoOcorrencia> ObterPorOrcamentoId(int idOrcamento)
        {
            return _rep.ObterPorOrcamentoId(idOrcamento).ToList();
        }

        public void Salvar(OrcamentoOcorrencia model)
        {
            if (model.Data == null)
                throw new Exception("Informe a Data!");

            if (string.IsNullOrWhiteSpace(model.Descricao))
                throw new Exception("Informe a Descrição!");

            _rep.Salvar(model);
        }
    }
}
