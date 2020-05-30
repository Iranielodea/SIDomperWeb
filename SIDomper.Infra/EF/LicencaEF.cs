using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class LicencaEF
    {
        private readonly Repositorio<Licenca> _rep;

        public LicencaEF()
        {
            _rep = new Repositorio<Licenca>();
        }

        public Licenca ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IEnumerable<Licenca> ListarTudo()
        {
            return _rep.Get(x => x.Id > 0);
        }

        public void Salvar(Licenca model)
        {
            if (model.Id == 0)
                _rep.Add(model);
        }

        public void Excluir(Licenca model)
        {
            _rep.Deletar(model);
        }

        public void ExcluirTudo()
        {
            _rep.DeleteAll(x => x.Id > 0);
        }

        public void Commit()
        {
            _rep.Commit();
        }

    }
}
