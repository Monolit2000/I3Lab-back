using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.TreatmentStages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentStageComments.Events
{
    public class WorkCommentAddedDomainEvent : DomainEventBase
    {
        public TreatmentStageCommentId WorkCommentId { get; }

        public TreatmentStageId WorkId { get; }

        public string Comment { get; }

        public WorkCommentAddedDomainEvent(TreatmentStageCommentId workCommentId, TreatmentStageId workId, string comment)
        {
            WorkCommentId = workCommentId;  
            WorkId = workId;
            Comment = comment;
        }
    }
}
