using FluentResults;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatment;
using I3Lab.Works.Domain.Works;
using MediatR;

namespace I3Lab.Works.Application.Works.CreateWork
{
    public class CreateWorkCommandHandler(
        IMemberRepository memberRepository,
        ITretmentRepository tretmentRepository,
        IWorkRepository workRepository,
        IMemberContext memberContext) : IRequestHandler<CreateWorkCommand, Result<WorkDto>>
    {
        public async Task<Result<WorkDto>> Handle(CreateWorkCommand request, CancellationToken cancellationToken)
        {
            var treatment = await tretmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId), cancellationToken);
            if (treatment == null)
                return Result.Fail("Treatment not exist");

            var creator = await memberRepository.GetMByIdAsync(memberContext.MemberId);
            if (creator == null)
                return Result.Fail("Member not exist");

            var createWorkResult = await Work.CreateAsync(creator, new TreatmentId(request.TreatmentId));
            if (createWorkResult.IsFailed)
                return Result.Fail(createWorkResult.Errors);

            var work = createWorkResult.Value;

            await workRepository.AddAsync(work);
            await workRepository.SaveChangesAsync();

            var workDto = new WorkDto
            {
                Id = work.Id.Value,
                TreatmentId = work.TreatmentId.Value,
                TreatmentName = work.TreatmentName,
                WorkStatus = work.WorkStatus.ToString(),
                WorkStartedDate = work.WorkStartedDate,
                CreatorId = work.CreatorId.Value
            };

            return Result.Ok(workDto);
        }
    }
}

