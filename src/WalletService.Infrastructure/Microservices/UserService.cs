using WalletService.Application.Abstractions;
using WalletService.Application.Models;
using WalletService.Application.Queries;

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
        userServiceClient.DefaultRequestHeaders.Add("Authorization", getUserQuery.Token);

        var response = await userServiceClient
            .GetAsync($"{userServiceClient.BaseAddress}/{getUserQuery.UserId}");

        return response.IsSuccessStatusCode;
    }
}