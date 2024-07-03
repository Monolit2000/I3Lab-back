using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Files.Events;
using I3Lab.Works.Domain.WorkDirectorys;

namespace I3Lab.Works.Domain.Files
{
    public class File : Entity
    {
        public WorkDirectoryId WorkDirectoryId { get; private set; }

        public FileId Id { get; private set; }
        public FileType Type { get; private set; }
        public Accessibilitylevel Accessibilitylevel { get; private set; }
        public string BlobName { get; private set; }
        public string FileName { get; private set; }
        public string BlobPath { get; private set; }

        private File() { } //For EF core 

        private File(string fileName, FileType type, string blobPath, string blobName)
        {
            Id = new FileId(Guid.NewGuid());
            FileName = fileName;
            Type = type;
            BlobPath = blobPath;
            BlobName = blobName;
            Accessibilitylevel = Accessibilitylevel.Hot;
            AddDomainEvent(new FileCreatedDomainEvent());
        }

        private File(string fileName, FileType type, string blobPath)
        {
            Id = new FileId(Guid.NewGuid());
            FileName = fileName;
            Type = type;
            BlobPath = blobPath;
            Accessibilitylevel = Accessibilitylevel.Hot;
            AddDomainEvent(new FileCreatedDomainEvent());
        }

        private File(string fileName, FileType type, string blobPath, string blobName, Accessibilitylevel accessibilitylevel)
        {
            Id = new FileId(Guid.NewGuid());
            FileName = fileName;
            Type = type;
            BlobPath = blobPath;
            BlobName = blobName;
            Accessibilitylevel = accessibilitylevel;
            AddDomainEvent(new FileCreatedDomainEvent());
        }

        public static File CreateNew(string fileName, FileType type, string path)
        {
            var newFile = new File(
                fileName,
                type,
                path);

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
