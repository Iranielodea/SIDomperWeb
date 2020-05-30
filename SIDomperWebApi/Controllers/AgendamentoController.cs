using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    [RoutePrefix("api/agendamento")]
    public class AgendamentoController : ApiController
    {
        private readonly AgendamentoServico _agendamentoServico;

        public AgendamentoController()
        {
            _agendamentoServico = new AgendamentoServico();
        }

        [HttpGet]
        public AgendamentoViewModel ObterPorId(int id)
        {
            var model = new AgendamentoViewModel();
            try
            {
                var item = _agendamentoServico.ObterPorId(id);
                model = item.Adapt<AgendamentoViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        private void PopularDados(Agendamento model, AgendamentoViewModel viewModel)
        {
            if (model.Cliente == null)
                model.Cliente = new Cliente();

            viewModel.ClienteId = model.Cliente.Id;
            viewModel.CodigoCliente = model.Cliente.Codigo;
            viewModel.NomeCliente = model.Cliente.Nome;

            viewModel.UsuarioId = model.Usuario.Id;
            viewModel.CodigoUsuario = model.Usuario.Codigo;
            viewModel.NomeUsuario = model.Usuario.Nome;

            viewModel.TipoId = model.Tipo.Id;
            viewModel.CodigoTipo = model.Tipo.Codigo;
            viewModel.NomeTipo = model.Tipo.Nome;

            viewModel.StatusId = model.Status.Id;
            viewModel.CodigoStatus = model.Status.Codigo;
            viewModel.NomeStatus = model.Status.Nome;
        }

        [Route("Editar")]
        [HttpGet]
        public AgendamentoViewModel Editar(int idUsuario, int id)
        {
            var model = new AgendamentoViewModel();
            try
            {
                string mensagem = "";
                var item = _agendamentoServico.Editar(idUsuario, id, ref mensagem);
                model = item.Adapt<AgendamentoViewModel>();

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

        [Route("Novo")]
        [HttpGet]
        public AgendamentoViewModel Novo(int idUsuario)
        {
            var model = new AgendamentoViewModel();
            try
            {
                var item = _agendamentoServico.Novo(idUsuario);
                model = item.Adapt<AgendamentoViewModel>();

                PopularDados(item, model);

                return model;
            }
            catch (Exception ex) 
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpPost]
        public IEnumerable<AgendamentoConsultaViewModel> Filtrar([FromBody]AgendamentoFiltroViewModel filtro, string campo, string texto, int idUsuario, bool contem = true)
        {
            try
            {
                return _agendamentoServico.Filtrar(filtro, campo, texto, idUsuario, contem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("Incluir")]
        [HttpPost]
        public AgendamentoViewModel Incluir([FromBody]AgendamentoViewModel model, int usuarioId)
        {
            var agendamentoViewModel = new AgendamentoViewModel();
            try
            {
                var agendamento = model.Adapt<Agendamento>();
                _agendamentoServico.Salvar(agendamento, usuarioId);
                agendamentoViewModel = agendamento.Adapt<AgendamentoViewModel>();
                return agendamentoViewModel;
            }
            catch (Exception ex)
            {
                agendamentoViewModel.Mensagem = ex.Message;
                return agendamentoViewModel;
            }
        }

        [Route("Alterar")]
        [HttpPut]
        public AgendamentoViewModel Update([FromBody]AgendamentoViewModel model, int usuarioId)
        {
            var agendamentoViewModel = new AgendamentoViewModel();
            try
            {
                var agendamento = model.Adapt<Agendamento>();
                _agendamentoServico.Salvar(agendamento, usuarioId);
                agendamentoViewModel = agendamento.Adapt<AgendamentoViewModel>();
                return agendamentoViewModel;
            }
            catch (Exception ex)
            {
                agendamentoViewModel.Mensagem = ex.Message;
                return agendamentoViewModel;
            }
        }

        [HttpDelete]
        public AgendamentoViewModel Delete(int idUsuario, int id)
        {
            var model = new AgendamentoViewModel();
            try
            {
                _agendamentoServico.Excluir(idUsuario, id);
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("Reagendamento")]
        [HttpPost]
        public AgendamentoViewModel Reagendamento(int idUsuario, int idAgendamento, string data, string hora, string texto)
        {
            var model = new AgendamentoViewModel();
            try
            {
                _agendamentoServico.Reagendamento(idUsuario, idAgendamento, data, hora, texto);
                model.Mensagem = "OK";
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("Cancelamento")]
        [HttpPost]
        public AgendamentoViewModel Cancelamento(int idUsuario, int idAgendamento, string data, string hora, string texto)
        {
            var model = new AgendamentoViewModel();
            try
            {
                _agendamentoServico.Cancelamento(idUsuario, idAgendamento, data, hora, texto);
                model.Mensagem = "OK";
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("Encerramento")]
        [HttpPost]
        public AgendamentoViewModel Encerramento(int idUsuario, int idAgenda, int idPrograma)
        {
            var model = new AgendamentoViewModel();
            try
            {
                _agendamentoServico.Encerramento(idUsuario, idAgenda, idPrograma);
                model.Mensagem = "OK";
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("Encerramentoweb")]
        [HttpPost]
        public AgendamentoViewModel EncerramentoWeb(int idUsuario, int idAgenda)
        {
            var model = new AgendamentoViewModel();
            try
            {
                _agendamentoServico.EncerramentoWEB(idUsuario, idAgenda);
                model.Mensagem = "OK";
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("Quadro")]
        [HttpGet]
        public IEnumerable<AgendamentoQuadroViewModel> Quadro(string dataInicial, string dataFinal, int idUsuario, int idRevenda)
        {
            try
            {
                var lista = _agendamentoServico.Quadros(dataInicial, dataFinal, idUsuario, idRevenda);
                //var model = lista.Adapt<AgendamentoQuadroViewModel[]>();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}