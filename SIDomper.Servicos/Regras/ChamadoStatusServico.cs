using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class ChamadoStatusServico
    {
        private readonly ChamadoStatusEF _rep;

        public ChamadoStatusServico()
        {
            _rep = new ChamadoStatusEF();
        }

        public IEnumerable<ChamadoStatus> ObterPorChamado(int idChamado)
        {
            return _rep.ObterPorChamado(idChamado);
        }

        public void Salvar(ChamadoStatus model, bool commit = true)
        {
            _rep.Salvar(model);
            if (commit)
                _rep.Commit();
        }
    }
}
