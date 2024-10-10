using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.TreatmentFiles;


namespace I3Lab.Treatments.Domain.TreatmentStages
{
    public class TreatmentStageFile : Entity
    {
        public TreatmentStageId TreatmentStageId { get; private set; }
        public TreatmentFile File { get; private set; }
        public DateTime CreateDate { get; private set; }

        private TreatmentStageFile() { } //For EF CORE 

        private TreatmentStageFile(
            TreatmentStageId workId, 
            TreatmentFile file)
        {
            TreatmentStageId = workId;    
            File = file;

            CreateDate = DateTime.UtcNow;
        }

        internal static TreatmentStageFile CreateNew(TreatmentStageId workId, TreatmentFile fileId)
        {
            return new TreatmentStageFile(workId, fileId);
        }
    }
}
