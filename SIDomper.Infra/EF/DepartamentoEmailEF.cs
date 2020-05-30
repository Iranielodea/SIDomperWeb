using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System.Linq;

namespace SIDomper.Infra.EF
{
    public class DepartamentoEmailEF
    {
        private readonly Repositorio<DepartamentoEmail> _rep;

        public DepartamentoEmailEF()
        {
            _rep = new Repositorio<DepartamentoEmail>();
        }

        public DepartamentoEmail ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IQueryable<DepartamentoEmail> ObterPorDepartamento(int departamentoId)
        {
            return _rep.Get(x => x.DepartamentoId == departamentoId);
        }
    }
}
