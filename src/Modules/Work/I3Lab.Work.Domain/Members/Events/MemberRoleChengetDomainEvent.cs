using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.Members.Events
{
    internal class MemberRoleChengetDomainEvent : DomainEventBase
    {
        public MemberId MemberId { get; private set; }

        public MemberRole NewMemberRole { get; private set; }


    }
}
