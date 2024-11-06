using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;

namespace I3Lab.Treatments.Application.Treatments.SetTreatmentMemberAccessibilityTypeAsReadOnly
{
    public class SetTreatmentMemberAccessibilityTypeAsReadOnlyCommandHandler(
        IMemberRepository memberRepository,
        ITreatmentRepository treatmentRepository) : IRequestHandler<SetTreatmentMemberAccessibilityTypeAsReadOnlyCommand, Result>
    {
        public async Task<Result> Handle(SetTreatmentMemberAccessibilityTypeAsReadOnlyCommand request, CancellationToken cancellationToken)
        {
            var treatment = await treatmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId));
            if (treatment is null)
                return Result.Fail(TreatmentsErrors.TreatmentNotFound);

            var member = await memberRepository.GetAsync(new MemberId(request.TreatmentMemberId));
            if (member == null)
                return Result.Fail(TreatmentsErrors.MemberNotFound);

            var result = treatment.SetAccessibilityTypeAsReadOnly(member.Id);
            if (result.IsFailed)
                return result;

            await treatmentRepository.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
