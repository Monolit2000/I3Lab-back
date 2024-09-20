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

namespace I3Lab.Treatments.Application.WorkChats.RemoveChatMember
{
    public class RemoveChatMemberCommandHandler(
        ITreatmentStageChatRepository workChatRepository) : IRequestHandler<RemoveChatMemberCommand>
    {
        public async Task Handle(RemoveChatMemberCommand request, CancellationToken cancellationToken)
        {
            var workChat = await workChatRepository.GetByTreatmentStageIdAsync(new TreatmentStageId(request.WorkId));

            workChat.RemoveChatMember(new MemberId(request.MemberId));

            await workChatRepository.SaveChangesAsync();
        }
    }
}
