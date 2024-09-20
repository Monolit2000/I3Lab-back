//using FluentResults;
//using I3Lab.TreatmentStages.Domain.Members;
//using I3Lab.TreatmentStages.Domain.TreatmentStages;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace I3Lab.TreatmentStages.Application.TreatmentStages.RemoveWorkMember
//{
//    public class RemoveWorkMemberCommandHandler(IWorkRepository workRepository) : IRequestHandler<RemoveWorkMemberCommand, Result<WorkMemberDto>>
//    {
//        public async Task<Result<WorkMemberDto>> Handle(RemoveWorkMemberCommand request, CancellationToken cancellationToken)
//        {
//            var work = await workRepository.GetByIdAsync(new TreatmentStageId(request.TreatmentStageId));

//            if (work == null)
//            {
//                return Result.Fail<WorkMemberDto>("TreatmentStage not found.");
//            }

//            var workMember = work.WorkMembers.FirstOrDefault(wm => wm.Member == new MemberId(request.MemberId));

//            if (workMember == null)
//            {
//                return Result.Fail<WorkMemberDto>("TreatmentStage member not found.");
//            }

//            work.WorkMembers.Remove(workMember);

//            await workRepository.UpdateAsync(work);

//            var workMemberDto = new WorkMemberDto(
//                workMember.TreatmentStageId.Value,
//                workMember.MemberId.Value,
//                workMember.AddedBy.Value,
//                workMember.JoinDate
//            );

//            return workMemberDto;

//        }
//    }
//}
