using Hangfire;
using I3Lab.Treatments.Application.Configuration.Commands;
using I3Lab.Users.IntegrationEvents;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace I3Lab.Treatments.Application.Members.CreateMember
{
    public class NewUserRegisteredIntegrationEventHandler(
        ILogger<NewUserRegisteredIntegrationEventHandler> logger,
        IMediator mediator,
        ICommandsScheduler commandsScheduler) : IConsumer<UserRegisteredIntegretionEvent>
    {
        public async Task Consume(ConsumeContext<UserRegisteredIntegretionEvent> context)
        {
            logger.LogInformation("{Consumer} : {Message}",
             nameof(NewUserRegisteredIntegrationEventHandler), context.Message.UserId);

           //var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget!"));

            await commandsScheduler.EnqueueAsync(new CreateMemberCommand(
                context.Message.UserId,
                context.Message.Email));

            //await mediator.Send(new CreateMemberCommand(
            //    context.Message.UserId,
            //    context.Message.Email));
        }
    }
}
