using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    [RoutePrefix("api/parametro")]
    public class ParametroController : ApiController
    {
        private readonly IServicoParametro _servicoParametro;

        public ParametroController(IServicoParametro servicoParametro)
        {
            _servicoParametro = servicoParametro;
        }

        [Route("ObterPorId")]
        [HttpGet]
        public ParametroViewModel ObterPorId(int id)
        {
            var model = new ParametroViewModel();
            try
            {
                var prod = _servicoParametro.ObterPorId(id);
                model = prod.Adapt<ParametroViewModel>();
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
        public ParametroViewModel Novo(int idUsuario)
        {
            var model = new ParametroViewModel();
            try
            {
                var item = _servicoParametro.Novo(idUsuario);
                model = item.Adapt<ParametroViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("ObterPorParametro")]
        [HttpGet]
        public ParametroViewModel ObterPorParametro(int codigo, int programa)
        {
            var model = new ParametroViewModel();
            try
            {
                var prod = _servicoParametro.ObterPorParametro(codigo, programa);
                model = prod.Adapt<ParametroViewModel>();
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
        public ParametroViewModel Editar(int id, int idUsuario)
        {
            var model = new ParametroViewModel();
            try
            {
                string mensagem = "";
                var parametro = _servicoParametro.Editar(id, idUsuario, ref mensagem);
                model = parametro.Adapt<ParametroViewModel>();
                model.Mensagem = mensagem;
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
        public IEnumerable<ParametroViewModel> Filtrar(string campo, string texto, bool contem = true)
        {
            try
            {
                var lista = _servicoParametro.Filtrar(campo, texto, contem);
                var model = lista.Adapt<ParametroViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ParametroViewModel Incluir(ParametroViewModel model)
        {
            var parametroViewModel = new ParametroViewModel();
            try
            {
                var parametro = model.Adapt<Parametro>();
                _servicoParametro.Salvar(parametro);
                parametroViewModel = parametro.Adapt<ParametroViewModel>();
                return parametroViewModel;
            }
            catch (Exception ex)
            {
                parametroViewModel.Mensagem = ex.Message;
                return parametroViewModel;
            }
        }

        [HttpPut]
        public ParametroViewModel Update(ParametroViewModel model)
        {
            var parametroViewModel = new ParametroViewModel();
            try
            {
                var parametro = model.Adapt<Parametro>();
                _servicoParametro.Salvar(parametro);
                parametroViewModel = parametro.Adapt<ParametroViewModel>();
                return parametroViewModel;
            }
            catch (Exception ex)
            {
                parametroViewModel.Mensagem = ex.Message;
                return parametroViewModel;
            }
        }

        [HttpDelete]
        public ParametroViewModel Delete(int idUsuario, int id)
        {
            var model = new ParametroViewModel();
            try
            {
                _servicoParametro.Excluir(_servicoParametro.ObterPorId(id), idUsuario);
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
