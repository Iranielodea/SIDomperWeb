using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class ParametroController : ApiController
    {
        private readonly ParametroServico _parametroServico;

        public ParametroController()
        {
            _parametroServico = new ParametroServico();
        }

        [HttpGet]
        public ParametroViewModel ObterPorId(int id)
        {
            var model = new ParametroViewModel();
            try
            {
                var prod = _parametroServico.ObterPorId(id);
                model = prod.Adapt<ParametroViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public ParametroViewModel Novo(string novo, int idUsuario)
        {
            var model = new ParametroViewModel();
            try
            {
                var item = _parametroServico.Novo(idUsuario);
                model = item.Adapt<ParametroViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public ParametroViewModel ObterPorParametro(int codigo, int programa)
        {
            var model = new ParametroViewModel();
            try
            {
                var prod = _parametroServico.ObterPorParametro(codigo, programa);
                model = prod.Adapt<ParametroViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public ParametroViewModel Editar(int id, int idUsuario)
        {
            var model = new ParametroViewModel();
            try
            {
                string mensagem = "";
                var prod = _parametroServico.Editar(idUsuario, id, ref mensagem);
                model = prod.Adapt<ParametroViewModel>();
                model.Mensagem = mensagem;
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public IEnumerable<ParametroViewModel> Filtrar(string campo, string texto, bool contem = true)
        {
            try
            {
                var lista = _parametroServico.Filtrar(campo, texto, contem);
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
                _parametroServico.Salvar(parametro);
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
                _parametroServico.Salvar(parametro);
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
                _parametroServico.Excluir(idUsuario, id);
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
