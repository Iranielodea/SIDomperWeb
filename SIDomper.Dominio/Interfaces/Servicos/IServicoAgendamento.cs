using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoAgendamento
    {
        IEnumerable<AgendamentoConsultaViewModel> Filtrar(AgendamentoFiltroViewModel filtro, string campo, string texto, int idUsuario, bool contem = true);
        Agendamento Novo(int idUsuario);
        Agendamento Editar(int id, int idUsuario, ref string mensagem);
        Agendamento ObterPorId(int id);
        void Relatorio(int idUsuario);
        void Excluir(Agendamento model, int idUsuario);
        void Salvar(Agendamento model);
        void Salvar(Agendamento model, int usuarioId);
        void Reagendamento(int idUsuario, int idAgendamento, string data, string hora, string texto);
        void Cancelamento(int idUsuario, int idAgendamento, string data, string hora, string texto);
        void Encerramento(int idUsuario, int idAgenda, int idPrograma);
        void EncerramentoWEB(int idUsuario, int idAgenda);
        IEnumerable<AgendamentoQuadroViewModel> Quadros(string dataInicial, string dataFinal, int idUsuario, int idRevenda);
        string AgendamentoCancelado();
        string AgendamentoEnderrado();
        int StatusAbertura();
        void EnviarEmailAgendamento(Agendamento model, int usuarioId);
        string RetornarEmailCliente(int usuarioId, Agendamento agendamento);
    }
}
