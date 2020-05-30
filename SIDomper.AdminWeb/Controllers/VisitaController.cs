using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using SIDomper.Dominio.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SIDomper.AdminWEB.Controllers
{
    public class VisitaController : AbstractLogadoController
    {
        VisitaViewModel _visitaViewModel;
        VisitaServico _servico;


        public VisitaController()
        {
            _visitaViewModel = new VisitaViewModel();
            _servico = new VisitaServico();
        }

        // GET: Visita
        public ActionResult Index()
        {
            if (!_servico.PermissaoAcesso(UsuarioId))
            {
                return RedirectToAction("Index", "Login");
            }

            PreencherCombo(_visitaViewModel);
            _visitaViewModel.Campo = "Cli_Nome";
            _visitaViewModel.Texto = "ABCDEF";
            _visitaViewModel.ListaConsulta = Filtrar(_visitaViewModel, _visitaViewModel.Filtro);
            _visitaViewModel.Texto = "";

            DateTime dataInicio = Servicos.Funcoes.FuncaoGeral.PrimeiroDiaMesCorrente();
            DateTime dataFinal = Servicos.Funcoes.FuncaoGeral.UltimoDiaMesCorrente();

            _visitaViewModel.Filtro.DataInicial = dataInicio.ToString("yyyy-MM-dd");
            _visitaViewModel.Filtro.DataFinal = dataFinal.ToString("yyyy-MM-dd");

            return View(_visitaViewModel);
        }

        public ActionResult Novo(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("index", "cliente");

            var StatusServico = new StatusServico();
            var TipoServico = new TipoServico();
            var ClienteServico = new ClienteServico();
            var UsuarioServico = new UsuarioServico();


            var cliente = ClienteServico.ObterPorId(id.Value);
            if (cliente == null)
                return RedirectToAction("index", "cliente");

            var model = new Visita();

            if (ModelState.IsValid)
            {
                try
                {
                    if (!_servico.PermissaoIncluir(UsuarioId))
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Usuário sem Permissão!");
                        //return RedirectToAction("Index", "Login");
                    }

                    if (!UsuarioServico.HorarioUsoSistema("","", UsuarioId))
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest, Mensagem.MensagemHorarioAcessoSistema);

                    model.Data = DateTime.Now.Date;
                    model.ClienteId = id.Value;
                    model.Cliente = cliente;
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
                    model.Versao = cliente.Versao;

                    var listaTipos = TipoServico.ListarVisitas("");
                    var tipo = new Tipo();
                    listaTipos.Insert(0, tipo);

                    model.ListaTipos = listaTipos;
                    model.ListaStatus = StatusServico.ListarVisitas("");
                    model.ListaUsuarios = UsuarioServico.Listar("");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            return View("alterar", model);
        }

        [HttpPost]
        public ActionResult Index(VisitaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.ListaConsulta = Filtrar(model, model.Filtro);
                    PreencherCombo(model);

                    return View(model);
                }
                catch (Exception ex)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return View(model);
        }

        private void PreencherCombo(VisitaViewModel model)
        {
            model.Campos.Add(new VisitaCamposPesquisaViewModel { Campo = "Vis_Data", Descricao = "Data" });
            model.Campos.Add(new VisitaCamposPesquisaViewModel { Campo = "Vis_Id", Descricao = "Id" });
            model.Campos.Add(new VisitaCamposPesquisaViewModel { Campo = "Vis_Dcto", Descricao = "Documento" });
            model.Campos.Add(new VisitaCamposPesquisaViewModel { Campo = "Cli_Nome", Descricao = "Cliente" });
            model.Campos.Add(new VisitaCamposPesquisaViewModel { Campo = "Cli_Fantasia", Descricao = "Fantasia" });
            model.Campos.Add(new VisitaCamposPesquisaViewModel { Campo = "Usu_Nome", Descricao = "Consultor" });
        }


        [HttpPost]
        public ActionResult Alterar(Visita model)
        {
            try
            {
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

            var model = _servico.ObterPorId(id);

            if (ModelState.IsValid)
            {
                try
                {
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
            try
            {
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
            catch(Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        private List<VisitaConsulta> Filtrar(VisitaViewModel model, VisitaFiltro filtro)
        {
            var lista = _servico.Filtrar(UsuarioId, filtro, model.Campo, model.Texto);
            return lista;
        }
    }
}