using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Infrastructure.EventBus
{
    public interface IIntegrationEvent : INotification
    {
        public Guid Id { get; }

        public DateTime OccurredOn { get; }
    }


    public abstract class IntegrationEvent : IIntegrationEvent
    {
        public Guid Id { get; }

        public DateTime OccurredOn { get; }

        protected IntegrationEvent()
        {
            this.Id = Guid.NewGuid();
            this.OccurredOn = DateTime.UtcNow;
        }
    }
}
