using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;
using TreatmentStage = I3Lab.Treatments.Domain.TreatmentStages.TreatmentStage;

namespace I3Lab.Treatments.Application.Works.CreateWorks
{
    public class CreateWorksCommandHandler(
        IMemberRepository memberRepository,
        ITreatmentRepository tretmentRepository,
        ITreatmentStageRepository workRepository) : IRequestHandler<CreateWorksCommand>
    {

        private List<string> BaseWorkTitels = new List<string>() { "1", "2", "3", "4" };

        public async Task Handle(CreateWorksCommand request, CancellationToken cancellationToken)
        {
            var treatment = await tretmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId), cancellationToken);
            if (treatment == null)
                return; 

            var creator = await memberRepository.GetAsync(new MemberId(request.CreatorId));
            if (creator == null)
                return;
               
            foreach (var titel in BaseWorkTitels)
            {
                var workResult = await TreatmentStage.CreateBasedOnTreatmentAsync(
                    creator, 
                    new TreatmentId(request.TreatmentId), 
                    TreatmentStageTitel.Create(titel));

                if (workResult.IsFailed)
                    return;

                var work = workResult.Value;

                await workRepository.AddAsync(work);
            }
             
            await workRepository.SaveChangesAsync();

        }
    }
}

