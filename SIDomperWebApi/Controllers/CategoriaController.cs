using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class CategoriaController : ApiController
    {
        private readonly CategoriaServico _categoriaServico;

        public CategoriaController()
        {
            _categoriaServico = new CategoriaServico();
        }

        [HttpGet]
        public CategoriaViewModel ObterPorId(int id)
        {
            var model = new CategoriaViewModel();
            try
            {
                var item = _categoriaServico.ObterPorId(id);
                model = item.Adapt<CategoriaViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public CategoriaViewModel Editar(int idUsuario, int id)
        {
            var model = new CategoriaViewModel();
            try
            {
                string mensagem = "";
                var item = _categoriaServico.Editar(idUsuario, id, ref mensagem);
                model = item.Adapt<CategoriaViewModel>();
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
        public CategoriaViewModel Novo(string novo, int idUsuario)
        {
            var model = new CategoriaViewModel();
            try
            {
                var item = _categoriaServico.Novo(idUsuario);
                model = item.Adapt<CategoriaViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public CategoriaViewModel ObterPorCodigo(int codigo)
        {
            var model = new CategoriaViewModel();
            try
            {
                var prod = _categoriaServico.ObterPorCodigo(codigo);
                model = prod.Adapt<CategoriaViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public IEnumerable<CategoriaViewModel> Filtrar(string campo, string texto, string ativo = "A", bool contem = true, int idCliente = 0)
        {
            try
            {
                var lista = _categoriaServico.Filtrar(campo, texto, ativo, contem, idCliente);
                var model = lista.Adapt<CategoriaViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public CategoriaViewModel Incluir(CategoriaViewModel model)
        {
            var categoriaViewModel = new CategoriaViewModel();
            try
            {
                var categoria = model.Adapt<Categoria>();
                _categoriaServico.Salvar(categoria);
                categoriaViewModel = categoria.Adapt<CategoriaViewModel>();
                return categoriaViewModel;
            }
            catch (Exception ex)
            {
                categoriaViewModel.Mensagem = ex.Message;
                return categoriaViewModel;
            }
        }

        [HttpPut]
        public CategoriaViewModel Update(CategoriaViewModel model)
        {
            var CategoriaViewModel = new CategoriaViewModel();
            try
            {
                var Categoria = model.Adapt<Categoria>();
                _categoriaServico.Salvar(Categoria);
                CategoriaViewModel = Categoria.Adapt<CategoriaViewModel>();
                return CategoriaViewModel;
            }
            catch (Exception ex)
            {
                CategoriaViewModel.Mensagem = ex.Message;
                return CategoriaViewModel;
            }
        }

        [HttpDelete]
        public CategoriaViewModel Delete(int idUsuario, int id)
        {
            var model = new CategoriaViewModel();
            try
            {
                var categoria = _categoriaServico.ObterPorId(id);
                _categoriaServico.Excluir(idUsuario, categoria);
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
