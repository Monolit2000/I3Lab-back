using I3Lab.User.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.User.Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password)
        }

        public bool Verify(string password, string hashePassword) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashePassword);




    }
}
