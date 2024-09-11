using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.BlobFiles;


namespace I3Lab.Works.Domain.Works
{
    public class WorkFile : Entity
    {
        public WorkId WorkId { get; private set; }
        public BlobFile File { get; private set; }

        public DateTime CreateDate { get; private set; }

        private WorkFile() { } //For EF CORE 

        private WorkFile(
            WorkId workId, 
            BlobFile file)
        {
            WorkId = workId;    
            File = file;

            CreateDate = DateTime.UtcNow;
        }

        internal static WorkFile CreateNew(WorkId workId, BlobFile fileId)
        {
            return new WorkFile(workId, fileId);
        }
    }
}
