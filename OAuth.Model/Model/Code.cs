using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth.Model
{
    public class Code : BaseEntity
    {
        public virtual User LoggedUser { get; set; }

        public Guid Value { get; set; }

        public string RedirectUrl { get; set; }

        public DateTime ExpireAt { get; set; }

        public bool WasUsed { get; set; }

        public Code()
        {
            Value = Guid.NewGuid();
            ExpireAt = DateTime.Now.AddSeconds(30);
            WasUsed = false;
        }

        public bool IsValid()
        {
            if ((DateTime.Compare(ExpireAt, DateTime.Now) > 0) || WasUsed == false)
                return true;

            return false;
        }
    }
}
