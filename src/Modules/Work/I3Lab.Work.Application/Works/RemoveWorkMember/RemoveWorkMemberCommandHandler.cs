//using FluentResults;
//using I3Lab.Works.Domain.Members;
//using I3Lab.Works.Domain.Works;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace I3Lab.Works.Application.Works.RemoveWorkMember
//{
//    public class RemoveWorkMemberCommandHandler(IWorkRepository workRepository) : IRequestHandler<RemoveWorkMemberCommand, Result<WorkMemberDto>>
//    {
//        public async Task<Result<WorkMemberDto>> Handle(RemoveWorkMemberCommand request, CancellationToken cancellationToken)
//        {
//            var work = await workRepository.GetByIdAsync(new WorkId(request.WorkId));

//            if (work == null)
//            {
//                return Result.Fail<WorkMemberDto>("Work not found.");
//            }

//            var workMember = work.WorkMembers.FirstOrDefault(wm => wm.Member == new MemberId(request.MemberId));

//            if (workMember == null)
//            {
//                return Result.Fail<WorkMemberDto>("Work member not found.");
//            }

//            work.WorkMembers.Remove(workMember);

//            await workRepository.UpdateAsync(work);

//            var workMemberDto = new WorkMemberDto(
//                workMember.WorkId.Value,
//                workMember.MemberId.Value,
//                workMember.AddedBy.Value,
//                workMember.JoinDate
//            );

//            return workMemberDto;

//        }
//    }
//}
