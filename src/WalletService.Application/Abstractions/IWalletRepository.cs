using WalletService.Application.Wallet.Queries;
using WalletService.Application.Wallets.Commands;

namespace WalletService.Application.Abstractions;

public interface IWalletRepository
{
    ValueTask<Models.Wallet> GetWalletAsync(GetWalletQuery getWalletQuery);
    ValueTask<IEnumerable<Models.Wallet>> GetWalletsAsync(GetWalletsQuery getWalletsQuery);
    ValueTask AddWalletAsync(CreateWalletCommand createWalletCommand);
    ValueTask UpdateWalletBalanceAsync(UpdateWalletBalanceCommand updateWalletBalanceCommand);
    ValueTask InitDBAsync();
}