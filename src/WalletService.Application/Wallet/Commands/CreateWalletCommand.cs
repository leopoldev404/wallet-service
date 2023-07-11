using MediatR;

namespace WalletService.Application.Wallets.Commands;

public record CreateWalletCommand(
    string UserId,
    string WalletName,
    string Currency) : IRequest<Models.Wallet>;
