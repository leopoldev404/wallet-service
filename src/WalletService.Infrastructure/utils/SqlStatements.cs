namespace WalletService.Infrastructure.utils;

public static class SqlStatements
{
    public static string GetSelectWalletSqlStatement()
        => "SELECT * FROM wallets WHERE id = @walletId AND userId = @userId";



    public static string GetInsertTransactionSqlStatement()
        => "INSERT INTO transactions (userId, walletId, timestamp, amount) VALUES (@UserId, @WalletId, @Timestamp, @Amount)";

}