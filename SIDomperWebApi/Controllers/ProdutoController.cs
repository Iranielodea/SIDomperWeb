using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.Servicos;
using SIDomper.Dominio.ViewModel;
using SIDomper.Infra.DataBase;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class ProdutoController : ApiController
    {
        private readonly ProdutoServico _produtoServico;
        private readonly IServicoProduto _servicoProduto;

        public ProdutoController(IServicoProduto servicoProduto)
        {
            _servicoProduto = servicoProduto;
            _produtoServico = new ProdutoServico();
        }

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

        [HttpGet]
        public ProdutoViewModel Editar(int idUsuario, int id)
        {
            var model = new ProdutoViewModel();
            try
            {
                string mensagem = "";
                var item = _produtoServico.Editar(idUsuario, id, ref mensagem);
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

        [HttpGet]
        public ProdutoViewModel Novo(string novo, int idUsuario)
        {
            var model = new ProdutoViewModel();
            try
            {
                var item = _produtoServico.Novo(idUsuario);
                model = item.Adapt<ProdutoViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

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
                //_servicoProduto.Salvar(produto);
                _produtoServico.Salvar(produto);
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
                _produtoServico.Excluir(idUsuario, id);
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