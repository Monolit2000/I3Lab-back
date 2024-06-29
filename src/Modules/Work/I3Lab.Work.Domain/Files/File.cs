using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Files.Events;
using I3Lab.Work.Domain.Work;

namespace I3Lab.Work.Domain.Files
{
    public class File : Entity, IAggregateRoot
    {
        public FileId Id { get; private set; }
        public FileType Type { get; private set; }
        public string FileName { get; private set; }
        public string BlobPath { get; private set; }

        private File()
        {
        }

        private File(string fileName, FileType type, string blobPath)
        {
            Id = new FileId(Guid.NewGuid());
            FileName = fileName;
            Type = type;
            BlobPath = blobPath;

            AddDomainEvent(new FileCreatedDomainEvent());
        }

        public static File CreateNewFile( string fileName, FileType type, string path)
        {
            var newFile = new File(
                fileName, 
                type,
                path);

            return newFile;
        }
     
    }

  
}
