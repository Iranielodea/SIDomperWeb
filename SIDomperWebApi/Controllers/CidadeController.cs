using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class CidadeController : ApiController
    {
        private readonly CidadeServico _cidadeServico;

        public CidadeController()
        {
            _cidadeServico = new CidadeServico();
        }

        [HttpGet]
        public CidadeViewModel ObterPorid(int id)
        {
            var model = new CidadeViewModel();
            try
            {
                var item = _cidadeServico.ObterPorId(id);
                model = item.Adapt<CidadeViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public CidadeViewModel Editar(int idUsuario, int id)
        {
            var model = new CidadeViewModel();
            try
            {
                string mensagem = "";
                var item = _cidadeServico.Editar(idUsuario, id, ref mensagem);
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

        [HttpGet]
        public CidadeViewModel Novo(string novo, int idUsuario)
        {
            var model = new CidadeViewModel();
            try
            {
                var item = _cidadeServico.Novo(idUsuario);
                model = item.Adapt<CidadeViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public CidadeViewModel ObterPorCodigo(int codigo)
        {
            var model = new CidadeViewModel();
            try
            {
                var prod = _cidadeServico.ObterPorCodigo(codigo);
                model = prod.Adapt<CidadeViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public IEnumerable<CidadeViewModel> Filtrar(string campo, string texto, bool ativo = true, bool contem = true)
        {
            try
            {
                var lista = _cidadeServico.Filtrar(campo, texto, ativo, contem);
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
                _cidadeServico.Salvar(cidade);
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
                _cidadeServico.Salvar(Cidade);
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
                _cidadeServico.Excluir(idUsuario, id);
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
