using FluentResults;
using I3Lab.Treatments.Application.Configuration.Commands;
using I3Lab.Treatments.Application.Contract;


namespace I3Lab.Treatments.Application.Works.CreateWorks
{
    public class CreateWorksCommand : InternalCommandBase
    {
        public Guid TreatmentId {  get; set; }

        public Guid CreatorId { get; set; }

        public CreateWorksCommand(Guid treatmentId, Guid creatorId)
        {
            TreatmentId = treatmentId;
            CreatorId = creatorId;
        }
    }
}
