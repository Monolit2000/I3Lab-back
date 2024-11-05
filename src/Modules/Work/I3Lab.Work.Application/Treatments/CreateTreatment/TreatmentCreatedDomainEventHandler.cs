using Hangfire;
using I3Lab.Treatments.Application.Configuration.Commands;
using I3Lab.Treatments.Application.Works.CreateWorks;
using I3Lab.Treatments.Domain.Treatments.Events;
using MediatR;

namespace I3Lab.Treatments.Application.Treatments.CreateTreatment
{
    public class TreatmentCreatedDomainEventHandler(
        ISender sender, 
        IHangFireCommandsScheduler hangFireCommandsScheduler) : INotificationHandler<TreatmentCreatedDomainEvent>
    {
        public async Task Handle(TreatmentCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            //await hangFireCommandsScheduler.EnqueueAsync(new CreateTreatmentStagesCommand(
            //    notification.TreatmentId,
            //    notification.CreatorId));


            await sender.Send(new CreateTreatmentStagesCommand(
                    notification.TreatmentId,
                    notification.CreatorId));
        }

       
    }
}
