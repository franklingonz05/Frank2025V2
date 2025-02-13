
using CreditCard.Core.Domain.Entity;

namespace CreditCard.Core.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<TransactionView>> GetTransactionsByCardForCurrentMonthAsync(string cardNumber);
        Task<int> RegisterTransactionAsync(CreditCard.Core.Domain.Entity.Transactions transaction);
    }
}