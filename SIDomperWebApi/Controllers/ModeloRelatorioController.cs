using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class ModeloRelatorioController : ApiController
    {
        private readonly ModeloRelatorioServico _modeloRelatorioServico;

        public ModeloRelatorioController()
        {
            _modeloRelatorioServico = new ModeloRelatorioServico();
        }

        [HttpGet]
        public ModeloRelatorioViewModel ObterPorId(int id)
        {
            var model = new ModeloRelatorioViewModel();
            try
            {
                var item = _modeloRelatorioServico.ObterPorId(id);
                model = item.Adapt<ModeloRelatorioViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public ModeloRelatorioViewModel Editar(int idUsuario, int id)
        {
            var model = new ModeloRelatorioViewModel();
            try
            {
                var item = _modeloRelatorioServico.Editar(idUsuario, id);
                model = item.Adapt<ModeloRelatorioViewModel>();
                model.CodigoRevenda = item.Revenda.Codigo;
                model.NomeRevenda = item.Revenda.Nome;
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public ModeloRelatorioViewModel Novo(string novo, int idUsuario)
        {
            var model = new ModeloRelatorioViewModel();
            try
            {
                var item = _modeloRelatorioServico.Novo(idUsuario);
                model = item.Adapt<ModeloRelatorioViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public ModeloRelatorioViewModel ObterPorCodigo(int codigo)
        {
            var model = new ModeloRelatorioViewModel();
            try
            {
                var prod = _modeloRelatorioServico.ObterPorCodigo(codigo);
                model = prod.Adapt<ModeloRelatorioViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public IEnumerable<ModeloRelatorioConsultaViewModel> Filtrar(string campo, string texto, bool contem = true)
        {
            try
            {
                var lista = _modeloRelatorioServico.Filtrar(campo, texto, contem);
                var model = lista.Adapt<ModeloRelatorioConsultaViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ModeloRelatorioViewModel Incluir(ModeloRelatorioViewModel model)
        {
            var modeloRelatorioViewModel = new ModeloRelatorioViewModel();
            try
            {
                var modeloRelatorio = model.Adapt<ModeloRelatorio>();
                _modeloRelatorioServico.Salvar(modeloRelatorio);
                modeloRelatorioViewModel = modeloRelatorio.Adapt<ModeloRelatorioViewModel>();
                return modeloRelatorioViewModel;
            }
            catch (Exception ex)
            {
                modeloRelatorioViewModel.Mensagem = ex.Message;
                return modeloRelatorioViewModel;
            }
        }

        [HttpPut]
        public ModeloRelatorioViewModel Update(ModeloRelatorioViewModel model)
        {
            var modeloRelatorioViewModel = new ModeloRelatorioViewModel();
            try
            {
                var modeloRelatorio = model.Adapt<ModeloRelatorio>();
                _modeloRelatorioServico.Salvar(modeloRelatorio);
                modeloRelatorioViewModel = modeloRelatorio.Adapt<ModeloRelatorioViewModel>();
                return modeloRelatorioViewModel;
            }
            catch (Exception ex)
            {
                modeloRelatorioViewModel.Mensagem = ex.Message;
                return modeloRelatorioViewModel;
            }
        }

        [HttpDelete]
        public ModeloRelatorioViewModel Delete(int idUsuario, int id)
        {
            var model = new ModeloRelatorioViewModel();
            try
            {
                _modeloRelatorioServico.Excluir(idUsuario, id);
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