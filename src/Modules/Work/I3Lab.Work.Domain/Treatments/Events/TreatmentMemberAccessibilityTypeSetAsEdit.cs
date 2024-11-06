using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.Treatments.Events
{
    public class TreatmentMemberAccessibilityTypeSetAsEdit : DomainEventBase
    {
        public TreatmentId TreatmentId { get; set; }    
        public MemberId MemberId { get; set; }

        public TreatmentMemberAccessibilityTypeSetAsEdit(TreatmentId treatmentId, MemberId memberId)
        {
            TreatmentId = treatmentId;
            MemberId = memberId;
        }
    }
}
