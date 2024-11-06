using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.SetTreatmentMemberAccessibilityTypeAsEdit
{
    public class SetTreatmentMemberAccessibilityTypeAsEditCommand : IRequest<Result>
    {
        public Guid TreatmentId { get; set; }
        public Guid TreatmentMemberId { get; set; }

        public SetTreatmentMemberAccessibilityTypeAsEditCommand(
            Guid treatmentId, 
            Guid treatmentMemberId)
        {
            TreatmentId = treatmentId;
            TreatmentMemberId = treatmentMemberId;
        }
    }
}
