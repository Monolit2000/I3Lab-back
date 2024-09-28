using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.GetTreatmentInvitationLink
{
    public class GetTreatmentInvitationLinkCommand : IRequest<Result<string>>
    {
        public Guid TreatmentId { get; set; }

        public GetTreatmentInvitationLinkCommand()
        {
                
        }

        public GetTreatmentInvitationLinkCommand(Guid treatmentId)
        {
            TreatmentId = treatmentId;
        }
    }
}
