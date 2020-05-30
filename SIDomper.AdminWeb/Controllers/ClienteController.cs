﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;

namespace SIDomper.AdminWEB.Controllers
{
    public class ClienteController : AbstractLogadoController
    {
        ClienteViewModel _clientesVM;


        public ClienteController()
        {
            _clientesVM = new ClienteViewModel();
        }

        // GET: Cliente
        public ActionResult Index()
        {
            var ClienteServico = new ClienteServico();
            int idUsuario = UsuarioId;

            if (!ClienteServico.PermissaoAcesso(idUsuario))
            {
                return RedirectToAction("Sair", "Login");
            }

            //ViewBag.UsuarioId = new SelectList
            //    (
            //        new UsuarioServico().Listar(""),
            //        "Id",
            //        "Nome"
            //    );

            //ViewBag.RevendaId = new SelectList
            //    (
            //        new RevendaServico().Listar(""),
            //        "Id",
            //        "Nome"
            //    );

            //ViewBag.CidadeId = new SelectList
            //    (
            //        new CidadeServico().Listar(""),
            //        "Id",
            //        "Nome"
            //    );


            //ViewBag.ModuloId = new SelectList
            //   (
            //       new ModuloServico().Listar(""),
            //       "Id",
            //       "Nome"
            //   );

            //ViewBag.ProdutoId = new SelectList
            //   (
            //       new ProdutoServico().Listar(""),
            //       "Id",
            //       "Nome"
            //   );

            //PreencherCombo(_clientesVM);
            //_clientesVM.Campo = "Cli_Nome";
            //_clientesVM.Texto = "abcde";
            //_clientesVM.Id = 1;
            //_clientesVM.Texto = "";
            //var teste = Filtro(_clientesVM, _clientesVM.FiltroCliente).ToPagedList(pagina, 10);
            //_clientesVM.Clientes = teste.ToList();
            //return View(_clientesVM);

            PreencherCombo(_clientesVM);
            _clientesVM.Campo = "Cli_Nome";
            _clientesVM.Texto = "abcde";
            _clientesVM.Id = 1;
            _clientesVM.Clientes = Filtro(_clientesVM, _clientesVM.FiltroCliente);
            _clientesVM.Texto = "";

            return View(_clientesVM);
        }

        public ActionResult Editar(int id)
        {
            var servico = new ClienteServico();
            var model = servico.ObterPorId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ClienteViewModel model)
        {
            model.Clientes = Filtro(model, model.FiltroCliente);
            PreencherCombo(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(Cliente model)
        {
            try
            {
                model.Cidade = null;
                model.Revenda = null;
                model.Usuario = null;
                var servico = new ClienteServico();
                if (model != null)
                    servico.Salvar(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        private void PreencherCombo(ClienteViewModel model)
        {
            model.Campos.Add(new ClienteCamposPesquisaViewModel { Campo = "Cli_Id", Descricao = "Id" });
            model.Campos.Add(new ClienteCamposPesquisaViewModel { Campo = "Cli_Nome", Descricao = "Razão Social" });
            model.Campos.Add(new ClienteCamposPesquisaViewModel { Campo = "Cli_Fantasia", Descricao = "Nome Fantasia" });
            model.Campos.Add(new ClienteCamposPesquisaViewModel { Campo = "Cli_Dcto", Descricao = "Documento" });
            model.Campos.Add(new ClienteCamposPesquisaViewModel { Campo = "Cli_Fone1", Descricao = "Telefone" });
            model.Campos.Add(new ClienteCamposPesquisaViewModel { Campo = "Usu_Nome", Descricao = "Consultor" });
        }

        private List<ClienteConsulta> Filtro(ClienteViewModel model, ClienteFiltro filtrarCliente)
        {
            filtrarCliente.Ativo = "A";
            filtrarCliente.EmpresaVinculada = "T";
            filtrarCliente.Restricao = 2;

            var servico = new ClienteServico();
            var lista = servico.FiltrarWeb(UsuarioId, filtrarCliente, 2, model.Campo, model.Texto);

            return lista.ToList();
        }
    }
}