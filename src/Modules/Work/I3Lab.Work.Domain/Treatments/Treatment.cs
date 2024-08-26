using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.TreatmentInvites;
using I3Lab.Works.Domain.Treatments.Events;
using I3Lab.Works.Domain.WorkCatalogs.Events;
using I3Lab.Works.Domain.Works;

namespace I3Lab.Works.Domain.Treatments
{
    public class Treatment : Entity, IAggregateRoot
    {

        public readonly List<Work> TreatmentStages = [];

        public TreatmentId Id { get; private set; }
        public MemberId CreatorId { get; private set; }
        public MemberId PatientId { get; private set; }
        public string Name { get; private set; }
        public BlobFileId TreatmentPreview { get; private set; }

        public DateTime CreateDate { get; private set; }

        private Treatment() { } // For Ef Core

        private Treatment(MemberId creatorId, MemberId patientId, string name)
        {
            Id = new TreatmentId(Guid.NewGuid());
            CreatorId = creatorId;
            PatientId = patientId;
            CreateDate = DateTime.UtcNow;
            Name = name;

            AddDomainEvent(new TreatmentCreatedDomainEvent());
        }

        public static Treatment CreateNew(
            MemberId creatorId,
            MemberId patientId,
            string name)
        {
            return new Treatment(
                creatorId,
                patientId,
                name);
        }

        public TreatmentInvite Invite(Member member)
        {
            return TreatmentInvite.InviteBasedOnTreatment(this ,member).Value;
        }

        public async Task<Result<Work>> CreateNewTreatmentStage(Member creator)
        {
            //var newTreatmentStage = TreatmentStage.CreateNew(this.Id, workId);

            //TreatmentStages.Add(newTreatmentStage);

            var workResult = await Work.CreateBasedOnTreatmentAsync(creator, Id);

            return workResult;

            //AddDomainEvent(new NewTreatmentStageCreatedDomainEvent());
        }

        public void RemuveTreatmentStage(MemberId creatorId, WorkId workId)
        {
            var treatmentStages = TreatmentStages.FirstOrDefault(ts => ts.Id == workId);
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

        public void AddPreview(BlobFileId fileId)
        {
            var treatmentPreview = fileId; //TreatmentPreview.CreateNew(this.Id, fileId);

            TreatmentPreview = treatmentPreview;
        }
    }
}
