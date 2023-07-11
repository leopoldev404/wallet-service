using WalletService.Application.User.Queries;

namespace WalletService.Application.Abstractions;

public interface IUserService
{
    ValueTask<bool> ValidateUserAsync(GetUserQuery getUserQuery);
}