using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoChamado
    {
        IEnumerable<ChamadoConsultaViewModel> Filtrar(ChamadoFiltroViewModel filtro, string campo, string texto, int usuarioId, bool contem, EnumChamado tipo);
        Chamado Novo(int idUsuario, bool quadro, int idClienteAgendamento, int idAgendamento, EnProgramas enProgramas, EnumChamado enumChamado);
        Chamado Editar(int id, int idUsuario, EnProgramas enProgramas, ref string mensagem);
        Chamado ObterPorId(int id);
        void Relatorio(int idUsuario, EnProgramas enProgramas);
        void Excluir(Chamado model, int idUsuario, EnProgramas enProgramas);
        void Salvar(Chamado model, int idUsuario, bool ocorrencia);
        void Salvar(Chamado model);
        void SalvarAplicativo(ChamadoAplicativoInputViewModel chamadoInputModel);
        IEnumerable<ChamadoAplicativoViewModel> RetornarDadosAplicativo(string cnpj);
        ChamadoQuadroViewModel AbrirQuadro(int idUsuario, int idRevenda, EnProgramas enProgramas);
        IEnumerable<ChamadoAnexo> RetornarAnexos(int chamadoId);
        ClienteModulo ObterPorModulo(int idCliente, int idModulo);
        void UpdateHoraUsuarioAtual(int idChamado, EnumChamado enumChamado, int idUsuario, int idStatus);
        IEnumerable<ChamadoOcorrencia> ListarProblemaSolucao(ChamadoFiltro filtro, string texto, int idUsuario, EnumChamado tipo);
        void NovoChamadoQuadro(ChamadoViewModel model, EnumChamado enChamadoAtividade, int idEncerramento);
        bool PermissaoAlterarDataHoraChamado(int idUsuario);
        bool PermissaoOcorrenciaChamadoAlterar(int idUsuario);
        bool PermissaoOcorrenciaChamadoExcluir(int idUsuario);
        bool PermissaoAlterarDataHoraAtividade(int idUsuario);
        bool PermissaoOcorrenciaAlterarAtividade(int idUsuario);
        bool PermissaoOcorrenciaAtividadeExcluir(int idUsuario);
        Usuario ObterUsuarioPorId(int id);        
    }
}
