using CreditCard.Interfaces;
using CreditCard.Models.Commons;
using CreditCard.Models.DTOs;

namespace CreditCard.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly IBaseRepository<TransactionDTOList> _transactionRepository;
        private readonly IBaseRepository<int> _transactionCreateRepository;

        public TransactionService(IBaseRepository<TransactionDTOList> transactionRepository, IBaseRepository<int> transactionCreateRepository)
        {
            _transactionRepository = transactionRepository;
            _transactionCreateRepository = transactionCreateRepository;
        }

        public async Task<BaseResponse<int>> CreateAsync(CreateTransaction create)
        {
            return await _transactionCreateRepository.PostAsync("Transaction", create);

        }

        public async Task<BaseResponse<IEnumerable<TransactionDTOList>>> GetTransactionsByCardIdAsync(string creditCardId)
        {
            var parametros = new Dictionary<string, string> { { "CardNumber", creditCardId } };
            return await _transactionRepository.GetListWithParamsAsync("Transaction/ByCard", parametros);
        }
    }
}
