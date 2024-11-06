using FluentResults;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using MediatR;

namespace I3Lab.Treatments.Application.Treatments.ChengTreatmentMemberStatus
{
    public class ChengTreatmentMemberStatusCommandHandler(
        IMemberRepository memberRepository,
        ITreatmentRepository treatmentRepository) : IRequestHandler<ChengTreatmentMemberStatusCommand, Result>
    {
        public async Task<Result> Handle(ChengTreatmentMemberStatusCommand request, CancellationToken cancellationToken)
        {
            var treatment = await treatmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId));
            if (treatment is null)
                return Result.Fail(TreatmentsErrors.TreatmentNotFound);

            var member = await memberRepository.GetAsync(new MemberId(request.TreatmentMemberId));

            if (member == null)
                return Result.Fail(TreatmentsErrors.MemberNotFound);

            var result = treatment.AddToTreatmentMembers(member);
            if (result.IsFailed)
                return result;

            await treatmentRepository.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
