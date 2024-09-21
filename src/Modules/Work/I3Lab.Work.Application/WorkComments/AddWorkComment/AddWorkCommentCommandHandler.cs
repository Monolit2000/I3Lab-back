using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStageComments;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;

namespace I3Lab.Treatments.Application.WorkComments.AddWorkComment
{
    //public class AddWorkCommentCommandHandler(
    //    IWorkCommentRepository workCommentRepository) : IRequestHandler<AddWorkCommentCommand, Result<WorkCommentDto>>
    //{
    //    public async Task<Result<WorkCommentDto>> Handle(AddWorkCommentCommand request, CancellationToken cancellationToken)
    //    {
    //        var workComment = WorkComment.CreateBaseOnTreatmentStage(
    //            new TreatmentId(request.TreatmentId),
    //            new MemberToInvite(request.AuthorId),
    //            request.Content);

    //        await workCommentRepository.AddAsync(workComment);

    //        var workCommentDto = new WorkCommentDto();

    //        return workCommentDto;
    //    }
    //}
}
