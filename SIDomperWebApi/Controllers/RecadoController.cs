using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Linq;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    [RoutePrefix("api/recado")]
    public class RecadoController : ApiController
    {
        private RecadoServico _servico;
        private RecadoViewModel _viewModel;

        public RecadoController()
        {
            _servico = new RecadoServico();
            _viewModel = new RecadoViewModel();
        }

        [Route("Novo")]
        [HttpGet]
        public RecadoViewModel Novo(int idUsuario)
        {
            try
            {
                var model = _servico.Novo(idUsuario);
                _viewModel = model.Adapt<RecadoViewModel>();

                _viewModel.StatusId = model.Status.Id;
                _viewModel.CodigoStatus = model.Status.Codigo;
                _viewModel.NomeStatus = model.Status.Nome;

                _viewModel.TipoId= model.Tipo.Id;
                _viewModel.CodigoTipo = model.Tipo.Codigo;
                _viewModel.NomeTipo = model.Tipo.Nome;

                _viewModel.UsuarioLctoId = model.UsuarioLcto.Id;
                _viewModel.CodigoUsuarioLcto = model.UsuarioLcto.Codigo;
                _viewModel.NomeUsuarioLancamento = model.UsuarioLcto.Nome;
                
                return _viewModel;
            }
            catch(Exception ex)
            {
                _viewModel.Mensagem = ex.Message;
                return _viewModel;
            }
        }

        [Route("Filtrar")]
        [HttpPost]
        public RecadoConsultaViewModel[] Filtrar([FromBody] RecadoFiltroViewModel filtro)
        {
            try
            {
                return _servico.Filtrar(filtro).ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("Editar")]
        [HttpGet]
        public RecadoViewModel Editar(int idUsuario, int id)
        {
            try
            {
                string mensagem = "";
                var model = _servico.Editar(idUsuario, id, ref mensagem);
                _viewModel = model.Adapt<RecadoViewModel>();

                _viewModel.CodigoStatus = model.Status.Codigo;
                _viewModel.NomeStatus = model.Status.Nome;

                _viewModel.CodigoTipo = model.Tipo.Codigo;
                _viewModel.NomeTipo = model.Tipo.Nome;

                _viewModel.CodigoUsuarioLcto = model.UsuarioLcto.Codigo;
                _viewModel.NomeUsuarioLancamento = model.UsuarioLcto.Nome;

                _viewModel.CodigoUsuarioDest = model.UsuarioDestino.Codigo;
                _viewModel.NomeUsuarioDestino = model.UsuarioDestino.Nome;

                _viewModel.CodigoCliente = model.Cliente.Codigo;
                _viewModel.RazaoSocial = model.RazaoSocial;
                _viewModel.NomeCliente = model.Cliente.Nome;

                _viewModel.Mensagem = mensagem;
                return _viewModel;
            }
            catch (Exception ex)
            {
                _viewModel.Mensagem = ex.Message;
                return _viewModel;
            }
        }

        [HttpPost]
        public RecadoViewModel Incluir([FromBody]RecadoViewModel model)
        {
            try
            {
                var recado = model.Adapt<Recado>();
                _servico.Salvar(recado);
                _viewModel = recado.Adapt<RecadoViewModel>();
                return _viewModel;
            }
            catch (Exception ex)
            {
                _viewModel.Mensagem = ex.Message;
                return _viewModel;
            }
        }

        [HttpPut]
        public RecadoViewModel Update([FromBody]RecadoViewModel model)
        {
            try
            {
                var recado = model.Adapt<Recado>();
                _servico.Salvar(recado);
                _viewModel = recado.Adapt<RecadoViewModel>();
                return _viewModel;
            }
            catch (Exception ex)
            {
                _viewModel.Mensagem = ex.Message;
                return _viewModel;
            }
        }

        [Route("Excluir")]
        [HttpDelete]
        public RecadoViewModel Delete(int idUsuario, int id)
        {
            try
            {
                var model = _servico.ObterPorId(id);
                _servico.Excluir(idUsuario, model);
                return _viewModel;
            }
            catch (Exception ex)
            {
                _viewModel.Mensagem = ex.Message;
                return _viewModel;
            }
        }
    }
}
