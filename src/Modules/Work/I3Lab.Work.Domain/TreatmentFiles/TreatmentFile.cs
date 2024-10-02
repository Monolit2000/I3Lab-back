using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.WorkCatalogs.Events;

namespace I3Lab.Treatments.Domain.TreatmentFiles
{
    public class TreatmentFile : Entity, IAggregateRoot
    {
        public TreatmentId TreatmentId { get; private set; }
        public TreatmentStageId TreatmentStageId { get; private set; }

        public TreatmentFilesId Id {  get; }   
        public BlobFilePath BlobFilePath { get; private set; }
        public FilePreview FilePreview { get; private set; } 
        public BlobFileType BlobFileType { get; private set; }
        public ContentType ContentType { get; set; }
        public BlobFileUrl Url { get; private set; }
        public double MbSize { get; private set; }
        public DateTime CreateDate { get; private set; }

        public TreatmentFile() { } //For Ef core
        
        private TreatmentFile(
            TreatmentId treatmentId,
            TreatmentStageId treatmentStageId,
            BlobFileType blobFileType,
            BlobFileUrl url,
            double mbSize,
            FilePreview filePreview = null)
        {
            Id = new TreatmentFilesId(Guid.NewGuid());
            TreatmentId = treatmentId;
            TreatmentStageId = treatmentStageId;
            FilePreview = filePreview;
            BlobFileType = blobFileType;
            Url = url;
            CreateDate = DateTime.UtcNow;
            MbSize = mbSize;
        }

        public static TreatmentFile CreateBaseOnTreatmentStage(TreatmentId treatmentId, TreatmentStageId treatmentStageId, BlobFileType type, BlobFileUrl url, double mdSize) 
            => new TreatmentFile(treatmentId, treatmentStageId, type, url, mdSize);

    }
}
