using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Treatments.Domain.TreatmentInvites
{
    public class TreatmentInviteId : TypedIdValueBase
    {
        public TreatmentInviteId(Guid value) 
            : base(value)
        {
        }
    }
}
