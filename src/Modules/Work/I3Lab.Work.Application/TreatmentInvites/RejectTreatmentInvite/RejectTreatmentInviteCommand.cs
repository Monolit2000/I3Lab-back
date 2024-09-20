using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentInvites.RejectTreatmentInvite
{
    public class RejectTreatmentInviteCommand : IRequest<Result>
    {
        public Guid TreatmentInviteId { get; set; }
        public RejectTreatmentInviteCommand(Guid treatmentInviteId)
        {
            TreatmentInviteId = treatmentInviteId;
        }
    }
}
