using I3Lab.Doctors.Application.Contract;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace I3Lab.Doctors.Infrastructure.Configurations.EventBus
{
    public static class EventBusDIConfiguration
    {
        public static IServiceCollection AddMassTransitEventBus(
            this IServiceCollection service, IConfiguration configuration)
        {
            service.AddMassTransit(busConfiguration
                => busConfiguration.AddConsumers(typeof(DoctorModule).Assembly));

            return service;
        }
    }
}
