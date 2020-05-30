using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class ClienteModuloEF
    {
        private readonly Repositorio<ClienteModulo> _rep;

        public ClienteModuloEF()
        {
            _rep = new Repositorio<ClienteModulo>();
        }

        public ClienteModulo ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IQueryable<ClienteModulo> ObterPorCliente(int idCliente)
        {
            return _rep.Get(x => x.ClienteId == idCliente);
        }

        public ClienteModulo ObterPorModulo(int idCliente, int idModulo)
        {
            return _rep.First(x => x.ClienteId == idCliente && x.ModuloId == idModulo);
        }
    }
}
