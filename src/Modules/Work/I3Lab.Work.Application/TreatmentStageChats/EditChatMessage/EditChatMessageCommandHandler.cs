using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.TreatmentStageChats;

namespace I3Lab.Treatments.Application.TreatmentStageChats.EditChatMessage
{
    public class EditChatMessageCommandHandler(
        ITreatmentStageChatRepository treatmentStageChatRepository) : IRequestHandler<EditChatMessageCommand, Result>
    {
        public async Task<Result> Handle(EditChatMessageCommand request, CancellationToken cancellationToken)
        {
            var chat = await treatmentStageChatRepository.GetByTreatmentStageIdAsync(new TreatmentStageId(request.WorkId));
            if (chat == null)
                return Result.Fail("Chat not found");

            var result = chat.EditMessage(new MessageId(request.MessageId), request.EditedMessage);
            if (result.IsFailed)
                return result;

            await treatmentStageChatRepository.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
