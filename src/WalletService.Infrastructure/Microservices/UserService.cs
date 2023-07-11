using WalletService.Application.Abstractions;
using WalletService.Application.User.Queries;

namespace WalletService.Infrastructure.Microservices;

public class UserService : IUserService
{
    private readonly IHttpClientFactory httpClientFactory;

    public UserService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async ValueTask<bool> ValidateUserAsync(GetUserQuery getUserQuery)
    {
        var userServiceClient = httpClientFactory.CreateClient("userServiceClient");

        // add authorization token to call custom user microservice and authenticate it
        // userServiceClient.DefaultRequestHeaders.Add("Authorization", getUserQuery.Token);

        var response = await userServiceClient
            .GetAsync($"{userServiceClient.BaseAddress}/{getUserQuery.UserId}");

        return response.IsSuccessStatusCode;
    }
}