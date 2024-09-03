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
        public Member Creator { get; private set; }
        public Member Patient { get; private set; }

        public TreatmentId Id { get; private set; }
        public Titel Titel { get; private set; }
        public BlobFileId TreatmentPreview { get; private set; }
        public TreatmentDate TreatmentDate { get; private set; }

        private Treatment() { } // For Ef Core

        private Treatment(
            Member creator, 
            Member patient,
            Titel titel)
        {
            Id = new TreatmentId(Guid.NewGuid());
            Creator = creator;
            Patient = patient;
            Titel = titel;
            TreatmentDate = TreatmentDate.Start();

            AddDomainEvent(new TreatmentCreatedDomainEvent(
                creator.Id.Value, 
                Id.Value));
        }

        public static Treatment CreateNew(
            Member creator,
            Member patient,
            Titel titel)
        {
            return new Treatment(
                creator,
                patient,
                titel);
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
                throw new InvalidOperationException("Member to invite not found.");

            TreatmentStages.Remove(treatmentStages);
            AddDomainEvent(new TreatmentRemuveWorkDomainEvent());
        }

        public void AddPatient(Member customer)
        {
            Patient = customer;
            AddDomainEvent(new AddedCustomerToTreatmentDomainEvent());
        }

        public void AddPreview(BlobFileId fileId)
        {
            var treatmentPreview = fileId; //TreatmentPreview.CreateBaseOnWork(this.Id, fileId);

            TreatmentPreview = treatmentPreview;
        }
    }
}
