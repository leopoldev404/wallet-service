using MediatR;
using Microsoft.AspNetCore.Mvc;
using WalletService.Api.Attributes;
using WalletService.Application.Wallet.Queries;

namespace WalletService.Api.Endpoints;

public static class WalletEndpoints
{
    public static void MapWalletEndpoints(this WebApplication app)
    {
        string route = "api/wallets";

        app.MapGet(route, GetWalletsAsync)
            .AddEndpointFilter<Authorize>();
    }

    public static async ValueTask<IResult> GetWalletsAsync(
        [FromServices] IMediator mediator,
        string userId,
        int pageSize = 10,
        int pageNumber = 1)
    {
        var getWalletsQuery = new GetWalletsQuery(userId, pageSize, pageNumber);
        var wallets = await mediator.Send(getWalletsQuery);
        return Results.Ok(wallets);
    }
}