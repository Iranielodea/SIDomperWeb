using SIDomper.Dominio.Entidades;

namespace SIDomper.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioUsuarioWrite
    {
        int Insert(Usuario usuario);
        void Update(Usuario usuario);
    }
}
