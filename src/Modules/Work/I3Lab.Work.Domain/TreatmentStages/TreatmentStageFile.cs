using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.BlobFiles;


namespace I3Lab.Treatments.Domain.TreatmentStages
{
    public class TreatmentStageFile : Entity
    {
        public TreatmentStageId WorkId { get; private set; }
        public BlobFile File { get; private set; }

        public DateTime CreateDate { get; private set; }

        private TreatmentStageFile() { } //For EF CORE 

        private TreatmentStageFile(
            TreatmentStageId workId, 
            BlobFile file)
        {
            WorkId = workId;    
            File = file;

            CreateDate = DateTime.UtcNow;
        }

        internal static TreatmentStageFile CreateNew(TreatmentStageId workId, BlobFile fileId)
        {
            return new TreatmentStageFile(workId, fileId);
        }
    }
}
