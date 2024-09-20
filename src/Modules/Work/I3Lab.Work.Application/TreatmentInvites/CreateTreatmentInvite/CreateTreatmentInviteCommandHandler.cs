using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentInvites;
using I3Lab.Treatments.Domain.Treatments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentInvites.CreateTreatmentInvite
{
    public class CreateTreatmentInviteCommandHandler(
        ITretmentRepository tretmentRepository, 
        ITreatmentInviteRepository treatmentInviteRepository,
        IMemberRepository memberRepository) : IRequestHandler<CreateTreatmentInviteCommand, Result<TreatmentInviteDto>>
    {
        public async Task<Result<TreatmentInviteDto>> Handle(CreateTreatmentInviteCommand request, CancellationToken cancellationToken)
        {
            var treatment = await tretmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId), cancellationToken);

            var memberToInvite = await memberRepository.GetMemberByIdAsync(new MemberId(request.MemberToInviteId));

            var inviter = await memberRepository.GetMemberByIdAsync(new MemberId(request.InviterId));

            var treatmentInvaite = treatment.Invite(memberToInvite, inviter);

            await treatmentInviteRepository.AddAsync(treatmentInvaite);

            return new TreatmentInviteDto();
        }
    }
}
