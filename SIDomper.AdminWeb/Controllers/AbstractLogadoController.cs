using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SIDomper.AdminWEB.Controllers
{
    [Authorize]
    public abstract class AbstractLogadoController : Controller
    {
        protected string UsuarioNome { get; set; }
        protected int UsuarioId { get; set; }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            HttpCookie authCookie = Request.Cookies["SIDDomperWebCookie"];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                UsuarioNome = authTicket.Name;
                UsuarioId = Convert.ToInt32(authTicket.UserData);
                ViewBag.UsuarioNome = UsuarioNome;
                ViewBag.UsuarioId = UsuarioId;
            }

            base.OnAuthorization(filterContext);
        }
    }
}