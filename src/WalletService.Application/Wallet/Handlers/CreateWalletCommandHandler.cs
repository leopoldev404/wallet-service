using MediatR;
using WalletService.Application.Abstractions;
using WalletService.Application.Wallets.Commands;

namespace WalletService.Application.Wallet.Handlers;

public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, Models.Wallet>
{
    private readonly IWalletRepository walletRepository;

    public CreateWalletCommandHandler(IWalletRepository walletRepository)
    {
        this.walletRepository = walletRepository;
    }

    public async Task<Models.Wallet> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
    {
        var wallet = new Models.Wallet(
            Guid.NewGuid().ToString(),
            request.WalletName,
            request.Currency,
            DateTime.UtcNow.ToUniversalTime().ToString(),
            0
        );

        await walletRepository.AddWalletAsync(wallet, request.UserId);
        return wallet;
    }
}