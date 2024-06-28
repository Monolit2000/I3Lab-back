using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Work;

namespace I3Lab.Work.Domain.File
{
    public class File : Entity, IAggregateRoot
    {
        public FileId Id { get; private set; }
        public FileType Type { get; private set; }
        public string Name { get; private set; }
        public string Path { get; private set; }

        private File()
        {
                
        }

        private File(string name, FileType type, string path)
        {
            Id = new FileId(Guid.NewGuid());
            Name = name;
            Type = type;
            Path = path;
        }

        public static File CreateNewFile( string name, FileType type, string path)
        {
            var newFile = new File(
                name, 
                type,
                path);

            return newFile;
        }
     
    }

  
}
