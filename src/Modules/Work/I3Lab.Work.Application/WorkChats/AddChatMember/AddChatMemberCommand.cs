using I3Lab.Works.Domain.Members;
using MassTransit.Testing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.WorkChats.AddChatMember
{
    public class AddChatMemberCommand : IRequest
    {
        public Guid MemberId { get; }
        public Guid WorkId { get; }
        public Guid WrorkChatId { get; }

        public AddChatMemberCommand(
            Guid memberId, 
            Guid workId)
        {
            MemberId = memberId;
            WorkId = workId;
        }
    }
}
