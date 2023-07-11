using WalletService.Application.Abstractions;
using WalletService.Application.User.Queries;

namespace WalletService.Infrastructure.Microservices;

public class UserService : IUserService
{
    private readonly HttpClient userServiceClient;

    public UserService(HttpClient userServiceClient)
    {
        this.userServiceClient = userServiceClient;
    }

    public async ValueTask<bool> ValidateUserAsync(GetUserQuery getUserQuery)
    {
        // add authorization token to call custom user microservice and authenticate it
        // userServiceClient.DefaultRequestHeaders.Add("Authorization", getUserQuery.Token);

        var response = await userServiceClient
            .GetAsync($"{userServiceClient.BaseAddress}/{getUserQuery.UserId}");

        return response.IsSuccessStatusCode;
    }
}