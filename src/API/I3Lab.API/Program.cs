using Serilog;
using I3Lab.Users.Infrastructure.JWT;
using I3Lab.Users.Infrastructure.Startup;
using I3Lab.Treatments.Infrastructure.Startup;
using I3Lab.BuildingBlocks.Infrastructure;
using I3Lab.Doctors.Infrastructure.Startup;
using I3Lab.BuildingBlocks.Infrastructure.StartUp;
using I3Lab.Administration.Infrastructure.StartUp;
using I3Lab.Users.Infrastructure.Persistence.Extensions;
using I3Lab.Treatments.Infrastructure.Persistence.Extensions;
using I3Lab.Doctors.Infrastructure.Persistence.Extensions;
using I3Lab.BuildingBlocks.Infrastructure.Configurations.EventBus;
using I3Lab.Clinics.Infrastructure.Startup;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Metrics;
using I3Lab.Clinics.Infrastructure.Persistence.Extensions;
using I3Lab.Modules.BlobFailes.Infrastructure.Startup;
using I3Lab.Modules.BlobFailes.Infrastructure.Persistence;
using Asp.Versioning;
using I3Lab.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
//builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();


builder.Host.UseSerilog((context, loggerConfig) 
    => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Logging.AddSerilog();


//builder.Logging.ClearProviders();
//builder.Logging.AddOpenTelemetry(x => 
//{
//    x.AddOtlpExporter(a =>
//    {
//        a.Endpoint = new Uri();
//        a.Protocol = OtlpExportProtocol.HttpProtobuf;
//        a.Headers = "";
//    });
//});

builder.Services.AddOpenTelemetry()
    .ConfigureResource(builder => builder.AddService(serviceName: "i3lab.api"))
    .WithTracing(tracing =>
    {
        tracing.AddHttpClientInstrumentation()
               .AddAspNetCoreInstrumentation()
               .AddSource(MassTransit.Logging.DiagnosticHeaders.DefaultListenerName);

        tracing.AddOtlpExporter();
    });

builder.Services.AddControllers();


builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));



//builder.Services.AddIdentityCore<User>()
//    .AddEntityFrameworkStores<UserContext>()
//    .AddApiEndpoints();


builder.Services.AddApiVersioning(options =>
{

    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = ApiVersion.Default;  /*new ApiVersion(1);*/

    options.ApiVersionReader = new UrlSegmentApiVersionReader();
})
    //.AddMvc()
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'V";
        options.SubstituteApiVersionInUrl = true;
    });


builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();


//ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
//        new HeaderApiVersionReader());

builder.Services.AddHttpContextAccessor();

builder.Services.AddBuildingBlocksModule(builder.Configuration);

builder.Services
    .AddUserModule(builder.Configuration)
    .AddWorkModule(builder.Configuration)
    .AddDoctorModule(builder.Configuration)
    .AddAdministrationModule(builder.Configuration)
    .AddClinicModule(builder.Configuration)
    .AddBlobFileModule(builder.Configuration);

builder.Services.AddMassTransitRabbitMqEventBus(builder.Configuration);




var app = builder.Build();

ServiceFactory.Configure(app.Services);

// Configure the HTTP request pipeline.
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
    app.ApplyDoctorContextMigrations();
    app.ApplyClinicContextMigrations();

    app.ApplyBlobFaileContextMigrations();
}

app.UseHttpsRedirection();

app.MapHealthChecks("health");

app.UseSerilogRequestLogging();

app.MapControllers();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapIdentityApi<User>();

app.Run();

