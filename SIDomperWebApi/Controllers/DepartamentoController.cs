using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class DepartamentoController : ApiController
    {
        private readonly DepartamentoServico _departamentoServico;

        public DepartamentoController()
        {
            _departamentoServico = new DepartamentoServico();
        }

        [HttpGet]
        public DepartamentoViewModel ObterPorId(int id)
        {
            var model = new DepartamentoViewModel();
            try
            {
                var item = _departamentoServico.ObterPorId(id);
                model = item.Adapt<DepartamentoViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public DepartamentoViewModel Editar(int idUsuario, int id)
        {
            var model = new DepartamentoViewModel();
            try
            {
                string mensagem = "";
                var item = _departamentoServico.Editar(idUsuario, id, ref mensagem);
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

        [HttpGet]
        public DepartamentoViewModel Novo(string novo, int idUsuario)
        {
            var model = new DepartamentoViewModel();
            try
            {
                var item = _departamentoServico.Novo(idUsuario);
                model = item.Adapt<DepartamentoViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public DepartamentoViewModel ObterPorCodigo(int codigo)
        {
            var model = new DepartamentoViewModel();
            try
            {
                var prod = _departamentoServico.ObterPorCodigo(codigo);
                model = prod.Adapt<DepartamentoViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public IEnumerable<DepartamentoConsultaViewModel> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            try
            {
                var lista = _departamentoServico.Filtrar(campo, texto, ativo, contem);
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
                _departamentoServico.Salvar(departamento);

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
                _departamentoServico.Salvar(departamento);

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
        public DepartamentoViewModel Delete(int idUsuario, int id)
        {
            var model = new DepartamentoViewModel();
            try
            {
                var departamento = _departamentoServico.ObterPorId(id);
                _departamentoServico.Excluir(idUsuario, departamento);
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
