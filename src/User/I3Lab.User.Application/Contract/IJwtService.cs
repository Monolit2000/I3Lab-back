using I3Lab.Users.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Users.Application.Contract
{
    public interface IJwtService
    {
        public string GenegateToken(User user);
    }
}
