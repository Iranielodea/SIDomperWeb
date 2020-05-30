using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class LicencaItemServico
    {
        private readonly LicencaItemEF _rep;

        public LicencaItemServico()
        {
            _rep = new LicencaItemEF();
        }

        public LicencaItem ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public IEnumerable<LicencaItem> ListarTudo()
        {
            return _rep.ListarTudo();
        }

        public void ExcluirTudo()
        {
            _rep.ExcluirTudo();
            _rep.Commit();
        }

        public void Salvar(LicencaItem model)
        {
            _rep.Salvar(model);
            _rep.Commit();
        }
    }
}
