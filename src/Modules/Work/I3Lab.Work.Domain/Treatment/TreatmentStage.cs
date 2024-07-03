using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Treatment.Events;
using I3Lab.Work.Domain.Work;
using I3Lab.Work.Domain.Works;
using System.Diagnostics;

namespace I3Lab.Work.Domain.Treatment
{
    public class TreatmentStage : Entity
    {
        public TreatmentId TreatmentId {  get; private set; }   
        public WorkId WorkId { get; private set; }  

        public DateTime CreateDate { get; private set; }
        private TreatmentStage() { } //For Ef core

        private TreatmentStage(
            TreatmentId treatmentId,
            WorkId workId)
        {
            TreatmentId = treatmentId;
            WorkId = workId;

            AddDomainEvent(new TreatmentStageCreatedDomainEvent());
        }

        public static TreatmentStage CreateNew(
            TreatmentId treatmentId,
            WorkId workId)
        {
            return new TreatmentStage(
                treatmentId,
                workId);
        }
    }
}