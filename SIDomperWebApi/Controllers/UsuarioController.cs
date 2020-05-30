using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly UsuarioServico _usuarioServico;
        private readonly ClienteServico _clienteServico;

        public UsuarioController()
        {
            _usuarioServico = new UsuarioServico();
            _clienteServico = new ClienteServico();
        }

        [HttpGet]
        public UsuarioViewModel ObterPorId(int id)
        {
            var model = new UsuarioViewModel();
            try
            {
                var item = _usuarioServico.ObterPorId(id);
                model = item.Adapt<UsuarioViewModel>();

                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public UsuarioViewModel Editar(int idUsuario, int id)
        {
            var model = new UsuarioViewModel();
            try
            {
                bool permissao = true;
                Cliente cliente = new Cliente();
                var item = _usuarioServico.Editar(idUsuario, id, ref permissao);
                if (item.ClienteId.HasValue)
                    cliente = _clienteServico.ObterPorId(item.ClienteId.Value);
                
                model = item.Adapt<UsuarioViewModel>();
                model.ClienteCodigo = cliente.Codigo;
                model.NomeCliente = cliente.Nome;
                //model.Cliente = cliente.Adapt<ClienteViewModel>();

                if (permissao == false)
                    model.Mensagem = "Usuário sem permissão!";

                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public UsuarioViewModel ObterPorUsuario(string login, string senha)
        {
            var model = new UsuarioViewModel();
            try
            {
                var item = _usuarioServico.ObterPorUsuario(login, senha);
                model = item.Adapt<UsuarioViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public UsuarioViewModel HorarioUsoSistema(string userName, string senha, int idUsuario = 0)
        {
            var model = new UsuarioViewModel();
            try
            {
                var item = _usuarioServico.HorarioUsoSistema(userName, senha, idUsuario);
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

        [HttpGet]
        public IEnumerable<UsuarioPermissaoDepartamento> ObterPermissaoPorUsuario(string userName, string senha, string permissaoDep)
        {
            try
            {
                var lista = _usuarioServico.ObterPermissaoPorUsuario(userName, senha);
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public UsuarioViewModel Novo(string novo, int idUsuario)
        {
            var model = new UsuarioViewModel();
            try
            {
                var item = _usuarioServico.Novo(idUsuario);
                model = item.Adapt<UsuarioViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public UsuarioViewModel ObterPorCodigo(int codigo)
        {
            var model = new UsuarioViewModel();
            try
            {
                var prod = _usuarioServico.ObterPorCodigo(codigo);
                //model = prod.Adapt<UsuarioViewModel>();
                model.Id = prod.Id;
                model.Codigo = prod.Codigo;
                model.Nome = prod.Nome;
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public IEnumerable<UsuarioConsultaViewModel> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            try
            {
                var lista = _usuarioServico.Filtrar(campo, texto, ativo, contem);
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
                _usuarioServico.Salvar(usuario);
                usuarioViewModel = usuario.Adapt<UsuarioViewModel>();
                return usuarioViewModel;
            }
            catch (Exception ex)
            {
                usuarioViewModel.Mensagem = ex.Message;
                return usuarioViewModel;
            }
        }

        [HttpPost]
        public UsuarioConsultaViewModel[] Filtrar([FromBody] UsuarioFiltroViewModel filtro, string pesquisar)
        {
            try
            {
                var FiltroUsuario = filtro.Adapt<UsuarioFiltro>();
                var Lista = _usuarioServico.Filtrar(FiltroUsuario);
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
                _usuarioServico.Salvar(usuario);
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
        public UsuarioViewModel Delete(int idUsuario, int id)
        {
            var model = new UsuarioViewModel();
            try
            {
                var usuario = _usuarioServico.ObterPorId(id);
                _usuarioServico.Excluir(idUsuario, usuario);
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
