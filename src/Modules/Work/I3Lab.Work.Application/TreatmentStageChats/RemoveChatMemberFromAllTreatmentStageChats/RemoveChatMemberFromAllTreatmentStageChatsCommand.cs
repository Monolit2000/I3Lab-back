using I3Lab.Treatments.Application.Configuration.Commands;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using MassTransit.Testing;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
