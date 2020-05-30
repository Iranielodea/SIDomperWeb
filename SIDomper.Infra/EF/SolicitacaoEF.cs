using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System.Linq;

namespace SIDomper.Infra.EF
{
    public class SolicitacaoEF
    {
        private readonly Repositorio<Solicitacao> _rep;

        public SolicitacaoEF()
        {
            _rep = new Repositorio<Solicitacao>();
        }

        public Solicitacao ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public void Excluir(Solicitacao model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Salvar(Solicitacao model)
        {
            if (model.Id > 0)
                _rep.Update(model);
            else
            {
                _rep.Add(model);
            }
        }

        public void AdicionarCronograma(SolicitacaoCronograma model)
        {
            _rep.context.SolicitacaoCronogramas.Add(model);
        }

        public void AlterarCronograma(Solicitacao model, SolicitacaoCronograma solicitacaoCronograma)
        {
            foreach (var item in model.SolicitacaoCronogramas)
            {
                if (item.Id == solicitacaoCronograma.Id)
                {
                    item.Data = solicitacaoCronograma.Data;
                    item.HoraFim = solicitacaoCronograma.HoraFim;
                    item.HoraInicio = solicitacaoCronograma.HoraInicio;
                    item.UsuarioId = solicitacaoCronograma.UsuarioId;
                }
            }
        }

        public void ExcluirCronograma(int id)
        {
            var model = _rep.context.SolicitacaoCronogramas.First(x => x.Id == id);
            if (model != null)
                _rep.context.SolicitacaoCronogramas.Remove(model);
        }


        public void AdicionarOcorrencia(SolicitacaoOcorrencia model)
        {
            _rep.context.SolicitacaoOcorrencias.Add(model);
        }

        public void AlterarOcorrencia(Solicitacao model, SolicitacaoOcorrencia solicitacaoOcorrencia)
        {
            foreach (var item in model.SolicitacaoOcorrencias)
            {
                if (item.Id == solicitacaoOcorrencia.Id)
                {
                    item.Data = solicitacaoOcorrencia.Data;
                    item.Anexo = solicitacaoOcorrencia.Anexo;
                    item.Classificacao = solicitacaoOcorrencia.Classificacao;
                    item.Descricao = solicitacaoOcorrencia.Descricao;
                    item.Hora = solicitacaoOcorrencia.Hora;
                    item.TipoId = solicitacaoOcorrencia.TipoId;
                    item.UsuarioId = solicitacaoOcorrencia.UsuarioId;
                }
            }
        }

        public void ExcluirOcorrencia(int id)
        {
            var model = _rep.context.SolicitacaoOcorrencias.First(x => x.Id == id);
            if (model != null)
                _rep.context.SolicitacaoOcorrencias.Remove(model);
        }

        public void AdicionarSolicitacaoStatus(SolicitacaoStatus model)
        {
            _rep.context.SolicitacaoStatus.Add(model);
        }
    }
}
