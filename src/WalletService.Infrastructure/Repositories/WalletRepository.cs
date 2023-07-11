using System.Data.SqlClient;
using Dapper;
using WalletService.Application.Abstractions;
using WalletService.Application.Models;
using WalletService.Application.Wallet.Queries;
using WalletService.Application.Wallets.Commands;
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

    public async ValueTask AddWalletAsync(CreateWalletCommand createWalletCommand)
    {
        var entity = new WalletEntity(
            "id",
            "wallet",
            "USD",
            DateTime.UtcNow.ToUniversalTime().ToString(),
            0.0,
            "userId");

        string sqlStatement =
"""
INSERT INTO wallets (id, name, currency, createdAt, balance, userId)
VALUES (@Id, @Name, @Currency, @CreatedAt, @Balance, @UserId)
""";

        using var connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(sqlStatement, entity);
    }

    public async ValueTask<Wallet> GetWalletAsync(GetWalletQuery getWalletQuery)
    {
        string sqlStatement = SqlStatements.GetSelectWalletSqlStatement();

        using var connection = new SqlConnection(connectionString);

        var walletEntity = await connection
            .QuerySingleOrDefaultAsync<WalletEntity>(sqlStatement, getWalletQuery);

        return new Wallet(
            walletEntity.Id,
            walletEntity.Name,
            walletEntity.Currency,
            walletEntity.CreatedAt,
            walletEntity.Balance
        );
    }

    public async ValueTask<IEnumerable<Wallet>> GetWalletsAsync(GetWalletsQuery getWalletsQuery)
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
        return await connection.QueryAsync<Wallet>(sqlStatement, getWalletsQuery);
    }

    public async ValueTask UpdateWalletBalanceAsync(UpdateWalletBalanceCommand updateWalletBalanceCommand)
    {
        throw new NotImplementedException();
    }

    public async ValueTask InitDBAsync()
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand("", connection);
        command.ExecuteNonQuery();
    }
}