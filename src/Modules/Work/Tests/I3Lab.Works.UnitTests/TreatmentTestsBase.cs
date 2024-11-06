using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentFiles;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentInvites;

namespace I3Lab.Treatments.UnitTests
{
    public class TreatmentTestsBase
    {
        protected class TreatmentTestDataOptions
        {
            public Member Creator { get; set; }
            public Member Patient { get; set; }
            public string Titel { get; set; } = "Test Treatment";

            public Member Inviter { get; set; }
            public Member Invitee { get; set; }

            public List<Member> ChatMembers { get; set; } = new List<Member>();

            public List<Message> ChatMessage { get; set; } = [];
        }

        protected class TreatmentTestData
        {
            public Treatment Treatment { get; }
            public TreatmentStage TreatmentStage { get; }
            public TreatmentFile TreatmentFile { get; }
            public TreatmentStageChat TreatmentStageChat { get; }
            public TreatmentInvite TreatmentInvite { get; }

            public TreatmentTestData(
                Treatment treatment, 
                TreatmentStage treatmentStage, 
                TreatmentFile treatmentFile, 
                TreatmentStageChat treatmentStageChat,
                TreatmentInvite treatmentInvite)
            {
                Treatment = treatment;
                TreatmentStage = treatmentStage;
                TreatmentFile = treatmentFile;
                TreatmentStageChat = treatmentStageChat;
                TreatmentInvite = treatmentInvite;
            }
        }

        protected TreatmentTestData CreateTreatmentTestData(TreatmentTestDataOptions options)
        {
            // Treatment
            var creator = options.Creator ?? Member.Create(new MemberId(Guid.NewGuid()), "Doctor");
            var patient = options.Patient ?? Member.Create(new MemberId(Guid.NewGuid()), "Patient");
            var treatment = Treatment.CreateNew(creator, patient, TreatmentTitel.Create(options.Titel));

            // TreatmentStage
            var treatmentStage = treatment
                .CreateTreatmentStage(creator, TreatmentStageTitel.Create("Initial Stage"))
                .Value;

            // TreatmentFile
            var treatmentFile = TreatmentFile.CreateBaseOnTreatmentStage(treatment.Id, treatmentStage.Id, new ContentType("application/pdf"), BlobFileUrl.Create("http://example.com/file"), 32.0);

            //TreatmentStageChat
            var treatmentStageChat = TreatmentStageChat.CreateBaseOnTreatmentStage(treatment.Id, treatmentStage.Id, options.ChatMembers);

            //TreatmentInvite
            var inviter = options.Inviter ?? CreateMember();
            var invitee = options.Invitee ?? CreateMember();
            var treatmentInvite = treatment.Invite(inviter, invitee);

            return new TreatmentTestData(treatment, treatmentStage, treatmentFile, treatmentStageChat, treatmentInvite);
        }

        protected Member CreateMember()
        {
            var member = Member.Create(new MemberId(Guid.NewGuid()), $"TestEmail{Guid.NewGuid().ToString()}@gmail.com");
            return member;
        }
    }
}
