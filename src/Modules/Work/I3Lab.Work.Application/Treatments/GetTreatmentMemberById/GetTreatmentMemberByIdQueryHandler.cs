﻿using FluentResults;
using MediatR;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;

namespace I3Lab.Treatments.Application.Treatments.GetTreatmentMembers
{
    public class GetTreatmentMemberByIdQueryHandler(
        ITreatmentRepository tretmentRepository) : IRequestHandler<GetTreatmentMemberByIdQuery, Result<TreatmentMemberDto>>
    {
        public async Task<Result<TreatmentMemberDto>> Handle(GetTreatmentMemberByIdQuery request, CancellationToken cancellationToken)
        {
            var treatment = await tretmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId));
            if (treatment == null)
                return Result.Fail("Treatment not found");

            var treatmentMember = treatment.TreatmentMembers.FirstOrDefault(tm => tm.Member.Id == new MemberId(request.TreatmentMemberId));

            if (treatmentMember == null)
                return Result.Fail("Member not found");

            return new TreatmentMemberDto(
                treatmentMember.Member.Id.Value, 
                treatmentMember.Member.FirstName,
                treatmentMember.Member.LastName);
        }
    }
}
