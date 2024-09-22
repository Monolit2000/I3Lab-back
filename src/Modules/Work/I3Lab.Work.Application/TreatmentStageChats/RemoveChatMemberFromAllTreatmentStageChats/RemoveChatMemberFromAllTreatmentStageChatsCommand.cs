using I3Lab.Treatments.Application.Configuration.Commands;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;

namespace I3Lab.Works.Application.TreatmentStageChats.RemoveChatMemberWithAllChats
{
    public class RemoveChatMemberFromAllTreatmentStageChatsCommand : InternalCommandBase
    {
        public MemberId MemberId {  get; set; }

        public TreatmentId TreatmentId {  get; set; }

        public RemoveChatMemberFromAllTreatmentStageChatsCommand(
            MemberId memberId,
            TreatmentId treatmentId)
        {
            MemberId = memberId;
            TreatmentId = treatmentId;
        }
    }
}
