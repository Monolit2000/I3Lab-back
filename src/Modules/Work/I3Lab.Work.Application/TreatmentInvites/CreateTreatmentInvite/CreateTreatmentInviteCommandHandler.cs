using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentInvites;
using I3Lab.Treatments.Domain.Treatments.Errors;

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
            if (treatment is null)
                return Result.Fail(TreatmentErrors.TreatmentNotFound);

            var memberToInvite = await memberRepository
                .GetAsync(new MemberId(request.MemberToInviteId));
            if (memberToInvite is null)
                return Result.Fail(TreatmentInviteApplicationErrors.InviteeNotFound);

            var inviter = await memberRepository
                .GetAsync(new MemberId(request.InviterId));
            if (inviter is null)
                return Result.Fail(TreatmentInviteApplicationErrors.InviterNotFound);

            var treatmentInvaite = treatment.Invite(memberToInvite, inviter);

            await treatmentInviteRepository.AddAsync(treatmentInvaite);

            return new TreatmentInviteDto();
        }
    }
}
