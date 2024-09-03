using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.WorkComments;
using I3Lab.Works.Domain.WorkComments.Events;

namespace I3Lab.Works.Domain.WorkCatalogs
{
    public class PinedFile : Entity
    {
        public WorkCommentId WorkCommentId { get; private set; }
        public BlobFile FileId { get; private set; }

        public PinedFile() { } // For EF Core 

        private PinedFile(
            WorkCommentId workCommentId,
            BlobFile fileId)
        {
            WorkCommentId = workCommentId;
            FileId = fileId;

            AddDomainEvent(new FilePinedDomainEvent());
        }
        
        public static PinedFile CreateNew(
            WorkCommentId workCommentId, 
            BlobFile fileId)
        {
            return new PinedFile(
                workCommentId, 
                fileId);
        }
    }
}
