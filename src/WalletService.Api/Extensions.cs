using System.Reflection;
using MediatR;
using Serilog;
using WalletService.Application.Abstractions;
using WalletService.Infrastructure.Microservices;

namespace WalletService.Api;

public static class Extensions
{
    public static WebApplicationBuilder AddApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return builder;
    }

    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IUserService, UserService>();

        builder.Services.AddHttpClient<IUserService, UserService>("userServiceClient", client =>
            client.BaseAddress = new Uri(builder.Configuration["Microservices:User"] ?? ""));

        return builder;
    }

    public static void AddLogger(this WebApplicationBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
            .Build();

        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);
        builder.Services.AddSingleton<Serilog.ILogger>(logger);
        builder.Services.AddSingleton<Application.Logging.ILogger, Application.Logging.Logger>();
    }
}