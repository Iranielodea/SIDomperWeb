using SIDomper.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoUsuario
    {
        IEnumerable<UsuarioConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true);
        IEnumerable<UsuarioConsulta> Filtrar(UsuarioFiltro filtro);
        Usuario Novo(int idUsuario);
        Usuario ObterPorId(int id);
        Usuario ObterPorIdNull(int? id);
        Usuario ObterPorUsuario(string userName);
        List<UsuarioPermissaoDepartamento> ObterPermissao(string userName, string senha);
        IQueryable<Usuario> ListarUsuarios(string nome);
        Usuario ObterPorCodigo(int codigo);
        void Excluir(Usuario model, int idUsuario);
        void Salvar(Usuario model);
        void AdicionarPermissao(UsuarioPermissao model);
        void ExcluirPermissao(int id);
        string PermissaoUsuario(int idUsuario);
        IQueryable<Usuario> RetornarTodos();
        void ExcluirItem(string ids);
        void Relatorio(int idUsuario);        
        bool HorarioUsoSistema(string userName, string senha, int idUsuario = 0);
        Usuario Editar(int id, int idUsuario, ref string mensagem);
        List<UsuarioPermissaoDepartamento> ObterPermissaoPorUsuario(string userName, string senha);
    }
}
