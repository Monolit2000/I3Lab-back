using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Infrastructure.EventBus
{
    public interface IEventBus
    {
        public Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken = default)
             where T : class, IIntegrationEvent;
    }
}
