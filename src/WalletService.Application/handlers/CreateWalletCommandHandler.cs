using MediatR;
using WalletService.Application.Abstractions;
using WalletService.Application.Commands;
using WalletService.Application.Models;

namespace WalletService.Application.handlers;

public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, Wallet>
{
    private readonly IWalletRepository walletRepository;

    public CreateWalletCommandHandler(IWalletRepository walletRepository)
    {
        this.walletRepository = walletRepository;
    }

    public async Task<Wallet> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
    {
        var wallet = new Wallet(
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