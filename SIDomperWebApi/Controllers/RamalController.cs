using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class RamalController : ApiController
    {
        private readonly RamalServico _ramalServico;

        public RamalController()
        {
            _ramalServico = new RamalServico();
        }

        [HttpGet]
        public RamalViewModel ObterPorId(int id)
        {
            var model = new RamalViewModel();
            try
            {
                var item = _ramalServico.ObterPorId(id);
                model = item.Adapt<RamalViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public RamalViewModel Editar(int idUsuario, int id)
        {
            var model = new RamalViewModel();
            try
            {
                string mensagem = "";
                var item = _ramalServico.Editar(idUsuario, id, ref mensagem);
                model = item.Adapt<RamalViewModel>();
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
        public RamalViewModel Novo(string novo, int idUsuario)
        {
            var model = new RamalViewModel();
            try
            {
                var item = _ramalServico.Novo(idUsuario);
                model = item.Adapt<RamalViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public IEnumerable<RamalConsultaViewModel> Filtrar(string campo, string texto, bool contem = true)
        {
            try
            {
                var lista = _ramalServico.Filtrar(campo, texto, contem);
                var model = lista.Adapt<RamalConsultaViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPost]
        public RamalViewModel Incluir(RamalViewModel model)
        {

            var ramalViewModel = new RamalViewModel();
            try
            {
                var ramal = model.Adapt<Ramal>();
                _ramalServico.Salvar(ramal);

                ramalViewModel = ramal.Adapt<RamalViewModel>();
                return ramalViewModel;
            }
            catch (Exception ex)
            {
                ramalViewModel.Mensagem = ex.Message;
                return ramalViewModel;
            }
        }

        [HttpPut]
        public RamalViewModel Update(RamalViewModel model)
        {
            var ramalViewModel = new RamalViewModel();
            try
            {
                var ramal = model.Adapt<Ramal>();
                _ramalServico.Salvar(ramal);

                ramalViewModel = ramal.Adapt<RamalViewModel>();
                return ramalViewModel;
            }
            catch (Exception ex)
            {
                ramalViewModel.Mensagem = ex.Message;
                return ramalViewModel;
            }
        }

        //DELETE api/<controller>/5
        [HttpDelete]
        public RamalViewModel Delete(int idUsuario, int id)
        {
            var model = new RamalViewModel();
            try
            {
                var ramal = _ramalServico.ObterPorId(id);
                _ramalServico.Excluir(idUsuario, ramal);
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
