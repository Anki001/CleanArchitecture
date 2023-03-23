using CleanArch.Application;
using CleanArch.Application.Behaviours;
using CleanArch.Infrastructure;
using CleanArch.Presentation;
using MediatR;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add dependency of Application, Infrastructure and Presentaion layer
builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation();

// Register loger configuration
builder.Host.UseSerilog((context, logConfiguration) =>
    logConfiguration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.Run();