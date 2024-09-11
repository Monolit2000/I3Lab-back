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
        public BlobFileUrl Url { get; private set; }
        public BlobFilePath Path { get; private set; }
        public DateTime CreateDate { get; private set; }

        private BlobFile() { } //For EF core 

        private BlobFile(
            WorkId workId,
            string fileName,
            BlobFileType type,
            BlobFileUrl url)
        {
            WorkId = workId;
            Id = new BlobFileId(Guid.NewGuid());
            FileName = fileName;
            FileType = type;
            Accessibilitylevel = Accessibilitylevel.Hot;
            Url = url;
            AddDomainEvent(new BlobFileCreatedDomainEvent());
        }

        public static BlobFile CreateBaseOnWork(
            WorkId workId, 
            string fileName, 
            BlobFileType type, 
            BlobFileUrl url) 
            => new BlobFile(
                workId,  
                fileName, 
                type, 
                url);


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
