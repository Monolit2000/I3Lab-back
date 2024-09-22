using FluentResults;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentStageChats.RemoveChatMessage
{
    public class RemoveChatMessageCommandHandler(
        ITreatmentStageChatRepository treatmentStageChatRepository) : IRequestHandler<RemoveChatMessageCommand, Result>
    {
        public async Task<Result> Handle(RemoveChatMessageCommand request, CancellationToken cancellationToken)
        {
            var treatmentStageChat = await treatmentStageChatRepository.GetByTreatmentStageIdAsync(new TreatmentStageId(request.WorkId));

            if (treatmentStageChat == null)
                return Result.Fail("TreatmentStageChat not found");

            treatmentStageChat.RemoveMessage(new ChatMessageId(request.MessageId));

            return Result.Ok();
        }
    }
}
