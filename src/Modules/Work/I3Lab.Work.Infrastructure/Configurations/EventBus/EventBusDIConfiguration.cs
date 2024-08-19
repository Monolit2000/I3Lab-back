using I3Lab.BuildingBlocks.Infrastructure.MussTransitEventBus;
using I3Lab.Works.Application.Contract;
using I3Lab.Works.Application.Members.CreateMember;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace I3Lab.Works.Infrastructure.Configurations.EventBus
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
