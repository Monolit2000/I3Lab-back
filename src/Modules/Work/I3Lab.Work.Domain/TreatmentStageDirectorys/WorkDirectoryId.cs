using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.WorkDirectorys
{
    public class WorkDirectoryId : TypedIdValueBase
    {
        public WorkDirectoryId(Guid value)
            : base(value)
        {
        }
    }
}
