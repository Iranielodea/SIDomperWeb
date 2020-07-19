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
    [RoutePrefix("api/cidade")]
    public class CidadeController : ApiController
    {
        private readonly IServicoCidade _servicoCidade;
        private readonly CidadeServico _cidadeServico;

        public CidadeController(IServicoCidade servicoCidade)
        {
            _cidadeServico = new CidadeServico();
            _servicoCidade = servicoCidade;
        }

        [Route("ObterPorId")]
        [HttpGet]
        public CidadeViewModel ObterPorid(int id)
        {
            var model = new CidadeViewModel();
            try
            {
                var item = _servicoCidade.ObterPorId(id);
                //var item = _cidadeServico.ObterPorId(id);
                model = item.Adapt<CidadeViewModel>();
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
        public CidadeViewModel Editar(int id, int idUsuario)
        {
            var model = new CidadeViewModel();
            try
            {
                string mensagem = "";
                var item = _servicoCidade.Editar(id, idUsuario, ref mensagem);
                //var item = _cidadeServico.Editar(idUsuario, id, ref mensagem);
                model = item.Adapt<CidadeViewModel>();
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
        public CidadeViewModel Novo(int idUsuario)
        {
            var model = new CidadeViewModel();
            try
            {
                //var item = _cidadeServico.Novo(idUsuario);
                var item = _servicoCidade.Novo(idUsuario);
                model = item.Adapt<CidadeViewModel>();
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
        public CidadeViewModel ObterPorCodigo(int codigo)
        {
            var model = new CidadeViewModel();
            try
            {
                var prod = _servicoCidade.ObterPorCodigo(codigo);
                //var prod = _cidadeServico.ObterPorCodigo(codigo);
                model = prod.Adapt<CidadeViewModel>();
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
        public IEnumerable<CidadeViewModel> Filtrar(string campo, string texto, bool ativo = true, bool contem = true)
        {
            try
            {
                var lista = _servicoCidade.Filtrar(campo, texto, ativo, contem);
                //var lista = _cidadeServico.Filtrar(campo, texto, ativo, contem);
                var model = lista.Adapt<CidadeViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public CidadeViewModel Incluir(CidadeViewModel model)
        {
            var CidadeViewModel = new CidadeViewModel();
            try
            {
                var cidade = model.Adapt<Cidade>();
                _servicoCidade.Salvar(cidade);
                //_cidadeServico.Salvar(cidade);
                CidadeViewModel = cidade.Adapt<CidadeViewModel>();
                return CidadeViewModel;
            }
            catch (Exception ex)
            {
                CidadeViewModel.Mensagem = ex.Message;
                return CidadeViewModel;
            }
        }

        [HttpPut]
        public CidadeViewModel Update(CidadeViewModel model)
        {
            var CidadeViewModel = new CidadeViewModel();
            try
            {
                var Cidade = model.Adapt<Cidade>();
                _servicoCidade.Salvar(Cidade);
                //_cidadeServico.Salvar(Cidade);
                CidadeViewModel = Cidade.Adapt<CidadeViewModel>();
                return CidadeViewModel;
            }
            catch (Exception ex)
            {
                CidadeViewModel.Mensagem = ex.Message;
                return CidadeViewModel;
            }
        }

        //DELETE api/<controller>/5
        [HttpDelete]
        public CidadeViewModel Delete(int idUsuario, int id)
        {
            var model = new CidadeViewModel();
            try
            {
                //_cidadeServico.Excluir(idUsuario, id);
                _servicoCidade.Excluir(_servicoCidade.ObterPorId(id), idUsuario);
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
