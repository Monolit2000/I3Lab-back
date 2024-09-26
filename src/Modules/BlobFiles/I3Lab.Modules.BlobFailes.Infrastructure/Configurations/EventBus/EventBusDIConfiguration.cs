using I3Lab.Modules.BlobFailes.Application.Contract;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace I3Lab.Modules.BlobFailes.Infrastructure.Configurations.EventBus
{
    public static class EventBusDIConfiguration
    {
        public static IServiceCollection AddMassTransitEventBus(
            this IServiceCollection service, IConfiguration configuration)
        {
            service.AddMassTransit(busConfiguration
                => busConfiguration.AddConsumers(typeof(IBlobFilesModule).Assembly));

            return service;
        }
    }
}
