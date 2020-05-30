using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;

namespace SIDomper.Servicos.Regras
{
    public class ChamadoOcorrenciaColaboradorServico
    {
        private readonly ChamadoOcorrenciaColaboradorEF _rep;

        public ChamadoOcorrenciaColaboradorServico()
        {
            _rep = new ChamadoOcorrenciaColaboradorEF();
        }

        public ChamadoOcorrenciaColaborador ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public void Salvar(ChamadoOcorrenciaColaborador model, bool commit = true)
        {
            Validar(model);

            _rep.Salvar(model);
            if (commit)
                _rep.Commit();
        }

        public void Salvar(Repositorio<Chamado> repositorio, ChamadoOcorrenciaColaborador model)
        {
            Validar(model);

            _rep.Salvar(repositorio, model);
            _rep.Commit();
        }

        public IEnumerable<ChamadoOcorrenciaColaborador> ObterPorOcorrencia(int idOcorrencia)
        {
            return _rep.ObterPorOcorrencia(idOcorrencia);
        }

        public void Excluir(int id, bool commit = true)
        {
            var model = new ChamadoOcorrenciaColaborador();
            model = ObterPorId(id);
            if (model != null)
            {
                _rep.Excluir(model);
                if (commit)
                    _rep.Commit();
            }
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Excluir(Repositorio<Chamado> repositorio, ChamadoOcorrenciaColaborador model)
        {
            _rep.Excluir(repositorio, model);
            _rep.Commit();
        }

        private void Validar(ChamadoOcorrenciaColaborador model)
        {
            if (model.UsuarioId == 0)
                throw new Exception("Informe o Usuário!");

            if (model.HoraInicio.HasValue)
                throw new Exception("Informe o horário de início!");

            if (model.HoraFim.HasValue)
                throw new Exception("Informe o horário de final!");

            if (!model.HoraInicio.HasValue && !model.HoraFim.HasValue)
            {
                if (model.HoraInicio.Value > model.HoraFim.Value)
                    throw new Exception("Hora Inicial maior que Hora Final!");

                double HoraInicio = Funcoes.Horas.HoraToDecimal(model.HoraInicio.ToString());
                double HoraFim = Funcoes.Horas.HoraToDecimal(model.HoraFim.ToString());
                model.TotalHoras = HoraFim - HoraInicio;
            }
        }
    }
}
