using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIDomper.AdminWEB.Controllers
{
    public class HomeController : AbstractLogadoController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Versão 1.0";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Lista(string term)
        {
            var servico = new ClienteServico();
            var clientes = servico.Listar(1, term);

            var result = new
            {
                results = clientes.Select(x => new
                {
                    id = x.Id.ToString(),
                    text = x.Nome
                })
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}