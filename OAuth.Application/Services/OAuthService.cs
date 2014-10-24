using OAuth.Infrastructure;
using OAuth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OAuth.Application.Cryptography
{
    public class OAuthService
    {
        private Context _context;

        public IPrincipal User
        {
            get
            {
                return System.Web.HttpContext.Current.User;
            }
        }

        public OAuthService(Context context)
        {
            _context = context;
        }

        public Token GetToken(Code code)
        {
            if (code != null && code.IsValid() && IsValidRequest(code))
            {
                code.WasUsed = true;

                var token = new Token() {
                    LoggedUser = code.LoggedUser
                };
                _context.Tokens.Add(token);

                _context.SaveChanges();

                return token;
            }

            throw new UnauthorizedAccessException();
        }

        public Code GetANewCode(string redirectUrl)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                using (var context = new Context())
                {
                    var loggedUser = context.Users.Where(x => x.Username == this.User.Identity.Name).FirstOrDefault();

                    var code = new Code() {
                        RedirectUrl = redirectUrl,
                        LoggedUser = loggedUser
                    };

                    context.Codes.Add(code);
                    context.SaveChanges();

                    return code;
                }
            }

            throw new UnauthorizedAccessException();
        }
        private bool IsValidRequest(Code code)
        {
            /*var codeRedirectUrl = code.RedirectUrl;

            return System.Web.HttpContext.Current.Request.Url.ToString() == codeRedirectUrl;*/

            return true;
        }
    }
}
