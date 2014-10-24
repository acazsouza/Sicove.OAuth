using OAuth.Model;
using OAuth.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OAuth.Application.Cryptography;

namespace OAuth.Presentation.Controllers
{
    public class OAuthController : Controller
    {
        [HttpPost]
        public JsonResult GetToken(string code)
        {
            var parsedCode = Guid.Parse(code);

            using (var context = new Context()) {
                var oauthService = new OAuthService(context);
                var codeRecord = context.Codes.Where(x => x.Value == parsedCode).FirstOrDefault();

                var token = oauthService.GetToken(codeRecord);

                return Json(token.LoggedUser);
            }
        }

        public ActionResult GetCode(string redirectUrl)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                using (var context = new Context()) {
                    var oauthService = new OAuthService(context);
                    var code = oauthService.GetANewCode(redirectUrl);

                    redirectUrl = string.Format("{0}?code={1}", redirectUrl, code.Value);

                    return Redirect(redirectUrl);
                }
            }
            else {
                return this.RedirectToAction("Index", "Login", new { redirectUrl = redirectUrl });
            }
        }
    }
}
