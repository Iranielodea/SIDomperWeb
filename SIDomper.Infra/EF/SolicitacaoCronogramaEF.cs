using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class SolicitacaoCronogramaEF
    {
        private readonly Repositorio<SolicitacaoCronograma> _rep;

        public SolicitacaoCronogramaEF()
        {
            _rep = new Repositorio<SolicitacaoCronograma>();
        }

        public SolicitacaoCronograma ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public void Salvar(SolicitacaoCronograma model)
        {
            _rep.AddUpdate(model);
        }

        public void Excluir(SolicitacaoCronograma model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void ExcluirOcorrenciaIds(string ids)
        {
            _rep.context.Database.ExecuteSqlCommand("DELETE FROM Solicitacao_Cronograma WHERE SOCro_Id in (" + ids + ")");
        }
    }
}
