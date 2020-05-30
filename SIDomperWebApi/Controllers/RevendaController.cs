using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class RevendaController : ApiController
    {
        private readonly RevendaServico _revendaServico;

        public RevendaController()
        {
            _revendaServico = new RevendaServico();
        }

        [HttpGet]
        public RevendaViewModel ObterPorId(int id)
        {
            var model = new RevendaViewModel();
            try
            {
                var item = _revendaServico.ObterPorId(id);
                model = item.Adapt<RevendaViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public RevendaViewModel Editar(int idUsuario, int id)
        {
            var model = new RevendaViewModel();
            try
            {
                string mensagem = "";
                var item = _revendaServico.Editar(idUsuario, id, ref mensagem);
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

        [HttpGet]
        public RevendaViewModel Novo(string novo, int idUsuario)
        {
            var model = new RevendaViewModel();
            try
            {
                var item = _revendaServico.Novo(idUsuario);
                model = item.Adapt<RevendaViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public RevendaViewModel ObterPorCodigo(int codigo)
        {
            var model = new RevendaViewModel();
            try
            {
                var prod = _revendaServico.ObterPorCodigo(codigo);
                model = prod.Adapt<RevendaViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public IEnumerable<RevendaConsultaViewModel> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            try
            {
                var lista = _revendaServico.Filtrar(campo, texto, ativo, contem);
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
                _revendaServico.Salvar(revenda);

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
                _revendaServico.Salvar(revenda);

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
        public RevendaViewModel Delete(int idUsuario, int id)
        {
            var model = new RevendaViewModel();
            try
            {
                var revenda = _revendaServico.ObterPorId(id);
                _revendaServico.Excluir(idUsuario, revenda);
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
