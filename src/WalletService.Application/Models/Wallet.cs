namespace WalletService.Application.Models;

public record Wallet(
    string Id,
    string Name,
    string Currency,
    string CreatedAt,
    double Balance
);