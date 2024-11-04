using MediatR;
using Microsoft.Extensions.Logging;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages;
using TreatmentStage = I3Lab.Treatments.Domain.TreatmentStages.TreatmentStage;

namespace I3Lab.Treatments.Application.Works.CreateWorks
{
    public class CreateWorksCommandHandler(
        IMemberRepository memberRepository,
        ITreatmentRepository treatmentRepository,
        ITreatmentStageRepository workRepository,
        ILogger<CreateWorksCommandHandler> logger) : IRequestHandler<CreateWorksCommand>
    {
        private List<string> BaseWorkTitles = new List<string>() { "1", "2", "3", "4" };

        public async Task Handle(CreateWorksCommand request, CancellationToken cancellationToken)
        {
            //var treatment = await treatmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId), cancellationToken);
            //if (treatment == null)
            //{
            //    logger.LogWarning("Treatment with ID {TreatmentId} not found.", request.TreatmentId);
            //    return;
            //}

            var creator = await memberRepository.GetAsync(new MemberId(request.CreatorId));
            if (creator == null)
            {
                logger.LogWarning("Creator with ID {CreatorId} not found.", request.CreatorId);
                return;
            }

            var tasks = BaseWorkTitles.Select(async title =>
            {
                logger.LogDebug("Creating work for title: {Title}", title);

                var workResult = await TreatmentStage.CreateBasedOnTreatmentAsync(
                    creator,
                    new TreatmentId(request.TreatmentId),
                    TreatmentStageTitel.Create(title));

                if (workResult.IsFailed)
                {
                    logger.LogError("Failed to create work for title: {Title}. Error: {Error}", title, workResult.Errors.FirstOrDefault()?.Message);
                    return null;
                }

                var work = workResult.Value;
                await workRepository.AddAsync(work);

                return work;
            }).ToList();

            var results = await Task.WhenAll(tasks);

            await workRepository.SaveChangesAsync();
            logger.LogInformation("Changes saved to the repository for TreatmentId: {TreatmentId}", request.TreatmentId);
        }
    }
}



//foreach (var titel in BaseWorkTitels)
//{
//    var workResult = await TreatmentStage.CreateBasedOnTreatmentAsync(
//        creator, 
//        new TreatmentId(request.TreatmentId), 
//        TreatmentStageTitel.Create(titel));

//    if (workResult.IsFailed)
//        return;

//    var work = workResult.Value;

//    await workRepository.AddAsync(work);
//}
