using I3Lab.BuildingBlocks.Application.MussTransitEventBus;
using I3Lab.Users.IntegrationEvents;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace I3Lab.Works.Application.Members.CreateMember
{
    public class NewUserRegisteredIntegrationEventHandler(
        ILogger<NewUserRegisteredIntegrationEventHandler> logger,
        IMediator publisher) : IConsumer<UserRegisteredIntegretionEvent>
    {
        public async Task Consume(ConsumeContext<UserRegisteredIntegretionEvent> context)
        {
            logger.LogInformation("{Consumer} : {Message}",
             nameof(NewUserRegisteredIntegrationEventHandler), context.Message.UserId);

            var command = new CreateMemberCommand(
                context.Message.UserId,
                context.Message.Name,
                context.Message.Email,
                context.Message.LastName);

            await publisher.Send(command);
        }
    }









    public class CreateNewUserIntegrationEventHandlerV2(
        ILogger<CreateNewUserIntegrationEventHandlerV2> logger) : IConsumer<CurrentTimeEvent>
    {
        public Task Consume(ConsumeContext<CurrentTimeEvent> context)
        {
            logger.LogInformation("{Consumer} : {Message}",
                nameof(CreateNewUserIntegrationEventHandlerV2), context.Message.Value);

            return Task.CompletedTask;
        }
    }
}
