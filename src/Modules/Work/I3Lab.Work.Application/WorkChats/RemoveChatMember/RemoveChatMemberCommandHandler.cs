using FluentResults;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.WorkChats;
using I3Lab.Works.Domain.Works;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.WorkChats.RemoveChatMember
{
    public class RemoveChatMemberCommandHandler(
        IWorkChatRepository workChatRepository) : IRequestHandler<RemoveChatMemberCommand>
    {
        public async Task Handle(RemoveChatMemberCommand request, CancellationToken cancellationToken)
        {
            var workChat = await workChatRepository.GetByWorkIdAsync(new WorkId(request.WorkId));

            workChat.RemoveChatMember(new MemberId(request.MemberId));

            await workChatRepository.SaveChangesAsync();
        }
    }
}
