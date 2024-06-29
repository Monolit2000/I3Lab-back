using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Work;
using System.Diagnostics;

namespace I3Lab.Work.Domain.Treatment
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

        internal static TreatmentStage CreateNew(
            TreatmentId treatmentId, 
            WorkId workId) 
        { 
            return new TreatmentStage(
                treatmentId, 
                workId); 
        } 
    }
}