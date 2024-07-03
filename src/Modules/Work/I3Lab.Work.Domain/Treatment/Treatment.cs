using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Files;
using I3Lab.Work.Domain.Members;
using I3Lab.Work.Domain.Treatment.Events;
using I3Lab.Work.Domain.Works;

namespace I3Lab.Work.Domain.Treatment
{
    public class Treatment : Entity, IAggregateRoot
    {
        public TreatmentId Id { get; private set; }
        public MemberId CreatorId { get; private set; }  
        public MemberId PatientId { get; private set; }    
        public string Name { get; private set; }

        public List<TreatmentStage> TreatmentStages = [];
        public TreatmentPreview TreatmentPreview { get; private set; }

    public DateTime CreateDate { get; private set; }

        private Treatment() { } // For Ef Core

        private Treatment(MemberId creatorId, MemberId patientId, string name)
        {
            Id = new TreatmentId(Guid.NewGuid());
            CreatorId = creatorId;
            PatientId = patientId;
            CreateDate = DateTime.UtcNow;

            AddDomainEvent(new TreatmentCreatedDomainEvent());
        }

        internal static Treatment CreateNew(
            MemberId creatorId, 
            MemberId patientId, 
            string name)
        {
            return new Treatment(
                creatorId, 
                patientId, 
                name); 
        }

        public void CreateNewTreatmentStage(MemberId creatorId, WorkId workId)
        {
            var newTreatmentStage = TreatmentStage.CreateNew(this.Id, workId);
            TreatmentStages.Add(newTreatmentStage);

            AddDomainEvent(new NewTreatmentStageCreatedDomainEvent());
        }

        public void RemuveTreatmentStage(MemberId creatorId, WorkId workId)
        {
            var treatmentStages = TreatmentStages.FirstOrDefault(ts => ts.WorkId == workId);
            if (treatmentStages == null) 
                throw new InvalidOperationException("Member not found.");

            TreatmentStages.Remove(treatmentStages);
            AddDomainEvent(new TreatmentRemuveWorkDomainEvent());
        }

        public void AddPatient(MemberId customerId)
        {
            PatientId = customerId;
            AddDomainEvent(new AddedCustomerToTreatmentDomainEvent());
        }

        public void AddPreview(FileId fileId)
        {
            var treatmentPreview = TreatmentPreview.CreateNew(this.Id, fileId);

            TreatmentPreview = treatmentPreview;
        }
    }
}
