using SIDomper.Dominio.Entidades;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoClienteEspecificacao
    {
        IEnumerable<ClienteEspecifiacaoConsulta> Filtrar(int idCliente);
        ClienteEspecifiacao ObterPorId(int id);
        void Excluir(ClienteEspecifiacao model);
        void Salvar(ClienteEspecifiacao model);
    }
}
