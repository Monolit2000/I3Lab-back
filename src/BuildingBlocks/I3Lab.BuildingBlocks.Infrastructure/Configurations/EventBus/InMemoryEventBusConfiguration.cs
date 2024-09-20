using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using I3Lab.Treatments.Application.Members.CreateMember;
using I3Lab.BuildingBlocks.Infrastructure.MussTransitEventBus;

namespace I3Lab.BuildingBlocks.Infrastructure.Configurations.EventBus
{
    public static class InMemoryEventBusConfiguration
    {
        public static IServiceCollection AddMassTransitInMemoryEventBus(
            this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMassTransit(busConfiguration =>
            {
                busConfiguration.SetKebabCaseEndpointNameFormatter();

                busConfiguration.UsingInMemory((context, config) => config.ConfigureEndpoints(context));
            });


            services.AddHostedService<MassageLoopPublisher>();

            return services;
        }
    }
}
