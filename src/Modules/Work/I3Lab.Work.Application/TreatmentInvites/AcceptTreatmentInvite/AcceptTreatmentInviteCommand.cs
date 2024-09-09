using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.TreatmentInvites.AcceptTreatmentInvite
{
    public class AcceptTreatmentInviteCommand : IRequest<Result>
    {
        public Guid TreatmentInviteId { get; set; }
        public AcceptTreatmentInviteCommand(Guid treatmentInviteId)
        {
            TreatmentInviteId = treatmentInviteId;
        }
    }
}
