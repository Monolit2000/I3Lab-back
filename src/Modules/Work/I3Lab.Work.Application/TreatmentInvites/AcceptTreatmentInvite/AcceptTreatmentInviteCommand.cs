using FluentResults;
using MediatR;

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
