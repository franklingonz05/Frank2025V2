using CreditCard.Models.Commons;
using CreditCard.Models.DTOs;

namespace CreditCard.Interfaces
{
    public interface ICreditCardsService
    {
        Task<BaseResponse<AccountStatementDTO>> GetAccountStatemenByCardIdAsync(string creditCardId);
        Task<BaseResponse<IEnumerable<CreditCardDTO>>> GetAllAsync();
    }
}