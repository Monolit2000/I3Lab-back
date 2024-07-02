using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Members;
using I3Lab.Work.Domain.Works;
using I3Lab.Work.Domain.WorkCatalogs;

namespace I3Lab.Work.Domain.WorkComments
{
    public class WorkComment : Entity, IAggregateRoot
    {
        public WorkCommentId Id { get; private set; }
        public MemberId AuthorId { get; private set; }  
        public WorkId WorkId { get; private set; }
        public string Content { get; private set; }
        public List<PinedFile> PinedFiles { get; private set; }
        public WorkCommentId? InReplyToCommentId { get; private set; }

        public DateTime CreateDate { get; private set; }

        public DateTime? EditDate { get; private set; }

        private WorkComment()
        {
        }
        private WorkComment( WorkId workId, MemberId authorId, string content)
        {
            Id = new WorkCommentId(Guid.NewGuid());
            WorkId = workId;
            AuthorId = authorId;
            Content = content;
            CreateDate = DateTime.UtcNow;  
        }

        internal static WorkComment CreateNew(WorkId workId, MemberId authorId, string content) 
        { 
            return new WorkComment(
                workId,
                authorId,
                content); 
        }

        public void PinFile(PinedFile pinFile)
        {
            PinedFiles.Add(pinFile);   
        }

    }
}
