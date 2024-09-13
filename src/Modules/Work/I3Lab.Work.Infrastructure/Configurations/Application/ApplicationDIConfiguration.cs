using I3Lab.Works.Application.Configuration.Commands;
using I3Lab.Works.Application.Contract;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.TreatmentInvites;
using I3Lab.Works.Domain.Treatments;
using I3Lab.Works.Domain.WorkChats;
using I3Lab.Works.Domain.Works;
using I3Lab.Works.Infrastructure.Domain.BlobFiles;
using I3Lab.Works.Infrastructure.Domain.Members;
using I3Lab.Works.Infrastructure.Domain.TreatmentInvites;
using I3Lab.Works.Infrastructure.Domain.Treatments;
using I3Lab.Works.Infrastructure.Domain.WorkChats;
using I3Lab.Works.Infrastructure.Domain.Works;
using I3Lab.Works.Infrastructure.Processing.InternalCommands;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace I3Lab.Works.Infrastructure.Configurations.Application
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
            services.AddScoped<IWorkRepository, WorkRepository>();
            //services.AddScoped<IWorkCommentRepository, WorkCommentRepository>();
            services.AddScoped<ITreatmentInviteRepository, TreatmentInviteRepository>();
            services.AddScoped<IWorkChatRepository, WorkChatRepository>();
            services.AddScoped<IBlobFileRepository, BlobFileRepository>();
            services.AddScoped<ITretmentRepository, TretmentRepository>();

            return services;
        }
    }
}
