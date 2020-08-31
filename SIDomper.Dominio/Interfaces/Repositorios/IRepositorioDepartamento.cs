using SIDomper.Dominio.Entidades;

namespace SIDomper.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioDepartamento : IRepositorio<Departamento>
    {
        Departamento Duplicar(Departamento model);
        string RetornarEmails(Departamento departamento);
        bool SolicitacaoPermissaoAnalise(Usuario usuario);
        bool SolicitacaoPermissaoOcorrenciaGeral(Usuario usuario);
        bool SolicitacaoPermissaoOcorrenciaRegra(Usuario usuario);
        bool SolicitacaoPermissaoOcorrenciaTecnica(Usuario usuario);
        bool SolicitacaoPermissaoQuadro(Usuario usuario);
        bool PermissaoAbertura(Usuario usuario);
        bool MostrarAnexos(Usuario usuario);
        bool SolicitacaoPermissaoStatus(Usuario usuario);
    }
}
