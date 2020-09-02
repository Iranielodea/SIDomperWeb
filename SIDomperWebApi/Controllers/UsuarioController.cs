using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private readonly UsuarioServico _usuarioServico;
        private readonly IServicoCliente _servicoCliente;
        private readonly IServicoUsuario _servicoUsuario;

        public UsuarioController(IServicoUsuario servicoUsuario, IServicoCliente servicoCliente)
        {
            _usuarioServico = new UsuarioServico();
            _servicoUsuario = servicoUsuario;
            _servicoCliente = servicoCliente;
        }

        [Route("ObterPorId")]
        [HttpGet]
        public UsuarioViewModel ObterPorId(int id)
        {
            var model = new UsuarioViewModel();
            try
            {
                var item = _servicoUsuario.ObterPorId(id);
                model = item.Adapt<UsuarioViewModel>();

                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("Editar")]
        [HttpGet]
        public UsuarioViewModel Editar(int id, int idUsuario)
        {
            var model = new UsuarioViewModel();
            try
            {
                string mensagem = "";
                var item = _servicoUsuario.Editar(id, idUsuario, ref mensagem);

                model = item.Adapt<UsuarioViewModel>();

                if (item.ClienteId.HasValue)
                {
                    var cliente = _servicoCliente.ObterPorId(item.ClienteId.Value);
                    model.ClienteCodigo = cliente.Codigo;
                    model.NomeCliente = cliente.Nome;
                }

                model.Mensagem = mensagem;
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("ObterPorUsuario")]
        [HttpGet]
        public UsuarioViewModel ObterPorUsuario(string login, string senha)
        {
            var model = new UsuarioViewModel();
            try
            {
                var item = _servicoUsuario.RetornarTodos().FirstOrDefault(x => x.UserName == login && x.Password == senha);
                //var item = _usuarioServico.ObterPorUsuario(login, senha);
                model = item.Adapt<UsuarioViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("HorarioUsoSistema")]
        [HttpGet]
        public UsuarioViewModel HorarioUsoSistema(string userName, string senha, int idUsuario = 0)
        {
            var model = new UsuarioViewModel();
            try
            {
                var item = _servicoUsuario.HorarioUsoSistema(userName, senha, idUsuario);
                model = item.Adapt<UsuarioViewModel>();
                model.HorarioUsoSistema = item;
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("ObterPermissaoPorDepartamento")]
        [HttpGet]
        public IEnumerable<UsuarioPermissaoDepartamento> ObterPermissaoPorUsuario(string userName, string senha, string permissaoDep)
        {
            try
            {
                var lista = _servicoUsuario.ObterPermissaoPorUsuario(userName, senha);
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("Novo")]
        [HttpGet]
        public UsuarioViewModel Novo(int idUsuario)
        {
            var model = new UsuarioViewModel();
            try
            {
                var item = _servicoUsuario.Novo(idUsuario);
                model = item.Adapt<UsuarioViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("ObterPorCodigo")]
        [HttpGet]
        public UsuarioViewModel ObterPorCodigo(int codigo)
        {
            var model = new UsuarioViewModel();
            try
            {
                var usuario = _servicoUsuario.ObterPorCodigo(codigo);
                model.Id = usuario.Id;
                model.Codigo = usuario.Codigo;
                model.Nome = usuario.Nome;
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("Filtrar")]
        [HttpGet]
        public IEnumerable<UsuarioConsultaViewModel> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            try
            {
                var lista = _servicoUsuario.Filtrar(campo, texto, ativo, contem);
                var model = lista.Adapt<UsuarioConsultaViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public UsuarioViewModel Incluir(UsuarioViewModel model)
        {
            var usuarioViewModel = new UsuarioViewModel();
            try
            {
                var usuario = model.Adapt<Usuario>();
                _servicoUsuario.Salvar(usuario);
                usuarioViewModel = usuario.Adapt<UsuarioViewModel>();
                return usuarioViewModel;
            }
            catch (Exception ex)
            {
                usuarioViewModel.Mensagem = ex.Message;
                return usuarioViewModel;
            }
        }

        [Route("FiltrarSimples")]
        [HttpPost]
        public UsuarioConsultaViewModel[] Filtrar([FromBody] UsuarioFiltroViewModel filtro, string pesquisar)
        {
            try
            {
                var FiltroUsuario = filtro.Adapt<UsuarioFiltro>();
                var Lista = _servicoUsuario.Filtrar(FiltroUsuario);
                var model = Lista.Adapt<UsuarioConsultaViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public UsuarioViewModel Update(UsuarioViewModel model)
        {
            var usuarioViewModel = new UsuarioViewModel();
            try
            {
                var usuario = model.Adapt<Usuario>();
                _servicoUsuario.Salvar(usuario);
                usuarioViewModel = usuario.Adapt<UsuarioViewModel>();
                return usuarioViewModel;
            }
            catch (Exception ex)
            {
                usuarioViewModel.Mensagem = ex.Message;
                return usuarioViewModel;
            }
        }

        //DELETE api/<controller>/5
        [HttpDelete]
        public UsuarioViewModel Delete(int id, int idUsuario)
        {
            var model = new UsuarioViewModel();
            try
            {
                _servicoUsuario.Excluir(_servicoUsuario.ObterPorId(id), idUsuario);
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }
    }
}
