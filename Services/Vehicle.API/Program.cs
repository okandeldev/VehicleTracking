
global using VehicleAPI.Application.DTOs;
global using VehicleAPI.Core.Domain.Entities;
using Core.Shared;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging.Console;
using System.Reflection;
using VehicleAPI.Application.Validator;
using VehicleAPI.Infrastructure.Persistence;
using EventBusRabbitMQ; 
using RabbitMQ.Client;
using VehicleAPI.Infrastructure.RabbitMQ;
using VehicleAPI.Extentions;
using VehicleAPI.Common.HubConfig;
using VehicleAPI.Core.Repositories;
using VehicleAPI.Infrastructure.Repositories; 
using Core.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
});

builder.Services.AddScoped<IValidator<VehicleCreateDTO>, VehicleCreateValidator>();
builder.Services.AddScoped<IValidator<VehicleUpdateDTO>, VehicleUpdateValidator>();
builder.Services.AddDatabaseContext<VehicleContext>(builder.Configuration);


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IVehiclesRepository), typeof(VehiclesRepository));
builder.Services.AddScoped(typeof(IVehicleStatusRepository), typeof(VehicleStatusRepository)); 
  

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();
builder.Services.AddSingleton<NotificationsHub>();


using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddSimpleConsole(i => i.ColorBehavior = LoggerColorBehavior.Disabled);
});

var logger = loggerFactory.CreateLogger<Program>();
builder.Services.AddSingleton(typeof(ILogger), logger!);

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});


IConfiguration configuration = builder.Configuration;

builder.Services.AddSingleton<IRabbitMQConnection>(sp =>
{
    var factory = new ConnectionFactory()
    {
        HostName = configuration["EventBus:HostName"]
    };

    if (!string.IsNullOrEmpty(configuration["EventBus:UserName"]))
    {
        factory.UserName = configuration["EventBus:UserName"];
    }

    if (!string.IsNullOrEmpty(configuration["EventBus:Password"]))
    {
        factory.Password = configuration["EventBus:Password"];
    }

    return new RabbitMQConnection(factory);
});

builder.Services.AddSingleton<EventBusRabbitMQConsumer>();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRabbitListener();
app.UseAuthorization();

app.MapControllers();
app.MapHub<NotificationsHub>("/notifications");

app.Run();
