using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.TreatmentInvites;
using I3Lab.Works.Domain.Treatments.Errors;
using I3Lab.Works.Domain.Treatments.Events;
using I3Lab.Works.Domain.Works;

namespace I3Lab.Works.Domain.Treatments
{
    public class Treatment : Entity, IAggregateRoot
    {
        public readonly List<Work> TreatmentStages = [];

        public readonly List<TreatmentMember> TreatmentMemberss = [];

        public Member Creator { get; private set; }
        public Member Patient { get; private set; }

        public TreatmentId Id { get; private set; }
        public Titel Titel { get; private set; }
        public BlobFile TreatmentPreview { get; private set; }
        public TreatmentDate TreatmentDate { get; private set; }


        public static Treatment CreateNew(Member creator, Member patient, Titel titel) 
            => new Treatment(creator, patient, titel);

        private Treatment()
        {
            // For Ef Core
        }

        private Treatment(
            Member creator, 
            Member patient,
            Titel titel)
        {
            Id = new TreatmentId(Guid.NewGuid());
            Creator = creator;
            Patient = patient;
            Titel = titel;
            TreatmentDate = TreatmentDate.Start();

            AddDomainEvent(new TreatmentCreatedDomainEvent(creator.Id.Value, Id.Value));
        }


        public TreatmentInvite Invite(Member memberToInvite, Member inviter)
        {
            return TreatmentInvite.InviteBasedOnTreatment(this , memberToInvite, inviter).Value;
        }

        public async Task<Result<Work>> CreateWorkAsync(Member creator)
        {
            return await Work.CreateBasedOnTreatmentAsync(creator, this);
        }

        public void RemuveTreatmentStage(MemberId creatorId, WorkId workId)
        {
            var treatmentStages = TreatmentStages.FirstOrDefault(ts => ts.Id == workId);
            if (treatmentStages == null) 
                throw new InvalidOperationException("Member to invite not found.");

            TreatmentStages.Remove(treatmentStages);
            AddDomainEvent(new TreatmentRemuveWorkDomainEvent());
        }


        public Result AddTreatmentMember(Member member, Member addedBy)
        {
            if (TreatmentMemberss.Any(member => member.Member.Id == member.Member.Id))
                return Result.Fail(TreatmentErrors.MemberAlreadyAdded);

            var treatmentMember = TreatmentMember.CreateNew(this.Id, member, addedBy);

            TreatmentMemberss.Add(treatmentMember);

            AddDomainEvent(new MemberAddedToTreatmentDomainEvent(Id.Value, member.Id.Value));

            return Result.Ok();
        }

        public Result RemoveTreatmentMember(Member member, Member addedBy)
        {
            var treatmentMember = TreatmentMemberss.FirstOrDefault(member => member.Member.Id == member.Member.Id);

            if(treatmentMember == null)
                return Result.Fail(TreatmentErrors.MemberAlreadyAdded);

            TreatmentMemberss.Remove(treatmentMember);

            AddDomainEvent(new MemberRemovedFromTreatmentDomainEvent(Id.Value, member.Id.Value));

            return Result.Ok();
        }


        //public Result AddMember(Member newMember)
        //{
        //    if (TreatmentMembers.Any(member => member.Id == newMember.Id))
        //        return Result.Fail(TreatmentErrors.MemberAlreadyAdded);

        //    TreatmentMembers.Add(newMember);

        //    AddDomainEvent(new MemberAddedToTreatmentDomainEvent(Id.Value, newMember.Id.Value));

        //    return Result.Ok();
        //}

        //public Result RemoveMember(MemberId memberId)
        //{
        //    var memberToRemove = TreatmentMembers.FirstOrDefault(member => member.Id == memberId);

        //    if (memberToRemove == null)
        //        return Result.Fail(TreatmentErrors.MemberNotFound);

        //    TreatmentMembers.Remove(memberToRemove);

        //    AddDomainEvent(new MemberRemovedFromTreatmentDomainEvent(Id.Value, memberToRemove.Id.Value));

        //    return Result.Ok();
        //}


        public void AddPatient(Member customer)
        {
            Patient = customer;
            AddDomainEvent(new AddedCustomerToTreatmentDomainEvent());
        }

        public void AddPreview(BlobFile fileId)
        {
            var treatmentPreview = fileId; //TreatmentPreview.CreateBaseOnWork(this.Id, fileId);

            TreatmentPreview = treatmentPreview;
        }
    }
}
