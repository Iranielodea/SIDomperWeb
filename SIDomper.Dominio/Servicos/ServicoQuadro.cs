using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;
using System.Linq;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoQuadro : IServicoQuadro
    {
        private readonly IUnitOfWork _uow;
        private readonly IServicoSolicitacao _servicoSolicitacao;
        private readonly IServicoParametro _servicoParametro;
        private readonly IServicoChamado _servicoChamado;

        public ServicoQuadro(IUnitOfWork uow, IServicoSolicitacao servicoSolicitacao,
            IServicoParametro servicoParametro, IServicoChamado servicoChamado)
        {
            _uow = uow;
            _servicoSolicitacao = servicoSolicitacao;
            _servicoParametro = servicoParametro;
            _servicoChamado = servicoChamado;
        }

        public QuadroViewModel DadosQuadro(int usuarioId)
        {
            var usuario = _uow.RepositorioUsuario.find(usuarioId);
            // Titulos
            var titulosQuadro = _servicoParametro.BuscarTitulosQuadro();

            //SOLICITACAO
            var permissaoSolicitacao = new SolicitacaoPermissaoViewModel();
            permissaoSolicitacao.PermissaoAnalise = _uow.RepositorioDepartamento.SolicitacaoPermissaoAnalise(usuario);
            permissaoSolicitacao.PermissaoConfTempoGeral = _uow.RepositorioUsuario.PermissaoConferenciaTempoGeral(usuario, usuarioId);
            permissaoSolicitacao.PermissaoOcorrenciaGeral = _uow.RepositorioDepartamento.SolicitacaoPermissaoOcorrenciaGeral(usuario);
            permissaoSolicitacao.PermissaoOcorrenciaRegra = _uow.RepositorioDepartamento.SolicitacaoPermissaoOcorrenciaRegra(usuario);
            permissaoSolicitacao.PermissaoOcorrenciaTecnica = _uow.RepositorioDepartamento.SolicitacaoPermissaoOcorrenciaTecnica(usuario);
            permissaoSolicitacao.PermissaoQuadro = _uow.RepositorioDepartamento.SolicitacaoPermissaoQuadro(usuario);
            permissaoSolicitacao.PermissaoTempo = _uow.RepositorioUsuario.PermissaoSolicitacaoTempo(usuario, usuarioId);

            // CHAMADO
            var permissaoChamado = new ChamadoPermissaoViewModel();
            permissaoChamado.PermissaoAlterarDataHoraAtividade = _servicoChamado.PermissaoAlterarDataHoraChamado(usuarioId);
            permissaoChamado.PermissaoChamadoQuadro = _servicoChamado.PermissaoChamadoQuadro(usuario);
            permissaoChamado.PermissaoOcorrenciaChamadoAlterar = _servicoChamado.PermissaoOcorrenciaChamadoAlterar(usuarioId);
            permissaoChamado.PermissaoOcorrenciaChamadoExcluir = _servicoChamado.PermissaoOcorrenciaChamadoExcluir(usuarioId);

            // ATIVIDADE
            permissaoChamado.PermissaoAlterarDataHoraAtividade = _servicoChamado.PermissaoAlterarDataHoraAtividade(usuarioId);
            permissaoChamado.PermissaoAtividadeQuadro = _servicoChamado.PermissaoAtividadeQuadro(usuario);
            permissaoChamado.PermissaoOcorrenciaAlterarAtividade = _servicoChamado.PermissaoOcorrenciaAlterarAtividade(usuarioId);
            permissaoChamado.PermissaoOcorrenciaAtividadeExcluir = _servicoChamado.PermissaoOcorrenciaAtividadeExcluir(usuarioId);

            var model = new QuadroViewModel();
            model.SolicitacaoPermissaoViewModel = permissaoSolicitacao;
            model.ChamadoPermissaoViewModel = permissaoChamado;
            model.TitulosQuadroViewModel = titulosQuadro.ToList();

            //TODO: esta faltando implementar os dois
            //AGENDAMENTO
            //RECADO

            model.CodigoStatusAberturaChamado = _uow.RepositorioChamado.StatusAbertura();
            model.CodigoStatusAtendimentoChamado = _uow.RepositorioChamado.StatusAtendimentoChamado();

            model.CodigoStatusAberturaAtividade = _uow.RepositorioChamado.StatusAberturaAtividade();
            model.CodigoStatusAtendimentoAtividade = _uow.RepositorioChamado.StatusAtendimentoAtividade();

            return model;
        }
    }
}
