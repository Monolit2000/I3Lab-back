using FluentResults;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.WorkChats.RemoveChatMessage
{
    public class RemoveChatMessageCommandHandler(
        ITreatmentStageChatRepository workChatRepository) : IRequestHandler<RemoveChatMessageCommand, Result>
    {
        public async Task<Result> Handle(RemoveChatMessageCommand request, CancellationToken cancellationToken)
        {
            var workChat = await workChatRepository.GetByTreatmentStageIdAsync(new TreatmentStageId(request.WorkId));

            if (workChat == null)
                return Result.Fail("TreatmentStageChat not found");

            workChat.RemoveMessage(new ChatMessageId(request.MessageId));

            return Result.Ok();
        }
    }
}
