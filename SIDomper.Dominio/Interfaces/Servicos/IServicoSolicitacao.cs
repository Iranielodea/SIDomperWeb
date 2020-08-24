using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoSolicitacao
    {
        IEnumerable<SolicitacaoConsulta> Filtrar(SolicitacaoFiltroViewModel filtro, string campo, string texto, int usuarioId, bool contem);
        Solicitacao Novo(int usuarioId);
        Solicitacao Editar(int id, int idUsuario, ref string mensagem);
        Solicitacao ObterPorId(int id);
        void Relatorio(int idUsuario);
        void Excluir(Solicitacao model, int idUsuario);
        void Salvar(Solicitacao model, int usuarioId);
    }
}
