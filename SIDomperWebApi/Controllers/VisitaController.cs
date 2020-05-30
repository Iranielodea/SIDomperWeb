using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Linq;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class VisitaController : ApiController
    {
        private readonly VisitaServico _visitaServico;

        public VisitaController()
        {
            _visitaServico = new VisitaServico();
        }

        [HttpGet]
        public VisitaViewModelApi ObterPorId(int id)
        {
            var model = new VisitaViewModelApi();
            try
            {
                var item = _visitaServico.ObterPorId(id);
                model = item.Adapt<VisitaViewModelApi>();

                PopularDados(model, item);

                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public VisitaViewModelApi Novo(string novo, int idUsuario, int idClienteAgendamento, int idAgendamento)
        {
            var model = new VisitaViewModelApi();
            try
            {
                var item = _visitaServico.Novo(idUsuario, idClienteAgendamento);
                model = item.Adapt<VisitaViewModelApi>();

                if (item.Usuario != null)
                {
                    model.UsuarioId = item.Usuario.Id;
                    model.CodUsuario = item.Usuario.Codigo;
                    model.NomeUsuario = item.Usuario.Nome;
                }

                if (item.Status != null)
                {
                    model.StatusId = item.Status.Id;
                    model.CodStatus = item.Status.Codigo;
                    model.NomeStatus = item.Status.Nome;
                }

                if (item.Cliente != null)
                {
                    model.ClienteId = item.Cliente.Id;
                    model.CodCliente = item.Cliente.Codigo;
                    model.NomeCliente = item.Cliente.Nome;
                }

                BuscarAgendamento(idAgendamento, model);

                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        private void BuscarAgendamento(int idAgendamento, VisitaViewModelApi model)
        {
            if (idAgendamento > 0)
            {
                var AgendamentoServico = new AgendamentoServico();
                var agendamento = AgendamentoServico.ObterPorId(idAgendamento);
                if (agendamento != null)
                {
                    model.Data = agendamento.Data;
                    model.Descricao = agendamento.Descricao;

                    //model.DataAgendamento = agendamento.Data;
                    //model.DescricaoAgendamento = agendamento.Descricao;
                }
            }
        }

        /*
         Salvar

        Se encerraAgendamento
            idCadastro = Vis_Id
         ========================================
        OnCreate
        construtor (boolean Pesquisar = false, boolean Quadro = false, boolean encerrarAgendamento = false, int idCliente=0, int idAgenda=0)
        construtor (int id, boolean editar=false)

        ========================================
        No OnShow
        Se vem do Quadro
            clicar no botao novo
        ========================================
        Nas Descricoes abrir tela de Observacoes tipo Visita
          
         */
        [HttpGet]
        public VisitaViewModelApi Editar(int idUsuario, int id)
        {
            var model = new VisitaViewModelApi();
            try
            {
                string mensagem = "";
                var item = _visitaServico.Editar(idUsuario, id, ref mensagem);
                model = item.Adapt<VisitaViewModelApi>();

                PopularDados(model, item);

                model.Mensagem = mensagem;
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        private void PopularDados(VisitaViewModelApi model, Visita item)
        {
            model.CodUsuario = item.Usuario.Codigo;
            model.NomeUsuario = item.Usuario.Nome;

            model.CodTipo = item.Tipo.Codigo;
            model.NomeTipo = item.Tipo.Nome;

            model.CodStatus = item.Status.Codigo;
            model.NomeStatus = item.Status.Nome;

            model.CodCliente = item.Cliente.Codigo;
            model.NomeCliente = item.Cliente.Nome;
        }

        [HttpPost]
        public VisitaConsultaViewModelApi[] Filtrar([FromBody] VisitaFiltroViewModelApi filtro, int idUsuario, string campo, string valor)
        {
            try
            {
                return _visitaServico.FiltrarAPI(idUsuario, filtro, campo, valor).ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public VisitaViewModelApi Incluir(VisitaViewModelApi model, int idUsuario)
        {
            var visitaViewModel = new VisitaViewModelApi();
            try
            {
                var visita = model.Adapt<Visita>();
                _visitaServico.Salvar(visita, idUsuario);
                visitaViewModel = visita.Adapt<VisitaViewModelApi>();
                return visitaViewModel;
            }
            catch (Exception ex)
            {
                visitaViewModel.Mensagem = ex.Message;
                return visitaViewModel;
            }
        }

        [HttpPut]
        public VisitaViewModelApi Update(VisitaViewModelApi model, int idUsuario)
        {
            var visitaViewModel = new VisitaViewModelApi();
            try
            {
                var visita = model.Adapt<Visita>();
                _visitaServico.Salvar(visita, idUsuario);
                visitaViewModel = visita.Adapt<VisitaViewModelApi>();
                return visitaViewModel;
            }
            catch (Exception ex)
            {
                visitaViewModel.Mensagem = ex.Message;
                return visitaViewModel;
            }
        }

        [HttpDelete]
        public VisitaViewModelApi Delete(int idUsuario, int id)
        {
            var model = new VisitaViewModelApi();
            try
            {
                _visitaServico.Excluir(idUsuario, id);
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpPost]
        public VisitaViewModelApi EnviarEmail([FromBody] VisitaViewModelApi model, int idUsuario, string email)
        {
            var visitaViewModel = new VisitaViewModelApi();
            try
            {
                var visita = model.Adapt<Visita>();
                visita = _visitaServico.ObterPorId(model.Id);

                _visitaServico.EnviarEmailVisita(visita, idUsuario);
                visitaViewModel = visita.Adapt<VisitaViewModelApi>();
                return visitaViewModel;
            }
            catch (Exception ex)
            {
                visitaViewModel.Mensagem = ex.Message;
                return visitaViewModel;
            }
        }
    }
}
