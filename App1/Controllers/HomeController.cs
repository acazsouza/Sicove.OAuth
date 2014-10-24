using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace App1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return this.Redirect(string.Format("http://loginsicove.azurewebsites.net/oauth/getcode?redirecturl={0}", "http://loginexemplo1.azurewebsites.net/oauth/receivecode"));
            }
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}