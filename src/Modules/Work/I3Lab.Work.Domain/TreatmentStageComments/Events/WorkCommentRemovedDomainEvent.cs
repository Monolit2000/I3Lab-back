using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.TreatmentStages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentStageComments.Events
{
    public class WorkCommentRemovedDomainEvent : DomainEventBase
    {
        public TreatmentStageCommentId WorkCommentId { get; }

        public WorkCommentRemovedDomainEvent(TreatmentStageCommentId workCommentId)
        {
            WorkCommentId = workCommentId;
        }
    }
}
