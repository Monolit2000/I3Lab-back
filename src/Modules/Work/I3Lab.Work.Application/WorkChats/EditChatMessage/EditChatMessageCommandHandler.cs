using FluentResults;
using I3Lab.Works.Domain.WorkChats;
using MediatR;
using I3Lab.Works.Domain.Works;
using System.Diagnostics.CodeAnalysis;

namespace I3Lab.Works.Application.WorkChats.EditChatMessage
{
    public class EditChatMessageCommandHandler(
        IWorkChatRepository workChatRepository) : IRequestHandler<EditChatMessageCommand, Result>
    {
        public async Task<Result> Handle(EditChatMessageCommand request, CancellationToken cancellationToken)
        {
            var chat = await workChatRepository.GetByWorkIdAsync(new WorkId(request.WorkId));
            if (chat == null)
                return Result.Fail("Chat not found");

            var result = chat.EditMessage(new ChatMessageId(request.MessageId), request.EditedMessage);

            if (result.IsFailed)
                return result;

            return Result.Ok();
        }
    }
}
