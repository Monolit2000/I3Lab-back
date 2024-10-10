using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.TreatmentFiles;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages.Errors;
using I3Lab.Treatments.Domain.TreatmentStages.Events;
using I3Lab.Treatments.Domain.TreatmentStages;
using System.Data;

namespace I3Lab.Treatments.Domain.TreatmentStages
{
    public class TreatmentStage : Entity, IAggregateRoot
    {
        public TreatmentId TreatmentId { get; private set; }
        public Member Creator { get; private set; }

        public readonly List<TreatmentStageFile> TreatmentStageFiles = [];
        public TreatmentStageId Id { get; private set; }
        public TreatmentStageTitel Titel { get; private set; }
        public TreatmentStageFile TreatmentStageAvatarImage  { get; private set; }
        public TreatmentStageStatus TreatmentStageStatus { get; private set; }
        public TreatmentStageDate TreatmentStageDate { get; private set; }

        private TreatmentStage() { } //for Ef core

        private TreatmentStage(
            Member creatorId,
            TreatmentId treatment,
            TreatmentStageTitel workTitel)
        {
            Id = new TreatmentStageId(Guid.NewGuid());
            Creator = creatorId;
            TreatmentId = treatment;
            Titel = workTitel;
            TreatmentStageDate = TreatmentStageDate.Start();
            TreatmentStageStatus = TreatmentStageStatus.Pending;

            AddDomainEvent(new WorkCreatedDomainEvent(Id, TreatmentId));
        }

        public static Task<Result<TreatmentStage>> CreateBasedOnTreatmentAsync(
            Member creator,
            TreatmentId treatment,
            TreatmentStageTitel workTitel)
        {
            if (!IsMemberRoleValid(creator))
                return Task.FromResult(Result.Fail<TreatmentStage>(WorkErrors.MemberNotHaveRequiredRole));

            var treatmentStage = new TreatmentStage(creator, treatment, workTitel);
            return Task.FromResult(Result.Ok(treatmentStage));
        }

        public TreatmentFile CreateTreatmentStageFile(BlobFileUrl url, ContentType contentType, BlobFileType fileType) 
            => TreatmentFile.CreateBaseOnTreatmentStage(this.TreatmentId, this.Id, contentType, url, 32);

        public TreatmentStageChat CreateTreatmentStageChat(List<Member> members) 
            => TreatmentStageChat.CreateBaseOnTreatmentStage(this.TreatmentId, this.Id, members);

        public void AddWorkFile(TreatmentStageId workId, TreatmentFile fileId)
        {
            var newWorkFile = TreatmentStageFile.CreateNew(workId, fileId);
            TreatmentStageFiles.Add(newWorkFile);
        }

        public void SetWorkAvatarImage(TreatmentStageFile workFile)
        {
            TreatmentStageAvatarImage = workFile;
            AddDomainEvent(new WorkAvatarImageSetDomainEvent(workFile));
        }

        public Result Close()
        {
            TreatmentStageStatus = TreatmentStageStatus.Closed;

            AddDomainEvent(new TreatmentStageClosedDomainEvent(Id));
            return Result.Ok();
        }


        public Result ChangeStatus(TreatmentStageStatus newStatus)
        {
            if (TreatmentStageStatus == newStatus)
                return Result.Ok(); 

            TreatmentStageStatus = newStatus;
            AddDomainEvent(new WorkStatusChangedDomainEvent(Id, newStatus));
            return Result.Ok();
        }

        private static bool IsMemberRoleValid(Member creator)
        {
            return true; /*creator.MemberRole == MemberRole.Doctor || creator.MemberRole == MemberRole.Admin;*/
        }

    }
}
//private bool IsWorkMamberIdContainInWorkMembersList(MemberId memberId)
//{
//    var workMember = TreatmentAccebilityMembers.FirstOrDefault(wm => wm.Member.Id == memberId);

//    if (workMember == null)
//      return false;

//    return true;    
//}

//public Result AddWorkMember(Member memberId, Member addedBy)
//{
//    if(IsWorkMamberIdContainInWorkMembersList(addedBy.Id))
//        return Result.Fail(WorkErrors.WorkMemberNotFoundError);

//    var newWorkMember = WorkMember.CreateBaseOnTreatmentStage(this.Id, memberId, addedBy);
//    TreatmentAccebilityMembers.Add(newWorkMember);

//    AddDomainEvent(new WorkMemberAddedDomainEvent(this.Id, memberId, addedBy));
//    return Result.Ok();
//}

//public Result RemoveWorkMember(MemberId memberId, MemberId removedBy)
//{
//    var workMember = TreatmentAccebilityMembers.FirstOrDefault(wm => wm.Member.Id == memberId);
//    if (workMember == null)
//        return Result
//            .Fail(WorkErrors.WorkMemberNotFoundError);

//    TreatmentAccebilityMembers.Remove(workMember);
//    AddDomainEvent(new WorkMemberRemovedDomainEvent(Id, memberId, removedBy));
//    return Result.Ok();
//}