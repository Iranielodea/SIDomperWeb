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
    [RoutePrefix("api/contaemail")]
    public class ContaEmailController : ApiController
    {
        //private readonly ContaEmailServico _contaEmailServico;
        private readonly IServicoContaEmail _servicoContaEmail;

        public ContaEmailController(IServicoContaEmail servicoContaEmail)
        {
            //_contaEmailServico = new ContaEmailServico();
            _servicoContaEmail = servicoContaEmail;
        }

        [Route("ObterPorId")]
        [HttpGet]
        public ContaEmailViewModel ObterPorId(int id)
        {
            var model = new ContaEmailViewModel();
            try
            {
                var prod = _servicoContaEmail.ObterPorId(id);
                //var prod = _contaEmailServico.ObterPorId(id);
                model = prod.Adapt<ContaEmailViewModel>();
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
        public ContaEmailViewModel Editar(int id, int idUsuario)
        {
            var model = new ContaEmailViewModel();
            try
            {
                string mensagem = "";
                var item = _servicoContaEmail.Editar(id, idUsuario, ref mensagem);
                //var item = _contaEmailServico.Editar(idUsuario, id, ref mensagem);
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

        [Route("Novo")]
        [HttpGet]
        public ContaEmailViewModel Novo(int idUsuario)
        {
            var model = new ContaEmailViewModel();
            try
            {
                var item = _servicoContaEmail.Novo(idUsuario);
                //var item = _contaEmailServico.Novo(idUsuario);
                model = item.Adapt<ContaEmailViewModel>();
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
        public ContaEmailViewModel ObterPorCodigo(int codigo)
        {
            var model = new ContaEmailViewModel();
            try
            {
                var prod = _servicoContaEmail.ObterPorCodigo(codigo);
                //var prod = _contaEmailServico.ObterPorCodigo(codigo);
                model = prod.Adapt<ContaEmailViewModel>();
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
        public IEnumerable<ContaEmailConsultaViewModel> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            try
            {
                var lista = _servicoContaEmail.Filtrar(campo, texto, ativo, contem);
                //var lista = _contaEmailServico.Filtrar(campo, texto, ativo, contem);
                var model = lista.Adapt<ContaEmailConsultaViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ContaEmailViewModel Incluir([FromBody] ContaEmailViewModel model)
        {
            var produtoViewModel = new ContaEmailViewModel();
            try
            {
                var produto = model.Adapt<ContaEmail>();
                _servicoContaEmail.Salvar(produto);
                //_contaEmailServico.Salvar(produto);
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
                _servicoContaEmail.Salvar(produto);
                //_contaEmailServico.Salvar(produto);
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
        public ContaEmailViewModel Delete(int id, int idUsuario)
        {
            var model = new ContaEmailViewModel();
            try
            {
                //var contaEmail = _contaEmailServico.ObterPorId(id);
                //_contaEmailServico.Excluir(idUsuario, contaEmail);
                _servicoContaEmail.Excluir(_servicoContaEmail.ObterPorId(id), idUsuario);
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
