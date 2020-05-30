using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class ChamadoStatusEF
    {
        private readonly Repositorio<ChamadoStatus> _rep;

        public ChamadoStatusEF()
        {
            _rep = new Repositorio<ChamadoStatus>();
        }

        public IQueryable<ChamadoStatus> ObterPorChamado(int idChamado)
        {
            return _rep.Get(x => x.ChamadoId == idChamado);
        }

        public void Salvar(ChamadoStatus model)
        {
            if (model.Id > 0)
                _rep.Update(model);
            else
                _rep.Add(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }
    }
}
