using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStages.Events;


namespace I3Lab.Treatments.Domain.TreatmentStages
{
    public class TreatmentStageMember : Entity
    {
        public TreatmentStageId WorkId { get; private set; }
        public Member Member { get; private set; }
        public TreatmentMemberAccessibilityType AccessibilityType { get; private set; }
        public Member AddedBy { get; private set; }
        public DateTime JoinDate { get; private set; }

        private TreatmentStageMember() { } //for EF core

        private TreatmentStageMember(
            TreatmentStageId workId,
            Member member,
            Member addedBy) 
        {
            WorkId = workId;
            Member = member;
            AddedBy = addedBy;
            JoinDate = DateTime.UtcNow;
        }

        public static TreatmentStageMember CreateNew(
            TreatmentStageId workId,
            Member memberId,
            Member addedBy)
        {
            return new TreatmentStageMember(
                workId, 
                memberId,
                addedBy);
        }


        public Result ChangeAccessibilityType(TreatmentMemberAccessibilityType newAccessibilityType)
        {
            if (AccessibilityType == newAccessibilityType)
                return Result.Ok();

            AccessibilityType = newAccessibilityType;

            AddDomainEvent(new MemberAccessibilityTypeChangedDomainEvent(
                WorkId, 
                Member, 
                newAccessibilityType));

            return Result.Ok();
        }

    }
}
