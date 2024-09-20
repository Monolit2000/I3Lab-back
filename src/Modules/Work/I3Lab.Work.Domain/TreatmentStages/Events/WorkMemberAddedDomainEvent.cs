using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;

namespace I3Lab.Treatments.Domain.TreatmentStages.Events
{
    public class WorkMemberAddedDomainEvent : DomainEventBase
    {
        public TreatmentStageId WorkId { get; }
        public Member MemberId { get; }
        public Member AddedBy { get; }

        public WorkMemberAddedDomainEvent(
            TreatmentStageId workId,
            Member memberId,
            Member addedBy)
        {
            WorkId = workId;
            MemberId = memberId;
            AddedBy = addedBy;
        }
    }
}
