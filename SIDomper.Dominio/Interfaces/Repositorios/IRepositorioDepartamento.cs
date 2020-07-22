using SIDomper.Dominio.Entidades;

namespace SIDomper.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioDepartamento : IRepositorio<Departamento>
    {
        Departamento Duplicar(Departamento model);
    }
}
