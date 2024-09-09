using FluentResults;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.WorkComments;
using I3Lab.Works.Domain.Works;
using MediatR;

namespace I3Lab.Works.Application.WorkComments.AddWorkComment
{
    //public class AddWorkCommentCommandHandler(
    //    IWorkCommentRepository workCommentRepository) : IRequestHandler<AddWorkCommentCommand, Result<WorkCommentDto>>
    //{
    //    public async Task<Result<WorkCommentDto>> Handle(AddWorkCommentCommand request, CancellationToken cancellationToken)
    //    {
    //        var workComment = WorkComment.CreateBaseOnWork(
    //            new TreatmentId(request.TreatmentId),
    //            new MemberToInvite(request.AuthorId),
    //            request.Content);

    //        await workCommentRepository.AddAsync(workComment);

    //        var workCommentDto = new WorkCommentDto();

    //        return workCommentDto;
    //    }
    //}
}
