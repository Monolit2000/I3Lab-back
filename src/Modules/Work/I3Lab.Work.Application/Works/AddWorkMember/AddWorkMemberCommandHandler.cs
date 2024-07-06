using FluentResults;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Works;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Works.AddWorkMember
{
    public class AddWorkMemberCommandHandler : IRequestHandler<AddWorkMemberCommand, Result<WorkMemberDto>>
    {
        private IWorkRepository _workRepository;

        public AddWorkMemberCommandHandler(IWorkRepository workRepository)
        {
            _workRepository = workRepository;
        }

        public async Task<Result<WorkMemberDto>> Handle(AddWorkMemberCommand request, CancellationToken cancellationToken)
        {
            var work = await _workRepository.GetByIdAsync(new WorkId(request.WorkId));

            if (work == null)
                return Result.Fail("Work not found");

            var addWorkMemberResult = work.AddWorkMember(
                work.Id,
                new MemberId(request.MemberId), 
                new MemberId(request.AddedByMemberId));

            if (addWorkMemberResult.IsFailed)
                return addWorkMemberResult;

            await _workRepository.SaveChangesAsync();

            return new WorkMemberDto(work.Id.Value, request.MemberId);
        }
    }
}
