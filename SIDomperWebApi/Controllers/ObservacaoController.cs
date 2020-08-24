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
    [RoutePrefix("api/observacao")]
    public class ObservacaoController : ApiController
    {
        private readonly IServicoObservacao _servicoObservacao;

        public ObservacaoController(IServicoObservacao servicoObservacao)
        {
            _servicoObservacao = servicoObservacao;
        }

        [Route("ObterPorId")]
        [HttpGet]
        public ObservacaoViewModel ObterPorId(int id)
        {
            var model = new ObservacaoViewModel();
            try
            {
                var item = _servicoObservacao.ObterPorId(id);
                model = item.Adapt<ObservacaoViewModel>();
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
        public ObservacaoViewModel Editar(int id, int idUsuario)
        {
            var model = new ObservacaoViewModel();
            try
            {
                string mensagem = "";
                var item = _servicoObservacao.Editar(id, idUsuario, ref mensagem);
                model = item.Adapt<ObservacaoViewModel>();
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
        public ObservacaoViewModel Novo(int idUsuario)
        {
            var model = new ObservacaoViewModel();
            try
            {
                var item = _servicoObservacao.Novo(idUsuario);
                model = item.Adapt<ObservacaoViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("ObservacaoPadrao")]
        [HttpGet]
        public ObservacaoViewModel ObservacaoPadrao(int idPrograma)
        {
            var model = new ObservacaoViewModel();
            try
            {
                var item = _servicoObservacao.ObterPadrao(idPrograma);
                model = item.Adapt<ObservacaoViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("ObservacaoEmailPadrao")]
        [HttpGet]
        public ObservacaoViewModel ObservacaoEmailPadrao(int idPrograma)
        {
            var model = new ObservacaoViewModel();
            try
            {
                var item = _servicoObservacao.ObterEmailPadrao(idPrograma);
                model = item.Adapt<ObservacaoViewModel>();
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
        public ObservacaoViewModel ObterPorCodigo(int codigo)
        {
            var model = new ObservacaoViewModel();
            try
            {
                var prod = _servicoObservacao.ObterPorCodigo(codigo);
                model = prod.Adapt<ObservacaoViewModel>();
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
        public IEnumerable<ObservacaoConsultaViewModel> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            try
            {
                var lista = _servicoObservacao.Filtrar(campo, texto, ativo, contem);
                var model = lista.Adapt<ObservacaoConsultaViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ObservacaoViewModel Incluir(ObservacaoViewModel model)
        {
            var observacaoViewModel = new ObservacaoViewModel();
            try
            {
                var observacao = model.Adapt<Observacao>();
                _servicoObservacao.Salvar(observacao);
                observacaoViewModel = observacao.Adapt<ObservacaoViewModel>();
                return observacaoViewModel;
            }
            catch (Exception ex)
            {
                observacaoViewModel.Mensagem = ex.Message;
                return observacaoViewModel;
            }
        }

        [HttpPut]
        public ObservacaoViewModel Update(ObservacaoViewModel model)
        {
            var observacaoViewModel = new ObservacaoViewModel();
            try
            {
                var observacao = model.Adapt<Observacao>();
                _servicoObservacao.Salvar(observacao);
                observacaoViewModel = observacao.Adapt<ObservacaoViewModel>();
                return observacaoViewModel;
            }
            catch (Exception ex)
            {
                observacaoViewModel.Mensagem = ex.Message;
                return observacaoViewModel;
            }
        }

        [HttpDelete]
        public ObservacaoViewModel Delete(int idUsuario, int id)
        {
            var model = new ObservacaoViewModel();
            try
            {
                _servicoObservacao.Excluir(_servicoObservacao.ObterPorId(id), idUsuario);
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