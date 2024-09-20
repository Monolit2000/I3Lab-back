using I3Lab.BuildingBlocks.Infrastructure.MussTransitEventBus;
using I3Lab.Treatments.Application.Contract;
using I3Lab.Treatments.Application.Members.CreateMember;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace I3Lab.Treatments.Infrastructure.Configurations.EventBus
{
    public static class EventBusDIConfiguration
    {
        public static IServiceCollection AddMassTransitEventBus(
            this IServiceCollection service, IConfiguration configuration)
        {
            service.AddMassTransit(busConfiguration 
                => busConfiguration.AddConsumers(typeof(WorkModule).Assembly));
         
            return service;
        }
    }
}
