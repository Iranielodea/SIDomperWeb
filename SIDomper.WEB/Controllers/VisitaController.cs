using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SIDomper.WEB.Controllers
{
    public class VisitaController : AbstractLogadoController
    {
        VisitaViewModel _visitaVM;
        VisitaServico _servico;


        public VisitaController()
        {
            _visitaVM = new VisitaViewModel();
            _servico = new VisitaServico();
        }

        // GET: Visita
        public ActionResult Index()
        {
            //var VisitaServico = new VisitaServico();

            if (!_servico.PermissaoAcesso(UsuarioId))
            {
                return RedirectToAction("Index", "Login");
            }

            _visitaVM.Filtro.Id = 99999;
            _visitaVM.ListaConsulta = Filtrar(_visitaVM.Filtro);

            return View(_visitaVM);
        }

        public ActionResult Novo()
        {
            var StatusServico = new StatusServico();
            var TipoServico = new TipoServico();
            var ClienteServico = new ClienteServico();
            var UsuarioServico = new UsuarioServico();

            var model = new Visita();

            if (ModelState.IsValid)
            {
                try
                {
                    if (!_servico.PermissaoEditar(UsuarioId))
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Usuário sem Permissão!");
                        //return RedirectToAction("Index", "Login");
                    }

                    model = _servico.ObterPorId(1);
                    model.Data = DateTime.Now.Date;
                    model.ClienteId = 1;
                    model.StatusId = 1;
                    model.TipoId = 1;
                    model.UsuarioId = UsuarioId;
                    model.Anexo = "";
                    model.Contato = "";
                    model.Dcto = "";
                    model.Descricao = "";
                    model.FormaPagto = "";
                    model.HoraFim = TimeSpan.Zero;
                    model.HoraInicio = TimeSpan.Zero;
                    model.Id = 0;
                    model.TotalHoras = 0;
                    model.Valor = 0;
                    model.Versao = "";

                    model.ListaTipos = TipoServico.ListarVisitas("");
                    model.ListaStatus = StatusServico.ListarVisitas("");
                    model.ListaClientes = ClienteServico.Listar(model.UsuarioId, "");
                    model.ListaUsuarios = UsuarioServico.Listar("");

                    return View(model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    ViewBag.Alerta = "Usuário sem permissão";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Index(VisitaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var Servico = new VisitaServico();

                    //if (model.Visita != null)
                    //    Servico.Salvar(model.Visita);

                    model.ListaConsulta = Filtrar(model.Filtro);
                    return View(model);
                }
                catch (Exception ex)
                {
                    //ModelState.AddModelError("", ex.Message);
                    //return RedirectToAction("index");
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Visita model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var Servico = new VisitaServico();

                    if (model != null)
                        _servico.Salvar(model, UsuarioId);

                    //model.ListaConsulta = Filtrar(model.Filtro);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //ModelState.AddModelError("", ex.Message);
                    //return RedirectToAction("index");
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return View(model);
        }

        public ActionResult Editar(int id)
        {
            //var Servico = new VisitaServico();
            var model = new Visita();
            model = _servico.ObterPorId(id);

            if (model == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    if (!_servico.PermissaoEditar(UsuarioId))
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    return View(model);
                }
                catch (Exception ex)
                {
                    //ModelState.AddModelError("", ex.Message);
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
                    //ViewBag.Alerta = "Usuário sem permissão";
                    //return View(model);
                }
            }
            else
                return View(model);
        }

        [HttpPost]
        public ActionResult Alterar(Visita model)
        {
            try
            {
                //var Servico = new VisitaServico();

                if (model != null)
                    _servico.Salvar(model, UsuarioId);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
                //ModelState.AddModelError("", ex.Message);
            }
            //return RedirectToAction("index");
        }

        public ActionResult Alterar(int id)
        {
            var StatusServico = new StatusServico();
            var TipoServico = new TipoServico();
            var ClienteServico = new ClienteServico();
            var UsuarioServico = new UsuarioServico();

            //var Servico = new VisitaServico();
            var model = _servico.ObterPorId(id);

            if (ModelState.IsValid)
            {
                try
                {
                    //int idUsuario = 0;

                    if (!_servico.PermissaoEditar(UsuarioId))
                    {
                        return RedirectToAction("Index", "Login");
                    }

                    model.ListaTipos = TipoServico.ListarVisitas("");
                    model.ListaStatus = StatusServico.ListarVisitas("");
                    model.ListaClientes = ClienteServico.Listar(UsuarioId, "");
                    model.ListaUsuarios = UsuarioServico.Listar("");

                    return View(model);
                }
                catch (Exception ex)
                {
                    //ModelState.AddModelError("", ex.Message);
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
                    //ViewBag.Alerta = "Usuário sem permissão";
                    //return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Excluir(int id)
        {
            //var Servico = new VisitaServico();

            if (!_servico.PermissaoExcluir(UsuarioId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Usuário sem Permissão");
            }
            else
            {
                _servico.Excluir(id);
            }
            return RedirectToAction("index");
        }

        private List<VisitaConsulta> Filtrar(VisitaFiltro filtro)
        {
            filtro.ClienteId = 0;
            filtro.ClienteId = 0;
            filtro.RevendaId = 0;
            filtro.StatusId = 0;
            filtro.TipoId = 0;
            filtro.UsuarioId = 0;

            //var servico = new VisitaServico();
            var lista = _servico.Filtrar(UsuarioId, filtro);
            return lista;
        }
    }
}