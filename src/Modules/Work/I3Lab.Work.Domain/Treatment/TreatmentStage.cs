using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Work;
using I3Lab.Works.Domain.Works;
using System.Diagnostics;

namespace I3Lab.Works.Domain.Treatment
{
    public class TreatmentStage : Entity
    {
        public TreatmentId TreatmentId {  get; private set; }   

        public WorkId WorkId { get; private set; }  

        private TreatmentStage() { } //For Ef core

        private TreatmentStage(
            TreatmentId treatmentId,
            WorkId workId)
        {
            TreatmentId = treatmentId;
            WorkId = workId;    
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