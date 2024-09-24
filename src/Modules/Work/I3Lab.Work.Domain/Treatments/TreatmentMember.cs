using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.Treatments.Events;

namespace I3Lab.Treatments.Domain.Treatments
{
    public class TreatmentMember : Entity
    {
        public TreatmentId TreatmentId { get; private set; }
        public TreatmentMemberId Id { get; private set; }
        public Member Member { get; private set; }

        //public TreatmentMemberRole TreatmentMemberRole { get; private set; }    
        public TreatmentMemberAccessibilityType AccessibilityType { get; private set; }
        public Member AddedBy { get; private set; }
        public DateTime JoinDate { get; private set; }
        public DateTime LeaveDate { get; private set; }

        private TreatmentMember() { } //for EF core

        private TreatmentMember(
            TreatmentId treatmentId,
            Member member,
            Member addedBy)
        {
            Id = new TreatmentMemberId(Guid.NewGuid());
            TreatmentId = treatmentId;
            Member = member;
            AddedBy = addedBy;
            JoinDate = DateTime.UtcNow;

            AddDomainEvent(new TreatmentMemberAddedDomainEvent(treatmentId, member.Id));
        }

        public static TreatmentMember CreateNew(
            TreatmentId treatmentId,
            Member memberId,
            Member addedBy)
            => new TreatmentMember(
                treatmentId,
                memberId,
                addedBy);

        public void Leave() 
            => LeaveDate = DateTime.UtcNow;

        public Result ChangeAccessibilityType(TreatmentMemberAccessibilityType newAccessibilityType)
        {
            if (AccessibilityType == newAccessibilityType)
                return Result.Ok();

            AccessibilityType = newAccessibilityType;

            AddDomainEvent(new TreatmentMemberAccessibilityTypeChangedDomainEvent(TreatmentId, Member, newAccessibilityType));

            return Result.Ok();
        }
    }
}
