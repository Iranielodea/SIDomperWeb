using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoUsuario : IServicoUsuario
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<UsuarioConsulta> _repositoryReadOnly;
        private readonly EnProgramas _tipoPrograma;

        public ServicoUsuario(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<UsuarioConsulta> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _tipoPrograma = EnProgramas.Usuario;
        }

        public void AdicionarPermissao(UsuarioPermissao model)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Usuario model)
        {
            _uow.RepositorioUsuario.Deletar(model);
            _uow.Commit();
        }

        public void ExcluirItem(string ids)
        {
            _uow.RepositorioUsuario.ExcluirItem(ids);
        }

        public void ExcluirPermissao(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            string sql = _uow.RepositorioUsuario.Filtrar(campo, texto, ativo, contem);
            return _repositoryReadOnly.GetAll(sql);
        }

        public IEnumerable<UsuarioConsulta> Filtrar(UsuarioFiltro filtro)
        {
            return _repositoryReadOnly.GetAll(_uow.RepositorioUsuario.Filtrar(filtro));
        }

        public IQueryable<Usuario> ListarUsuarios(string nome)
        {
            return _uow.RepositorioUsuario.Get(x => x.Nome.Contains(nome) && x.Ativo == true).OrderBy(b => b.Nome);
        }

        public List<UsuarioPermissaoDepartamento> ObterPermissao(string userName, string senha)
        {
            return _uow.RepositorioUsuario.ObterPermissao(userName, senha).ToList();
        }

        public Usuario ObterPorCodigo(int codigo)
        {
            return _uow.RepositorioUsuario.First(x => x.Codigo == codigo);
        }

        public Usuario ObterPorId(int id)
        {
            return _uow.RepositorioUsuario.find(id);
        }

        public Usuario ObterPorIdNull(int? id)
        {
            return _uow.RepositorioUsuario.find(id);
        }

        public Usuario ObterPorUsuario(string userName)
        {
            return _uow.RepositorioUsuario.First(x => x.UserName == userName);
        }

        public string PermissaoUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Usuario> RetornarTodos()
        {
            return _uow.RepositorioUsuario.GetAll();
        }

        public void Salvar(Usuario model)
        {
            _uow.RepositorioUsuario.Salvar(model);
        }
    }
}
