using SIDomper.Dominio.Entidades;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioParametro : IRepositorio<Parametro>
    {
        IEnumerable<Parametro> BuscarTitulosChamados();
        Parametro ObterPorParametro(int codigo, int programa);
    }
}
