using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Works;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace I3Lab.Works.Domain.Treatment
{
    public class TreatmentStage : Entity
    {
        public WorkId Id { get; private set; }  

        public TreatmentId TreatmentId {  get; private set; }   

        private TreatmentStage() { } //For Ef core

        private TreatmentStage(
            TreatmentId treatmentId,
            WorkId workId)
        {
            Id = workId;    
            TreatmentId = treatmentId;
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