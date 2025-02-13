
namespace CreditCard.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountStatementRepository AccountStatementRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        ICreditCardRepository CreditCardRepository { get; }

        void BeginTransaction();
        void Commit();
        void Dispose();
        void Rollback();
    }
}