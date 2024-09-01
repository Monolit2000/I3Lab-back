using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Works.Events
{
    public class CustomerAddedDomainEvent : DomainEventBase
    {
        public Member WorkMember { get; }

        public CustomerAddedDomainEvent(Member workMember) 
        {
            WorkMember = workMember;    
        }   
    }
}
