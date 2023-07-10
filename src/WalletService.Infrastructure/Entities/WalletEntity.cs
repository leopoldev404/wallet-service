namespace WalletService.Infrastructure.Entities;

public record WalletEntity(
    string Id,
    string Name,
    string Currency,
    string CreatedAt,
    double Balance,
    string UserId
);