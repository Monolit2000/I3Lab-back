using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.Work
{
    public class WorkId : TypedIdValueBase
    {
        public WorkId(Guid value) 
            : base(value)
        { 
        }
    }
}
