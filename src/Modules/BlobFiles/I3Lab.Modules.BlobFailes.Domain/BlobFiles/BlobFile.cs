using I3Lab.BuildingBlocks.Domain;
using I3Lab.Modules.BlobFailes.Domain.BlobFiles.Events;

namespace I3Lab.Modules.BlobFailes.Domain.BlobFiles
{
    public class BlobFile : Entity, IAggregateRoot
    {
        public BlobFileId Id { get; private set; }
        public BlobFileType FileType { get; private set; }
        public ContentType ContentType { get; private set; }
        public Accessibilitylevel Accessibilitylevel { get; private set; }
        public BlobFileUrl Url { get; private set; }
        public BlobFilePath Path { get; private set; }
        public DateTime CreateDate { get; private set; }

        private BlobFile() { } //For EF core 

        private BlobFile(
            ContentType contentType,
            BlobFileUrl url,
            BlobFileType type)
        {
            Id = new BlobFileId(Guid.NewGuid());
     
            FileType = type;
            ContentType = contentType;
            Url = url;
            CreateDate = DateTime.UtcNow;
            Path = BlobFilePath.Create("undefine", Id.Value.ToString()).Value;
            Accessibilitylevel = Accessibilitylevel.Hot;
            AddDomainEvent(new BlobFileCreatedDomainEvent());
        }

        public static BlobFile CreateBaseOnTreatmentStage(BlobFileUrl url, ContentType ContentType, BlobFileType type)
            => new BlobFile(ContentType, url, type);


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
