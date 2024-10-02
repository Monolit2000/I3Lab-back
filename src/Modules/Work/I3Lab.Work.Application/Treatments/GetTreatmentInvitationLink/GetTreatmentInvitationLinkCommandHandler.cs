using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Treatments;

namespace I3Lab.Treatments.Application.Treatments.GetTreatmentInvitationLink
{
    public class GetTreatmentInvitationLinkCommandHandler(
        ITreatmentRepository treatmentRepository) : IRequestHandler<GetTreatmentInvitationLinkCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(GetTreatmentInvitationLinkCommand request, CancellationToken cancellationToken)
        {
            var treatment = await treatmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId));

            var token = treatment.GetInvitationToken();

            var invitationLink = $"/join-invite?token={token}";

            return invitationLink;
        }
    }
}
