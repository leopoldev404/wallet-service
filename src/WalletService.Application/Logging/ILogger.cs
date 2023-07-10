namespace WalletService.Application.Logging;

public interface ILogger
{
    void LogInfo(string message);
    void LogError(string message);
}