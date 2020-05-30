using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class TipoController : ApiController
    {
        private readonly TipoServico _tipoServico;

        public TipoController()
        {
            _tipoServico = new TipoServico();
        }

        [HttpGet]
        public TipoViewModel ObterPorId(int id)
        {
            var model = new TipoViewModel();
            try
            {
                var item = _tipoServico.ObterPorId(id);
                model = item.Adapt<TipoViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public TipoViewModel Editar(int idUsuario, int id)
        {
            var model = new TipoViewModel();
            try
            {
                string mensagem = "";
                var item = _tipoServico.Editar(idUsuario, id, ref mensagem);
                model = item.Adapt<TipoViewModel>();
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
        public TipoViewModel Novo(string novo, int idUsuario)
        {
            var model = new TipoViewModel();
            try
            {
                var item = _tipoServico.Novo(idUsuario);
                model = item.Adapt<TipoViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public TipoViewModel ObterPorCodigo(int codigo, EnTipos enTipos)
        {
            var model = new TipoViewModel();
            try
            {
                var prod = _tipoServico.ObterPorCodigo(codigo, enTipos);
                model = prod.Adapt<TipoViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public IEnumerable<TipoConsultaViewModel> Filtrar(string campo, string texto, EnTipos enTipos, string ativo = "A", bool contem = true)
        {
            try
            {
                var lista = _tipoServico.Filtrar(campo, texto, enTipos, ativo, contem);
                var model = lista.Adapt<TipoConsultaViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public TipoViewModel Incluir(TipoViewModel model)
        {
            var TipoViewModel = new TipoViewModel();
            try
            {
                var tipo = model.Adapt<Tipo>();
                _tipoServico.Salvar(tipo);
                TipoViewModel = tipo.Adapt<TipoViewModel>();
                return TipoViewModel;
            }
            catch (Exception ex)
            {
                TipoViewModel.Mensagem = ex.Message;
                return TipoViewModel;
            }
        }

        [HttpPut]
        public TipoViewModel Update(TipoViewModel model)
        {
            var TipoViewModel = new TipoViewModel();
            try
            {
                var tipo = model.Adapt<Tipo>();
                _tipoServico.Salvar(tipo);
                TipoViewModel = tipo.Adapt<TipoViewModel>();
                return TipoViewModel;
            }
            catch (Exception ex)
            {
                TipoViewModel.Mensagem = ex.Message;
                return TipoViewModel;
            }
        }

        //DELETE api/<controller>/5
        [HttpDelete]
        public TipoViewModel Delete(int idUsuario, int id)
        {
            var model = new TipoViewModel();
            try
            {
                _tipoServico.Excluir(idUsuario, id);
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
