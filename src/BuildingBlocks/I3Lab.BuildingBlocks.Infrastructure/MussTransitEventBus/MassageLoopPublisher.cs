using I3Lab.BuildingBlocks.Application.MussTransitEventBus;
using MassTransit;
using MassTransit.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Infrastructure.MussTransitEventBus
{
    public class MassageLoopPublisher (IBus bus)  : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                await bus.Publish(
                    new CurrentTimeEvent
                    {
                        Value = $"The current  time is {DateTime.UtcNow}"
                    },
                    stoppingToken);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }


}
