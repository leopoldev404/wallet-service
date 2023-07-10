using MediatR;
using WalletService.Application.Models;

namespace WalletService.Application.Commands;

public record CreateWalletCommand(
    string UserId,
    string WalletName,
    string Currency) : IRequest<Wallet>;
