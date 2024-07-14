using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.WorkChats
{
    public class ChatMember : ValueObject
    {
        public MemberId MemberId { get; private set; }

        private ChatMember() { } // For EF Core

        public ChatMember(MemberId memberId)
        {
            MemberId = memberId;
        }
    }
}
