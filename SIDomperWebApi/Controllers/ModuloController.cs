using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    [RoutePrefix("api/modulo")]
    public class ModuloController : ApiController
    {
        //private readonly ModuloServico _moduloServico;
        private readonly IServicoModulo _servicoModulo;

        public ModuloController(IServicoModulo servicoModulo)
        {
            //_moduloServico = new ModuloServico();
            _servicoModulo = servicoModulo;
        }

        [Route("ObterPorId")]
        [HttpGet]
        public ModuloViewModel ObterPorId(int id)
        {
            var model = new ModuloViewModel();
            try
            {
                //var item = _moduloServico.ObterPorId(id);
                var item = _servicoModulo.ObterPorId(id);
                model = item.Adapt<ModuloViewModel>();
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
        public ModuloViewModel Editar(int id, int idUsuario)
        {
            var model = new ModuloViewModel();
            try
            {
                string mensagem = "";
                //var item = _moduloServico.Editar(idUsuario, id, ref mensagem);
                var item = _servicoModulo.Editar(id, idUsuario, ref mensagem);
                model = item.Adapt<ModuloViewModel>();
                model.Mensagem = mensagem;
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("Novo")]
        [HttpGet]
        public ModuloViewModel Novo(int idUsuario)
        {
            var model = new ModuloViewModel();
            try
            {
                //var item = _moduloServico.Novo(idUsuario);
                var item = _servicoModulo.Novo(idUsuario);
                model = item.Adapt<ModuloViewModel>();
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
        public ModuloViewModel ObterPorCodigo(int codigo)
        {
            var model = new ModuloViewModel();
            try
            {
                //var prod = _moduloServico.ObterPorCodigo(codigo);
                var prod = _servicoModulo.ObterPorCodigo(codigo);
                model = prod.Adapt<ModuloViewModel>();
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
        public IEnumerable<ModuloViewModel> Filtrar(string campo, string texto, string ativo = "A", bool contem = true, int idCliente = 0)
        {
            try
            {
                //var lista = _moduloServico.Filtrar(campo, texto, ativo, contem, idCliente);
                var lista = _servicoModulo.Filtrar(campo, texto, ativo, contem, idCliente);
                var model = lista.Adapt<ModuloViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ModuloViewModel Incluir(ModuloViewModel model)
        {
            var moduloViewModel = new ModuloViewModel();
            try
            {
                var modulo = model.Adapt<Modulo>();
                //_moduloServico.Salvar(modulo);
                _servicoModulo.Salvar(modulo);
                moduloViewModel = modulo.Adapt<ModuloViewModel>();
                return moduloViewModel;
            }
            catch (Exception ex)
            {
                moduloViewModel.Mensagem = ex.Message;
                return moduloViewModel;
            }
        }

        [HttpPut]
        public ModuloViewModel Update(ModuloViewModel model)
        {
            var ModuloViewModel = new ModuloViewModel();
            try
            {
                var Modulo = model.Adapt<Modulo>();
                //_moduloServico.Salvar(Modulo);
                _servicoModulo.Salvar(Modulo);
                ModuloViewModel = Modulo.Adapt<ModuloViewModel>();
                return ModuloViewModel;
            }
            catch (Exception ex)
            {
                ModuloViewModel.Mensagem = ex.Message;
                return ModuloViewModel;
            }
        }

        [HttpDelete]
        public ModuloViewModel Delete(int id, int idUsuario)
        {
            var model = new ModuloViewModel();
            try
            {
                //var modulo = _moduloServico.ObterPorId(id);
                //_moduloServico.Excluir(idUsuario, modulo);
                _servicoModulo.Excluir(_servicoModulo.ObterPorId(id), idUsuario);
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