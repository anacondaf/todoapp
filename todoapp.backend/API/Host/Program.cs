using Application;
using Host.Configurations;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "KaiNguyen.NET Todo App API",
            Version = "v1",
            Description = "The API for the KaiNguyen.NET Todo Application",
            TermsOfService = new Uri("https://github.com/anacondaf/todoapp"),
            Contact = new OpenApiContact
            {
                Name = "Khai Nguyen Duc",
                Email = "kainguyen.business@gmail.com",
                Url = new Uri("https://www.linkedin.com/in/khai-nguyen-duc/"),
            }
        });
});

builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:3000";
        options.TokenValidationParameters.ValidateAudience = false;
    });

builder.Services.AddAuthorization();

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
    app.UseSwaggerUI(options =>
    {
        options.OAuthAppName("Swagger Client");
        options.OAuthClientId("<Your client id>");
        options.OAuthClientSecret("<Your client secret>");
        options.OAuthUseBasicAuthenticationWithAccessCodeGrant();
    });
}

//app.MapGet("identity", (ClaimsPrincipal user) => user.Claims.Select(c => new { c.Type, c.Value }))
//    .RequireAuthorization();

app.MapEndpoints();

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.MapIdentityApi<IdentityUser>();

app.Run();
