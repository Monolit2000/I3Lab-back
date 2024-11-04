using Hangfire;
using I3Lab.Treatments.Infrastructure.Processing.InternalCommands;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace I3Lab.Treatments.Infrastructure.Processing.Hangfire
{
    public static class HangfireExtension
    {
        public static IApplicationBuilder UseHangfire(this WebApplication app)
        {
            app.Services
                .GetRequiredService<IRecurringJobManager>()
                .AddOrUpdate<ProcessInternalCommandsHangFireJob>(
                "process-internal-commands-job",  
                x => x.Execute(),                
                "*/2 * * * * *");

            return app;
        }
    }
}
