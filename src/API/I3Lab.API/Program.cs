using Hangfire;
using Asp.Versioning;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;
using Hangfire.PostgreSql;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using I3Lab.API.Configuration;
using I3Lab.Users.Infrastructure.JWT;
using I3Lab.Users.Infrastructure.Startup;
using I3Lab.BuildingBlocks.Infrastructure;
using I3Lab.Clinics.Infrastructure.Startup;
using I3Lab.Treatments.Infrastructure.Startup;
using I3Lab.BuildingBlocks.Infrastructure.StartUp;
using I3Lab.Administration.Infrastructure.StartUp;
using I3Lab.Modules.BlobFailes.Infrastructure.Startup;
using I3Lab.Users.Infrastructure.Persistence.Extensions;
using I3Lab.Modules.BlobFailes.Infrastructure.Persistence;
using I3Lab.Clinics.Infrastructure.Persistence.Extensions;
using I3Lab.Treatments.Infrastructure.Persistence.Extensions;
using I3Lab.BuildingBlocks.Infrastructure.Configurations.EventBus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();



//builder.Host.UseSerilog((context, loggerConfig)
//    => loggerConfig.ReadFrom.Configuration(context.Configuration));

//builder.Logging.AddSerilog();


builder.Services
    .AddOpenTelemetry()
    .ConfigureResource(builder => builder.AddService(serviceName: "i3lab-api"))
    .WithMetrics(metrics =>
    {
        metrics
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation();

        metrics.AddOtlpExporter();
    })
    .WithTracing(tracing =>
    {
        tracing.AddHttpClientInstrumentation()
               .AddAspNetCoreInstrumentation()
               .AddEntityFrameworkCoreInstrumentation()
               .AddSource(MassTransit.Logging.DiagnosticHeaders.DefaultListenerName);

        tracing.AddOtlpExporter();
    });

builder.Logging.AddOpenTelemetry(logging => logging.AddOtlpExporter());





builder.Services.AddControllers();


builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));



builder.Services.AddApiVersioning(options =>
{

    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = ApiVersion.Default;  /*new ApiVersion(1);*/

    options.ApiVersionReader = new UrlSegmentApiVersionReader();
})
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'V";
        options.SubstituteApiVersionInUrl = true;
    });


builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddHangfire(x =>
x.UseSimpleAssemblyNameTypeSerializer()
.UseRecommendedSerializerSettings()
.UsePostgreSqlStorage(options => options.UseNpgsqlConnection(builder.Configuration.GetConnectionString("Database")))
);

builder.Services.AddHangfireServer(x => x.SchedulePollingInterval = TimeSpan.FromSeconds(2));


builder.Services.AddBuildingBlocksModule(builder.Configuration);

builder.Services
    .AddUserModule(builder.Configuration)
    .AddClinicModule(builder.Configuration)
    .AddBlobFileModule(builder.Configuration)
    .AddTreatmentModule(builder.Configuration)
    .AddAdministrationModule(builder.Configuration);

builder.Services.AddMassTransitRabbitMqEventBus(builder.Configuration);



var app = builder.Build();

ServiceFactory.Configure(app.Services);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var deacriptions = app.DescribeApiVersions();

        foreach(var deacription in deacriptions)
        {
            string url = $"/swagger/{deacription.GroupName}/swagger.json";
            string name = deacription.GroupName.ToUpperInvariant();

            options.SwaggerEndpoint(url, name);
        }
    });

    //app.ClearDbContextMigrations();

    app.ApplyUserContextMigrations();
    app.ApplyWorkContextMigrations();
    //app.ApplyDoctorContextMigrations();
    app.ApplyClinicContextMigrations();

    app.ApplyBlobFaileContextMigrations();
}


app.UseHttpsRedirection();

app.MapHealthChecks("health");

//app.UseSerilogRequestLogging();

app.MapControllers();


app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = [],
});
//app.UseAuthentication();
//app.UseAuthorization();

//app.MapIdentityApi<User>();

app.Run();

