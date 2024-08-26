using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatments;
using I3Lab.Works.Domain.WorkAccebilitys;
using I3Lab.Works.Domain.WorkChats;
using I3Lab.Works.Domain.Works.Errors;
using I3Lab.Works.Domain.Works.Events;
using I3Lab.Works.Domain.Works.Rule;

namespace I3Lab.Works.Domain.Works
{
    public class Work : Entity, IAggregateRoot
    {
        public TreatmentId TreatmentId { get; private set; }

        //public WorkChat WorkChat { get; private set; } 

        public string TreatmentName { get; private set; }

        //public WorkDirectory WorkDirectory { get; private set; }

        public readonly List<WorkFile> WorkFiles = [];

        public readonly List<WorkMember> WorkMembers = [];

        public WorkId Id { get; private set; }
        public WorkFile WorkAvatarImage  { get; private set; }
        public MemberId CustomerId { get; private set; }
        public WorkStatus WorkStatus { get; private set; }
        public MemberId CreatorId { get; private set; }
        public DateTime WorkStartedDate { get; private set; }   

        private Work() { } //for Ef core

        private Work(
            MemberId creatorId,
            TreatmentId treatmentId)
        {
            Id = new WorkId(Guid.NewGuid());
            WorkStatus = WorkStatus.Pending;
            CreatorId = creatorId;
            TreatmentId = treatmentId;  
            WorkStartedDate = DateTime.UtcNow;

            AddDomainEvent(new WorkCreatedDomainEvent(Id, treatmentId));
        }

        public static async Task<Result<Work>> CreateBasedOnTreatmentAsync(
            Member creator, 
            TreatmentId treatmentId)
        {
            if (!IsMemberRoleValid(creator))
                return Result.Fail(WorkErrors.MemberNotHaveRequiredRole);

            return new Work(
                creator.Id,
                treatmentId);
        }

        public Result AddWorkMember(MemberId memberId, MemberId addedBy)
        {
            if(IsWorkMamberIdContainInWorkMembersList(addedBy))
                return Result.Fail(WorkErrors.WorkMemberNotFoundError);

            var newWorkMember = WorkMember.CreateNew(this.Id, memberId, addedBy);
            WorkMembers.Add(newWorkMember);

            AddDomainEvent(new WorkMemberAddedDomainEvent(this.Id, memberId, addedBy));
            return Result.Ok();
        }

        public Result RemoveWorkMember(MemberId memberId, MemberId removedBy)
        {
            var workMember = WorkMembers.FirstOrDefault(wm => wm.MemberId == memberId);
            if (workMember == null)
                return Result
                    .Fail(WorkErrors.WorkMemberNotFoundError);

            WorkMembers.Remove(workMember);
            AddDomainEvent(new WorkMemberRemovedDomainEvent(Id, memberId, removedBy));
            return Result.Ok();
        }

        public void AddWorkFile(WorkId workId, BlobFileId fileId)
        {
            var newWorkFile = WorkFile.CreateNew(workId, fileId);
            WorkFiles.Add(newWorkFile);
        }

        public void SetWorkAvatarImage(WorkFile workFile)
        {
            WorkAvatarImage = workFile;
            AddDomainEvent(new WorkAvatarImageSetDomainEvent(workFile));
        }

        public Result AddCustomerId(MemberId customerId, MemberId addedBy)
        {
            var result = CheckRules(new OnlyExistingWorkMembersCanAddCustomerRule(WorkMembers, addedBy));

            if (result.IsFailed)
                return result;

            var newWorkMember = WorkMember.CreateNew(this.Id, customerId, addedBy);

            WorkMembers.Add(newWorkMember);

            CustomerId = customerId;
            AddDomainEvent(new CustomerAddedDomainEvent(customerId));

            return Result.Ok();
        }

        public Result ChangeWorkStatus(WorkStatus newStatus)
        {
            if (WorkStatus == newStatus)
                return Result.Ok(); 

            WorkStatus = newStatus;
            AddDomainEvent(new WorkStatusChangedDomainEvent(Id, newStatus));
            return Result.Ok();
        }


        private bool IsWorkMamberIdContainInWorkMembersList(MemberId memberId)
        {
            var workMember = WorkMembers.FirstOrDefault(wm => wm.MemberId == memberId);

            if (workMember == null)
              return false;

            return true;    
        }

        private static bool IsMemberRoleValid(Member creator)
        {
            return creator.MemberRole == MemberRole.Doctor || creator.MemberRole == MemberRole.Admin;
        }

    }
}
