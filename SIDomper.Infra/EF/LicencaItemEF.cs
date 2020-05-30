using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class LicencaItemEF
    {
        private readonly Repositorio<LicencaItem> _rep;

        public LicencaItemEF()
        {
            _rep = new Repositorio<LicencaItem>();
        }

        public LicencaItem ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IEnumerable<LicencaItem> ListarTudo()
        {
            return _rep.Get(x => x.Id > 0);
        }

        public void ExcluirTudo()
        {
            _rep.DeleteAll(x => x.Id > 0);
        }

        public void Salvar(LicencaItem model)
        {
            if (model.Id == 0)
                _rep.Add(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }
    }
}
