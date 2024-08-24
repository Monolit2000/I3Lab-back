using I3Lab.Users.Infrastructure.Persistence.Extensions;
using I3Lab.Users.Infrastructure.Startup;
using I3Lab.Users.Infrastructure.JWT;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using I3Lab.API.Configuration;
using Serilog;
using OpenTelemetry.Logs;
using OpenTelemetry.Exporter;
using I3Lab.BuildingBlocks.Infrastructure.StartUp;
using I3Lab.Works.Infrastructure.Persistence.Extensions;
using I3Lab.Works.Infrastructure.Startup;
using I3Lab.BuildingBlocks.Infrastructure.Configurations.EventBus;
using I3Lab.Doctors.Infrastructure.Startup;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
//builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();


builder.Host.UseSerilog((context, loggerConfig) =>
loggerConfig.ReadFrom.Configuration(context.Configuration));

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

builder.Services.AddControllers();


builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));



//builder.Services.AddIdentityCore<User>()
//    .AddEntityFrameworkStores<UserContext>()
//    .AddApiEndpoints();

builder.Services.AddHttpContextAccessor();

builder.Services.AddBuildingBlocksModule(builder.Configuration);

builder.Services
    .AddUserModule(builder.Configuration)
    .AddWorkModule(builder.Configuration)
    .AddDoctorModule(builder.Configuration);

builder.Services.AddMassTransitRabbitMqEventBus(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyUserContextMigrations();
    app.ApplyWorkContextMigrations();
    app.ApplyWorkContextMigrations();
}

app.UseHttpsRedirection();

app.MapHealthChecks("health");

app.UseSerilogRequestLogging();

app.MapControllers();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapIdentityApi<User>();

app.Run();

