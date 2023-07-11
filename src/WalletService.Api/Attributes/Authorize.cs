using System.Text.Json.Nodes;
using MediatR;
using WalletService.Application.Abstractions;
using WalletService.Application.User.Queries;

namespace WalletService.Api.Attributes;

public class Authorize : IEndpointFilter
{
    private readonly IMediator mediator;
    private readonly IUserService userService;
    private readonly Application.Logging.ILogger logger;

    public Authorize(
        IMediator mediator,
        IUserService userService,
        Application.Logging.ILogger logger)
    {
        this.mediator = mediator;
        this.userService = userService;
        this.logger = logger;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        string? userId = await GetUserId(context);
        if (string.IsNullOrEmpty(userId))
        {
            return Results.BadRequest("Missing Required Parameter");
        }

        string? token = context.HttpContext.Request.Headers["Authorization"];

        if (string.IsNullOrEmpty(token) ||
            !await userService.ValidateUserAsync(new GetUserQuery(userId, token)))
        {
            return Results.Unauthorized();
        }

        return await next(context);
    }

    private async ValueTask<string?> GetUserId(EndpointFilterInvocationContext context)
    {
        string? userId = context.HttpContext.Request.Query["userId"];
        logger.LogInfo($"UserId: {userId}");

        if (string.IsNullOrEmpty(userId) &&
            context.HttpContext.Request.Method.Equals(HttpMethod.Post))
        {
            var bodyAsText = await new StreamReader(context.HttpContext.Request.Body).ReadToEndAsync();
            var jsonBody = JsonNode.Parse(bodyAsText);
            userId = jsonBody?["userId"]?.ToString();
            context.HttpContext.Request.Body.Position = 0;
        }

        return userId;
    }
}