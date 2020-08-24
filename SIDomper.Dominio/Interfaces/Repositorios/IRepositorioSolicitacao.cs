using SIDomper.Dominio.Entidades;

namespace SIDomper.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioSolicitacao : IRepositorio<Solicitacao>
    {
        string StatusAbertura();
        string RetornarCaminhoAnexo();
        string StatusEncerramento();
        string StatusOcorrencia();
    }
}
