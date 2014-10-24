using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth.Model
{
    public class Token : BaseEntity
    {
        public virtual User LoggedUser { get; set; }

        public string RedirectUrl { get; set; }

        public string GetToken()
        {
            return JsonConvert.SerializeObject(LoggedUser);
        }
    }
}
