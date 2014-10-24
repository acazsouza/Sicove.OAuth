using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace OAuth.Model
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        [ScriptIgnore]
        public string Password { get; set; }
    }
}
