using MediatR;
namespace WalletService.Application.Wallet.Queries;

public record GetWalletsQuery(
    string UserId,
    int PageNumber,
    int PageSize) : IRequest<List<Models.Wallet>>;