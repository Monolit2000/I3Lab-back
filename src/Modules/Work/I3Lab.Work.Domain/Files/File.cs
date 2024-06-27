using I3Lab.Work.Domain.Work;

namespace I3Lab.Work.Domain.File
{
    public class File
    {
        public FileId Id { get; private set; }
        public WorkId WorkId { get; private set; }  
        public string Name { get; private set; }
        public FileType Type { get; private set; }
        public string Path { get; private set; }

        private File()
        {
                
        }

        private File(WorkId workId, string name, FileType type, string path)
        {
            Id = new FileId(Guid.NewGuid());
            WorkId = workId;
            Name = name;
            Type = type;
            Path = path;
        }

        public static File CreateNewFile(WorkId workId, string name, FileType type, string path)
        {
            var newFile = new File(
                workId,
                name, 
                type,
                path);

            return newFile;
        }
     
    }

  
}
