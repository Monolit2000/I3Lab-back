using I3Lab.Administration.Application.Contruct;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatments;
using I3Lab.Works.Domain.Works;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Administration.Infrastructure.Configurations.Application
{
    public static class ApplicationDIConfiguration
    {
        public static IServiceCollection AddApplicationServices(
         this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AdministrationModule).Assembly);
            });


            //services.AddScoped<IMemberContext, MemberContext>();
            //services.AddScoped<IMemberRepository, MemberRepository>();
            //services.AddScoped<IWorkRepository, WorkRepository>();
            ////services.AddScoped<IWorkCommentRepository, WorkCommentRepository>();
            //services.AddScoped<IBlobFileRepository, BlobFileRepository>();
            //services.AddScoped<ITretmentRepository, TretmentRepository>();

            return services;
        }
    }
}
