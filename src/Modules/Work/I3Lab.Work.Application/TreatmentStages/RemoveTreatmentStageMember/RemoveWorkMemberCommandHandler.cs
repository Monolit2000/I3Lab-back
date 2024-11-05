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
//    public class RemoveWorkMemberCommandHandler(IWorkRepository workRepository) : IRequestHandler<RemoveWorkMemberCommand, Result<TreatmentMemberDto>>
//    {
//        public async Task<Result<TreatmentMemberDto>> Handle(RemoveWorkMemberCommand request, CancellationToken cancellationToken)
//        {
//            var work = await workRepository.GetByIdAsync(new TreatmentStageId(request.TreatmentStageId));

//            if (work == null)
//            {
//                return Result.Fail<TreatmentMemberDto>("TreatmentStage not found.");
//            }

//            var workMember = work.TreatmentAccebilityMembers.FirstOrDefault(wm => wm.Member == new SenderId(request.SenderId));

//            if (workMember == null)
//            {
//                return Result.Fail<TreatmentMemberDto>("TreatmentStage member not found.");
//            }

//            work.TreatmentAccebilityMembers.Remove(workMember);

//            await workRepository.UpdateAsync(work);

//            var workMemberDto = new TreatmentMemberDto(
//                workMember.TreatmentStageId.Value,
//                workMember.SenderId.Value,
//                workMember.AddedBy.Value,
//                workMember.JoinDate
//            );

//            return workMemberDto;

//        }
//    }
//}
