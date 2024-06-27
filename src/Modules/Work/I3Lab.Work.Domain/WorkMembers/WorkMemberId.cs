using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.Member
{
    public class WorkMemberId : TypedIdValueBase
    {
        public WorkMemberId(Guid value) 
            : base(value)
        {
        }
    }
}
