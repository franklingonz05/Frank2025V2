using CreditCard.Interfaces;
using CreditCard.Models.Commons;
using CreditCard.Models.DTOs;

namespace CreditCard.Service
{
    public class CreditCardsService : ICreditCardsService
    {
        private readonly IBaseRepository<CreditCardDTO> repository;
        private readonly IBaseRepository<AccountStatementDTO> _accountStatement;

        public CreditCardsService(IBaseRepository<CreditCardDTO> _Repository, IBaseRepository<AccountStatementDTO> accountStatement)
        {
            repository = _Repository;
            _accountStatement = accountStatement;
        }

        public async Task<BaseResponse<IEnumerable<CreditCardDTO>>> GetAllAsync()
        {
            return await repository.GetListAsync("CreditCard");
        }


        public async Task<BaseResponse<AccountStatementDTO>> GetAccountStatemenByCardIdAsync(string creditCardId)
        {
            var parametros = new Dictionary<string, string> { { "CardNumber", creditCardId } };
            return await _accountStatement.GetWithParamsAsync("AccountStatement", parametros);
        }
    }
}
