﻿using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    //[RoutePrefix("api/chamado")]
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        //private readonly ProdutoServico _produtoServico;
        private readonly IServicoProduto _servicoProduto;

        public ProdutoController(IServicoProduto servicoProduto)
        {
            _servicoProduto = servicoProduto;
            //_produtoServico = new ProdutoServico();
        }

        [Route("ObterPorId")]
        [HttpGet]
        public ProdutoViewModel ObterPorId(int id)
        {
            var model = new ProdutoViewModel();
            try
            {
                //var item = _produtoServico.ObterPorId(id);
                var item = _servicoProduto.ObterPorId(id);
                model = item.Adapt<ProdutoViewModel>();
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
        public ProdutoViewModel Editar(int id, int idUsuario)
        {
            var model = new ProdutoViewModel();
            try
            {
                string mensagem = "";
                //var item = _produtoServico.Editar(idUsuario, id, ref mensagem);
                var item = _servicoProduto.Editar(id, idUsuario, ref mensagem);
                model = item.Adapt<ProdutoViewModel>();
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
        public ProdutoViewModel Novo(int idUsuario)
        {
            var model = new ProdutoViewModel();
            try
            {
                var item = _servicoProduto.Novo(idUsuario);
                //var item = _produtoServico.Novo(idUsuario);
                model = item.Adapt<ProdutoViewModel>();
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
        public ProdutoViewModel ObterPorCodigo(int codigo)
        {
            var model = new ProdutoViewModel();
            try
            {
                var prod = _servicoProduto.ObterPorCodigo(codigo);
                //var prod = _produtoServico.ObterPorCodigo(codigo);
                model = prod.Adapt<ProdutoViewModel>();
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
        public IEnumerable<ProdutoViewModel> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            try
            {
                var lista = _servicoProduto.Filtrar(campo, texto, ativo, contem);
                //var lista = _produtoServico.Filtrar(campo, texto, ativo, contem);
                var model = lista.Adapt<ProdutoViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ProdutoViewModel Incluir(ProdutoViewModel model)
        {
            var produtoViewModel = new ProdutoViewModel();
            try
            {
                var produto = model.Adapt<Produto>();
                _servicoProduto.Salvar(produto);
                //_produtoServico.Salvar(produto);
                produtoViewModel = produto.Adapt<ProdutoViewModel>();
                return produtoViewModel;
            }
            catch (Exception ex)
            {
                produtoViewModel.Mensagem = ex.Message;
                return produtoViewModel;
            }
        }

        [HttpPut]
        public ProdutoViewModel Update(ProdutoViewModel model)
        {
            var produtoViewModel = new ProdutoViewModel();
            try
            {
                var produto = model.Adapt<Produto>();
                //_produtoServico.Salvar(produto);
                _servicoProduto.Salvar(produto);
                produtoViewModel = produto.Adapt<ProdutoViewModel>();
                return produtoViewModel;
            }
            catch (Exception ex)
            {
                produtoViewModel.Mensagem = ex.Message;
                return produtoViewModel;
            }
        }

        [HttpDelete]
        public ProdutoViewModel Delete(int idUsuario, int id)
        {
            var model = new ProdutoViewModel();
            try
            {
                //_produtoServico.Excluir(idUsuario, id);
                _servicoProduto.Excluir(_servicoProduto.ObterPorId(id), idUsuario);
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