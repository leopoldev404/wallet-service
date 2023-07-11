using MediatR;

namespace WalletService.Application.User.Queries;

public record GetUserQuery(string UserId, string Token) : IRequest<bool>;