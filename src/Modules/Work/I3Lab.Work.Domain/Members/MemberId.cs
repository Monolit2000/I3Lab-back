using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.Members
{
    public class MemberId : TypedIdValueBase
    {
        public MemberId(Guid value) 
            : base(value)
        {
        }
    }
}
