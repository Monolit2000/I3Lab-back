using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.BlobFiles;


namespace I3Lab.Works.Domain.Works
{
    public class WorkFile : Entity
    {
        public WorkId WorkId { get; private set; }
        public BlobFileId FileId { get; private set; }

        public DateTime CreateDate { get; private set; }

        private WorkFile() { } //For EF CORE 

        private WorkFile(
            WorkId workId, 
            BlobFileId fileId)
        {
            WorkId = workId;    
            FileId = fileId;

            CreateDate = DateTime.UtcNow;
        }

        internal static WorkFile CreateNew(WorkId workId, BlobFileId fileId)
        {
            return new WorkFile(workId, fileId);
        }
    }
}
