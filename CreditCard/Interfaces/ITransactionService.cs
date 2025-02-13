using CreditCard.Models.Commons;
using CreditCard.Models.DTOs;

namespace CreditCard.Interfaces
{
    public interface ITransactionService
    {
        Task<BaseResponse<int>> CreateAsync(CreateTransaction create);
        Task<BaseResponse<IEnumerable<TransactionDTOList>>> GetTransactionsByCardIdAsync(string creditCardId);
    }
}