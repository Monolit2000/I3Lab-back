
using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.BlobFiles;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentInvites;
using I3Lab.Treatments.Domain.Treatments.Errors;
using I3Lab.Treatments.Domain.Treatments.Events;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.WorkAccebilitys;

namespace I3Lab.Treatments.Domain.Treatments
{
    public class Treatment : Entity, IAggregateRoot
    {
        public readonly List<TreatmentMember> TreatmentMembers = new();

        public Member Creator { get; private set; }
        public Member Patient { get; private set; }

        public TreatmentId Id { get; }
        public TreatmentTitel Titel { get; private set; }
        public BlobFile TreatmentPreview { get; private set; }
        public TreatmentDate TreatmentDate { get; private set; }
        public bool IsCanceled { get; private set; } = false;
        public bool IsFinished => TreatmentDate.IsFinished();

        public static Treatment CreateNew(Member creator, Member patient, TreatmentTitel titel)
            => new Treatment(creator, patient, titel);

        private Treatment() { } // For EF Core

        private Treatment(
            Member creator,
            Member patient,
            TreatmentTitel titel)
        {
            Id = new TreatmentId(Guid.NewGuid());
            Creator = creator;
            Patient = patient;
            Titel = titel;
            TreatmentDate = TreatmentDate.Start();

            TreatmentMembers.Add(TreatmentMember.CreateNew(Id, creator, creator));
            TreatmentMembers.Add(TreatmentMember.CreateNew(Id, patient, creator));

            AddDomainEvent(new TreatmentCreatedDomainEvent(creator.Id.Value, Id.Value));
        }

        //private void AddCreator(Member creator)
        //{
        //    Creator = creator;
        //    AddToTreatmentMembers(creator, creator);
        //}

        //public void AddPatient(Member patient)
        //{
        //    Patient = patient;
        //    AddToTreatmentMembers(patient, Creator);
        //}

        public TreatmentInvite Invite(Member memberToInvite, Member inviter)
        {
            return TreatmentInvite.InviteBasedOnTreatment(this, memberToInvite, inviter).Value;
        }

        public async Task<Result<TreatmentStage>> CreateTreatmentStageAsync(Member creator, TreatmentStageTitel stageTitel)
        {
            return await TreatmentStage.CreateBasedOnTreatmentAsync(creator, this.Id, stageTitel);
        }

        public Result AddToTreatmentMembers(Member member, Member addedBy)
        {
            if (TreatmentMembers.Any(m => m.Member.Id == member.Id))
                return Result.Fail(TreatmentErrors.MemberAlreadyAdded);

            var treatmentMember = TreatmentMember.CreateNew(this.Id, member, addedBy);
            TreatmentMembers.Add(treatmentMember);

            return Result.Ok();
        }

        public Result RemoveTreatmentMember(MemberId memberId, MemberId removingMemberId)
        {
            var treatmentMember = TreatmentMembers.FirstOrDefault(member => member.Member.Id == memberId);

            if (treatmentMember == null)
                return Result.Fail(TreatmentErrors.MemberNotFound);

            treatmentMember.Leave();
            TreatmentMembers.Remove(treatmentMember);
            AddDomainEvent(new MemberRemovedFromTreatmentDomainEvent(Id, treatmentMember.Member.Id));

            return Result.Ok();
        }

        public Result Cancel()
        {
            if (IsFinished)
                return Result.Fail("Cannot cancel a treatment that has already been finished.");

            if (IsCanceled)
                return Result.Fail("Treatment is already canceled.");

            IsCanceled = true;
            AddDomainEvent(new TreatmentCanceledDomainEvent(Id.Value, DateTime.UtcNow));

            return Result.Ok();
        }

        public Result Finish()
        {
            if (IsCanceled)
                return Result.Fail("Cannot finish a canceled treatment.");

            var result = TreatmentDate.End();

            if (result.IsFailed)
                return result;

            AddDomainEvent(new TreatmentFinishedDomainEvent(Id.Value, TreatmentDate.TreatmentFinished));

            return Result.Ok();
        }

        public void AddPreview(BlobFile fileId)
        {
            TreatmentPreview = fileId;
        }
    }
}



















































//using FluentResults;
//using I3Lab.BuildingBlocks.Domain;
//using I3Lab.Treatments.Domain.BlobFiles;
//using I3Lab.Treatments.Domain.Members;
//using I3Lab.Treatments.Domain.TreatmentInvites;
//using I3Lab.Treatments.Domain.Treatments.Errors;
//using I3Lab.Treatments.Domain.Treatments.Events;
//using I3Lab.Treatments.Domain.TreatmentStages;

//namespace I3Lab.Treatments.Domain.Treatments
//{
//    public class Treatment : Entity, IAggregateRoot
//    {
//        public readonly List<TreatmentMember> TreatmentMembers = [];

