using MediatR;

namespace WalletService.Application.Commands;


public record UpdateWalletBalanceCommand(string Operation, double Amount) : IRequest;

