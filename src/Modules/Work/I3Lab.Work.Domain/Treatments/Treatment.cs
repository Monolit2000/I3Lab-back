using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.TreatmentInvites;
using I3Lab.Works.Domain.Treatments.Events;
using I3Lab.Works.Domain.Works;

namespace I3Lab.Works.Domain.Treatments
{
    public class Treatment : Entity, IAggregateRoot
    {

        public readonly List<Work> TreatmentStages = [];

        public readonly List<Member> members = [];
        public MemberId CreatorId { get; private set; }
        public MemberId PatientId { get; private set; }

        public TreatmentId Id { get; private set; }
        public string Titel { get; private set; }
        public BlobFileId TreatmentPreview { get; private set; }
        public DateTime CreateDate { get; private set; }

        private Treatment() { } // For Ef Core

        private Treatment(MemberId creatorId, MemberId patientId, string name)
        {
            Id = new TreatmentId(Guid.NewGuid());
            CreatorId = creatorId;
            PatientId = patientId;
            CreateDate = DateTime.UtcNow;
            Titel = name;

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

        public TreatmentInvite Invite(Member memberToInvite, Member inviter)
        {
            return TreatmentInvite.InviteBasedOnTreatment(this , memberToInvite, inviter).Value;
        }

        public async Task<Result<Work>> CreateWork(Member creator)
        {
            return await Work.CreateBasedOnTreatmentAsync(creator, this);

        }

        public void RemuveTreatmentStage(MemberId creatorId, WorkId workId)
        {
            var treatmentStages = TreatmentStages.FirstOrDefault(ts => ts.Id == workId);
            if (treatmentStages == null) 
                throw new InvalidOperationException("MemberToInvite not found.");

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
            var treatmentPreview = fileId; //TreatmentPreview.CreateBaseOnWork(this.Id, fileId);

            TreatmentPreview = treatmentPreview;
        }
    }
}
