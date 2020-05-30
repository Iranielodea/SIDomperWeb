using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class ChamadoOcorrenciaColaboradorEF
    {
        private readonly Repositorio<ChamadoOcorrenciaColaborador> _rep;

        public ChamadoOcorrenciaColaboradorEF()
        {
            _rep = new Repositorio<ChamadoOcorrenciaColaborador>();
        }

        public ChamadoOcorrenciaColaborador ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IQueryable<ChamadoOcorrenciaColaborador> ObterPorOcorrencia(int idOcorrencia)
        {
            return _rep.Get(x => x.ChamadoOcorrenciaId == idOcorrencia);
        }

        public void Salvar(ChamadoOcorrenciaColaborador model)
        {
            _rep.AddUpdate(model);
            //if (model.Id > 0)
            //    _rep.Update(model);
            //else
            //    _rep.Add(model);
        }

        public void Salvar(Repositorio<Chamado> repositorio, ChamadoOcorrenciaColaborador model)
        {
            var item = repositorio.context.ChamadoOcorrenciaColaboradores.First(x => x.Id == model.Id);
            if (item == null)
                repositorio.context.ChamadoOcorrenciaColaboradores.Add(item);
            else
            {
                item = ObterPorId(model.Id);
                item = model;
                Salvar(item);
            }
        }

        public void Excluir(Repositorio<Chamado> repositorio, ChamadoOcorrenciaColaborador model)
        {
            var item = repositorio.context.ChamadoOcorrenciaColaboradores.First(x => x.Id == model.Id);
            if (item != null)
                repositorio.context.ChamadoOcorrenciaColaboradores.Remove(item);
        }

        public void Excluir(ChamadoOcorrenciaColaborador model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }
    }
}
