using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.BlobFiles;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.TreatmentInvites;
using I3Lab.Treatments.Domain.Treatments.Errors;
using I3Lab.Treatments.Domain.Treatments.Events;
using I3Lab.Treatments.Domain.Treatments.Rules;

namespace I3Lab.Treatments.Domain.Treatments
{
    public class Treatment : Entity, IAggregateRoot
    {
        public Member Creator { get; private set; }
        public Member Patient { get; private set; }

        public readonly List<TreatmentMember> TreatmentMembers = [];

        public TreatmentId Id { get; }
        public TreatmentTitel Titel { get; private set; }
        public BlobFile TreatmentPreview { get; private set; }
        public TreatmentDate TreatmentDate { get; private set; }
        public TreatmentStatus Status { get; private set; }
        public InvitationToken InvitationToken { get; private set; }

        public static Treatment CreateNew(Member creator, Member patient, TreatmentTitel titel)
            => new Treatment(creator, patient, titel);

        private Treatment() { } // For EF Core

        private Treatment(
            Member creator,
            Member patient,
            TreatmentTitel titel)
        {
            Id = new TreatmentId(Guid.NewGuid());
            Creator = creator;
            Patient = patient;
            Titel = titel;
            TreatmentDate = TreatmentDate.Start();
            Status = TreatmentStatus.Active;
            InvitationToken = InvitationToken.Generate();

            TreatmentMembers.Add(TreatmentMember.CreateNew(Id, creator, TreatmentMemberRole.Doctor));

            TreatmentMembers.Add(TreatmentMember.CreateNew(Id, patient, TreatmentMemberRole.Patient));

            AddDomainEvent(new TreatmentCreatedDomainEvent(creator.Id.Value, Id.Value));
        }

        public TreatmentInvite Invite(Member memberToInvite, Member inviter) 
            => TreatmentInvite.InviteBasedOnTreatment(this, memberToInvite, inviter).Value;

        public async Task<Result<TreatmentStage>> CreateTreatmentStageAsync(Member creator, TreatmentStageTitel stageTitel)
            => await TreatmentStage.CreateBasedOnTreatmentAsync(creator, this.Id, stageTitel);


        public Result AddToTreatmentMembers(Member member)
        {
            var result = CheckRule(new MemberMustNotBeInTreatmentRule(TreatmentMembers, member.Id));
            if (result.IsFailed)
                return result;

            var treatmentMember = TreatmentMember.CreateNew(this.Id, member, TreatmentMemberRole.Doctor);
            TreatmentMembers.Add(treatmentMember);

            return Result.Ok();
        }

        public Result RemoveTreatmentMember(MemberId memberId, MemberId removingMemberId)
        {
            var treatmentMember = TreatmentMembers.FirstOrDefault(member => member.Member.Id == memberId);

            if (treatmentMember == null)
                return Result.Fail(TreatmentErrors.MemberNotFound);

            treatmentMember.Leave();
            TreatmentMembers.Remove(treatmentMember);
            AddDomainEvent(new MemberRemovedFromTreatmentDomainEvent(Id, treatmentMember.Member.Id));

            return Result.Ok();
        }

        public Result ValidateInviteToken(string token)
        {
            var result = CheckRule(new InviteTokenMustExistRule(InvitationToken));
            if (result.IsFailed)
                return result;

            return InvitationToken.Validate(token);
        }

        public string GetInvitationToken(TimeSpan linkLifetime = default)
        {
            if (InvitationToken == null || InvitationToken.IsExpired())
                InvitationToken = InvitationToken.Generate(linkLifetime);
            
            return InvitationToken.Token;
        }

        public Result Cancel()
        {
            var result = CheckRules(
              new TreatmentMustNotBeFinishedRule(Status),
              new TreatmentMustNotBeCanceledRule(Status));
            if (result.IsFailed)
                return result;

            Status = TreatmentStatus.Canceled;
            AddDomainEvent(new TreatmentCanceledDomainEvent(Id.Value, DateTime.UtcNow));

            return Result.Ok();
        }

        public Result Finish()
        {
            var result = CheckRule(new TreatmentMustNotBeCanceledRule(Status));
            if (result.IsFailed)
                return result;

            result = TreatmentDate.End();
            if (result.IsFailed)
                return result;

            Status = TreatmentStatus.Finished;
            AddDomainEvent(new TreatmentFinishedDomainEvent(Id.Value, TreatmentDate.TreatmentFinished));

            return Result.Ok();
        }

        public void AddPreview(BlobFile fileId)
        {
            TreatmentPreview = fileId;
        }
    }
}

