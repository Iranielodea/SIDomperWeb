﻿using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    [RoutePrefix("api/feriado")]
    public class FeriadoController : ApiController
    {
        private readonly FeriadoServico _feridadoServico;
        private readonly IServicoFeriado _servicoFeriado;

        public FeriadoController(IServicoFeriado servicoFeriado)
        {
            _feridadoServico = new FeriadoServico();
            _servicoFeriado = servicoFeriado;
        }

        [Route("ObterPorId")]
        [HttpGet]
        public FeriadoViewModel ObterPorId(int id)
        {
            var model = new FeriadoViewModel();
            try
            {
                var item = _servicoFeriado.ObterPorId(id);
                //var item = _feridadoServico.ObterPorId(id);
                model = item.Adapt<FeriadoViewModel>();
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
        public FeriadoViewModel Editar(int id, int idUsuario)
        {
            var model = new FeriadoViewModel();
            try
            {
                string mensagem = "";
                var item = _servicoFeriado.Editar(id, idUsuario, ref mensagem);
                //var item = _feridadoServico.Editar(idUsuario, id, ref mensagem);
                model = item.Adapt<FeriadoViewModel>();
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
        public FeriadoViewModel Novo(int idUsuario)
        {
            var model = new FeriadoViewModel();
            try
            {
                var item = _servicoFeriado.Novo(idUsuario);
                //var item = _feridadoServico.Novo(idUsuario);
                model = item.Adapt<FeriadoViewModel>();
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
        public IEnumerable<FeriadoViewModel> Filtrar(string campo, string texto)
        {
            try
            {
                var lista = _servicoFeriado.Filtrar(campo, texto);
                //var lista = _feridadoServico.Filtrar(campo, texto);
                var model = lista.Adapt<FeriadoViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public FeriadoViewModel Incluir(FeriadoViewModel model)
        {
            var feridadoViewModel = new FeriadoViewModel();
            try
            {
                var feridado = model.Adapt<Feriado>();
                _servicoFeriado.Salvar(feridado);
                //_feridadoServico.Salvar(feridado);
                feridadoViewModel = feridado.Adapt<FeriadoViewModel>();
                return feridadoViewModel;
            }
            catch (Exception ex)
            {
                feridadoViewModel.Mensagem = ex.Message;
                return feridadoViewModel;
            }
        }

        [HttpPut]
        public FeriadoViewModel Update(FeriadoViewModel model)
        {
            var feridadoViewModel = new FeriadoViewModel();
            try
            {
                var feridado = model.Adapt<Feriado>();
                _servicoFeriado.Salvar(feridado);
                //_feridadoServico.Salvar(feridado);
                feridadoViewModel = feridado.Adapt<FeriadoViewModel>();
                return feridadoViewModel;
            }
            catch (Exception ex)
            {
                feridadoViewModel.Mensagem = ex.Message;
                return feridadoViewModel;
            }
        }

        [HttpDelete]
        public FeriadoViewModel Delete(int id, int idUsuario)
        {
            var model = new FeriadoViewModel();
            try
            {
                //var feriado = _feridadoServico.ObterPorId(id);
                //_feridadoServico.Excluir(feriado, idUsuario);
                _servicoFeriado.Excluir(_servicoFeriado.ObterPorId(id), idUsuario);
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