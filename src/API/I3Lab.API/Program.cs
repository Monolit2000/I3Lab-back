using Npgsql;
using Serilog;
using Hangfire;
using Asp.Versioning;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;
using Hangfire.PostgreSql;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using I3Lab.API.Configuration;
using Serilog.Sinks.OpenTelemetry;
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
using Serilog.Filters;
using I3Lab.Treatments.Infrastructure.Processing.Hangfire;
using I3Lab.API.Modules.Treatments.TreatmentStageChats.Hubs;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

builder.Services
    .AddOpenTelemetry()
    .ConfigureResource(builder => builder.AddService(serviceName: "i3lab-api"))
    .WithMetrics(metrics =>
    {
        metrics
            .AddMeter("i3labMeter")
            //.AddPrometheusExporter();
            .AddProcessInstrumentation()
            .AddRuntimeInstrumentation()
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation();

        metrics.AddOtlpExporter(options =>
        options.Endpoint = new Uri(builder.Configuration["Otel:Endpoint"]));
    })
    .WithTracing(tracing =>
    {
        tracing
            .AddNpgsql()
            .AddHttpClientInstrumentation()
            .AddAspNetCoreInstrumentation()
            //.AddEntityFrameworkCoreInstrumentation()
            .AddSource(MassTransit.Logging.DiagnosticHeaders.DefaultListenerName);

        tracing.AddOtlpExporter(options => 
        options.Endpoint = new Uri(builder.Configuration["Otel:Endpoint"]));
    });

//builder.Logging.AddOpenTelemetry(logging => logging.AddOtlpExporter(options =>
//        options.Endpoint = new Uri(builder.Configuration["Otel:Endpoint"])));


// Настройка Serilog
builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
            // .Filter.ByExcluding(logEvent =>
            //logEvent.MessageTemplate.Text.Contains("Request starting"))
        .WriteTo.OpenTelemetry(options =>
        {
            options.Endpoint = context.Configuration["Otel:Endpoint"];
            options.Protocol = OtlpProtocol.Grpc;
            options.ResourceAttributes = new Dictionary<string, object>
            {
                ["service.name"] = "i3lab-api"
            };
        })
        .WriteTo.Console(); 
});


builder.Services.AddApiVersioning(options =>
{

    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = ApiVersion.Default;  /*new ApiVersion(1);*/
                                    
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
}).AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'V";
        options.SubstituteApiVersionInUrl = true;
    });


builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddHangfire(x =>
x.UseSimpleAssemblyNameTypeSerializer()
.UseRecommendedSerializerSettings()
.UsePostgreSqlStorage(options => options.UseNpgsqlConnection(builder.Configuration.GetConnectionString("Database"))));

builder.Services.AddHangfireServer(x => x.SchedulePollingInterval = TimeSpan.FromSeconds(2));


builder.Services.AddBuildingBlocksModule(builder.Configuration);

 builder.Services
    .AddTreatmentModule(builder.Configuration)
    .AddClinicModule(builder.Configuration)
    .AddBlobFileModule(builder.Configuration)
    .AddUserModule(builder.Configuration)
    .AddAdministrationModule(builder.Configuration);

builder.Services.AddMassTransitInMemoryEventBus(builder.Configuration);


var app = builder.Build();

ServiceFactory.Configure(app.Services);

//app.UseHangfire();

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

    app.ClearDbContextMigrations();

    app.ApplyUserContextMigrations();
    app.ApplyWorkContextMigrations();
    app.ApplyClinicContextMigrations();
    app.ApplyBlobFaileContextMigrations();
}

//app.UseOpenTelemetryPrometheusScrapingEndpoint();

app.UseHttpsRedirection();

app.MapHealthChecks("health");

//app.UseSerilogRequestLogging();

//app.MapHub<TreatmentStageChatHub>("/treatmentStageChatHub");

app.MapControllers();

//app.UseHangfireDashboard("/hangfire", new DashboardOptions
//{
//    Authorization = [],
//});

app.Run();




