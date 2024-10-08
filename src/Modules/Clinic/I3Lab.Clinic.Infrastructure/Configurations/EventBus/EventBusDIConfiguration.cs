using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using I3Lab.Clinics.Application.Contruct;   

namespace I3Lab.Clinics.Infrastructure.Configurations.EventBus
{
    public static class EventBusDIConfiguration
    {
        public static IServiceCollection AddMassTransitEventBus(
            this IServiceCollection service, IConfiguration configuration)
        {
            service.AddMassTransit(busConfiguration
                => busConfiguration.AddConsumers(typeof(IClinicModule).Assembly));

            return service;
        }
    }
}
