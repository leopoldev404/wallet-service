using MediatR;

namespace WalletService.Application.Queries;

public record GetUserQuery(string UserId, string Token) : IRequest<bool>;