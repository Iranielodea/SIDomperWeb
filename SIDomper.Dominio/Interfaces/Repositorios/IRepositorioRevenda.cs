using SIDomper.Dominio.Entidades;

namespace SIDomper.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioRevenda : IRepositorio<Revenda>
    {
        string RetornarEmails(Revenda model);
    }
}
