using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.WorkChats.AddChatMember
{
    public class AddChatMemberCommandHandler(
        IMemberRepository memberRepository,  
        ITreatmentStageChatRepository workChatRepository) : IRequestHandler<AddChatMemberCommand>
    {
        public async Task Handle(AddChatMemberCommand request, CancellationToken cancellationToken)
        {
            var workChat = await workChatRepository.GetByTreatmentStageIdAsync(new TreatmentStageId(request.WorkId));

            if (workChat == null)
                return;

            var member = await memberRepository.GetMemberByIdAsync(new MemberId(request.MemberId));

            workChat.AddChatMember(member);

            await workChatRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
