﻿using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;
using System;
using System.Linq;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class BaseConhController : ApiController
    {
        private readonly IServicoBaseConhecimento _servicoBaseConhecimento;

        public BaseConhController(IServicoBaseConhecimento servicoBaseConhecimento)
        {
            _servicoBaseConhecimento = servicoBaseConhecimento;
        }

        [HttpGet]
        public BaseConhViewModel ObterPorId(int id)
        {
            var model = new BaseConhViewModel();
            try
            {
                var item = _servicoBaseConhecimento.ObterPorId(id);
                model = item.Adapt<BaseConhViewModel>();

                PopularDados(item, model);
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public BaseConhViewModel Editar(int idUsuario, int id)
        {
            var model = new BaseConhViewModel();
            try
            {
                string mensagem = "";
                var item = _servicoBaseConhecimento.Editar(id, idUsuario, ref mensagem);
                model = item.Adapt<BaseConhViewModel>();
                PopularDados(item, model);

                model.Mensagem = mensagem;
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        private void PopularDados(BaseConhecimento item, BaseConhViewModel model)
        {
            if (item.Produto != null)
            {
                model.CodProduto = item.Produto.Codigo;
                model.NomeProduto = item.Produto.Nome;
            }

            if (item.Modulo != null)
            {
                model.CodModulo = item.Modulo.Codigo;
                model.NomeModulo = item.Modulo.Nome;
            }

            model.CodStatus = item.Status.Codigo;
            model.NomeStatus = item.Status.Nome;

            model.CodTipo = item.Tipo.Codigo;
            model.NomeTipo = item.Tipo.Nome;

            model.CodUsuario = item.Usuario.Codigo;
            model.NomeUsuario = item.Usuario.Nome;
        }

        [HttpGet]
        public BaseConhViewModel Novo(string novo, int idUsuario)
        {
            var model = new BaseConhViewModel();
            try
            {
                var item = _servicoBaseConhecimento.Novo(idUsuario);
                model = item.Adapt<BaseConhViewModel>();

                model.UsuarioId = item.UsuarioId;
                model.CodUsuario = item.Usuario.Codigo;
                model.NomeUsuario = item.Usuario.Nome;

                model.TipoId = item.Tipo.Id;
                model.CodTipo = item.Tipo.Codigo;
                model.NomeTipo = item.Tipo.Nome;
                model.Data = item.Data;

                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpPost]
        public BaseConhConsultaViewModel[] Filtrar([FromBody] BaseConhecimentoFiltroViewModel filtro, int usuarioId, bool contem = true)
        {
            try
            {
                return _servicoBaseConhecimento.Filtrar(filtro, filtro.Campo, filtro.Texto, usuarioId, contem).ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public BaseConhViewModel Incluir(BaseConhViewModel model)
        {

            var baseConhViewModel = new BaseConhViewModel();
            try
            {
                var baseConh = model.Adapt<BaseConhecimento>();
                _servicoBaseConhecimento.Salvar(baseConh);

                baseConhViewModel = baseConh.Adapt<BaseConhViewModel>();
                return baseConhViewModel;
            }
            catch (Exception ex)
            {
                baseConhViewModel.Mensagem = ex.Message;
                return baseConhViewModel;
            }
        }

        [HttpPut]
        public BaseConhViewModel Update(BaseConhViewModel model)
        {
            var baseConhViewModel = new BaseConhViewModel();
            try
            {
                var baseConh = model.Adapt<BaseConhecimento>();
                _servicoBaseConhecimento.Salvar(baseConh);

                baseConhViewModel = baseConh.Adapt<BaseConhViewModel>();
                return baseConhViewModel;
            }
            catch (Exception ex)
            {
                baseConhViewModel.Mensagem = ex.Message;
                return baseConhViewModel;
            }
        }

        //DELETE api/<controller>/5
        [HttpDelete]
        public BaseConhViewModel Delete(int idUsuario, int id)
        {
            var model = new BaseConhViewModel();
            try
            {
                var baseConh = _servicoBaseConhecimento.ObterPorId(id);
                _servicoBaseConhecimento.Excluir(baseConh, idUsuario);
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
