using WalletService.Application.Models;

namespace WalletService.Application.Abstractions;

public interface IWalletRepository
{
    ValueTask<Models.Wallet> GetWalletAsync(string userId, string walletId);
    ValueTask<IEnumerable<Models.Wallet>> GetWalletsAsync(string userId, int pageNumber, int pageSize);
    ValueTask AddWalletAsync(Models.Wallet wallet, string userId);
    ValueTask UpdateWalletBalanceAsync(string userId, string walletId, string operation, double amount);
    ValueTask InitDBAsync();
}