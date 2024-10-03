using MediatR;
using FluentResults;

namespace I3Lab.Treatments.Application.Treatments.GetTreatmentById
{
    public class GetTreatmentByIdQuery : IRequest<Result<TreatmentDto>>
    {
        public Guid TreatmentId { get; set; }

        public GetTreatmentByIdQuery()
        {
                
        }
        public GetTreatmentByIdQuery(Guid treatmentId)
        {
            TreatmentId = treatmentId;
        }
    }
}
