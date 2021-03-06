﻿using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    [RoutePrefix("api/tipo")]
    public class TipoController : ApiController
    {
        private readonly IServicoTipo _servicoTipo;

        public TipoController(IServicoTipo servicoTipo)
        {
            _servicoTipo = servicoTipo;
        }

        [Route("ObterPorId")]
        [HttpGet]
        public TipoViewModel ObterPorId(int id)
        {
            var model = new TipoViewModel();
            try
            {
                var item = _servicoTipo.ObterPorId(id);
                model = item.Adapt<TipoViewModel>();
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
        public TipoViewModel Editar(int id, int idUsuario)
        {
            var model = new TipoViewModel();
            try
            {
                string mensagem = "";
                var item = _servicoTipo.Editar(id, idUsuario, ref mensagem);
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

        [Route("Novo")]
        [HttpGet]
        public TipoViewModel Novo(int idUsuario)
        {
            var model = new TipoViewModel();
            try
            {
                var item = _servicoTipo.Novo(idUsuario);
                model = item.Adapt<TipoViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("ObterPorCodigoTipo")]
        [HttpGet]
        public TipoViewModel ObterPorCodigo(int codigo, EnTipos enTipos)
        {
            var model = new TipoViewModel();
            try
            {
                var prod = _servicoTipo.ObterPorCodigo(codigo, enTipos);
                model = prod.Adapt<TipoViewModel>();
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
        public IEnumerable<TipoConsultaViewModel> Filtrar(string campo, string texto, EnTipos enTipos, string ativo = "A", bool contem = true)
        {
            try
            {
                var lista = _servicoTipo.Filtrar(campo, texto, enTipos, ativo, contem);
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
                _servicoTipo.Salvar(tipo);
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
                _servicoTipo.Salvar(tipo);
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
        public TipoViewModel Delete(int id, int idUsuario)
        {
            var model = new TipoViewModel();
            try
            {
                _servicoTipo.Excluir(_servicoTipo.ObterPorId(id), idUsuario);
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
