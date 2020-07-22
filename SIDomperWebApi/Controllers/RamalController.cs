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
    [RoutePrefix("api/ramal")]
    public class RamalController : ApiController
    {
        private readonly IServicoRamal _servicoRamal;

        public RamalController(IServicoRamal servicoRamal)
        {
            _servicoRamal = servicoRamal;
        }

        [Route("ObterPorId")]
        [HttpGet]
        public RamalViewModel ObterPorId(int id)
        {
            var model = new RamalViewModel();
            try
            {
                var item = _servicoRamal.ObterPorId(id);
                model = item.Adapt<RamalViewModel>();
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
        public RamalViewModel Editar(int id, int idUsuario)
        {
            var model = new RamalViewModel();
            try
            {
                string mensagem = "";
                var item = _servicoRamal.Editar(id, idUsuario, ref mensagem);
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

        [Route("Novo")]
        [HttpGet]
        public RamalViewModel Novo(int idUsuario)
        {
            var model = new RamalViewModel();
            try
            {
                var item = _servicoRamal.Novo(idUsuario);
                model = item.Adapt<RamalViewModel>();
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
        public IEnumerable<RamalConsultaViewModel> Filtrar(string campo, string texto, bool contem = true)
        {
            try
            {
                var lista = _servicoRamal.Filtrar(campo, texto, contem);
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
                _servicoRamal.Salvar(ramal);

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
                _servicoRamal.Salvar(ramal);

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
        public RamalViewModel Delete(int id, int idUsuario)
        {
            var model = new RamalViewModel();
            try
            {
                _servicoRamal.Excluir(_servicoRamal.ObterPorId(id), idUsuario);
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
