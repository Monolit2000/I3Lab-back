using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Treatments;


namespace I3Lab.Treatments.Application.Treatments.GetTreatmentJoinLink
{
    public class GetTreatmentJoinLinkCommandHandler(
        ITreatmentRepository treatmentRepository) : IRequestHandler<GetTreatmentJoinLinkCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(GetTreatmentJoinLinkCommand request, CancellationToken cancellationToken)
        {
            var treatment = await treatmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId));

            var joinLink = treatment.GenerateInviteLink();

            return joinLink;
        }
    }
}
