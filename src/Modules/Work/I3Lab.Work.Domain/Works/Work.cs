using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatment;
using I3Lab.Works.Domain.WorkAccebilitys;
using I3Lab.Works.Domain.Works.Events;

namespace I3Lab.Works.Domain.Works
{
    public class Work : Entity, IAggregateRoot
    {
        public TreatmentId TreatmentId { get; private set; }

        public string TreatmentName { get; private set; }

        public WorkDirectory WorkDirectory { get; private set; }

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

            AddDomainEvent(new WorkCreatedDomainEvent(Id));
        }

        public static Work CreateNewWork(
            MemberId creatorId, 
            TreatmentId treatmentId,
            WorkAccebility workAccebilityId)
        {
            return new Work(
                creatorId,
                treatmentId);
        }

        public Result AddWorkMember(MemberId memberId, MemberId addedBy)
        {
            var addeder = WorkMembers.FirstOrDefault(a => a.MemberId == addedBy);
            if (addeder == null)
                return Result
                    .Fail("The member adding the new work member is not present in the work members list");

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
                    .Fail("The member to be removed is not present in the work members list");

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
            var addeder = WorkMembers.FirstOrDefault(a => a.MemberId == addedBy);
            if (addeder == null)
                return Result
                    .Fail("The member adding the new work member is not present in the work members list");

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
    }
}
