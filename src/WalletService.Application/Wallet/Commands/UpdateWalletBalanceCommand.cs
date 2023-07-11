using MediatR;

namespace WalletService.Application.Wallets.Commands;

public record UpdateWalletBalanceCommand(string Operation, double Amount) : IRequest;

