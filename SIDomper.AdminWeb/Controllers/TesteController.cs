using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIDomper.AdminWeb.Controllers
{
    public class TesteController : Controller
    {
        // GET: Teste
        public ActionResult Index()
        {
            OrcamentoSession orcamento = (Session["orcamento"] as OrcamentoSession);
            if (orcamento != null)
            {
                ViewBag.campo1 = orcamento.Campo1;
                ViewBag.campo2 = orcamento.Campo2;
                if (orcamento.Subcampos != null)
                {
                    ViewBag.campo3 = string.Join(" , ", orcamento.Subcampos.Select(x => x.Subcampo1));
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult IndexEnviar(string campo1, string campo2)
        {
            OrcamentoSession orcamento = (Session["orcamento"] as OrcamentoSession);
            if (orcamento == null)
            {
                orcamento = new OrcamentoSession();
                orcamento.Subcampos = new[] {
                    new OrcamentoItemSession { Subcampo1 = "a" },
                    new OrcamentoItemSession { Subcampo1 = "b" }
                };
            }
            orcamento.Campo1 = campo1;
            orcamento.Campo2 = campo2;

            Session["orcamento"] = orcamento;

            if (string.IsNullOrEmpty(campo1))
                return new HttpStatusCodeResult(400);

            return Content(campo1 + " , " + campo2);
        }
    }

    [Serializable]
    public class OrcamentoSession
    {
        public string Campo1 { get; set; }
        public string Campo2 { get; set; }
        public OrcamentoItemSession[] Subcampos { get; set; }
    }

    [Serializable]
    public class OrcamentoItemSession
    {
        public string Subcampo1 { get; set; }
    }



}