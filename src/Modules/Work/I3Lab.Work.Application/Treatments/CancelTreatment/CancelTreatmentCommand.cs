using FluentResults;
using MediatR;

namespace I3Lab.Treatments.Application.Treatments.CancelTreatment
{
    public class CancelTreatmentCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }

        public Guid TreatmentId { get; set; }

        public CancelTreatmentCommand()
        {
        }

        public CancelTreatmentCommand(
            Guid userId,
            Guid treatmentId)
        {
            UserId = userId;
            TreatmentId = treatmentId;
        }
    }
}
