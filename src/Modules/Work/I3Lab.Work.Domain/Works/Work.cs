using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatment;
using I3Lab.Works.Domain.WorkAccebilitys;
using I3Lab.Works.Domain.WorkDirectorys;
using I3Lab.Works.Domain.Works.Events;

namespace I3Lab.Works.Domain.Works
{
    public class Work : Entity, IAggregateRoot
    {
        public TreatmentId TreatmentId { get; private set; }
        public WorkAccebility WorkAccebilityId { get; private set; }
        public WorkDirectoryId WorkCatalogId { get; private set; }

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
            TreatmentId treatmentId,
            WorkAccebility workAccebilityId)
        {
            Id = new WorkId(Guid.NewGuid());
            WorkStatus = WorkStatus.Pending;
            CreatorId = creatorId;
            TreatmentId = treatmentId;  
            WorkAccebilityId = workAccebilityId;
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
                treatmentId, 
                workAccebilityId);
        }
        

        public void AddFile(WorkFile workFile)
        {
            WorkFiles.Add(workFile);
        }

        public void SetWorkAvatarImage(WorkFile workFile)
        {
            WorkAvatarImage = workFile;
            AddDomainEvent(new WorkAvatarImageSetDomainEvent(workFile));
        }

        public void AddCustomerId(MemberId customerId)
        {
            CustomerId = customerId;
            AddDomainEvent(new CustomerAddedDomainEvent(customerId));
        }

        public void ChangeWorkStatus(WorkStatus newStatus)
        {
            WorkStatus = newStatus;
            AddDomainEvent(new WorkStatusChangedDomainEvent(this.Id, newStatus));
        }

        //public void MarkAsActive()
        //{
        //    WorkStatus = WorkStatus.Active;
        //    AddDomainEvent(new Set);
        //}

        
    }
}
