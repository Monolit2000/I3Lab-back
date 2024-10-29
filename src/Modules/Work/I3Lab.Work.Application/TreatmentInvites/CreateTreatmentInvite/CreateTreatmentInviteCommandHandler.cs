using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentInvites;


namespace I3Lab.Treatments.Application.TreatmentInvites.CreateTreatmentInvite
{
    public class CreateTreatmentInviteCommandHandler(
        IMemberRepository memberRepository, 
        ITreatmentRepository tretmentRepository, 
        ITreatmentInviteRepository treatmentInviteRepository) : IRequestHandler<CreateTreatmentInviteCommand, Result<TreatmentInviteDto>>
    {
        public async Task<Result<TreatmentInviteDto>> Handle(CreateTreatmentInviteCommand request, CancellationToken cancellationToken)
        {
            var treatment = await tretmentRepository
                .GetByIdAsync(new TreatmentId(request.TreatmentId), cancellationToken);

            var memberToInvite = await memberRepository
                .GetAsync(new MemberId(request.MemberToInviteId));

            var inviter = await memberRepository
                .GetAsync(new MemberId(request.InviterId));

            var treatmentInvaite = treatment.Invite(memberToInvite, inviter);

            await treatmentInviteRepository.AddAsync(treatmentInvaite);

            return new TreatmentInviteDto();
        }
    }
}
