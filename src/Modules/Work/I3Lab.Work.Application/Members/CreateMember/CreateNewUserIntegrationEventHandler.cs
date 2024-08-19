using I3Lab.BuildingBlocks.Application.MussTransitEventBus;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace I3Lab.Works.Application.Members.CreateMember
{
    public class CreateNewUserIntegrationEventHandler(
        ILogger<CreateNewUserIntegrationEventHandler> logger) : IConsumer<CurrentTimeEvent>
    {
        public Task Consume(ConsumeContext<CurrentTimeEvent> context)
        {
            logger.LogInformation("{Consumer} : {Message}", 
                nameof(CreateNewUserIntegrationEventHandler), context.Message.Value);

            return Task.CompletedTask;  
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
