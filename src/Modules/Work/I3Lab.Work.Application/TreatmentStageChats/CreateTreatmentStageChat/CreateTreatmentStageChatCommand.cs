using I3Lab.Treatments.Application.Configuration.Commands;

namespace I3Lab.Treatments.Application.TreatmentStageChats.CreatetreatmentStageChat
{
    public class CreateTreatmentStageChatCommand : InternalCommandBase
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
