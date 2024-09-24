using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.AddTreatmentMember
{
    public class AddTreatmentMemberCommand : IRequest<Result>
    {
        public Guid TreatmentId { get; }   
        public Guid MemberId { get; }
        public Guid InvaiterId { get; }

        public AddTreatmentMemberCommand(
            Guid treatmentId,
            Guid memberId,
            Guid invaiterId)
        {
            TreatmentId = treatmentId;
            MemberId = memberId;
            InvaiterId = invaiterId;
        }
    }
}
