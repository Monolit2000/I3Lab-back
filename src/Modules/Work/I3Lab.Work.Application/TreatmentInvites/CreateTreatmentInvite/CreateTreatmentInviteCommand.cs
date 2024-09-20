using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentInvites.CreateTreatmentInvite
{
    public class CreateTreatmentInviteCommand : IRequest<Result<TreatmentInviteDto>>
    {
        public Guid TreatmentId { get; set; }

        public Guid MemberToInviteId { get; set; }

        public Guid InviterId { get; set; }

        public CreateTreatmentInviteCommand()
        {
                
        }
        public CreateTreatmentInviteCommand(
            Guid treatmentId,
            Guid memberToInviteId,
            Guid inviter)
        {
            TreatmentId = treatmentId;
            MemberToInviteId = memberToInviteId;
            InviterId = inviter;
        }
    }
}
