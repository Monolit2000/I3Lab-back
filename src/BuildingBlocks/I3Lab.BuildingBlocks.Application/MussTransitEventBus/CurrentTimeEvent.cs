using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Application.MussTransitEventBus
{
    public record CurrentTimeEvent
    {
        public string Value { get; init; } = string.Empty;
    }
}
