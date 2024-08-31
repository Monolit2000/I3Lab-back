using I3Lab.Administration.Application.Contruct;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Administration.Infrastructure.Configurations.EventBus
{
    public static class EventBusDIConfiguration
    {
        public static IServiceCollection AddMassTransitEventBus(
            this IServiceCollection service, IConfiguration configuration)
        {
            service.AddMassTransit(busConfiguration
                => busConfiguration.AddConsumers(typeof(AdministrationModule).Assembly));

            return service;
        }
    }
}
