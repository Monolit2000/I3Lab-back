using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.Files
{
    public class FileId : TypedIdValueBase
    {
        public FileId(Guid value)
            : base(value)
        {
        }
    }
}
