using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.Servicos;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    [RoutePrefix("api/departamento")]
    public class DepartamentoController : ApiController
    {
        //private readonly DepartamentoServico _departamentoServico;
        //private readonly ServicoDepartamento _servicoDepartamento;
        private readonly IServicoDepartamento _servicoDepartamento;

        public DepartamentoController(IServicoDepartamento servicoDepartamento)
        {
            //_departamentoServico = new DepartamentoServico();
            _servicoDepartamento = servicoDepartamento;
        }

        [Route("ObterPorId")]
        [HttpGet]
        public DepartamentoViewModel ObterPorId(int id)
        {
            var model = new DepartamentoViewModel();
            try
            {
                var item = _servicoDepartamento.ObterPorId(id);
                model = item.Adapt<DepartamentoViewModel>();
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
        public DepartamentoViewModel Editar(int id, int idUsuario)
        {
            var model = new DepartamentoViewModel();
            try
            {
                string mensagem = "";
                var item = _servicoDepartamento.Editar(id, idUsuario, ref mensagem);
                model = item.Adapt<DepartamentoViewModel>();

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
        public DepartamentoViewModel Novo(int idUsuario)
        {
            var model = new DepartamentoViewModel();
            try
            {
                var item = _servicoDepartamento.Novo(idUsuario);
                model = item.Adapt<DepartamentoViewModel>();
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
        public DepartamentoViewModel ObterPorCodigo(int codigo)
        {
            var model = new DepartamentoViewModel();
            try
            {
                var prod = _servicoDepartamento.ObterPorCodigo(codigo);
                model = prod.Adapt<DepartamentoViewModel>();
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
        public IEnumerable<DepartamentoConsultaViewModel> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            try
            {
                var lista = _servicoDepartamento.Filtrar(campo, texto, ativo, contem);
                    var model = lista.Adapt<DepartamentoConsultaViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public DepartamentoViewModel Incluir(DepartamentoViewModel model)
        {

            var departamentoViewModel = new DepartamentoViewModel();
            try
            {
                var departamento = model.Adapt<Departamento>();
                _servicoDepartamento.Salvar(departamento);

                departamentoViewModel = departamento.Adapt<DepartamentoViewModel>();
                return departamentoViewModel;
            }
            catch (Exception ex)
            {
                departamentoViewModel.Mensagem = ex.Message;
                return departamentoViewModel;
            }
        }

        [HttpPut]
        public DepartamentoViewModel Update(DepartamentoViewModel model)
        {
            var departamentoViewModel = new DepartamentoViewModel();
            try
            {
                var departamento = model.Adapt<Departamento>();
                _servicoDepartamento.Salvar(departamento);

                departamentoViewModel = departamento.Adapt<DepartamentoViewModel>();
                return departamentoViewModel;
            }
            catch (Exception ex)
            {
                departamentoViewModel.Mensagem = ex.Message;
                return departamentoViewModel;
            }
        }

        //DELETE api/<controller>/5
        [HttpDelete]
        public DepartamentoViewModel Delete(int id, int idUsuario)
        {
            var model = new DepartamentoViewModel();
            try
            {
                _servicoDepartamento.Excluir(_servicoDepartamento.ObterPorId(id), idUsuario);
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
