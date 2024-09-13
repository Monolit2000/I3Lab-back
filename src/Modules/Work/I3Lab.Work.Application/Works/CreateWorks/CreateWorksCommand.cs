using FluentResults;
using I3Lab.Works.Application.Configuration.Commands;
using I3Lab.Works.Application.Contract;


namespace I3Lab.Works.Application.Works.CreateWorks
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
