using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Treatments.Domain.TreatmentStages
{
    public class TreatmentStageId : TypedIdValueBase
    {
        public TreatmentStageId(Guid value) 
            : base(value)
        { 
        }
    }
}
