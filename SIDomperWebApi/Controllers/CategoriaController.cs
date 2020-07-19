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
    [RoutePrefix("api/categoria")]
    public class CategoriaController : ApiController
    {
        //private readonly CategoriaServico _categoriaServico;
        private readonly IServicoCategoria _servicoCategoria;

        public CategoriaController(IServicoCategoria servicoCategoria)
        {
            //_categoriaServico = new CategoriaServico();
            _servicoCategoria = servicoCategoria;
        }

        [Route("ObterPorId")]
        [HttpGet]
        public CategoriaViewModel ObterPorId(int id)
        {
            var model = new CategoriaViewModel();
            try
            {
                //var item = _categoriaServico.ObterPorId(id);
                var item = _servicoCategoria.ObterPorId(id);
                model = item.Adapt<CategoriaViewModel>();
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
        public CategoriaViewModel Editar(int id, int idUsuario)
        {
            var model = new CategoriaViewModel();
            try
            {
                string mensagem = "";
                //var item = _categoriaServico.Editar(idUsuario, id, ref mensagem);
                var item = _servicoCategoria.Editar(id, idUsuario, ref mensagem);
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

        [Route("Novo")]
        [HttpGet]
        public CategoriaViewModel Novo(int idUsuario)
        {
            var model = new CategoriaViewModel();
            try
            {
                //var item = _categoriaServico.Novo(idUsuario);
                var item = _servicoCategoria.Novo(idUsuario);
                model = item.Adapt<CategoriaViewModel>();
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
        public CategoriaViewModel ObterPorCodigo(int codigo)
        {
            var model = new CategoriaViewModel();
            try
            {
                //var prod = _categoriaServico.ObterPorCodigo(codigo);
                var categoria = _servicoCategoria.ObterPorCodigo(codigo);
                model = categoria.Adapt<CategoriaViewModel>();
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
        public IEnumerable<CategoriaViewModel> Filtrar(string campo, string texto, string ativo = "A", int idCliente = 0, bool contem = true)
        {
            try
            {
                //var lista = _categoriaServico.Filtrar(campo, texto, ativo, contem, idCliente);
                var lista = _servicoCategoria.Filtrar(campo, texto, ativo, contem, idCliente);
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
                //_categoriaServico.Salvar(categoria);
                _servicoCategoria.Salvar(categoria);
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
                //_categoriaServico.Salvar(Categoria);
                _servicoCategoria.Salvar(Categoria);
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
                //var categoria = _categoriaServico.ObterPorId(id);
                //_categoriaServico.Excluir(idUsuario, categoria);
                _servicoCategoria.Excluir(_servicoCategoria.ObterPorId(id), id);
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
