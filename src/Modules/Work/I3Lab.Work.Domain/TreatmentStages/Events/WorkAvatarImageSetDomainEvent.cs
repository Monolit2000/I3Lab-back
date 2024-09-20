using I3Lab.BuildingBlocks.Domain;


namespace I3Lab.Treatments.Domain.TreatmentStages.Events
{
    public class WorkAvatarImageSetDomainEvent : DomainEventBase
    {
        public TreatmentStageFile WorkFile { get; }

        public WorkAvatarImageSetDomainEvent(TreatmentStageFile workFile)
        {
            WorkFile = workFile;
        }
    }
}
