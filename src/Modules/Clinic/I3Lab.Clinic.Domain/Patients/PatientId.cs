using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Clinics.Domain.Patients
{
    public class PatientId : TypedIdValueBase
    {
        public PatientId(Guid value) 
            : base(value)
        {
        }
    }
}
