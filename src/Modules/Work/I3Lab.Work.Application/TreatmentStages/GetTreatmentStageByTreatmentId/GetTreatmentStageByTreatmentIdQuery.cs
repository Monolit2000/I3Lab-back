using FluentResults;
using MediatR;


namespace I3Lab.Treatments.Application.TreatmentStages.GetTreatmentStageByTreatmentId
{
    public class GetTreatmentStageByTreatmentIdQuery : IRequest<Result<List<TreatmentStageDto>>>
    {
        public Guid TreatmentId { get; set; }
    }
}
