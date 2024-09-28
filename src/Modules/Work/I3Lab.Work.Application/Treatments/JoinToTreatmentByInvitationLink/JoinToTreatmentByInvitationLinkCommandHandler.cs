using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Treatments;

namespace I3Lab.Treatments.Application.Treatments.JoinToTreatmentByInvitationLink
{
    public class JoinToTreatmentByInvitationLinkCommandHandler(
        ITreatmentRepository treatmentRepository) : IRequestHandler<JoinToTreatmentByInvitationLinkCommand, Result>
    {
        public async Task<Result> Handle(JoinToTreatmentByInvitationLinkCommand request, CancellationToken cancellationToken)
        {
            var treatment = await treatmentRepository.GetByTokenAsync(request.Token);

            if (treatment == null)
                return Result.Fail("Invalid invite link");

            var validateResult = treatment.ValidateInviteToken(request.Token);
            if (validateResult.IsFailed)
                return validateResult;



            throw new NotImplementedException();
        }
    }
}
