using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class RamalItemEF
    {
        private readonly Repositorio<RamalItem> _rep;

        public RamalItemEF()
        {
            _rep = new Repositorio<RamalItem>();
        }

        public RamalItem ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IEnumerable<RamalItem> ListarRamaisPorDepartamento(int idDepartamento)
        {
            return _rep.Get(x => x.RamalId == idDepartamento);
        }

        public void Salvar(RamalItem model)
        {
            if (model.Id == 0)
                _rep.Add(model);
        }

        public void Excluir(RamalItem model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }
    }
}
