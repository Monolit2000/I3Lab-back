using I3Lab.Treatments.Application.Configuration.Commands;
using MediatR;

namespace I3Lab.Treatments.Application.TreatmentStageChats.CreatetreatmentStageChat
{
    public class CreateTreatmentStageChatCommand : IRequest
    {
        public Guid TreatmentStageId { get; }
        public Guid TreatmentId { get; }

        public CreateTreatmentStageChatCommand(
            Guid treatmentStageId, 
            Guid treatmentId )
        {
            TreatmentStageId = treatmentStageId;
            TreatmentId = treatmentId;
        }
    }
}
