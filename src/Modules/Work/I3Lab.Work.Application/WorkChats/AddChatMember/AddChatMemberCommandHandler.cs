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

namespace I3Lab.Works.Application.WorkChats.AddChatMember
{
    public class AddChatMemberCommandHandler(
        IMemberRepository memberRepository,  
        IWorkChatRepository workChatRepository) : IRequestHandler<AddChatMemberCommand>
    {
        public async Task Handle(AddChatMemberCommand request, CancellationToken cancellationToken)
        {
            var workChat = await workChatRepository.GetByWorkIdAsync(new WorkId(request.WorkId));

            if (workChat == null)
                return;

            var member = await memberRepository.GetMemberByIdAsync(new MemberId(request.MemberId));

            workChat.AddChatMember(member);

            await workChatRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
