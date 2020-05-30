using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class LicencaServico
    {
        private readonly LicencaEF _rep;

        public LicencaServico()
        {
            _rep = new LicencaEF();
        }

        public Licenca ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public IEnumerable<Licenca> ListarTudo()
        {
            return _rep.ListarTudo();
        }

        public void Salvar(Licenca model)
        {
            _rep.Salvar(model);
            _rep.Commit();
        }

        public void Excluir(Licenca model)
        {
            _rep.Excluir(model);
            _rep.Commit();
        }

        public void ExcluirTudo()
        {
            _rep.ExcluirTudo();
            _rep.Commit();
        }
    }
}
