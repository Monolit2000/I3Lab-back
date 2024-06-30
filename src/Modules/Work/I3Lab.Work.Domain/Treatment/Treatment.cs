using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Members;
using I3Lab.Work.Domain.Treatment.Events;
using I3Lab.Work.Domain.Work;
using I3Lab.Work.Domain.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.Treatment
{
    public class Treatment : Entity, IAggregateRoot
    {
        public MemberId CustomerId { get; private set; }    

        public TreatmentId Id { get; private set; }
        public MemberId CreatorId { get; private set; }  

        public List<TreatmentStage> TreatmentStages = [];
        public DateTime CreateDate { get; private set; }

        private Treatment() { } // For Ef Core

        private Treatment(MemberId creatorId)
        {
            Id = new TreatmentId(Guid.NewGuid());
            CreatorId = creatorId;
            CreateDate = DateTime.UtcNow;

            AddDomainEvent(new NewTreatmentStageCreatedDomainEvent());
        }

        internal static Treatment CreateNew(MemberId creatorId)
        {
            return new Treatment(creatorId); 
        }

        public void CreateNewTreatmentStage(MemberId creatorId, WorkId workId)
        {
            var newTreatmentStage = TreatmentStage.CreateNew(this.Id, workId);
            TreatmentStages.Add(newTreatmentStage);

            AddDomainEvent(new NewTreatmentStageCreatedDomainEvent());
        }

        public void RemuveTreatmentStage(MemberId creatorId, WorkId workId)
        {
            var Work = TreatmentStages.FirstOrDefault(ts => ts.WorkId == workId);
            if (Work == null) 
                throw new InvalidOperationException("Member not found.");

            TreatmentStages.Remove(Work);
            AddDomainEvent(new TreatmentRemuveWorkDomainEvent());
        }

        public void AddCustomer(MemberId customerId)
        {
            CustomerId = customerId;
            AddDomainEvent(new AddedCustomerToTreatmentDomainEvent());
        }
    }
}
