using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.BlobFiles.Events;
using I3Lab.Works.Domain.WorkDirectorys;

namespace I3Lab.Works.Domain.BlobFiles
{
    public class BlobFile : Entity, IAggregateRoot 
    {
        public WorkDirectoryId WorkDirectoryId { get; private set; }

        public BlobFileId Id { get; private set; }
        public BlobFileType Type { get; private set; }
        public Accessibilitylevel Accessibilitylevel { get; private set; }
        public string BlobName { get; private set; }
        public string FileName { get; private set; }
        public string BlobDirectoryName { get; private set; }
        public string BlobPath { get; private set; }
        public DateTime CreateDate { get; private set; }

        private BlobFile() { } //For EF core 

        private BlobFile(string fileName, BlobFileType type)
        {
            Id = new BlobFileId(Guid.NewGuid());
            FileName = fileName;
            Type = type;
            Accessibilitylevel = Accessibilitylevel.Hot;
            AddDomainEvent(new BlobFileCreatedDomainEvent());
        }

        public static BlobFile CreateNew(string fileName, BlobFileType type)
        {
            var newFile = new BlobFile(
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
