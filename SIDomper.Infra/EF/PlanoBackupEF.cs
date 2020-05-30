using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class PlanoBackupEF
    {
        private readonly Repositorio<PlanoBackup> _rep;

        public PlanoBackupEF()
        {
            _rep = new Repositorio<PlanoBackup>();
        }

        public PlanoBackup ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public void Salvar(PlanoBackup model)
        {
            if (model.Id == 0)
                _rep.Add(model);
        }

        public void Excluir(PlanoBackup model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

    }
}