//        public Member Creator { get; private set; }
//        public Member Patient { get; private set; }

//        public TreatmentId Id { get; private set; }
//        public TreatmentTitel Titel { get; private set; }
//        public BlobFile TreatmentPreview { get; private set; }
//        public TreatmentDate TreatmentDate { get; private set; }


//        public static Treatment CreateNew(Member creator, Member patient, TreatmentTitel titel) 
//            => new Treatment(creator, patient, titel);

//        private Treatment() { } // For Ef Core

//        private Treatment(
//            Member creator, 
//            Member patient,
//            TreatmentTitel titel)
//        {
//            Id = new TreatmentId(Guid.NewGuid());
//            Creator = creator;
//            Patient = patient;
//            Titel = titel;
//            TreatmentDate = TreatmentDate.Start();

//            AddCreator(creator);

//            AddPatient(patient);

//            AddDomainEvent(new TreatmentCreatedDomainEvent(creator.Id.Value, Id.Value));
//        }


//        private void AddCreator(Member creator)
//        {
//            Creator = creator;

//            AddToTreatmentMembers(creator, creator);
//        }

//        public void AddPatient(Member patient)
//        {
//            Patient = patient;

//            AddToTreatmentMembers(patient, Creator);
//        }

//        public TreatmentInvite Invite(Member memberToInvite, Member inviter)
//        {
//            return TreatmentInvite.InviteBasedOnTreatment(this , memberToInvite, inviter).Value;
//        }

//        public async Task<Result<TreatmentStages.TreatmentStage>> CreateTreatmentStageAsync(Member creator, TreatmentStageTitel workTitel)
//        {
//            return await Domain.TreatmentStages.TreatmentStage.CreateBasedOnTreatmentAsync(creator, this.Id, workTitel);
//        }

//        //public void RemuveTreatmentStage(MemberId creatorId, TreatmentStageId workId)
//        //{
//        //    var treatmentStages = TreatmentStages.FirstOrDefault(ts => ts.Id == workId);
//        //    if (treatmentStages == null) 
//        //        throw new InvalidOperationException("Member to invite not found.");

//        //    TreatmentStages.Remove(treatmentStages);
//        //    AddDomainEvent(new TreatmentRemuveWorkDomainEvent());
//        //}


//        public Result AddToTreatmentMembers(Member member, Member addedBy)
//        {
//            if (TreatmentMembers.Any(m => m.Member.Id == member.Id))
//                return Result.Fail(TreatmentErrors.MemberAlreadyAdded);

//            var treatmentMember = TreatmentMember.CreateNew(this.Id, member, addedBy);

//            TreatmentMembers.Add(treatmentMember);

//            return Result.Ok();
//        }

//        public Result RemoveTreatmentMember(MemberId memberId, MemberId removingMemberId)
//        {
//            var treatmentMember = TreatmentMembers.FirstOrDefault(member => member.Member.Id == member.Member.Id);

//            if(treatmentMember == null)
//                return Result.Fail(TreatmentErrors.MemberAlreadyAdded);

//            treatmentMember.Leave();

//            TreatmentMembers.Remove(treatmentMember);

//            AddDomainEvent(new MemberRemovedFromTreatmentDomainEvent(Id, treatmentMember.Member.Id));

//            return Result.Ok();
//        }


//        //public void AddPatient(Member customer)
//        //{
//        //    Patient = customer;
//        //    AddDomainEvent(new AddedCustomerToTreatmentDomainEvent());
//        //}

//        public void AddPreview(BlobFile fileId)
//        {
//            var treatmentPreview = fileId; //TreatmentPreview.CreateBaseOnTreatmentStage(this.Id, fileId);

//            TreatmentPreview = treatmentPreview;
//        }

//        //public Result AddMember(Member newMember)
//        //{
//        //    if (TreatmentMembers.Any(member => member.Id == newMember.Id))
//        //        return Result.Fail(TreatmentErrors.MemberAlreadyAdded);

//        //    TreatmentMembers.Add(newMember);

//        //    AddDomainEvent(new TreatmentMemberAddedDomainEvent(Id.Value, newMember.Id.Value));

//        //    return Result.Ok();
//        //}

//        //public Result RemoveMember(MemberId memberId)
//        //{
//        //    var memberToRemove = TreatmentMembers.FirstOrDefault(member => member.Id == memberId);

//        //    if (memberToRemove == null)
//        //        return Result.Fail(TreatmentErrors.MemberNotFound);

//        //    TreatmentMembers.Remove(memberToRemove);

//        //    AddDomainEvent(new MemberRemovedFromTreatmentDomainEvent(Id.Value, memberToRemove.Id.Value));

//        //    return Result.Ok();
//        //}



//    }
//}
