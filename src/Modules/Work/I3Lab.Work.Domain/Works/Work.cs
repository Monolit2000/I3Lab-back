using FluentResults;
using I3Lab.Works.Domain.Members;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.Treatments;
using I3Lab.Works.Domain.Works.Errors;
using I3Lab.Works.Domain.Works.Events;

namespace I3Lab.Works.Domain.Works
{
    public class Work : Entity, IAggregateRoot
    {
        public Treatment Treatment { get; private set; }

        public readonly List<WorkFile> WorkFiles = [];

        //public readonly List<WorkMember> WorkMembers = [];

        public WorkId Id { get; private set; }
        public WorkFile WorkAvatarImage  { get; private set; }
        public Member Customer { get; private set; }
        public WorkStatus WorkStatus { get; private set; }
        public Member CreatorId { get; private set; }
        public DateTime WorkStartedDate { get; private set; }   

        private Work() { } //for Ef core

        private Work(
            Member creatorId,
            Treatment treatment)
        {
            Id = new WorkId(Guid.NewGuid());
            WorkStatus = WorkStatus.Pending;
            CreatorId = creatorId;
            Treatment = treatment;  
            WorkStartedDate = DateTime.UtcNow;

            //WorkChat = WorkChat.CreateBaseOnWork(Id, treatment.TreatmentMembers);

            AddDomainEvent(new WorkCreatedDomainEvent(Id, treatment.Id));
        }

        internal static async Task<Result<Work>> CreateBasedOnTreatmentAsync(
            Member creator, 
            Treatment treatment)
        {
            if (!IsMemberRoleValid(creator))
                return Result.Fail(WorkErrors.MemberNotHaveRequiredRole);

            return new Work(
                creator,
                treatment);
        }

        //public BlobFile Create(  )
        //{

        //}

        public void AddWorkFile(WorkId workId, BlobFile fileId)
        {
            var newWorkFile = WorkFile.CreateNew(workId, fileId);
            WorkFiles.Add(newWorkFile);
        }

        public void SetWorkAvatarImage(WorkFile workFile)
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

        public Result ChangeWorkStatus(WorkStatus newStatus)
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