using SIDomper.Dominio.Entidades;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SIDomper.WEB.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Usuario model)
        {
            if (ModelState.IsValid) //verifica se é válido
            {
                var Servico = new UsuarioServico();
                try
                {
                    model = Servico.ObterPorUsuario(model.UserName, model.Password);
                    if (model != null)
                    {
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                            model.UserName,
                            DateTime.Now,
                            DateTime.Now.AddDays(30),
                            true,
                            model.Id.ToString(),
                            FormsAuthentication.FormsCookiePath);

                        string encTicket = FormsAuthentication.Encrypt(ticket);
                        Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }
                return RedirectToAction("index", "Home");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "Home");
        }
    }
}