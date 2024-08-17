using I3Lab.Works.Application.Contract;
using I3Lab.Works.Domain.Works;
using I3Lab.Works.Infrastructure.Domain.Works;
using I3Lab.Works.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using I3Lab.BuildingBlocks.Infrastructure.Domain;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Infrastructure.Domain.Members;
using I3Lab.Works.Domain.WorkComments;
using I3Lab.Works.Infrastructure.Domain.WorkComments;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Infrastructure.Domain.BlobFiles;
using I3Lab.Works.Domain.Treatment;
using I3Lab.Works.Infrastructure.Domain.Treatments;


namespace I3Lab.Works.Infrastructure.Startup
{
    public static class WorkModuleStartup
    {
        public static IServiceCollection AddWorkModule(
         this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("Database");

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(WorkModule).Assembly);
            });

            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<WorkContext>((sp, options) =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Database"));
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            });

            
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IWorkRepository, WorkRepository>();
            //services.AddScoped<IWorkCommentRepository, WorkCommentRepository>();
            services.AddScoped<IBlobFileRepository, BlobFileRepository>();
            //services.AddScoped<ITretmentRepository, TretmentRepository>();


            return services;


            //services.AddEventBusModule();
            //services.AddScoped<IUserAccessApi, UserAccessApi>();
            //services.AddScoped<IUserAccessModule, UserAccessModule>();
        }
    }
}
