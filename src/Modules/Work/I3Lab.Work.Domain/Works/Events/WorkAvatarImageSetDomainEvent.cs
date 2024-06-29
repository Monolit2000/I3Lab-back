using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.Works.Events
{
    public class WorkAvatarImageSetDomainEvent : DomainEventBase
    {
        public WorkFile WorkFile { get; }

        public WorkAvatarImageSetDomainEvent(WorkFile workFile)
        {
            WorkFile = workFile;
        }
    }
}
