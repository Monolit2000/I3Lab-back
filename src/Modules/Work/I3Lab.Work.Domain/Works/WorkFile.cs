using I3Lab.Works.Domain.Files;


namespace I3Lab.Works.Domain.Works
{
    public class WorkFile
    {
        public WorkId WorkId { get; private set; }
        public FileId FileId { get; private set; }
        public string ContainerName { get; private set; }   

        public DateTime CreateDate { get; private set; }

        private WorkFile() { } //For EF CORE 

        private WorkFile(WorkId workId, FileId fileId)
        {
            WorkId = workId;    
            FileId = fileId;
            ContainerName = workId.ToString();

            CreateDate = DateTime.UtcNow;
        }

        internal static WorkFile CreateNew(WorkId workId, FileId fileId)
        {
            return new WorkFile(workId, fileId);
        }
    }
}
