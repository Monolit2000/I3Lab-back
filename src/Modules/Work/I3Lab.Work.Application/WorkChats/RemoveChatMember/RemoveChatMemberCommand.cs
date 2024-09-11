using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.WorkChats.RemoveChatMember
{
    public class RemoveChatMemberCommand : IRequest
    {
        public Guid MemberId { get; }
        public Guid WorkId { get; }
        public Guid WrorkChatId { get; }

        public RemoveChatMemberCommand(
            Guid memberId,
            Guid workId)
        {
            MemberId = memberId;
            WorkId = workId;
        }
    }
}
