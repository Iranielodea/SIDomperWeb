using SIDomper.Dominio.Entidades;

namespace SIDomper.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioContaEmail : IRepositorio<ContaEmail>
    {
        void EnviarEmail(int idUsuario, string destinatiario, string copiaOculta, string assunto, string texto, string arquivoAnexo, bool aviso = false);
    }
}
