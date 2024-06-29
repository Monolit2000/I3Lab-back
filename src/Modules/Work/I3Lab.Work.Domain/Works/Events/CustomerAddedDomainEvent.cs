using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.Works.Events
{
    public class CustomerAddedDomainEvent : DomainEventBase
    {
        public MemberId WorkMember { get; }

        public CustomerAddedDomainEvent(MemberId workMember) 
        {
            WorkMember = workMember;    
        }   
    }
}
