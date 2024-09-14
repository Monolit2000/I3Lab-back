using FluentResults;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatments;
using I3Lab.Works.Domain.Works;
using MediatR;

namespace I3Lab.Works.Application.Works.CreateWorks
{
    public class CreateWorksCommandHandler(
        IMemberRepository memberRepository,
        ITretmentRepository tretmentRepository,
        IWorkRepository workRepository,
        IMemberContext memberContext) : IRequestHandler<CreateWorksCommand>
    {

        public List<string> BaseWorkTitels = new List<string>() { "1", "2", "3", "4" };

        public async Task Handle(CreateWorksCommand request, CancellationToken cancellationToken)
        {
            var treatment = await tretmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId), cancellationToken);
            if (treatment == null)
                return; /*Result.Fail("Treatments not exist");*/

            var creator = await memberRepository.GetMemberByIdAsync(new MemberId(request.CreatorId));
            if (creator == null)
                return;

            foreach (var titel in BaseWorkTitels)
            {
                var workResult = await Work.CreateBasedOnTreatmentAsync(
                    creator, new TreatmentId(request.TreatmentId), WorkTitel.Create(titel));

                if (workResult.IsFailed)
                    return;
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
            //    Creator = work.Creator.Id.Value
            //};

         
        }
    }
}

