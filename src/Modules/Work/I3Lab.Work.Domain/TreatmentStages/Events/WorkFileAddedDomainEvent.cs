using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentStages.Events
{
    public class WorkFileAddedDomainEvent : DomainEventBase
    {
        public TreatmentStageFile WorkFile { get; }

        public WorkFileAddedDomainEvent(TreatmentStageFile workFile)
        {
            WorkFile = workFile;
        }
    }
}
