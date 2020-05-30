using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class UsuarioPermissaoEF
    {
        private readonly Repositorio<UsuarioPermissao> _rep;

        public UsuarioPermissaoEF()
        {
            _rep = new Repositorio<UsuarioPermissao>();
        }

        public UsuarioPermissao ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IQueryable<UsuarioPermissao> ObterPorUsuario(int idUsuario)
        {
            return _rep.Get(x => x.UsuarioId == idUsuario);
        }

        public UsuarioPermissao ObterPorSigla(string sigla)
        {
            return _rep.First(x => x.Sigla == sigla);
        }

        public UsuarioPermissao ObterPorUsuarioSigla(int idUsuario, string sigla)
        {
            return _rep.First(x => x.UsuarioId == idUsuario && x.Sigla == sigla);
        }
    }
}
