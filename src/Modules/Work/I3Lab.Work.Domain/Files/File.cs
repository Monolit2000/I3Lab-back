using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Files.Events;
using I3Lab.Work.Domain.Treatment;
using I3Lab.Work.Domain.Work;

namespace I3Lab.Work.Domain.Files
{
    public class File : Entity
    {
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

        public static File CreateNewFile(string fileName, FileType type, string path, string blobName)
        {
            var newFile = new File(
                fileName,
                type,
                path,
                blobName);

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
