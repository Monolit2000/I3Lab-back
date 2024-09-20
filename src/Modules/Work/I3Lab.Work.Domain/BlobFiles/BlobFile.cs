using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.BlobFiles.Events;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages;

namespace I3Lab.Treatments.Domain.BlobFiles
{
    public class BlobFile : Entity, IAggregateRoot 
    {
        public TreatmentStageId WorkId { get; private set; }

        //public TreatmentId TreatmentId { get; private set; }
 
        public BlobFileId Id { get; private set; }
        public BlobFileType FileType { get; private set; }
        public ContentType ContentType { get; private set; }
        public Accessibilitylevel Accessibilitylevel { get; private set; }
        public string BlobName { get; private set; }
        public string FileName { get; private set; }
        public string BlobDirectoryName { get; private set; }
        public BlobFileUrl Url { get; private set; }
        public BlobFilePath Path { get; private set; }
        public DateTime CreateDate { get; private set; }

        private BlobFile() { } //For EF core 

        private BlobFile(
            TreatmentStageId workId,
            string fileName,
            ContentType contentType,
            BlobFileType type)
        {
            WorkId = workId;
            Id = new BlobFileId(Guid.NewGuid());
            FileName = fileName;
            FileType = type;
            ContentType = contentType;
            CreateDate = DateTime.UtcNow;
            Path = BlobFilePath.Create("undefine", Id.Value.ToString());
            Accessibilitylevel = Accessibilitylevel.Hot;
            AddDomainEvent(new BlobFileCreatedDomainEvent());
        }

        public static BlobFile CreateBaseOnWork(TreatmentStageId workId, string fileName, ContentType ContentType, BlobFileType type)
            => new BlobFile(workId, fileName, ContentType, type);


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
