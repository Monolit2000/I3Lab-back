using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.TreatmentFiles;
using I3Lab.Treatments.Domain.TreatmentFiles.Events;
using I3Lab.Treatments.Domain.TreatmentFils.Events;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages;

namespace I3Lab.Treatments.Domain.TreatmentFils
{
    public class TreatmentFile : Entity, IAggregateRoot
    {
        public TreatmentId TreatmentId { get; private set; }
        public TreatmentStageId TreatmentStageId { get; private set; }

        public TreatmentFileId Id { get; }
        public BlobFilePath BlobFilePath { get; private set; }
        public FilePreview FilePreview { get; private set; }
        public BlobFileType FileType { get; private set; }
        public ContentType ContentType { get; set; }
        public BlobFileUrl Url { get; private set; }
        public double MbSize { get; private set; }
        public DateTime CreateDate { get; private set; }

        public TreatmentFile() { } //For Ef core

        private TreatmentFile(
            TreatmentId treatmentId,
            TreatmentStageId treatmentStageId,
            ContentType blobFileType,
            BlobFileUrl url,
            double mbSize,
            FilePreview filePreview = null)
        {
            Id = new TreatmentFileId(Guid.NewGuid());
            TreatmentId = treatmentId;
            TreatmentStageId = treatmentStageId;
            FilePreview = filePreview;
            ContentType = blobFileType;
            Url = url;
            CreateDate = DateTime.UtcNow;
            MbSize = mbSize;

            AddDomainEvent(new TreatmentFileCreatedDomainEvent());
        }

        public static TreatmentFile CreateBaseOnTreatmentStage(TreatmentId treatmentId, TreatmentStageId treatmentStageId, ContentType type, BlobFileUrl url, double mdSize)
            => new TreatmentFile(treatmentId, treatmentStageId, type, url, mdSize);

    }
}
