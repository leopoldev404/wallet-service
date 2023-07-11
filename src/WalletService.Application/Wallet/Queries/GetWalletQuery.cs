using MediatR;

namespace WalletService.Application.Wallet.Queries;

public record GetWalletQuery() : IRequest<Models.Wallet>;

