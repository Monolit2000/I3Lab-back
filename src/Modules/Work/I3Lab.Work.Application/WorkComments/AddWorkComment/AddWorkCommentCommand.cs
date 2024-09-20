using FluentResults;
using MediatR;


namespace I3Lab.Treatments.Application.WorkComments.AddWorkComment
{
    public class AddWorkCommentCommand : IRequest<Result<WorkCommentDto>>
    {
        public Guid WorkId { get; private set; }
        public Guid AuthorId { get; private set; }
        public string Content { get; private set; }
    }
}
