using I3Lab.Treatments.Application.Configuration.Commands;
using I3Lab.Treatments.Application.Contract;
using I3Lab.Treatments.Domain.TreatmentFils;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentInvites;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Infrastructure.Domain.TreatmentFiles;
using I3Lab.Treatments.Infrastructure.Domain.Members;
using I3Lab.Treatments.Infrastructure.Domain.TreatmentInvites;
using I3Lab.Treatments.Infrastructure.Domain.Treatments;
using I3Lab.Treatments.Infrastructure.Domain.WorkChats;
using I3Lab.Treatments.Infrastructure.Domain.Works;
using I3Lab.Treatments.Infrastructure.Processing.InternalCommands;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using I3Lab.Treatments.Infrastructure.Cache;
using I3Lab.BuildingBlocks.Infrastructure.PublishStrategies;
using Scrutor;
using I3Lab.Treatments.Infrastructure.Pipelines;

namespace I3Lab.Treatments.Infrastructure.Configurations.Application
{
    public static class ApplicationDIConfiguration
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(WorkModule).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(ProcessInternalCommandsCommandHandler).Assembly);
                cfg.NotificationPublisher = new ParallelNoWaitPublisher();

            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheInvalidationBehaviour<,>));

            services.AddScoped<ICommandsScheduler, CommandsScheduler>();
            services.AddScoped<IDistributedCacheService, DistributedCacheService>();

            services.AddScoped<IMemberContext, MemberContext>();

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.Decorate<IMemberRepository, CacheMemberRepository>();

            services.AddScoped<IBlobFileRepository, TreatmentFileRepository>();
            services.AddScoped<ITreatmentRepository, TretmentRepository>();
            services.AddScoped<ITreatmentStageRepository, TreatmentStageRepository>();
            services.AddScoped<ITreatmentInviteRepository, TreatmentInviteRepository>();
            services.AddScoped<ITreatmentStageChatRepository, TreatmentStageChatRepository>();

            return services;
        }
    }
}
