using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Infrastructure.EventBus
{
    public class InMemoryMessageQueue
    {
        private readonly Channel<IIntegrationEvent> _chennel = Channel.CreateUnbounded<IIntegrationEvent>();

        public ChannelWriter<IIntegrationEvent> Write => _chennel.Writer;

        public ChannelReader<IIntegrationEvent> Reder => _chennel.Reader;
    }
}
