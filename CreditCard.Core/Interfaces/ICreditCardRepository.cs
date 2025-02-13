using CreditCard.Core.Domain.Entity;

namespace CreditCard.Core.Interfaces
{
    public interface ICreditCardRepository
    {
        Task<IEnumerable<CreditCardView>> GetCreditCardAsync();
    }
}