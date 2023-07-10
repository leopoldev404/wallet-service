using System.Transactions;

namespace WalletService.Application.Abstractions;

public interface ITransactionRepository
{
    ValueTask SaveTransactionAsync(Transaction transaction);
    ValueTask<List<Transaction>> GetTransactionsAsync();
}