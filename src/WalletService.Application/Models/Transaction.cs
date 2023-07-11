namespace WalletService.Application.Models;

public record Transaction(
    string UserId,
    string WalletId,
    string Timestamp,
    double Amount
);