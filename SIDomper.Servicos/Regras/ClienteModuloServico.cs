using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class ClienteModuloServico
    {
        ClienteModuloEF _rep;

        public ClienteModuloServico()
        {
            _rep = new ClienteModuloEF();
        }

        public ClienteModulo ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }
        public List<ClienteModulo> ObterPorCliente(int idCliente)
        {
            return _rep.ObterPorCliente(idCliente).ToList();
        }

        public ClienteModulo ObterPorModulo(int idCliente, int idModulo)
        {
            return _rep.ObterPorModulo(idCliente, idModulo);
        }
    }
}
