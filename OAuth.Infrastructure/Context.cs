using OAuth.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Code> Codes { get; set; }

        public DbSet<Token> Tokens { get; set; }

        public Context() : base("DefaultConnection")
        {

        }
    }
}
