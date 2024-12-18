﻿using I3Lab.BuildingBlocks.Infrastructure.MussTransitEventBus;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace I3Lab.BuildingBlocks.Infrastructure.Configurations.EventBus
{
    public static class MassTransitConfiguration
    {
        public static IServiceCollection AddMassTransitInMemoryEventBus(
            this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMassTransit(busConfiguration =>
            {
                busConfiguration.SetKebabCaseEndpointNameFormatter();

                busConfiguration.UsingInMemory((context, config) => config.ConfigureEndpoints(context));
            });


            //services.AddHostedService<MassageLoopPublisher>();

            return services;
        }

        public static IServiceCollection AddMassTransitRabbitMqEventBus(
           this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMassTransit(busConfiguration =>
            {
                busConfiguration.SetKebabCaseEndpointNameFormatter();

                busConfiguration.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(new Uri(configuration["MessageBroker:HostName"]!), h =>
                    {
                        h.Username(configuration["MessageBroker:Username"]!);
                        h.Username(configuration["MessageBroker:Password"]!);
                    });

                    configurator.ConfigureEndpoints(context);
                });
            });

            //services.AddHostedService<MassageLoopPublisher>();
            return services;
        }
    }
}
