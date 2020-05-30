using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class PlanoBackupItemServico
    {
        private readonly PlanoBackupItemEF _rep;

        public PlanoBackupItemServico()
        {
            _rep = new PlanoBackupItemEF();
        }

        public PlanoBackupItem ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public void Salvar(PlanoBackupItem model)
        {
            _rep.Salvar(model);
            _rep.Commit();
        }

        public void Excluir(PlanoBackupItem model)
        {
            _rep.Excluir(model);
            _rep.Commit();
        }
    }
}
