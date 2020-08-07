using SIDomper.Dominio.Entidades;

namespace SIDomper.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioChamado : IRepositorio<Chamado>
    {
        string StatusAtendimentoChamado();
        string StatusAtendimentoAtividade();
        string StatusAbertura();
        string StatusAberturaAtividade();
        string UsuarioAplicativo();
        string CaminhoAnexo();
    }
}
