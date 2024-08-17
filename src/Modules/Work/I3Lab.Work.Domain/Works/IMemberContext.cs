using I3Lab.Works.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Works
{
    public interface IMemberContext
    {
        MemberId MemberId { get; }
    }
}
