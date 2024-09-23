using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.GetTreatmentMembers
{
    public class GetTreatmentMembersQueryHandler(
        ITreatmentRepository tretmentRepository) : IRequestHandler<GetTreatmentMembersQuery, Result<List<TreatmentMemberDto>>>
    {
        public async Task<Result<List<TreatmentMemberDto>>> Handle(GetTreatmentMembersQuery request, CancellationToken cancellationToken)
        {
            var tretment = await tretmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId));

            var treatmentMember = tretment.TreatmentMembers.FirstOrDefault(tm => tm.Member.Id == new MemberId(request.TreatmentMemberId));

            if (treatmentMember == null)
                return Result.Fail("Member not found");

            var treatmentMemberDto = new TreatmentMemberDto(
                treatmentMember.Member.Id.Value,
                treatmentMember.Member.FirstName,
                treatmentMember.Member.LastName);

            return new List<TreatmentMemberDto>();
        }
    }
}
