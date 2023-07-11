using MediatR;

namespace WalletService.Application.Wallets.Commands;

public record UpdateWalletBalanceCommand(
    string UserId,
    string WalletId,
    string Operation,
    double Amount) : IRequest;
