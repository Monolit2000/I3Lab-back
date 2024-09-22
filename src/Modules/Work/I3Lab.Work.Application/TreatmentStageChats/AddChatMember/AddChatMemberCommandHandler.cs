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

namespace I3Lab.Treatments.Application.TreatmentStageChats.AddChatMember
{
    public class AddChatMemberCommandHandler(
        IMemberRepository memberRepository,  
        ITreatmentStageChatRepository treatmentStageChatRepository) : IRequestHandler<AddChatMemberCommand>
    {
        public async Task Handle(AddChatMemberCommand request, CancellationToken cancellationToken)
        {
            var treatmentStageChat = await treatmentStageChatRepository.GetByTreatmentStageIdAsync(new TreatmentStageId(request.WorkId));

            if (treatmentStageChat == null)
                return;

            var member = await memberRepository.GetMemberByIdAsync(new MemberId(request.MemberId));

            treatmentStageChat.AddChatMember(member);

            await treatmentStageChatRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
