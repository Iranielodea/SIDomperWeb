using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.EF
{
    public class SolicitacaoOcorrenciaEF
    {
        private readonly Repositorio<SolicitacaoOcorrencia> _rep;

        public SolicitacaoOcorrenciaEF()
        {
            _rep = new Repositorio<SolicitacaoOcorrencia>();
        }

        public SolicitacaoOcorrencia ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public void Salvar(SolicitacaoOcorrencia model)
        {
            _rep.AddUpdate(model);
        }

        public void Excluir(SolicitacaoOcorrencia model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void ExcluirOcorrenciaIds(string ids)
        {
            _rep.context.Database.ExecuteSqlCommand("DELETE FROM Solicitacao_Ocorrencia WHERE SCro_Id in (" + ids + ")");
        }
    }
}
