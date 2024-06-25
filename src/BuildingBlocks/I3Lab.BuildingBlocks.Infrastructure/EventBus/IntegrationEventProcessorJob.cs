using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace I3Lab.BuildingBlocks.Infrastructure.EventBus
{
    public class IntegrationEventProcessorJob : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private InMemoryMessageQueue _inMemoryMessageQueue;
        private readonly ILogger<IntegrationEventProcessorJob> _logger;

        public IntegrationEventProcessorJob(
            IServiceProvider serviceProvider,
            InMemoryMessageQueue inMemoryMessageQueue,
            ILogger<IntegrationEventProcessorJob> logger)
        {
            _serviceProvider = serviceProvider;
            _inMemoryMessageQueue = inMemoryMessageQueue;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var mediatr = GetMediatorServices(scope);

            await Console.Out.WriteLineAsync("ExecuteAsync Start IntegrationEventProcessorJob");

            await foreach (IIntegrationEvent @event in _inMemoryMessageQueue.Reder.ReadAllAsync(stoppingToken))
            {
                _logger.LogInformation(
                    "Starting IntegrationEvent {@event}, {@DateTimeUtc}", @event, DateTime.UtcNow);

                await mediatr.Publish(@event, stoppingToken);
            }
        }


        private IMediator GetMediatorServices(IServiceScope scope)
        {
            var mediator = scope.ServiceProvider.GetService<IMediator>();
            if (mediator == null)
                throw new ArgumentNullException(nameof(IMediator), "Cant resolve IMediator from service provider");

            return mediator;
        }

    }
}
