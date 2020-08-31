using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoSolicitacao
    {
        IEnumerable<SolicitacaoConsultaViewModel> Filtrar(SolicitacaoFiltroViewModel filtro, string campo, string texto, int usuarioId, bool contem);
        Solicitacao Novo(int usuarioId);
        Solicitacao Editar(int id, int idUsuario, ref string mensagem);
        Solicitacao ObterPorId(int id);
        void Relatorio(int idUsuario);
        void Excluir(Solicitacao model, int idUsuario);
        void Salvar(Solicitacao model, int usuarioId);
        bool PermissaoAbertura(Usuario usuario);
        bool PermissaoAnalise(Usuario usuario);
        bool PermissaoOcorrenciaGeral(Usuario usuario);
        bool PermissaoOcorrenciaRegra(Usuario usuario);
        bool PermissaoOcorrenciaTecnica(Usuario usuario);
        bool PermissaoStatus(Usuario usuario);
        bool PermissaoSolicitacaoTempo(Usuario usuario, int usuarioId);
        bool PermissaoConferenciaTempoGeral(Usuario usuario, int usuarioId);
        bool MostrarAnexos(Usuario usuario);
        string RetornarCaminhoAnexo();
        SolicitacaoPermissaoViewModel BuscarPermissoes(int usuarioId);
    }
}
