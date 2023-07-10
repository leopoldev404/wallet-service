namespace WalletService.Application.Models;

public record User(
    string Id,
    string Name,
    string Email,
    string Password,
    string CreatedAt
);