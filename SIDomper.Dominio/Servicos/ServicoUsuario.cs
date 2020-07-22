using SIDomper.Dominio.Constantes;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoUsuario : IServicoUsuario
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<UsuarioConsulta> _repositoryReadOnly;
        private readonly IRepositorioUsuarioWrite _repositorioUsuarioWrite;
        private readonly EnProgramas _enProgramas;

        public ServicoUsuario(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<UsuarioConsulta> repositoryReadOnly, 
           IRepositorioUsuarioWrite repositorioUsuarioWrite)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _repositorioUsuarioWrite = repositorioUsuarioWrite;
            _enProgramas = EnProgramas.Usuario;
        }

        public void Excluir(Usuario model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioUsuario.Deletar(model);
            _uow.SaveChanges();
        }

        public void ExcluirItem(string ids)
        {
            _uow.RepositorioUsuario.ExcluirItem(ids);
        }

        public void AdicionarPermissao(UsuarioPermissao model)
        {
            _uow.RepositorioUsuario.AdicionarPermissao(model);
        }

        public void ExcluirPermissao(int id)
        {
            _uow.RepositorioUsuario.ExcluirPermissao(id);
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

        public Usuario Novo(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            var usuario = new Usuario
            {
                Codigo = ProximoCodigo(),
                Ativo = true
            };
            return usuario;
        }

        public List<UsuarioPermissaoDepartamento> ObterPermissao(string userName, string senha)
        {
            return _uow.RepositorioUsuario.ObterPermissao(userName, senha).ToList();
        }

        public Usuario ObterPorCodigo(int codigo)
        {
            var model = _uow.RepositorioUsuario.First(x => x.Codigo == codigo);
            if (model == null)
                throw new Exception("Registro não Encontrado!");

            return model;
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
            return _uow.RepositorioUsuario.PermissaoUsuario(idUsuario);
        }

        public IQueryable<Usuario> RetornarTodos()
        {
            return _uow.RepositorioUsuario.GetAll();
        }

        public void Salvar(Usuario model)
        {
            if (model.Codigo <= 0)
                _uow.Notificacao.Add("Informe o Código!");

            if (string.IsNullOrWhiteSpace(model.Nome))
                _uow.Notificacao.Add("Informe o Nome!");

            if (model.DepartamentoId == 0)
                _uow.Notificacao.Add("Informe o Departamento!");

            if (string.IsNullOrWhiteSpace(model.UserName))
                _uow.Notificacao.Add("Informe o Usuário!");

            if (string.IsNullOrWhiteSpace(model.Password))
                _uow.Notificacao.Add("Informe a Senha!");

            if (string.IsNullOrWhiteSpace(model.Email))
                _uow.Notificacao.Add("Informe o Email!");

            if (!_uow.IsValid())
                throw new Exception(_uow.RetornoNotificacao());

            if (model.Id == 0)
            {
                var id = _repositorioUsuarioWrite.Insert(model);
            }
            else
            {
                _repositorioUsuarioWrite.Update(model);

                var usuario = ObterPorId(model.Id);
                if (usuario == null)
                    usuario = new Usuario();

                AlterarPermissao(usuario, model);
                ExcluirPermissaoUsuario(usuario, model);

                _uow.RepositorioUsuario.Salvar(usuario);
                _uow.SaveChanges();
            }
        }

        private int ProximoCodigo()
        {
            try
            {
                return _uow.RepositorioUsuario.GetAll().Max(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        private Usuario RetornarUsuarioValido(string userName, string senha)
        {
            var model = _uow.RepositorioUsuario.First(x => x.UserName == userName);

            if (model == null)
                throw new Exception("Usuário não Cadastrado!");

            if (model.Password != senha)
                throw new Exception("Senha Inválida!");

            if (model.Ativo == false)
                throw new Exception("Usuário Inativo!");

            if (!HorarioUsoSistema(userName, senha))
                throw new Exception(Mensagem.MensagemHorarioAcessoSistema);

            return model;
        }

        public bool HorarioUsoSistema(string userName, string senha, int idUsuario = 0)
        {
            bool resultado = true;
            Usuario usuario = new Usuario();

            if (idUsuario > 0)
                usuario = ObterPorId(idUsuario);
            else
            {
                usuario = ObterPorUsuario(userName);

                if (usuario != null)
                {
                    if (usuario.Password != senha)
                        throw new Exception("Usuário não cadastrado!");
                }
            }

            if (usuario != null)
            {
                if (usuario.Departamento.HoraInicial != null && usuario.Departamento.HoraFinal != null)
                {
                    TimeSpan horaAtual = DateTime.Now.TimeOfDay;

                    if (horaAtual >= usuario.Departamento.HoraInicial && horaAtual <= usuario.Departamento.HoraFinal)
                        resultado = true;
                    else
                        resultado = false;
                }
            }
            return resultado;
        }

        private void AlterarPermissao(Usuario usuarioBanco, Usuario model)
        {
            foreach (var item in model.UsuariosPermissao)
            {
                if (string.IsNullOrWhiteSpace(item.Sigla))
                    throw new Exception("Informe a sigla!");

                if (item.Id == 0)
                    usuarioBanco.UsuariosPermissao.Add(item);
                else
                {
                    var temp = usuarioBanco.UsuariosPermissao.FirstOrDefault(x => x.Id == item.Id);
                    if (temp != null)
                    {
                        temp.Sigla = item.Sigla;
                    }
                }
            }
        }

        private void ExcluirPermissaoUsuario(Usuario usuarioBanco, Usuario model)
        {
            string idDelecao = "";
            int i = 1;
            foreach (var itemBanco in usuarioBanco.UsuariosPermissao)
            {
                var dados = model.UsuariosPermissao.FirstOrDefault(x => x.Id == itemBanco.Id);
                if (dados == null)
                {
                    if (itemBanco.Id > 0)
                    {
                        if (i == 1)
                            idDelecao += itemBanco.Id;
                        else
                            idDelecao += "," + itemBanco.Id;
                        i++;
                    }
                }
            }

            if (idDelecao != "")
                _uow.Executar("DELETE FROM Usuario_Permissao WHERE UsuP_Id in (" + idDelecao + ")");
        }

        public Usuario Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public List<UsuarioPermissaoDepartamento> ObterPermissaoPorUsuario(string userName, string senha)
        {
            var model = _uow.RepositorioUsuario.GetAll().FirstOrDefault(x => x.UserName == userName);

            if (model == null)
                throw new Exception("Usuário não Cadastrado!");

            if (model.Password != senha)
                throw new Exception("Senha Inválida!");

            if (model.Ativo == false)
                throw new Exception("Usuário Inativo!");

            if (!HorarioUsoSistema(userName, senha))
                throw new Exception(Mensagem.MensagemHorarioAcessoSistema);

            return _uow.RepositorioUsuario.ObterPermissao(userName, senha).ToList();
        }
    }
}
