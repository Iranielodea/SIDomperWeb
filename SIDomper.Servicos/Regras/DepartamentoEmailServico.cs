using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Servicos.Regras
{
    public class DepartamentoEmailServico
    {
        DepartamentoEmailEF _rep;

        public DepartamentoEmailServico()
        {
            _rep = new DepartamentoEmailEF();
        }

        public DepartamentoEmail ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public List<DepartamentoEmail> ObterPorDepartamento(int departamentoId)
        {
            return _rep.ObterPorDepartamento(departamentoId).ToList();
        }

        public List<DepartamentoEmail> RetornarEmail(int usuarioId)
        {
            var usuarioServico = new UsuarioServico();
            var usuarioModel = usuarioServico.ObterPorId(usuarioId);

            return ObterPorDepartamento(usuarioModel.DepartamentoId);
        }
    }
}
