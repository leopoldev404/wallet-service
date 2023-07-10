namespace WalletService.Infrastructure.Entities;

public record TransactionEntity(
    string UserId,
    string WalletId,
    string Timestamp,
    double Amount);
