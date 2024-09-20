using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.WorkCatalogs;
using I3Lab.Treatments.Domain.BlobFiles;

namespace I3Lab.Treatments.Domain.TreatmentStageComments
{
    public class TreatmentStageComment : Entity, IAggregateRoot
    {
        public TreatmentStageCommentId Id { get; private set; }
        public MemberId AuthorId { get; private set; }  
        public TreatmentStageId WorkId { get; private set; }
        public string Content { get; private set; }
        public List<PinedFile> PinedFiles { get; private set; }

        public TreatmentStageCommentId InReplyToCommentId { get; private set; }

        public DateTime CreateDate { get; private set; }

        public DateTime? EditDate { get; private set; }

        private TreatmentStageComment()
        {
        }
        private TreatmentStageComment( TreatmentStageId workId, MemberId authorId, string content)
        {
            Id = new TreatmentStageCommentId(Guid.NewGuid());
            WorkId = workId;
            AuthorId = authorId;
            Content = content;
            CreateDate = DateTime.UtcNow;  
        }

        public static TreatmentStageComment CreateNew(TreatmentStageId workId, MemberId authorId, string content) 
        { 
            return new TreatmentStageComment(
                workId,
                authorId,
                content); 
        }

        public void PinFile(TreatmentStageCommentId workCommentId, BlobFile fileId)
        {
            var newPineFile = PinedFile.CreateNew(workCommentId, fileId);    

            PinedFiles.Add(newPineFile);   
        }

    }
}
