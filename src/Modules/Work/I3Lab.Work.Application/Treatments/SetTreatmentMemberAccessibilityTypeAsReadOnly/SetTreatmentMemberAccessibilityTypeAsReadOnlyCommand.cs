using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.SetTreatmentMemberAccessibilityTypeAsReadOnly
{
    public class SetTreatmentMemberAccessibilityTypeAsReadOnlyCommand : IRequest<Result>
    {
        public Guid TreatmentId { get; set; }
        public Guid TreatmentMemberId { get; set; }

        public SetTreatmentMemberAccessibilityTypeAsReadOnlyCommand()
        {
        }

        public SetTreatmentMemberAccessibilityTypeAsReadOnlyCommand(
            Guid treatmentId,
            Guid treatmentMemberId)
        {
            TreatmentId = treatmentId;
            TreatmentMemberId = treatmentMemberId;
        }
    }
}
