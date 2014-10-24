using OAuth.Application;
using OAuth.Infrastructure;
using OAuth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OAuth.Presentation.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index(string redirectUrl)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.RedirectToAction("Index", "Default");
            }

            this.ViewBag.RedirectUrl = redirectUrl;

            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password, string redirectUrl)
        {
            using (var context = new Context())
            {
                var usuarioService = new UserService(context);

                if (usuarioService.ValidateUser(username, password))
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    return this.RedirectToAction("GetCode", "OAuth", new { RedirectUrl = redirectUrl });
                }
            }

            this.ViewBag.RedirectUrl = redirectUrl;

            return View();
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
            this.RedirectToAction("Index", "Default");
        }
    }
}