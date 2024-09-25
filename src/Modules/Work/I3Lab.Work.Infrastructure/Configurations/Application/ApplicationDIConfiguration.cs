using I3Lab.Treatments.Application.Configuration.Commands;
using I3Lab.Treatments.Application.Contract;
using I3Lab.Treatments.Domain.BlobFiles;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentInvites;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Infrastructure.Domain.BlobFiles;
using I3Lab.Treatments.Infrastructure.Domain.Members;
using I3Lab.Treatments.Infrastructure.Domain.TreatmentInvites;
using I3Lab.Treatments.Infrastructure.Domain.Treatments;
using I3Lab.Treatments.Infrastructure.Domain.WorkChats;
using I3Lab.Treatments.Infrastructure.Domain.Works;
using I3Lab.Treatments.Infrastructure.Processing.InternalCommands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            });

            services.AddScoped<ICommandsScheduler, CommandsScheduler>();
            
            services.AddScoped<IMemberContext, MemberContext>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<ITreatmentStageRepository, TreatmentStageRepository>();
            //services.AddScoped<IWorkCommentRepository, WorkCommentRepository>();
            services.AddScoped<ITreatmentInviteRepository, TreatmentInviteRepository>();
            services.AddScoped<ITreatmentStageChatRepository, TreatmentStageChatRepository>();
            services.AddScoped<IBlobFileRepository, BlobFileRepository>();
            services.AddScoped<ITreatmentRepository, TretmentRepository>();

            return services;
        }
    }
}
