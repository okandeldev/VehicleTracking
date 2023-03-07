global using Core.Shared; 
using EventBusRabbitMQ;
using EventBusRabbitMQ.Producer;
using MediatR;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Reflection;
using TrackingAPI.Data;
using TrackingAPI.Data.Repositories;
using TrackingAPI.Models.Settings;
using TrackingAPI.Services; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(ICollectionRepository<>), typeof(BaseCollectionRepository<>));
builder.Services.AddScoped(typeof(IVehicleHistoryStatusService), typeof(VehicleHistoryStatusService));
builder.Services.AddScoped(typeof(IVehiclePingHistoryRepository), typeof(VehiclePingHistoryRepository));

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
builder.Services.AddSingleton<IMongoDataContext, MongoDataContext>();


builder.Services.AddSingleton<EventBusRabbitMQProducer>();
 
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

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
