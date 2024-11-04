//using I3Lab.BuildingBlocks.Domain;
//using I3Lab.Treatments.Domain.TreatmentStages;
//using System.ComponentModel.DataAnnotations;
//using System.Diagnostics;

//namespace I3Lab.Treatments.Domain.Treatments
//{
//    public class TreatmentStage : Entity
//    {
//        public TreatmentStageId Id { get; private set; }  

//        public TreatmentId TreatmentId {  get; private set; }   

//        private TreatmentStage() { } //For Ef core

//        private TreatmentStage(
//            TreatmentId treatmentId,
//            TreatmentStageId workId)
//        {
//            Id = workId;    
//            TreatmentId = treatmentId;
//        }

//        public static TreatmentStage Create(
//            TreatmentId treatmentId,
//            TreatmentStageId workId)
//        {
//            return new TreatmentStage(
//                treatmentId,
//                workId);
//        }
//    }
//}