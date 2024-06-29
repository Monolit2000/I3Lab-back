using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.WorkCatalogs
{
    public class WorkCatalogId : TypedIdValueBase
    {
        public WorkCatalogId(Guid value)
            : base(value)
        {
        }
    }
}
