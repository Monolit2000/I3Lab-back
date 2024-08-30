using I3Lab.Users.IntegrationEvents;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace I3Lab.Works.Application.Members.CreateMember
{
    public class NewUserRegisteredIntegrationEventHandler(
        ILogger<NewUserRegisteredIntegrationEventHandler> logger,
        IMediator mediator) : IConsumer<UserRegisteredIntegretionEvent>
    {
        public async Task Consume(ConsumeContext<UserRegisteredIntegretionEvent> context)
        {
            logger.LogInformation("{Consumer} : {Message}",
             nameof(NewUserRegisteredIntegrationEventHandler), context.Message.UserId);

            var command = new CreateMemberCommand(
                context.Message.Email);

            await mediator.Send(command);
        }
    }
}
