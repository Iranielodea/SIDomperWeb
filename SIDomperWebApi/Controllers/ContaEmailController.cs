using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class ContaEmailController : ApiController
    {
        private readonly ContaEmailServico _contaEmailServico;

        public ContaEmailController()
        {
            _contaEmailServico = new ContaEmailServico();
        }

        [HttpGet]
        public ContaEmailViewModel ObterPorId(int id)
        {
            var model = new ContaEmailViewModel();
            try
            {
                var prod = _contaEmailServico.ObterPorId(id);
                model = prod.Adapt<ContaEmailViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public ContaEmailViewModel Editar(int idUsuario, int id)
        {
            var model = new ContaEmailViewModel();
            try
            {
                string mensagem = "";
                var item = _contaEmailServico.Editar(idUsuario, id, ref mensagem);
                model = item.Adapt<ContaEmailViewModel>();
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
        public ContaEmailViewModel Novo(string novo, int idUsuario)
        {
            var model = new ContaEmailViewModel();
            try
            {
                var item = _contaEmailServico.Novo(idUsuario);
                model = item.Adapt<ContaEmailViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public ContaEmailViewModel ObterPorCodigo(int codigo)
        {
            var model = new ContaEmailViewModel();
            try
            {
                var prod = _contaEmailServico.ObterPorCodigo(codigo);
                model = prod.Adapt<ContaEmailViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public IEnumerable<ContaEmailConsultaViewModel> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            try
            {
                var lista = _contaEmailServico.Filtrar(campo, texto, ativo, contem);
                var model = lista.Adapt<ContaEmailConsultaViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ContaEmailViewModel Incluir(ContaEmailViewModel model)
        {
            var produtoViewModel = new ContaEmailViewModel();
            try
            {
                var produto = model.Adapt<ContaEmail>();
                _contaEmailServico.Salvar(produto);
                produtoViewModel = produto.Adapt<ContaEmailViewModel>();
                return produtoViewModel;
            }
            catch (Exception ex)
            {
                produtoViewModel.Mensagem = ex.Message;
                return produtoViewModel;
            }
        }

        [HttpPut]
        public ContaEmailViewModel Update(ContaEmailViewModel model)
        {
            var produtoViewModel = new ContaEmailViewModel();
            try
            {
                var produto = model.Adapt<ContaEmail>();
                _contaEmailServico.Salvar(produto);
                produtoViewModel = produto.Adapt<ContaEmailViewModel>();
                return produtoViewModel;
            }
            catch (Exception ex)
            {
                produtoViewModel.Mensagem = ex.Message;
                return produtoViewModel;
            }
        }

        //DELETE api/<controller>/5
        [HttpDelete]
        public ContaEmailViewModel Delete(int idUsuario, int id)
        {
            var model = new ContaEmailViewModel();
            try
            {
                var contaEmail = _contaEmailServico.ObterPorId(id);
                _contaEmailServico.Excluir(idUsuario, contaEmail);
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
