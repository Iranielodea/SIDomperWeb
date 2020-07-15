using SIDomper.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoUsuario
    {
        IEnumerable<UsuarioConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true);
        IEnumerable<UsuarioConsulta> Filtrar(UsuarioFiltro filtro);
        Usuario ObterPorId(int id);
        Usuario ObterPorIdNull(int? id);
        Usuario ObterPorUsuario(string userName);
        List<UsuarioPermissaoDepartamento> ObterPermissao(string userName, string senha);
        IQueryable<Usuario> ListarUsuarios(string nome);
        Usuario ObterPorCodigo(int codigo);
        void Excluir(Usuario model);
        void Salvar(Usuario model);
        void AdicionarPermissao(UsuarioPermissao model);
        void ExcluirPermissao(int id);
        string PermissaoUsuario(int idUsuario);
        IQueryable<Usuario> RetornarTodos();
        void ExcluirItem(string ids);
    }
}
