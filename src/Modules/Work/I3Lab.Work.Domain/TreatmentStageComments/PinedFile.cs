using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.TreatmentFils;
using I3Lab.Treatments.Domain.TreatmentStageComments;
using I3Lab.Treatments.Domain.TreatmentStageComments.Events;

namespace I3Lab.Treatments.Domain.WorkCatalogs
{
    public class PinedFile : Entity
    {
        public TreatmentStageCommentId WorkCommentId { get; private set; }
        public TreatmentFile FileId { get; private set; }

        public PinedFile() { } // For EF Core 

        private PinedFile(
            TreatmentStageCommentId workCommentId,
            TreatmentFile fileId)
        {
            WorkCommentId = workCommentId;
            FileId = fileId;

            AddDomainEvent(new FilePinedDomainEvent());
        }
        
        public static PinedFile CreateNew(
            TreatmentStageCommentId workCommentId, 
            TreatmentFile fileId)
        {
            return new PinedFile(
                workCommentId, 
                fileId);
        }
    }
}
