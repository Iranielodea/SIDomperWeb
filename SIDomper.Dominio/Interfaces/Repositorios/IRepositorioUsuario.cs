using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        void AdicionarPermissao(UsuarioPermissao model);
        string Filtrar(string campo, string texto, string ativo = "A", bool contem = true);
        IEnumerable<UsuarioPermissaoDepartamento> ObterPermissao(string userName, string senha);
        string Filtrar(UsuarioFiltro filtro);
        void ExcluirItem(string ids);
        void ExcluirPermissao(int id);
        string PermissaoUsuario(int idUsuario);
        bool PermissaoAcesso(int idUsuario, EnProgramas enProgramas);
        bool PermissaoIncluir(int idUsuario, EnProgramas enProgramas);
        bool PermissaoEditar(int idUsuario, EnProgramas enProgramas);
        bool PermissaoExcluir(int idUsuario, EnProgramas enProgramas);
        bool PermissaoRelatorio(int idUsuario, EnProgramas enProgramas);        
    }
}
