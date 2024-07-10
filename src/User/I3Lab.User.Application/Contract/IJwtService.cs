using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.User.Application.Contract
{
    public interface IJwtService
    {
        public string GenegateToken();
    }
}
