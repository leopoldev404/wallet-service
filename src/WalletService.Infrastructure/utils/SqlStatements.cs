namespace WalletService.Infrastructure.utils;

public static class SqlStatements
{
    public static string SelectWallets() =>
"""
SELECT *
FROM wallets
""";

    public static string SelectWallet() =>
"""
SELECT *
FROM wallets
WHERE id = @walletId AND userId = @userId
""";

    public static string InsertTransaction() =>
"""
INSERT INTO transactions (userId, walletId, timestamp, amount)
VALUES (@UserId, @WalletId, @Timestamp, @Amount)
""";
}