using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Servicos;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    [RoutePrefix("api/status")]
    public class StatusController : ApiController
    {
        private readonly ServicoStatus _servicoStatus;

        public StatusController(ServicoStatus servicoStatus)
        {
            _servicoStatus = servicoStatus;
        }

        [Route("ObterPorId")]
        [HttpGet]
        public StatusViewModel ObterPorId(int id)
        {
            var model = new StatusViewModel();
            try
            {
                var item = _servicoStatus.ObterPorId(id);
                model = item.Adapt<StatusViewModel>();
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
        public StatusViewModel Editar(int id, int idUsuario)
        {
            var model = new StatusViewModel();
            try
            {
                string mensagem = "";
                var item = _servicoStatus.Editar(id, idUsuario, ref mensagem);
                model = item.Adapt<StatusViewModel>();
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
        public StatusViewModel Novo(int idUsuario)
        {
            var model = new StatusViewModel();
            try
            {
                var item = _servicoStatus.Novo(idUsuario);
                model = item.Adapt<StatusViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("ObterPorCodigoStatus")]
        [HttpGet]
        public StatusViewModel ObterPorCodigo(int codigo, EnStatus enStatus)
        {
            var model = new StatusViewModel();
            try
            {
                var prod = _servicoStatus.ObterPorCodigo(codigo, enStatus);
                model = prod.Adapt<StatusViewModel>();
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
        public IEnumerable<StatusConsultaViewModel> Filtrar(string campo, string texto, EnStatus enStatus, string ativo = "A", bool contem = true)
        {
            try
            {
                var lista = _servicoStatus.Filtrar(campo, texto, enStatus, ativo, contem);
                var model = lista.Adapt<StatusConsultaViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public StatusViewModel Incluir(StatusViewModel model)
        {
            var statusViewModel = new StatusViewModel();
            try
            {
                var status = model.Adapt<Status>();
                _servicoStatus.Salvar(status);
                statusViewModel = status.Adapt<StatusViewModel>();
                return statusViewModel;
            }
            catch (Exception ex)
            {
                statusViewModel.Mensagem = ex.Message;
                return statusViewModel;
            }
        }

        [HttpPut]
        public StatusViewModel Update(StatusViewModel model)
        {
            var statusViewModel = new StatusViewModel();
            try
            {
                var status = model.Adapt<Status>();
                _servicoStatus.Salvar(status);
                statusViewModel = status.Adapt<StatusViewModel>();
                return statusViewModel;
            }
            catch (Exception ex)
            {
                statusViewModel.Mensagem = ex.Message;
                return statusViewModel;
            }
        }

        [HttpDelete]
        public StatusViewModel Delete(int idUsuario, int id)
        {
            var model = new StatusViewModel();
            try
            {
                _servicoStatus.Excluir(_servicoStatus.ObterPorId(id), idUsuario);
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
