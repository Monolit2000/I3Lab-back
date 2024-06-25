using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace I3Lab.BuildingBlocks.Infrastructure.EventBus
{
    public class EventBus : IEventBus
    {
        private InMemoryMessageQueue _inMemoryMessageQueue;
        private readonly ILogger<EventBus> _logger;
        public EventBus(
            InMemoryMessageQueue inMemoryMessageQueue,
            ILogger<EventBus> logger)
        {
            _inMemoryMessageQueue = inMemoryMessageQueue;
            _logger = logger;
        }

        public async Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken)
            where T : class, IIntegrationEvent
        {
            //_logger.LogInformation("Publishing {Event}", integrationEvent.GetType().FullName);
            await _inMemoryMessageQueue.Write.WriteAsync(integrationEvent, cancellationToken);
        }
    }
}
