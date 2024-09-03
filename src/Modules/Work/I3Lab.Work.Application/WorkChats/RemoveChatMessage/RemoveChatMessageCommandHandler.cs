using FluentResults;
using I3Lab.Works.Domain.WorkChats;
using I3Lab.Works.Domain.Works;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.WorkChats.RemoveChatMessage
{
    public class RemoveChatMessageCommandHandler(
        IWorkChatRepository workChatRepository) : IRequestHandler<RemoveChatMessageCommand, Result>
    {
        public async Task<Result> Handle(RemoveChatMessageCommand request, CancellationToken cancellationToken)
        {
            var workChat = await workChatRepository.GetByWorkIdAsync(new WorkId(request.WorkId));

            if (workChat == null)
                return Result.Fail("WorkChat not found");

            workChat.RemoveMessage(new ChatMessageId(request.MessageId));

            return Result.Ok();
        }
    }
}
