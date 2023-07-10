using MediatR;
using WalletService.Application.Abstractions;
using WalletService.Application.Queries;

namespace WalletService.Application.handlers;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, bool>
{
    private readonly IUserService userService;

    public GetUserQueryHandler(IUserService userService)
    {
        this.userService = userService;
    }

    public async Task<bool> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await userService.ValidateUserAsync(request);
    }
}