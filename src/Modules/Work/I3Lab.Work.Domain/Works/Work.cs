using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Members;
using I3Lab.Work.Domain.Treatment;
using I3Lab.Work.Domain.WorkAccebilitys;
using I3Lab.Work.Domain.WorkCatalogs;
using I3Lab.Work.Domain.WorkComments;
using I3Lab.Work.Domain.Works;
using I3Lab.Work.Domain.Works.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.Works
{
    public class Work : Entity, IAggregateRoot
    {
        public TreatmentId TreatmentId { get; private set; }
        public WorkAccebilityId WorkAccebilityId { get; private set; }
        public WorkCatalogId WorkCatalogId { get; private set; }

        public readonly List<WorkFile> WorkFiles = [];

        public WorkId Id { get; private set; }
        public WorkFile WorkAvatarImage  { get; private set; }
        public MemberId CustomerId { get; private set; }
        public WorkStatus Status { get; private set; }
        public MemberId CreatorId { get; private set; }
        public DateTime WorkStartedDate { get; private set; }   

        private Work()
        {
            //Ef core
        }
        private Work(
            MemberId creatorId,
            TreatmentId treatmentId,
            WorkAccebilityId workAccebilityId)
        {
            Id = new WorkId(Guid.NewGuid());
            Status = WorkStatus.Pending;
            CreatorId = creatorId;
            TreatmentId = treatmentId;  
            WorkAccebilityId = workAccebilityId;
            WorkStartedDate = DateTime.UtcNow;

            AddDomainEvent(new WorkCreatedDomainEvent(Id));
        }

        public static Work CreateNewWork(
            MemberId creatorId, 
            TreatmentId treatmentId, 
            WorkAccebilityId workAccebilityId)
        {
            return new Work(
                creatorId, 
                treatmentId, 
                workAccebilityId);
        }

        public void AddWorkFile(WorkFile workFile)
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

        public void ChangeStatus(WorkStatus newStatus)
        {
            Status = newStatus;
        }
    }
}
