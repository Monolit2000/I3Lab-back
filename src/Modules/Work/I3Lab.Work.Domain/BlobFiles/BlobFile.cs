using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.BlobFiles.Events;
using I3Lab.Works.Domain.Works;

namespace I3Lab.Works.Domain.BlobFiles
{
    public class BlobFile : Entity, IAggregateRoot 
    {
        public WorkId WorkId { get; private set; }

        public BlobFileId Id { get; private set; }
        public BlobFileType FileType { get; private set; }
        public Accessibilitylevel Accessibilitylevel { get; private set; }
        public string BlobName { get; private set; }
        public string FileName { get; private set; }
        public string BlobDirectoryName { get; private set; }
        public BlobFilePath Path { get; private set; }
        public DateTime CreateDate { get; private set; }

        private BlobFile() { } //For EF core 

        private BlobFile(
            BlobFileId blobFileId, 
            string fileName,
            BlobFileType type)
        {
            Id = blobFileId;
            FileName = fileName;
            FileType = type;
            Accessibilitylevel = Accessibilitylevel.Hot;
            AddDomainEvent(new BlobFileCreatedDomainEvent());
        }

        public static BlobFile CreateNew(
            BlobFileId blobFileId,
            string fileName,
            BlobFileType type)
        {
            var newFile = new BlobFile(
                blobFileId,
                fileName,
                type);

            return newFile;
        }

        public void RestoreToHotAccessibilitylevel()
        {
            Accessibilitylevel = Accessibilitylevel.Hot;

            AddDomainEvent(new RestoreToHotAccessibilitylevelDomainEvent());
        }

        public void RestoreToCoolAccessibilitylevel()
        {
            Accessibilitylevel = Accessibilitylevel.Cool;

            AddDomainEvent(new RestoreToCoolAccessibilitylevelDomainEvent());
        }

        public void RestoreToColdAccessibilitylevel()
        {
            Accessibilitylevel = Accessibilitylevel.Cold;

            AddDomainEvent(new RestoreToColdAccessibilitylevelDomainEvent());
        }

        public void RestoreToArchiveAccessibilitylevel()
        {
            Accessibilitylevel = Accessibilitylevel.Archive;

            AddDomainEvent(new RestoreToArchiveAccessibilitylevelDomainEvent());
        }
    }
}
