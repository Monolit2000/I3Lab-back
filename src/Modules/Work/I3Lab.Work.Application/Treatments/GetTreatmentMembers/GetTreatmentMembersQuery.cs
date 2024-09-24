using FluentResults;
using MediatR;


namespace I3Lab.Treatments.Application.Treatments.GetTreatmentMembers
{
    public class GetTreatmentMembersQuery : IRequest<Result<List<TreatmentMemberDto>>>
    {
        public Guid TreatmentId { get; set; }

        public GetTreatmentMembersQuery()
        {

        }

        public GetTreatmentMembersQuery(
            Guid treatmentId)
        {
            TreatmentId = treatmentId;
        }
    }
}
