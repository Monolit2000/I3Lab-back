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

        private BlobFile(string fileName, string blobDirectoryName, BlobFileType type, string blobPath, string blobName)
        {
            Id = new BlobFileId(Guid.NewGuid());
            FileName = fileName;
            Type = type;
            BlobPath = blobPath;
            BlobName = blobName;
            BlobDirectoryName = blobDirectoryName;
            Accessibilitylevel = Accessibilitylevel.Hot;
            CreateDate = DateTime.UtcNow;
            AddDomainEvent(new FileCreatedDomainEvent());
        }

        private BlobFile(string fileName, string blobDirectoryName, BlobFileType type, string blobPath)
        {
            Id = new BlobFileId(Guid.NewGuid());
            FileName = fileName;
            Type = type;
            BlobPath = blobPath;
            BlobDirectoryName = blobDirectoryName;
            Accessibilitylevel = Accessibilitylevel.Hot;
            AddDomainEvent(new FileCreatedDomainEvent());
        }

        private BlobFile(string fileName, BlobFileType type, string blobPath, string blobName, Accessibilitylevel accessibilitylevel)
        {
            Id = new BlobFileId(Guid.NewGuid());
            FileName = fileName;
            Type = type;
            BlobPath = blobPath;
            BlobName = blobName;
            Accessibilitylevel = accessibilitylevel;
            AddDomainEvent(new FileCreatedDomainEvent());
        }

        public static BlobFile CreateNew(string fileName, string blobDirectoryName, BlobFileType type, string path)
        {
            var newFile = new BlobFile(
                fileName,
                blobDirectoryName,
                type,
                path);

            return newFile;
        }

        //public static BlobFile CreateNew3DFile(string fileName, string path)
        //{
        //    var newFile = new BlobFile(
        //        fileName,
        //        BlobFileType.File3D,
        //        path);

        //    return newFile;
        //}


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
