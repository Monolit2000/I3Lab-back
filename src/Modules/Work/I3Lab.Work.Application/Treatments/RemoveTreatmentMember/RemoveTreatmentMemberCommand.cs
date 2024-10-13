using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.RemoveTreatmentMember
{
    public class RemoveTreatmentMemberCommand : IRequest<Result>
    {
        public Guid TreatmentId { get; }
        public Guid TreatmentMemberId{ get; }
        public Guid TreatmentRemovingMemberId { get; }
        public RemoveTreatmentMemberCommand(
            Guid treatmentId, 
            Guid treatmentMemberId)
        {
            TreatmentId = treatmentId;
            TreatmentMemberId = treatmentMemberId;
        }
    }
}
