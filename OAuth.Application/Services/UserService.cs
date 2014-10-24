using OAuth.Application.Cryptography;
using OAuth.Infrastructure;
using OAuth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OAuth.Application
{
    public class UserService
    {
        private Context _context;

        public UserService(Context context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public bool ValidateUser(string username, string password)
        {
            var user = _context.Users.Where(x => x.Username == username).FirstOrDefault();

            if (user == null)
                return false;

            return (user.Password == CryptographyService.GetHashSHA256(password));
        }
    }
}
