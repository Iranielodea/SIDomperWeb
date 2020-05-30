using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class PlanoBackupServico
    {
        private readonly PlanoBackupEF _rep;

        public PlanoBackupServico()
        {
            _rep = new PlanoBackupEF();
        }

        public PlanoBackup ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public void Salvar(PlanoBackup model)
        {
            _rep.Salvar(model);
            _rep.Commit();
        }

        public void Excluir(PlanoBackup model)
        {
            _rep.Excluir(model);
            _rep.Commit();
        }
    }
}
