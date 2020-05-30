using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class RamalItemServico
    {
        private readonly RamalItemEF _rep;

        public RamalItemServico()
        {
            _rep = new RamalItemEF();
        }

        public RamalItem ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public IEnumerable<RamalItem> ListarRamaisPorDepartamento(int idDepartamento)
        {
            return _rep.ListarRamaisPorDepartamento(idDepartamento);
        }

        public void Salvar(RamalItem model)
        {
            _rep.Salvar(model);
            _rep.Commit();
        }

        public void Excluir(RamalItem model)
        {
            _rep.Excluir(model);
            _rep.Commit();
        }
    }
}
