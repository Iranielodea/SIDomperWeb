using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class StatusController : ApiController
    {
        private readonly StatusServico _statusServico;

        public StatusController()
        {
            _statusServico = new StatusServico();
        }

        [HttpGet]
        public StatusViewModel ObterPorId(int id)
        {
            var model = new StatusViewModel();
            try
            {
                var item = _statusServico.ObterPorId(id);
                model = item.Adapt<StatusViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public StatusViewModel Editar(int idUsuario, int id)
        {
            var model = new StatusViewModel();
            try
            {
                string mensagem = "";
                var item = _statusServico.Editar(idUsuario, id, ref mensagem);
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

        [HttpGet]
        public StatusViewModel Novo(string novo, int idUsuario)
        {
            var model = new StatusViewModel();
            try
            {
                var item = _statusServico.Novo(idUsuario);
                model = item.Adapt<StatusViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public StatusViewModel ObterPorCodigo(int codigo, EnStatus enStatus)
        {
            var model = new StatusViewModel();
            try
            {
                var prod = _statusServico.ObterPorCodigo(codigo, enStatus);
                model = prod.Adapt<StatusViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public IEnumerable<StatusConsultaViewModel> Filtrar(string campo, string texto, EnStatus enStatus, string ativo = "A", bool contem = true)
        {
            try
            {
                var lista = _statusServico.Filtrar(campo, texto, enStatus, ativo, contem);
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
                _statusServico.Salvar(status);
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
                _statusServico.Salvar(status);
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
                var status = _statusServico.ObterPorId(id);
                _statusServico.Excluir(status, idUsuario);
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
