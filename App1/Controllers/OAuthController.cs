using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace App1.Controllers
{
    public class OAuthController : Controller
    {
        public ActionResult ReceiveCode(string code)
        {
            if (!String.IsNullOrEmpty(code) /*&& !this.User.Identity.IsAuthenticated*/)
            {
                //gettoken
                string getTokenResponse;
                using (WebClient client = new WebClient())
                {
                    getTokenResponse = client.UploadString("http://loginsicove.azurewebsites.net/oauth/gettoken?code=" + code, "");
                }

                //var jsonTokenResponse = JContainer.Parse(getTokenResponse);

                //if returns a valid token, authenticate the user.
                FormsAuthentication.SetAuthCookie("acaz", false);
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}