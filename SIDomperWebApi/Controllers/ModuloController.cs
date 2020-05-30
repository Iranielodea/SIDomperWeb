using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class ModuloController : ApiController
    {
        private readonly ModuloServico _moduloServico;

        public ModuloController()
        {
            _moduloServico = new ModuloServico();
        }

        [HttpGet]
        public ModuloViewModel ObterPorId(int id)
        {
            var model = new ModuloViewModel();
            try
            {
                var item = _moduloServico.ObterPorId(id);
                model = item.Adapt<ModuloViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public ModuloViewModel Editar(int idUsuario, int id)
        {
            var model = new ModuloViewModel();
            try
            {
                string mensagem = "";
                var item = _moduloServico.Editar(idUsuario, id, ref mensagem);
                model = item.Adapt<ModuloViewModel>();
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
        public ModuloViewModel Novo(string novo, int idUsuario)
        {
            var model = new ModuloViewModel();
            try
            {
                var item = _moduloServico.Novo(idUsuario);
                model = item.Adapt<ModuloViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public ModuloViewModel ObterPorCodigo(int codigo)
        {
            var model = new ModuloViewModel();
            try
            {
                var prod = _moduloServico.ObterPorCodigo(codigo);
                model = prod.Adapt<ModuloViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public IEnumerable<ModuloViewModel> Filtrar(string campo, string texto, string ativo = "A", bool contem = true, int idCliente = 0)
        {
            try
            {
                var lista = _moduloServico.Filtrar(campo, texto, ativo, contem, idCliente);
                var model = lista.Adapt<ModuloViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ModuloViewModel Incluir(ModuloViewModel model)
        {
            var moduloViewModel = new ModuloViewModel();
            try
            {
                var modulo = model.Adapt<Modulo>();
                _moduloServico.Salvar(modulo);
                moduloViewModel = modulo.Adapt<ModuloViewModel>();
                return moduloViewModel;
            }
            catch (Exception ex)
            {
                moduloViewModel.Mensagem = ex.Message;
                return moduloViewModel;
            }
        }

        [HttpPut]
        public ModuloViewModel Update(ModuloViewModel model)
        {
            var ModuloViewModel = new ModuloViewModel();
            try
            {
                var Modulo = model.Adapt<Modulo>();
                _moduloServico.Salvar(Modulo);
                ModuloViewModel = Modulo.Adapt<ModuloViewModel>();
                return ModuloViewModel;
            }
            catch (Exception ex)
            {
                ModuloViewModel.Mensagem = ex.Message;
                return ModuloViewModel;
            }
        }

        [HttpDelete]
        public ModuloViewModel Delete(int idUsuario, int id)
        {
            var model = new ModuloViewModel();
            try
            {
                var modulo = _moduloServico.ObterPorId(id);
                _moduloServico.Excluir(idUsuario, modulo);
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
