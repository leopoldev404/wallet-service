using System.Data.SqlClient;
using WalletService.Application.Models;
using WalletService.Infrastructure.Entities;

namespace WalletService.Infrastructure.Repositories;

public class TransactionRepository
{
    private readonly string connectionString;

    public TransactionRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public async ValueTask InsertTransactionAsync(Transaction transaction)
    {
        var transactionEntity = new TransactionEntity("", "", "", 0.0);
        using var connection = new SqlConnection(connectionString);
        // await connection.ExecuteAsync(SqlStatements.GetInsertTransactionSqlStatement(), transactionEntity);
    }
}