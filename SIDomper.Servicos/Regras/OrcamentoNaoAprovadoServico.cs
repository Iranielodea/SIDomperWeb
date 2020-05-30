using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System.Threading.Tasks;
using SIDomper.Infra.EF;

namespace SIDomper.Servicos.Regras
{
    public class OrcamentoNaoAprovadoServico
    {
        private readonly OrcamentoNaoAprovadoEF _rep;

        public OrcamentoNaoAprovadoServico()
        {
            _rep = new OrcamentoNaoAprovadoEF();
        }

        public OrcamentoNaoAprovado ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public List<OrcamentoNaoAprovado> ObterPorOrcamentoId(int idOrcamento)
        {
            return _rep.ObterPorOrcamentoId(idOrcamento).ToList();
        }

        public void Excluir(int id)
        {
            _rep.Excluir(id);
        }

        public void Salvar(OrcamentoNaoAprovado model)
        {
            if (model.TipoId == 0)
                throw new Exception("Informe o Tipo!");

            if (string.IsNullOrEmpty(model.Descricao))
                throw new Exception("Informe a Descrição!");

            _rep.Salvar(model);
        }

        public string RetornarDescricaoSituacao(int situacao)
        {
            string retorno = "";
            switch(situacao)
            {
                case 1:
                    retorno = "Em Análise";
                    break;
                case 2:
                    retorno = "Aprovado";
                    break;
                case 3:
                    retorno = "Não Aprovado";
                    break;
                case 4:
                    retorno = "Faturado";
                    break;
            }
            return retorno;
        }
    }
}
