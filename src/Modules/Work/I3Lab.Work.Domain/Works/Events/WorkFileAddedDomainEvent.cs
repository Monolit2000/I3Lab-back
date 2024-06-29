using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.Works.Events
{
    public class WorkFileAddedDomainEvent : DomainEventBase
    {
        public WorkFile WorkFile { get; }

        public WorkFileAddedDomainEvent(WorkFile workFile)
        {
            WorkFile = workFile;
        }
    }
}
