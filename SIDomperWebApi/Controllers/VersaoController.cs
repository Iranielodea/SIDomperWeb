using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;
using System;
using System.Linq;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    [RoutePrefix("api/versao")]
    public class VersaoController : ApiController
    {
        private readonly IServicoVersao _servicoVersao;

        public VersaoController(IServicoVersao servicoVersao)
        {
            _servicoVersao = servicoVersao;
        }

        [Route("ObterPorId")]
        [HttpGet]
        public VersaoViewModel ObterPorId(int id)
        {
            var model = new VersaoViewModel();
            try
            {
                var item = _servicoVersao.ObterPorId(id);
                model = item.Adapt<VersaoViewModel>();

                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("Filtrar")]
        [HttpPost]
        public VersaoConsultaViewModel[] Filtrar([FromBody] VersaoFiltroViewModel filtro, bool contem)
        {
            try
            {
                return _servicoVersao.Filtrar(filtro, filtro.Campo, filtro.Texto, contem).ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("Editar")]
        [HttpGet]
        public VersaoViewModel Editar(int id, int idUsuario)
        {
            var model = new VersaoViewModel();
            try
            {
                string mensagem = "";
                var item = _servicoVersao.Editar(id, idUsuario, ref mensagem);
                model = item.Adapt<VersaoViewModel>();

                model.CodUsuario = item.Usuario.Codigo;
                model.NomeUsuario = item.Usuario.Nome;

                model.CodTipo = item.Tipo.Codigo;
                model.NomeTipo = item.Tipo.Nome;

                model.CodStatus = item.Status.Codigo;
                model.NomeStatus = item.Status.Nome;

                if (item.Produto != null)
                {
                    model.CodProduto = item.Produto.Codigo;
                    model.NomeProduto = item.Produto.Nome;
                }

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
        public VersaoViewModel Novo(int idUsuario)
        {
            var model = new VersaoViewModel();
            try
            {
                var item = _servicoVersao.Novo(idUsuario);
                model = item.Adapt<VersaoViewModel>();

                if (item.Usuario != null)
                {
                    model.UsuarioId = item.Usuario.Id;
                    model.CodUsuario = item.Usuario.Codigo;
                    model.NomeUsuario = item.Usuario.Nome;
                }

                if (item.Tipo != null)
                {
                    model.CodTipo = item.Tipo.Codigo;
                    model.NomeTipo = item.Tipo.Nome;
                }

                var Status = _servicoVersao.ObterStatusDesenvolvedor();
                if (Status != null)
                {
                    model.StatusIdParam = Status.Id;
                    model.StatusCodigoParam = Status.Codigo;
                    model.StatusNomeParam = Status.Nome;
                }

                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpPost]
        public VersaoViewModel Incluir(VersaoViewModel model)
        {
            var versaoViewModel = new VersaoViewModel();
            try
            {
                var versao = model.Adapt<Versao>();
                _servicoVersao.Salvar(versao);
                versaoViewModel = versao.Adapt<VersaoViewModel>();
                return versaoViewModel;
            }
            catch (Exception ex)
            {
                versaoViewModel.Mensagem = ex.Message;
                return versaoViewModel;
            }
        }

        [HttpPut]
        public VersaoViewModel Update(VersaoViewModel model)
        {
            var versaoViewModel = new VersaoViewModel();
            try
            {
                var versao = model.Adapt<Versao>();
                _servicoVersao.Salvar(versao);
                versaoViewModel = versao.Adapt<VersaoViewModel>();
                return versaoViewModel;
            }
            catch (Exception ex)
            {
                versaoViewModel.Mensagem = ex.Message;
                return versaoViewModel;
            }
        }

        [HttpDelete]
        public VersaoViewModel Delete(int id, int idUsuario)
        {
            var model = new VersaoViewModel();
            try
            {
                _servicoVersao.Excluir(_servicoVersao.ObterPorId(id), idUsuario);
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
