using System.Data.SqlClient;
using Dapper;
using WalletService.Application.Abstractions;
using WalletService.Application.Models;
using WalletService.Infrastructure.Entities;
using WalletService.Infrastructure.utils;

namespace WalletService.Infrastructure.Repositories;

public class WalletRepository : IWalletRepository
{
    private readonly string connectionString;

    public WalletRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public async ValueTask AddWalletAsync(Wallet wallet, string userId)
    {
        var entity = new WalletEntity(
            wallet.Id,
            wallet.Name,
            wallet.Currency,
            wallet.CreatedAt,
            wallet.Balance,
            userId);

        string sqlStatement = """
            INSERT INTO wallets (id, name, currency, createdAt, balance, userId)
            VALUES (@Id, @Name, @Currency, @CreatedAt, @Balance, @UserId)
        """;

        using var connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(sqlStatement, entity);
    }

    public async ValueTask<Wallet> GetWalletAsync(string userId, string walletId)
    {
        string sqlStatement = SqlStatements.GetSelectWalletSqlStatement();

        using var connection = new SqlConnection(connectionString);

        var walletEntity = await connection
            .QuerySingleOrDefaultAsync<WalletEntity>(sqlStatement, new { walletId, userId });

        return new Wallet(
            walletEntity.Id,
            walletEntity.Name,
            walletEntity.Currency,
            walletEntity.CreatedAt,
            walletEntity.Balance
        );
    }

    public async ValueTask<IEnumerable<Wallet>> GetWalletsAsync(string userId, int pageNumber, int pageSize)
    {
        string sqlStatement =
"""
SELECT *
FROM wallets
WHERE userId = @userId
OFFSET ((@pageNumber - 1) * @pageSize) ROWS
FETCH NEXT @pageSize ROWS ONLY;
""";

        using var connection = new SqlConnection(connectionString);

        return await connection.QueryAsync<Wallet>(
                sqlStatement, new { userId, pageNumber, pageSize });
    }

    public async ValueTask UpdateWalletBalanceAsync(string userId, string walletId, string operation, double amount)
    {
        throw new NotImplementedException();
    }

    public async ValueTask InitDBAsync()
    {
        string script = File.ReadAllText("OBSER");

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(script, connection);
        command.ExecuteNonQuery();
    }
}