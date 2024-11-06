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

          
        public TreatmentMemberRole Role { get; private set; }
        public TreatmentMemberAccessibilityType AccessibilityType { get; private set; }
        public DateTime JoinDate { get; private set; }
        public DateTime LeaveDate { get; private set; }

        private TreatmentMember() { } //for EF core

        private TreatmentMember(
            TreatmentId treatmentId,
            Member member,
            TreatmentMemberRole treatmentMemberRole)
        {
            Id = new TreatmentMemberId(Guid.NewGuid());
            TreatmentId = treatmentId;
            Member = member;
            JoinDate = DateTime.UtcNow;
            Role = treatmentMemberRole;

            AddDomainEvent(new TreatmentMemberAddedDomainEvent(
                treatmentId, 
                member.Id));
        }


        public Result SetAccessibilityTypeAsEdit()
        {
            AccessibilityType = TreatmentMemberAccessibilityType.Edit;

            AddDomainEvent(new TreatmentMemberAccessibilityTypeSetAsEdit(this.TreatmentId, this.Member.Id));
            return Result.Ok();
        }


        public static TreatmentMember CreateNew(
            TreatmentId treatmentId,
            Member memberId,
            TreatmentMemberRole treatmentMemberRole)
            => new TreatmentMember(
                treatmentId,
                memberId,
                treatmentMemberRole);

        public void Leave() 
            => LeaveDate = DateTime.UtcNow;

        public Result ChangeAccessibilityType(TreatmentMemberAccessibilityType newAccessibilityType)
        {
            if (AccessibilityType == newAccessibilityType)
                return Result.Ok();

            AccessibilityType = newAccessibilityType;

            AddDomainEvent(new TreatmentMemberAccessibilityTypeChangedDomainEvent(
                TreatmentId, 
                Member, 
                newAccessibilityType));

            return Result.Ok();
        }

        public bool IsActiveTreatmentMember(MemberId memberId)
        {
            return Member.Id == memberId;
        }
    }
}
