using Mapster;
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
        private readonly IServicoProduto _servicoProduto;

        public ProdutoController(IServicoProduto servicoProduto)
        {
            _servicoProduto = servicoProduto;
        }

        [Route("ObterPorId")]
        [HttpGet]
        public ProdutoViewModel ObterPorId(int id)
        {
            var model = new ProdutoViewModel();
            try
            {
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
        public ProdutoViewModel Delete(int id, int idUsuario)
        {
            var model = new ProdutoViewModel();
            try
            {
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