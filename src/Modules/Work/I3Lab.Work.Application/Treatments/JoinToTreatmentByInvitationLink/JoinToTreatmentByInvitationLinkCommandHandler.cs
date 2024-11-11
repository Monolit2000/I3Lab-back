using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments.Errors;

namespace I3Lab.Treatments.Application.Treatments.JoinToTreatmentByInvitationLink
{
    public class JoinToTreatmentByInvitationLinkCommandHandler(
        IMemberRepository memberRepository,
        ITreatmentRepository treatmentRepository) : IRequestHandler<JoinToTreatmentByInvitationLinkCommand, Result>
    {
        public async Task<Result> Handle(JoinToTreatmentByInvitationLinkCommand request, CancellationToken cancellationToken)
        {
            var treatment = await treatmentRepository.GetByTokenAsync(request.Token);

            if (treatment == null)
                return Result.Fail(TreatmentErrors.InvalidInviteLink);

            var validateResult = treatment.ValidateInviteToken(request.Token);
            if (validateResult.IsFailed)
                return validateResult;

            var member = await memberRepository.GetAsync(new MemberId(request.MemberId));
            if (member is null)
                return Result.Fail(TreatmentErrors.MemberNotFound);

            var result = treatment.AddToTreatmentMembers(member);

            if (result.IsFailed)
                return result;

            await treatmentRepository.SaveChangesAsync();

            return result;  
        }
    }
}
