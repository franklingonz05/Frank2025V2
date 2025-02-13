using CreditCard.Core.Domain.Entity;

namespace CreditCard.Core.Interfaces
{
    public interface IAccountStatementRepository
    {
        Task<AccountStatement> GetAccountStatementByIdAsync(string cardNumber);
        Task<IEnumerable<AccountStatement>> GetAccountStatementsAsync();
    }
}