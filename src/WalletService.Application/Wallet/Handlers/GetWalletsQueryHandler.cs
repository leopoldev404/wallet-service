using MediatR;
using WalletService.Application.Abstractions;
using WalletService.Application.Wallet.Queries;

namespace WalletService.Application.Wallet.Handlers;

public class GetWalletsQueryHandler : IRequestHandler<GetWalletsQuery, IEnumerable<Models.Wallet>>
{
    private readonly IWalletRepository walletRepository;

    public GetWalletsQueryHandler(IWalletRepository walletRepository)
    {
        this.walletRepository = walletRepository;
    }

    public async Task<IEnumerable<Models.Wallet>> Handle(GetWalletsQuery request, CancellationToken cancellationToken) =>
        await walletRepository.GetWalletsAsync(request);
}