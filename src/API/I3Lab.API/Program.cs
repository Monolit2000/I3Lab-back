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
    .AddDoctorModule(builder.Configuration)
    .AddAdministrationModule(builder.Configuration);

builder.Services.AddMassTransitRabbitMqEventBus(builder.Configuration);


var app = builder.Build();

ServiceFactory.Configure(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ClearDbContextMigrations();

    app.ApplyUserContextMigrations();
    app.ApplyWorkContextMigrations();
    app.ApplyDoctorContextMigrations();
}

app.UseHttpsRedirection();

app.MapHealthChecks("health");

app.UseSerilogRequestLogging();

app.MapControllers();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapIdentityApi<User>();

app.Run();

