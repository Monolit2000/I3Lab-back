using MediatR;
using Microsoft.Extensions.Logging;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages;
//using TreatmentStage = I3Lab.Treatments.Domain.TreatmentStages.TreatmentStage;

namespace I3Lab.Treatments.Application.Works.CreateWorks
{
    public class CreateTreatmentStagesCommandHandler(
        IMemberRepository memberRepository,
        ITreatmentStageRepository workRepository,
        ILogger<CreateTreatmentStagesCommandHandler> logger) : IRequestHandler<CreateTreatmentStagesCommand>
    {
        private List<string> BaseWorkTitles = ["1", "2", "3", "4"];

        public async Task Handle(CreateTreatmentStagesCommand request, CancellationToken cancellationToken)
        {
            var creator = await memberRepository.GetAsync(new MemberId(request.CreatorId));
            if (creator == null)
            {
                logger.LogWarning("Creator with ID {CreatorId} not found.", request.CreatorId);
                return;
            }

            foreach (var title in BaseWorkTitles)
            {
                var workResult = await TreatmentStage.CreateBasedOnTreatmentAsync(
                    creator,
                    new TreatmentId(request.TreatmentId),
                    TreatmentStageTitel.Create(title));

                if (workResult.IsFailed)
                {
                    logger.LogError(
                        "Failed to create work for title: {Title}. Error: {Error}", 
                        title, 
                        workResult.Errors.FirstOrDefault()?.Message);

                    continue;
                }

                var work = workResult.Value;
                await workRepository.AddAsync(work);
            }

            await workRepository.SaveChangesAsync();
        }
    }
}




//var tasks = BaseWorkTitles.Select(async title =>
//{
//    logger.LogDebug("Creating work for title: {Title}", title);

//    var workResult = await TreatmentStage.CreateBasedOnTreatmentAsync(
//        creator,
//        new TreatmentId(request.TreatmentId),
//        TreatmentStageTitel.Create(title));

//    if (workResult.IsFailed)
//    {
//        logger.LogError("Failed to create work for title: {Title}. Error: {Error}", title, workResult.Errors.FirstOrDefault()?.Message);
//        return null;
//    }

//    var work = workResult.Value;
//    await workRepository.AddAsync(work);

//    return work;
//}).ToList();

//var results = await Task.WhenAll(tasks);


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
