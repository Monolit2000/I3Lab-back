using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.TreatmentStageChats;

namespace I3Lab.Treatments.Application.WorkChats.EditChatMessage
{
    public class EditChatMessageCommandHandler(
        ITreatmentStageChatRepository workChatRepository) : IRequestHandler<EditChatMessageCommand, Result>
    {
        public async Task<Result> Handle(EditChatMessageCommand request, CancellationToken cancellationToken)
        {
            var chat = await workChatRepository.GetByTreatmentStageIdAsync(new TreatmentStageId(request.WorkId));
            if (chat == null)
                return Result.Fail("Chat not found");

            var result = chat.EditMessage(new ChatMessageId(request.MessageId), request.EditedMessage);

            if (result.IsFailed)
                return result;

            await workChatRepository.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
