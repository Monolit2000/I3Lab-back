using I3Lab.Treatments.Application.Configuration.Commands;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentStageChats.AddChatMemberToAllTreatmentStageChatsByTreatmentId
{
    public class AddChatMemberToAllTreatmentStageChatsByTreatmentIdCommand : InternalCommandBase
    {
        public MemberId MemberId { get; set; }

        public TreatmentId TreatmentId { get; set; }

        public AddChatMemberToAllTreatmentStageChatsByTreatmentIdCommand(
            MemberId memberId,
            TreatmentId treatmentId)
        {
            MemberId = memberId;
            TreatmentId = treatmentId;
        }
    }
}
