
global using CustomerAPI.Core.Application.DTOs;
global using CustomerAPI.Core.Domain.Entities;
using Core.Shared;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging.Console;
using System.Reflection;
using CustomerAPI.Core.Application.Validator;
using CustomerAPI.Infrastructure.Persistence;
using Core.Repositories;
using CustomerAPI.Core.Repositories;
using CustomerAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
});

builder.Services.AddScoped<IValidator<CustomerCreateDTO>, CustomerCreateValidator>();
builder.Services.AddScoped<IValidator<CustomerUpdateDTO>, CustomerUpdateValidator>();
builder.Services.AddDatabaseContext<CustomerContext>(builder.Configuration);


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICustomersRepository), typeof(CustomersRepository));

 
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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
