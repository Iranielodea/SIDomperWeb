using SIDomper.Dominio.Entidades;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        string Filtrar(string campo, string texto, string ativo = "A", bool contem = true);
        IEnumerable<UsuarioPermissaoDepartamento> ObterPermissao(string userName, string senha);
        string Filtrar(UsuarioFiltro filtro);
        void ExcluirItem(string ids);
        string PermissaoUsuario(int idUsuario);
    }
}
