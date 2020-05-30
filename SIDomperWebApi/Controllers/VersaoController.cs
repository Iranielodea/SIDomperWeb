using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Linq;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class VersaoController : ApiController
    {
        private readonly VersaoServico _versaoServico;
        private readonly StatusServico _statusServico;

        public VersaoController()
        {
            _versaoServico = new VersaoServico();
            _statusServico = new StatusServico();
        }

        [HttpGet]
        public VersaoViewModel ObterPorId(int id)
        {
            var model = new VersaoViewModel();
            try
            {
                var item = _versaoServico.ObterPorId(id);
                model = item.Adapt<VersaoViewModel>();

                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpPost]
        public VersaoConsultaViewModel[] Filtrar([FromBody] VersaoFiltroViewModel filtro, bool contem)
        {
            try
            {
                return _versaoServico.Filtrar(filtro, filtro.Campo, filtro.Texto, contem).ToArray();

                //var FiltroVersao = filtro.Adapt<VersaoFiltro>();
                //var Lista = _versaoServico.Filtrar(FiltroVersao, filtro.Campo, filtro.Texto, contem);
                //var model = Lista.Adapt<VersaoConsultaViewModel[]>();
                //return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public VersaoViewModel Editar(int idUsuario, int id)
        {
            var model = new VersaoViewModel();
            try
            {
                string mensagem = "";
                var item = _versaoServico.Editar(idUsuario, id, ref mensagem);
                model = item.Adapt<VersaoViewModel>();

                //BuscarStatusDesenvolvedor(model);

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

        [HttpGet]
        public VersaoViewModel Novo(string novo, int idUsuario)
        {
            var model = new VersaoViewModel();
            try
            {
                var item = _versaoServico.Novo(idUsuario);
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

                BuscarStatusDesenvolvedor(model);

                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        private void BuscarStatusDesenvolvedor(VersaoViewModel model)
        {
            var parametro = _versaoServico.ObterStatusDesenvolvedor();
            if (parametro != null)
            {
                int codigo;
                int.TryParse(parametro.Valor, out codigo);

                var Status = _statusServico.ObterPorCodigo(codigo);

                if (Status != null)
                {
                    model.StatusIdParam = Status.Id;
                    model.StatusCodigoParam = Status.Codigo;
                    model.StatusNomeParam = Status.Nome;
                }
            }
        }

        [HttpPost]
        public VersaoViewModel Incluir(VersaoViewModel model)
        {
            var versaoViewModel = new VersaoViewModel();
            try
            {
                var versao = model.Adapt<Versao>();
                _versaoServico.Salvar(versao);
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
                _versaoServico.Salvar(versao);
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
        public VersaoViewModel Delete(int idUsuario, int id)
        {
            var model = new VersaoViewModel();
            try
            {
                _versaoServico.Excluir(idUsuario, id);
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
