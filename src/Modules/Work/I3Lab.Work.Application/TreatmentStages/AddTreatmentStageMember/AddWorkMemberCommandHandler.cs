using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Works.AddWorkMember
{
    //public class AddWorkMemberCommandHandler(
    //    IWorkRepository workRepository,
    //    IMemberRepository memberRepository) : IRequestHandler<AddWorkMemberCommand, Result<WorkMemberDto>>
    //{
      
    //    public async Task<Result<WorkMemberDto>> Handle(AddWorkMemberCommand request, CancellationToken cancellationToken)
    //    {
    //        var work = await workRepository.GetByIdAsync(new TreatmentId(request.TreatmentId));

    //        if (work == null)
    //            return Result.Fail("TreatmentStage not found");

    //        var addWorkMemberResult = work.AddWorkMember(
    //            new SenderId(request.SenderId), 
    //            new SenderId(request.AddedByMemberId));

    //        if (addWorkMemberResult.IsFailed)
    //            return addWorkMemberResult;

    //        await workRepository.SaveChangesAsync();

    //        return new WorkMemberDto(work.Id.Value, request.SenderId);
    //    }
    //}
}
