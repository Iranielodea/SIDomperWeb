using SIDomper.Dominio.Entidades;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioAgendamento : IRepositorio<Agendamento>
    {
        IEnumerable<ClienteEmail> RetornarEmailClientes(int agendamentoId);
        bool VerificarAgendamentoAberto(int idUsuario, int idStatusEncerrado, int idStausCancelado);
    }
}
