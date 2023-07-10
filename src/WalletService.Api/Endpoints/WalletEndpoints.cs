using MediatR;
using WalletService.Api.Attributes;

namespace LogispinWalletSolution.Api.Endpoints;

public static class WalletEndpoints
{
    public static void MapWalletEndpoints(this WebApplication app)
    {
        string route = "api/wallets";

        app.MapGet(route, GetWalletsAsync)
            .AddEndpointFilter<Authorize>();
    }

    public static async ValueTask<IResult> GetWalletsAsync(
        IMediator mediator,
        string userId,
        int pageSize = 10,
        int pageNumber = 1)
    {
        return Results.Ok("Lol");
    }
}