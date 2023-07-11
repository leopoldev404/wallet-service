using MediatR;
using Serilog;
using WalletService.Application.Abstractions;
using WalletService.Application.Wallets.Commands;
using WalletService.Infrastructure.Microservices;

namespace WalletService.Api;

public static class Extensions
{
    public static void AddApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblyContaining<Program>());
    }

    public static void AddInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpClient<IUserService, UserService>("userServiceClient", client =>
            client.BaseAddress = new Uri(builder.Configuration["Microservices:User"] ?? ""));
    }

    public static async Task InitDBAsync(this WebApplicationBuilder builder)
    {
        using var serviceProvider = builder.Services.BuildServiceProvider();
        var mediator = serviceProvider.GetRequiredService<IMediator>();
        await mediator.Send(new InitDBCommand());
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