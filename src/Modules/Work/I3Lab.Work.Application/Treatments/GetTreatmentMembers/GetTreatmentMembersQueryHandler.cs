using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Treatments;


namespace I3Lab.Treatments.Application.Treatments.GetTreatmentMembers
{
    public class GetTreatmentMembersQueryHandler(
        ITreatmentRepository tretmentRepository) : IRequestHandler<GetTreatmentMembersQuery, Result<List<TreatmentMemberDto>>>
    {
        public async Task<Result<List<TreatmentMemberDto>>> Handle(GetTreatmentMembersQuery request, CancellationToken cancellationToken)
        {
            var tretment = await tretmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId));

            var treatmentMembers = tretment.TreatmentMembers.Select(treatmentMember => new TreatmentMemberDto(
                treatmentMember.Member.Id.Value,
                treatmentMember.Member.FirstName,
                treatmentMember.Member.LastName)).ToList();

            if (treatmentMembers.Any() is false)
                return new List<TreatmentMemberDto>();

            return treatmentMembers;
        }
    }
}
