using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioStatus : IRepositorio<Status>
    {
        bool NotificarCliente(int statusId);
        bool NotificarConsultor(int statusId);
        bool NotificarRevenda(int statusId);
        bool NotificarSupervisor(int statusId);
        Status ObterPorCodigo(int codigo, EnStatus enStatus);
        IEnumerable<Status> ObterPorPrograma(EnStatus enStatus);
    }
}
