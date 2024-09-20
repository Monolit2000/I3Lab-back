using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.BlobFiles;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages.Errors;
using I3Lab.Treatments.Domain.TreatmentStages.Events;

namespace I3Lab.Treatments.Domain.TreatmentStages
{
    public class TreatmentStage : Entity, IAggregateRoot
    {
        public TreatmentId TreatmentId { get; private set; }

        public readonly List<TreatmentStageFile> WorkFiles = [];
        public TreatmentStageId Id { get; private set; }
        public TreatmentStageTitel Titel { get; private set; }
        public TreatmentStageFile WorkAvatarImage  { get; private set; }
        public Member Customer { get; private set; }
        public TreatmentStageStatus WorkStatus { get; private set; }
        public Member Creator { get; private set; }
        public DateTime WorkStartedDate { get; private set; }   

        private TreatmentStage() { } //for Ef core

        private TreatmentStage(
            Member creatorId,
            TreatmentId treatment,
            TreatmentStageTitel workTitel)
        {
            Id = new TreatmentStageId(Guid.NewGuid());
            WorkStatus = TreatmentStageStatus.Pending;
            Creator = creatorId;
            TreatmentId = treatment;
            Titel = workTitel; 
            WorkStartedDate = DateTime.UtcNow;

            AddDomainEvent(new WorkCreatedDomainEvent(Id, TreatmentId));
        }

        public static async Task<Result<TreatmentStage>> CreateBasedOnTreatmentAsync(
            Member creator,
            TreatmentId treatment,
            TreatmentStageTitel workTitel)
        {
            if (!IsMemberRoleValid(creator))
                return Result.Fail(WorkErrors.MemberNotHaveRequiredRole);

            return new TreatmentStage(
                creator,
                treatment,
                workTitel);
        }

        public BlobFile CreateWorkFile(string fileName, ContentType contentType, BlobFileType fileType)
        {
            return BlobFile.CreateBaseOnWork(this.Id, fileName, contentType, fileType);
        }
        public TreatmentStageChat CreateWorkChat(List<Member> members)
        {
            return TreatmentStageChat.CreateBaseOnWork(this.Id, members);
        }
        public void AddWorkFile(TreatmentStageId workId, BlobFile fileId)
        {
            var newWorkFile = TreatmentStageFile.CreateNew(workId, fileId);
            WorkFiles.Add(newWorkFile);
        }

        public void SetWorkAvatarImage(TreatmentStageFile workFile)
        {
            WorkAvatarImage = workFile;
            AddDomainEvent(new WorkAvatarImageSetDomainEvent(workFile));
        }

        public Result AddCustomer(Member Customer, Member addedBy)
        {

            this.Customer = Customer;
            AddDomainEvent(new CustomerAddedDomainEvent(Customer));

            return Result.Ok();
        }

        public Result ChangeWorkStatus(TreatmentStageStatus newStatus)
        {
            if (WorkStatus == newStatus)
                return Result.Ok(); 

            WorkStatus = newStatus;
            AddDomainEvent(new WorkStatusChangedDomainEvent(Id, newStatus));
            return Result.Ok();
        }

        private static bool IsMemberRoleValid(Member creator)
        {
            return creator.MemberRole == MemberRole.Doctor || creator.MemberRole == MemberRole.Admin;
        }

    }
}
//private bool IsWorkMamberIdContainInWorkMembersList(MemberId memberId)
//{
//    var workMember = WorkMembers.FirstOrDefault(wm => wm.Member.Id == memberId);

//    if (workMember == null)
//      return false;

//    return true;    
//}

//public Result AddWorkMember(Member memberId, Member addedBy)
//{
//    if(IsWorkMamberIdContainInWorkMembersList(addedBy.Id))
//        return Result.Fail(WorkErrors.WorkMemberNotFoundError);

//    var newWorkMember = WorkMember.CreateBaseOnWork(this.Id, memberId, addedBy);
//    WorkMembers.Add(newWorkMember);

//    AddDomainEvent(new WorkMemberAddedDomainEvent(this.Id, memberId, addedBy));
//    return Result.Ok();
//}

//public Result RemoveWorkMember(MemberId memberId, MemberId removedBy)
//{
//    var workMember = WorkMembers.FirstOrDefault(wm => wm.Member.Id == memberId);
//    if (workMember == null)
//        return Result
//            .Fail(WorkErrors.WorkMemberNotFoundError);

//    WorkMembers.Remove(workMember);
//    AddDomainEvent(new WorkMemberRemovedDomainEvent(Id, memberId, removedBy));
//    return Result.Ok();
//}