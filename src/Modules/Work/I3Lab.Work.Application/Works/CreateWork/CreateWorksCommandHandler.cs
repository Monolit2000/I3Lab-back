using FluentResults;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatments;
using I3Lab.Works.Domain.Works;
using MediatR;

namespace I3Lab.Works.Application.Works.CreateWork
{
    public class CreateWorksCommandHandler(
        IMemberRepository memberRepository,
        ITretmentRepository tretmentRepository,
        IWorkRepository workRepository,
        IMemberContext memberContext) : IRequestHandler<CreateWorksCommand, Result<WorkDto>>
    {

        public List<string> BaseWorkTitels = new List<string>() { "1", "2", "3", "4" };

        public async Task<Result<WorkDto>> Handle(CreateWorksCommand request, CancellationToken cancellationToken)
        {
            var treatment = await tretmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId), cancellationToken);
            if (treatment == null)
                return Result.Fail("Treatments not exist");

            var creator = await memberRepository.GetMemberByIdAsync(new MemberId(request.CreatorId));
            if (creator == null)
                return Result.Fail("MemberToInvite not exist");


            foreach (var titel in BaseWorkTitels)
            {

                var workResult = await treatment.CreateWorkAsync(creator, WorkTitel.Create(titel));

                if (workResult.IsFailed)
                    return Result.Fail(workResult.Errors);

                var work = workResult.Value;

                await workRepository.AddAsync(work);
            }
             
            await workRepository.SaveChangesAsync();

            //var workDto = new WorkDto
            //{
            //    Id = work.Id.Value,
            //    TreatmentId = work.Treatment.Id.Value,
            //    WorkStatus = work.WorkStatus.Value,
            //    WorkStartedDate = work.WorkStartedDate,
            //    CreatorId = work.CreatorId.Id.Value
            //};

            return new WorkDto();
        }
    }
}

