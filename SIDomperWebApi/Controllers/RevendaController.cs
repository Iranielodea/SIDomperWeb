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
    [RoutePrefix("api/revenda")]
    public class RevendaController : ApiController
    {
        //private readonly RevendaServico _revendaServico;
        private readonly IServicoRevenda _servicoRevenda;

        public RevendaController(IServicoRevenda servicoRevenda)
        {
            //_revendaServico = new RevendaServico();
            _servicoRevenda = servicoRevenda;
        }

        [Route("ObterPorId")]
        [HttpGet]
        public RevendaViewModel ObterPorId(int id)
        {
            var model = new RevendaViewModel();
            try
            {
                var item = _servicoRevenda.ObterPorId(id);
                //var item = _revendaServico.ObterPorId(id);
                model = item.Adapt<RevendaViewModel>();
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
        public RevendaViewModel Editar(int id, int idUsuario)
        {
            var model = new RevendaViewModel();
            try
            {
                string mensagem = "";
                var item = _servicoRevenda.Editar(id, idUsuario, ref mensagem);
                //var item = _revendaServico.Editar(idUsuario, id, ref mensagem);
                model = item.Adapt<RevendaViewModel>();
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
        public RevendaViewModel Novo(int idUsuario)
        {
            var model = new RevendaViewModel();
            try
            {
                var item = _servicoRevenda.Novo(idUsuario);
                //var item = _revendaServico.Novo(idUsuario);
                model = item.Adapt<RevendaViewModel>();
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
        public RevendaViewModel ObterPorCodigo(int codigo)
        {
            var model = new RevendaViewModel();
            try
            {
                var revenda = _servicoRevenda.ObterPorCodigo(codigo);
                //var prod = _revendaServico.ObterPorCodigo(codigo);
                model = revenda.Adapt<RevendaViewModel>();
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
        public IEnumerable<RevendaConsultaViewModel> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            try
            {
                var lista = _servicoRevenda.Filtrar(campo, texto, ativo, contem);
                //var lista = _revendaServico.Filtrar(campo, texto, ativo, contem);
                var model = lista.Adapt<RevendaConsultaViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public RevendaViewModel Incluir(RevendaViewModel model)
        {

            var revendaViewModel = new RevendaViewModel();
            try
            {
                var revenda = model.Adapt<Revenda>();
                _servicoRevenda.Salvar(revenda);
                //_revendaServico.Salvar(revenda);

                revendaViewModel = revenda.Adapt<RevendaViewModel>();
                return revendaViewModel;
            }
            catch (Exception ex)
            {
                revendaViewModel.Mensagem = ex.Message;
                return revendaViewModel;
            }
        }

        [HttpPut]
        public RevendaViewModel Update(RevendaViewModel model)
        {
            var revendaViewModel = new RevendaViewModel();
            try
            {
                var revenda = model.Adapt<Revenda>();
                _servicoRevenda.Salvar(revenda);
                //_revendaServico.Salvar(revenda);

                revendaViewModel = revenda.Adapt<RevendaViewModel>();
                return revendaViewModel;
            }
            catch (Exception ex)
            {
                revendaViewModel.Mensagem = ex.Message;
                return revendaViewModel;
            }
        }

        //DELETE api/<controller>/5
        [HttpDelete]
        public RevendaViewModel Delete(int id, int idUsuario) 
        {
            var model = new RevendaViewModel();
            try
            {
                //var revenda = _revendaServico.ObterPorId(id);
                //_revendaServico.Excluir(idUsuario, revenda);
                _servicoRevenda.Excluir(_servicoRevenda.ObterPorId(id), idUsuario);
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
