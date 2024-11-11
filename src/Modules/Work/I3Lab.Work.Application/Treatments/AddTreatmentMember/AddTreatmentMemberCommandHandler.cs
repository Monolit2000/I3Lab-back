using FluentResults;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using MediatR;


namespace I3Lab.Treatments.Application.Treatments.AddTreatmentMember
{
    public class AddTreatmentMemberCommandHandler(
        IMemberRepository memberRepository,
        ITreatmentRepository treatmentRepository) : IRequestHandler<AddTreatmentMemberCommand, Result>
    {
        public async Task<Result> Handle(AddTreatmentMemberCommand request, CancellationToken cancellationToken)
        {
            var treatment = await treatmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId), cancellationToken);

            if (treatment == null)
                return Result.Fail(TreatmentApplicationErrors.TreatmentNotFound);

            var member = await memberRepository.GetAsync(new MemberId(request.MemberId));

            if (member == null)
                return Result.Fail(TreatmentApplicationErrors.MemberNotFound);

            var result = treatment.AddToTreatmentMembers(member);
            if (result.IsFailed)
                return result; 

            await treatmentRepository.SaveChangesAsync();

            return result;
        }
    }
}
