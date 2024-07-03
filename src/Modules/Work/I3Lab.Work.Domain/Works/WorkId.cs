using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Works.Domain.Works
{
    public class WorkId : TypedIdValueBase
    {
        public WorkId(Guid value) 
            : base(value)
        { 
        }
    }
}
