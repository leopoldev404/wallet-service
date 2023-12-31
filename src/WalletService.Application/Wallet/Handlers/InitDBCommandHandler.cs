using MediatR;
using WalletService.Application.Abstractions;
using WalletService.Application.Wallets.Commands;

namespace WalletService.Application.Wallet.Handlers;

public class InitDBCommandHandler : IRequestHandler<InitDBCommand>
{
    private readonly IWalletRepository walletRepository;

    public InitDBCommandHandler(IWalletRepository walletRepository)
    {
        this.walletRepository = walletRepository;
    }

    public async Task Handle(InitDBCommand command, CancellationToken cancellationToken)
    {

    }
}