using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Works.Events;
using I3Lab.Works.Domain.Works;
using I3Lab.Works.Domain.Treatments.Events;

namespace I3Lab.Works.Domain.Treatments
{
    public class TreatmentMember : Entity
    {
        public TreatmentId TreatmentId { get; private set; }

        public TreatmentMemberId Id { get; private set; }

        public Member Member { get; private set; }
        public MemberAccessibilityType AccessibilityType { get; private set; }
        public Member AddedBy { get; private set; }
        public DateTime JoinDate { get; private set; }

        private TreatmentMember() { } //for EF core

        private TreatmentMember(
            TreatmentId treatmentId,
            Member member,
            Member addedBy)
        {
            Id = new TreatmentMemberId( Guid.NewGuid());
            TreatmentId = treatmentId;
            Member = member;
            AddedBy = addedBy;
            JoinDate = DateTime.UtcNow;
        }

        public static TreatmentMember CreateNew(
            TreatmentId treatmentId,
            Member memberId,
            Member addedBy)
        {
            return new TreatmentMember(
                treatmentId,
                memberId,
                addedBy);
        }

        public Result ChangeAccessibilityType(MemberAccessibilityType newAccessibilityType)
        {
            if (AccessibilityType == newAccessibilityType)
                return Result.Ok();

            AccessibilityType = newAccessibilityType;

            AddDomainEvent(new TreatmentMemberAccessibilityTypeChangedDomainEvent(TreatmentId, Member, newAccessibilityType));

            return Result.Ok();
        }
    }
}
