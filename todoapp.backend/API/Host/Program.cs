using Application;
using Host.Configurations;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder
    .AddConfigurations()
    .RegisterSerilog();

builder
    .Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

await app.Services.InitializeDatabasesAsync(CancellationToken.None);

await app.Services.InitializeServiceBus();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndpoints();

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.MapIdentityApi<IdentityUser>();

app.Run();
