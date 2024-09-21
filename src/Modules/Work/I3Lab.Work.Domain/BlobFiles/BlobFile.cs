using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.BlobFiles.Events;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages;

namespace I3Lab.Treatments.Domain.BlobFiles
{
    public class BlobFile : Entity, IAggregateRoot 
    {
        public TreatmentStageId TreatmentStageId { get; private set; }
        public TreatmentId TreatmentId { get; private set; }

        public BlobFileId Id { get; private set; }
        public BlobFileType FileType { get; private set; }
        public ContentType ContentType { get; private set; }
        public Accessibilitylevel Accessibilitylevel { get; private set; }
        public BlobFileUrl Url { get; private set; }
        public BlobFilePath Path { get; private set; }
        public DateTime CreateDate { get; private set; }

        private BlobFile() { } //For EF core 

        
        private BlobFile(
            TreatmentId treatmentId,
            TreatmentStageId workId,
            ContentType contentType,
            BlobFileUrl url,
            BlobFileType type)
        {
            Id = new BlobFileId(Guid.NewGuid());
            TreatmentId = treatmentId;
            TreatmentStageId = workId;
            FileType = type;
            ContentType = contentType;
            Url = url;
            CreateDate = DateTime.UtcNow;
            Path = BlobFilePath.Create("undefine", Id.Value.ToString()).Value;
            Accessibilitylevel = Accessibilitylevel.Hot;
            AddDomainEvent(new BlobFileCreatedDomainEvent());
        }

        public static BlobFile CreateBaseOnTreatmentStage(TreatmentId treatmentId, TreatmentStageId treatmentStageId, BlobFileUrl url, ContentType ContentType, BlobFileType type)
            => new BlobFile(treatmentId, treatmentStageId, ContentType, url, type);


        public void RestoreToHotAccessibilitylevel()
        {
            Accessibilitylevel = Accessibilitylevel.Hot;

            AddDomainEvent(new RestoredToHotAccessibilitylevelDomainEvent());
        }

        public void RestoreToCoolAccessibilitylevel()
        {
            Accessibilitylevel = Accessibilitylevel.Cool;

            AddDomainEvent(new RestoredToCoolAccessibilitylevelDomainEvent());
        }

        public void RestoreToColdAccessibilitylevel()
        {
            Accessibilitylevel = Accessibilitylevel.Cold;

            AddDomainEvent(new RestoredToColdAccessibilitylevelDomainEvent());
        }

        public void RestoreToArchiveAccessibilitylevel()
        {
            Accessibilitylevel = Accessibilitylevel.Archive;

            AddDomainEvent(new RestoredToArchiveAccessibilitylevelDomainEvent());
        }
    }
}
