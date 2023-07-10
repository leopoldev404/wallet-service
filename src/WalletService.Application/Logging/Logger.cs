namespace WalletService.Application.Logging;

public class Logger : ILogger
{
    private readonly Serilog.ILogger logger;

    public Logger(Serilog.ILogger logger)
    {
        this.logger = logger;
    }

    public void LogError(string message)
    {
        logger.Error(message);
    }

    public void LogInfo(string message)
    {
        logger.Information(message);
    }
}