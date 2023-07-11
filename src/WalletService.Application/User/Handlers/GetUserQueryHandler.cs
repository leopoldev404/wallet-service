using MediatR;
using WalletService.Application.Abstractions;
using WalletService.Application.User.Queries;

namespace WalletService.Application.User.Handlers;


public class GetUserQueryHandler : IRequestHandler<GetUserQuery, bool>
{
    private readonly IUserService userService;

    public GetUserQueryHandler(IUserService userService)
    {
        this.userService = userService;
    }

    public async Task<bool> Handle(GetUserQuery request, CancellationToken cancellationToken) =>
        await userService.ValidateUserAsync(request);
}