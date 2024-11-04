using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentFiles;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.UnitTests
{
    public class TreatmentTestsBase
    {
        protected class TreatmentTestDataOptions
        {
            public Member Creator { get; set; }
            public Member Patient { get; set; }
            public string Titel { get; set; } = "Test Treatment";
            public List<Member> ChatMembers { get; set; } = new List<Member>();

            public List<Message> ChatMessage { get; set; } = [];
        }

        protected class TreatmentTestData
        {
            public Treatment Treatment { get; }
            public TreatmentStage TreatmentStage { get; }
            public TreatmentFile TreatmentFile { get; }
            public TreatmentStageChat TreatmentStageChat { get; }

            public TreatmentTestData(Treatment treatment, TreatmentStage treatmentStage, TreatmentFile treatmentFile, TreatmentStageChat treatmentStageChat)
            {
                Treatment = treatment;
                TreatmentStage = treatmentStage;
                TreatmentFile = treatmentFile;
                TreatmentStageChat = treatmentStageChat;
            }
        }

        protected TreatmentTestData CreateTreatmentTestData(TreatmentTestDataOptions options)
        {
            var creator = options.Creator ?? Member.Create(new MemberId(Guid.NewGuid()), "Doctor");
            var patient = options.Patient ?? Member.Create(new MemberId(Guid.NewGuid()), "Patient");

            // Створення Treatment
            var treatment = Treatment.CreateNew(creator, patient, TreatmentTitel.Create(options.Titel));

            // Створення TreatmentStage
            var treatmentStage = treatment
                .CreateTreatmentStage(creator, TreatmentStageTitel.Create("Initial Stage"))
                .Value;

            // Створення TreatmentFile
            var treatmentFile = TreatmentFile.CreateBaseOnTreatmentStage(treatment.Id, treatmentStage.Id, new ContentType("application/pdf"), BlobFileUrl.Create("http://example.com/file"), 32.0);

            // Створення TreatmentStageChat
            var treatmentStageChat = TreatmentStageChat.CreateBaseOnTreatmentStage(treatment.Id, treatmentStage.Id, options.ChatMembers);

            return new TreatmentTestData(treatment, treatmentStage, treatmentFile, treatmentStageChat);
        }
    }
}
