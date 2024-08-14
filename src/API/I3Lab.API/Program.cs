using I3Lab.Users.Domain.Users;
using I3Lab.Users.Infrastructure.Persistence;
using I3Lab.Users.Infrastructure.Persistence.Extensions;
using Microsoft.AspNetCore.Identity;
using I3Lab.Users.Infrastructure.Startup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();

builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<UserContext>()
    .AddApiEndpoints();


builder.Services
    .AddUserModule(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.Run();

