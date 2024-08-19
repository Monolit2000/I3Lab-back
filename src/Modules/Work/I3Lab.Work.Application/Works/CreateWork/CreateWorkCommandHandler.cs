using FluentResults;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatment;
using I3Lab.Works.Domain.Works;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Works.CreateWork
{
    public class CreateWorkCommandHandler(
        IMemberRepository memberRepository,
        IWorkRepository workRepository,
        IMemberContext memberContext) : IRequestHandler<CreateWorkCommand, Result<WorkDto>>
    {
        public async Task<Result<WorkDto>> Handle(CreateWorkCommand request, CancellationToken cancellationToken)
        {
            var member = await memberRepository.GetByIdAsync(memberContext.MemberId);

            if (member == null)
                return Result.Fail("member not exist");

            var work = await Work.CreateAsync(
                member, 
                new TreatmentId(request.TreatmentId));

            var workDto = new WorkDto();

            return workDto;
        }
    }
}
