using WalletService.Application.Models;
using WalletService.Application.Queries;

namespace WalletService.Application.Abstractions;

public interface IUserService
{
    ValueTask<bool> ValidateUserAsync(GetUserQuery getUserQuery);
}