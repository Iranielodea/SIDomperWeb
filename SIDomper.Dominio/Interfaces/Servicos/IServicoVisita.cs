using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoVisita
    {
        Visita Novo(int idUsuario, int idClienteAgendamento);
        Visita Editar(int id, int idUsuario, ref string mensagem);
        IEnumerable<VisitaConsultaViewModelApi> Filtrar(int idUsuario, VisitaFiltroViewModelApi filtro, string campo, string valor);
        Visita ObterPorId(int id);
        void Salvar(Visita model, int usuarioId);
        void Excluir(Visita model, int idUsuario);
        void EnviarEmailVisita(Visita model, int usuarioId);
    }
}
